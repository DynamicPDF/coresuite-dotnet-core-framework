Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements.Html

Public Class HtmlAreaPDF
    Public Shared Sub Run_WithHtmlTags(ByVal outputPdfPath As String)
        'Create a document and set it's properties
        Dim document As New Document With {
            .Creator = "HtmlAreaTags",
            .Author = "ceTe Software",
            .Title = "HtmlArea Tags"
        }

        'Create a header footer template
        Dim header As HeaderFooterTemplate = New HeaderFooterTemplate("HeaderText", "FooterText")

        'Create a uri and get the input Html file.
        Dim uri As Uri = New Uri(Util.GetResourcePath("Html/HtmlTags.html"))

        'Create a HtmlArea and set it's Dimensions
        Dim htmlArea As HtmlArea = New HtmlArea(uri, 0.0, 0.0, 500.0, 680.0)
        Do
            'Create a page to add to the document
            Dim page As Page = New Page()

            'Add htmlArea to page
            page.Elements.Add(htmlArea)

            'Add page to document
            document.Pages.Add(page)

            ' Set the html area object equal to the rest of the html area that did not fit
            ' if all the html area did fit, GetOverflowHtmlArea will return null
            htmlArea = htmlArea.GetOverflowHtmlArea(0.0, 0.0, 680.0)
        Loop While Not htmlArea Is Nothing

        'Add the template to the document
        document.Template = header

        ' Outputs the document to the current web page
        document.Draw(outputPdfPath)
    End Sub


    Public Shared Sub Run_WithHtmlTagsAndStyles(ByVal outputPdfPath As String)
        'Create a document and set it's properties
        Dim document As New Document With {
            .Creator = "HtmlAreaTagsAndStyles.aspx",
            .Author = "ceTe Software",
            .Title = "HtmlArea Tags And Styles"
        }

        'Create a uri and get the input Html file.
        Dim uri As Uri = New Uri(Util.GetResourcePath("Html/HtmlAreaTagsAndStyles.html"))

        'Create a HtmlArea and set it's Dimensions
        Dim htmlArea As HtmlArea = New HtmlArea(uri, 0.0, 0.0, 500.0, 680.0)
        Do
            'Create a page to add to the document
            Dim page As Page = New Page()
            Dim x As Integer = 1
            If x = 3 Then
                ' set the page dimensions for 3rd page
                page.Dimensions.Width = 400
                page.Dimensions.Height = 550
            End If
            'Add htmlArea to page
            page.Elements.Add(htmlArea)

            ' Set the html area object equal to the rest of the html area that did not fit
            ' if all the html area did fit, GetOverflowHtmlArea will return null
            htmlArea = htmlArea.GetOverflowHtmlArea(0.0, 0.0, 680.0)

            'Add page to document
            document.Pages.Add(page)
            x = x + 1
        Loop While Not htmlArea Is Nothing

        'Outputs the document to the current web page
        document.Draw(outputPdfPath)

    End Sub
End Class

