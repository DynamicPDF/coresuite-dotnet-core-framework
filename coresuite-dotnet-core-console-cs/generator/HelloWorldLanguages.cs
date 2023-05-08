using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.Text;

namespace coresuite_dotnet_core_console_cs.generator
{
    public class HelloWorldLanguages
    {
        public static void Run(string outputPdfPath)
        {
            // Create a document and set it's properties
            Document document = new Document
            {
                Creator = "HelloWorldLanguages",
                Author = "ceTe Software",
                Title = "Hello World Languages"
            };

            Font japansesFont = Font.HeiseiKakuGothicW5;
            Font koreanFont = Font.HanyangSystemsGothicMedium;
            Font chineseSimplifiedFont = Font.SinoTypeSongLight;
            Font chineseTraditionalFont = Font.MonotypeHeiMedium;
            Font latin1Font = Font.TimesRoman;
            Font unicodeFont = new OpenTypeFont("times.ttf");

            Font unicodeFont1 = new OpenTypeFont("micross.ttf");
            Font InFont = new OpenTypeFont("Nirmala.ttf");

            // Create a page to add to the document
            Page page = new Page(PageSize.Letter, PageOrientation.Portrait, 54.0f);
            Page page1 = new Page(PageSize.Letter, PageOrientation.Portrait, 54.0f);

            // Uncomment the line below to add a layout grid to the page
            //page.Elements.Add( new LayoutGrid() );

            // Add label to page
            AddLanguage(page, 1, 1, "Dutch:", "Hallo", latin1Font);
            AddLanguage(page, 2, 1, "English:", "Hello", latin1Font);
            AddLanguage(page, 1, 2, "French:", "Bonjour", latin1Font);
            AddLanguage(page, 2, 2, "German:", "Hallo", latin1Font);
            AddLanguage(page, 1, 3, "Greek:", "Χαίρετε", unicodeFont);
            AddLanguage(page, 2, 3, "Italian:", "Ciao", latin1Font);
            AddLanguage(page, 1, 4, "Japanese:", "こんにちは", japansesFont);
            AddLanguage(page, 2, 4, "Korean:", "안녕하세요", koreanFont);
            AddLanguage(page, 1, 5, "Norwegian:", "Hallo", latin1Font);
            AddLanguage(page, 2, 5, "Portuguese:", "Olá", latin1Font);
            AddLanguage(page, 1, 6, "Russian:", "Здравствуйте", unicodeFont);
            AddLanguage(page, 2, 6, "Simplified Chinese:", "你好", chineseSimplifiedFont);
            AddLanguage(page, 1, 7, "Spanish:", "Hola", latin1Font);
            AddLanguage(page, 2, 7, "Traditional Chinese:", "你好", chineseTraditionalFont);

            AddLanguage(page1, 1, 1, "Arabic:", "مرحبا", unicodeFont1);
            AddLanguage(page1, 2, 1, "Hebrew:", "שלום", unicodeFont1);
            AddLanguage(page1, 1, 2, "Thai:", "สวัสดี", unicodeFont1);
            AddLanguage(page1, 2, 2, "Hindi:", "नमस्ते", InFont);
            AddLanguage(page1, 1, 3, "Bangla:", "স্বাগত", InFont);
            AddLanguage(page1, 2, 3, "Tamil:", "வணக்கம்", InFont);


            // Add pages to document
            document.Pages.Add(page);
            document.Pages.Add(page1);

            // Outputs the document to the current web page
            document.Draw(outputPdfPath);
        }

        public static void AddLanguage(Page page, int column, int row, string language, string text, Font font)
        {
            float padding = 12;
            float rowMultiple = (page.Dimensions.Body.Height + padding) / 7;
            float columnMultiple = (page.Dimensions.Body.Width + padding) / 2;
            float rowHeight = rowMultiple - padding;
            float columnWidth = columnMultiple - padding;
            float xOffset = (column - 1) * columnMultiple;
            float yOffset = (row - 1) * rowMultiple;

            page.Elements.Add(new Label(language, xOffset, yOffset, columnWidth, 12, Font.Helvetica, 12));
            page.Elements.Add(new Rectangle(xOffset, yOffset + 16, columnWidth, rowHeight - 16, RgbColor.Black, RgbColor.Lavender, 0.5F));

            Label label = new Label(text, xOffset + 4, yOffset + 18, columnWidth - 8, rowHeight - 20, font, 24, TextAlign.Center);
            label.VAlign = VAlign.Center;

            page.Elements.Add(label);
        }
    }
}
