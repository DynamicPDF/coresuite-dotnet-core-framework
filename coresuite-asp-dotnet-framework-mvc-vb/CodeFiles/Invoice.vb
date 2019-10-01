Imports ceTe.DynamicPDF
Imports System.Data.SqlClient

Namespace coresuite_asp_dotnet_framework_mvc_vb.CodeFiles

    Public Class Invoice

        Public Shared Function Run(ByVal invoiceNumbers As List(Of String)) As Byte()

            'Add the template to the document
            Dim document As Document = New Document With {
                .Creator = "Invoice",
                .Author = "ceTe Software",
                .Title = "Invoice",
                .Template = InvoiceCreator.GetTemplate
            }

            ' Establises connection to the database
            Dim connection As SqlConnection = New SqlConnection(ConfigurationManager.AppSettings("NorthWindConnectionString"))
            connection.Open()

            ' Add Invoices to the document           
            Dim item As String
            For Each item In invoiceNumbers
                Dim invoice As InvoiceCreator = New InvoiceCreator()
                invoice.Draw(connection, document, Integer.Parse(item.Trim()))
            Next

            ' Cleans up database connections
            connection.Close()

            ' Outputs the Invoices to the current web page
            Try
                Return document.Draw()
            Catch Empty As EmptyDocumentException
                ' Show an empty document error
                Return Util.GetErrorDocument("Document is empty. No invoices were selected.", "")
            Catch excGeneral As Exception
                ' Show a general error
                Return Util.GetErrorDocument(excGeneral.Message, excGeneral.StackTrace)
            End Try

        End Function


        Friend Shared Function RunMerger(ByVal invoiceNumbers As List(Of String)) As Byte()
            ' Create a document And set it's properties
            Dim Document As Document = New Document With {
                .Creator = "Invoice",
                .Author = "ceTe Software",
                .Title = "Invoice"
            }

            ' Establises connection to the database
            Dim connection As SqlConnection = New SqlConnection(ConfigurationManager.AppSettings("NorthWindConnectionString"))
            connection.Open()

            ' Add Invoices to the document
            Dim item As String
            For Each item In invoiceNumbers
                Dim Invoice As MergerInvoiceCreator = New MergerInvoiceCreator()
                Invoice.Draw(connection, Document, Integer.Parse(item.Trim()))
            Next

            ' Cleans up database connections
            connection.Close()

            ' Outputs the Invoices to the current web page
            Try
                Return Document.Draw()
            Catch Empty As EmptyDocumentException
                ' Show an empty document error
                Return Util.GetErrorDocument("Document is empty. No invoices were selected.", "")
            Catch excGeneral As Exception
                'Show a general error
                Return Util.GetErrorDocument(excGeneral.Message, excGeneral.StackTrace)
            End Try
        End Function
    End Class
End Namespace