Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements
Imports Microsoft.Extensions.Configuration
Imports System
Imports System.Data.SqlClient

Namespace coresuite_dotnet_standard_vb.generator

    Public Class Invoice

        Public Shared Function Run(ByVal invoiceNumbers As String()) As Byte()
            'Add the template to the document
            Dim MyDocument As Document = New Document With {
                .Creator = "Invoice",
                .Author = "ceTe Software",
                .Title = "Invoice",
                .Template = MyInvoice.GetTemplate
            }

            ' Establises connection to the database
            Dim connection As SqlConnection = New SqlConnection(Util.DynamicPDFConfiguration.GetConnectionString("NorthWindConnectionString"))
            connection.Open()

            ' Add Invoices to the document
            Dim item As String
            For Each item In invoiceNumbers
                Dim invoice As MyInvoice = New MyInvoice()
                invoice.Draw(connection, MyDocument, Integer.Parse(item.Trim()))
            Next

            'Cleans up database connections
            connection.Close()


            'Outputs the Invoices to the current web MyPage
            Try
                Return MyDocument.Draw()
            Catch empty As EmptyDocumentException
                'Show an empty MyDocument error
                Return ShowErrorDocument("Document is empty. No invoices were selected.", "")
            Catch general As Exception
                'Show a general error
                Return ShowErrorDocument(general.Message, general.StackTrace)
            End Try
        End Function

        Private Shared Function ShowErrorDocument(ByVal message As String, ByVal stackTrace As String) As Byte()
            'Shows the error in a PDF MyDocument
            Dim MyDocument As Document = New Document
            Dim MyPage As Page = New Page(PageSize.Letter, PageOrientation.Portrait)

            Dim MyMessage As TextArea = New TextArea(Message, 0, 0, 512, 36, Font.Helvetica, 18, RgbColor.Red)
            MyMessage.Height = MyMessage.GetRequiredHeight()
            MyPage.Elements.Add(MyMessage)

            If StackTrace.Trim().Length > 0 Then
                Dim StackTraceTop As Single = MyMessage.Y + MyMessage.Height + 20

                Dim StackTraceMessage As TextArea = New TextArea(StackTrace, 0, StackTraceTop, 512, 692 - StackTraceTop, Font.Helvetica, 10)

                MyPage.Elements.Add(New ceTe.DynamicPDF.PageElements.Label("StackTrace:", 0, StackTraceTop - 12, 512, 12, Font.HelveticaBold, 10))
                MyPage.Elements.Add(StackTraceMessage)
            End If
            MyDocument.Pages.Add(MyPage)
            Return MyDocument.Draw()
        End Function
    End Class
End Namespace