using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace coresuite_dotnet_core_console_cs.reportwriter
{
    public class ContactListWithGroupByReport
    {
        public static void Run(string outputPdfPath)
        {
            // Create the document's layout from a DLEX template
            DocumentLayout documentLayout = new DocumentLayout(Util.GetResourcePath("DLEX/ContactListWithGroupBy.dlex"));

            NameValueLayoutData layoutData = new NameValueLayoutData();
            layoutData.Add("Contacts", ContactListWithGroupByExampleData.Contacts);

            // Layout the document using the parameters and set it's properties
            Document document = documentLayout.Layout(layoutData);
            document.Author = "DynamicPDF ReportWriter";
            document.Title = "Contact List With Group By Example";

            // Outputs the document to a file
            document.Draw(outputPdfPath);
        }
    }
}