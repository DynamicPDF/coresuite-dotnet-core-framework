using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace coresuite_dotnet_core_console_cs.reportwriter
{
    public class SimpleReportWithCoverPage
    {
        public static void Run(string outputPdfPath)
        {
            DocumentLayout layoutReport = new DocumentLayout(Util.GetResourcePath("DLEX/SimpleReportWithCoverPage.dlex"));

            NameValueLayoutData layoutData = new NameValueLayoutData();
            layoutData.Add("ReportCreatedFor", "Alex Smith");
            layoutData.Add("Products", SimpleReportWithCoverPageExampleData.Products);

            // Layout the document and set it's properties
            Document document = layoutReport.Layout(layoutData);
            document.Author = "DynamicPDF ReportWriter";
            document.Title = "Simple Report Example";

            // Outputs the document to a file
            document.Draw(outputPdfPath);
        }
    }
}