using ceTe.DynamicPDF.Merger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace coresuite_asp_dotnet_core_mvc_cs.CodeFiles
{
    public class ExtractText
    {
        internal static string Run(Microsoft.AspNetCore.Hosting.IHostingEnvironment currentEnvironment)
        {
            //Create PDF document object 
            PdfDocument pdfA = new PdfDocument(System.IO.Path.Combine(currentEnvironment.WebRootPath, "PDFs/TimeMachine.pdf"));

            //Call GetText method from PDF document object to get the text from the document
            return pdfA.GetText();
        }
    }
}