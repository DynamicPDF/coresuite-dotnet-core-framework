Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.Merger
Imports ceTe.DynamicPDF.PageElements

Namespace coresuite_asp_dotnet_framework_mvc_vb.CodeFiles

    Friend Class SelectPages
        Friend Shared Function Run(ByVal selected As List(Of String)) As Byte()
            ' Create a document and set it's properties
            Dim Document As Document = New Document With {
                .Creator = "SelectPages",
                .Author = "ceTe Software",
                .Title = "Select Pages"
            }

            'Add a title page to the document
            AddTitlePage(Document)

            ' Add selected import pages to the document
            AddSelectedPages(Document, selected)

            ' Outputs the document to the current web page
            Return Document.Draw()
        End Function

        Private Shared Sub AddTitlePage(ByVal MyDocument As Document)
            ' Creates title MyPage
            Dim page As Page = New Page(PageSize.Letter, PageOrientation.Portrait, 50)

            ' Creates and centeres image on title MyPage
            Dim image As Image = New Image(HttpContext.Current.Server.MapPath("../Images/DPDFLogo.png"), page.Dimensions.Body.Width / 2, page.Dimensions.Body.Height / 2, 0.48) With {
                .Align = Align.Center,
                .VAlign = VAlign.Center
            }

            ' Adds text and image to title MyPage
            page.Elements.Add(New TextArea("Title Page", 0, 0, page.Dimensions.Body.Width, 72, Font.Helvetica, 72, TextAlign.Center))
            page.Elements.Add(image)

            ' Adds title MyPage to document
            MyDocument.Pages.Add(page)
        End Sub

        Private Shared Sub AddSelectedPages(ByVal document As Document, ByVal selected As List(Of String))
            AddSelectedPagesFromDocument(document, selected.FindAll(Function(s) s.StartsWith("A")), System.Web.HttpContext.Current.Server.MapPath("~/PDFs/DocumentA.pdf"))
            AddSelectedPagesFromDocument(document, selected.FindAll(Function(s) s.StartsWith("B")), System.Web.HttpContext.Current.Server.MapPath("~/PDFs/DocumentB.pdf"))
            AddSelectedPagesFromDocument(document, selected.FindAll(Function(s) s.StartsWith("C")), System.Web.HttpContext.Current.Server.MapPath("~/PDFs/DocumentC.pdf"))
            AddSelectedPagesFromDocument(document, selected.FindAll(Function(s) s.StartsWith("D")), System.Web.HttpContext.Current.Server.MapPath("~/PDFs/DocumentD.pdf"))
            AddSelectedPagesFromDocument(document, selected.FindAll(Function(s) s.StartsWith("D")), System.Web.HttpContext.Current.Server.MapPath("~/PDFs/DocumentD.pdf"))
        End Sub

        Private Shared Sub AddSelectedPagesFromDocument(ByVal document As Document, ByVal list As List(Of String), ByVal importDocument As String)
            Dim pdfDocument As PdfDocument = New PdfDocument(importDocument)
            Dim item As String
            For Each item In list
                document.Pages.Add(New ImportedPage(pdfDocument.GetPage(Integer.Parse(item.Remove(0, 1)))))
            Next
        End Sub
    End Class
End Namespace