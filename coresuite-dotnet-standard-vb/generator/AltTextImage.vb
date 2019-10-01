Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements

Namespace coresuite_dotnet_standard_vb.generator

    Public Class AltTextImage

        Public Shared Sub Run(outputPdfPath As String)
            ' Create a PDF Document
            Dim document As Document = New Document()

            ' Create a page And add it to the document
            Dim page As Page = New Page()
            document.Pages.Add(page)

            ' Create a label And add it to the page
            page.Elements.Add(New Label("Mouse over the image to see alternate text", 100, 220, 300, 100, Font.Helvetica, 15.0F))

            ' Create an image
            ' Set alternate text to the image
            Dim image As Image = New Image(Util.GetResourcePath("Images/DPDFLogo.png"), 250.0F, 350.0F, 0.24F) With {
                .AlternateText = "DynamicPDF Logo"
            }

            ' Image Is sized And centered in the rectangle
            image.SetBounds(200, 200)
            image.VAlign = VAlign.Center
            image.Align = Align.Center

            ' Add image to the page
            page.Elements.Add(image)

            ' Outputs the document to the current web page
            document.Draw(outputPdfPath)
        End Sub
    End Class
End Namespace