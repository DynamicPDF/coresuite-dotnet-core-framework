Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements.Forms

Public Class DigitalSignatures
    Public Shared Sub Run(outputPdfPath As String)
        Dim MyDocument As ceTe.DynamicPDF.Document = New ceTe.DynamicPDF.Document
        Dim MyPage As ceTe.DynamicPDF.Page = New ceTe.DynamicPDF.Page
        'Create & add Signature Form Field
        Dim MySignature As New Signature("SigField", 10, 10, 250, 100)
        MyPage.Elements.Add(MySignature)
        MyDocument.Pages.Add(MyPage)

        Dim MyCertificate As New Certificate(Util.GetResourcePath("Data/JohnDoe.pfx"), "dynamicpdf")
        MyDocument.Sign("SigField", MyCertificate)

        MyDocument.Draw(outputPdfPath)
    End Sub
End Class
