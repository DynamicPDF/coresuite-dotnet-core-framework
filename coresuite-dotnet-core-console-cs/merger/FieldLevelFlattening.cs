using ceTe.DynamicPDF.Forms;
using ceTe.DynamicPDF.Merger;

namespace coresuite_dotnet_core_console_cs.merger
{
    public class FieldLevelFlattening
    {
        public static void Run(string outputPdfPath)
        {
            MergeDocument document = new MergeDocument(Util.GetResourcePath("PDFs/fw9AcroForm_18_filled.pdf"));

            document.Form.Fields["topmostSubform[0].Page1[0].f1_1[0]"].Output = FormFieldOutput.Remove;
            document.Form.Fields["topmostSubform[0].Page1[0].Address[0].f1_8[0]"].Output = FormFieldOutput.Remove;

            document.Form.Fields["topmostSubform[0].Page1[0].f1_2[0]"].Output = FormFieldOutput.Flatten;
            document.Form.Fields["topmostSubform[0].Page1[0].Address[0].f1_7[0]"].Output = FormFieldOutput.Flatten;

            document.Draw(outputPdfPath);
        }
    }
}