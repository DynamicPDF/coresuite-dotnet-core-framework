using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Merger;
using ceTe.DynamicPDF.PageElements;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace coresuite_dotnet_framework_console_cs.Merger
{
    class SelectPages
    {
        internal static void Run(string[] selected, string fileName)
        {
            // Create a document and set it's properties
            Document document = new Document
            {
                Creator = "SelectPages",
                Author = "ceTe Software",
                Title = "Select Pages"
            };

            // Add a title page to the document
            AddTitlePage(document);

            // Add selected import pages to the document
            AddSelectedPages(document, selected.ToList());

            // Outputs the document to the current web page
            document.Draw(fileName);
        }

        private static void AddTitlePage(Document document)
        {
            // Creates title page
            Page page = new Page(PageSize.Letter, PageOrientation.Portrait, 50);
            // Creates and centeres image on title page
            Image image = new Image(Util.GetResourcePath("Images/DPDFLogo.png"), page.Dimensions.Body.Width / 2, page.Dimensions.Body.Height / 2, 0.48f);
            image.Align = Align.Center;
            image.VAlign = VAlign.Center;
            // Adds text and image to title page
            page.Elements.Add(new TextArea("Title Page", 0, 0, page.Dimensions.Body.Width, 72, Font.Helvetica, 72, TextAlign.Center));
            page.Elements.Add(image);
            // Adds title page to document
            document.Pages.Add(page);
        }

        private static void AddSelectedPages(Document document, List<string> selected)
        {
            try
            { 
            AddSelectedPagesFromDocument(document, selected.FindAll(s => s.StartsWith("A")), Util.GetResourcePath("PDFs/DocumentA.pdf"));
            AddSelectedPagesFromDocument(document, selected.FindAll(s => s.StartsWith("B")), Util.GetResourcePath("PDFs/DocumentB.pdf"));
            AddSelectedPagesFromDocument(document, selected.FindAll(s => s.StartsWith("C")), Util.GetResourcePath("PDFs/DocumentC.pdf"));
            AddSelectedPagesFromDocument(document, selected.FindAll(s => s.StartsWith("D")), Util.GetResourcePath("PDFs/DocumentD.pdf"));
            }
            catch(Exception e)
            {
                 Console.WriteLine(e.Message);
            }
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
