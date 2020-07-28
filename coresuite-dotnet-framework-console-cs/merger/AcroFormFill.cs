using ceTe.DynamicPDF.Merger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coresuite_dotnet_framework_console_cs.Merger
{
  public  class AcroFormFill
    {
        public static void Run(string outputPdfPath)
        {
            // Create a document and set it's properties
            MergeDocument document = new MergeDocument(Util.GetResourcePath("PDFs/fw9AcroForm_18.pdf"));
            document.Creator = "AcroFormFill.aspx";
            document.Author = "ceTe Software";
            document.Title = "W-9 AcroForm Filler";

            // Add content to the page
            document.Form.Fields["topmostSubform[0].Page1[0].f1_1[0]"].Value = "Any Company, Inc.";
            document.Form.Fields["topmostSubform[0].Page1[0].f1_2[0]"].Value = "Any Company";
            document.Form.Fields["topmostSubform[0].Page1[0].FederalClassification[0].c1_1[0]"].Value = "1";
            document.Form.Fields["topmostSubform[0].Page1[0].Address[0].f1_7[0]"].Value = "123 Main Street";
            document.Form.Fields["topmostSubform[0].Page1[0].Address[0].f1_8[0]"].Value = "Washington, DC  22222";
            document.Form.Fields["topmostSubform[0].Page1[0].f1_9[0]"].Value = "Any Requester";
            document.Form.Fields["topmostSubform[0].Page1[0].f1_10[0]"].Value = "17288825617";



            string ssn = "265748".Replace("-", "").Replace(" ", "");
            string ein = "521234567".Trim().Replace("-", "").Replace(" ", "");
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
            document.Draw(outputPdfPath);

        }
    }
}
