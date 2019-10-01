Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.Cryptography
Imports ceTe.DynamicPDF.PageElements

Namespace coresuite_dotnet_standard_vb.generator

    Public Class Aes256BitEncryption

        Public Shared Sub Run(ByVal outputPdfPath As String)

            ' Create a PDF Document
            Dim MyDocument As Document = New Document With {
                .Creator = "Aes256BitEncryption",
                .Author = "ceTe Software",
                .Title = "AES 256 Bit Encrypted Document"
            }

            ' Create a page to add to the document
            Dim MyPage As Page = New Page(PageSize.Letter, PageOrientation.Portrait, 54.0F)

            ' Create a Label to add to the page
            Dim text As String = "Hello ASPX C# World...\nFrom DynamicPDF Generator for .NET\nDynamicPDF.com"
            Dim label As Label = New Label(text, 0, 0, 504, 100, Font.Helvetica, 18, TextAlign.Center)

            ' Add label to page
            MyPage.Elements.Add(label)

            ' Add page to document
            MyDocument.Pages.Add(MyPage)

            ' Create an instance of EmbeddedFile
            Dim embeddedFile As EmbeddedFile = New EmbeddedFile(Util.GetResourcePath("PDFs/DocumentA.pdf"))

            ' Add the embeddedFile to the EmbeddedFileList of the document public class
            MyDocument.EmbeddedFiles.Add(embeddedFile)

            ' Set the PageMode to the ShowAttachments
            MyDocument.InitialPageMode = PageMode.ShowAttachments

            ' Create AES 256 bit security object
            Dim security As Aes256Security = New Aes256Security("password")

            ' Set DocumentComponents property to OnlyFileAttachments
            security.DocumentComponents = EncryptDocumentComponents.OnlyFileAttachments

            ' Add the security object to the document
            MyDocument.Security = security

            ' Outputs the document to the current web page
            MyDocument.Draw(outputPdfPath)
        End Sub
    End Class
End Namespace