Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.Merger
Imports ceTe.DynamicPDF.PageElements

Namespace coresuite_dotnet_standard_vb.merger

    Public Class StampPDF

        Public Shared Sub Run(outputPdfPath As String)
            ' Create an output document And set it's properties
            Dim document As MergeDocument = New MergeDocument(Util.GetResourcePath("PDFs/fw9_18.pdf"))
            document.Creator = "StampPDF"
            document.Author = "ceTe Software"
            document.Title = "Stamp PDF"

            ' Create a template to place an image behind each page in the PDF
            Dim backgroundTemplate As Template = New Template()
            document.Template = backgroundTemplate
            backgroundTemplate.Elements.Add(New BackgroundImage(Util.GetResourcePath("Images/DPDFLogo_Watermark.png")))

            ' Create a label for the stamp And rotate it 20 degrees
            Dim MyLabel As Label = New Label("Stamped with Merger for .NET.", 0, 250, 500, 100, Font.Helvetica, 24, TextAlign.Center, RgbColor.Red)
            MyLabel.Angle = -20

            ' Create an anchor group to keep the label anchored regardless of page size
            Dim anchorGroup As AnchorGroup = New AnchorGroup(500, 100, Align.Center, VAlign.Top)
            anchorGroup.Add(MyLabel)

            ' Create a stamp template And add the anchor group containing the label to it
            Dim stampTemplate As Template = New Template()
            document.StampTemplate = stampTemplate
            stampTemplate.Elements.Add(anchorGroup)

            ' Outputs the stamped document to the current web page
            document.Draw(outputPdfPath)
        End Sub
    End Class
End Namespace