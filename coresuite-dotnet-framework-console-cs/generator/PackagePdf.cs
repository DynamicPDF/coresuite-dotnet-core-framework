using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using System;
using System.IO;

namespace coresuite_dotnet_framework_console_cs.Generator
{
    public class PackagePdf
    {
        public static void Run(string outputPdfPath)
        {
            // Create a PDF Document
            Document document = new Document
            {
                Creator = "PackagePdf",
                Author = "ceTe Software",
                Title = "Package Pdf"
            };

            // FileStreams used for creating the instance of EmbeddedFile
            FileStream fileStream1 = new FileStream(Util.GetResourcePath("Images/DPDFLogo.png"), FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            FileStream fileStream2 = new FileStream(Util.GetResourcePath("Data/HelloWorldExcel.xls"), FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            // byte array of the file by reading the file.
            byte[] filebyte = new byte[fileStream2.Length];
            fileStream2.Read(filebyte, 0, filebyte.Length);

            // Created 3 instances of EmbeddedFile using all the available constructors.
            EmbeddedFile embeddedFile1 = new EmbeddedFile(Util.GetResourcePath("PDFs/DocumentA.pdf"));
            EmbeddedFile embeddedFile2 = new EmbeddedFile(fileStream1, "DPDFLogo.png", DateTime.Now);
            EmbeddedFile embeddedFile3 = new EmbeddedFile(filebyte, "HelloWorldExcel.xls", DateTime.Now);

            // Added the embeddedFiles to the EmbeddedFileList of the document public class.
            document.EmbeddedFiles.Add(embeddedFile1);
            document.EmbeddedFiles.Add(embeddedFile2);
            document.EmbeddedFiles.Add(embeddedFile3);

            // Create a Page and add it to the document
            Page page = new Page();
            document.Pages.Add(page);

            // Create a Document Package with Attachment Layout Detailed
            document.Package = new DocumentPackage(AttachmentLayout.Detailed);

            // Add a label to the page 
            page.Elements.Add(new Label("This is the cover page for a package PDF", 0, 0, 512, 40, Font.Helvetica, 24, TextAlign.Center));

            // Save the PDF document
            document.Draw(outputPdfPath);
        }
    }
}
