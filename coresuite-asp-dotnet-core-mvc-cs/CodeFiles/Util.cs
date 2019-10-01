using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;

namespace coresuite_asp_dotnet_core_mvc_cs.CodeFiles
{
    public class Util
    {
        public static byte[] GetErrorDocument(string message, string stackTrace)
        {
            // Shows the error in a PDF document
            Document document = new Document();
            Page page = new Page(PageSize.Letter, PageOrientation.Portrait);

            TextArea messageArea = new TextArea(message, 0, 0, 512, 36, Font.Helvetica, 18, RgbColor.Red);
            messageArea.Height = messageArea.GetRequiredHeight();
            page.Elements.Add(messageArea);

            if (stackTrace.Trim().Length > 0)
            {
                float stackTraceTop = messageArea.Y + messageArea.Height + 20;

                TextArea stackTraceArea = new TextArea(stackTrace, 0, stackTraceTop, 512, 692 - stackTraceTop, Font.Helvetica, 10);

                page.Elements.Add(new Label("StackTrace:", 0, stackTraceTop - 12, 512, 12, Font.HelveticaBold, 10));
                page.Elements.Add(stackTraceArea);
            }
            document.Pages.Add(page);
            return document.Draw();
        }
    }
}