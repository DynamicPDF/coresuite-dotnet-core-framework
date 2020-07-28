Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.LayoutEngine

Public Class ContactListReport

    Public Shared Sub Run(outputPdfPath As String)

        ' Create the document's layout from a DLEX template
        Dim documentLayout As DocumentLayout = New DocumentLayout(Util.GetResourcePath("DLEX/ContactList.dlex"))

        Dim layoutData As NameValueLayoutData = New NameValueLayoutData()
        layoutData.Add("ContactGroups", ContactListExampleData.ContactGroups)

        ' Layout the document imports the parameters And set it's properties
        Dim document As Document = documentLayout.Layout(layoutData)
        document.Author = "DynamicPDF ReportWriter"
        document.Title = "Contact List Example"

        ' Outputs the document to a file
        document.Draw(outputPdfPath)
    End Sub
End Class

