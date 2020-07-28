using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using System.IO;

namespace coresuite_dotnet_core_console_cs.generator
{
    public class Watermark
    {
        // Templates for watermark elements
        public static Template template = new Template();

        public static void Run(string outputPdfPath)
        {
            // Create a document and set it's properties
            Document document = new Document
            {
                Creator = "Watermark.aspx",
                Author = "cete software",
                Title = "Watermark",
                Template = template,
                PdfVersion = PdfVersion.v1_6
            };

            // Adds elements to the template
            SetPageTemplate();

            // Adds Chapters to the document
            AddChapter(document, Util.GetResourcePath("Text/TimeMachine_Chapter1.txt"), "1", "Chapter 1");

            // Outputs the document to the current web page
            document.Draw(outputPdfPath);
        }

        public static void SetPageTemplate()
        {
            // Uncomment the line below to add a layout grid to the title header page
            //headerTemplate.Elements.Add( new LayoutGrid() );

            // Create Text watermark
            TextWatermark textWatermark = new TextWatermark("Draft");
            textWatermark.TextOutlineColor = textWatermark.TextColor;
            textWatermark.TextColor = null;
            // Add Text watermark to the template
            template.Elements.Add(textWatermark);

            //uncomment the below lines to add image watermark
            // Create Image watermark
            ImageWatermark imageWatermark = new ImageWatermark(Util.GetResourcePath("Images/DPDFLogo.png"));

            // Add Text watermark to the template
            template.Elements.Add(imageWatermark);
        }


        public static void AddChapter(Document document, string filePath, string title, string bookmarkText)
        {
            // Retrieves the text from the sections file
            string sectionText = GetTextFromFile(filePath);

            // Adds the first page of the section
            Page page = AddSectionHeaderPage(title, bookmarkText);

            // Creates a TextArea for the sections text
            TextArea textArea = new TextArea(sectionText, 0, 146, 324, 322, Font.TimesRoman, 11);
            textArea.Leading = 14;
            textArea.ParagraphSpacing = 20;
            page.Elements.Add(textArea);
            document.Pages.Add(page);

            // Creates a TextArea for the overflow text
            textArea = textArea.GetOverflowTextArea(0, 0, 324, 468);

            // Loops for 3 pages.
            for (int i = 0; i < 3; i++)
            {
                // Adds a new page to the document
                page = new Page(396, 540, 36);
                page.Elements.Add(textArea);

                // Adds new page to the document
                document.Pages.Add(page);

                // Creates a TextArea for the overflow text
                textArea = textArea.GetOverflowTextArea();

            }
        }

        public static string GetTextFromFile(string filePath)
        {
            // Opens a text file and returns the text from it.
            StreamReader textFile = File.OpenText(filePath);
            string sectionText = textFile.ReadToEnd();
            textFile.Close();
            return sectionText;
        }

        public static Page AddSectionHeaderPage(string title, string bookmarkText)
        {
            // Adds the first page of a section to the document
            Page page = new Page(396, 540, 36);

            // Uncomment the line below to add a layout grid to the section header pages
            //page.Elements.Add( new LayoutGrid() );

            page.Elements.Add(new Label("The Time Machine", 0, 36, 324, 30, Font.TimesBold, 30, TextAlign.Center));
            page.Elements.Add(new Label(title, 0, 96, 324, 22, Font.TimesBold, 22, TextAlign.Center));
            page.Elements.Add(new Line(120, 128, 204, 128));

            return page;
        }
    }
}
