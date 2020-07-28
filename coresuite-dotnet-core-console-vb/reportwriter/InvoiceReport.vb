Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.LayoutEngine

Public Class InvoiceReport

    Public Shared Sub Run(outputPdfPath As String)
        ' Create the document's layout from a DLEX template
        Dim documentLayout As DocumentLayout = New DocumentLayout(Util.GetResourcePath("DLEX/Invoice.dlex"))

        Dim order As InvoiceExampleData.Order = InvoiceExampleData.Order11077
        Dim layoutData As NameValueLayoutData = New NameValueLayoutData()
        layoutData.Add("OrderID", order.OrderID)
        layoutData.Add("OrderDate", order.OrderDate)
        layoutData.Add("CustomerID", order.CustomerID)
        layoutData.Add("ShippedDate", order.ShippedDate)
        layoutData.Add("ShipperName", order.ShipperName)
        layoutData.Add("BillTo", order.BillTo)
        layoutData.Add("ShipTo", order.ShipTo)
        layoutData.Add("Freight", order.Freight)
        layoutData.Add("OrderDetails", order.OrderDetails)

        ' Layout the document imports the parameters and set it's properties
        Dim document As Document = documentLayout.Layout(layoutData)
        document.Author = "DynamicPDF ReportWriter"
        document.Title = "Invoice Example"

        ' Outputs the document to a file
        document.Draw(outputPdfPath)
    End Sub
End Class

