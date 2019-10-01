Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.Extensions.Configuration
Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.IO
Imports ceTe.DynamicPDF.Text
Imports ceTe.DynamicPDF.PageElements

Namespace coresuite_dotnet_standard_vb.generator
    Public Class TableReport

        Public Shared Sub Run(outputPdfPath As String)
            ' Create a MyDocument and set it's properties
            Dim MyDocument As ceTe.DynamicPDF.Document = New ceTe.DynamicPDF.Document
            MyDocument.Creator = "Table.aspx"
            MyDocument.Author = "ceTe Software"
            MyDocument.Title = "Table Example"

            ' Establises connection to the database
            Dim Connection As SqlConnection = GetOpenDBConn()
            Dim Data As SqlDataReader = GetContactListData(Connection)

            'Create a Table and set it's properties
            Dim MyTable As Table2 = New Table2(0, 0, 512, 676, ceTe.DynamicPDF.Font.Helvetica, 12)
            MyTable.Border.Width = 1
            MyTable.CellDefault.Border.Width = 1
            MyTable.Border.Color = Grayscale.Black
            MyTable.RepeatColumnHeaderCount = 1
            MyTable.RepeatRowHeaderCount = 1

            ' Builds the report
            BuildTable(Data, MyTable)

            Dim CurrentRow As Integer = 0
            Dim CurrentColumn As Integer = 0
            Do
                CurrentRow = CurrentRow + 1
                CurrentColumn = 1
                AddTableToPage(MyDocument, MyTable, CurrentRow, CurrentColumn)
                Dim OverflowTable As Table2 = MyTable.GetOverflowColumns()
                Do
                    CurrentColumn = CurrentColumn + 1
                    AddTableToPage(MyDocument, OverflowTable, CurrentRow, CurrentColumn)
                    OverflowTable = OverflowTable.GetOverflowColumns()
                Loop While Not OverflowTable Is Nothing
                MyTable = MyTable.GetOverflowRows()
            Loop While Not MyTable Is Nothing


            ' Cleans up database connections
            Data.Close()
            Connection.Close()

            ' Outputs the Table Report to the current web MyPage
            MyDocument.Draw(outputPdfPath)
        End Sub

        Public Shared Sub AddTableToPage(ByVal MyDocument As Document, ByVal MyTable As Table2, ByVal CurrentRow As Integer, ByVal CurrentColumn As Integer)
            Dim MyPage As Page = New Page(PageSize.Letter)
            If Not MyTable Is Nothing Then
                MyPage.Elements.Add(MyTable)
            End If
            MyPage.Elements.Add(New Label("(" & CurrentRow & "," & CurrentColumn & ")", 0, MyPage.Dimensions.Body.Height - 12, MyPage.Dimensions.Body.Width, 12, Font.Helvetica, 12, TextAlign.Center))
            MyDocument.Pages.Add(MyPage)
        End Sub

        Public Shared Sub BuildTable(ByVal Data As SqlDataReader, ByVal MyTable As Table2)
            CreateColumns(MyTable)
            CreateRowHeadings(MyTable)

            While Data.Read()
                CreateRow(MyTable, Data)
            End While
        End Sub

        Public Shared Sub CreateRowHeadings(ByVal MyTable As Table2)
            Dim MyRow As Row2 = MyTable.Rows.Add(40, Font.TimesBold, 12, Grayscale.Black, Grayscale.LightGrey)
            MyRow.CellDefault.Align = TextAlign.Center
            MyRow.CellDefault.VAlign = VAlign.Top
            MyRow.Cells.Add("ID")
            MyRow.Cells.Add("Product Name")
            MyRow.Cells.Add("Supplier ID")
            MyRow.Cells.Add("Category ID")
            MyRow.Cells.Add("Quantity Per Unit")
            MyRow.Cells.Add("Unit Price")
            MyRow.Cells.Add("Unit In Stock")
            MyRow.Cells.Add("Units On Order")
            MyRow.Cells.Add("Reorder Level")
            MyRow.Cells.Add("Discontinued")
        End Sub

        Public Shared Sub CreateRow(ByVal MyTable As Table2, ByVal Data As SqlDataReader)
            Dim MyRow As Row2 = MyTable.Rows.Add(20)
            MyRow.Cells.Add(Data.GetInt32(0).ToString(), Font.Helvetica, 12, Grayscale.Black, Grayscale.LightGrey, 1)
            MyRow.Cells.Add(Data.GetString(1))
            MyRow.Cells.Add(Data.GetInt32(2).ToString())
            MyRow.Cells.Add(Data.GetInt32(3).ToString())
            MyRow.Cells.Add(Data.GetString(4))
            MyRow.Cells.Add(Data.GetDecimal(5).ToString("$0.00"))
            MyRow.Cells.Add(Data.GetInt16(6).ToString())
            MyRow.Cells.Add(Data.GetInt16(7).ToString())
            MyRow.Cells.Add(Data.GetInt16(8).ToString())
            MyRow.Cells.Add(Data.GetBoolean(9).ToString())
        End Sub

        Public Shared Sub CreateColumns(ByVal MyTable As Table2)
            MyTable.Columns.Add(25)
            MyTable.Columns.Add(150)
            MyTable.Columns.Add(90)
            MyTable.Columns.Add(90)
            MyTable.Columns.Add(120)
            MyTable.Columns.Add(60)
            MyTable.Columns.Add(90)
            MyTable.Columns.Add(90)
            MyTable.Columns.Add(90)
            MyTable.Columns.Add(90)
        End Sub
        Public Shared Function GetOpenDBConn() As SqlConnection
            ' Creates and opens a database connection
            Dim Connection As SqlConnection = New SqlConnection(Util.DynamicPDFConfiguration.GetConnectionString("NorthWindConnectionString"))
            Connection.Open()
            Return Connection
        End Function

        Public Shared Function GetContactListData(ByVal Connection As SqlConnection) As SqlDataReader
            ' Creates a DataReader for the report
            Dim Command As SqlCommand = Connection.CreateCommand()
            Command.CommandText = "SELECT * FROM Products where (UnitPrice > 15)"
            Dim DataReader As SqlDataReader = Command.ExecuteReader()

            Return DataReader
        End Function
    End Class
End Namespace