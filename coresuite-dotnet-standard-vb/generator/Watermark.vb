Imports System.IO
Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements

Namespace coresuite_dotnet_standard_vb.generator
    Public Class Watermark

        ' Templates for watermark elements
        Public Shared template As Template = New Template()

        Public Shared Sub Run(outputPdfPath As String)
            ' Create a document and set it's properties
            Dim Mydocument As Document = New Document With {
                .Creator = "Watermark.aspx",
                .Author = "cete software",
                .Title = "Watermark",
                .Template = template,
                .PdfVersion = PdfVersion.v1_6
            }

            ' Adds elements to the template
            SetPageTemplate()

            ' Adds Chapters to the document
            AddChapter(Mydocument, Util.GetResourcePath("Text/TimeMachine_Chapter1.txt"), "1", "Chapter 1")

            ' Outputs the document to the current web page
            Mydocument.Draw(outputPdfPath)
        End Sub

        Public Shared Sub SetPageTemplate()
            ' Uncomment the line below to add a layout grid to the title header page
            ' headerTemplate.Elements.Add( new LayoutGrid() );

            ' Create Text watermark
            Dim textWatermark As TextWatermark = New TextWatermark("Draft")
            textWatermark.TextOutlineColor = textWatermark.TextColor
            textWatermark.TextColor = Nothing

            ' Add Text watermark to the template
            template.Elements.Add(textWatermark)

            'uncomment the below lines to add image watermark
            '' Create Image watermark
            'Dim imageWatermark As ImageWatermark = New ImageWatermark(Server.MapPath("../Images/DPDFLogo.png"))

            '' Add Text watermark to the template
            'template.Elements.Add(imageWatermark)
        End Sub

        Public Shared Sub AddChapter(ByVal MyDocument As Document, ByVal filePath As String, ByVal title As String, ByVal bookmarkText As String)
            ' Retrieves the text from the sections file
            Dim sectionText As String = GetTextFromFile(filePath)

            ' Adds the first page of the section
            Dim Mypage As Page = AddSectionHeaderPage(title, bookmarkText)

            ' Creates a TextArea for the sections text
            Dim textArea As TextArea = New TextArea(sectionText, 0, 146, 324, 322, Font.TimesRoman, 11)
            textArea.Leading = 14
            textArea.ParagraphSpacing = 20
            Mypage.Elements.Add(textArea)
            MyDocument.Pages.Add(Mypage)

            ' Creates a TextArea for the overflow text
            textArea = textArea.GetOverflowTextArea(0, 0, 324, 468)

            ' Loops for 3 pages.
            Dim i As Integer
            For i = 0 To 3 Step i + 1
                ' Adds a new page to the document
                Mypage = New Page(396, 540, 36)
                Mypage.Elements.Add(textArea)

                ' Adds new page to the document
                MyDocument.Pages.Add(Mypage)

                ' Creates a TextArea for the overflow text
                textArea = textArea.GetOverflowTextArea()
            Next
        End Sub

        Public Shared Function GetTextFromFile(ByVal filePath As String) As String
            'Opens a text file and returns the text from it.
            Dim textFile As StreamReader = File.OpenText(filePath)
            Dim sectionText As String = textFile.ReadToEnd()
            textFile.Close()
            Return sectionText
        End Function

        Public Shared Function AddSectionHeaderPage(ByVal title As String, ByVal bookmarkText As String) As Page
            ' Adds the first page of a section to the document
            Dim Mypage As Page = New Page(396, 540, 36)

            ' Uncomment the line below to add a layout grid to the section header pages
            ' page.Elements.Add( new LayoutGrid() );

            Mypage.Elements.Add(New Label("The Time Machine", 0, 36, 324, 30, Font.TimesBold, 30, TextAlign.Center))
            Mypage.Elements.Add(New Label(title, 0, 96, 324, 22, Font.TimesBold, 22, TextAlign.Center))
            Mypage.Elements.Add(New Line(120, 128, 204, 128))

            Return Mypage
        End Function
    End Class
End Namespace