using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.PageElements.BarCoding;
using System;
using System.IO;

namespace coresuite_dotnet_standard_cs.generator
{
    public class TimeMachineTaggedPdf
    {
        // Templates for header and footer elements
        public static Template footerTemplate = new Template();
        public static EvenOddTemplate headerTemplate = new EvenOddTemplate();

        public static void Run(string outputPdfPath)
        {
            // Create a document and set it's properties
            Document document = new Document
            {
                Creator = "TimeMachineTaggedPdf.aspx",
                Author = "H. G. Wells",
                Title = "The Time Machine",
                Template = headerTemplate,

                // Specify document as tagged PDF
                Tag = new TagOptions()
            };

            // Adds elements to the header and footer groups
            SetPageHeaderTemplate();
            SetPageFooterTemplate();

            // Sets up outline hierarchy
            Outline titlePageOutline = document.Outlines.Add("The Time Machine", new XYDestination(1, 0, 0));
            Outline chapterOutline = titlePageOutline.ChildOutlines.Add("Chapters");

            // Builds the report
            BuildDocument(document, titlePageOutline, chapterOutline);

            // Outputs the ContactList to the current web page
            document.Draw(outputPdfPath);
        }

        public static void BuildDocument(Document document, Outline titlePage, Outline chapters)
        {
            // Adds Title page to document
            document.Sections.Begin(NumberingStyle.None, "Cover");
            AddTitlePage(document);
            document.Sections.Begin(NumberingStyle.Numeric, "Page ", footerTemplate);

            // Adds Chapters to the document
            AddChapter(document, Util.GetResourcePath("Text/TimeMachine_Chapter1.txt"), "1", "Chapter 1", chapters);
            AddChapter(document, Util.GetResourcePath("Text/TimeMachine_Chapter2.txt"), "2", "Chapter 2", chapters);
            AddChapter(document, Util.GetResourcePath("Text/TimeMachine_Chapter3.txt"), "3", "Chapter 3", chapters);
            AddChapter(document, Util.GetResourcePath("Text/TimeMachine_Chapter4.txt"), "4", "Chapter 4", chapters);
            AddChapter(document, Util.GetResourcePath("Text/TimeMachine_Chapter5.txt"), "5", "Chapter 5", chapters);
            AddChapter(document, Util.GetResourcePath("Text/TimeMachine_Chapter6.txt"), "6", "Chapter 6", chapters);
            AddChapter(document, Util.GetResourcePath("Text/TimeMachine_Chapter7.txt"), "7", "Chapter 7", chapters);
            AddChapter(document, Util.GetResourcePath("Text/TimeMachine_Chapter8.txt"), "8", "Chapter 8", chapters);
            AddChapter(document, Util.GetResourcePath("Text/TimeMachine_Chapter9.txt"), "9", "Chapter 9", chapters);
            AddChapter(document, Util.GetResourcePath("Text/TimeMachine_Chapter10.txt"), "10", "Chapter 10", chapters);
            AddChapter(document, Util.GetResourcePath("Text/TimeMachine_Chapter11.txt"), "11", "Chapter 11", chapters);
            AddChapter(document, Util.GetResourcePath("Text/TimeMachine_Chapter12.txt"), "12", "Chapter 12", chapters);

            // Add the Epilogue to the document
            AddChapter(document, Util.GetResourcePath("Text/TimeMachine_Epilogue.txt"), "Epilogue", "Epilogue", titlePage);
        }

        public static void SetPageHeaderTemplate()
        {
            // Uncomment the line below to add a layout grid to the title header page
            //headerTemplate.Elements.Add( new LayoutGrid() );

            // Adds elements to the header template
            headerTemplate.OddElements.Add(new Label("The Time Machine", -18, -18, 324, 11, Font.TimesRoman, 11, TextAlign.Left));
            headerTemplate.OddElements.Add(new Label("H. G. Wells", 18, -18, 324, 11, Font.TimesRoman, 11, TextAlign.Right));
            headerTemplate.EvenElements.Add(new Label("H. G. Wells", -18, -18, 324, 11, Font.TimesRoman, 11, TextAlign.Left));
            headerTemplate.EvenElements.Add(new Label("The Time Machine", 18, -18, 324, 11, Font.TimesRoman, 11, TextAlign.Right));
        }

        public static void SetPageFooterTemplate()
        {
            // Adds elements to the footer template
            PageNumberingLabel pageNumberLabel = new PageNumberingLabel("- %%CP%% -", 0, 478, 324, 11, Font.TimesRoman, 11, TextAlign.Center);
            pageNumberLabel.PageOffset = -1;
            footerTemplate.Elements.Add(pageNumberLabel);
        }

        public static void AddTitlePage(Document document)
        {
            //Adds a title page to the document
            Page page = new Page(396, 540, 36);

            // Uncomment the line below to add a layout grid to the title page
            //page.Elements.Add( new LayoutGrid() );

            string disclaimer = "This document is in the public domain. Permission to use, copy, modify, and distribute this document for any purpose and without fee is hereby granted, without any conditions or restrictions. The barcode below is for demonstration purposes only.";
            string generated = "Generated by\nDynamicPDF Generator for .NET\non " + DateTime.Now.ToLongDateString() + ",\nat " + DateTime.Now.ToLongTimeString() + " EST";
            page.Elements.Add(new Label("The Time Machine", 36, 36, 252, 30, Font.TimesBold, 30, TextAlign.Center));
            page.Elements.Add(new Label("by H. G. Wells", 36, 96, 252, 22, Font.TimesBold, 22, TextAlign.Center));
            page.Elements.Add(new Label("1895", 36, 148, 252, 22, Font.TimesBold, 22, TextAlign.Center));
            page.Elements.Add(new Image(Util.GetResourcePath("Images/DPDFLogo.png"), 62, 208, 0.21f));
            page.Elements.Add(new Label(generated, 132, 206, 182, 55, Font.TimesRoman, 11));
            page.Elements.Add(new Label(disclaimer, 36, 274, 252, 66, Font.TimesRoman, 11, TextAlign.Justify));
            page.Elements.Add(new Ean13Sup5("201234567890", "90000", 82, 360));
            page.ApplyDocumentTemplate = false;
            document.Pages.Add(page);
        }

        public static void AddChapter(Document document, string filePath, string title, string bookmarkText, Outline parentOutline)
        {
            // Retrieves the text from the sections file
            string sectionText = GetTextFromFile(filePath);

            // Adds the first page of the section
            Page page = AddSectionHeaderPage(title, bookmarkText, parentOutline);
            page.ApplyDocumentTemplate = false;

            // Creates a TextArea for the sections text
            TextArea textArea = new TextArea(sectionText, 0, 146, 324, 322, Font.TimesRoman, 11);
            textArea.Leading = 14;
            textArea.ParagraphSpacing = 20;
            page.Elements.Add(textArea);
            document.Pages.Add(page);

            // Creates a TextArea for the overflow text
            textArea = textArea.GetOverflowTextArea(0, 0, 324, 468);

            // Loops until no overflow text is found.
            while (textArea != null)
            {
                // Adds a new page to the document
                page = new Page(396, 540, 36);
                page.Elements.Add(textArea);

                // Adds new page to the document
                document.Pages.Add(page);

                // Creates a TextArea for the overflow text
                textArea = textArea.GetOverflowTextArea();
            }
        }

        public static Page AddSectionHeaderPage(string title, string bookmarkText, Outline parentOutline)
        {
            // Adds the first page of a section to the document
            Page page = new Page(396, 540, 36);

            // Uncomment the line below to add a layout grid to the section header pages
            //page.Elements.Add( new LayoutGrid() );

            page.Elements.Add(new Bookmark(bookmarkText, 0, 0, parentOutline));
            page.Elements.Add(new Label("The Time Machine", 0, 36, 324, 30, Font.TimesBold, 30, TextAlign.Center));
            page.Elements.Add(new Label(title, 0, 96, 324, 22, Font.TimesBold, 22, TextAlign.Center));
            page.Elements.Add(new Line(120, 128, 204, 128));
            PageNumberingLabel pageNumberLabel = new PageNumberingLabel("- %%CP%% -", 0, 478, 324, 11, Font.TimesRoman, 11, TextAlign.Center);
            pageNumberLabel.PageOffset = -1;
            page.Elements.Add(pageNumberLabel);
            return page;
        }

        public static string GetTextFromFile(string filePath)
        {
            // Opens a text file and returns the text from it.
            StreamReader textFile = File.OpenText(filePath);
            string sectionText = textFile.ReadToEnd();
            textFile.Close();
            return sectionText;
        }
    }
}
