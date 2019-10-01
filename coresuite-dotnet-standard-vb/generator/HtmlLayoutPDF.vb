Imports ceTe.DynamicPDF
Imports System

Namespace coresuite_dotnet_standard_vb.generator

    Public Class HtmlLayoutPDF

        Public Shared Sub Run(outputPdfPath As String)
            ' Outputs the document to the current web page
            Dim htmlSource As Uri = New Uri(Util.GetResourcePath("Html/Products.html"))
            Dim htmlLayout As HtmlLayout = New HtmlLayout(htmlSource, New PageInfo(PageSize.Letter, PageOrientation.Portrait))
            htmlLayout.Header.Center.Text = "DynamicPDF CoreSuite HTML Layout Example"
            htmlLayout.Header.Center.ShowOnFirstPage = False
            htmlLayout.Footer.Center.Text = "Page %%CP%% of %%TP%%"
            htmlLayout.Footer.Center.HasPageNumbers = True

            ' Layout the document and set it's properties
            Dim document As Document = htmlLayout.Layout()
            document.Creator = "HtmlLayoutExample.aspx"
            document.Author = "ceTe Software"
            document.Title = "HTML Layout Example"

            ' Outputs the document to the current web page
            document.Draw(outputPdfPath)
        End Sub
    End Class
End Namespace