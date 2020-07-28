Imports ceTe.DynamicPDF.Forms
Imports ceTe.DynamicPDF.Merger

Public Class FormFlattening

    Public Shared Sub Run(outputPdfPath As String)

        Dim document As MergeDocument = New MergeDocument(Util.GetResourcePath("PDFs/fw9AcroForm_18_filled.pdf"))

        document.Form.Output = FormOutput.Flatten

        document.Draw(outputPdfPath)
    End Sub
End Class

