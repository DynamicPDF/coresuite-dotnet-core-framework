Imports ceTe.DynamicPDF.Merger

Public Class TextExtraction
    Friend Shared Function Run() As String
        Dim document As PdfDocument = New PdfDocument(Util.GetResourcePath("PDFs/TimeMachine.pdf"))
        Return document.GetText()
    End Function
End Class
