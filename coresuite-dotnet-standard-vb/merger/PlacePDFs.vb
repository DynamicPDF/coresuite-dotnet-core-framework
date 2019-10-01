Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.Merger
Imports ceTe.DynamicPDF.PageElements

Namespace coresuite_dotnet_standard_vb.merger

    Public Class PlacePDFs

        Public Shared Sub Run(outputPdfPath As String)

            ' Create a merge document And set it's properties
            Dim document As Document = New Document With {
                .Creator = "PlacePDFs",
                .Author = "ceTe Software",
                .Title = "Place PDFs"
            }

            ' Create page to place the imported PDF pages on
            Dim page As Page = New Page(1404, 1404, 0)

            ' Add rectangles to show dimensions of original pages
            page.Elements.Add(New Rectangle(0, 0, 612, 792))
            page.Elements.Add(New Rectangle(0, 792, 792, 612))
            page.Elements.Add(New Rectangle(612, 0, 792, 612))
            page.Elements.Add(New Rectangle(792, 612, 612, 792))

            ' Import And place 4 pages rotating 3 of them.
            page.Elements.Add(New ImportedPageArea(Util.GetResourcePath("PDFs/DocumentA.pdf"), 1, 0, 0))

            Dim importedPage2 As ImportedPageArea = New ImportedPageArea(Util.GetResourcePath("PDFs/DocumentA.pdf"), 2, 1404, 0)
            importedPage2.Angle = 90
            page.Elements.Add(importedPage2)

            Dim importedPage3 As ImportedPageArea = New ImportedPageArea(Util.GetResourcePath("PDFs/DocumentA.pdf"), 3, 1404, 1404)
            importedPage3.Angle = 180
            page.Elements.Add(importedPage3)

            Dim importedPage4 As ImportedPageArea = New ImportedPageArea(Util.GetResourcePath("PDFs/DocumentA.pdf"), 4, 0, 1404)
            importedPage4.Angle = -90
            page.Elements.Add(importedPage4)

            ' Add page to document
            document.Pages.Add(page)

            ' Outputs the merged document to the current web page
            document.Draw(outputPdfPath)
        End Sub
    End Class
End Namespace