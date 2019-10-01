using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Imaging;

namespace coresuite_dotnet_standard_cs.generator
{
    public class TiffToPdf
    {
        public static void Run(string outputPdfPath)
        {
            // Create a TiffFile object from the TIFF image
            TiffFile tiffFile = new TiffFile(Util.GetResourcePath("Images/fw9_18.tif"));

            // Create a document object from the file
            Document document = tiffFile.GetDocument();

            // Save the PDF document
            document.Draw(outputPdfPath);
        }
    }
}
