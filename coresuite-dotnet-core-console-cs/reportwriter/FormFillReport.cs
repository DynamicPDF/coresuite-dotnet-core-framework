using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace coresuite_dotnet_core_console_cs.reportwriter
{
    public class FormFillReport
    {
        public static void Run(string outputPdfPath)
        {
            // Create the document's layout from a DLEX template
            DocumentLayout layoutReport = new DocumentLayout(Util.GetResourcePath("DLEX/FormFill.dlex"));

            // Specify the data.
            NameValueLayoutData layoutData = new NameValueLayoutData();
            W4Data w4Data = new W4Data
            {
                FirstNameAndI = "Alex B.",
                LastName = "Smith",
                SSN = "123-45-6789",
                HomeAddress = "456 Green Road",
                IsSingle = true,
                CityStateZip = "Somewhere, Earth  12345",
                Allowances = 2
            };

            layoutData.Add("W4Data", w4Data);

            // Layout the document and save the PDF
            Document document = layoutReport.Layout(layoutData);
            document.Author = "DynamicPDF ReportWriter";
            document.Title = "Form Fill Example";

            document.Draw(outputPdfPath);
        }
    }
}