using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;

namespace coresuite_dotnet_core_console_cs.generator
{
    public class TaggedPdf
    {
        public static void Run(string outputPdfPath)
        {
            // Create a document and set it's properties
            Document document = new Document
            {
                Creator = "HelloWorldTaggedPdf.aspx",
                Author = "ceTe Software",
                Title = "Hello World",

                // Specify document as tagged PDF
                Tag = new TagOptions()
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

            // Outputs the document to the current web page
            document.Draw(outputPdfPath);
        }
    }
}
