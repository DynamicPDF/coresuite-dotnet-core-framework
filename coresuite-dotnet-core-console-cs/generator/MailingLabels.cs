using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace coresuite_dotnet_core_console_cs.generator
{
    public class MailingLabels
    {
        //////////////////////////////////////////////////
        // Begin Setting Region
        // This settings are for Avery Label number 5160. Modify the settings below based on your label number

        // Set page dimensions
        static int topMargin = 36;
        static int bottomMargin = 36;
        static float rightMargin = 13.5f;
        static float leftMargin = 13.5f;

        // Set the number of labels per page
        static int maximumColumns = 3;
        static int maximumRows = 10;

        // Set the spacing between the labels
        static int horizontalSpace = 9;
        static int verticalSpace = 0;

        // These margins are on the labels themsleves
        static int labelTopBottomMargin = 5;
        static int labelLeftRightMargin = 15;

        // End Setting Region
        //////////////////////////////////////////////////

        static Document document;
        static Page page;
        static float currentColumn, currentRow, labelWidth, labelHeight;
        static string companyName;
        static string contactName;
        static string phone;
        static string fax;

        public static List<MailingLabelsData.Customer> mailingLabelsData = MailingLabelsData.Customers;


        public static void Run(string outputPdfPath)
        {
            // Put user code to initialize the page here
            document = new Document
            {
                Creator = "MailingLabels.aspx",
                Author = "ceTe Software",
                Title = "Mailing Labels"
            };
            page = new Page(PageSize.Letter, PageOrientation.Portrait);

            // Entrypoint for the labels
            currentRow = 1;
            currentColumn = 1;

            foreach (var data in mailingLabelsData)
            {
                companyName = SafeDataNull(data.CompanyName);
                contactName = SafeDataNull(data.ContactName);
                phone = SafeDataNull(data.Phone);
                fax = SafeDataNull(data.Fax);
                AddLabel();
            }
            if (page.Elements.Count > 0)
                document.Pages.Add(page);

            // Outputs the document to the current web page
            document.Draw(outputPdfPath);
        }

        public static float FindLabelHeight()
        {
            return (page.Dimensions.Height - (page.Dimensions.TopMargin + page.Dimensions.BottomMargin) - ((maximumRows - 1) * verticalSpace)) / maximumRows;
        }

        public static float FindLabelWidth()
        {
            return (page.Dimensions.Width - (page.Dimensions.RightMargin + page.Dimensions.LeftMargin) - ((maximumColumns - 1) * horizontalSpace)) / maximumColumns;
        }

        public static void AddLabel()
        {
            // Add a new page if you are beyond the maximum Rows
            if (currentRow == maximumRows + 1)
            {
                document.Pages.Add(page);
                currentRow = 1;
            }

            // Determines if the the label belongs in the first row or first column of the page
            if (currentColumn > 1 & currentRow > 1)
            {
                AddToPage();
            }
            else if (currentColumn > 1 & currentRow == 1)
            {
                AddToFirstRow();
            }
            else if (currentColumn == 1 & currentRow > 1)
            {
                AddToFirstColumn();
            }
            else
            {
                page = new Page(PageSize.Letter, PageOrientation.Portrait);
                page.Dimensions.TopMargin = topMargin;
                page.Dimensions.BottomMargin = bottomMargin;
                page.Dimensions.RightMargin = rightMargin;
                page.Dimensions.LeftMargin = leftMargin;
                labelWidth = FindLabelWidth();
                labelHeight = FindLabelHeight();
                AddToFirstRowColumn();
            }

            // Incremment your row if you are beyond the maximum columns
            if (currentColumn == maximumColumns + 1)
            {
                currentRow = currentRow + 1;
                currentColumn = 1;
            }
        }

        // Adds the label on at least row 2 column 2 of the page
        public static void AddToPage()
        {
            float x;
            float y;
            y = (currentRow - 1) * (labelHeight + verticalSpace);
            x = (currentColumn - 1) * (labelWidth + horizontalSpace);
            AddLabelInfo(x, y);
            currentColumn = currentColumn + 1;
        }

        // Adds the label on the first row of labels
        public static void AddToFirstRow()
        {
            float x;
            float y;
            y = 0;
            x = (currentColumn - 1) * (labelWidth + horizontalSpace);
            AddLabelInfo(x, y);
            currentColumn = currentColumn + 1;
        }

        // Adds the label to the First column of labels
        public static void AddToFirstColumn()
        {
            float x;
            float y;
            y = (currentRow - 1) * (labelHeight + verticalSpace);
            x = 0;
            AddLabelInfo(x, y);
            currentColumn = currentColumn + 1;
        }

        // Adds only the first label of every page (row 1 column 1)
        public static void AddToFirstRowColumn()
        {
            float x;
            float y;
            y = 0;
            x = 0;
            AddLabelInfo(x, y);
            currentColumn = currentColumn + 1;
        }

        // This is where you format the look of each label
        public static void AddLabelInfo(float x, float y)
        {
            TextArea txt1 = new TextArea(companyName, x + labelLeftRightMargin, y + labelTopBottomMargin, labelWidth - (labelLeftRightMargin * 2), 11, Font.TimesRoman, 11);
            TextArea txt2 = new TextArea(contactName, x + labelLeftRightMargin, y + labelTopBottomMargin + 12, labelWidth - (labelLeftRightMargin * 2), 11, Font.TimesRoman, 11);
            TextArea txt3 = new TextArea(phone, x + labelLeftRightMargin, y + labelTopBottomMargin + 24, labelWidth - (labelLeftRightMargin * 2), 11, Font.TimesRoman, 11);
            TextArea txt4 = new TextArea(fax, x + labelLeftRightMargin, y + labelTopBottomMargin + 36, labelWidth - (labelLeftRightMargin * 2), 11, Font.TimesRoman, 11);
            page.Elements.Add(txt1);
            page.Elements.Add(txt2);
            page.Elements.Add(txt3);
            page.Elements.Add(txt4);
        }

        public static string SafeDataNull(string value)
        {
            if (value == null)
                return String.Empty;
            else
                return value;
        }
    }
}