Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements
Imports ceTe.DynamicPDF.PageElements.BarCoding

Public Class USEnvelope
    Public Shared Sub Run(outputPdfPath As String)
        'Create a MyDocument and set it's properties
        Dim MyDocument As ceTe.DynamicPDF.Document = New ceTe.DynamicPDF.Document
        MyDocument.Creator = "USEnvelope.aspx"
        MyDocument.Author = "ceTe Software"
        MyDocument.Title = "US Envelope"

        'Create a MyPage and add it to the MyDocument.
        Dim MyPage As ceTe.DynamicPDF.Page = New ceTe.DynamicPDF.Page(PageSize.Envelope10, PageOrientation.Landscape, 18)
        MyDocument.Pages.Add(MyPage)

        'Uncomment the line below to show a layout grid.
        'MyPage.Elements.Add(New LayoutGrid())

        'Add MyPage elements to the MyPage 
        MyPage.Elements.Add(New Image(Util.GetResourcePath("Images/DPDFLogo.png"), 0, 2, 0.16F))
        MyPage.Elements.Add(New TextArea(GetFromAddress(), 50, 0, 400, 80, Font.Helvetica, 10))
        MyPage.Elements.Add(New TextArea(GetToAddress(), 300, 140, 400, 80, Font.Helvetica, 12))
        'MyPage.Elements.Add(New Postnet(txtToZip.Text, 300, 248))

        'Check for an error
        Try
            MyDocument.Draw(outputPdfPath)
        Catch barCodeValue As InvalidValueBarCodeException
            'Show the Postnet value error
            ShowErrorDocument("Invalid To Zipcode. To zipcode must be a valid US zipcode.", "")
        Catch general As Exception
            'Show a general error
            ShowErrorDocument(general.Message, general.StackTrace)
        End Try


    End Sub

    Private Shared Sub ShowErrorDocument(ByVal Message As String, ByVal StackTrace As String)
        'Shows the error in a PDF MyDocument       
        Dim MyDocument As Document = New Document
        Dim MyPage As ceTe.DynamicPDF.Page = New ceTe.DynamicPDF.Page(PageSize.Letter, PageOrientation.Portrait)

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
        MyDocument.Draw("ErrorDocument.pdf")
    End Sub

    Private Shared Function GetFromAddress() As String
        'Returns a formatted From Address
        Return GetAddress("Any Company", "13071 Wainwright Road", "Suite 100", "Columbia", "MD", "20777")
    End Function

    Private Shared Function GetToAddress() As String
        'Returns a formatted To Address
        Return GetAddress("ceTe Software", "123 Main Street", "", "AnyWhere", "MD", "20815-4704")
    End Function

    Private Shared Function GetAddress(ByVal Name As String, ByVal Address As String, ByVal Address2 As String, ByVal City As String, ByVal State As String, ByVal Zip As String) As String
        'Formats a US address
        Dim MyAddress As String = Name.Trim() + vbCrLf
        MyAddress += Address.Trim() + vbCrLf
        If Address2.Trim().Length > 0 Then
            MyAddress += Address2.Trim() + vbCrLf
        End If
        MyAddress += City.Trim() + ", " + State.Trim() + "  " + Zip.Trim()

        Return MyAddress
    End Function
End Class
