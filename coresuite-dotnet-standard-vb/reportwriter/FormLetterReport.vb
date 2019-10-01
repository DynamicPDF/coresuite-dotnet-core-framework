Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.LayoutEngine

Namespace coresuite_dotnet_standard_vb.reportwriter

    Public Class FormLetterReport

        Public Shared Sub Run(outputPdfPath As String)
            ' Create the document's layout from a DLEX template
            Dim layoutReport As DocumentLayout = New DocumentLayout(Util.GetResourcePath("DLEX/FormLetter.dlex"))

            ' Specify the data.
            Dim layoutData As NameValueLayoutData = New NameValueLayoutData()
            layoutData.Add("Name", "Alex Smith")
            layoutData.Add("Address", "456 Green Road\nSomewhere, Earth")
            layoutData.Add("Amount", "$321.00")

            ' Layout the document and save the PDF
            Dim document As Document = layoutReport.Layout(layoutData)
            document.Author = "DynamicPDF ReportWriter"
            document.Title = "Form Letter Example"

            document.Draw(outputPdfPath)
        End Sub
    End Class
End Namespace