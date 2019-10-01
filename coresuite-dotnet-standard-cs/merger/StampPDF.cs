using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Merger;
using ceTe.DynamicPDF.PageElements;

namespace coresuite_dotnet_standard_cs.merger
{
    public class StampPDF
    {
        public static void Run(string outputPdfPath)
        {
            // Create an output document and set it's properties
            MergeDocument document = new MergeDocument(Util.GetResourcePath("PDFs/fw9_18.pdf"));
            document.Creator = "StampPDF";
            document.Author = "ceTe Software";
            document.Title = "Stamp PDF";

            // Create a template to place an image behind each page in the PDF
            Template backgroundTemplate = new Template();
            document.Template = backgroundTemplate;
            backgroundTemplate.Elements.Add(new BackgroundImage(Util.GetResourcePath("Images/DPDFLogo_Watermark.png")));

            // Create a label for the stamp and rotate it 20 degrees
            Label label = new Label("Stamped with Merger for .NET.", 0, 250, 500, 100, Font.Helvetica, 24, TextAlign.Center, RgbColor.Red);
            label.Angle = -20;

            // Create an anchor group to keep the label anchored regardless of page size
            AnchorGroup anchorGroup = new AnchorGroup(500, 100, Align.Center, VAlign.Top);
            anchorGroup.Add(label);

            // Create a stamp template and add the anchor group containing the label to it
            Template stampTemplate = new Template();
            document.StampTemplate = stampTemplate;
            stampTemplate.Elements.Add(anchorGroup);

            // Outputs the stamped document to the current web page
            document.Draw(outputPdfPath);
        }
    }
}