Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements

Namespace coresuite_asp_dotnet_framework_mvc_vb.CodeFiles
    Public Class Util

        Public Shared Function GetErrorDocument(ByVal message As String, ByVal stackTrace As String) As Byte()
            ' Shows the error in a PDF document
            Dim document As Document = New Document()
            Dim page As Page = New Page(PageSize.Letter, PageOrientation.Portrait)

            Dim messageArea As TextArea = New TextArea(message, 0, 0, 512, 36, Font.Helvetica, 18, RgbColor.Red)
            messageArea.Height = messageArea.GetRequiredHeight()
            page.Elements.Add(messageArea)

            If stackTrace.Trim().Length > 0 Then
                Dim stackTraceTop As Single = messageArea.Y + messageArea.Height + 20

                Dim stackTraceArea As TextArea = New TextArea(stackTrace, 0, stackTraceTop, 512, 692 - stackTraceTop, Font.Helvetica, 10)

                page.Elements.Add(New Label("StackTrace:", 0, stackTraceTop - 12, 512, 12, Font.HelveticaBold, 10))
                page.Elements.Add(stackTraceArea)
            End If

            document.Pages.Add(page)
            Return document.Draw()

        End Function
    End Class
End Namespace