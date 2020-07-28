Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements

Public Class TableReport

    Public Shared tableData As List(Of TableReportData.Table) = TableReportData.Tables

    Public Shared Sub Run(outputPdfPath As String)
        ' Create a MyDocument and set it's properties
        Dim MyDocument As ceTe.DynamicPDF.Document = New ceTe.DynamicPDF.Document
        MyDocument.Creator = "Table.aspx"
        MyDocument.Author = "ceTe Software"
        MyDocument.Title = "Table Example"

        'Create a Table and set it's properties
        Dim MyTable As Table2 = New Table2(0, 0, 512, 676, ceTe.DynamicPDF.Font.Helvetica, 12)
        MyTable.Border.Width = 1
        MyTable.CellDefault.Border.Width = 1
        MyTable.Border.Color = Grayscale.Black
        MyTable.RepeatColumnHeaderCount = 1
        MyTable.RepeatRowHeaderCount = 1

        ' Builds the report
        BuildTable(MyTable)

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

    Public Shared Sub BuildTable(ByVal MyTable As Table2)
        CreateColumns(MyTable)
        CreateRowHeadings(MyTable)

        For Each Data As TableReportData.Table In tableData
            CreateRow(MyTable, Data)
        Next
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

    Public Shared Sub CreateRow(ByVal MyTable As Table2, ByVal Data As TableReportData.Table)
        Dim MyRow As Row2 = MyTable.Rows.Add(20)
        MyRow.Cells.Add(Data.ID.ToString(), Font.Helvetica, 12, Grayscale.Black, Grayscale.LightGrey, 1)
        MyRow.Cells.Add(Data.ProductName)
        MyRow.Cells.Add(Data.SupplierID.ToString())
        MyRow.Cells.Add(Data.CategoryID.ToString())
        MyRow.Cells.Add(Data.QuantityPerUnit)
        MyRow.Cells.Add(Data.UnitPrice.ToString("$0.00"))
        MyRow.Cells.Add(Data.UnitInStock.ToString())
        MyRow.Cells.Add(Data.UnitsOnOrder.ToString())
        MyRow.Cells.Add(Data.ReorderLevel.ToString())
        MyRow.Cells.Add(Data.Discontinued.ToString())
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
End Class



