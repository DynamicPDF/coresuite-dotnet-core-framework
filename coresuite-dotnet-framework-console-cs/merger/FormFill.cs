using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Merger;
using ceTe.DynamicPDF.PageElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coresuite_dotnet_framework_console_cs.Merger
{
     public class FormFill
    {
        public static void Run(string outputPdfPath)
        {
            // Create a MergeOptions object to import the AcroForm
            MergeOptions options = new MergeOptions(false);

            // Create a document and set it's properties
            MergeDocument document = new MergeDocument(Util.GetResourcePath("PDFs/fw9_18.pdf"), options);

            document.Creator = "FormFill.aspx";
            document.Author = "ceTe Software";
            document.Title = "W-9 Form Filler";

            // Get the imorted page and set margins.
            ceTe.DynamicPDF.Page page = document.Pages[0];
            page.Dimensions.SetMargins(41, 35, 45, 37);

            // Uncomment the line below to show a layout grid.
            //page.Elements.Add( new LayoutGrid() );

            // Add page elements to the page
            page.Elements.Add(new Label("Alex B", 20, 60, 490, 12, Font.Courier, 9));
            page.Elements.Add(new Label("Smith", 20, 84, 490, 12, Font.Courier, 9));
            page.Elements.Add(new Label("3", 27, 125, 20, 12, Font.ZapfDingbats, 6));
            page.Elements.Add(new Label("123 Main Street", 20, 215, 300, 12, Font.Courier, 9));
            page.Elements.Add(new Label("Washington, DC  22222", 20, 240, 300, 12, Font.Courier, 9));
            page.Elements.Add(new Label("Enna Mark", 350, 215, 170, 36, Font.Courier, 9));
            page.Elements.Add(new Label("11998728719", 20, 265, 160, 12, Font.Courier, 9));


            string ssn = "521234567".Trim().Replace("-", "").Replace(" ", "");
            string ein = "52123".Trim().Replace("-", "").Replace(" ", "");
            if (ssn.Length >= 9)
            {
                page.Elements.Add(new Label(ssn.Substring(0, 1), 375, 307, 14, 12, Font.Courier, 9, TextAlign.Center));
                page.Elements.Add(new Label(ssn.Substring(1, 1), 391.4f, 307, 14, 12, Font.Courier, 9, TextAlign.Center));
                page.Elements.Add(new Label(ssn.Substring(2, 1), 405.8f, 307, 14, 12, Font.Courier, 9, TextAlign.Center));
                page.Elements.Add(new Label(ssn.Substring(3, 1), 433.2f, 307, 14, 12, Font.Courier, 9, TextAlign.Center));
                page.Elements.Add(new Label(ssn.Substring(4, 1), 447.6f, 307, 14, 12, Font.Courier, 9, TextAlign.Center));
                page.Elements.Add(new Label(ssn.Substring(5, 1), 475.4f, 307, 14, 12, Font.Courier, 9, TextAlign.Center));
                page.Elements.Add(new Label(ssn.Substring(6, 1), 490.8f, 307, 14, 12, Font.Courier, 9, TextAlign.Center));
                page.Elements.Add(new Label(ssn.Substring(7, 1), 505.2f, 307, 14, 12, Font.Courier, 9, TextAlign.Center));
                page.Elements.Add(new Label(ssn.Substring(8, 1), 520, 307, 14, 12, Font.Courier, 9, TextAlign.Center));
            }
            else if (ein.Length >= 9)
            {
                page.Elements.Add(new Label(ein.Substring(0, 1), 376, 355, 14, 12, Font.Courier, 9, TextAlign.Center));
                page.Elements.Add(new Label(ein.Substring(1, 1), 391.4f, 355, 14, 12, Font.Courier, 9, TextAlign.Center));
                page.Elements.Add(new Label(ein.Substring(2, 1), 418.8f, 355, 14, 12, Font.Courier, 9, TextAlign.Center));
                page.Elements.Add(new Label(ein.Substring(3, 1), 433.2f, 355, 14, 12, Font.Courier, 9, TextAlign.Center));
                page.Elements.Add(new Label(ein.Substring(4, 1), 447.6f, 355, 14, 12, Font.Courier, 9, TextAlign.Center));
                page.Elements.Add(new Label(ein.Substring(5, 1), 462, 355, 14, 12, Font.Courier, 9, TextAlign.Center));
                page.Elements.Add(new Label(ein.Substring(6, 1), 476.4f, 355, 14, 12, Font.Courier, 9, TextAlign.Center));
                page.Elements.Add(new Label(ein.Substring(7, 1), 490.8f, 355, 14, 12, Font.Courier, 9, TextAlign.Center));
                page.Elements.Add(new Label(ein.Substring(8, 1), 505.2f, 355, 14, 12, Font.Courier, 9, TextAlign.Center));
            }


            // Outputs the W-9 to the current web page
            document.Draw(outputPdfPath);

        }
    }
}
