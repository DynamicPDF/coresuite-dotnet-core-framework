using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace coresuite_dotnet_framework_console_cs.ReportWriter
{
    public class SimpleSubReport
    {
        public static void Run(string outputPdfPath)
        {
            // Create the document's layout from a DLEX template
            DocumentLayout layoutReport = new DocumentLayout(Util.GetResourcePath("DLEX/SimpleSubReport.dlex"));

            NameValueLayoutData layoutData = new NameValueLayoutData();
            layoutData.Add("ProductsByCategory", SimpleSubReportExampleData.ProductsByCategory);

            // Layout the document and set it's properties
            Document document = layoutReport.Layout(layoutData);
            document.Author = "DynamicPDF ReportWriter";
            document.Title = "Simple SubReport Example";

            // Outputs the document to a file
            document.Draw(outputPdfPath);
        }
    }
}