using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace coresuite_dotnet_standard_cs.reportwriter
{
    public class ContactListReport
    {
        public static void Run(string outputPdfPath)
        {
            // Create the document's layout from a DLEX template
            DocumentLayout documentLayout = new DocumentLayout(Util.GetResourcePath("DLEX/ContactList.dlex"));

            NameValueLayoutData layoutData = new NameValueLayoutData();
            layoutData.Add("ContactGroups", ContactListExampleData.ContactGroups);

            // Layout the document using the parameters and set it's properties
            Document document = documentLayout.Layout(layoutData);
            document.Author = "DynamicPDF ReportWriter";
            document.Title = "Contact List Example";

            // Outputs the document to a file
            document.Draw(outputPdfPath);
        }
    }
}