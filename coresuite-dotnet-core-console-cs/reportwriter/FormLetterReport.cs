using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace coresuite_dotnet_core_console_cs.reportwriter
{
    public class FormLetterReport
    {
        public static void Run(string outputPdfPath)
        {
            // Create the document's layout from a DLEX template
            DocumentLayout layoutReport = new DocumentLayout(Util.GetResourcePath("DLEX/FormLetter.dlex"));

            // Specify the data.
            NameValueLayoutData layoutData = new NameValueLayoutData();
            layoutData.Add("Name", "Alex Smith");
            layoutData.Add("Address", "456 Green Road\nSomewhere, Earth");
            layoutData.Add("Amount", "$321.00");

            // Layout the document and save the PDF
            Document document = layoutReport.Layout(layoutData);
            document.Author = "DynamicPDF ReportWriter";
            document.Title = "Form Letter Example";

            document.Draw(outputPdfPath);
        }
    }
}