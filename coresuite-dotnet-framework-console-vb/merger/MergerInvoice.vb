Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.Merger
Imports ceTe.DynamicPDF.PageElements
Imports ceTe.DynamicPDF.PageElements.BarCoding

Public Class MergerInvoice
    Public Shared order As List(Of MergerInvoiceData.Order) = MergerInvoiceData.Orders

    Friend Shared Function Run(invoiceNumbers() As String) As Byte()
        ' Create a document And set it's properties
        Dim Document As Document = New Document With {
        .Creator = "Invoice",
        .Author = "ceTe Software",
        .Title = "Invoice"
    }

        ' Add Invoices to the document
        Dim item As String
        Dim data As MergerInvoiceData.Order
        For Each item In invoiceNumbers
            For Each data In order
                If item = data.OrderID.ToString() Then
                    Dim Invoice As MergerInvoiceCreator = New MergerInvoiceCreator()
                    Invoice.Draw(data, Document)
                End If
            Next
        Next

        ' Outputs the Invoices to the current web page
        Try
            Return Document.Draw()
        Catch Empty As EmptyDocumentException
            ' Show an empty document error
            Return ShowErrorDocument("Document is empty. No invoices were selected.", "")
        Catch excGeneral As Exception
            'Show a general error
            Return ShowErrorDocument(excGeneral.Message, excGeneral.StackTrace)
        End Try
    End Function

    Private Shared Function ShowErrorDocument(message As String, stackTrace As String) As Byte()
        ' Shows the error in a PDF document
        Dim document As Document = New Document()
        Dim page As Page = New Page(PageSize.Letter, PageOrientation.Portrait)

        Dim messageArea As TextArea = New TextArea(message, 0, 0, 512, 36, Font.Helvetica, 18, RgbColor.Red)
        messageArea.Height = messageArea.GetRequiredHeight()
        page.Elements.Add(messageArea)

        If stackTrace.Trim().Length > 0 Then
            Dim stackTraceTop As Single = messageArea.Y + messageArea.Height + 20

            Dim stackTraceArea As TextArea = New TextArea(stackTrace, 0, stackTraceTop, 512, 692 - stackTraceTop, Font.Helvetica, 10)

            page.Elements.Add(New Label("StackTrace:", 0, stackTraceTop - 12, 512, 12, Font.HelveticaBold, 10))
            page.Elements.Add(stackTraceArea)
        End If

        document.Pages.Add(page)
        Return document.Draw()
    End Function
End Class

Public Class MergerInvoiceCreator

    Private Shared templatePath As String
    Private subTotal As Decimal = 0
    Private freight As Decimal = 0
    Private Shared templatePathSet As Boolean = False
    Public Sub New()
        SetTemplatePath()
    End Sub

    Private Sub SetTemplatePath()
        ' Adds the image to page template if it Is Not already added
        If Not templatePathSet Then
            templatePath = Util.GetResourcePath("PDFs/Invoice.pdf")
            templatePathSet = True
        End If
    End Sub

    Public Sub Draw(ByVal Data As MergerInvoiceData.Order, ByVal MyDocument As Document)
        ' Each Invoice should begin a New section
        MyDocument.Sections.Begin()

        ' Adds the invoice if there Is data
        If Not Data Is Nothing Then
            ' Sets the Freight amount
            freight = CType(Data.Freight, Decimal)

            'Draws the invoice data, returns a page object if it Is the last page
            Dim i As Integer = 0
            Dim LastPage As Page = DrawInvoiceData(Data, MyDocument, i)

            ' Draws aditional pages if necessary
            While LastPage Is Nothing
                LastPage = DrawInvoiceData(Data, MyDocument, i)
            End While
            'Draws the totals to the bottom of the last page of the Invoice
            DrawTotals(Data, MyDocument.Pages.Item(MyDocument.Pages.Count - 1))
        End If
    End Sub

    Private Function DrawInvoiceData(ByVal Data As MergerInvoiceData.Order, ByVal MyDocument As Document, ByRef start As Integer) As Page
        'Tracks if the invoice is finished
        Dim InvoiceFinished As Boolean = True
        'Tracks the y position on the MyPage
        Dim YOffset As Single = 288

        'Create a MyPage for the Invoice
        Dim MyPage As Page = New ImportedPage(templatePath, 1)
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

    Private Sub DrawInvoiceDetails(ByVal Data As MergerInvoiceData.Order, ByVal MyPage As Page)
        'Adds Invoice details to the MyPage
        MyPage.Elements.Add(New Label(Data.OrderID.ToString(), 437, 25, 100, 12, Font.Helvetica, 12))
        MyPage.Elements.Add(New Label((CType(Data.OrderDate, DateTime)).ToString("d MMM yyyy"), 437, 39, 100, 12, Font.Helvetica, 12))
        MyPage.Elements.Add(New Label(Data.CustomerID.ToString(), 437, 53, 100, 12, Font.Helvetica, 12))
        If Not Data.ShippedDate = Nothing Then
            MyPage.Elements.Add(New Label((CType(Data.ShippedDate, DateTime)).ToString("d MMM yyyy"), 437, 67, 100, 12, Font.Helvetica, 12))
        End If
        MyPage.Elements.Add(New Label(Data.ShipperName.ToString(), 437, 81, 100, 12, Font.Helvetica, 12))
        MyPage.Elements.Add(New Interleaved25(Data.OrderID.ToString(), 380, 4, 18, False))
        MyPage.Elements.Add(New PageNumberingLabel("Page %%SP%% of %%ST%% ", 450, 253, 90, 20, Font.HelveticaBold, 12, TextAlign.Center))
    End Sub

    Private Sub DrawLineItem(ByVal Data As MergerInvoiceData.OrderDetail, ByVal MyPage As Page, ByRef YOffset As Single)
        'Adds a line item to the invoice
        Dim Quantity As Int16 = CType(Data.Quantity, Int16)
        Dim UnitPrice As Decimal = CType(Data.UnitPrice, Decimal)
        Dim LineTotal As Decimal = UnitPrice * Quantity
        subTotal += LineTotal

        MyPage.Elements.Add(New Label(Quantity.ToString(), 4, 3 + YOffset, 52, 12, Font.Helvetica, 12, TextAlign.Right))
        MyPage.Elements.Add(New Label(Data.ProductName.ToString(), 64, 3 + YOffset, 292, 12, Font.Helvetica, 12))
        MyPage.Elements.Add(New Label(UnitPrice.ToString("#,##0.00"), 364, 3 + YOffset, 82, 12, Font.Helvetica, 12, TextAlign.Right))
        MyPage.Elements.Add(New Label(LineTotal.ToString("#,##0.00"), 454, 3 + YOffset, 82, 12, Font.Helvetica, 12, TextAlign.Right))

        YOffset += 18
    End Sub

    Private Sub DrawTotals(ByVal Data As MergerInvoiceData.Order, ByVal MyPage As Page)
        'Add totals to the bottom of the Invoice
        Dim GrandTotal As Decimal = subTotal + freight

        MyPage.Elements.Add(New Label(subTotal.ToString("#,##0.00"), 454, 668, 82, 12, Font.Helvetica, 12, TextAlign.Right))
        MyPage.Elements.Add(New Label(freight.ToString("#,##0.00"), 454, 686, 82, 12, Font.Helvetica, 12, TextAlign.Right))
        MyPage.Elements.Add(New Label(GrandTotal.ToString("#,##0.00"), 454, 704, 82, 12, Font.Helvetica, 12, TextAlign.Right))
    End Sub
End Class


