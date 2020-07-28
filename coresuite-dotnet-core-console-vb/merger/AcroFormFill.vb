Imports ceTe.DynamicPDF.Merger

Public Class AcroFormFill
    Public Shared Sub Run(outputPdfPath As String)

        ' Create a document and set it's properties 
        Dim MyDocument As MergeDocument = New MergeDocument(Util.GetResourcePath("PDFs/fw9AcroForm_18.pdf"))
        MyDocument.Creator = "AcroFormFill.aspx"
        MyDocument.Author = "ceTe Software"
        MyDocument.Title = "W-9 AcroForm Filler"

        ' Get the imorted MyPage and set margins.
        Dim MyPage As ceTe.DynamicPDF.Page = MyDocument.Pages(0)

        ' Add content to the MyPage
        MyDocument.Form.Fields("topmostSubform[0].Page1[0].f1_1[0]").Value = "Any Company, Inc."
        MyDocument.Form.Fields("topmostSubform[0].Page1[0].f1_2[0]").Value = "Any Company"
        MyDocument.Form.Fields("topmostSubform[0].Page1[0].FederalClassification[0].c1_1[0]").Value = "1"
        MyDocument.Form.Fields("topmostSubform[0].Page1[0].Address[0].f1_7[0]").Value = "123 Main Street"
        MyDocument.Form.Fields("topmostSubform[0].Page1[0].Address[0].f1_8[0]").Value = "Washington, DC  22222"
        MyDocument.Form.Fields("topmostSubform[0].Page1[0].f1_9[0]").Value = "Any Requester"
        MyDocument.Form.Fields("topmostSubform[0].Page1[0].f1_10[0]").Value = "17288825617"
        Dim Ssn As String = "265748".Trim().Replace("-", "").Replace(" ", "")
        Dim Ein As String = "521234567".Trim().Replace("-", "").Replace(" ", "")
        If Ssn.Length >= 9 Then
            MyDocument.Form.Fields("topmostSubform[0].Page1[0].SSN[0].f1_11[0]").Value = Ssn.Substring(0, 1) + Ssn.Substring(1, 1) + Ssn.Substring(2, 1)
            MyDocument.Form.Fields("topmostSubform[0].Page1[0].SSN[0].f1_12[0]").Value = Ssn.Substring(3, 1) + Ssn.Substring(4, 1)
            MyDocument.Form.Fields("topmostSubform[0].Page1[0].SSN[0].f1_13[0]").Value = Ssn.Substring(5, 1) + Ssn.Substring(6, 1) + Ssn.Substring(7, 1) + Ssn.Substring(8, 1)
        ElseIf Ein.Length >= 9 Then
            MyDocument.Form.Fields("topmostSubform[0].Page1[0].EmployerID[0].f1_14[0]").Value = Ein.Substring(0, 1) + Ein.Substring(1, 1)
            MyDocument.Form.Fields("topmostSubform[0].Page1[0].EmployerID[0].f1_15[0]").Value = Ein.Substring(2, 1) + Ein.Substring(3, 1) + Ein.Substring(4, 1) + Ein.Substring(5, 1) + Ein.Substring(6, 1) + Ein.Substring(7, 1) + Ein.Substring(8, 1)

        End If

        ' Uncomment to make form read only
        'MyDocument.Form.IsReadOnly = True

        ' Outputs the W-9 to the current web MyPage
        MyDocument.Draw(outputPdfPath)


    End Sub
End Class
