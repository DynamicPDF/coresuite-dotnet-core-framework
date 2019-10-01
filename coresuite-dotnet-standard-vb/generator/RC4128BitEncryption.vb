Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.Cryptography
Imports ceTe.DynamicPDF.PageElements

Namespace coresuite_dotnet_standard_vb.generator

    Public Class RC4128BitEncryption

        Public Shared Sub Run(outputPdfPath As String)

            ' Create a document and set it's properties
            Dim document As Document = New Document With {
                .Creator = "HelloWorld.aspx",
                .Author = "ceTe Software",
                .Title = "Hello World RC4 128 Bit Encrypted"
            }

            ' Create a page to add to the document
            Dim page As Page = New Page(PageSize.Letter, PageOrientation.Portrait, 54.0F)

            ' Create a Label to add to the page
            Dim text As String = "Hello ASPX C# World...\nFrom DynamicPDF Generator for .NET\nDynamicPDF.com"
            Dim label As Label = New Label(text, 0, 0, 504, 100, Font.Helvetica, 18, TextAlign.Center)

            ' Add label to page
            page.Elements.Add(label)

            ' Add page to document
            document.Pages.Add(page)

            ' Create RC4 128 bit encryption security object that prevents text copying.
            Dim security As RC4128Security = New RC4128Security("owner", "user")
            security.AllowCopy = False

            ' Add the security object to the document
            document.Security = security

            ' Outputs the document to the current web page
            document.Draw(outputPdfPath)

        End Sub
    End Class
End Namespace