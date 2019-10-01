Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.Merger
Imports ceTe.DynamicPDF.PageElements
Imports ceTe.DynamicPDF.PageElements.BarCoding
Imports System.Data.SqlClient

Namespace coresuite_asp_dotnet_framework_mvc_vb.CodeFiles

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
                templatePath = HttpContext.Current.Server.MapPath("~/PDFs/Invoice.pdf")
                templatePathSet = True
            End If
        End Sub

        Public Sub Draw(ByVal Connection As SqlConnection, ByVal MyDocument As Document, ByVal invoiceNumber As Integer)
            ' Each Invoice should begin a New section
            MyDocument.Sections.Begin()

            ' Gets the Invoice data
            Dim Data As SqlDataReader = GetInvoiceData(Connection, invoiceNumber)

            ' Adds the invoice if there Is data
            If Data.Read() Then
                ' Sets the Freight amount
                freight = CType(Data("Freight"), Decimal)

                'Draws the invoice data, returns a page object if it Is the last page
                Dim LastPage As Page = DrawInvoiceData(Data, MyDocument)

                ' Draws aditional pages if necessary
                While LastPage Is Nothing
                    LastPage = DrawInvoiceData(Data, MyDocument)
                End While
                'Draws the totals to the bottom of the last page of the Invoice
                DrawTotals(Data, LastPage)
            End If

            ' Close DataReader
            Data.Close()
        End Sub

        Private Function DrawInvoiceData(ByVal Data As SqlDataReader, ByVal MyDocument As Document) As Page
            'Tracks if the invoice is finished
            Dim InvoiceFinished As Boolean = True
            'Tracks the y position on the MyPage
            Dim YOffset As Single = 288

            'Create a MyPage for the Invoice
            Dim MyPage As Page = New ImportedPage(templatePath, 1)
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
            MyPage.Elements.Add(New PageNumberingLabel("Page %%SP%% of %%ST%% ", 450, 253, 90, 20, Font.HelveticaBold, 12, TextAlign.Center))
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