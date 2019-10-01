using ceTe.DynamicPDF.Merger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace coresuite_asp_dotnet_framework_mvc_cs.CodeFiles
{
    public class ExtractText
    {
        internal static string Run()
        {
            //Create PDF document object 
            PdfDocument pdfA = new PdfDocument(HttpContext.Current.Server.MapPath("~/PDFs/TimeMachine.pdf"));

            //Call GetText method from PDF document object to get the text from the document
            return pdfA.GetText();
        }
    }
}