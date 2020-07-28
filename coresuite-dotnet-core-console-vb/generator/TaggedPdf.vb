Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements

Public Class TaggedPdf

    Public Shared Sub Run(outputPdfPath As String)
        ' Create a document And set it's properties
        ' Specify document as tagged PDF
        Dim MyDocument As Document = New Document With {
            .Creator = "HelloWorldTaggedPdf.aspx",
            .Author = "ceTe Software",
            .Title = "Hello World",
            .Tag = New TagOptions()
        }

        ' Create a page to add to the document
        Dim page As Page = New Page(PageSize.Letter, PageOrientation.Portrait, 54.0F)

        ' Create a Label to add to the page
        Dim text As String = "Hello ASPX C# World...\nFrom DynamicPDF Generator for .NET\nDynamicPDF.com"
        Dim label As Label = New Label(text, 0, 0, 504, 100, Font.Helvetica, 18, TextAlign.Center)

        ' Add label to page
        page.Elements.Add(label)

        ' Add page to document
        MyDocument.Pages.Add(page)

        ' Outputs the document to the current web page
        MyDocument.Draw(outputPdfPath)
    End Sub
End Class

