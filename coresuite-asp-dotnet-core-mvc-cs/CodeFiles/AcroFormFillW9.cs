using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Merger;
using ceTe.DynamicPDF.PageElements;
using coresuite_asp_dotnet_core_mvc_cs.Models;
using System;

namespace coresuite_asp_dotnet_core_mvc_cs.CodeFiles
{
    public class AcroFormFillW9
    {
        internal static byte[] Run(W9FormModel w9FormData, Microsoft.AspNetCore.Hosting.IHostingEnvironment currentEnvironment)
        {
            try
            {
                // Create a document and set it's properties
                PdfDocument pdf = new PdfDocument(System.IO.Path.Combine(currentEnvironment.WebRootPath, "PDFs/fw9AcroForm_18.pdf"));
                MergeDocument document = new MergeDocument(pdf)
                {
                    Creator = "AcroFormFill",
                    Author = "ceTe Software",
                    Title = "W-9 AcroForm Filler"
                };

                // Add content to the page
                if (!string.IsNullOrEmpty(w9FormData.Name))
                    document.Form.Fields["topmostSubform[0].Page1[0].f1_1[0]"].Value = w9FormData.Name;
                if (!string.IsNullOrEmpty(w9FormData.BusinessName))
                    document.Form.Fields["topmostSubform[0].Page1[0].f1_2[0]"].Value = w9FormData.BusinessName;

                switch (w9FormData.BusinessType)
                {
                    case BusinessType.Individual:
                        document.Form.Fields["topmostSubform[0].Page1[0].FederalClassification[0].c1_1[0]"].Value = "1";
                        break;
                    case BusinessType.C_Corporation:
                        document.Form.Fields["topmostSubform[0].Page1[0].FederalClassification[0].c1_1[1]"].Value = "2";
                        break;
                    case BusinessType.S_Corporation:
                        document.Form.Fields["topmostSubform[0].Page1[0].FederalClassification[0].c1_1[2]"].Value = "3";
                        break;
                    case BusinessType.Partnership:
                        document.Form.Fields["topmostSubform[0].Page1[0].FederalClassification[0].c1_1[3]"].Value = "4";
                        break;
                    case BusinessType.Trust:
                        document.Form.Fields["topmostSubform[0].Page1[0].FederalClassification[0].c1_1[4]"].Value = "5";
                        break;
                    case BusinessType.Limited_Liability_Company:
                        document.Form.Fields["topmostSubform[0].Page1[0].FederalClassification[0].c1_1[5]"].Value = "6";
                        if (!string.IsNullOrEmpty(w9FormData.TaxClassification))
                            document.Form.Fields["topmostSubform[0].Page1[0].FederalClassification[0].f1_3[0]"].Value = w9FormData.TaxClassification;
                        break;
                    case BusinessType.Other:
                        document.Form.Fields["topmostSubform[0].Page1[0].FederalClassification[0].c1_7[0]"].Value = "7";
                        if (!string.IsNullOrEmpty(w9FormData.OtherBusinessType))
                            document.Form.Fields["topmostSubform[0].Page1[0].FederalClassification[0].f1_4[0]"].Value = w9FormData.OtherBusinessType;
                        break;
                }

                if (!string.IsNullOrEmpty(w9FormData.Address))
                    document.Form.Fields["topmostSubform[0].Page1[0].Address[0].f1_7[0]"].Value = w9FormData.Address;
                if (!string.IsNullOrEmpty(w9FormData.CityState))
                    document.Form.Fields["topmostSubform[0].Page1[0].Address[0].f1_8[0]"].Value = w9FormData.CityState;
                if (!string.IsNullOrEmpty(w9FormData.RequestersNameAndAddress))
                    document.Form.Fields["topmostSubform[0].Page1[0].f1_9[0]"].Value = w9FormData.RequestersNameAndAddress;
                if (!string.IsNullOrEmpty(w9FormData.AccountNumbers))
                    document.Form.Fields["topmostSubform[0].Page1[0].f1_10[0]"].Value = w9FormData.AccountNumbers;

                string ssn = string.IsNullOrEmpty(w9FormData.SSN) ? "" : w9FormData.SSN.Trim().Replace("-", "").Replace(" ", "");
                string ein = string.IsNullOrEmpty(w9FormData.EmployersID) ? "" : w9FormData.EmployersID.Trim().Replace("-", "").Replace(" ", "");
                if (ssn.Length >= 9)
                {
                    document.Form.Fields["topmostSubform[0].Page1[0].SSN[0].f1_11[0]"].Value = ssn.Substring(0, 1) + ssn.Substring(1, 1) + ssn.Substring(2, 1);
                    document.Form.Fields["topmostSubform[0].Page1[0].SSN[0].f1_12[0]"].Value = ssn.Substring(3, 1) + ssn.Substring(4, 1);
                    document.Form.Fields["topmostSubform[0].Page1[0].SSN[0].f1_13[0]"].Value = ssn.Substring(5, 1) + ssn.Substring(6, 1) + ssn.Substring(7, 1) + ssn.Substring(8, 1);
                }
                else if (ein.Length >= 9)
                {
                    document.Form.Fields["topmostSubform[0].Page1[0].EmployerID[0].f1_14[0]"].Value = ein.Substring(0, 1) + ein.Substring(1, 1);
                    document.Form.Fields["topmostSubform[0].Page1[0].EmployerID[0].f1_15[0]"].Value = ein.Substring(2, 1) + ein.Substring(3, 1) + ein.Substring(4, 1) + ein.Substring(5, 1) + ein.Substring(6, 1) + ein.Substring(7, 1) + ein.Substring(8, 1);
                }

                // Uncomment to make form read only
                //document.Form.IsReadOnly = true;

                // Outputs the W-9 to the current web page
                return document.Draw();
            }
            catch (Exception ex)
            {
                return Util.GetErrorDocument(ex.Message, ex.StackTrace);
            }
        }

        internal static byte[] RunFormFill(W9FormModel w9FormData, Microsoft.AspNetCore.Hosting.IHostingEnvironment currentEnvironment)
        {
            // Create a MergeOptions object to import the AcroForm
            MergeOptions options = new MergeOptions(false);

            // Create a document and set it's properties
            MergeDocument document = new MergeDocument(System.IO.Path.Combine(currentEnvironment.WebRootPath, "PDFs/fw9_18.pdf"), options)
            {
                Creator = "FormFill",
                Author = "ceTe Software",
                Title = "W-9 Form Filler"
            };

            // Get the imorted page and set margins.
            Page page = document.Pages[0];
            page.Dimensions.SetMargins(41, 35, 45, 37);

            // Uncomment the line below to show a layout grid.
            //page.Elements.Add( new LayoutGrid() );

            // Add page elements to the page
            if (!string.IsNullOrEmpty(w9FormData.Name))
                page.Elements.Add(new Label(w9FormData.Name, 20, 60, 490, 12, Font.Courier, 9));
            if (!string.IsNullOrEmpty(w9FormData.BusinessName))
                page.Elements.Add(new Label(w9FormData.BusinessName, 20, 84, 490, 12, Font.Courier, 9));

            switch (w9FormData.BusinessType)
            {
                case BusinessType.Individual:
                    page.Elements.Add(new Label("3", 27, 125, 20, 12, Font.ZapfDingbats, 6));
                    break;
                case BusinessType.C_Corporation:
                    page.Elements.Add(new Label("3", 141, 124, 20, 12, Font.ZapfDingbats, 6));
                    break;
                case BusinessType.S_Corporation:
                    page.Elements.Add(new Label("3", 213, 124, 20, 12, Font.ZapfDingbats, 6));
                    break;
                case BusinessType.Partnership:
                    page.Elements.Add(new Label("3", 285, 124, 20, 12, Font.ZapfDingbats, 6));
                    break;
                case BusinessType.Trust:
                    page.Elements.Add(new Label("3", 357, 124, 20, 12, Font.ZapfDingbats, 6));
                    break;
                case BusinessType.Limited_Liability_Company:
                    page.Elements.Add(new Label("3", 27, 149, 50, 12, Font.ZapfDingbats, 6));
                    page.Elements.Add(new Label(w9FormData.TaxClassification, 375, 134, 160, 12, Font.Courier, 9));
                    break;
                case BusinessType.Other:
                    page.Elements.Add(new Label("3", 27, 196, 50, 12, Font.ZapfDingbats, 6));
                    if (!string.IsNullOrEmpty(w9FormData.OtherBusinessType))
                        page.Elements.Add(new Label(w9FormData.OtherBusinessType, 130, 158, 160, 12, Font.Courier, 9));
                    break;
            }

            if (!string.IsNullOrEmpty(w9FormData.Address))
                page.Elements.Add(new Label(w9FormData.Address, 20, 180, 300, 12, Font.Courier, 9));
            if (!string.IsNullOrEmpty(w9FormData.CityState))
                page.Elements.Add(new Label(w9FormData.CityState, 20, 204, 300, 12, Font.Courier, 9));
            if (!string.IsNullOrEmpty(w9FormData.RequestersNameAndAddress))
                page.Elements.Add(new Label(w9FormData.RequestersNameAndAddress, 350, 180, 170, 36, Font.Courier, 9));
            if (!string.IsNullOrEmpty(w9FormData.AccountNumbers))
                page.Elements.Add(new Label(w9FormData.AccountNumbers, 20, 228, 160, 12, Font.Courier, 9));

            string ssn = string.IsNullOrEmpty(w9FormData.SSN) ? "" : w9FormData.SSN.Trim().Replace("-", "").Replace(" ", "");
            string ein = string.IsNullOrEmpty(w9FormData.EmployersID) ? "" : w9FormData.EmployersID.Trim().Replace("-", "").Replace(" ", "");
            if (ssn.Length >= 9)
            {
                page.Elements.Add(new Label(ssn.Substring(0, 1), 375, 272, 14, 12, Font.Courier, 9, TextAlign.Center));
                page.Elements.Add(new Label(ssn.Substring(1, 1), 391.4f, 272, 14, 12, Font.Courier, 9, TextAlign.Center));
                page.Elements.Add(new Label(ssn.Substring(2, 1), 405.8f, 272, 14, 12, Font.Courier, 9, TextAlign.Center));
                page.Elements.Add(new Label(ssn.Substring(3, 1), 433.2f, 272, 14, 12, Font.Courier, 9, TextAlign.Center));
                page.Elements.Add(new Label(ssn.Substring(4, 1), 447.6f, 272, 14, 12, Font.Courier, 9, TextAlign.Center));
                page.Elements.Add(new Label(ssn.Substring(5, 1), 475.4f, 272, 14, 12, Font.Courier, 9, TextAlign.Center));
                page.Elements.Add(new Label(ssn.Substring(6, 1), 490.8f, 272, 14, 12, Font.Courier, 9, TextAlign.Center));
                page.Elements.Add(new Label(ssn.Substring(7, 1), 505.2f, 272, 14, 12, Font.Courier, 9, TextAlign.Center));
                page.Elements.Add(new Label(ssn.Substring(8, 1), 520, 272, 14, 12, Font.Courier, 9, TextAlign.Center));
            }
            else if (ein.Length >= 9)
            {
                page.Elements.Add(new Label(ein.Substring(0, 1), 376, 320, 14, 12, Font.Courier, 9, TextAlign.Center));
                page.Elements.Add(new Label(ein.Substring(1, 1), 391.4f, 320, 14, 12, Font.Courier, 9, TextAlign.Center));
                page.Elements.Add(new Label(ein.Substring(2, 1), 418.8f, 320, 14, 12, Font.Courier, 9, TextAlign.Center));
                page.Elements.Add(new Label(ein.Substring(3, 1), 433.2f, 320, 14, 12, Font.Courier, 9, TextAlign.Center));
                page.Elements.Add(new Label(ein.Substring(4, 1), 447.6f, 320, 14, 12, Font.Courier, 9, TextAlign.Center));
                page.Elements.Add(new Label(ein.Substring(5, 1), 462, 320, 14, 12, Font.Courier, 9, TextAlign.Center));
                page.Elements.Add(new Label(ein.Substring(6, 1), 476.4f, 320, 14, 12, Font.Courier, 9, TextAlign.Center));
                page.Elements.Add(new Label(ein.Substring(7, 1), 490.8f, 320, 14, 12, Font.Courier, 9, TextAlign.Center));
                page.Elements.Add(new Label(ein.Substring(8, 1), 505.2f, 320, 14, 12, Font.Courier, 9, TextAlign.Center));
            }

            // Outputs the W-9 to the current web page
            return document.Draw();
        }
    }
}