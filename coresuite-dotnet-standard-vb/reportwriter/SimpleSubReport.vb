Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.LayoutEngine
Imports coresuite_dotnet_reportdata_vb

Namespace coresuite_dotnet_standard_vb.reportwriter

    Public Class SimpleSubReport

        Public Shared Sub Run(outputPdfPath As String)
            ' Create the document's layout from a DLEX template
            Dim layoutReport As DocumentLayout = New DocumentLayout(Util.GetResourcePath("DLEX/SimpleSubReport.dlex"))

            Dim layoutData As NameValueLayoutData = New NameValueLayoutData()
            layoutData.Add("ProductsByCategory", SimpleSubReportExampleData.ProductsByCategory)

            ' Layout the document and set it's properties
            Dim document As Document = layoutReport.Layout(layoutData)
            document.Author = "DynamicPDF ReportWriter"
            document.Title = "Simple SubReport Example"

            ' Outputs the document to a file
            document.Draw(outputPdfPath)
        End Sub
    End Class
End Namespace