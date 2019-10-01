Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.LayoutEngine
Imports coresuite_dotnet_reportdata_vb

Namespace coresuite_dotnet_standard_vb.reportwriter

    Public Class ContactListWithGroupByReport

        Public Shared Sub Run(outputPdfPath As String)


            ' Create the document's layout from a DLEX template
            Dim documentLayout As DocumentLayout = New DocumentLayout(Util.GetResourcePath("DLEX/ContactListWithGroupBy.dlex"))

            Dim layoutData As NameValueLayoutData = New NameValueLayoutData()
            layoutData.Add("Contacts", ContactListWithGroupByExampleData.Contacts)

            ' Layout the document using the parameters and set it's properties
            Dim document As Document = documentLayout.Layout(layoutData)
            document.Author = "DynamicPDF ReportWriter"
            document.Title = "Contact List With Group By Example"

            ' Outputs the document to a file
            document.Draw(outputPdfPath)
        End Sub
    End Class
End Namespace