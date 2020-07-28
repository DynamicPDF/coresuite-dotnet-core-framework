using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;

namespace coresuite_dotnet_core_console_cs.generator
{
    public class HelloWorld
    {
        public static void Run(string outputPdfPath)
        {
            Document document = new Document
            {
                Creator = "HelloWorld",
                Author = "ceTe Software",
                Title = "Hello World"
            };

            // Create a page to add to the document
            Page page = new Page(PageSize.Letter, PageOrientation.Portrait, 54.0f);

            // Uncomment the line below to add a layout grid to the page
            //page.Elements.Add( new LayoutGrid() );

            // Create a Label to add to the page
            string strLabel = "Hello C# World...\nFrom DynamicPDF Generator for .NET\nDynamicPDF.com";
            Label label = new Label(strLabel, 0, 0, 504, 100, Font.Helvetica, 18, TextAlign.Center);

            // Add label to page
            page.Elements.Add(label);

            // Add page to document
            document.Pages.Add(page);

            // Outputs the document to the current web page
            document.Draw(outputPdfPath);
        }
    }
}