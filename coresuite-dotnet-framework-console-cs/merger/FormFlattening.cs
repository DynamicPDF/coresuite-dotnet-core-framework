using ceTe.DynamicPDF.Forms;
using ceTe.DynamicPDF.Merger;

namespace coresuite_dotnet_framework_console_cs.Merger
{
    public class FormFlattening
    {
        public static void Run(string outputPdfPath)
        {
            MergeDocument document = new MergeDocument(Util.GetResourcePath("PDFs/fw9AcroForm_18_filled.pdf"));

            document.Form.Output = FormOutput.Flatten;

            document.Draw(outputPdfPath);
        }
    }
}