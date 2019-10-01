using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.PageElements.BarCoding;
using coresuite_asp_dotnet_core_mvc_cs.Models;
using System;

namespace coresuite_asp_dotnet_core_mvc_cs.CodeFiles
{
    public class USEnvelope
    {
        public static byte[] Run(EnvelopeModel envelope, Microsoft.AspNetCore.Hosting.IHostingEnvironment currentEnvironment)
        {
            // Create a document and set it's properties
            Document document = new Document
            {
                Creator = "USEnvelope.aspx",
                Author = "ceTe Software",
                Title = "US Envelope"
            };

            // Create a page and add it to the document.
            Page page = new Page(PageSize.Envelope10, PageOrientation.Landscape, 18);
            document.Pages.Add(page);

            // Uncomment the line below to show a layout grid.
            //page.Elements.Add( new LayoutGrid() );

            // Add page elements to the page
            page.Elements.Add(new Image(System.IO.Path.Combine(currentEnvironment.WebRootPath, "Images/DPDFLogo.png"), 0, 2, 0.16f));
            page.Elements.Add(new TextArea(GetAddress(envelope.FromAddress), 50, 0, 350, 80, Font.Helvetica, 10));
            page.Elements.Add(new TextArea(GetAddress(envelope.ToAddress), 300, 140, 360, 100, Font.Helvetica, 12));
            page.Elements.Add(new Postnet(envelope.ToAddress.Zip, 300, 248));

            // Check for an error
            try
            {
                return document.Draw();
            }
            catch (InvalidValueBarCodeException)
            {
                // Show the Postnet value error
                return Util.GetErrorDocument("Invalid To Zipcode. To zipcode must be a valid US zipcode.", "");
            }
            catch (Exception excGeneral)
            {
                // Show a general error
                return Util.GetErrorDocument(excGeneral.Message, excGeneral.StackTrace);
            }
        }

        private static string GetAddress(Address address)
        {
            // Formats a US address
            string myAddress = address.Name + "\n";
            myAddress += address.Address1.Trim() + "\n";
            if (address.Address2.Trim().Length > 0) myAddress += address.Address2.Trim() + "\n";
            myAddress += address.City.Trim() + ", " + address.State.Trim() + "  " + address.Zip.Trim();
            return myAddress;
        }
    }
}