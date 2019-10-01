Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.LayoutEngine
Imports coresuite_dotnet_reportdata_vb

Namespace coresuite_dotnet_standard_vb.reportwriter

    Public Class FormFillReport

        Public Shared Sub Run(outputPdfPath As String)
            'Create the document's layout from a DLEX template
            Dim documentLayout As DocumentLayout = New DocumentLayout(Util.GetResourcePath("DLEX/FormFill.dlex"))

            ' Specify the data.
            Dim layoutData As NameValueLayoutData = New NameValueLayoutData()
            Dim w4Data As W4Data = New W4Data()
            w4Data.FirstNameAndI = "Alex B."
            w4Data.LastName = "Smith"
            w4Data.SSN = "123-45-6789"
            w4Data.HomeAddress = "456 Green Road"
            w4Data.IsSingle = True
            w4Data.CityStateZip = "Somewhere, Earth  12345"
            w4Data.Allowances = 2

            layoutData.Add("W4Data", w4Data)

            ' Layout the document And save the PDF
            Dim document As Document = documentLayout.Layout(layoutData)
            document.Author = "DynamicPDF ReportWriter"
            document.Title = "Form Fill Example"

            document.Draw(outputPdfPath)
        End Sub
    End Class
End Namespace
