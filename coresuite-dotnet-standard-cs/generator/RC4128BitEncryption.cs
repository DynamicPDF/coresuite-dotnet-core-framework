using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Cryptography;
using ceTe.DynamicPDF.PageElements;

namespace coresuite_dotnet_standard_cs.generator
{
    public class RC4128BitEncryption
    {
        public static void Run(string outputPdfPath)
        {
            // Create a document and set it's properties
            Document document = new Document
            {
                Creator = "HelloWorld.aspx",
                Author = "ceTe Software",
                Title = "Hello World RC4 128 Bit Encrypted"
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

            // Create RC4 128 bit encryption security object that prevents text copying.
            RC4128Security security = new RC4128Security("owner", "user");
            security.AllowCopy = false;

            // Add the security object to the document
            document.Security = security;

            // Outputs the document to the current web page
            document.Draw(outputPdfPath);
        }
    }
}