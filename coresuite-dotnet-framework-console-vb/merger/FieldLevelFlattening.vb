Imports ceTe.DynamicPDF.Forms
Imports ceTe.DynamicPDF.Merger

Public Class FieldLevelFlattening

    Public Shared Sub Run(outputPdfPath As String)
        Dim document As MergeDocument = New MergeDocument(Util.GetResourcePath("PDFs/fw9AcroForm_18_filled.pdf"))

        document.Form.Fields("topmostSubform[0].Page1[0].f1_1[0]").Output = FormFieldOutput.Remove
        document.Form.Fields("topmostSubform[0].Page1[0].Address[0].f1_8[0]").Output = FormFieldOutput.Remove

        document.Form.Fields("topmostSubform[0].Page1[0].f1_2[0]").Output = FormFieldOutput.Flatten
        document.Form.Fields("topmostSubform[0].Page1[0].Address[0].f1_7[0]").Output = FormFieldOutput.Flatten

        document.Draw(outputPdfPath)
    End Sub
End Class