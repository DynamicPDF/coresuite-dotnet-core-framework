Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.LayoutEngine.LayoutElements
Imports ceTe.DynamicPDF.LayoutEngine
Imports ceTe.DynamicPDF.PageElements
Imports ceTe.DynamicPDF.PageElements.BarCoding
Imports coresuite_dotnet_reportdata_vb

Namespace coresuite_dotnet_standard_vb.reportwriter

    Public Class PlaceHolderReport

        Public Shared Sub Run(outputPdfPath As String)
            'Create the document's layout from a DLEX template
            Dim documentLayout As DocumentLayout = New DocumentLayout(Util.GetResourcePath("DLEX/PlaceHolder.dlex"))

            'Retrieve the placeholder for the dynamic image and attach an event to it
            Dim barcode As PlaceHolder = CType(documentLayout.GetLayoutElementById("Barcode"), PlaceHolder)
            AddHandler barcode.LaidOut, AddressOf barcode_LaidOut

            'Specify the Data to use when laying out the document
            Dim layoutData As NameValueLayoutData = New NameValueLayoutData()
            layoutData.Add("HeaderData", "Popular Websites")
            layoutData.Add("Websites", PlaceHolderExampleData.Websites)

            'Layout the PDF document
            Dim document As Document = documentLayout.Layout(layoutData)
            document.Author = "ceTe Software"
            document.Title = "PlaceHolder Example"

            'Outputs the document to a file
            document.Draw(outputPdfPath)
        End Sub

        Private Shared Sub barcode_LaidOut(ByVal sender As Object, ByVal e As PlaceHolderLaidOutEventArgs)
            'Retrieve the image bytes from the layout data for the current record
            Dim url As String = e.LayoutWriter.Data("Url").ToString()

            ' Create a barcode page element from the data and set its properties
            Dim qrCode As QrCode = New QrCode(url, 0, 0, 2)

            ' Add the image to the placeholder's content area
            e.ContentArea.Add(qrCode)
            e.ContentArea.Add(New Link(0, 0, qrCode.GetSymbolWidth(), qrCode.GetSymbolHeight(), New UrlAction(url)))
        End Sub
    End Class
End Namespace