using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Merger;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.PageElements.BarCoding;
using System;
using System.Data.SqlClient;

namespace coresuite_asp_dotnet_framework_mvc_cs.CodeFiles
{
    public class MergerInvoiceCreator
    {
        #region Member Variables

        private static string templatePath;
        private decimal subTotal = 0;
        private decimal freight = 0;
        private static bool templatePathSet = false;

        #endregion

        #region Constructors

        public MergerInvoiceCreator()
        {
            SetTemplatePath();
        }

        #endregion

        #region Private Methods

        private void SetTemplatePath()
        {
            // Adds the image to page template if it is not already added
            if (!templatePathSet)
            {
                templatePath = System.Web.HttpContext.Current.Server.MapPath("~/PDFs/Invoice.pdf");
                templatePathSet = true;
            }
        }

        public void Draw(SqlConnection connection, Document document, int invoiceNumber)
        {
            // Each Invoice should begin a new section
            document.Sections.Begin();

            // Gets the Invoice data
            SqlDataReader data = GetInvoiceData(connection, invoiceNumber);

            // Adds the invoice if there is data
            if (data.Read())
            {
                // Sets the Freight amount
                freight = (decimal)data["Freight"];

                // Draws the invoice data, returns a page object if it is the last page
                Page lastPage = DrawInvoiceData(data, document);

                // Draws aditional pages if necessary
                while (lastPage == null)
                {
                    lastPage = DrawInvoiceData(data, document);
                }

                // Draws the totals to the bottom of the last page of the Invoice
                DrawTotals(data, lastPage);
            }

            // Close DataReader
            data.Close();
        }

        private Page DrawInvoiceData(SqlDataReader data, Document document)
        {
            // Tracks if the invoice is finished
            bool invoiceFinished = true;

            // Tracks the y position on the page
            float yOffset = 288;

            // Create a page using "Invoice.pdf" as a template
            Page page = new ImportedPage(templatePath, 1);

            // Uncomment the line below to show a layout grid.
            //page.Elements.Add( new LayoutGrid() );

            // Add Details to the Invoice
            DrawInvoiceDetails(data, page);

            // Add bill to address
            DrawBillTo(data, page);

            // Add ship to address
            DrawShipTo(data, page);

            // Add line items to the Invoice
            while (DrawLineItem(data, page, ref yOffset))
            {
                // Break if at the bottom of the page
                if (yOffset >= 666)
                {
                    invoiceFinished = false;
                    break;
                }
            }

            // Add the page to the document
            document.Pages.Add(page);

            // If Invoice is finished return the page else return null so another page will be added
            if (invoiceFinished)
            {
                return page;
            }
            else
            {
                page.Elements.Add(new Label("Continued...", 454, 704, 82, 12, Font.Helvetica, 12, TextAlign.Right));
                return null;
            }
        }

        private void DrawInvoiceDetails(SqlDataReader data, Page page)
        {
            // Adds Invoice details to the page
            page.Elements.Add(new Label(data["OrderID"].ToString(), 437, 25, 100, 12, Font.Helvetica, 12));
            page.Elements.Add(new Label(((DateTime)data["OrderDate"]).ToString("d MMM yyyy"), 437, 39, 100, 12, Font.Helvetica, 12));
            page.Elements.Add(new Label(data["CustomerID"].ToString(), 437, 53, 100, 12, Font.Helvetica, 12));
            if (!(data["ShippedDate"] is DBNull))
            {
                page.Elements.Add(new Label(((DateTime)data["ShippedDate"]).ToString("d MMM yyyy"), 437, 67, 100, 12, Font.Helvetica, 12));
            }
            page.Elements.Add(new Label(data["ShipperName"].ToString(), 437, 81, 100, 12, Font.Helvetica, 12));
            page.Elements.Add(new Interleaved25(data["OrderID"].ToString(), 380, 4, 18, false));
            page.Elements.Add(new PageNumberingLabel("Page %%SP%% of %%ST%% ", 450, 253, 90, 20, Font.HelveticaBold, 12, TextAlign.Center));
        }

        private void DrawBillTo(SqlDataReader data, Page page)
        {
            // Adds bill to address
            string strBillToAddress =
                data["BillName"].ToString() + "\n" +
                data["BillAddress"].ToString() + "\n" +
                data["BillCity"].ToString() + ", " +
                data["BillPostalCode"].ToString() + "\n" +
                data["BillCountry"].ToString();
            page.Elements.Add(new TextArea(strBillToAddress, 28, 138, 194, 70, Font.Helvetica, 12));
        }

        private void DrawShipTo(SqlDataReader data, Page page)
        {
            // Adds ship to address
            string strShipToAddress =
                data["ShipName"].ToString() + "\n" +
                data["ShipAddress"].ToString() + "\n" +
                data["ShipCity"].ToString() + ", " +
                data["ShipPostalCode"].ToString() + "\n" +
                data["ShipCountry"].ToString();
            page.Elements.Add(new TextArea(strShipToAddress, 318, 138, 194, 70, Font.Helvetica, 12));
        }

        private bool DrawLineItem(SqlDataReader data, Page page, ref float yOffset)
        {
            // Adds a line item to the invoice
            short quantity = (short)data["Quantity"];
            decimal unitPrice = (decimal)data["UnitPrice"];
            decimal lineTotal = unitPrice * quantity;

            subTotal += lineTotal;
            page.Elements.Add(new Label(quantity.ToString(), 4, 2 + yOffset, 52, 12, Font.Helvetica, 12, TextAlign.Right));
            page.Elements.Add(new Label(data["ProductName"].ToString(), 64, 2 + yOffset, 292, 12, Font.Helvetica, 12));
            page.Elements.Add(new Label(unitPrice.ToString("#,##0.00"), 364, 2 + yOffset, 82, 12, Font.Helvetica, 12, TextAlign.Right));
            page.Elements.Add(new Label(lineTotal.ToString("#,##0.00"), 454, 2 + yOffset, 82, 12, Font.Helvetica, 12, TextAlign.Right));
            yOffset += 18;

            // Advanses the recordset and returns if there are additional records
            return data.Read();
        }

        private void DrawTotals(SqlDataReader data, Page page)
        {
            // Add totals to the bottom of the Invoice
            decimal grandTotal = subTotal + freight;
            page.Elements.Add(new Label(subTotal.ToString("#,##0.00"), 454, 668, 82, 12, Font.Helvetica, 12, TextAlign.Right));
            page.Elements.Add(new Label(freight.ToString("#,##0.00"), 454, 686, 82, 12, Font.Helvetica, 12, TextAlign.Right));
            page.Elements.Add(new Label(grandTotal.ToString("#,##0.00"), 454, 704, 82, 12, Font.Helvetica, 12, TextAlign.Right));
        }

        private SqlDataReader GetInvoiceData(SqlConnection connection, int invoiceNumber)
        {
            // Creates a DataReader for the Invioce
            SqlCommand command = connection.CreateCommand();
            command.CommandText =
                "SELECT o.OrderID, o.CustomerID, o.OrderDate, o.ShippedDate, Freight, " +
                "		o.ShipName, o.ShipAddress, o.ShipCity, o.ShipPostalCode, o.ShipCountry, " +
                "		c.CompanyName as BillName, c.Address as BillAddress, " +
                "		c.City as BillCity, c.PostalCode as BillPostalCode, " +
                "		c.Country as BillCountry, s.CompanyName as ShipperName, " +
                "		p.ProductName, od.UnitPrice, od.Quantity " +
                "FROM	Orders o " +
                "JOIN	Customers c ON " +
                "		o.CustomerID = c.CustomerID " +
                "JOIN	Shippers s ON " +
                "		o.ShipVia = s.ShipperID " +
                "JOIN	[Order Details] od ON " +
                "		o.OrderID = od.OrderID " +
                "JOIN	Products p ON " +
                "		od.ProductID = p.ProductID " +
                "WHERE	o.OrderID = " + invoiceNumber;
            SqlDataReader dataReader = command.ExecuteReader();
            return dataReader;
        }

        #endregion
    }
}