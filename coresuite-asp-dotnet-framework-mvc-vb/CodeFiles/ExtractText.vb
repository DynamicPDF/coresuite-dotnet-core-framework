Imports ceTe.DynamicPDF.Merger

Namespace coresuite_asp_dotnet_framework_mvc_vb.CodeFiles

    Public Class ExtractText
        Friend Shared Function Run() As String

            'Create PDF document object    
            Dim pdfA As PdfDocument = New PdfDocument(HttpContext.Current.Server.MapPath("~/PDFs/TimeMachine.pdf"))

            'Call GetText method from PDF document object to get the text from the document
            Return pdfA.GetText()
        End Function
    End Class
End Namespace
