using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Merger;
using ceTe.DynamicPDF.PageElements;

namespace coresuite_dotnet_core_console_cs.merger
{
    public class PlacePDFs
    {
        public static void Run(string outputPdfPath)
        {
            // Create a merge document and set it's properties
            Document document = new Document
            {
                Creator = "PlacePDFs",
                Author = "ceTe Software",
                Title = "Place PDFs"
            };

            // Create page to place the imported PDF pages on
            Page page = new Page(1404, 1404, 0);

            // Add rectangles to show dimensions of original pages
            page.Elements.Add(new Rectangle(0, 0, 612, 792));
            page.Elements.Add(new Rectangle(0, 792, 792, 612));
            page.Elements.Add(new Rectangle(612, 0, 792, 612));
            page.Elements.Add(new Rectangle(792, 612, 612, 792));

            // Import and place 4 pages rotating 3 of them.
            page.Elements.Add(new ImportedPageArea(Util.GetResourcePath("PDFs/DocumentA.pdf"), 1, 0, 0));

            ImportedPageArea importedPage2 = new ImportedPageArea(Util.GetResourcePath("PDFs/DocumentA.pdf"), 2, 1404, 0);
            importedPage2.Angle = 90;
            page.Elements.Add(importedPage2);

            ImportedPageArea importedPage3 = new ImportedPageArea(Util.GetResourcePath("PDFs/DocumentA.pdf"), 3, 1404, 1404);
            importedPage3.Angle = 180;
            page.Elements.Add(importedPage3);

            ImportedPageArea importedPage4 = new ImportedPageArea(Util.GetResourcePath("PDFs/DocumentA.pdf"), 4, 0, 1404);
            importedPage4.Angle = -90;
            page.Elements.Add(importedPage4);

            // Add page to document
            document.Pages.Add(page);

            // Outputs the merged document to the current web page
            document.Draw(outputPdfPath);
        }
    }
}