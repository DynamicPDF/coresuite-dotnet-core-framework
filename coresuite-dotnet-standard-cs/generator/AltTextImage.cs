using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;

namespace coresuite_dotnet_standard_cs.generator
{
    public class AltTextImage
    {
        public static void Run(string outputPdfPath)
        {
            // Create a PDF Document
            Document document = new Document();

            // Create a page and add it to the document
            Page page = new Page();
            document.Pages.Add(page);

            // Create a label and add it to the page
            page.Elements.Add(new Label("Mouse over the image to see alternate text", 100, 220, 300, 100, Font.Helvetica, 15f));

            // Create an image
            Image image = new Image(Util.GetResourcePath("Images/DPDFLogo.png"), 250f, 350f, 0.24f);

            // Set alternate text to the image
            image.AlternateText = "DynamicPDF Logo";

            // Image is sized and centered in the rectangle
            image.SetBounds(200, 200);
            image.VAlign = VAlign.Center;
            image.Align = Align.Center;

            // Add image to the page
            page.Elements.Add(image);

            // Outputs the document to the current web page
            document.Draw(outputPdfPath);
        }
    }
}
