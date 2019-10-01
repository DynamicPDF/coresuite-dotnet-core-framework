using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Merger;
using ceTe.DynamicPDF.PageElements;
using System.Collections.Generic;

namespace coresuite_asp_dotnet_core_mvc_cs.CodeFiles
{
    internal class SelectPages
    {
        internal static byte[] Run(List<string> selected, Microsoft.AspNetCore.Hosting.IHostingEnvironment currentEnvironment)
        {
            // Create a document and set it's properties
            Document document = new Document
            {
                Creator = "SelectPages",
                Author = "ceTe Software",
                Title = "Select Pages"
            };

            // Add a title page to the document
            AddTitlePage(document, currentEnvironment);

            // Add selected import pages to the document
            AddSelectedPages(document, selected, currentEnvironment);

            // Outputs the document to the current web page
            return document.Draw();
        }

        private static void AddTitlePage(Document document, Microsoft.AspNetCore.Hosting.IHostingEnvironment currentEnvironment)
        {
            // Creates title page
            Page page = new Page(PageSize.Letter, PageOrientation.Portrait, 50);
            // Creates and centeres image on title page
            Image image = new Image(System.IO.Path.Combine(currentEnvironment.WebRootPath, "Images/DPDFLogo.png"), page.Dimensions.Body.Width / 2, page.Dimensions.Body.Height / 2, 0.48f);
            image.Align = Align.Center;
            image.VAlign = VAlign.Center;
            // Adds text and image to title page
            page.Elements.Add(new TextArea("Title Page", 0, 0, page.Dimensions.Body.Width, 72, Font.Helvetica, 72, TextAlign.Center));
            page.Elements.Add(image);
            // Adds title page to document
            document.Pages.Add(page);
        }

        private static void AddSelectedPages(Document document, List<string> selected, Microsoft.AspNetCore.Hosting.IHostingEnvironment currentEnvironment)
        {
            AddSelectedPagesFromDocument(document, selected.FindAll(s => s.StartsWith("A")), System.IO.Path.Combine(currentEnvironment.WebRootPath, "PDFs/DocumentA.pdf"));
            AddSelectedPagesFromDocument(document, selected.FindAll(s => s.StartsWith("B")), System.IO.Path.Combine(currentEnvironment.WebRootPath, "PDFs/DocumentB.pdf"));
            AddSelectedPagesFromDocument(document, selected.FindAll(s => s.StartsWith("C")), System.IO.Path.Combine(currentEnvironment.WebRootPath, "PDFs/DocumentC.pdf"));
            AddSelectedPagesFromDocument(document, selected.FindAll(s => s.StartsWith("D")), System.IO.Path.Combine(currentEnvironment.WebRootPath, "PDFs/DocumentD.pdf"));
        }

        private static void AddSelectedPagesFromDocument(Document document, List<string> list, string importDocument)
        {
            PdfDocument pdfDocument = new PdfDocument(importDocument);
            foreach (string item in list)
            {
                document.Pages.Add(new ImportedPage(pdfDocument.GetPage(int.Parse(item.Remove(0, 1)))));
            }
        }
    }
}