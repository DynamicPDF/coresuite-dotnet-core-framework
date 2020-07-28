Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.Merger
Imports ceTe.DynamicPDF.PageElements

Public Class SelectPages
    Friend Shared Sub Run(selected() As String, fileName As String)
        ' Create a document And set it's properties
        Dim MyDocument As Document = New Document With {
                .Creator = "SelectPages",
                .Author = "ceTe Software",
                .Title = "SelectPages"
            }

        ' Add a title page to the document
        AddTitlePage(MyDocument)

        ' Add selected import pages to the document
        AddSelectedPages(MyDocument, selected.ToList())

        ' Outputs the document to the current web page
        MyDocument.Draw(fileName)
    End Sub

    Private Shared Sub AddTitlePage(document As Document)
        ' Creates title page
        Dim Page As Page = New Page(PageSize.Letter, PageOrientation.Portrait, 50)
        ' Creates And centeres image on title page
        Dim image As Image = New Image(Util.GetResourcePath("Images/DPDFLogo.png"), Page.Dimensions.Body.Width / 2, Page.Dimensions.Body.Height / 2, 0.48F)
        image.Align = Align.Center
        image.VAlign = VAlign.Center
        ' Adds text And image to title page
        Page.Elements.Add(New TextArea("Title Page", 0, 0, Page.Dimensions.Body.Width, 72, Font.Helvetica, 72, TextAlign.Center))
        Page.Elements.Add(image)
        ' Adds title page to document
        document.Pages.Add(Page)
    End Sub


    Private Shared Sub AddSelectedPages(document As Document, selected As List(Of String))
        Try
            AddSelectedPagesFromDocument(document, selected.FindAll(Function(s As String) s.StartsWith("A")), Util.GetResourcePath("PDFs/DocumentA.pdf"))
            AddSelectedPagesFromDocument(document, selected.FindAll(Function(s As String) s.StartsWith("B")), Util.GetResourcePath("PDFs/DocumentB.pdf"))
            AddSelectedPagesFromDocument(document, selected.FindAll(Function(s As String) s.StartsWith("C")), Util.GetResourcePath("PDFs/DocumentC.pdf"))
            AddSelectedPagesFromDocument(document, selected.FindAll(Function(s As String) s.StartsWith("D")), Util.GetResourcePath("PDFs/DocumentD.pdf"))
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

    End Sub


    Private Shared Sub AddSelectedPagesFromDocument(document As Document, list As List(Of String), importDocument As String)
        Dim pdfDocument As PdfDocument = New PdfDocument(importDocument)
        For Each item As String In list
            document.Pages.Add(New ImportedPage(pdfDocument.GetPage(Integer.Parse(item.Remove(0, 1)))))
        Next
    End Sub

End Class
