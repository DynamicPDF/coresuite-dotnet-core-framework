Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.Merger
Imports ceTe.DynamicPDF.Merger.Forms
Imports ceTe.DynamicPDF.PageElements

Public Class FormFieldReader

    Public Shared Sub Run(outputPdfPath As String)
        Dim PdfDocument As PdfDocument = New PdfDocument(Util.GetResourcePath("PDFs/fw9AcroForm_18_filled.pdf"))
        'Create Table to display the form fields and values
        Dim MyTable As Table2 = New Table2(0, 0, 512, 676, ceTe.DynamicPDF.Font.Helvetica, 12)
        MyTable.Border.Width = 1.0F
        MyTable.Border.Color = Grayscale.Black
        MyTable.RepeatColumnHeaderCount = 1
        MyTable.RepeatRowHeaderCount = 1

        BuildTable(MyTable)

        CreateList(MyTable, PdfDocument.Form.Fields)

        Dim MyDocument As Document = New Document
        AddTableToPage(MyDocument, MyTable)

        Dim OverflowRowTable As Table2 = MyTable.GetOverflowRows()

        While Not OverflowRowTable Is Nothing
            AddTableToPage(MyDocument, OverflowRowTable)
            OverflowRowTable = OverflowRowTable.GetOverflowRows()
        End While

        MyDocument.Draw(outputPdfPath)
    End Sub

    Private Shared Sub CreateList(ByVal MyTable As Table2, ByVal FieldList As ceTe.DynamicPDF.Merger.Forms.PdfFormFieldList)
        Dim I As Integer
        For I = 0 To FieldList.Count - 1
            ' Dim fieldType As String = fieldList(I).GetType().ToString()
            Dim MyRow As Row2 = MyTable.Rows.Add(20)
            MyRow.Cells.Add(FieldList(I).FullName)
            MyRow.Cells.Add(GetFieldType(FieldList(I)))
            MyRow.Cells.Add(FieldList(I).GetValue())

            If FieldList(I).HasChildFields = True Then
                CreateList(MyTable, FieldList(I).ChildFields)
            End If
        Next
    End Sub

    Private Shared Function GetFieldType(ByVal PdfFormField As PdfFormField) As String
        If TypeOf PdfFormField Is PdfTextField Then
            Return "Text Field"
        End If

        If TypeOf PdfFormField Is PdfButtonField Then
            Return "Button Field"
        End If

        If TypeOf PdfFormField Is PdfChoiceField Then
            Return "Choice Field"
        End If

        If TypeOf PdfFormField Is PdfSignatureField Then
            Return "Signature Field"
        End If

        Return "Container Field"
    End Function

    Private Shared Sub BuildTable(ByVal MyTable As Table2)
        CreateColumns(MyTable)
        CreateRowHeadings(MyTable)
    End Sub

    Private Shared Sub AddTableToPage(ByVal MyDocument As Document, ByVal MyTable As Table2)
        Dim MyPage As Page = New Page(PageSize.Letter)
        If Not MyTable Is Nothing Then
            MyPage.Elements.Add(MyTable)
        End If

        MyDocument.Pages.Add(MyPage)
    End Sub

    Private Shared Sub CreateRowHeadings(ByVal MyTable As Table2)
        Dim MyRow As Row2 = MyTable.Rows.Add(40, Font.TimesBold, 12, Grayscale.Black, Grayscale.LightGrey)
        MyRow.CellDefault.Align = TextAlign.Center
        MyRow.CellDefault.VAlign = VAlign.Top
        MyRow.Cells.Add("FormField Name")
        MyRow.Cells.Add("FormField Type")
        MyRow.Cells.Add("FormField Value")
    End Sub

    Private Shared Sub CreateColumns(ByVal MyTable As Table2)
        MyTable.Columns.Add(150)
        MyTable.Columns.Add(150)
        MyTable.Columns.Add(150)
    End Sub
End Class

