using ceTe.DynamicPDF;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace coresuite_asp_dotnet_core_mvc_cs.CodeFiles
{
    public class Invoice
    {
        public static byte[] Run(List<string> invoiceNumbers, string connectionString, IHostingEnvironment currentEnvironment)
        {
            Document document = new Document
            {
                Creator = "Invoice",
                Author = "ceTe Software",
                Title = "Invoice",

                //Add the template to the document
                Template = InvoiceCreator.GetTemplate
            };

            // Establises connection to the database
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            // Add Invoices to the document
            foreach (string item in invoiceNumbers)
            {
                InvoiceCreator invoice = new InvoiceCreator(currentEnvironment.WebRootPath);
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
                return Util.GetErrorDocument("Document is empty. No invoices were selected.", "");
            }
            catch (Exception excGeneral)
            {
                // Show a general error
                return Util.GetErrorDocument(excGeneral.Message, excGeneral.StackTrace);
            }
        }

        internal static byte[] RunMerger(List<string> invoiceNumbers, string connectionString, IHostingEnvironment currentEnvironment)
        {
            // Create a document and set it's properties
            Document document = new Document
            {
                Creator = "Invoice",
                Author = "ceTe Software",
                Title = "Invoice"
            };

            // Establises connection to the database
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            // Add Invoices to the document
            foreach (string item in invoiceNumbers)
            {
                MergerInvoiceCreator invoice = new MergerInvoiceCreator(currentEnvironment.WebRootPath);
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
                return Util.GetErrorDocument("Document is empty. No invoices were selected.", "");
            }
            catch (Exception excGeneral)
            {
                // Show a general error
                return Util.GetErrorDocument(excGeneral.Message, excGeneral.StackTrace);
            }
        }
    }
}