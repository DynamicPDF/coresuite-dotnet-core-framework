using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;

namespace coresuite_dotnet_standard_cs.generator
{
    public class Invoice
    {
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

            // Establises connection to the database
            SqlConnection connection = new SqlConnection(Util.DynamicPDFConfiguration.GetConnectionString("NorthWindConnectionString"));
            connection.Open();

            // Add Invoices to the document
            foreach (string item in invoiceNumbers)
            {
                MyInvoice invoice = new MyInvoice();
                invoice.Draw(connection, document, int.Parse(item.Trim()));
            }

            // Cleans up database connections
            connection.Close();

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
}
