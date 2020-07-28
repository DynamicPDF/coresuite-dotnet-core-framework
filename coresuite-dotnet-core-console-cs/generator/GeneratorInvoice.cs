using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.PageElements.BarCoding;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace coresuite_dotnet_core_console_cs.generator
{
    public class GeneratorInvoice
    {
        public static List<GeneratorInvoiceData.Order> order = GeneratorInvoiceData.Orders;
      
        public static byte[] Run(string[] invoiceNumbers)
        {
            Document document = new Document
            {
                Creator = "Invoice",
                Author = "ceTe Software",
                Title = "Invoice",

                //Add the template to the document
                Template = MyInvoice.GetTemplate
            };

            // Add Invoices to the document           
            foreach (string item in invoiceNumbers)
            {
                foreach (GeneratorInvoiceData.Order data in order)
                {                              
                        if (item == data.OrderID.ToString())
                        {
                            MyInvoice invoice = new MyInvoice();
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


        public class MyInvoice
        {
            #region Member Variables

            private decimal subTotal = 0;
            private decimal freight = 0;
            private static Template template = new Template();
            private static bool pageTemplateImagesSet = false;
            private static WebColor backgroundColor = new WebColor("#E0E0FF");
            private static WebColor totalBGColor = new WebColor("#FFC0C0");
            private static WebColor thankYouText = new WebColor("#000080");
            public static List<GeneratorInvoiceData.Order> order = GeneratorInvoiceData.Orders;
            #endregion

            #region Constructors

            static MyInvoice()
            {
                // Uncomment the line below to add a layout grid to the pages
                //template.Elements.Add( new LayoutGrid() );

                // Top part of Invoice
                template.Elements.Add(new Label("Northwind Traders\n1234 International Drive\nAnywhere, Earth  ABC123", 56, 0, 200, 44, Font.Helvetica));
                template.Elements.Add(new Label("Invoice", 0, 0, 540, 18, Font.HelveticaBold, 18, TextAlign.Right));
                template.Elements.Add(new PageNumberingLabel("Page %%SP%% of %%ST%% ", 450, 253, 90, 20, Font.HelveticaBold, 12, TextAlign.Center));

                // Add Invoice Details Template
                template.Elements.Add(GetDetailsGroup());

                // Add BillTo Template
                template.Elements.Add(GetBillToGroup());

                // Add ShipTo Template
                template.Elements.Add(GetShipToGroup());

                // Add Line Item Template
                template.Elements.Add(GetLineItemGroup());
            }

            public MyInvoice()
            {
                SetPageTemplateImage();
            }

            #endregion

            public static Template GetTemplate
            {
                get { return template; }
            }

            #region Static Methods

            private static Group GetDetailsGroup()
            {
                // Returns a group containing the details template
                Group group = new Group();
                group.Add(new Rectangle(340, 24, 200, 72, RgbColor.Black, backgroundColor, 0.5f));
                group.Add(new Label("Order ID:", 343, 25, 85, 12, Font.HelveticaBold, 12, TextAlign.Right));
                group.Add(new Label("Order Date:", 343, 39, 85, 12, Font.HelveticaBold, 12, TextAlign.Right));
                group.Add(new Label("Customer ID:", 343, 53, 85, 12, Font.HelveticaBold, 12, TextAlign.Right));
                group.Add(new Label("Shipped Date:", 343, 67, 85, 12, Font.HelveticaBold, 12, TextAlign.Right));
                group.Add(new Label("Shipped Via:", 343, 81, 85, 12, Font.HelveticaBold, 12, TextAlign.Right));
                return group;
            }

            private static Group GetBillToGroup()
            {
                // Returns a group containing the bill to template
                Group group = new Group();
                group.Add(new Rectangle(25, 120, 200, 90, 0.5f));
                group.Add(new Line(25, 136, 225, 136, 0.5f));
                group.Add(new Label("Bill To:", 28, 121, 200, 12, Font.HelveticaBold, 12));
                return group;
            }

            private static Group GetShipToGroup()
            {
                // Returns a group containing the ship to template
                Group group = new Group();
                group.Add(new Rectangle(315, 120, 200, 90, 0.5f));
                group.Add(new Line(315, 136, 515, 136, 0.5f));
                group.Add(new Label("Ship To:", 318, 121, 200, 12, Font.HelveticaBold, 12));
                return group;
            }

            private static Group GetLineItemGroup()
            {
                // Returns a group containing the line items template
                Group group = new Group();

                for (int i = 0; i < 10; i++)
                {
                    group.Add(new Rectangle(0, 306 + i * 36, 540, 18, RgbColor.Black, backgroundColor, 0.0F));
                }

                group.Add(new Rectangle(450, 250, 90, 20, 0.5f));
                group.Add(new Rectangle(450, 702, 90, 18, RgbColor.Black, totalBGColor, 0.0F));
                group.Add(new Rectangle(0, 270, 540, 450, 0.5f));
                group.Add(new Line(0, 288, 540, 288, 0.5f));
                group.Add(new Line(0, 666, 540, 666, 0.5f));
                group.Add(new Line(60, 270, 60, 666, 0.5f));
                group.Add(new Line(360, 270, 360, 720, 0.5f));
                group.Add(new Line(450, 270, 450, 720, 0.5f));
                group.Add(new Line(450, 702, 540, 702, 0.5f));
                group.Add(new Label("Quantity", 0, 272, 60, 12, Font.HelveticaBold, 12, TextAlign.Center));
                group.Add(new Label("Description", 60, 272, 300, 12, Font.HelveticaBold, 12, TextAlign.Center));
                group.Add(new Label("Unit Price", 360, 272, 90, 12, Font.HelveticaBold, 12, TextAlign.Center));
                group.Add(new Label("Price", 450, 272, 90, 12, Font.HelveticaBold, 12, TextAlign.Center));
                group.Add(new Label("Thank you for your purchase.\nWe appreciate your business.", 5, 672, 350, 54, Font.HelveticaBold, 18, thankYouText));
                group.Add(new Label("Sub Total", 364, 668, 82, 12, Font.HelveticaBold, 12, TextAlign.Right));
                group.Add(new Label("Freight", 364, 686, 82, 12, Font.HelveticaBold, 12, TextAlign.Right));
                group.Add(new Label("Total", 364, 704, 82, 12, Font.HelveticaBold, 12, TextAlign.Right));

                return group;
            }

            #endregion

            #region Private Methods

            private void SetPageTemplateImage()
            {
                // Adds the image to page template if it is not already added
                if (!pageTemplateImagesSet)
                {
                    template.Elements.Add(new Image(Util.GetResourcePath("Images/DPDFLogo.png"), 0, 0, 0.16f));
                    pageTemplateImagesSet = true;
                }
            }

            public void Draw(GeneratorInvoiceData.Order data, Document document)
            {
            //Adds the invoice if there is data
            if (data != null)
                {
                    // Sets the Freight amount
                    freight = (decimal)data.Freight;

                    // Draws the invoice data, returns a page object if it is the last page
                    int i = 0;
                    Page lastPage = DrawInvoiceData(data, document, ref i);

                    // Draws aditional pages if necessary
                    while (lastPage == null)
                    {
                        lastPage = DrawInvoiceData(data, document, ref i);
                    }
                    // Draws the totals to the bottom of the last page of the Invoice
                    DrawTotals(data, document.Pages[document.Pages.Count - 1]);
                }
            }

            private Page DrawInvoiceData(GeneratorInvoiceData.Order data, Document document, ref int start)
            {
                // Tracks if the invoice is finished
                bool invoiceFinished = true;

                // Tracks the y position on the page
                float yOffset = 288;

                // Create a page for the Invoice
                Page page = new Page(PageSize.Letter, PageOrientation.Portrait, 36.0f);

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

            private void DrawInvoiceDetails(GeneratorInvoiceData.Order data, Page page)
            {
                // Adds Invoice details to the page
                page.Elements.Add(new Label(data.OrderID.ToString(), 437, 25, 100, 12, Font.Helvetica, 12));
                page.Elements.Add(new Label(((DateTime)data.OrderDate).ToString("d MMM yyyy"), 437, 39, 100, 12, Font.Helvetica, 12));
                page.Elements.Add(new Label(data.CustomerID.ToString(), 437, 53, 100, 12, Font.Helvetica, 12));

                if (!(data.ShippedDate == null))
                {
                    page.Elements.Add(new Label(((DateTime)data.ShippedDate).ToString("d MMM yyyy"), 437, 67, 100, 12, Font.Helvetica, 12));
                }

                page.Elements.Add(new Label(data.ShipperName.ToString(), 437, 81, 100, 12, Font.Helvetica, 12));
                page.Elements.Add(new Interleaved25(data.OrderID.ToString(), 380, 4, 18, false));
            }

            private void DrawLineItem(GeneratorInvoiceData.OrderDetail detail, Page page, ref float yOffset)
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

            private void DrawTotals(GeneratorInvoiceData.Order data, Page page)
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


