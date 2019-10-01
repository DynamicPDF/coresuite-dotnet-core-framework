Imports ceTe.DynamicPDF.Merger

Namespace coresuite_dotnet_standard_vb.merger

    Public Class MergePDFs

        Public Shared Sub Run(outputPdfPath As String)
            ' Create a merge document and set it's properties
            Dim document As MergeDocument = MergeDocument.Merge(Util.GetResourcePath("PDFs/DocumentA.pdf"), Util.GetResourcePath("PDFs/DocumentB.pdf"))

            ' Append additional PDF
            document.Append(Util.GetResourcePath("PDFs/DocumentC.pdf"))

            ' Append 3 pages from an aditional PDF
            document.Append(Util.GetResourcePath("PDFs/DocumentD.pdf"), 1, 3)

            ' Outputs the merged document to the current web page
            document.Draw(outputPdfPath)
        End Sub
    End Class
End Namespace