Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements
Imports ceTe.DynamicPDF.PageElements.BarCoding
Imports coresuite_asp_dotnet_framework_mvc_vb.Models

Namespace coresuite_asp_dotnet_framework_mvc_vb.CodeFiles
    Public Class USEnvelope

        Public Shared Function Run(ByVal envelope As EnvelopeModel) As Byte()
            ' Create a document And set it's properties
            Dim Document As Document = New Document With {
                .Creator = "USEnvelope.aspx",
                .Author = "ceTe Software",
                .Title = "US Envelope"
            }

            ' Create a page And add it to the document.
            Dim Page As Page = New Page(PageSize.Envelope10, PageOrientation.Landscape, 18)
            Document.Pages.Add(Page)

            'Uncomment the line below to show a layout grid.
            'page.Elements.Add( New LayoutGrid() )

            ' Add page elements to the page
            Page.Elements.Add(New Image(System.Web.HttpContext.Current.Server.MapPath("~/Images/DPDFLogo.png"), 0, 2, 0.16F))
            Page.Elements.Add(New TextArea(GetAddress(envelope.FromAddress), 50, 0, 350, 80, Font.Helvetica, 10))
            Page.Elements.Add(New TextArea(GetAddress(envelope.ToAddress), 300, 140, 360, 100, Font.Helvetica, 12))
            Page.Elements.Add(New Postnet(envelope.ToAddress.Zip, 300, 248))

            ' Check for an error
            Try
                Return Document.Draw()
            Catch barCodeValue As InvalidValueBarCodeException
                'Show the Postnet value error
                Return Util.GetErrorDocument("Invalid To Zipcode. To zipcode must be a valid US zipcode.", "")
            Catch excgeneral As Exception
                'Show a general error
                Return Util.GetErrorDocument(excgeneral.Message, excgeneral.StackTrace)
            End Try
        End Function

        Private Shared Function GetAddress(ByVal address As Address) As String
            ' Formats a US address
            Dim myAddress As String = address.Name + "\n"
            myAddress += address.Address1.Trim() + "\n"
            If (address.Address2.Trim().Length > 0) Then myAddress += address.Address2.Trim() + "\n"
            myAddress += address.City.Trim() + ", " + address.State.Trim() + "  " + address.Zip.Trim()
            Return myAddress
        End Function
    End Class
End Namespace