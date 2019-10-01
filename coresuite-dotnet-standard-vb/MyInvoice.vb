Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements
Imports ceTe.DynamicPDF.PageElements.BarCoding
Imports System
Imports System.Data.SqlClient

Namespace coresuite_dotnet_standard_vb

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

        Public Sub Draw(ByVal Connection As SqlConnection, ByVal MyDocument As Document, ByVal invoiceNumber As Integer)
            'Gets the Invoice data
            Dim Data As SqlDataReader = GetInvoiceData(Connection, invoiceNumber)

            'Adds the invoice if there is Data
            If Data.Read() Then
                'Sets the Freight amount
                freight = CType(Data("Freight"), Decimal)

                'Draws the invoice data, returns a MyPage object if it is the last MyPage
                Dim LastPage As Page = DrawInvoiceData(Data, MyDocument)
                'Draws aditional MyPages if necessary
                While LastPage Is Nothing
                    LastPage = DrawInvoiceData(Data, MyDocument)
                End While

                'Draws the totals to the bottom of the last MyPage of the Invoice
                DrawTotals(Data, LastPage)
            End If

            'Close DataReader
            Data.Close()
        End Sub

        Private Function DrawInvoiceData(ByVal Data As SqlDataReader, ByVal MyDocument As Document) As Page
            'Tracks if the invoice is finished
            Dim InvoiceFinished As Boolean = True
            'Tracks the y position on the MyPage
            Dim YOffset As Single = 288

            'Create a MyPage for the Invoice
            Dim MyPage As Page = New Page(PageSize.Letter, PageOrientation.Portrait, 36.0F)
            'Add Details to the Invoice
            DrawInvoiceDetails(Data, MyPage)
            'Add bill to address
            DrawBillTo(Data, MyPage)
            'Add ship to address
            DrawShipTo(Data, MyPage)

            'Add line items to the Invoice
            While DrawLineItem(Data, MyPage, YOffset)
                'Break if at the bottom of the MyPage
                If YOffset >= 666 Then
                    InvoiceFinished = False
                    Exit While
                End If
            End While

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

        Private Sub DrawInvoiceDetails(ByVal Data As SqlDataReader, ByVal MyPage As Page)
            'Adds Invoice details to the MyPage
            MyPage.Elements.Add(New Label(Data("OrderID").ToString(), 437, 25, 100, 12, Font.Helvetica, 12))
            MyPage.Elements.Add(New Label((CType(Data("OrderDate"), DateTime)).ToString("d MMM yyyy"), 437, 39, 100, 12, Font.Helvetica, 12))
            MyPage.Elements.Add(New Label(Data("CustomerID").ToString(), 437, 53, 100, 12, Font.Helvetica, 12))
            If Not TypeOf Data("ShippedDate") Is DBNull Then
                MyPage.Elements.Add(New Label((CType(Data("ShippedDate"), DateTime)).ToString("d MMM yyyy"), 437, 67, 100, 12, Font.Helvetica, 12))
            End If
            MyPage.Elements.Add(New Label(Data("ShipperName").ToString(), 437, 81, 100, 12, Font.Helvetica, 12))
            MyPage.Elements.Add(New Interleaved25(Data("OrderID").ToString(), 380, 4, 18, False))
        End Sub

        Private Sub DrawBillTo(ByVal Data As SqlDataReader, ByVal MyPage As Page)
            'Adds bill to address
            Dim BillToAddress As String =
                    Data("BillName").ToString() & vbCrLf &
                    Data("BillAddress").ToString() & vbCrLf &
                    Data("BillCity").ToString() & ", " &
                    Data("BillPostalCode").ToString() & vbCrLf &
                    Data("BillCountry").ToString()

            MyPage.Elements.Add(New TextArea(BillToAddress, 28, 138, 194, 70, Font.Helvetica, 12))
        End Sub

        Private Sub DrawShipTo(ByVal Data As SqlDataReader, ByVal MyPage As Page)
            'Adds ship to address
            Dim ShipToAddress As String =
                    Data("ShipName").ToString() & vbCrLf &
                    Data("ShipAddress").ToString() & vbCrLf &
                    Data("ShipCity").ToString() & ", " &
                    Data("ShipPostalCode").ToString() & vbCrLf &
                    Data("ShipCountry").ToString()

            MyPage.Elements.Add(New TextArea(ShipToAddress, 318, 138, 194, 70, Font.Helvetica, 12))
        End Sub

        Private Function DrawLineItem(ByVal Data As SqlDataReader, ByVal MyPage As Page, ByRef YOffset As Single) As Boolean
            'Adds a line item to the invoice
            Dim Quantity As Int16 = CType(Data("Quantity"), Int16)
            Dim UnitPrice As Decimal = CType(Data("UnitPrice"), Decimal)
            Dim LineTotal As Decimal = UnitPrice * Quantity
            subTotal += LineTotal

            MyPage.Elements.Add(New Label(Quantity.ToString(), 4, 3 + YOffset, 52, 12, Font.Helvetica, 12, TextAlign.Right))
            MyPage.Elements.Add(New Label(Data("ProductName").ToString(), 64, 3 + YOffset, 292, 12, Font.Helvetica, 12))
            MyPage.Elements.Add(New Label(UnitPrice.ToString("#,##0.00"), 364, 3 + YOffset, 82, 12, Font.Helvetica, 12, TextAlign.Right))
            MyPage.Elements.Add(New Label(LineTotal.ToString("#,##0.00"), 454, 3 + YOffset, 82, 12, Font.Helvetica, 12, TextAlign.Right))

            YOffset += 18

            'Advanses the recordset and returns if there are additional records
            Return Data.Read()
        End Function

        Private Sub DrawTotals(ByVal Data As SqlDataReader, ByVal MyPage As Page)
            'Add totals to the bottom of the Invoice
            Dim GrandTotal As Decimal = subTotal + freight

            MyPage.Elements.Add(New Label(subTotal.ToString("#,##0.00"), 454, 668, 82, 12, Font.Helvetica, 12, TextAlign.Right))
            MyPage.Elements.Add(New Label(freight.ToString("#,##0.00"), 454, 686, 82, 12, Font.Helvetica, 12, TextAlign.Right))
            MyPage.Elements.Add(New Label(GrandTotal.ToString("#,##0.00"), 454, 704, 82, 12, Font.Helvetica, 12, TextAlign.Right))
        End Sub

        Private Function GetInvoiceData(ByVal Connection As SqlConnection, ByVal invoiceNumber As Integer) As SqlDataReader
            'Creates a DataReader for the Invioce
            Dim command As SqlCommand = Connection.CreateCommand()
            command.CommandText = "SELECT o.OrderID, o.CustomerID, o.OrderDate, o.ShippedDate, Freight, " &
                "		o.ShipName, o.ShipAddress, o.ShipCity, o.ShipPostalCode, o.ShipCountry, " &
                "		c.CompanyName as BillName, c.Address as BillAddress, " &
                "		c.City as BillCity, c.PostalCode as BillPostalCode, " &
                "		c.Country as BillCountry, s.CompanyName as ShipperName, " &
                "		p.ProductName, od.UnitPrice, od.Quantity " &
                "FROM	Orders o " &
                "JOIN	Customers c ON " &
                "		o.CustomerID = c.CustomerID " &
                "JOIN	Shippers s ON " &
                "		o.ShipVia = s.ShipperID " &
                "JOIN	[Order Details] od ON " &
                "		o.OrderID = od.OrderID " &
                "JOIN	Products p ON " &
                "		od.ProductID = p.ProductID " &
                "WHERE	o.OrderID = " & invoiceNumber
            Dim DataReader As SqlDataReader = command.ExecuteReader()

            Return DataReader
        End Function
    End Class
End Namespace