Imports System.IO
Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements

Public Class PackagePdf

    Public Shared Sub Run(outputPdfPath As String)
        ' Create a PDF Document
        Dim MyDocument As Document = New Document
        MyDocument.Creator = "PackagePdf"
        MyDocument.Author = "ceTe Software"
        MyDocument.Title = "Package Pdf"

        ' FileStreams used for creating the instance of EmbeddedFile
        Dim fileStream1 As FileStream = New FileStream(Util.GetResourcePath("Images/DPDFLogo.png"), FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
        Dim fileStream2 As FileStream = New FileStream(Util.GetResourcePath("Data/HelloWorldExcel.xls"), FileMode.Open, FileAccess.Read, FileShare.ReadWrite)

        ' byte array of the file by reading the file.
        Dim filebyte(fileStream2.Length) As Byte
        fileStream2.Read(filebyte, 0, filebyte.Length)

        ' Created 3 instances of EmbeddedFile using all the available constructors.
        Dim embeddedFile1 As EmbeddedFile = New EmbeddedFile(Util.GetResourcePath("PDFs/DocumentA.pdf"))
        Dim embeddedFile2 As EmbeddedFile = New EmbeddedFile(fileStream1, "DPDFLogo.png", DateTime.Now)
        Dim embeddedFile3 As EmbeddedFile = New EmbeddedFile(filebyte, "HelloWorldExcel.xls", DateTime.Now)

        ' Added the embeddedFiles to the EmbeddedFileList of the document class.
        MyDocument.EmbeddedFiles.Add(embeddedFile1)
        MyDocument.EmbeddedFiles.Add(embeddedFile2)
        MyDocument.EmbeddedFiles.Add(embeddedFile3)

        ' Create a Page and add it to the document
        Dim MyPage As Page = New Page
        MyDocument.Pages.Add(MyPage)

        ' Create a Document Package with Attachment Layout Detailed
        MyDocument.Package = New DocumentPackage(AttachmentLayout.Detailed)

        ' Add a label to the page
        MyPage.Elements.Add(New Label("This is the cover page for a package PDF", 0, 0, 512, 40, Font.Helvetica, 24, TextAlign.Center))

        ' Save the PDF document
        MyDocument.Draw(outputPdfPath)

    End Sub

End Class

