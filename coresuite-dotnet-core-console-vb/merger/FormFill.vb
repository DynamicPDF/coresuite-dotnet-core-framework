Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.Merger
Imports ceTe.DynamicPDF.PageElements

Public Class FormFill
    Public Shared Sub Run(outputPdfPath As String)

        ' Create a MergeOptions object to import the AcroForm
        Dim MyOptions As MergeOptions = New MergeOptions(False)

        ' Create a document and set it's properties
        Dim MyDocument As MergeDocument = New MergeDocument(Util.GetResourcePath("PDFs/fw9_18.pdf"), MyOptions)
        MyDocument.Creator = "FormFill.aspx"
        MyDocument.Author = "ceTe Software"
        MyDocument.Title = "W-9 Form Filler"

        ' Get the imorted MyPage and set margins.
        Dim MyPage As ceTe.DynamicPDF.Page = MyDocument.Pages(0)
        MyPage.Dimensions.SetMargins(41, 35, 45, 37)

        ' Uncomment the line below to show a layout grid.
        'MyPage.Elements.Add( new LayoutGrid() )

        ' Add page elements to the Page
        MyPage.Elements.Add(New Label("Alex B", 20, 60, 490, 12, Font.Courier, 9))
        MyPage.Elements.Add(New Label("Smith", 20, 84, 490, 12, Font.Courier, 9))
        MyPage.Elements.Add(New Label("3", 27, 125, 20, 12, Font.ZapfDingbats, 6))
        MyPage.Elements.Add(New Label("123 Main Street", 20, 215, 300, 12, Font.Courier, 9))
        MyPage.Elements.Add(New Label("Washington, DC  22222", 20, 240, 300, 12, Font.Courier, 9))
        MyPage.Elements.Add(New Label("Enna Mark", 350, 215, 170, 36, Font.Courier, 9))
        MyPage.Elements.Add(New Label("11998728719", 20, 265, 160, 12, Font.Courier, 9))
        Dim Ssn As String = "521234567".Trim().Replace("-", "").Replace(" ", "")
        Dim Ein As String = "52123".Trim().Replace("-", "").Replace(" ", "")
        If Ssn.Length >= 9 Then
            MyPage.Elements.Add(New Label(Ssn.Substring(0, 1), 375, 307, 14, 12, Font.Courier, 9, TextAlign.Center))
            MyPage.Elements.Add(New Label(Ssn.Substring(1, 1), 391.4F, 307, 14, 12, Font.Courier, 9, TextAlign.Center))
            MyPage.Elements.Add(New Label(Ssn.Substring(2, 1), 405.8F, 307, 14, 12, Font.Courier, 9, TextAlign.Center))
            MyPage.Elements.Add(New Label(Ssn.Substring(3, 1), 433.2F, 307, 14, 12, Font.Courier, 9, TextAlign.Center))
            MyPage.Elements.Add(New Label(Ssn.Substring(4, 1), 447.6F, 307, 14, 12, Font.Courier, 9, TextAlign.Center))
            MyPage.Elements.Add(New Label(Ssn.Substring(5, 1), 475.4F, 307, 14, 12, Font.Courier, 9, TextAlign.Center))
            MyPage.Elements.Add(New Label(Ssn.Substring(6, 1), 490.8F, 307, 14, 12, Font.Courier, 9, TextAlign.Center))
            MyPage.Elements.Add(New Label(Ssn.Substring(7, 1), 505.2F, 307, 14, 12, Font.Courier, 9, TextAlign.Center))
            MyPage.Elements.Add(New Label(Ssn.Substring(8, 1), 520, 307, 14, 12, Font.Courier, 9, TextAlign.Center))
        ElseIf Ein.Length >= 9 Then
            MyPage.Elements.Add(New Label(Ein.Substring(0, 1), 376, 355, 14, 12, Font.Courier, 9, TextAlign.Center))
            MyPage.Elements.Add(New Label(Ein.Substring(1, 1), 391.4F, 355, 14, 12, Font.Courier, 9, TextAlign.Center))
            MyPage.Elements.Add(New Label(Ein.Substring(2, 1), 418.8F, 355, 14, 12, Font.Courier, 9, TextAlign.Center))
            MyPage.Elements.Add(New Label(Ein.Substring(3, 1), 433.2F, 355, 14, 12, Font.Courier, 9, TextAlign.Center))
            MyPage.Elements.Add(New Label(Ein.Substring(4, 1), 447.6F, 355, 14, 12, Font.Courier, 9, TextAlign.Center))
            MyPage.Elements.Add(New Label(Ein.Substring(5, 1), 462, 355, 14, 12, Font.Courier, 9, TextAlign.Center))
            MyPage.Elements.Add(New Label(Ein.Substring(6, 1), 476.4F, 355, 14, 12, Font.Courier, 9, TextAlign.Center))
            MyPage.Elements.Add(New Label(Ein.Substring(7, 1), 490.8F, 355, 14, 12, Font.Courier, 9, TextAlign.Center))
            MyPage.Elements.Add(New Label(Ein.Substring(8, 1), 505.2F, 355, 14, 12, Font.Courier, 9, TextAlign.Center))
        End If

        ' Outputs the W-9 to the current web page
        MyDocument.Draw(outputPdfPath)


    End Sub
End Class
