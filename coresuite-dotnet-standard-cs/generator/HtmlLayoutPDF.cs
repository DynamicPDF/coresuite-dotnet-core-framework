using ceTe.DynamicPDF;
using System;

namespace coresuite_dotnet_standard_cs.generator
{
    public class HtmlLayoutPDF
    {
        public static void Run(string outputPdfPath)
        {
            // Outputs the document to the current web page
            Uri htmlSource = new Uri(Util.GetResourcePath("Html/Products.html"));
            HtmlLayout htmlLayout = new HtmlLayout(htmlSource, new PageInfo(PageSize.Letter, PageOrientation.Portrait));
            htmlLayout.Header.Center.Text = "DynamicPDF CoreSuite HTML Layout Example";
            htmlLayout.Header.Center.ShowOnFirstPage = false;
            htmlLayout.Footer.Center.Text = "Page %%CP%% of %%TP%%";
            htmlLayout.Footer.Center.HasPageNumbers = true;

            // Layout the document and set it's properties
            Document document = htmlLayout.Layout();
            document.Creator = "HtmlLayoutExample.aspx";
            document.Author = "ceTe Software";
            document.Title = "HTML Layout Example";

            // Outputs the document to the current web page
            document.Draw(outputPdfPath);
        }
    }
}
