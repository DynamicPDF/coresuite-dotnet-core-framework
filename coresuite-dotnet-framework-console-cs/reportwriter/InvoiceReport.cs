using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace coresuite_dotnet_framework_console_cs.ReportWriter
{
    public class InvoiceReport
    {
        public static void Run(string outputPdfPath)
        {
            // Create the document's layout from a DLEX template
            DocumentLayout documentLayout = new DocumentLayout(Util.GetResourcePath("DLEX/Invoice.dlex"));

            InvoiceExampleData.Order order = InvoiceExampleData.Order11077;
            NameValueLayoutData layoutData = new NameValueLayoutData();
            layoutData.Add("OrderID", order.OrderID);
            layoutData.Add("OrderDate", order.OrderDate);
            layoutData.Add("CustomerID", order.CustomerID);
            layoutData.Add("ShippedDate", order.ShippedDate);
            layoutData.Add("ShipperName", order.ShipperName);
            layoutData.Add("BillTo", order.BillTo);
            layoutData.Add("ShipTo", order.ShipTo);
            layoutData.Add("Freight", order.Freight);
            layoutData.Add("OrderDetails", order.OrderDetails);

            // Layout the document using the parameters and set it's properties
            Document document = documentLayout.Layout(layoutData);
            document.Author = "DynamicPDF ReportWriter";
            document.Title = "Invoice Example";

            // Outputs the document to a file
            document.Draw(outputPdfPath);
        }
    }
}