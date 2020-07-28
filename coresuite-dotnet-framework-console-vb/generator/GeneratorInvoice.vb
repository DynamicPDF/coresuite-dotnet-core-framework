Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements
Imports ceTe.DynamicPDF.PageElements.BarCoding
Imports System
Imports System.Configuration
Imports System.Data.SqlClient

Public Class GeneratorInvoice

    Public Shared order As List(Of GeneratorInvoiceData.Order) = GeneratorInvoiceData.Orders

    Public Shared Function Run(ByVal invoiceNumbers As String()) As Byte()
        'Add the template to the document
        Dim MyDocument As Document = New Document With {
            .Creator = "Invoice",
            .Author = "ceTe Software",
            .Title = "Invoice",
            .Template = MyInvoice.GetTemplate
        }

        ' Add Invoices to the document
        Dim item As String
        Dim data As GeneratorInvoiceData.Order

        For Each item In invoiceNumbers
            For Each data In order
                If item = data.OrderID.ToString Then
                    Dim invoice As MyInvoice = New MyInvoice()
                    invoice.Draw(data, MyDocument)
                End If
            Next
        Next

        'Outputs the Invoices to the current web MyPage
        Try
            Return MyDocument.Draw()
        Catch empty As EmptyDocumentException
            'Show an empty MyDocument error
            Return ShowErrorDocument("Document is empty. No invoices were selected.", "")
        Catch general As Exception
            'Show a general error
            Return ShowErrorDocument(general.Message, general.StackTrace)
        End Try
    End Function

    Private Shared Function ShowErrorDocument(ByVal message As String, ByVal stackTrace As String) As Byte()
        'Shows the error in a PDF MyDocument
        Dim MyDocument As Document = New Document
        Dim MyPage As Page = New Page(PageSize.Letter, PageOrientation.Portrait)

        Dim MyMessage As TextArea = New TextArea(message, 0, 0, 512, 36, Font.Helvetica, 18, RgbColor.Red)
        MyMessage.Height = MyMessage.GetRequiredHeight()
        MyPage.Elements.Add(MyMessage)

        If stackTrace.Trim().Length > 0 Then
            Dim StackTraceTop As Single = MyMessage.Y + MyMessage.Height + 20

            Dim StackTraceMessage As TextArea = New TextArea(stackTrace, 0, StackTraceTop, 512, 692 - StackTraceTop, Font.Helvetica, 10)

            MyPage.Elements.Add(New ceTe.DynamicPDF.PageElements.Label("StackTrace:", 0, StackTraceTop - 12, 512, 12, Font.HelveticaBold, 10))
            MyPage.Elements.Add(StackTraceMessage)
        End If
        MyDocument.Pages.Add(MyPage)
        Return MyDocument.Draw()
    End Function
End Class

Public Class MyInvoice

    Private subTotal As Decimal = 0
    Private freight As Decimal = 0
    Private Shared MyTemplate As Template = New Template
    Private Shared pageTemplateImagesSet As Boolean = False
    Private Shared backgroundColor As WebColor = New WebColor("#E0E0FF")
    Private Shared totalBGColor As WebColor = New WebColor("#FFC0C0")
    Private Shared thankYouText As WebColor = New WebColor("#000080")

    Shared Sub New()
        ' Uncomment the line below to add a layout grid to the pages
        'template.Elements.Add( New LayoutGrid() );

        ' Top part of Invoice
        MyTemplate.Elements.Add(New Label("Northwind Traders\n1234 International Drive\nAnywhere, Earth  ABC123", 56, 0, 200, 44, Font.Helvetica))
        MyTemplate.Elements.Add(New Label("Invoice", 0, 0, 540, 18, Font.HelveticaBold, 18, TextAlign.Right))
        MyTemplate.Elements.Add(New PageNumberingLabel("Page %%SP%% of %%ST%% ", 450, 253, 90, 20, Font.HelveticaBold, 12, TextAlign.Center))

        ' Add Invoice Details Template
        MyTemplate.Elements.Add(GetDetailsGroup())

        ' Add BillTo Template
        MyTemplate.Elements.Add(GetBillToGroup())

        ' Add ShipTo Template
        MyTemplate.Elements.Add(GetShipToGroup())

        ' Add Line Item Template
        MyTemplate.Elements.Add(GetLineItemGroup())
    End Sub

    Public Sub New()
        SetPageTemplateImage()
    End Sub


    Public Shared Function GetTemplate() As Template
        Return MyTemplate
    End Function

    Private Shared Function GetDetailsGroup() As Group
        'Returns a group containing the details template
        Dim MyGroup As Group = New Group

        MyGroup.Add(New Rectangle(340, 24, 200, 72, Grayscale.Black, backgroundColor, 0.5F))
        MyGroup.Add(New Label("Order ID:", 343, 25, 85, 12, Font.HelveticaBold, 12, TextAlign.Right))
        MyGroup.Add(New Label("Order Date:", 343, 39, 85, 12, Font.HelveticaBold, 12, TextAlign.Right))
        MyGroup.Add(New Label("Customer ID:", 343, 53, 85, 12, Font.HelveticaBold, 12, TextAlign.Right))
        MyGroup.Add(New Label("Shipped Date:", 343, 67, 85, 12, Font.HelveticaBold, 12, TextAlign.Right))
        MyGroup.Add(New Label("Shipped Via:", 343, 81, 85, 12, Font.HelveticaBold, 12, TextAlign.Right))

        Return MyGroup
    End Function

    Private Shared Function GetBillToGroup() As Group
        'Returns a group containing the bill to template
        Dim MyGroup As Group = New Group

        MyGroup.Add(New Rectangle(25, 120, 200, 90, 0.5F))
        MyGroup.Add(New Line(25, 136, 225, 136, 0.5F))
        MyGroup.Add(New Label("Bill To:", 28, 121, 200, 12, Font.HelveticaBold, 12))

        Return MyGroup
    End Function

    Private Shared Function GetShipToGroup() As Group
        'Returns a group containing the ship to template
        Dim MyGroup As Group = New Group

        MyGroup.Add(New Rectangle(315, 120, 200, 90, 0.5F))
        MyGroup.Add(New Line(315, 136, 515, 136, 0.5F))
        MyGroup.Add(New Label("Ship To:", 318, 121, 200, 12, Font.HelveticaBold, 12))

        Return MyGroup
    End Function

    Private Shared Function GetLineItemGroup() As Group
        'Returns a group containing the line items template
        Dim MyGroup As Group = New Group

        Dim I As Integer
        For I = 0 To 10 - 1 Step I + 1
            MyGroup.Add(New Rectangle(0, 306 + I * 36, 540, 18, Grayscale.Black, backgroundColor, 0.0F))
        Next

        MyGroup.Add(New Rectangle(450, 250, 90, 20, 0.5F))
        MyGroup.Add(New Rectangle(450, 702, 90, 18, Grayscale.Black, totalBGColor, 0.0F))
        MyGroup.Add(New Rectangle(0, 270, 540, 450, 0.5F))
        MyGroup.Add(New Line(0, 288, 540, 288, 0.5F))
        MyGroup.Add(New Line(0, 666, 540, 666, 0.5F))
        MyGroup.Add(New Line(60, 270, 60, 666, 0.5F))
        MyGroup.Add(New Line(360, 270, 360, 720, 0.5F))
        MyGroup.Add(New Line(450, 270, 450, 720, 0.5F))
        MyGroup.Add(New Line(450, 702, 540, 702, 0.5F))
        MyGroup.Add(New Label("Quantity", 0, 272, 60, 12, Font.HelveticaBold, 12, TextAlign.Center))
        MyGroup.Add(New Label("Description", 60, 272, 300, 12, Font.HelveticaBold, 12, TextAlign.Center))
        MyGroup.Add(New Label("Unit Price", 360, 272, 90, 12, Font.HelveticaBold, 12, TextAlign.Center))
        MyGroup.Add(New Label("Price", 450, 272, 90, 12, Font.HelveticaBold, 12, TextAlign.Center))

        MyGroup.Add(New Label("Thank you for your purchase." & vbCrLf & "We appreciate your business.", 5, 672, 350, 54, Font.HelveticaBold, 18, thankYouText))
        MyGroup.Add(New Label("Sub Total", 364, 668, 82, 12, Font.HelveticaBold, 12, TextAlign.Right))
        MyGroup.Add(New Label("Freight", 364, 686, 82, 12, Font.HelveticaBold, 12, TextAlign.Right))
        MyGroup.Add(New Label("Total", 364, 704, 82, 12, Font.HelveticaBold, 12, TextAlign.Right))

        Return MyGroup
    End Function

    Private Sub SetPageTemplateImage()
        ' Adds the image to page template if it Is Not already added
        If Not pageTemplateImagesSet Then

            MyTemplate.Elements.Add(New Image(Util.GetResourcePath("Images/DPDFLogo.png"), 0, 0, 0.16F))
            pageTemplateImagesSet = True
        End If
    End Sub

    Public Sub Draw(ByVal Data As GeneratorInvoiceData.Order, ByVal MyDocument As Document)
        'Adds the invoice if there is Data
        If Not Data Is Nothing Then
            'Sets the Freight amount
            freight = CType(Data.Freight, Decimal)

            'Draws the invoice data, returns a MyPage object if it is the last MyPage
            Dim i As Integer = 0
            Dim LastPage As Page = DrawInvoiceData(Data, MyDocument, i)
            'Draws aditional MyPages if necessary
            While LastPage Is Nothing
                LastPage = DrawInvoiceData(Data, MyDocument, i)
            End While

            'Draws the totals to the bottom of the last MyPage of the Invoice
            DrawTotals(Data, MyDocument.Pages.Item(MyDocument.Pages.Count - 1))
        End If
    End Sub

    Private Function DrawInvoiceData(ByVal Data As GeneratorInvoiceData.Order, ByVal MyDocument As Document, ByRef start As Integer) As Page
        'Tracks if the invoice is finished
        Dim InvoiceFinished As Boolean = True
        'Tracks the y position on the MyPage
        Dim YOffset As Single = 288

        'Create a MyPage for the Invoice
        Dim MyPage As Page = New Page(PageSize.Letter, PageOrientation.Portrait, 36.0F)
        'Add Details to the Invoice
        DrawInvoiceDetails(Data, MyPage)
        'Add bill to address
        MyPage.Elements.Add(New TextArea(Data.BillTo, 28, 138, 194, 70, Font.Helvetica, 12))
        'Add ship to address
        MyPage.Elements.Add(New TextArea(Data.ShipTo, 318, 138, 194, 70, Font.Helvetica, 12))

        'Add line items to the Invoice
        For i As Integer = start To Data.OrderDetails.Count - 1
            DrawLineItem(Data.OrderDetails.Item(i), MyPage, YOffset)
            'Break if at the bottom of the MyPage
            If YOffset >= 666 Then
                InvoiceFinished = False
                start = i + 1
                Exit For
            End If
        Next i

        'Add the MyPage to the MyDocument
        MyDocument.Pages.Add(MyPage)

        'If Invoice is finished return the MyPage else return null so another MyPage will be added
        If InvoiceFinished Then
            Return MyPage
        Else
            MyPage.Elements.Add(New Label("Continued...", 454, 704, 82, 12, Font.Helvetica, 12, TextAlign.Right))
            Return Nothing
        End If
    End Function

    Private Sub DrawInvoiceDetails(ByVal Data As GeneratorInvoiceData.Order, ByVal MyPage As Page)
        'Adds Invoice details to the MyPage
        MyPage.Elements.Add(New Label(Data.OrderID.ToString(), 437, 25, 100, 12, Font.Helvetica, 12))
        MyPage.Elements.Add(New Label((CType(Data.OrderDate, DateTime)).ToString("d MMM yyyy"), 437, 39, 100, 12, Font.Helvetica, 12))
        MyPage.Elements.Add(New Label(Data.CustomerID.ToString(), 437, 53, 100, 12, Font.Helvetica, 12))
        'Dim ShippedDate As Label = Nothing
        If Not Data.ShippedDate = Nothing Then
            MyPage.Elements.Add(New Label((CType(Data.ShippedDate, DateTime)).ToString("d MMM yyyy"), 437, 67, 100, 12, Font.Helvetica, 12))
        End If
        MyPage.Elements.Add(New Label(Data.ShipperName.ToString(), 437, 81, 100, 12, Font.Helvetica, 12))
        MyPage.Elements.Add(New Interleaved25(Data.OrderID.ToString(), 380, 4, 18, False))
    End Sub

    Private Sub DrawLineItem(ByVal Detail As GeneratorInvoiceData.OrderDetail, ByVal MyPage As Page, ByRef YOffset As Single)
        'Adds a line item to the invoice
        Dim Quantity As Int16 = CType(Detail.Quantity, Int16)
        Dim UnitPrice As Decimal = CType(Detail.UnitPrice, Decimal)
        Dim LineTotal As Decimal = UnitPrice * Quantity
        subTotal += LineTotal

        MyPage.Elements.Add(New Label(Quantity.ToString(), 4, 3 + YOffset, 52, 12, Font.Helvetica, 12, TextAlign.Right))
        MyPage.Elements.Add(New Label(Detail.ProductName.ToString(), 64, 3 + YOffset, 292, 12, Font.Helvetica, 12))
        MyPage.Elements.Add(New Label(UnitPrice.ToString("#,##0.00"), 364, 3 + YOffset, 82, 12, Font.Helvetica, 12, TextAlign.Right))
        MyPage.Elements.Add(New Label(LineTotal.ToString("#,##0.00"), 454, 3 + YOffset, 82, 12, Font.Helvetica, 12, TextAlign.Right))

        YOffset += 18
    End Sub

    Private Sub DrawTotals(ByVal Data As GeneratorInvoiceData.Order, ByVal MyPage As Page)
        'Add totals to the bottom of the Invoice
        Dim GrandTotal As Decimal = subTotal + freight
        MyPage.Elements.Add(New Label(subTotal.ToString("#,##0.00"), 454, 668, 82, 12, Font.Helvetica, 12, TextAlign.Right))
        MyPage.Elements.Add(New Label(freight.ToString("#,##0.00"), 454, 686, 82, 12, Font.Helvetica, 12, TextAlign.Right))
        MyPage.Elements.Add(New Label(GrandTotal.ToString("#,##0.00"), 454, 704, 82, 12, Font.Helvetica, 12, TextAlign.Right))
    End Sub
End Class
