using coresuite_dotnet_standard_cs.generator;
using coresuite_dotnet_standard_cs.merger;
using coresuite_dotnet_standard_cs.reportwriter;
using System.IO;

namespace coresuite_dotnet_core_console_cs
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Generator

            HelloWorld.Run("HelloWorld.pdf");
            AllPageElements.Run("AllPageElements.pdf");
            Calender.Run("Calender.pdf");
            Charting.Run("Charting.pdf");
            ContactList.Run("ContactList.pdf");
            Aes256BitEncryption.Run("Aes256BitEncryption.pdf");
            RC4128BitEncryption.Run("RC4128BitEncryption.pdf");
            HelloWorldLanguages.Run("HelloWorldLanguages.pdf");
            TaggedPdf.Run("TaggedPdf.pdf");
            HtmlAreaPDF.Run_WithHtmlTags("HtmlTags.pdf");
            HtmlAreaPDF.Run_WithHtmlTagsAndStyles("HtmlTagsWithStyles.pdf");
            HtmlLayoutPDF.Run("HtmlLayout.pdf");
            AltTextImage.Run("ImageWithAltText.pdf");
            MailingLabels.Run("MailingLabels.pdf");
            PackagePdf.Run("PackagePdf.pdf");
            SimpleReport.Run("SimpleReport.pdf");
            SimpleXMLReport.Run("SimpleXmlReport.pdf");
            TableReport.Run("TableReport.pdf");
            TaggedPdfWithStructureElements.Run("TaggedPdfWithStructureElements.pdf");
            TiffToPdf.Run("TiffToPdf.pdf");
            TimeMachine.Run("TimeMachine.pdf");
            TimeMachineTaggedPdf.Run("TimeMachineTaggedPdf.pdf");
            Watermark.Run("Watermark.pdf");
            byte[] data = Invoice.Run(new string[] { "10248", "10251" });
            File.WriteAllBytes("Invoice.pdf", data);

            #endregion

            #region Merger

            FieldLevelFlattening.Run("FieldLevelFlattening.pdf");
            FormFieldReader.Run("FormFieldReader.pdf");
            FormFlattening.Run("FormFlattening.pdf");
            MergePDFs.Run("MergePDFs.pdf");
            PlacePDFs.Run("PlacePDFs.pdf");
            StampPDF.Run("StampPDF.pdf");

            #endregion

            #region ReportWriter

            ContactListReport.Run("ContactListExample.pdf");
            ContactListWithGroupByReport.Run("ContactListWithGroupByExample.pdf");
            FormFillReport.Run("FormFill.pdf");
            FormLetterReport.Run("FormLetter.pdf");
            InvoiceReport.Run("Invoice.pdf");
            PlaceHolderReport.Run("PlaceHolder.pdf");
            SimpleSubReport.Run("SimpleSubReport.pdf");

            #endregion
        }
    }
}