using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Merger;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.PageElements.BarCoding;
using System;
using System.Collections.Generic;

namespace coresuite_dotnet_core_console_cs.merger
{
    class MergerInvoice
    {
        public static List<MergerInvoiceData.Order> order = MergerInvoiceData.Orders;

        internal static byte[] Run(string[] invoiceNumbers)
        {
            // Create a document and set it's properties
            Document document = new Document
            {
                Creator = "Invoice",
                Author = "ceTe Software",
                Title = "Invoice"
            };

            // Add Invoices to the document
            foreach (string item in invoiceNumbers)
            {
                foreach (MergerInvoiceData.Order data in order)
                {
                    if (item == data.OrderID.ToString())
                    {
                        MergerInvoiceCreator invoice = new MergerInvoiceCreator();
                        invoice.Draw(data, document);
                    }
                }
            }
          
            // Outputs the Invoices to the current web page
            try
            {
                return document.Draw();
            }
            catch (EmptyDocumentException)
            {
                // Show an empty document error
                return ShowErrorDocument("Document is empty. No invoices were selected.", "");
            }
            catch (Exception excGeneral)
            {
                // Show a general error
                return ShowErrorDocument(excGeneral.Message, excGeneral.StackTrace);
            }
        }

        private static byte[] ShowErrorDocument(string message, string stackTrace)
        {
            // Shows the error in a PDF document
            Document document = new Document();
            Page page = new Page(PageSize.Letter, PageOrientation.Portrait);

            TextArea messageArea = new TextArea(message, 0, 0, 512, 36, Font.Helvetica, 18, RgbColor.Red);
            messageArea.Height = messageArea.GetRequiredHeight();
            page.Elements.Add(messageArea);

            if (stackTrace.Trim().Length > 0)
            {
                float stackTraceTop = messageArea.Y + messageArea.Height + 20;

                TextArea stackTraceArea = new TextArea(stackTrace, 0, stackTraceTop, 512, 692 - stackTraceTop, Font.Helvetica, 10);

                page.Elements.Add(new Label("StackTrace:", 0, stackTraceTop - 12, 512, 12, Font.HelveticaBold, 10));
                page.Elements.Add(stackTraceArea);
            }
            document.Pages.Add(page);
            return document.Draw();
        }
    }

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
            // Adds the image to page template if it is not already added
            if (!templatePathSet)
            {
                templatePath = Util.GetResourcePath("PDFs/Invoice.pdf");
                templatePathSet = true;
            }
        }

        #endregion

        #region Private Methods

        public void Draw(MergerInvoiceData.Order data, Document document)
        {
            // Each Invoice should begin a new section
            document.Sections.Begin();

            // Adds the invoice if there is data
            if (data != null)
            { 
                // Sets the Freight amount
                freight = (decimal)data.Freight;

                // Draws the invoice data, returns a page object if it is the last page
                int i = 0;
                Page lastPage = DrawInvoiceData(data, document,ref i);

                // Draws aditional pages if necessary
                while (lastPage == null)
                {
                    lastPage = DrawInvoiceData(data, document,ref i);
                }

                // Draws the totals to the bottom of the last page of the Invoice
                DrawTotals(data, document.Pages[document.Pages.Count - 1]);
            }
        }

        private Page DrawInvoiceData(MergerInvoiceData.Order data, Document document,ref int start)
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
            page.Elements.Add(new TextArea(data.BillTo, 28, 139, 194, 70, Font.Helvetica, 12));

            // Add ship to address           
            page.Elements.Add(new TextArea(data.ShipTo, 318, 139, 194, 70, Font.Helvetica, 12));

            // Add line items to the Invoice   
            for (int i = start; i < data.OrderDetails.Count; i++)
            {
                DrawLineItem(data.OrderDetails[i], page, ref yOffset);
                // Break if at the bottom of the page
                if (yOffset >= 666)
                {
                    invoiceFinished = false;
                    start = i + 1;
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

        private void DrawInvoiceDetails(MergerInvoiceData.Order data, Page page)
        {
            // Adds Invoice details to the page
            page.Elements.Add(new Label(data.OrderID.ToString(), 437, 25, 100, 12, Font.Helvetica, 12));
            page.Elements.Add(new Label(((DateTime)data.OrderDate).ToString("d MMM yyyy"), 437, 39, 100, 12, Font.Helvetica, 12));
            page.Elements.Add(new Label(data.CustomerID.ToString(), 437, 53, 100, 12, Font.Helvetica, 12));
            if (!(data.ShippedDate==null))
            {
                page.Elements.Add(new Label(((DateTime)data.ShippedDate).ToString("d MMM yyyy"), 437, 67, 100, 12, Font.Helvetica, 12));
            }
            page.Elements.Add(new Label(data.ShipperName.ToString(), 437, 81, 100, 12, Font.Helvetica, 12));
            page.Elements.Add(new Interleaved25(data.OrderID.ToString(), 380, 4, 18, false));
            page.Elements.Add(new PageNumberingLabel("Page %%SP%% of %%ST%% ", 450, 253, 90, 20, Font.HelveticaBold, 12, TextAlign.Center));
        }

        private void DrawLineItem(MergerInvoiceData.OrderDetail detail, Page page, ref float yOffset)
        {
            // Adds a line item to the invoice
            Int16 quantity = (Int16)detail.Quantity;
            decimal unitPrice = (decimal)detail.UnitPrice;
            decimal lineTotal = unitPrice * quantity;
            subTotal += lineTotal;

            page.Elements.Add(new Label(quantity.ToString(), 4, 3 + yOffset, 52, 12, Font.Helvetica, 12, TextAlign.Right));
            page.Elements.Add(new Label(detail.ProductName.ToString(), 64, 3 + yOffset, 292, 12, Font.Helvetica, 12));
            page.Elements.Add(new Label(unitPrice.ToString("#,##0.00"), 364, 3 + yOffset, 82, 12, Font.Helvetica, 12, TextAlign.Right));
            page.Elements.Add(new Label(lineTotal.ToString("#,##0.00"), 454, 3 + yOffset, 82, 12, Font.Helvetica, 12, TextAlign.Right));
            yOffset += 18;
        }

        private void DrawTotals(MergerInvoiceData.Order data, Page page)
        {
            // Add totals to the bottom of the Invoice
            decimal grandTotal = subTotal + freight;
            page.Elements.Add(new Label(subTotal.ToString("#,##0.00"), 454, 668, 82, 12, Font.Helvetica, 12, TextAlign.Right));
            page.Elements.Add(new Label(freight.ToString("#,##0.00"), 454, 686, 82, 12, Font.Helvetica, 12, TextAlign.Right));
            page.Elements.Add(new Label(grandTotal.ToString("#,##0.00"), 454, 704, 82, 12, Font.Helvetica, 12, TextAlign.Right));
        }
       #endregion
    }
}
