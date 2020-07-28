using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Cryptography;
using ceTe.DynamicPDF.PageElements;

namespace coresuite_dotnet_framework_console_cs.Generator
{
    public class Aes256BitEncryption
    {
        public static void Run(string outputPdfPath)
        {
            // Create a PDF Document
            Document document = new Document
            {
                Creator = "Aes256BitEncryption",
                Author = "ceTe Software",
                Title = "AES 256 Bit Encrypted Document"
            };

            // Create a page to add to the document
            Page page = new Page(PageSize.Letter, PageOrientation.Portrait, 54.0f);

            // Create a Label to add to the page
            string text = "Hello ASPX C# World...\nFrom DynamicPDF Generator for .NET\nDynamicPDF.com";
            Label label = new Label(text, 0, 0, 504, 100, Font.Helvetica, 18, TextAlign.Center);

            // Add label to page
            page.Elements.Add(label);

            // Add page to document
            document.Pages.Add(page);

            // Create an instance of EmbeddedFile
            EmbeddedFile embeddedFile = new EmbeddedFile(Util.GetResourcePath("PDFs/DocumentA.pdf"));

            // Add the embeddedFile to the EmbeddedFileList of the document public class
            document.EmbeddedFiles.Add(embeddedFile);

            // Set the PageMode to the ShowAttachments
            document.InitialPageMode = PageMode.ShowAttachments;

            // Create AES 256 bit security object
            Aes256Security security = new Aes256Security("password")
            {
                // Set DocumentComponents property to OnlyFileAttachments
                DocumentComponents = EncryptDocumentComponents.OnlyFileAttachments
            };

            // Add the security object to the document
            document.Security = security;

            // Outputs the document to the current web page
            document.Draw(outputPdfPath);
        }
    }
}