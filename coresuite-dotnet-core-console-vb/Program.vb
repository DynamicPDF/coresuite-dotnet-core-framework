Imports System.IO

Module Program

    Sub Main()
        DisplayProducts()
    End Sub

    Private Sub DisplayProducts()
        While (True)
            Console.WriteLine("Welcome to the DynamicPDF Core Suite (Generator, Merger and ReportWriter) for .NET Examples")
            Console.WriteLine()
            Console.WriteLine("Select a product below to run its examples:")
            Console.WriteLine(" A : Generator")
            Console.WriteLine("     Examples for generating PDF documents and reports from scratch.")
            Console.WriteLine(" B : Merger")
            Console.WriteLine("     Examples for workign with existing PDF documents.")
            Console.WriteLine(" C : ReportWriter")
            Console.WriteLine("     Examples for creating PDF reports from DLEX template files.")
            Console.WriteLine()
            Console.WriteLine("Press 'Esc' to exit the application")
            Console.WriteLine()

            Dim runKey As ConsoleKeyInfo = Console.ReadKey()
            Console.WriteLine()
            Console.WriteLine()

            Select Case (runKey.Key)
                Case ConsoleKey.A
                    DisplayGeneratorExamples()
                Case ConsoleKey.B
                    DisplayMergerExamples()
                Case ConsoleKey.C
                    DisplayReportWriterExamples()
                Case ConsoleKey.Escape
                    System.Environment.Exit(0)
                Case Else
                    Console.WriteLine("Key not recognized.")
            End Select
        End While
    End Sub

    Private Sub DisplayGeneratorExamples()

        Dim exitToProducts As Boolean = False
        While (exitToProducts = False)
            Console.WriteLine("Select a DynamicPDF Generator for .NET example to run:")
            Console.WriteLine(" A : Hello World")
            Console.WriteLine(" B : All Page Elements")
            Console.WriteLine(" C : Calender")
            Console.WriteLine(" D : Charting")
            Console.WriteLine(" E : Contact List")
            Console.WriteLine(" F : AES 256 Bit Encryption")
            Console.WriteLine(" G : RC4 128 Bit Encryption")
            Console.WriteLine(" H : Hello World Languages")
            Console.WriteLine(" I : Tagged Pdf")
            Console.WriteLine(" J : HTML Tags")
            Console.WriteLine(" K : HTML Tags With Styles")
            Console.WriteLine(" L : HTML Layout")
            Console.WriteLine(" M : Image With Alternate Text")
            Console.WriteLine(" N : Mailing Labels")
            Console.WriteLine(" O : Package PDF")
            Console.WriteLine(" P : Simple Report")
            Console.WriteLine(" Q : Simple XML Report")
            Console.WriteLine(" R : Table Report")
            Console.WriteLine(" S : Tagged PDF With Structure Elements")
            Console.WriteLine(" T : Tiff To PDF")
            Console.WriteLine(" U : Time Machine")
            Console.WriteLine(" V : Time Machine Tagged PDF")
            Console.WriteLine(" W : Watermark")
            Console.WriteLine(" X : Invoice")
            Console.WriteLine(" Y : USEnvelope")
            Console.WriteLine()
            Console.WriteLine("Press 'Backspace' for the main products menu")
            Console.WriteLine("Press 'Esc' to exit application")
            Console.WriteLine()

            Dim runKey As ConsoleKeyInfo = Console.ReadKey()
            Console.WriteLine()
            Console.WriteLine()

            Dim exampleName As String = String.Empty
            Dim fileName As String = String.Empty
            Select Case (runKey.Key)
                Case ConsoleKey.A
                    exampleName = "Hello World"
                    fileName = "HelloWorld.pdf"
                    Console.WriteLine("Example " + exampleName + " is Running...")
                    HelloWorld.Run(fileName)
                Case ConsoleKey.B
                    exampleName = "All Page Elements"
                    fileName = "AllPageElements.pdf"
                    Console.WriteLine("Example " + exampleName + " is Running...")
                    AllPageElements.Run(fileName)
                Case ConsoleKey.C
                    exampleName = "Calender"
                    fileName = "Calender.pdf"
                    Console.WriteLine("Example " + exampleName + " is Running...")
                    Calendar.Run(fileName)
                Case ConsoleKey.D
                    exampleName = "Charting"
                    fileName = "Charting.pdf"
                    Console.WriteLine("Example " + exampleName + " is Running...")
                    Charting.Run(fileName)
                Case ConsoleKey.E
                    exampleName = "Contact List"
                    fileName = "ContactList.pdf"
                    Console.WriteLine("Example " + exampleName + " is Running...")
                    ContactList.Run(fileName)
                Case ConsoleKey.F
                    exampleName = "AES 256 Bit Encryption"
                    fileName = "Aes256BitEncryption.pdf"
                    Console.WriteLine("Example " + exampleName + " is Running...")
                    Aes256BitEncryption.Run(fileName)
                Case ConsoleKey.G
                    exampleName = "RC4 128 Bit Encryption"
                    fileName = "RC4128BitEncryption.pdf"
                    Console.WriteLine("Example " + exampleName + " is Running...")
                    RC4128BitEncryption.Run(fileName)
                Case ConsoleKey.H
                    exampleName = "Hello World Languages"
                    fileName = "HelloWorldLanguages.pdf"
                    Console.WriteLine("Example " + exampleName + " is Running...")
                    HelloWorldLanguages.Run(fileName)
                Case ConsoleKey.I
                    exampleName = "Tagged PDF"
                    fileName = "TaggedPdf.pdf"
                    Console.WriteLine("Example " + exampleName + " is Running...")
                    TaggedPdf.Run(fileName)
                Case ConsoleKey.J
                    exampleName = "HTML Tags"
                    fileName = "HtmlTags.pdf"
                    Console.WriteLine("Example " + exampleName + " is Running...")
                    HtmlAreaPDF.Run_WithHtmlTags(fileName)
                Case ConsoleKey.K
                    exampleName = "HTML Tags With Styles"
                    fileName = "HtmlTagsWithStyles.pdf"
                    Console.WriteLine("Example " + exampleName + " is Running...")
                    HtmlAreaPDF.Run_WithHtmlTagsAndStyles(fileName)
                Case ConsoleKey.L
                    exampleName = "HTML Layout"
                    fileName = "HtmlLayout.pdf"
                    Console.WriteLine("Example " + exampleName + " is Running...")
                    HtmlLayoutPDF.Run(fileName)
                Case ConsoleKey.M
                    exampleName = "Image With Alternate Text"
                    fileName = "ImageWithAltText.pdf"
                    Console.WriteLine("Example " + exampleName + " is Running...")
                    AltTextImage.Run(fileName)
                Case ConsoleKey.N
                    exampleName = "Mailing Labels"
                    fileName = "MailingLabels.pdf"
                    Console.WriteLine("Example " + exampleName + " is Running...")
                    MailingLabels.Run(fileName)
                Case ConsoleKey.O
                    exampleName = "Package PDF"
                    fileName = "PackagePdf.pdf"
                    Console.WriteLine("Example " + exampleName + " is Running...")
                    PackagePdf.Run(fileName)
                Case ConsoleKey.P
                    exampleName = "Simple Report"
                    fileName = "SimpleReport.pdf"
                    Console.WriteLine("Example " + exampleName + " is Running...")
                    SimpleReport.Run(fileName)
                Case ConsoleKey.Q
                    exampleName = "Simple XML Report"
                    fileName = "SimpleXmlReport.pdf"
                    Console.WriteLine("Example " + exampleName + " is Running...")
                    SimpleXMLReport.Run(fileName)
                Case ConsoleKey.R
                    exampleName = "Table Report"
                    fileName = "TableReport.pdf"
                    Console.WriteLine("Example " + exampleName + " is Running...")
                    TableReport.Run(fileName)
                Case ConsoleKey.S
                    exampleName = "Tagged PDF With Structure Elements"
                    fileName = "TaggedPdfWithStructureElements.pdf"
                    Console.WriteLine("Example " + exampleName + " is Running...")
                    TaggedPdfWithStructureElements.Run(fileName)
                Case ConsoleKey.T
                    exampleName = "Tiff To PDF"
                    fileName = "TiffToPdf.pdf"
                    Console.WriteLine("Example " + exampleName + " is Running...")
                    TiffToPdf.Run(fileName)
                Case ConsoleKey.U
                    exampleName = "Time Machine"
                    fileName = "TimeMachine.pdf"
                    Console.WriteLine("Example " + exampleName + " is Running...")
                    TimeMachine.Run(fileName)
                Case ConsoleKey.V
                    exampleName = "Time Machine Tagged PDF"
                    fileName = "TimeMachineTaggedPdf.pdf"
                    Console.WriteLine("Example " + exampleName + " is Running...")
                    TimeMachineTaggedPdf.Run(fileName)
                Case ConsoleKey.W
                    exampleName = "Watermark"
                    fileName = "Watermark.pdf"
                    Console.WriteLine("Example " + exampleName + " is Running...")
                    Watermark.Run(fileName)
                Case ConsoleKey.X
                    exampleName = "Invoice"
                    fileName = "Invoice.pdf"
                    Console.WriteLine("Please Enter the invoice numbers (Comma ',' seperated for multiple entries, Ex: 10248,10249,10250).")
                    Console.WriteLine()
                    Console.WriteLine("10248")
                    Console.WriteLine("10249")
                    Console.WriteLine("10250")
                    Console.WriteLine("10251")
                    Console.WriteLine("10252")
                    Console.WriteLine("10360")
                    Console.WriteLine("10979")
                    Console.WriteLine("11077")
                    Console.WriteLine()

                    Dim invoiceNumbers As String = Console.ReadLine()

                    Console.WriteLine("Example " + exampleName + " is Running...")

                    Dim pdf() As Byte = GeneratorInvoice.Run(invoiceNumbers.Split(New Char() {","c}))
                    File.WriteAllBytes(fileName, pdf)
                Case ConsoleKey.Y
                    exampleName = "USEnvelope"
                    fileName = "USEnvelope.pdf"
                    Console.WriteLine("Example " + exampleName + " is Running...")
                    USEnvelope.Run(fileName)
                Case ConsoleKey.Escape
                    System.Environment.Exit(0)
                Case ConsoleKey.Backspace
                    exitToProducts = True
                Case Else
                    Console.WriteLine()
                    Console.WriteLine("Key not recognized.")
            End Select

            If (fileName IsNot String.Empty) Then
                DisplayOutputPathWithOptionToOpen(fileName)
            End If
        End While
    End Sub

    Private Sub DisplayMergerExamples()

        Dim exitToProducts As Boolean = False
        While (exitToProducts = False)
            Console.WriteLine("Select a DynamicPDF Merger for .NET example to run:")
            Console.WriteLine("     A : Field Level Flattening")
            Console.WriteLine("     B : Form Field Reader")
            Console.WriteLine("     C : Form Flattening")
            Console.WriteLine("     D : Merge PDFs")
            Console.WriteLine("     E : Place PDFs")
            Console.WriteLine("     F : Stamp PDF")
            Console.WriteLine("     G : Text Extraction")
            Console.WriteLine("     H : Select Pages")
            Console.WriteLine("     I : Merge Invoices")
            Console.WriteLine("     J : AcroFormFill")
            Console.WriteLine("     K : FormFill")
            Console.WriteLine()
            Console.WriteLine("Press 'Backspace' for the main products menu")
            Console.WriteLine("Press 'Esc' to exit application")
            Console.WriteLine()

            Dim runKey As ConsoleKeyInfo = Console.ReadKey()
            Console.WriteLine()
            Console.WriteLine()

            Dim exampleName As String = String.Empty
            Dim fileName As String = String.Empty
            Select Case (runKey.Key)
                Case ConsoleKey.A
                    exampleName = "Field Level Flattening"
                    fileName = "FieldLevelFlattening.pdf"
                    Console.WriteLine("Example " + exampleName + " is Running...")
                    FieldLevelFlattening.Run(fileName)
                Case ConsoleKey.B
                    exampleName = "Form Field Reader"
                    fileName = "FormFieldReader.pdf"
                    Console.WriteLine("Example " + exampleName + " is Running...")
                    FormFieldReader.Run(fileName)
                Case ConsoleKey.C
                    exampleName = "Form Flattening"
                    fileName = "FormFlattening.pdf"
                    Console.WriteLine("Example " + exampleName + " is Running...")
                    FormFlattening.Run(fileName)
                Case ConsoleKey.D
                    exampleName = "Merge PDFs"
                    fileName = "MergePDFs.pdf"
                    Console.WriteLine("Example " + exampleName + " is Running...")
                    MergePDFs.Run(fileName)
                Case ConsoleKey.E
                    exampleName = "Place PDFs"
                    fileName = "PlacePDFs.pdf"
                    Console.WriteLine("Example " + exampleName + " is Running...")
                    PlacePDFs.Run(fileName)
                Case ConsoleKey.F
                    exampleName = "Stamp PDF"
                    fileName = "StampPDF.pdf"
                    Console.WriteLine("Example " + exampleName + " is Running...")
                    StampPDF.Run(fileName)
                Case ConsoleKey.G
                    exampleName = "Text Extraction"
                    Console.WriteLine("Example " + exampleName + " is Running...")
                    Console.WriteLine()
                    Console.WriteLine(TextExtraction.Run())
                Case ConsoleKey.H
                    exampleName = "Select Pages"
                    fileName = "SelectPages.pdf"
                    Console.WriteLine("Select Pages to Merge from Document A")
                    Console.WriteLine(" A1: Page 1")
                    Console.WriteLine(" A2: Page 2")
                    Console.WriteLine(" A3: Page 3")
                    Console.WriteLine(" A4: Page 4")
                    Console.WriteLine()
                    Console.WriteLine("Select Pages to Merge from Document B")
                    Console.WriteLine(" B1: Page 1")
                    Console.WriteLine(" B2: Page 2")
                    Console.WriteLine(" B3: Page 3")
                    Console.WriteLine()
                    Console.WriteLine("Select Pages to Merge from Document C")
                    Console.WriteLine(" C1: Page 1")
                    Console.WriteLine(" C2: Page 2")
                    Console.WriteLine()
                    Console.WriteLine("Select Pages to Merge from Document D")
                    Console.WriteLine(" D1: Page 1")
                    Console.WriteLine(" D2: Page 2")
                    Console.WriteLine(" D3: Page 3")
                    Console.WriteLine(" D4: Page 4")
                    Console.WriteLine(" D5: Page 5")
                    Console.WriteLine(" D6: Page 6")
                    Console.WriteLine()
                    Console.WriteLine("Please enter the page number(s) to merge. Use a comma ',' to seperate multiple entries (Ex: A1,B2,D5):")
                    Console.WriteLine()

                    Dim selectedPages As String = Console.ReadLine().ToUpper()
                    Console.WriteLine("Example " + exampleName + " is Running...")

                    SelectPages.Run(selectedPages.Split(New Char() {","c}), fileName)
                Case ConsoleKey.I
                    exampleName = "Merge Invoices PDF"
                    fileName = "MergerInvoice.pdf"
                    Console.WriteLine("Please enter the invoice number(s) to include. Use a comma ',' to seperate multiple entries (Ex: 10248,10249,10250):")
                    Console.WriteLine()
                    Console.WriteLine("10248")
                    Console.WriteLine("10249")
                    Console.WriteLine("10250")
                    Console.WriteLine("10251")
                    Console.WriteLine("10252")
                    Console.WriteLine("10360")
                    Console.WriteLine("10979")
                    Console.WriteLine("11077")
                    Console.WriteLine()

                    Dim invoiceNumbers As String = Console.ReadLine()

                    Console.WriteLine("Example " + exampleName + " is Running...")

                    Dim pdf() As Byte = MergerInvoice.Run(invoiceNumbers.Split(New Char() {","c}))
                    File.WriteAllBytes(fileName, pdf)
                Case ConsoleKey.J
                    exampleName = "AcroFormFill"
                    fileName = "AcroFormFill.pdf"
                    Console.WriteLine("Example " + exampleName + " is Running...")
                    AcroFormFill.Run(fileName)
                Case ConsoleKey.K
                    exampleName = "FormFill"
                    fileName = "FormFill.pdf"
                    Console.WriteLine("Example " + exampleName + " is Running...")
                    FormFill.Run(fileName)
                Case ConsoleKey.Escape
                    System.Environment.Exit(0)
                Case ConsoleKey.Backspace
                    exitToProducts = True
                Case Else
                    Console.WriteLine()
                    Console.WriteLine("Key not recognized.")
            End Select

            If (fileName IsNot String.Empty) Then
                DisplayOutputPathWithOptionToOpen(fileName)
            End If
        End While
    End Sub

    Private Sub DisplayReportWriterExamples()

        Dim exitToProducts As Boolean = False
        While (exitToProducts = False)
            Console.WriteLine("Select a DynamicPDF ReportWriter for .NET example to run:")
            Console.WriteLine("     A : Contact List")
            Console.WriteLine("     B : Contact List With Group By")
            Console.WriteLine("     C : Form Fill")
            Console.WriteLine("     D : Form Letter")
            Console.WriteLine("     E : Invoice")
            Console.WriteLine("     F : Place Holder")
            Console.WriteLine("     G : Simple Sub Report")
            Console.WriteLine()
            Console.WriteLine("Press 'Backspace' for the main products menu")
            Console.WriteLine("Press 'Esc' to exit application")
            Console.WriteLine()

            Dim runKey As ConsoleKeyInfo = Console.ReadKey()
            Console.WriteLine()
            Console.WriteLine()

            Dim exampleName As String = String.Empty
            Dim fileName As String = String.Empty
            Select Case (runKey.Key)
                Case ConsoleKey.A
                    exampleName = "Contact List"
                    fileName = "ContactListReport.pdf"
                    Console.WriteLine("Example " + exampleName + " is Running...")
                    ContactListReport.Run(fileName)
                Case ConsoleKey.B
                    exampleName = "Contact List With Group By"
                    fileName = "ContactListWithGroupByReport.pdf"
                    Console.WriteLine("Example " + exampleName + " is Running...")
                    ContactListWithGroupByReport.Run(fileName)
                Case ConsoleKey.C
                    exampleName = "Form Fill"
                    fileName = "FormFillReport.pdf"
                    Console.WriteLine("Example " + exampleName + " is Running...")
                    FormFillReport.Run(fileName)
                Case ConsoleKey.D
                    exampleName = "Form Letter"
                    fileName = "FormLetterReport.pdf"
                    Console.WriteLine("Example " + exampleName + " is Running...")
                    FormLetterReport.Run(fileName)
                Case ConsoleKey.E
                    exampleName = "Invoice"
                    fileName = "InvoiceReport.pdf"
                    Console.WriteLine("Example " + exampleName + " is Running...")
                    InvoiceReport.Run(fileName)
                Case ConsoleKey.F
                    exampleName = "Place Holder"
                    fileName = "PlaceHolderReport.pdf"
                    Console.WriteLine("Example " + exampleName + " is Running...")
                    PlaceHolderReport.Run(fileName)
                Case ConsoleKey.G
                    exampleName = "Simple Sub Report"
                    fileName = "SimpleSubReport.pdf"
                    Console.WriteLine("Example " + exampleName + " is Running...")
                    SimpleSubReport.Run(fileName)
                Case ConsoleKey.Escape
                    System.Environment.Exit(0)
                Case ConsoleKey.Backspace
                    exitToProducts = True
                Case Else
                    Console.WriteLine()
                    Console.WriteLine("Key not recognized.")
            End Select

            If (fileName IsNot String.Empty) Then
                DisplayOutputPathWithOptionToOpen(fileName)
            End If
        End While
    End Sub

    Private Sub DisplayOutputPathWithOptionToOpen(fileName As String)
        Dim fullFileName As String = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase) + "\" + fileName
        Console.WriteLine()
        Console.WriteLine("The ouptut file was saved at:")
        Console.WriteLine(fullFileName)
        Console.WriteLine()
        Console.WriteLine("Press any key to continue.")
        Console.WriteLine()
        Dim key As ConsoleKeyInfo = Console.ReadKey()
        Console.WriteLine()
    End Sub
End Module