Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.Imaging

Public Class TiffToPdf

    Public Shared Sub Run(outputPdfPath As String)
        ' Create a TiffFile object from the TIFF image
        Dim tiffFile As TiffFile = New TiffFile(Util.GetResourcePath("Images/fw9_18.tif"))

        ' Create a document object from the file
        Dim document As Document = tiffFile.GetDocument()

        ' Save the PDF document
        document.Draw(outputPdfPath)
    End Sub
End Class

