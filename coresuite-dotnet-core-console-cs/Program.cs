 using coresuite_dotnet_core_console_cs.generator;
using coresuite_dotnet_core_console_cs.merger;
using coresuite_dotnet_core_console_cs.reportwriter;
using System;
using System.IO;

namespace coresuite_dotnet_core_console_cs
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayProducts();
        }

        private static void DisplayProducts()
        {
            while (true)
            {
                Console.WriteLine("Welcome to the DynamicPDF Core Suite (Generator, Merger and ReportWriter) for .NET Examples");
                Console.WriteLine();
                Console.WriteLine("Select a product below to run its examples:");
                Console.WriteLine(" A : Generator");
                Console.WriteLine("     Examples for generating PDF documents and reports from scratch.");
                Console.WriteLine(" B : Merger");
                Console.WriteLine("     Examples for workign with existing PDF documents.");
                Console.WriteLine(" C : ReportWriter");
                Console.WriteLine("     Examples for creating PDF reports from DLEX template files.");
                Console.WriteLine();
                Console.WriteLine("Press 'Esc' to exit the application");
                Console.WriteLine();

                ConsoleKeyInfo runKey = Console.ReadKey();
                Console.WriteLine();
                Console.WriteLine();

                switch (runKey.Key)
                {
                    case ConsoleKey.A:
                        DisplayGeneratorExamples();
                        break;
                    case ConsoleKey.B:
                        DisplayMergerExamples();
                        break;
                    case ConsoleKey.C:
                        DisplayReportWriterExamples();
                        break;
                    case ConsoleKey.Escape:
                        System.Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Key not recognized.");
                        break;
                }
            }
        }

        private static void DisplayGeneratorExamples()
        {
            bool exitToProducts = false;
            while (!exitToProducts)
            {
                Console.WriteLine("Select a DynamicPDF Generator for .NET example to run:");
                Console.WriteLine(" A : Hello World");
                Console.WriteLine(" B : All Page Elements");
                Console.WriteLine(" C : Calender");
                Console.WriteLine(" D : Charting");
                Console.WriteLine(" E : Contact List");
                Console.WriteLine(" F : AES 256 Bit Encryption");
                Console.WriteLine(" G : RC4 128 Bit Encryption");
                Console.WriteLine(" H : Hello World Languages");
                Console.WriteLine(" I : Tagged Pdf");
                Console.WriteLine(" J : HTML Tags");
                Console.WriteLine(" K : HTML Tags With Styles");
                Console.WriteLine(" L : HTML Layout");
                Console.WriteLine(" M : Image With Alternate Text");
                Console.WriteLine(" N : Mailing Labels");
                Console.WriteLine(" O : Package PDF");
                Console.WriteLine(" P : Simple Report");
                Console.WriteLine(" Q : Simple XML Report");
                Console.WriteLine(" R : Table Report");
                Console.WriteLine(" S : Tagged PDF With Structure Elements");
                Console.WriteLine(" T : Tiff To PDF");
                Console.WriteLine(" U : Time Machine");
                Console.WriteLine(" V : Time Machine Tagged PDF");
                Console.WriteLine(" W : Watermark");
                Console.WriteLine(" X : Invoice");               
                Console.WriteLine(" Y : USEnvelope");
                Console.WriteLine();
                Console.WriteLine("Press 'Backspace' for the main products menu");
                Console.WriteLine("Press 'Esc' to exit application");
                Console.WriteLine();
                ConsoleKeyInfo runKey = Console.ReadKey();
                Console.WriteLine();

                string exampleName = string.Empty;
                string fileName = string.Empty;
                switch (runKey.Key)
                {
                    case ConsoleKey.A:
                        exampleName = "Hello World";
                        fileName = "HelloWorld.pdf";
                        Console.WriteLine(exampleName + " example is running...");
                        HelloWorld.Run(fileName);
                        break;
                    case ConsoleKey.B:
                        exampleName = "All Page Elements";
                        fileName = "AllPageElements.pdf";
                        Console.WriteLine(exampleName + " example is running...");
                        AllPageElements.Run(fileName);
                        break;
                    case ConsoleKey.C:
                        exampleName = "Calender";
                        fileName = "Calender.pdf";
                        Console.WriteLine(exampleName + " example is running...");
                        Calender.Run(fileName);
                        break;
                    case ConsoleKey.D:
                        exampleName = "Charting";
                        fileName = "Charting.pdf";
                        Console.WriteLine(exampleName + " example is running...");
                        Charting.Run(fileName);
                        break;
                    case ConsoleKey.E:
                        exampleName = "Contact List";
                        fileName = "ContactList.pdf";
                        Console.WriteLine(exampleName + " example is running...");
                        ContactList.Run(fileName);
                        break;
                    case ConsoleKey.F:
                        Console.Clear();
                        exampleName = "AES 256 Bit Encryption";
                        fileName = "Aes256BitEncryption.pdf";
                        Console.WriteLine(exampleName + " example is running...");
                        Aes256BitEncryption.Run(fileName);
                        break;
                    case ConsoleKey.G:
                        exampleName = "RC4 128 Bit Encryption";
                        fileName = "RC4128BitEncryption.pdf";
                        Console.WriteLine(exampleName + " example is running...");
                        RC4128BitEncryption.Run(fileName);
                        break;
                    case ConsoleKey.H:
                        exampleName = "Hello World Languages";
                        fileName = "HelloWorldLanguages.pdf";
                        Console.WriteLine(exampleName + " example is running...");
                        HelloWorldLanguages.Run(fileName);
                        break;
                    case ConsoleKey.I:
                        exampleName = "Tagged PDF";
                        fileName = "TaggedPdf.pdf";
                        Console.WriteLine(exampleName + " example is running...");
                        TaggedPdf.Run(fileName);
                        break;
                    case ConsoleKey.J:
                        exampleName = "HTML Tags";
                        fileName = "HtmlTags.pdf";
                        Console.WriteLine(exampleName + " example is running...");
                        HtmlAreaPDF.Run_WithHtmlTags(fileName);
                        break;
                    case ConsoleKey.K:
                        exampleName = "HTML Tags With Styles";
                        fileName = "HtmlTagsWithStyles.pdf";
                        Console.WriteLine(exampleName + " example is running...");
                        HtmlAreaPDF.Run_WithHtmlTagsAndStyles(fileName);
                        break;
                    case ConsoleKey.L:
                        exampleName = "HTML Layout";
                        fileName = "HtmlLayout.pdf";
                        Console.WriteLine(exampleName + " example is running...");
                        HtmlLayoutPDF.Run(fileName);
                        break;
                    case ConsoleKey.M:
                        exampleName = "Image With Alternate Text";
                        fileName = "ImageWithAltText.pdf";
                        Console.WriteLine(exampleName + " example is running...");
                        AltTextImage.Run(fileName);
                        break;
                    case ConsoleKey.N:
                        exampleName = "Mailing Labels";
                        fileName = "MailingLabels.pdf";
                        Console.WriteLine(exampleName + " example is running...");
                        MailingLabels.Run(fileName);
                        break;
                    case ConsoleKey.O:
                        exampleName = "Package PDF";
                        fileName = "PackagePdf.pdf";
                        Console.WriteLine(exampleName + " example is running...");
                        PackagePdf.Run(fileName);
                        break;
                    case ConsoleKey.P:
                        exampleName = "Simple Report";
                        fileName = "SimpleReport.pdf";
                        Console.WriteLine(exampleName + " example is running...");
                        SimpleReport.Run(fileName);
                        break;
                    case ConsoleKey.Q:
                        exampleName = "Simple XML Report";
                        fileName = "SimpleXmlReport.pdf";
                        Console.WriteLine(exampleName + " example is running...");
                        SimpleXMLReport.Run(fileName);
                        break;
                    case ConsoleKey.R:
                        exampleName = "Table Report";
                        fileName = "TableReport.pdf";
                        Console.WriteLine(exampleName + " example is running...");
                        TableReport.Run(fileName);
                        break;
                    case ConsoleKey.S:
                        exampleName = "Tagged PDF With Structure Elements";
                        fileName = "TaggedPdfWithStructureElements.pdf";
                        Console.WriteLine(exampleName + " example is running...");
                        TaggedPdfWithStructureElements.Run(fileName);
                        break;
                    case ConsoleKey.T:
                        exampleName = "Tiff To PDF";
                        fileName = "TiffToPdf.pdf";
                        Console.WriteLine(exampleName + " example is running...");
                        TiffToPdf.Run(fileName);
                        break;
                    case ConsoleKey.U:
                        exampleName = "Time Machine";
                        fileName = "TimeMachine.pdf";
                        Console.WriteLine(exampleName + " example is running...");
                        TimeMachine.Run(fileName);
                        break;
                    case ConsoleKey.V:
                        exampleName = "Time Machine Tagged PDF";
                        fileName = "TimeMachineTaggedPdf.pdf";
                        Console.WriteLine(exampleName + " example is running...");
                        TimeMachineTaggedPdf.Run(fileName);
                        break;
                    case ConsoleKey.W:
                        exampleName = "Watermark";
                        fileName = "Watermark.pdf";
                        Console.WriteLine(exampleName + " example is running...");
                        Watermark.Run(fileName);
                        break;
                    case ConsoleKey.X:
                        exampleName = "Invoice";
                        fileName = "Invoice.pdf";
                        Console.WriteLine("Please enter the invoice number(s) to include. Use a comma ',' to seperate multiple entries (Ex: 10248,10249,10250):");
                        Console.WriteLine();
                        Console.WriteLine("10248");
                        Console.WriteLine("10249");
                        Console.WriteLine("10250");
                        Console.WriteLine("10251");
                        Console.WriteLine("10252");
                        Console.WriteLine("10360");
                        Console.WriteLine("10979");
                        Console.WriteLine("11077");
                        Console.WriteLine();
                        string invoiceNumbers = Console.ReadLine();
                        Console.WriteLine(exampleName + " example is running...");
                        byte[] pdf = GeneratorInvoice.Run(invoiceNumbers.Split(','));
                        File.WriteAllBytes(fileName, pdf);
                        break;                  
                    case ConsoleKey.Y:
                        exampleName = "USEnvelope";
                        fileName = "USEnvelope.pdf";
                        Console.WriteLine(exampleName + " example is running...");
                        USEnvelope.Run(fileName);
                        break;
                    case ConsoleKey.Escape:
                        System.Environment.Exit(0);
                        break;
                    case ConsoleKey.Backspace:
                        exitToProducts = true;
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Key not recognized.");
                        break;
                }
                if (fileName != string.Empty)
                {
                    DisplayOutputPathWithOptionToOpen(fileName);
                }
            }
        }

        private static void DisplayMergerExamples()
        {
            bool exitToProducts = false;
            while (!exitToProducts)
            {
                Console.WriteLine("Select a DynamicPDF Merger for .NET example to run:");
                Console.WriteLine("     A : Field Level Flattening");
                Console.WriteLine("     B : Form Field Reader");
                Console.WriteLine("     C : Form Flattening");
                Console.WriteLine("     D : Merge PDFs");
                Console.WriteLine("     E : Place PDFs");
                Console.WriteLine("     F : Stamp PDF");
                Console.WriteLine("     G : Text Extraction");
                Console.WriteLine("     H : Select Pages");
                Console.WriteLine("     I : Merge Invoices");
                Console.WriteLine("     J : AcroForm Fill");
                Console.WriteLine("     K : Form Fill");
                Console.WriteLine();
                Console.WriteLine("Press 'Backspace' for the main products menu");
                Console.WriteLine("Press 'Esc' to exit application");
                Console.WriteLine();

                ConsoleKeyInfo runKey = Console.ReadKey();
                Console.WriteLine();
                Console.WriteLine();

                string exampleName = string.Empty;
                string fileName = string.Empty;
                switch (runKey.Key)
                {
                    case ConsoleKey.A:
                        exampleName = "Field Level Flattening";
                        fileName = "FieldLevelFlattening.pdf";
                        Console.WriteLine("Example " + exampleName + " is Running...");
                        FieldLevelFlattening.Run(fileName);
                        break;
                    case ConsoleKey.B:
                        exampleName = "Form Field Reader";
                        fileName = "FormFieldReader.pdf";
                        Console.WriteLine("Example " + exampleName + " is Running...");
                        FormFieldReader.Run(fileName);
                        break;
                    case ConsoleKey.C:
                        exampleName = "Form Flattening";
                        fileName = "FormFlattening.pdf";
                        Console.WriteLine("Example " + exampleName + " is Running...");
                        FormFlattening.Run(fileName);
                        break;
                    case ConsoleKey.D:
                        exampleName = "Merge PDFs";
                        fileName = "MergePDFs.pdf";
                        Console.WriteLine("Example " + exampleName + " is Running...");
                        MergePDFs.Run(fileName);
                        break;
                    case ConsoleKey.E:
                        exampleName = "Place PDFs";
                        fileName = "PlacePDFs.pdf";
                        Console.WriteLine("Example " + exampleName + " is Running...");
                        PlacePDFs.Run(fileName);
                        break;
                    case ConsoleKey.F:
                        exampleName = "Stamp PDF";
                        fileName = "StampPDF.pdf";
                        Console.WriteLine("Example " + exampleName + " is Running...");
                        StampPDF.Run(fileName);
                        break;
                    case ConsoleKey.G:
                        exampleName = "Text Extraction";
                        Console.WriteLine("Example " + exampleName + " is Running...");
                        Console.WriteLine();
                        Console.WriteLine(TextExtraction.Run());
                        break;
                    case ConsoleKey.H:
                        exampleName = "Select Pages";
                        fileName = "SelectPages.pdf";
                        Console.WriteLine("Select Pages to Merge from Document A");
                        Console.WriteLine(" A1: Page 1");
                        Console.WriteLine(" A2: Page 2");
                        Console.WriteLine(" A3: Page 3");
                        Console.WriteLine(" A4: Page 4");
                        Console.WriteLine();
                        Console.WriteLine("Select Pages to Merge from Document B");
                        Console.WriteLine(" B1: Page 1");
                        Console.WriteLine(" B2: Page 2");
                        Console.WriteLine(" B3: Page 3");
                        Console.WriteLine();
                        Console.WriteLine("Select Pages to Merge from Document C");
                        Console.WriteLine(" C1: Page 1");
                        Console.WriteLine(" C2: Page 2");
                        Console.WriteLine();
                        Console.WriteLine("Select Pages to Merge from Document D");
                        Console.WriteLine(" D1: Page 1");
                        Console.WriteLine(" D2: Page 2");
                        Console.WriteLine(" D3: Page 3");
                        Console.WriteLine(" D4: Page 4");
                        Console.WriteLine(" D5: Page 5");
                        Console.WriteLine(" D6: Page 6");
                        Console.WriteLine();
                        Console.WriteLine("Please enter the page number(s) to merge. Use a comma ',' to seperate multiple entries (Ex: A1,B2,D5):");
                        Console.WriteLine();

                        string selectedPages = Console.ReadLine().ToUpper();
                        Console.WriteLine("Example " + exampleName + " is Running...");

                        SelectPages.Run(selectedPages.Split(','), fileName);
                        break;
                    case ConsoleKey.I:
                        exampleName = "Merge Invoices PDF";
                        fileName = "MergerInvoice.pdf";
                        Console.WriteLine("Please enter the invoice number(s) to include. Use a comma ',' to seperate multiple entries (Ex: 10248,10249,10250):");
                        Console.WriteLine();
                        Console.WriteLine("10248");
                        Console.WriteLine("10249");
                        Console.WriteLine("10250");
                        Console.WriteLine("10251");
                        Console.WriteLine("10252");
                        Console.WriteLine("10360");
                        Console.WriteLine("10979");
                        Console.WriteLine("11077");
                        Console.WriteLine();

                        string invoiceNumbers = Console.ReadLine();

                        Console.WriteLine("Example " + exampleName + " is Running...");

                        byte[] pdf = MergerInvoice.Run(invoiceNumbers.Split(','));
                        File.WriteAllBytes(fileName, pdf);
                        break;
                    case ConsoleKey.J:
                        exampleName = "AcroForm Fill";
                        fileName = "AcroFormFill.pdf";
                        Console.WriteLine("Example " + exampleName + " is Running...");
                        AcroFormFill.Run(fileName);
                        break;
                    case ConsoleKey.K:
                        exampleName = "Form Fill";
                        fileName = "FormFill.pdf";
                        Console.WriteLine("Example " + exampleName + " is Running...");
                        FormFill.Run(fileName);
                        break;
                    case ConsoleKey.Escape:
                        System.Environment.Exit(0);
                        break;
                    case ConsoleKey.Backspace:
                        exitToProducts = true;
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Key not recognized.");
                        break;
                }

                if (fileName != string.Empty)
                {
                    DisplayOutputPathWithOptionToOpen(fileName);
                }
            }
        }

        private static void DisplayReportWriterExamples()
        {
            bool exitToProducts = false;
            while (!exitToProducts)
            {
                Console.WriteLine("Select a DynamicPDF ReportWriter for .NET example to run:");
                Console.WriteLine("     A : Contact List");
                Console.WriteLine("     B : Contact List With Group By");
                Console.WriteLine("     C : Form Fill");
                Console.WriteLine("     D : Form Letter");
                Console.WriteLine("     E : Invoice");
                Console.WriteLine("     F : Place Holder");
                Console.WriteLine("     G : Simple Sub Report");
                Console.WriteLine();
                Console.WriteLine("Press 'Backspace' for the main products menu");
                Console.WriteLine("Press 'Esc' to exit application");
                Console.WriteLine();

                ConsoleKeyInfo runKey = Console.ReadKey();
                Console.WriteLine();
                Console.WriteLine();

                string exampleName = "";
                string fileName = "";
                switch (runKey.Key)
                {
                    case ConsoleKey.A:
                        exampleName = "Contact List";
                        fileName = "ContactListReport.pdf";
                        Console.WriteLine("Example " + exampleName + " is Running...");
                        ContactListReport.Run(fileName);
                        break;
                    case ConsoleKey.B:
                        exampleName = "Contact List With Group By";
                        fileName = "ContactListWithGroupByReport.pdf";
                        Console.WriteLine("Example " + exampleName + " is Running...");
                        ContactListWithGroupByReport.Run(fileName);
                        break;
                    case ConsoleKey.C:
                        exampleName = "Form Fill";
                        fileName = "FormFillReport.pdf";
                        Console.WriteLine("Example " + exampleName + " is Running...");
                        FormFillReport.Run(fileName);
                        break;
                    case ConsoleKey.D:
                        exampleName = "Form Letter";
                        fileName = "FormLetterReport.pdf";
                        Console.WriteLine("Example " + exampleName + " is Running...");
                        FormLetterReport.Run(fileName);
                        break;
                    case ConsoleKey.E:
                        exampleName = "Invoice";
                        fileName = "InvoiceReport.pdf";
                        Console.WriteLine("Example " + exampleName + " is Running...");
                        InvoiceReport.Run(fileName);
                        break;
                    case ConsoleKey.F:
                        exampleName = "Place Holder";
                        fileName = "PlaceHolderReport.pdf";
                        Console.WriteLine("Example " + exampleName + " is Running...");
                        PlaceHolderReport.Run(fileName);
                        break;
                    case ConsoleKey.G:
                        exampleName = "Simple Sub Report";
                        fileName = "SimpleSubReport.pdf";
                        Console.WriteLine("Example " + exampleName + " is Running...");
                        SimpleSubReport.Run(fileName);
                        break;
                    case ConsoleKey.Escape:
                        System.Environment.Exit(0);
                        break;
                    case ConsoleKey.Backspace:
                        exitToProducts = true;
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Key not recognized.");
                        break;
                }

                if (fileName != string.Empty)
                {
                    DisplayOutputPathWithOptionToOpen(fileName);
                }
            }
        }

        private static void DisplayOutputPathWithOptionToOpen(string fileName)
        {
            string fullFileName = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase) + @"\" + fileName;
            Console.WriteLine();
            Console.WriteLine("The ouptut file was saved at:");
            Console.WriteLine(fullFileName);
            Console.WriteLine();
            Console.WriteLine("Press any key to continue.");
            Console.WriteLine();
            ConsoleKeyInfo key = Console.ReadKey();
            Console.WriteLine();
        }
    }
}