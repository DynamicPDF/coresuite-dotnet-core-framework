Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.LayoutEngine

Public Class SimpleReportWithCoverPage

    Public Shared Sub Run(outputPdfPath As String)
        Dim layoutReport As DocumentLayout = New DocumentLayout(Util.GetResourcePath("DLEX/SimpleReportWithCoverPage.dlex"))

        Dim layoutData As NameValueLayoutData = New NameValueLayoutData()
        layoutData.Add("ReportCreatedFor", "Alex Smith")
        layoutData.Add("Products", SimpleReportWithCoverPageExampleData.Products)

        ' Layout the document and set it's properties
        Dim document As Document = layoutReport.Layout(layoutData)
        document.Author = "DynamicPDF ReportWriter"
        document.Title = "Simple Report Example"

        ' Outputs the document to a file
        document.Draw(outputPdfPath)
    End Sub
End Class

