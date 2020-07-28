using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements.Html;
using System;

namespace coresuite_dotnet_core_console_cs.generator
{
    public class HtmlAreaPDF
    {
        public static void Run_WithHtmlTags(string outputPdfPath)
        {
            // Create a document and set it's properties
            Document document = new Document
            {
                Creator = "HtmlAreaTags",
                Author = "ceTe Software",
                Title = "HtmlArea Tags"
            };

            //Create a header footer template
            HeaderFooterTemplate header = new HeaderFooterTemplate("HeaderText", "FooterText");

            //Create a uri and get the input Html file.
            Uri uri = new Uri(Util.GetResourcePath("Html/HtmlTags.html"));

            // Create a HtmlArea and set it's Dimensions
            HtmlArea htmlArea = new HtmlArea(uri, 0, 0, 500, 680);
            Page page;
            do
            {
                // Create a page to add to the document
                page = new Page();

                // Add htmlArea to page
                page.Elements.Add(htmlArea);

                // Add page to document
                document.Pages.Add(page);

                // Set the html area object equal to the rest of the html area that did not fit
                // if all the html area did fit, GetOverflowHtmlArea will return null
                htmlArea = htmlArea.GetOverflowHtmlArea(0, 0, 680);

            } while (htmlArea != null);

            // Add the template to the document
            document.Template = header;

            // Outputs the document to the current web page
            document.Draw(outputPdfPath);
        }

        public static void Run_WithHtmlTagsAndStyles(string outputPdfPath)
        {
            // Create a document and set it's properties
            Document document = new Document
            {
                Creator = "HtmlAreaTagsAndStyles",
                Author = "ceTe Software",
                Title = "HtmlArea Tags And Styles"
            };

            //Create a uri and get the input Html file.
            Uri uri = new Uri(Util.GetResourcePath("Html/HtmlAreaTagsAndStyles.html"));

            // Create a HtmlArea and set it's Dimensions
            HtmlArea htmlArea = new HtmlArea(uri, 0, 0, 500, 680);
            Page page;
            int x = 1;
            do
            {
                // Create a page to add to the document
                page = new Page();
                if (x == 3)
                {
                    // set the page dimensions for 3rd page
                    page.Dimensions.Width = 400;
                    page.Dimensions.Height = 550;
                }

                // Add htmlArea to page
                page.Elements.Add(htmlArea);

                // Set the html area object equal to the rest of the html area that did not fit
                // if all the html area did fit, GetOverflowHtmlArea will return null
                htmlArea = htmlArea.GetOverflowHtmlArea(0, 0, 680);

                // Add page to document
                document.Pages.Add(page);
                x++;

            } while (htmlArea != null);

            // Outputs the document to the current web page
            document.Draw(outputPdfPath);
        }
    }
}