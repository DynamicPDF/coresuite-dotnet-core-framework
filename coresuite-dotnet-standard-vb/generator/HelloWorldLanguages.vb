Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements
Imports ceTe.DynamicPDF.Text

Namespace coresuite_dotnet_standard_vb.generator
    Public Class HelloWorldLanguages
        Public Shared Sub Run(outputPdfPath As String)
            ' Create a document and set it's properties
            Dim MyDocument As Document = New Document With {
                .Creator = "HelloWorldLanguages.aspx",
                .Author = "ceTe Software",
                .Title = "Hello World Languages"
            }

            Dim JapansesFont As Font = Font.HeiseiKakuGothicW5
            Dim KoreanFont As Font = Font.HanyangSystemsGothicMedium
            Dim ChineseSimplifiedFont As Font = Font.SinoTypeSongLight
            Dim ChineseTraditionalFont As Font = Font.MonotypeHeiMedium
            Dim Latin1Font As Font = Font.TimesRoman
            Dim UnicodeFont As Font = New OpenTypeFont("times.ttf")

            Dim unicodeFont1 As Font = New OpenTypeFont("micross.ttf", True)
            Dim InFont As Font = New OpenTypeFont("Nirmala.ttf", True)

            ' Create a page to add to the document
            Dim MyPage As Page = New Page(PageSize.Letter, PageOrientation.Portrait, 54.0F)
            Dim MyPage1 As Page = New Page(PageSize.Letter, PageOrientation.Portrait, 54.0F)

            ' Uncomment the line below to add a layout grid to the page
            'MyPage.Elements.Add( new LayoutGrid() );

            ' Add label to page
            AddLanguage(MyPage, 1, 1, "Dutch:", "De hallo Wereld", Latin1Font)
            AddLanguage(MyPage, 2, 1, "English:", "Hello World", Latin1Font)
            AddLanguage(MyPage, 1, 2, "French:", "Bonjour le Monded", Latin1Font)
            AddLanguage(MyPage, 2, 2, "German:", "Hallo Welt", Latin1Font)
            AddLanguage(MyPage, 1, 3, "Greek:", "Γειάσου κόσμος", UnicodeFont)
            AddLanguage(MyPage, 2, 3, "Italian:", "Ciao il Mondo", Latin1Font)
            AddLanguage(MyPage, 1, 4, "Japanese:", "こんにちは世界", JapansesFont)
            AddLanguage(MyPage, 2, 4, "Korean:", "여보세요 세계", KoreanFont)
            AddLanguage(MyPage, 1, 5, "Norwegian:", "Hei Verden", Latin1Font)
            AddLanguage(MyPage, 2, 5, "Portuguese:", "Oi Mundo", Latin1Font)
            AddLanguage(MyPage, 1, 6, "Russian:", "Привет Мир", UnicodeFont)
            AddLanguage(MyPage, 2, 6, "Simplified Chinese:", "你好世界", ChineseSimplifiedFont)
            AddLanguage(MyPage, 1, 7, "Spanish:", "Hola Mundo", Latin1Font)
            AddLanguage(MyPage, 2, 7, "Traditional Chinese:", "你好世界", ChineseTraditionalFont)

            AddLanguage(MyPage1, 1, 1, "Arabic:", "مرحبا", unicodeFont1)
            AddLanguage(MyPage1, 2, 1, "Hebrew:", "שלום", unicodeFont1)
            AddLanguage(MyPage1, 1, 2, "Thai:", "สวัสดี", unicodeFont1)
            AddLanguage(MyPage1, 2, 2, "Hindi:", "नमस्ते", InFont)
            AddLanguage(MyPage1, 1, 3, "Bangla:", "স্বাগত", InFont)
            AddLanguage(MyPage1, 2, 3, "Tamil:", "வணக்கம்", InFont)

            ' Add page to document
            MyDocument.Pages.Add(MyPage)
            MyDocument.Pages.Add(MyPage1)

            ' Outputs the document to the current web page
            MyDocument.Draw(outputPdfPath)
        End Sub

        Public Shared Sub AddLanguage(ByVal MyPage As Page, ByVal Column As Integer, ByVal Row As Integer, ByVal Language As String, ByVal Text As String, ByVal Font As Font)
            Dim Padding As Single = 12
            Dim RowMultiple As Single = (MyPage.Dimensions.Body.Height + Padding) / 7
            Dim ColumnMultiple As Single = (MyPage.Dimensions.Body.Width + Padding) / 2
            Dim RowHeight As Single = RowMultiple - Padding
            Dim ColumnWidth As Single = ColumnMultiple - Padding
            Dim XOffset As Single = (Column - 1) * ColumnMultiple
            Dim YOffset As Single = (Row - 1) * RowMultiple
            MyPage.Elements.Add(New Label(Language, XOffset, YOffset, ColumnWidth, 12, Font.Helvetica, 12))
            MyPage.Elements.Add(New Rectangle(XOffset, YOffset + 16, ColumnWidth, RowHeight - 16, Grayscale.Black, RgbColor.Lavender, 1.0F))
            Dim MyLabel As Label = New Label(Text, XOffset + 4, YOffset + 18, ColumnWidth - 8, RowHeight - 20, Font, 24, TextAlign.Center)
            MyLabel.VAlign = VAlign.Center
            MyPage.Elements.Add(MyLabel)
        End Sub
    End Class
End Namespace