using ceTe.DynamicPDF.Merger;
using System;
using System.Collections.Generic;
using System.Text;

namespace coresuite_dotnet_framework_console_cs.Merger
{
    class TextExtraction
    {
        public static string Run()
        {
            PdfDocument document = new PdfDocument(Util.GetResourcePath("PDFs/TimeMachine.pdf"));
            return document.GetText();
        }
    }
}
