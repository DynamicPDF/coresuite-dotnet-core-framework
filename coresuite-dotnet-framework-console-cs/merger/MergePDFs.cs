using ceTe.DynamicPDF.Merger;

namespace coresuite_dotnet_framework_console_cs.Merger
{
    public class MergePDFs
    {
        public static void Run(string outputPdfPath)
        {
            // Create a merge document and set it's properties
            MergeDocument document = MergeDocument.Merge(Util.GetResourcePath("PDFs/DocumentA.pdf"), Util.GetResourcePath("PDFs/DocumentB.pdf"));

            // Append additional PDF
            document.Append(Util.GetResourcePath("PDFs/DocumentC.pdf"));

            // Append 3 pages from an aditional PDF
            document.Append(Util.GetResourcePath("PDFs/DocumentD.pdf"), 1, 3);

            // Outputs the merged document to the current web page
            document.Draw(outputPdfPath);
        }
    }
}