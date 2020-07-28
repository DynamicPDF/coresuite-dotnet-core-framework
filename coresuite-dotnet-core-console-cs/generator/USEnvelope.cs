using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.PageElements.BarCoding;
using System;
using System.Collections.Generic;
using System.Text;

namespace coresuite_dotnet_core_console_cs.generator
{
   public class USEnvelope
    {
        public static void Run(string outputPdfPath)
        {
            // Create a document and set it's properties
            ceTe.DynamicPDF.Document document = new ceTe.DynamicPDF.Document();
            document.Creator = "USEnvelope.aspx";
            document.Author = "ceTe Software";
            document.Title = "US Envelope";

            // Create a page and add it to the document.
            ceTe.DynamicPDF.Page page = new ceTe.DynamicPDF.Page(PageSize.Envelope10, PageOrientation.Landscape, 18);
            document.Pages.Add(page);

            // Uncomment the line below to show a layout grid.
            //page.Elements.Add( new LayoutGrid() );

            // Add page elements to the page
            page.Elements.Add(new Image(Util.GetResourcePath("Images/DPDFLogo.png"), 0, 2, 0.16f));
            page.Elements.Add(new TextArea(GetFromAddress(), 50, 0, 350, 80, Font.Helvetica, 10));
            page.Elements.Add(new TextArea(GetToAddress(), 300, 140, 360, 100, Font.Helvetica, 12));


            // Check for an error
            try
            {
                document.Draw(outputPdfPath);
            }
            catch (InvalidValueBarCodeException)
            {
                // Show the Postnet value error
                ShowErrorDocument("Invalid To Zipcode. To zipcode must be a valid US zipcode.", "");
            }
            catch (Exception excGeneral)
            {
                // Show a general error
                ShowErrorDocument(excGeneral.Message, excGeneral.StackTrace);
            }           

        }

        private static void ShowErrorDocument(string message, string stackTrace)
        {
            // Shows the error in a PDF document          
            Document document = new Document();
            ceTe.DynamicPDF.Page page = new ceTe.DynamicPDF.Page(PageSize.Letter, PageOrientation.Portrait);

            TextArea messageArea = new TextArea(message, 0, 0, 512, 36, Font.Helvetica, 18, RgbColor.Red);
            messageArea.Height = messageArea.GetRequiredHeight();
            page.Elements.Add(messageArea);

            if (stackTrace.Trim().Length > 0)
            {
                float stackTraceTop = messageArea.Y + messageArea.Height + 20;
                TextArea stackTraceTA = new TextArea(stackTrace, 0, stackTraceTop, 512, 692 - stackTraceTop, Font.Helvetica, 10);
                page.Elements.Add(new ceTe.DynamicPDF.PageElements.Label("StackTrace:", 0, stackTraceTop - 12, 512, 12, Font.HelveticaBold, 10));
                page.Elements.Add(stackTraceTA);
            }
            document.Pages.Add(page);
            document.Draw();
        }

        private static string GetFromAddress()
        {
            // Returns a formatted From Address
            return GetAddress("Any Company", "13071 Wainwright Road", "Suite 100", "Columbia", "MD", "20777");
        }

        private static string GetToAddress()
        {
            // Returns a formatted To Address
            return GetAddress("ceTe Software", "123 Main Street", "", "AnyWhere", "MD", "20815-4704");
        }

        private static string GetAddress(string name, string address, string address2, string city, string state, string zip)
        {
            // Formats a US address
            string myAddress = name.Trim() + "\n";
            myAddress += address.Trim() + "\n";
            if (address2.Trim().Length > 0) myAddress += address2.Trim() + "\n";
            myAddress += city.Trim() + ", " + state.Trim() + "  " + zip.Trim();
            return myAddress;
        }

    }
}
