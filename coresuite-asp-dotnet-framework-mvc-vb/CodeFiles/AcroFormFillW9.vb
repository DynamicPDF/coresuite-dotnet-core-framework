Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements
Imports ceTe.DynamicPDF.Merger
Imports coresuite_asp_dotnet_framework_mvc_vb.Models

Namespace coresuite_asp_dotnet_framework_mvc_vb.CodeFiles
    Public Class AcroFormFillW9
        Friend Shared Function Run(ByVal w9FormData As W9FormModel) As Byte()
            Try
                Dim pdf As PdfDocument = New PdfDocument(HttpContext.Current.Server.MapPath("~/PDFs/fw9AcroForm_18.pdf"))
                Dim document As MergeDocument = New MergeDocument(pdf) With {
                    .Creator = "AcroFormFill",
                    .Author = "ceTe Software",
                    .Title = "W-9 AcroForm Filler"
                }
                document.Form.Fields("topmostSubform[0].Page1[0].f1_1[0]").Value = w9FormData.Name
                document.Form.Fields("topmostSubform[0].Page1[0].f1_2[0]").Value = w9FormData.BusinessName

                Select Case w9FormData.BusinessType
                    Case BusinessType.Individual
                        document.Form.Fields("topmostSubform[0].Page1[0].FederalClassification[0].c1_1[0]").Value = "1"
                    Case BusinessType.C_Corporation
                        document.Form.Fields("topmostSubform[0].Page1[0].FederalClassification[0].c1_1[1]").Value = "2"
                    Case BusinessType.S_Corporation
                        document.Form.Fields("topmostSubform[0].Page1[0].FederalClassification[0].c1_1[2]").Value = "3"
                    Case BusinessType.Partnership
                        document.Form.Fields("topmostSubform[0].Page1[0].FederalClassification[0].c1_1[3]").Value = "4"
                    Case BusinessType.Trust
                        document.Form.Fields("topmostSubform[0].Page1[0].FederalClassification[0].c1_1[4]").Value = "5"
                    Case BusinessType.Limited_Liability_Company
                        document.Form.Fields("topmostSubform[0].Page1[0].FederalClassification[0].c1_1[5]").Value = "6"
                        document.Form.Fields("topmostSubform[0].Page1[0].FederalClassification[0].f1_3[0]").Value = w9FormData.TaxClassification
                    Case BusinessType.Other
                        document.Form.Fields("topmostSubform[0].Page1[0].FederalClassification[0].c1_7[0]").Value = "7"
                        document.Form.Fields("topmostSubform[0].Page1[0].FederalClassification[0].f1_4[0]").Value = w9FormData.OtherBusinessType
                End Select

                document.Form.Fields("topmostSubform[0].Page1[0].Address[0].f1_7[0]").Value = w9FormData.Address
                document.Form.Fields("topmostSubform[0].Page1[0].Address[0].f1_8[0]").Value = w9FormData.CityState
                document.Form.Fields("topmostSubform[0].Page1[0].f1_9[0]").Value = w9FormData.RequestersNameAndAddress
                document.Form.Fields("topmostSubform[0].Page1[0].f1_10[0]").Value = w9FormData.AccountNumbers
                Dim ssn As String = If(String.IsNullOrEmpty(w9FormData.SSN), "", w9FormData.SSN.Trim().Replace("-", "").Replace(" ", ""))
                Dim ein As String = If(String.IsNullOrEmpty(w9FormData.EmployersID), "", w9FormData.EmployersID.Trim().Replace("-", "").Replace(" ", ""))

                If ssn.Length >= 9 Then
                    document.Form.Fields("topmostSubform[0].Page1[0].SSN[0].f1_11[0]").Value = ssn.Substring(0, 1) & ssn.Substring(1, 1) & ssn.Substring(2, 1)
                    document.Form.Fields("topmostSubform[0].Page1[0].SSN[0].f1_12[0]").Value = ssn.Substring(3, 1) & ssn.Substring(4, 1)
                    document.Form.Fields("topmostSubform[0].Page1[0].SSN[0].f1_13[0]").Value = ssn.Substring(5, 1) & ssn.Substring(6, 1) & ssn.Substring(7, 1) & ssn.Substring(8, 1)
                ElseIf ein.Length >= 9 Then
                    document.Form.Fields("topmostSubform[0].Page1[0].EmployerID[0].f1_14[0]").Value = ein.Substring(0, 1) & ein.Substring(1, 1)
                    document.Form.Fields("topmostSubform[0].Page1[0].EmployerID[0].f1_15[0]").Value = ein.Substring(2, 1) & ein.Substring(3, 1) & ein.Substring(4, 1) & ein.Substring(5, 1) & ein.Substring(6, 1) & ein.Substring(7, 1) & ein.Substring(8, 1)
                End If

                Return document.Draw()
            Catch ex As Exception
                Return Util.GetErrorDocument(ex.Message, ex.StackTrace)
            End Try
        End Function

        Friend Shared Function RunFormFill(ByVal w9FormData As W9FormModel) As Byte()
            Dim options As MergeOptions = New MergeOptions(False)
            Dim document As MergeDocument = New MergeDocument(HttpContext.Current.Server.MapPath("~/PDFs/fw9_18.pdf"), options) With {
                .Creator = "FormFill",
                .Author = "ceTe Software",
                .Title = "W-9 Form Filler"
            }
            Dim page As Page = document.Pages(0)
            page.Dimensions.SetMargins(41, 35, 45, 37)
            page.Elements.Add(New Label(w9FormData.Name, 20, 60, 490, 12, Font.Courier, 9))
            page.Elements.Add(New Label(w9FormData.BusinessName, 20, 84, 490, 12, Font.Courier, 9))

            Select Case w9FormData.BusinessType
                Case BusinessType.Individual
                    page.Elements.Add(New Label("3", 27, 125, 20, 12, Font.ZapfDingbats, 6))
                Case BusinessType.C_Corporation
                    page.Elements.Add(New Label("3", 141, 124, 20, 12, Font.ZapfDingbats, 6))
                Case BusinessType.S_Corporation
                    page.Elements.Add(New Label("3", 213, 124, 20, 12, Font.ZapfDingbats, 6))
                Case BusinessType.Partnership
                    page.Elements.Add(New Label("3", 285, 124, 20, 12, Font.ZapfDingbats, 6))
                Case BusinessType.Trust
                    page.Elements.Add(New Label("3", 357, 124, 20, 12, Font.ZapfDingbats, 6))
                Case BusinessType.Limited_Liability_Company
                    page.Elements.Add(New Label("3", 27, 149, 50, 12, Font.ZapfDingbats, 6))
                    page.Elements.Add(New Label(w9FormData.TaxClassification, 375, 134, 160, 12, Font.Courier, 9))
                Case BusinessType.Other
                    page.Elements.Add(New Label("3", 27, 196, 50, 12, Font.ZapfDingbats, 6))
                    page.Elements.Add(New Label(w9FormData.OtherBusinessType, 130, 158, 160, 12, Font.Courier, 9))
            End Select

            page.Elements.Add(New Label(w9FormData.Address, 20, 180, 300, 12, Font.Courier, 9))
            page.Elements.Add(New Label(w9FormData.CityState, 20, 204, 300, 12, Font.Courier, 9))
            page.Elements.Add(New Label(w9FormData.RequestersNameAndAddress, 350, 180, 170, 36, Font.Courier, 9))
            page.Elements.Add(New Label(w9FormData.AccountNumbers, 20, 228, 160, 12, Font.Courier, 9))
            Dim ssn As String = If(String.IsNullOrEmpty(w9FormData.SSN), "", w9FormData.SSN.Trim().Replace("-", "").Replace(" ", ""))
            Dim ein As String = If(String.IsNullOrEmpty(w9FormData.EmployersID), "", w9FormData.EmployersID.Trim().Replace("-", "").Replace(" ", ""))

            If ssn.Length >= 9 Then
                page.Elements.Add(New Label(ssn.Substring(0, 1), 375, 272, 14, 12, Font.Courier, 9, TextAlign.Center))
                page.Elements.Add(New Label(ssn.Substring(1, 1), 391.4F, 272, 14, 12, Font.Courier, 9, TextAlign.Center))
                page.Elements.Add(New Label(ssn.Substring(2, 1), 405.8F, 272, 14, 12, Font.Courier, 9, TextAlign.Center))
                page.Elements.Add(New Label(ssn.Substring(3, 1), 433.2F, 272, 14, 12, Font.Courier, 9, TextAlign.Center))
                page.Elements.Add(New Label(ssn.Substring(4, 1), 447.6F, 272, 14, 12, Font.Courier, 9, TextAlign.Center))
                page.Elements.Add(New Label(ssn.Substring(5, 1), 475.4F, 272, 14, 12, Font.Courier, 9, TextAlign.Center))
                page.Elements.Add(New Label(ssn.Substring(6, 1), 490.8F, 272, 14, 12, Font.Courier, 9, TextAlign.Center))
                page.Elements.Add(New Label(ssn.Substring(7, 1), 505.2F, 272, 14, 12, Font.Courier, 9, TextAlign.Center))
                page.Elements.Add(New Label(ssn.Substring(8, 1), 520, 272, 14, 12, Font.Courier, 9, TextAlign.Center))
            ElseIf ein.Length >= 9 Then
                page.Elements.Add(New Label(ein.Substring(0, 1), 376, 320, 14, 12, Font.Courier, 9, TextAlign.Center))
                page.Elements.Add(New Label(ein.Substring(1, 1), 391.4F, 320, 14, 12, Font.Courier, 9, TextAlign.Center))
                page.Elements.Add(New Label(ein.Substring(2, 1), 418.8F, 320, 14, 12, Font.Courier, 9, TextAlign.Center))
                page.Elements.Add(New Label(ein.Substring(3, 1), 433.2F, 320, 14, 12, Font.Courier, 9, TextAlign.Center))
                page.Elements.Add(New Label(ein.Substring(4, 1), 447.6F, 320, 14, 12, Font.Courier, 9, TextAlign.Center))
                page.Elements.Add(New Label(ein.Substring(5, 1), 462, 320, 14, 12, Font.Courier, 9, TextAlign.Center))
                page.Elements.Add(New Label(ein.Substring(6, 1), 476.4F, 320, 14, 12, Font.Courier, 9, TextAlign.Center))
                page.Elements.Add(New Label(ein.Substring(7, 1), 490.8F, 320, 14, 12, Font.Courier, 9, TextAlign.Center))
                page.Elements.Add(New Label(ein.Substring(8, 1), 505.2F, 320, 14, 12, Font.Courier, 9, TextAlign.Center))
            End If

            Return document.Draw()
        End Function
    End Class
End Namespace


