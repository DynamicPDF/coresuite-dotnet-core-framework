using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coresuite_dotnet_framework_console_cs.Generator
{
    class DigitalSignatures
    {
        public static void Run(string outputPdfPath)
        {
            Document document = new Document();
            Page page = new Page();

            Signature signature = new Signature("SigField", 10, 10, 250, 100);
            page.Elements.Add(signature);
            document.Pages.Add(page);

            Certificate certificate = new Certificate(Util.GetResourcePath("Data/JohnDoe.pfx"), "dynamicpdf");

            document.Sign("SigField", certificate);

            document.Draw(outputPdfPath);
        }
    }
}
