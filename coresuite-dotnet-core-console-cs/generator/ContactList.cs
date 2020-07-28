using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace coresuite_dotnet_core_console_cs.generator
{
    public class ContactList
    {
        #region Member Variables

        // Top, bottom, left and right margins of report
        public static float margin = 36;
        // Height of the header
        public static float headerHeight = 74;
        // Height of the footer
        public static float footerHeight = 14;
        // Size of paper to use
        public static PageDimensions pageSize = new PageDimensions(PageSize.Letter, PageOrientation.Landscape, margin);
        // Bottom Y coordinate for the body of the report
        public static float bodyBottom = pageSize.Height - (margin * 2) - footerHeight;

        // Current page that elements are being added to
        public static Page currentPage = null;

        // Current Y coordinate where elements are being added
        public static float currentY = 0;
        // Used to control the alternating background
        public static bool alternateBG = false;
        // Used to test for grouping
        public static string currentFirstI = string.Empty;
        // Template for header and footer elements

        public static Template template = null;

        public static List<ContactListData.ContactGroup> contactGroup = ContactListData.ContactGroups;
        #endregion

        public static void Run(string outputPdfPath)
        {
            if (template == null)
                SetTemplate();

            // Create a document and set it's properties
            Document document = new Document
            {
                Creator = "ContactList",
                Author = "ceTe Software",
                Title = "Contact List",
                Template = template
            };

            // Builds the report
            BuildDocument(document);

            // Outputs the ContactList to the current web page
            document.Draw(outputPdfPath);
        }

        #region Private Methods

        public static void SetTemplate()
        {
            template = new Template();

            // Uncomment the line below to add a layout grid to the each page
            //template.Elements.Add( new LayoutGrid() );

            // Adds header elements to the template
            template.Elements.Add(new Image(Util.GetResourcePath("Images/DPDFLogo.png"), 0, 0, 0.21f));
            template.Elements.Add(new Label("Northwind Traders", 0, 0, 720, 18, Font.HelveticaBold, 18, TextAlign.Center));
            template.Elements.Add(new Label("Contact List", 0, 21, 720, 12, Font.Helvetica, 12, TextAlign.Center));
            template.Elements.Add(new Label(DateTime.Now.ToString("dd MMM yyyy, H:mm:ss EST"), 0, 36, 720, 12, Font.Helvetica, 12, TextAlign.Center));
            template.Elements.Add(new Rectangle(0, 56, 720, 16, Grayscale.Black, new WebColor("0000A0"), 0.0F));
            template.Elements.Add(new Label("Cust ID", 2, 57, 58, 12, Font.HelveticaBold, 12, TextAlign.Left, Grayscale.White));
            template.Elements.Add(new Label("Company", 62, 57, 156, 12, Font.HelveticaBold, 12, TextAlign.Left, Grayscale.White));
            template.Elements.Add(new Label("Contact", 222, 57, 156, 12, Font.HelveticaBold, 12, TextAlign.Left, Grayscale.White));
            template.Elements.Add(new Label("Title", 362, 57, 156, 12, Font.HelveticaBold, 12, TextAlign.Left, Grayscale.White));
            template.Elements.Add(new Label("Phone", 522, 57, 86, 12, Font.HelveticaBold, 12, TextAlign.Left, Grayscale.White));
            template.Elements.Add(new Label("Fax", 622, 57, 86, 12, Font.HelveticaBold, 12, TextAlign.Left, Grayscale.White));

            // Adds footer elements to the template
            PageNumberingLabel pageNumLabel = new PageNumberingLabel("Page %%CP(i)%% of %%TP(i)%%", 0, bodyBottom + 5, 720, 10, Font.Helvetica, 10, TextAlign.Center);
            template.Elements.Add(pageNumLabel);
        }

        public static void BuildDocument(Document document)
        {
            // Builds the PDF document with data from the DataReader
            AddNewPage(document);

            foreach (var data in contactGroup)
            {
                // Add current record to the document
                AddRecord(document, data);
            }
        }

        public static void AddRecord(Document document, ContactListData.ContactGroup contactGroup)
        {
            // Creates TextAreas that are expandable
            foreach (var data in contactGroup.Contacts)
            { 
                TextArea companyName = new TextArea(data.CompanyName, 62, currentY + 3, 156, 11, Font.TimesRoman, 11);
                TextArea contactName = new TextArea(data.ContactName, 222, currentY + 3, 136, 11, Font.TimesRoman, 11);
                TextArea contactTitle = new TextArea(data.ContactTitle, 362, currentY + 3, 156, 11, Font.TimesRoman, 11);

                // Gets the height required for the current record
                float requiredHeight = SetExpandableRecords(document, contactGroup, companyName, contactName, contactTitle);

                // Creates non expandable Labels
                Label customerID = new Label(data.CustomerID, 2, currentY + 3, 58, 11, Font.TimesRoman, 11);
                Label phone = new Label(data.Phone, 522, currentY + 3, 96, 11, Font.TimesRoman, 11);
                Label fax = new Label(data.Fax == null ? "" : data.Fax, 622, currentY + 3, 96, 11, Font.TimesRoman, 11);

                // Adds alternating background if required
                if (alternateBG)
                {
                    currentPage.Elements.Add(new Rectangle(0, currentY, 720, requiredHeight + 6, RgbColor.Black, new WebColor("E0E0FF"), 0.0F));
                }

                // Toggles alternating background
                alternateBG = !alternateBG;

                // Adds elements to the current page
                currentPage.Elements.Add(customerID);
                currentPage.Elements.Add(companyName);
                currentPage.Elements.Add(contactName);
                currentPage.Elements.Add(contactTitle);
                currentPage.Elements.Add(phone);
                currentPage.Elements.Add(fax);

                // increments the current Y position on the page
                currentY += requiredHeight + 6;
            }
        }

        public static float SetExpandableRecords(Document document, ContactListData.ContactGroup data, TextArea companyName, TextArea contactName, TextArea contactTitle)
        {
            // Gets the maximum height requred of the three TextAreas
            float requiredHeight = GetMaxRecordHeight(companyName, contactName, contactTitle);

            // Add space for the section header if required
            float sectionHeaderHeight = 0;            
            if (currentFirstI != data.Letter) sectionHeaderHeight = 26;

            // Add a new page if needed
            if (bodyBottom < currentY + requiredHeight + sectionHeaderHeight + 4)
            {
                AddNewPage(document);
                if (sectionHeaderHeight == 0)
                {
                    // Update Y coordinate of TextArea when placed on the new page
                    companyName.Y = currentY + 3;
                    contactName.Y = currentY + 3;
                    contactTitle.Y = currentY + 3;
                }
            }

            // Add section header if required
            if (sectionHeaderHeight > 0)
            {
                AddSectionHeader(data);
                companyName.Y = currentY + 3;
                contactName.Y = currentY + 3;
                contactTitle.Y = currentY + 3;
            }
            return requiredHeight;
        }

        public static float GetMaxRecordHeight(TextArea companyName, TextArea contactName, TextArea contactTitle)
        {
            // Returns the maximum required height of the three TextAreas
            float requiredHeight = 11;
            float requiredHeightB = 0;

            requiredHeight = companyName.GetRequiredHeight();
            requiredHeightB = contactName.GetRequiredHeight();
            if (requiredHeightB > requiredHeight) requiredHeight = requiredHeightB;
            requiredHeightB = contactTitle.GetRequiredHeight();
            if (requiredHeightB > requiredHeight) requiredHeight = requiredHeightB;
            if (requiredHeight > 11)
            {
                companyName.Height = requiredHeight;
                contactName.Height = requiredHeight;
                contactTitle.Height = requiredHeight;
            }
            return requiredHeight;
        }

        public static void AddSectionHeader(ContactListData.ContactGroup data)
        {
            // Adds a section header to the current Y coordinate of the current page
            currentFirstI = data.Letter;
            currentPage.Elements.Add(new Label("- " + currentFirstI + " -", 0, currentY + 6, 720, 18, Font.HelveticaBold, 18, TextAlign.Center));
            currentY += 26;
            alternateBG = false;
        }

        public static void AddNewPage(Document document)
        {
            // Adds a new page to the document
            currentPage = new Page(pageSize);
            currentY = headerHeight;
            alternateBG = false;
            document.Pages.Add(currentPage);
        }
      #endregion
    }
}
