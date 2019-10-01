Imports System
Imports System.IO
Imports coresuite_dotnet_standard_vb.coresuite_dotnet_standard_vb.generator
Imports coresuite_dotnet_standard_vb.coresuite_dotnet_standard_vb.merger
Imports coresuite_dotnet_standard_vb.coresuite_dotnet_standard_vb.reportwriter

Module Program
    Sub Main(args As String())
#Region "Generator"

        HelloWorld.Run("HelloWorld.pdf")
        AllPageElements.Run("AllPageElements.pdf")
        Calendar.Run("Calender.pdf")
        Charting.Run("Charting.pdf")
        ContactList.Run("ContactList.pdf")
        Aes256BitEncryption.Run("Aes256BitEncryption.pdf")
        RC4128BitEncryption.Run("RC4128BitEncryption.pdf")
        HelloWorldLanguages.Run("HelloWorldLanguages.pdf")
        TaggedPdf.Run("TaggedPdf.pdf")
        HtmlAreaPDF.Run_WithHtmlTags("HtmlTags.pdf")
        HtmlAreaPDF.Run_WithHtmlTagsAndStyles("HtmlTagsWithStyles.pdf")
        HtmlLayoutPDF.Run("HtmlLayout.pdf")
        AltTextImage.Run("ImageWithAltText.pdf")
        MailingLabels.Run("MailingLabels.pdf")
        PackagePdf.Run("PackagePdf.pdf")
        SimpleReport.Run("SimpleReport.pdf")
        SimpleXMLReport.Run("SimpleXmlReport.pdf")
        TableReport.Run("TableReport.pdf")
        TaggedPdfWithStructureElements.Run("TaggedPdfWithStructureElements.pdf")
        TiffToPdf.Run("TiffToPdf.pdf")
        TimeMachine.Run("TimeMachine.pdf")
        TimeMachineTaggedPdf.Run("TimeMachineTaggedPdf.pdf")
        Watermark.Run("Watermark.pdf")
        Dim data() As Byte = Invoice.Run(New String() {"10248", "10251"})
        File.WriteAllBytes("Invoice.pdf", data)

#End Region

#Region "Merger"
        FieldLevelFlattening.Run("FieldLevelFlattening.pdf")
        FormFieldReader.Run("FormFieldReader.pdf")
        FormFlattening.Run("FormFlattening.pdf")
        MergePDFs.Run("MergePDFs.pdf")
        PlacePDFs.Run("PlacePDFs.pdf")
        StampPDF.Run("StampPDF.pdf")
#End Region

#Region "ReportWriter"
        ContactListReport.Run("ContactListExample.pdf")
        ContactListWithGroupByReport.Run("ContactListWithGroupByExample.pdf")
        FormFillReport.Run("FormFill.pdf")
        FormLetterReport.Run("FormLetter.pdf")
        InvoiceReport.Run("Invoice.pdf")
        PlaceHolderReport.Run("PlaceHolder.pdf")
        SimpleSubReport.Run("SimpleSubReport.pdf")
#End Region
    End Sub
End Module