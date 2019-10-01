Imports System.Text
Imports System.IO
Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.IO
Imports ceTe.DynamicPDF.PageElements
Imports ceTe.DynamicPDF.PageElements.Forms
Imports ceTe.DynamicPDF.PageElements.BarCoding
Imports ceTe.DynamicPDF.PageElements.Charting
Imports ceTe.DynamicPDF.PageElements.Charting.Axes
Imports ceTe.DynamicPDF.PageElements.Charting.Series
Imports ceTe.DynamicPDF.PageElements.Html

Namespace coresuite_dotnet_standard_vb.generator

    Public Class AllPageElements

        Private Shared pageCounter As Integer = 0

        Public Class StopSign
            Inherits PageElement

            Private X As Single = 0.0F
            Private Y As Single = 0.0F
            Private w As Single = 0.0F
            Private H As Single = 0.0F

            'Initilizes a new instance of the StopSign class.
            Public Sub New(ByVal X As Single, ByVal Y As Single, ByVal Width As Single, ByVal Height As Single)
                Me.X = X
                Me.Y = Y
                w = Width
                H = Height
            End Sub

            ' Overriden. Draws a MyPageElement page element to the page.
            Public NotOverridable Overrides Sub Draw(ByVal Writer As PageWriter)
                Dim v As Single = H / 3.414

                ' End text mode
                Writer.Write_ET()
                Writer.Write_m_(X + v, Y)
                Writer.Write_RG(RgbColor.White)
                Writer.Write_rg_(RgbColor.Red)

                ' Draws the axis lines to the page
                Writer.Write_l_(X + H - v, Y)
                Writer.Write_l_(X + H, Y + v)
                Writer.Write_l_(X + H, Y + H - v)
                Writer.Write_l_(X + H - v, Y + H)
                Writer.Write_l_(X + v, Y + H)
                Writer.Write_l_(X, Y + H - v)
                Writer.Write_l_(X, Y + v)
                Writer.Write_b_()
                Dim Text As String = "STOP"
                Dim CharText() As Char = Text.ToCharArray()

                ' Begin text mode
                Writer.Write_BT()
                Writer.SetFont(Font.Helvetica, 16)
                Writer.Write_rg_(RgbColor.White)
                Writer.Write_Tm(88.5, Y + (w / 1.65))

                ' Wirte the text
                Writer.Write_Tj_(Text, False)

                ' End text mode
                Writer.Write_ET()
            End Sub
        End Class

        Public Shared Sub Run(ByVal outputPdfPath As String)
            Dim MyDocument As Document = New Document With {
                .Creator = "AllPageElements.aspx",
                .Author = "ceTe Software",
                .Title = "All Page Elements"
            }

            ' Add the top level outline to the document
            Dim ParentOutline As Outline = MyDocument.Outlines.Add("Top Level Outline", New XYDestination(1, 0, 0))
            ParentOutline.Color = New WebColor("0000FF")
            ParentOutline.Style = TextStyle.Bold

            ' Add pages to the document
            AddPageElementPage(MyDocument, ParentOutline)
            AddTableAndOther(MyDocument, ParentOutline)
            AddChartspage(MyDocument, ParentOutline)
            AddFormElementPage(MyDocument, ParentOutline)
            AddUPCEANPage(MyDocument, ParentOutline)
            AddPostalBarCodePage(MyDocument, ParentOutline)
            AddIsbnIssnIsmnPage(MyDocument, ParentOutline)
            AddBarCodePage(MyDocument, ParentOutline)
            Add2DBarCodePage(MyDocument, ParentOutline)
            AddWatermark(MyDocument, ParentOutline)

            ' Outputs the document to the current web page
            MyDocument.Draw(outputPdfPath)
        End Sub

        Private Shared Sub AddIsbn(elements As Group, x As Integer, y As Integer)
            AddCaptionAndRectangle(elements, "ISBN Barcode", x, y, 204, 99)
            Dim MyBarCode As New Isbn("978-1-23-456789-7", x, y + 21) With {
                .ShowText = True
            }
            MyBarCode.X += (204 - MyBarCode.GetSymbolWidth()) / 2
            elements.Add(MyBarCode)
        End Sub

        Private Shared Sub AddIsbnSup2(elements As Group, x As Integer, y As Integer)
            AddCaptionAndRectangle(elements, "ISBN Barcode, 2 digit supplement", x, y, 204, 99)
            Dim MyBarCode As New IsbnSup2("978-1-23-456789-7", "12", x, y + 21) With {
                .ShowText = True
            }
            MyBarCode.X += (204 - MyBarCode.GetSymbolWidth()) / 2
            elements.Add(MyBarCode)
        End Sub

        Private Shared Sub AddIsbnSup5(elements As Group, x As Integer, y As Integer)
            AddCaptionAndRectangle(elements, "ISBN Barcode, 5 digit supplement", x, y, 204, 99)
            Dim MyBarCode As New IsbnSup5("978-1-23-456789-7", "12345", x, y + 21) With {
                .ShowText = True
            }
            MyBarCode.X += (204 - MyBarCode.GetSymbolWidth()) / 2
            elements.Add(MyBarCode)
        End Sub

        Private Shared Sub AddIsmn(elements As Group, x As Integer, y As Integer)
            AddCaptionAndRectangle(elements, "ISMN Barcode", x, y, 204, 99)
            Dim MyBarCode As New Ismn("979-0-1234-5678", x, y + 21) With {
                .ShowText = True
            }
            MyBarCode.X += (204 - MyBarCode.GetSymbolWidth()) / 2
            elements.Add(MyBarCode)
        End Sub

        Private Shared Sub AddIsmnSup2(elements As Group, x As Integer, y As Integer)
            AddCaptionAndRectangle(elements, "ISMN Barcode, 2 digit supplement", x, y, 204, 99)
            Dim MyBarCode As New IsmnSup2("979-0-1234-5678", "12", x, y + 21) With {
                .ShowText = True
            }
            MyBarCode.X += (204 - MyBarCode.GetSymbolWidth()) / 2
            elements.Add(MyBarCode)
        End Sub

        Private Shared Sub AddIsmnSup5(elements As Group, x As Integer, y As Integer)
            AddCaptionAndRectangle(elements, "ISMN Barcode, 5 digit supplement", x, y, 204, 99)
            Dim MyBarCode As New IsmnSup5("979-0-1234-5678", "12345", x, y + 21) With {
                .ShowText = True
            }
            MyBarCode.X += (204 - MyBarCode.GetSymbolWidth()) / 2
            elements.Add(MyBarCode)
        End Sub

        Private Shared Sub AddIssn(elements As Group, x As Integer, y As Integer)
            AddCaptionAndRectangle(elements, "ISSN Barcode", x, y, 204, 99)
            Dim MyBarCode As New Issn("977-1234-56700", x, y + 21) With {
                .ShowText = True
            }
            MyBarCode.X += (204 - MyBarCode.GetSymbolWidth()) / 2
            elements.Add(MyBarCode)
        End Sub

        Private Shared Sub AddIssnSup2(elements As Group, x As Integer, y As Integer)
            AddCaptionAndRectangle(elements, "ISSN Barcode, 2 digit supplement", x, y, 204, 99)
            Dim MyBarCode As New IssnSup2("977-1234-56700", "12", x, y + 21) With {
                .ShowText = True
            }
            MyBarCode.X += (204 - MyBarCode.GetSymbolWidth()) / 2
            elements.Add(MyBarCode)
        End Sub

        Private Shared Sub AddIssnSup5(elements As Group, x As Integer, y As Integer)
            AddCaptionAndRectangle(elements, "ISSN Barcode, 5 digit supplement", x, y, 204, 99)
            Dim MyBarCode As New IssnSup5("977-1234-56700", "12345", x, y + 21) With {
                .ShowText = True
            }
            MyBarCode.X += (204 - MyBarCode.GetSymbolWidth()) / 2
            elements.Add(MyBarCode)
        End Sub

        Private Shared Sub AddSingaporePost(elements As Group, x As Integer, y As Integer)
            AddCaptionAndRectangle(elements, "Singapore Post Barcode", x, y, 225, 80)
            Dim MyBarCode As New SingaporePost("208154", x, y + 15, True) With {
                .Height = 35
            }
            MyBarCode.X += (225 - MyBarCode.GetSymbolWidth()) / 2
            MyBarCode.Y += (65 - MyBarCode.Height) / 2
            elements.Add(MyBarCode)
        End Sub

        Private Shared Sub AddKix(elements As Group, x As Integer, y As Integer)
            AddCaptionAndRectangle(elements, "Kix (Royal TNT Post) Barcode", x, y, 225, 80)
            Dim MyBarCode As New Kix("1231FZ13XHS", x, y + 15, True) With {
                .Height = 35
            }
            MyBarCode.X += (225 - MyBarCode.GetSymbolWidth()) / 2
            MyBarCode.Y += (65 - MyBarCode.Height) / 2
            elements.Add(MyBarCode)
        End Sub

        Private Shared Sub AddDeutschePostLeitcode(elements As Group, x As Integer, y As Integer)
            AddCaptionAndRectangle(elements, "Deutsche Post Leitcode", x, y, 225, 80)
            Dim MyBarCode As New DeutschePostLeitcode("1234567890123", x, y + 15, 48)
            MyBarCode.X += (225 - MyBarCode.GetSymbolWidth()) / 2
            MyBarCode.Y += (65 - MyBarCode.Height) / 2
            elements.Add(MyBarCode)
        End Sub

        Private Shared Sub AddDeutschePostIdentcode(elements As Group, x As Integer, y As Integer)
            AddCaptionAndRectangle(elements, "Deutsche Post Identcode", x, y, 225, 80)
            Dim MyBarCode As New DeutschePostIdentcode("12345678901", x, y + 15, 48)
            MyBarCode.X += (225 - MyBarCode.GetSymbolWidth()) / 2
            MyBarCode.Y += (65 - MyBarCode.Height) / 2
            elements.Add(MyBarCode)
        End Sub

        Private Shared Sub AddAustraliaPost(elements As Group, x As Integer, y As Integer)
            AddCaptionAndRectangle(elements, "Australia Post Barcode", x, y, 225, 80)
            Dim MyBarCode As New AustraliaPost("1139549554", x, y + 15, True) With {
                .Height = 35
            }
            MyBarCode.X += (225 - MyBarCode.GetSymbolWidth()) / 2
            MyBarCode.Y += (65 - MyBarCode.Height) / 2
            elements.Add(MyBarCode)
        End Sub

        Private Shared Sub AddStackedGs1Expanded(elements As Group, x As Integer, y As Integer)
            AddCaptionAndRectangle(elements, "Stacked GS1 DataBar Expanded Barcode", x, y, 225, 100)
            Dim MyBarCode As New StackedGS1DataBar("(01)1234567890123", x, y + 15, 25, StackedGS1DataBarType.ExpandedStacked)
            MyBarCode.X += (225 - MyBarCode.GetSymbolWidth()) / 2
            MyBarCode.Y += (85 - MyBarCode.GetSymbolHeight()) / 2
            elements.Add(MyBarCode)
        End Sub

        Private Shared Sub AddStackedGs1Stacked(elements As Group, x As Integer, y As Integer)
            AddCaptionAndRectangle(elements, "Stacked GS1 DataBar Barcode", x, y, 225, 100)
            Dim MyBarCode As New StackedGS1DataBar("(01)1234567890123", x, y + 15, 25, StackedGS1DataBarType.Stacked)
            MyBarCode.X += (225 - MyBarCode.GetSymbolWidth()) / 2
            MyBarCode.Y += (85 - MyBarCode.GetSymbolHeight()) / 2
            elements.Add(MyBarCode)
        End Sub

        Private Shared Sub AddStackedGs1Omni(elements As Group, x As Integer, y As Integer)
            AddCaptionAndRectangle(elements, "Stacked GS1 DataBar Omnidirectional Barcode", x, y, 225, 100)
            Dim MyBarCode As New StackedGS1DataBar("(01)1234567890123", x, y + 15, 25, StackedGS1DataBarType.StackedOmnidirectional)
            MyBarCode.X += (225 - MyBarCode.GetSymbolWidth()) / 2
            MyBarCode.Y += (85 - MyBarCode.GetSymbolHeight()) / 2
            elements.Add(MyBarCode)
        End Sub

        Private Shared Sub AddGs1DataBarExpanded(elements As Group, x As Integer, y As Integer)
            AddCaptionAndRectangle(elements, "GS1 DataBar Expanded Barcode", x, y, 225, 80)
            Dim MyBarCode As New GS1DataBar("(01)1234567890123", x, y + 15, 48, GS1DataBarType.Expanded)
            MyBarCode.X += (225 - MyBarCode.GetSymbolWidth()) / 2
            MyBarCode.Y += (65 - MyBarCode.Height) / 2
            elements.Add(MyBarCode)
        End Sub

        Private Shared Sub AddGs1DataBarLimited(elements As Group, x As Integer, y As Integer)
            AddCaptionAndRectangle(elements, "GS1 DataBar Limited Barcode", x, y, 225, 80)
            Dim MyBarCode As New GS1DataBar("(01)1234567890123", x, y + 15, 48, GS1DataBarType.Limited)
            MyBarCode.X += (225 - MyBarCode.GetSymbolWidth()) / 2
            MyBarCode.Y += (65 - MyBarCode.Height) / 2
            elements.Add(MyBarCode)
        End Sub

        Private Shared Sub AddGs1DataBarOmnidirectional(elements As Group, x As Integer, y As Integer)
            AddCaptionAndRectangle(elements, "GS1 DataBar Omnidirectional Barcode", x, y, 225, 80)
            Dim MyBarCode As New GS1DataBar("(01)9889876543210", x, y + 15, 48, GS1DataBarType.Omnidirectional)
            MyBarCode.X += (225 - MyBarCode.GetSymbolWidth()) / 2
            MyBarCode.Y += (65 - MyBarCode.Height) / 2
            elements.Add(MyBarCode)
        End Sub

        Private Shared Sub AddEan14(elements As Group, x As Integer, y As Integer)
            AddCaptionAndRectangle(elements, "EAN-14 Barcode", x, y, 225, 80)
            Dim MyBarCode As New Ean14("1234567890123", x, y + 15, 48)
            MyBarCode.X += (225 - MyBarCode.GetSymbolWidth()) / 2
            MyBarCode.Y += (65 - MyBarCode.Height) / 2
            elements.Add(MyBarCode)
        End Sub

        Private Shared Sub AddItf14(elements As Group, x As Integer, y As Integer)
            AddCaptionAndRectangle(elements, "ITF-14 Barcode", x, y, 225, 80)
            Dim MyBarCode As New Itf14("1234567890123", x, y + 15, 48)
            MyBarCode.X += (225 - MyBarCode.GetSymbolWidth()) / 2
            MyBarCode.Y += (65 - MyBarCode.Height) / 2
            elements.Add(MyBarCode)
        End Sub

        Private Shared Sub AddIata25(elements As Group, x As Integer, y As Integer)
            AddCaptionAndRectangle(elements, "IATA-25 Barcode", x, y, 225, 80)
            Dim MyBarCode As New Iata25("1234567", x, y + 15, 48)
            MyBarCode.X += (225 - MyBarCode.GetSymbolWidth()) / 2
            MyBarCode.Y += (65 - MyBarCode.Height) / 2
            elements.Add(MyBarCode)
        End Sub

        Private Shared Sub AddExtendedCode93(elements As Group, x As Integer, y As Integer)
            AddCaptionAndRectangle(elements, "Extended Code 93 Barcode", x, y, 225, 80)
            Dim MyBarCode As New Code93("Code 93", x, y + 15, 48)
            MyBarCode.X += (225 - MyBarCode.GetSymbolWidth()) / 2
            MyBarCode.Y += (65 - MyBarCode.Height) / 2
            elements.Add(MyBarCode)
        End Sub

        Private Shared Sub AddCode93(elements As Group, x As Integer, y As Integer)
            AddCaptionAndRectangle(elements, "Code 93 Barcode", x, y, 225, 80)
            Dim MyBarCode As New Code93("CODE 93", x, y + 15, 48)
            MyBarCode.X += (225 - MyBarCode.GetSymbolWidth()) / 2
            MyBarCode.Y += (65 - MyBarCode.Height) / 2
            elements.Add(MyBarCode)
        End Sub

        Private Shared Sub AddExtendedCode39(elements As Group, x As Integer, y As Integer)
            AddCaptionAndRectangle(elements, "Extended Code 3 of 9 Barcode", x, y, 225, 80)
            Dim MyBarCode As New Code39("Code 39", x, y + 15, 48)
            MyBarCode.X += (225 - MyBarCode.GetSymbolWidth()) / 2
            MyBarCode.Y += (65 - MyBarCode.Height) / 2
            elements.Add(MyBarCode)
        End Sub

        Private Shared Sub AddCode11(elements As Group, x As Integer, y As Integer)
            AddCaptionAndRectangle(elements, "Code 11 Barcode", x, y, 225, 80)
            Dim MyBarCode As New Code11("12345678", x, y + 15, 48)
            MyBarCode.X += (225 - MyBarCode.GetSymbolWidth()) / 2
            MyBarCode.Y += (65 - MyBarCode.Height) / 2
            elements.Add(MyBarCode)
        End Sub

        Private Shared Sub Add2DBarCodePage(ByVal MyDocument As Document, ByVal ParentOutline As Outline)
            ' Increments a page counter
            pageCounter = pageCounter + 1

            ' Adds to outlines to the page
            ParentOutline.ChildOutlines.Add("Page " + CStr(pageCounter) + " - 2D and Stacked GS1 Databar Barcodes", New ZoomDestination(pageCounter, PageZoom.FitPage))

            ' Create a page to add to the document
            Dim MyPage As Page = New Page(PageSize.Letter, PageOrientation.Portrait, 54)

            ' Uncomment the line below to add a layout grid to the page
            'page.Elements.Add( new LayoutGrid() )

            ' Add the page elements to the page
            AddStackedGs1Omni(MyPage.Elements, 0, 0)
            AddStackedGs1Stacked(MyPage.Elements, 0, 108)
            AddStackedGs1Expanded(MyPage.Elements, 0, 216)
            AddQrCode(MyPage.Elements, 0, 432)

            AddPdf417(MyPage.Elements, 279, 0)
            AddPdf417Macro(MyPage.Elements, 279, 108)

            MyDocument.Pages.Add(MyPage)
        End Sub

        Private Shared Sub AddPostalBarCodePage(ByVal MyDocument As Document, ByVal ParentOutline As Outline)
            pageCounter = pageCounter + 1

            ' Adds to outlines to the page
            ParentOutline.ChildOutlines.Add("Page " + CStr(pageCounter) + " - Postal Barcodes", New ZoomDestination(pageCounter, PageZoom.FitPage))

            ' Create a page to add to the document
            Dim MyPage As Page = New Page(PageSize.Letter, PageOrientation.Portrait, 54)

            ' Uncomment the line below to add a layout grid to the page
            'page.Elements.Add( new LayoutGrid() )

            ' Add the page elements to the page
            AddAustraliaPost(MyPage.Elements, 0, 0)
            AddDeutschePostIdentcode(MyPage.Elements, 0, 120)
            AddDeutschePostLeitcode(MyPage.Elements, 0, 240)
            AddKix(MyPage.Elements, 0, 360)

            AddIntelligentMailBarcode(MyPage.Elements, 279, 0)
            AddRm4sccCode(MyPage.Elements, 279, 120)
            AddPostnet(MyPage.Elements, 279, 240)
            AddSingaporePost(MyPage.Elements, 279, 360)

            MyDocument.Pages.Add(MyPage)
        End Sub

        Private Shared Sub AddIsbnIssnIsmnPage(ByVal MyDocument As Document, ByVal ParentOutline As Outline)
            pageCounter = pageCounter + 1

            ' Adds to outlines to the page
            ParentOutline.ChildOutlines.Add("Page " + CStr(pageCounter) + " - ISBN/ISMN/ISSN Barcodes", New ZoomDestination(pageCounter, PageZoom.FitPage))

            ' Create a page to add to the document
            Dim MyPage As Page = New Page(PageSize.Letter, PageOrientation.Landscape, 54)

            ' Uncomment the line below to add a layout grid to the page
            'page.Elements.Add( new LayoutGrid() )

            ' Add the page elements to the page
            AddIsbn(MyPage.Elements, 0, 0)
            AddIsbnSup2(MyPage.Elements, 240, 0)
            AddIsbnSup5(MyPage.Elements, 480, 0)
            AddIsmn(MyPage.Elements, 0, 150)
            AddIsmnSup2(MyPage.Elements, 240, 150)
            AddIsmnSup5(MyPage.Elements, 480, 150)
            AddIssn(MyPage.Elements, 0, 300)
            AddIssnSup2(MyPage.Elements, 240, 300)
            AddIssnSup5(MyPage.Elements, 480, 300)

            ' Add the page to the document
            MyDocument.Pages.Add(MyPage)
        End Sub

        Private Shared Sub AddMSICode(elements As Group, x As Integer, y As Integer)
            AddCaptionAndRectangle(elements, "MSI Barcode", x, y, 225, 80)
            Dim msi As MsiBarcode = New MsiBarcode("1234567890", x, y, 50, True)
            msi.Y += (80 - msi.Height) / 2 + 8
            msi.X += (225 - msi.GetSymbolWidth()) / 2
            elements.Add(msi)
        End Sub

        Private Shared Sub AddRm4sccCode(elements As Group, x As Integer, y As Integer)
            AddCaptionAndRectangle(elements, "RM4SCC Barcode", x, y, 225, 80)
            Dim rm4sccCode As Rm4scc = New Rm4scc("1457826RA", x, y, True) With {
                .Height = 35
            }
            rm4sccCode.Y += (65 - rm4sccCode.Height) / 2 + 13
            rm4sccCode.X += (225 - rm4sccCode.GetSymbolWidth()) / 2
            elements.Add(rm4sccCode)
        End Sub

        Private Shared Sub AddChartspage(ByVal MyDocument As Document, ByVal ParentOutline As Outline)
            ' Increments a page counter
            pageCounter = pageCounter + 1

            ' Adds  outlines to the page
            ParentOutline.ChildOutlines.Add("Page " + CStr(pageCounter) + " - Charts", New ZoomDestination(pageCounter, PageZoom.FitPage))

            ' Create a page 
            Dim MyPage As Page = New Page(PageSize.Letter, PageOrientation.Landscape)
            AddAreaChart(MyPage.Elements, 0, 25)
            AddLineChart(MyPage.Elements, 375, 25)
            AddPieChart(MyPage.Elements, 0, 260)
            AddBarChart(MyPage.Elements, 375, 260)
            MyDocument.Pages.Add(MyPage)
        End Sub

        Private Shared Sub AddAreaChart(ByVal Elements As Group, ByVal X As Single, ByVal Y As Single)
            AddCaptionAndRectangle(Elements, "Stacked Area Chart", X, Y, 325, 225)

            ' Create a MyChart
            Dim MyChart As New Chart(X + 20, Y + 25, 300, 200)

            ' Create a plot area
            Dim MyPlotArea As PlotArea = MyChart.PrimaryPlotArea

            ' Create header title and add it to the MyChart
            Dim MyTitle1 As New Title("Website Visitors")
            MyChart.HeaderTitles.Add(MyTitle1)

            ' Create indexed stacked are series elements and add values to it
            Dim MySeriesElement1 As New IndexedStackedAreaSeriesElement("Website A")
            MySeriesElement1.Values.Add(New Single() {5, 7, 9, 6})
            Dim MySeriesElement2 As New IndexedStackedAreaSeriesElement("Website B")
            MySeriesElement2.Values.Add(New Single() {4, 2, 5, 8})
            Dim MySeriesElement3 As New IndexedStackedAreaSeriesElement("Website C")
            MySeriesElement3.Values.Add(New Single() {2, 4, 6, 9})

            ' Add autogradient colors to series
            Dim MyAutogradient1 As AutoGradient = New AutoGradient(90.0F, CmykColor.Red, CmykColor.IndianRed)
            MySeriesElement1.Color = MyAutogradient1
            Dim MyAutogradient2 As AutoGradient = New AutoGradient(90.0F, CmykColor.Green, CmykColor.YellowGreen)
            MySeriesElement2.Color = MyAutogradient2
            Dim MyAutogradient3 As AutoGradient = New AutoGradient(120.0F, CmykColor.Blue, CmykColor.LightBlue)
            MySeriesElement3.Color = MyAutogradient3

            ' Create a Indexed Stacked Area Series
            Dim MyAreaSeries1 As New IndexedStackedAreaSeries()

            ' Add indexed stacked area series elements to the Indexed Stacked Area Series
            MyAreaSeries1.Add(MySeriesElement1)
            MyAreaSeries1.Add(MySeriesElement2)
            MyAreaSeries1.Add(MySeriesElement3)

            ' Add series to the plot area
            MyPlotArea.Series.Add(MyAreaSeries1)

            ' Create a title and add it to the YAxis
            Dim MylTitle As New Title("Visitors (in millions)")
            MyAreaSeries1.YAxis.Titles.Add(MylTitle)

            'Adding AxisLabels to the XAxis
            MyAreaSeries1.XAxis.Labels.Add(New IndexedXAxisLabel("Q1", 0))
            MyAreaSeries1.XAxis.Labels.Add(New IndexedXAxisLabel("Q2", 1))
            MyAreaSeries1.XAxis.Labels.Add(New IndexedXAxisLabel("Q3", 2))
            MyAreaSeries1.XAxis.Labels.Add(New IndexedXAxisLabel("Q4", 3))
            Elements.Add(MyChart)
        End Sub

        Private Shared Sub AddLineChart(ByVal Elements As Group, ByVal X As Single, ByVal Y As Single)
            AddCaptionAndRectangle(Elements, "Line Chart", X, Y, 325, 225)

            ' Create a MyChart
            Dim MyChart As New Chart(X + 20, Y + 25, 300, 200)

            ' Create a plot area
            Dim MyPlotArea As PlotArea = MyChart.PrimaryPlotArea

            ' Create header titles and add it to the MyChart
            Dim MyTitle1 As New Title("Website Visitors")
            MyChart.HeaderTitles.Add(MyTitle1)

            ' Create a indexed line series and add values to it
            Dim MyLineSeries1 As New IndexedLineSeries("Website A")
            MyLineSeries1.Values.Add(New Single() {5, 7, 9, 6})
            Dim MyLineSeries2 As New IndexedLineSeries("Website B")
            MyLineSeries2.Values.Add(New Single() {4, 2, 5, 8})
            Dim MyLineSeries3 As New IndexedLineSeries("Website C")
            MyLineSeries3.Values.Add(New Single() {2, 4, 6, 9})

            ' Add indexed line series to the plot area
            MyPlotArea.Series.Add(MyLineSeries1)
            MyPlotArea.Series.Add(MyLineSeries2)
            MyPlotArea.Series.Add(MyLineSeries3)

            ' Create a title and add it to the yaxis
            Dim MylTitle As New Title("Visitors (in millions)")
            MyLineSeries1.YAxis.Titles.Add(MylTitle)

            'Adding AxisLabels to the XAxis
            MyLineSeries1.XAxis.Labels.Add(New IndexedXAxisLabel("Q1", 0))
            MyLineSeries1.XAxis.Labels.Add(New IndexedXAxisLabel("Q2", 1))
            MyLineSeries1.XAxis.Labels.Add(New IndexedXAxisLabel("Q3", 2))
            MyLineSeries1.XAxis.Labels.Add(New IndexedXAxisLabel("Q4", 3))
            Elements.Add(MyChart)
        End Sub

        Private Shared Sub AddPieChart(ByVal Elements As Group, ByVal X As Single, ByVal Y As Single)
            AddCaptionAndRectangle(Elements, "Pie Chart", X, Y, 325, 225)

            ' Create a MyChart
            Dim MyChart As New Chart(X + 20, Y + 25, 300, 200)

            ' Add a plot area to the MyChart
            Dim MyPlotArea As PlotArea = MyChart.PlotAreas.Add(50, 50, 300, 300)

            ' Create the Header titles and add it to the MyChart
            Dim MytTitle As New Title("Website Visitors (in millions)")
            MyChart.HeaderTitles.Add(MytTitle)

            ' Add autogradient colors to series
            Dim MyAutogradient1 As AutoGradient = New AutoGradient(90.0F, CmykColor.Red, CmykColor.IndianRed)
            Dim MyAutogradient2 As AutoGradient = New AutoGradient(90.0F, CmykColor.Green, CmykColor.YellowGreen)
            Dim MyAutogradient3 As AutoGradient = New AutoGradient(120.0F, CmykColor.Blue, CmykColor.LightBlue)

            ' Create a scalar datalabel
            Dim Myda As ScalarDataLabel = New ScalarDataLabel(True, False, False)

            ' Create a pie series 
            Dim MyPieSeries As New PieSeries()

            ' Set scalar datalabel to the pie series
            MyPieSeries.DataLabel = Myda

            ' Add series to the plot area
            MyPlotArea.Series.Add(MyPieSeries)

            'Add pie series elements to the pie series
            MyPieSeries.Elements.Add(27, "Website A")
            MyPieSeries.Elements.Add(19, "Website B")
            MyPieSeries.Elements.Add(21, "Website C")
            MyPieSeries.Elements(0).Color = MyAutogradient1
            MyPieSeries.Elements(1).Color = MyAutogradient2
            MyPieSeries.Elements(2).Color = MyAutogradient3
            Elements.Add(MyChart)
        End Sub

        Private Shared Sub AddBarChart(ByVal Elements As Group, ByVal X As Single, ByVal Y As Single)
            AddCaptionAndRectangle(Elements, "Stacked Bar Chart", X, Y, 325, 225)

            ' Create a MyChart
            Dim MyChart As New Chart(X + 20, Y + 25, 300, 200)

            ' Create a plot area
            Dim MyPlotArea As PlotArea = MyChart.PrimaryPlotArea

            ' Create header title and add it to the chartdim 
            Dim MyTitle1 As New Title("Website Visitors")
            MyChart.HeaderTitles.Add(MyTitle1)

            ' Create a indexed stacked bar series elements and add values to it
            Dim MySeriesElement1 As New IndexedStackedBarSeriesElement("Website A")
            MySeriesElement1.Values.Add(New Single() {5, 7, 9, 6})
            Dim MySeriesElement2 As New IndexedStackedBarSeriesElement("Website B")
            MySeriesElement2.Values.Add(New Single() {4, 2, 5, 8})
            Dim MySeriesElement3 As New IndexedStackedBarSeriesElement("Website C")
            MySeriesElement3.Values.Add(New Single() {2, 4, 6, 9})

            ' Add autogradient colors to series
            Dim MyAutogradient1 As AutoGradient = New AutoGradient(90.0F, CmykColor.Red, CmykColor.IndianRed)
            Dim MyAutogradient2 As AutoGradient = New AutoGradient(90.0F, CmykColor.Green, CmykColor.YellowGreen)
            Dim MyAutogradient3 As AutoGradient = New AutoGradient(90.0F, CmykColor.Blue, CmykColor.LightBlue)
            MySeriesElement1.Color = MyAutogradient1
            MySeriesElement2.Color = MyAutogradient2
            MySeriesElement3.Color = MyAutogradient3

            ' Create a Indexed Stacked Bar Series
            Dim MyBarSeries As New IndexedStackedBarSeries()

            ' Add indexed stacked bar series elements to the Indexed Stacked Bar Series
            MyBarSeries.Add(MySeriesElement1)
            MyBarSeries.Add(MySeriesElement2)
            MyBarSeries.Add(MySeriesElement3)

            'Add series to the plot area
            MyPlotArea.Series.Add(MyBarSeries)

            ' Create a title and add it to the xaxis
            Dim MylTitle As New Title("Visitors (in millions)")
            MyBarSeries.XAxis.Titles.Add(MylTitle)

            'Adding AxisLabels to the yaxis
            MyBarSeries.YAxis.Labels.Add(New IndexedYAxisLabel("Q1", 0))
            MyBarSeries.YAxis.Labels.Add(New IndexedYAxisLabel("Q2", 1))
            MyBarSeries.YAxis.Labels.Add(New IndexedYAxisLabel("Q3", 2))
            MyBarSeries.YAxis.Labels.Add(New IndexedYAxisLabel("Q4", 3))
            MyBarSeries.XAxis.Labels.Angle = -65
            Elements.Add(MyChart)
        End Sub

        Private Shared Sub AddBarCodePage(ByVal MyDocument As Document, ByVal ParentOutline As Outline)
            ' Increments a page counter
            pageCounter = pageCounter + 1

            ' Adds to outlines to the page
            ParentOutline.ChildOutlines.Add("Page " + CStr(pageCounter) + " - Other Linear Barcodes", New ZoomDestination(pageCounter, PageZoom.FitPage))

            ' Create a page to add to the document
            Dim MyPage As Page = New Page(PageSize.Letter, PageOrientation.Portrait, 54)

            ' Uncomment the line below to add a layout grid to the page
            'page.Elements.Add( new LayoutGrid() )

            ' Add the page elements to the page
            AddCodabar(MyPage.Elements, 0, 0)
            AddCode11(MyPage.Elements, 0, 88)
            AddCode128(MyPage.Elements, 0, 176)
            AddCode25(MyPage.Elements, 0, 264)
            AddCode39(MyPage.Elements, 0, 352)
            AddExtendedCode39(MyPage.Elements, 0, 440)
            AddCode93(MyPage.Elements, 0, 528)
            AddExtendedCode93(MyPage.Elements, 0, 616)

            AddIata25(MyPage.Elements, 279, 0)
            AddInterleaved25(MyPage.Elements, 279, 88)
            AddItf14(MyPage.Elements, 279, 176)
            AddMSICode(MyPage.Elements, 279, 264)
            AddEan14(MyPage.Elements, 279, 352)
            AddGs1DataBarOmnidirectional(MyPage.Elements, 279, 440)
            AddGs1DataBarLimited(MyPage.Elements, 279, 528)
            AddGs1DataBarExpanded(MyPage.Elements, 279, 616)
            MyDocument.Pages.Add(MyPage)
        End Sub

        Private Shared Sub AddCodabar(ByVal Elements As Group, ByVal X As Single, ByVal Y As Single)
            AddCaptionAndRectangle(Elements, "Codabar Barcode", X, Y, 225, 80)
            Dim MyBarCode As BarCode = New Codabar("A1234B", X, Y + 15, 48)
            MyBarCode.X += (225 - MyBarCode.GetSymbolWidth()) / 2
            MyBarCode.Y += (65 - MyBarCode.Height) / 2
            Elements.Add(MyBarCode)
        End Sub

        Private Shared Sub AddCode128(ByVal Elements As Group, ByVal X As Single, ByVal Y As Single)
            AddCaptionAndRectangle(Elements, "Code 128 Barcode", X, Y, 225, 80)
            Dim MyBarCode As BarCode = New Code128("Code 128 Barcode.", X, Y + 15, 48, 0.75F)
            MyBarCode.X += (225 - MyBarCode.GetSymbolWidth()) / 2
            MyBarCode.Y += (65 - MyBarCode.Height) / 2
            Elements.Add(MyBarCode)
        End Sub

        Private Shared Sub AddCode25(ByVal Elements As Group, ByVal X As Single, ByVal Y As Single)
            AddCaptionAndRectangle(Elements, "Code 2 of 5 Barcode", X, Y, 225, 80)
            Dim MyBarCode As BarCode = New Code25("1234567890", X, Y + 15, 48)
            MyBarCode.X += (225 - MyBarCode.GetSymbolWidth()) / 2
            MyBarCode.Y += (65 - MyBarCode.Height) / 2
            Elements.Add(MyBarCode)
        End Sub

        Private Shared Sub AddCode39(ByVal Elements As Group, ByVal X As Single, ByVal Y As Single)
            AddCaptionAndRectangle(Elements, "Code 3 of 9 Barcode", X, Y, 225, 80)
            Dim MyBarCode As BarCode = New Code39("CODE 39", X, Y + 15, 48)
            MyBarCode.X += (225 - MyBarCode.GetSymbolWidth()) / 2
            MyBarCode.Y += (65 - MyBarCode.Height) / 2
            Elements.Add(MyBarCode)
        End Sub

        Private Shared Sub AddInterleaved25(ByVal Elements As Group, ByVal X As Single, ByVal Y As Single)
            AddCaptionAndRectangle(Elements, "Interleaved 2 of 5 Barcode", X, Y, 225, 80)
            Dim MyBarCode As BarCode = New Interleaved25("1234567890", X, Y + 15, 48)
            MyBarCode.X += (225 - MyBarCode.GetSymbolWidth()) / 2
            MyBarCode.Y += (65 - MyBarCode.Height) / 2
            Elements.Add(MyBarCode)
        End Sub

        Private Shared Sub AddIntelligentMailBarcode(ByVal Elements As Group, ByVal X As Single, ByVal Y As Single)
            AddCaptionAndRectangle(Elements, "Intelligent Mail Barcode", X, Y, 225, 80)
            Dim MyBarCode As BarCode = New IntelligentMailBarCode("0123456709498765432101234567891", X, Y + 15, True) With {
                .Height = 35
            }
            MyBarCode.X += (225 - MyBarCode.GetSymbolWidth()) / 2
            MyBarCode.Y += (65 - MyBarCode.Height) / 2
            Elements.Add(MyBarCode)
        End Sub

        Private Shared Sub AddPostnet(ByVal Elements As Group, ByVal X As Single, ByVal Y As Single)
            AddCaptionAndRectangle(Elements, "Postnet Barcode", X, Y, 225, 80)
            Dim MyBarCode As BarCode = New Postnet("20815470412", X, Y + 15)
            MyBarCode.X += (225 - MyBarCode.GetSymbolWidth()) / 2
            MyBarCode.Y += (65 - MyBarCode.Height) / 2
            Elements.Add(MyBarCode)
        End Sub

        Private Shared Sub AddPdf417(ByVal Elements As Group, ByVal X As Single, ByVal Y As Single)
            AddCaptionAndRectangle(Elements, "PDF417 Barcode", X, Y, 225, 100)
            Dim Text As Byte() = Encoding.ASCII.GetBytes("PDF417 Barcode")
            Dim Pdfc As Pdf417 = New Pdf417(Text, X, Y + 15, 2, 2)
            Pdfc.X += (225 - Pdfc.GetSymbolWidth()) / 2
            Pdfc.Y += (85 - Pdfc.GetSymbolHeight()) / 2
            Elements.Add(Pdfc)
        End Sub

        Private Shared Sub AddPdf417Macro(ByVal Elements As Group, ByVal X As Single, ByVal Y As Single)
            AddCaptionAndRectangle(Elements, "PDF417 Macro Barcode", X, Y, 225, 100)
            Dim Data() As Byte = Nothing
            Try
                Dim MyFile As FileStream = New FileStream(Util.GetResourcePath("Text/Textdata.txt"), FileMode.Open, FileAccess.Read)
                'Data = New Byte(MyFile.Length) {}
                ReDim Data(MyFile.Length - 1)
                MyFile.Read(Data, 0, MyFile.Length)
                MyFile.Close()
            Catch e As Exception
                Console.WriteLine("EXCEPTION  " + e.Message)
            End Try

            ' Create a MacroPdf417
            Dim MyMacroPdf417 As MacroPdf417 = New MacroPdf417(Data, X, Y + 15, 10, 15, 0.9F)
            MyMacroPdf417.X += (225 - MyMacroPdf417.GetSymbolWidth()) / 2
            MyMacroPdf417.Y += (85 - MyMacroPdf417.GetSymbolHeight()) / 2

            ' Add macroPdf417 to page
            Elements.Add(MyMacroPdf417)

            ' Retrieve the overflow barcode and place it at the appropriate location on the page
            MyMacroPdf417 = MyMacroPdf417.GetOverflowMacroPdf417(X, Y + 124)
            MyMacroPdf417.X += (225 - MyMacroPdf417.GetSymbolWidth()) / 2
            MyMacroPdf417.Y += (85 - MyMacroPdf417.GetSymbolHeight()) / 2
            AddCaptionAndRectangle(Elements, "PDF417 Overflow Macro Barcode", X, Y + 108, 225, 100)
            Elements.Add(MyMacroPdf417)
        End Sub

        Private Shared Sub AddQrCode(ByVal Elements As Group, ByVal X As Single, ByVal Y As Single)
            AddCaptionAndRectangle(Elements, "QR Code", X, Y, 225, 100)
            Dim Text As Byte() = Encoding.ASCII.GetBytes("QR Code Barcode")
            Dim qrCode As QrCode = New QrCode(Text, X, Y + 15)
            qrCode.XDimension = 2.5F
            qrCode.X += (225 - qrCode.GetSymbolWidth()) / 2
            qrCode.Y += (85 - qrCode.GetSymbolHeight()) / 2
            Elements.Add(qrCode)
        End Sub

        Private Shared Sub AddUPCEANPage(ByVal MyDocument As Document, ByVal ParentOutline As Outline)
            ' Increments a page counter
            pageCounter = pageCounter + 1

            ' Adds to outlines to the page
            ParentOutline.ChildOutlines.Add("Page " + CStr(pageCounter) + " - UPC/EAN/JAN Barcodes", New ZoomDestination(pageCounter, PageZoom.FitPage))

            ' Create a page to add to the document
            Dim MyPage As Page = New Page(PageSize.Letter, PageOrientation.Landscape, 54)

            ' Uncomment the line below to add a layout grid to the page
            'page.Elements.Add( new LayoutGrid() )

            ' Add the page elements to the page
            AddEAN13(MyPage.Elements, 0, 0)
            AddEAN13Sup2(MyPage.Elements, 240, 0)
            AddEAN13Sup5(MyPage.Elements, 480, 0)
            AddUPCVersionA(MyPage.Elements, 0, 135)
            AddUPCVersionASup2(MyPage.Elements, 240, 135)
            AddUPCVersionASup5(MyPage.Elements, 480, 135)
            AddEAN8(MyPage.Elements, 0, 270)
            AddEAN8Sup2(MyPage.Elements, 240, 270)
            AddEAN8Sup5(MyPage.Elements, 480, 270)
            AddUPCVersionE(MyPage.Elements, 0, 405)
            AddUPCVersionESup2(MyPage.Elements, 240, 405)
            AddUPCVersionESup5(MyPage.Elements, 480, 405)
            ' Add the page to the document
            MyDocument.Pages.Add(MyPage)
        End Sub

        Private Shared Sub AddEAN13(ByVal Elements As Group, ByVal X As Single, ByVal Y As Single)
            AddCaptionAndRectangle(Elements, "EAN/JAN 13 Barcode", X, Y, 204, 99)
            Dim MyBarCode As BarCode = New Ean13("123456789012", X, Y + 21)
            MyBarCode.X += (204 - MyBarCode.GetSymbolWidth()) / 2
            Elements.Add(MyBarCode)
        End Sub

        Private Shared Sub AddEAN13Sup2(ByVal Elements As Group, ByVal X As Single, ByVal Y As Single)
            AddCaptionAndRectangle(Elements, "EAN/JAN 13 Barcode, 2 digit supplement", X, Y, 204, 99)
            Dim MyBarCode As BarCode = New Ean13Sup2("12345678901212", X, Y + 21)
            MyBarCode.X += (204 - MyBarCode.GetSymbolWidth()) / 2
            Elements.Add(MyBarCode)
        End Sub

        Private Shared Sub AddEAN13Sup5(ByVal Elements As Group, ByVal X As Single, ByVal Y As Single)
            AddCaptionAndRectangle(Elements, "EAN/JAN 13 Barcode, 5 digit supplement", X, Y, 204, 99)
            Dim MyBarCode As BarCode = New Ean13Sup5("12345678901212345", X, Y + 21)
            MyBarCode.X += (204 - MyBarCode.GetSymbolWidth()) / 2
            Elements.Add(MyBarCode)
        End Sub

        Private Shared Sub AddUPCVersionA(ByVal Elements As Group, ByVal X As Single, ByVal Y As Single)
            AddCaptionAndRectangle(Elements, "UPC Version A Barcode", X, Y, 204, 99)
            Dim MyBarCode As BarCode = New UpcVersionA("12345678901", X, Y + 21)
            MyBarCode.X += (204 - MyBarCode.GetSymbolWidth()) / 2
            Elements.Add(MyBarCode)
        End Sub

        Private Shared Sub AddUPCVersionASup2(ByVal Elements As Group, ByVal X As Single, ByVal Y As Single)
            AddCaptionAndRectangle(Elements, "UPC Version A Barcode, 2 digit supplement", X, Y, 204, 99)
            Dim MyBarCode As BarCode = New UpcVersionASup2("1234567890112", X, Y + 21)
            MyBarCode.X += (204 - MyBarCode.GetSymbolWidth()) / 2
            Elements.Add(MyBarCode)
        End Sub

        Private Shared Sub AddUPCVersionASup5(ByVal Elements As Group, ByVal X As Single, ByVal Y As Single)
            AddCaptionAndRectangle(Elements, "UPC Version A Barcode, 5 digit supplement", X, Y, 204, 99)
            Dim MyBarCode As BarCode = New UpcVersionASup5("1234567890112345", X, Y + 21)
            MyBarCode.X += (204 - MyBarCode.GetSymbolWidth()) / 2
            Elements.Add(MyBarCode)
        End Sub

        Private Shared Sub AddEAN8(ByVal Elements As Group, ByVal X As Single, ByVal Y As Single)
            AddCaptionAndRectangle(Elements, "EAN/JAN 8 Barcode", X, Y, 204, 99)
            Dim MyBarCode As BarCode = New Ean8("12345670", X, Y + 21)
            MyBarCode.X += (204 - MyBarCode.GetSymbolWidth()) / 2
            Elements.Add(MyBarCode)
        End Sub

        Private Shared Sub AddEAN8Sup2(ByVal Elements As Group, ByVal X As Single, ByVal Y As Single)
            AddCaptionAndRectangle(Elements, "EAN/JAN 8 Barcode, 2 digit supplement", X, Y, 204, 99)
            Dim MyBarCode As BarCode = New Ean8Sup2("1234567012", X, Y + 21)
            MyBarCode.X += (204 - MyBarCode.GetSymbolWidth()) / 2
            Elements.Add(MyBarCode)
        End Sub

        Private Shared Sub AddEAN8Sup5(ByVal Elements As Group, ByVal X As Single, ByVal Y As Single)
            AddCaptionAndRectangle(Elements, "EAN/JAN 8 Barcode, 5 digit supplement", X, Y, 204, 99)
            Dim MyBarCode As BarCode = New Ean8Sup5("1234567012345", X, Y + 21)
            MyBarCode.X += (204 - MyBarCode.GetSymbolWidth()) / 2
            Elements.Add(MyBarCode)
        End Sub

        Private Shared Sub AddUPCVersionE(ByVal Elements As Group, ByVal X As Single, ByVal Y As Single)
            AddCaptionAndRectangle(Elements, "UPC Version E Barcode", X, Y, 204, 99)
            Dim MyBarCode As BarCode = New UpcVersionE("0123456", X, Y + 21)
            MyBarCode.X += (204 - MyBarCode.GetSymbolWidth()) / 2
            Elements.Add(MyBarCode)
        End Sub

        Private Shared Sub AddUPCVersionESup2(ByVal Elements As Group, ByVal X As Single, ByVal Y As Single)
            AddCaptionAndRectangle(Elements, "UPC Version E Barcode, 2 digit supplement", X, Y, 204, 99)
            Dim MyBarCode As BarCode = New UpcVersionESup2("012345612", X, Y + 21)
            MyBarCode.X += (204 - MyBarCode.GetSymbolWidth()) / 2
            Elements.Add(MyBarCode)
        End Sub

        Private Shared Sub AddUPCVersionESup5(ByVal Elements As Group, ByVal X As Single, ByVal Y As Single)
            AddCaptionAndRectangle(Elements, "UPC Version E Barcode, 5 digit supplement", X, Y, 204, 99)
            Dim MyBarCode As BarCode = New UpcVersionESup5("012345612345", X, Y + 21)
            MyBarCode.X += (204 - MyBarCode.GetSymbolWidth()) / 2
            Elements.Add(MyBarCode)
        End Sub

        Private Shared Sub AddPageElementPage(ByVal MyDocument As Document, ByVal ParentOutline As Outline)
            ' Increments a page counter
            pageCounter = pageCounter + 1

            ' Adds to outlines to the page
            Dim PageOutline As Outline = ParentOutline.ChildOutlines.Add("Page " + CStr(pageCounter))
            PageOutline.ChildOutlines.Add("Zoom - Fit Page", New ZoomDestination(pageCounter, PageZoom.FitPage))
            PageOutline.ChildOutlines.Add("Zoom - Fit Width", New ZoomDestination(pageCounter, PageZoom.FitWidth))

            ' Create a page to add to the document
            Dim MyPage As Page = New Page(PageSize.Letter, PageOrientation.Portrait, 54)

            ' Uncomment the line below to add a layout grid to the page
            'page.Elements.Add( new LayoutGrid() )

            ' Add the page elements to the page
            AddHeader(MyPage.Elements)
            AddBookmark(MyPage.Elements, 0, 41, PageOutline)
            AddCircle(MyPage.Elements, 279, 41)
            AddHtmlArea(MyPage.Elements, 0, 134)
            AddImage(MyPage.Elements, 0, 227)
            AddLabel(MyPage.Elements, 279, 227)
            AddLine(MyPage.Elements, 0, 320)
            AddLink(MyPage.Elements, 279, 320)
            AddPath(MyPage.Elements, 0, 413)
            AddRectangle(MyPage.Elements, 279, 413)
            AddTextArea(MyPage.Elements, 0, 506)
            AddCustom(MyPage.Elements, 0, 599)
            AddNote(MyPage.Elements, 279, 599)

            ' Add the page to the document
            MyDocument.Pages.Add(MyPage)
        End Sub

        Private Shared Sub AddHeader(ByVal PageElements As Group)
            ' Adds a header to the pageElements
            Dim FormattedText As String = "<i>Dynamic</i><b>PDF</b> Generator for .NET has over 50 built-in page " +
                "elements. Custom page elements can be built by creating a class that inherits from " +
                "<b>ceTe.DynamicPDF.PageElement</b>."
            Dim MyFormattedTextArea As FormattedTextArea = New FormattedTextArea(FormattedText, 0, 0, 520, 450, FontFamily.Helvetica, 12, False)
            MyFormattedTextArea.Style.Paragraph.Align = TextAlign.Center
            PageElements.Add(MyFormattedTextArea)
        End Sub

        Private Shared Sub AddBookmark(ByVal PageElements As Group, ByVal X As Single, ByVal y As Single, ByVal ParentOutline As Outline)
            ' Adds a bookmark to the page
            AddCaptionAndRectangle(PageElements, "Bookmark Page Element", X, y)
            PageElements.Add(New Bookmark("Bookmarked Text", X + 5, y + 20, ParentOutline))
            PageElements.Add(New Label("This text is bookmarked.", X + 5, y + 20, 215, 10, Font.TimesRoman, 10))
        End Sub

        Private Shared Sub AddCircle(ByVal PageElements As Group, ByVal X As Single, ByVal Y As Single)
            ' Adds a circlt to the pageElements
            AddCaptionAndRectangle(PageElements, "Circle Page Element", X, Y)
            PageElements.Add(New Circle(X + 112.5F, Y + 50.0F, 107.5F, 30.0F, RgbColor.Red, RgbColor.Blue, 2, LineStyle.DashLarge))
        End Sub

        Private Shared Sub AddHtmlArea(ByVal PageElements As Group, ByVal X As Single, ByVal Y As Single)
            ' Adds an HTML text area to the pageElements
            Dim MyUri As Uri = New Uri(Util.GetResourcePath("Html/AllPageElementSample.html"))

            Dim MyHtmlArea As HtmlArea = New HtmlArea(MyUri, X + 5, Y + 20, 215, 70)
            ' Sets the indent property
            AddCaptionAndRectangle(PageElements, "HtmlArea Page Element", X, Y)
            AddCaptionAndRectangle(PageElements, "HtmlArea Overflow Text", X + 279, Y)
            PageElements.Add(MyHtmlArea)
            ' Set the html area object equal to the rest of the html area that did not fit
            ' if all the html area did fit, GetOverflowHtmlArea will return null
            Dim OverflowFormattedTextArea As HtmlArea = MyHtmlArea.GetOverflowHtmlArea(X + 284, Y + 20, 70)
            PageElements.Add(OverflowFormattedTextArea)
        End Sub

        Private Shared Sub AddImage(ByVal PageElements As Group, ByVal X As Single, ByVal Y As Single)
            ' Adds an image to the pageElements
            AddCaptionAndRectangle(PageElements, "Image Page Element", X, Y)
            Dim MyImage As Image = New Image(Util.GetResourcePath("Images/DPDFLogo.png"), X + 112.5F, Y + 50.0F, 0.24F)
            ' Image is sized and centered in the rectangle
            MyImage.SetBounds(215, 60)
            MyImage.VAlign = VAlign.Center
            MyImage.Align = Align.Center
            PageElements.Add(MyImage)
        End Sub

        Private Shared Sub AddLabel(ByVal PageElements As Group, ByVal X As Single, ByVal Y As Single)
            ' Adds a label to the pageElements
            AddCaptionAndRectangle(PageElements, "Label  and PageNumberingLabel Page Elements", X, Y)
            Dim LabelText As String = "Labels can be rotated"
            Dim NumberText As String = "PageNumberingLabels contain page numbering: %%CP%% of %%TP%% pages."
            Dim MyLabel As Label = New Label(LabelText, X + 5, Y + 12, 220, 80, Font.TimesRoman, 12, TextAlign.Center)
            MyLabel.Angle = 8
            Dim PageNumLabel As PageNumberingLabel = New PageNumberingLabel(NumberText, X + 5, Y + 55, 220, 80, Font.TimesRoman, 12, TextAlign.Center)
            PageElements.Add(PageNumLabel)
            PageElements.Add(MyLabel)
        End Sub

        Private Shared Sub AddLine(ByVal PageElements As Group, ByVal X As Single, ByVal Y As Single)
            ' Adds a line to the pageElements
            AddCaptionAndRectangle(PageElements, "Line Page Element", X, Y)
            PageElements.Add(New Line(X + 5, Y + 20, X + 220, Y + 80, 3, RgbColor.Green))
            PageElements.Add(New Line(X + 220, Y + 20, X + 5, Y + 80, 3, RgbColor.Green))
        End Sub

        Private Shared Sub AddLink(ByVal PageElements As Group, ByVal X As Single, ByVal Y As Single)
            ' Adds a link to the pageElements
            Dim MyFont As Font = Font.TimesRoman
            Dim Text As String = "This is a link to DynamicPDF.com."
            AddCaptionAndRectangle(PageElements, "Link Page Element", X, Y)
            Dim MyLabel As Label = New Label(Text, X + 5, Y + 20, 215, 80, MyFont, 12, RgbColor.Blue)
            MyLabel.Underline = True
            Dim link As Link = New Link(X + 5, Y + 20, MyFont.GetTextWidth(Text, 12), 12 - MyFont.GetDescender(12), New UrlAction("http://www.dynamicpdf.com"))
            PageElements.Add(MyLabel)
            PageElements.Add(link)
        End Sub

        Private Shared Sub AddPath(ByVal PageElements As Group, ByVal X As Single, ByVal Y As Single)
            ' Adds a path to the pageElements
            Dim MyPath As PageElements.Path = New PageElements.Path(X + 5, Y + 20, RgbColor.Blue, RgbColor.Red, 2, LineStyle.Solid, True)
            MyPath.SubPaths.Add(New LineSubPath(X + 215, Y + 40))
            MyPath.SubPaths.Add(New CurveToSubPath(X + 108, Y + 80, X + 160, Y + 80))
            MyPath.SubPaths.Add(New CurveSubPath(X + 5, Y + 40, X + 65, Y + 80, X + 5, Y + 60))
            AddCaptionAndRectangle(PageElements, "Path Page Element", X, Y)
            PageElements.Add(MyPath)
        End Sub

        Private Shared Sub AddRectangle(ByVal PageElements As Group, ByVal X As Single, ByVal Y As Single)
            ' Adds a rectangle to the pageElements
            AddCaptionAndRectangle(PageElements, "Rectangle Page Element", X, Y)
            PageElements.Add(New Rectangle(X + 5, Y + 20, 215, 60, RgbColor.Green, RgbColor.Blue, 2))
        End Sub

        Private Shared Sub AddTextArea(ByVal PageElements As Group, ByVal X As Single, ByVal Y As Single)
            ' Adds a text area to the pageElements
            Dim Text As String = "The TextArea page element is great for efficient processign of text that does " +
              "not require advanced formatting. It offers basic control over leading and paragraph spacing and " +
              "include text continuation functionality. If all the text does not fit within the bounds of " +
              "the TextArea the HasOverflowText method will return a true value. The GetOverflowTextArea " +
              "method can then be called to create a new TextArea with the remaining text. This " +
              "functionality makes it simple to span large amounts of text over multiple TextAreas and pages. Text can also be rotated."
            AddCaptionAndRectangle(PageElements, "TextArea Page Element", X, Y)
            AddCaptionAndRectangle(PageElements, "TextArea Overflow Text", X + 279, Y)
            Dim MyTextArea As TextArea = New TextArea(Text, X + 5, Y + 20, 215, 60, Font.TimesRoman, 10)
            ' Create an overflow text area for the overflow text
            Dim OverflowTextArea As TextArea = MyTextArea.GetOverflowTextArea(X + 284, Y + 20)
            PageElements.Add(MyTextArea)
            PageElements.Add(OverflowTextArea)
        End Sub

        Private Shared Sub AddCustom(ByVal PageElements As Group, ByVal X As Single, ByVal Y As Single)
            ' Adds a custom page element to the page
            AddCaptionAndRectangle(PageElements, "Custom Page Element", X, Y)
            PageElements.Add(New StopSign(80, Y + 20, 60, 60))
        End Sub

        Private Shared Sub AddNote(ByVal PageElements As Group, ByVal X As Single, ByVal Y As Single)
            ' Add a note element to the page
            AddCaptionAndRectangle(PageElements, "Note Page Element", X, Y)
            PageElements.Add(New Note("This is a note", X + 100, Y + 35, 50, 50, NoteType.Note))
        End Sub

        Private Shared Sub AddTableAndOther(ByVal MyDocument As Document, ByVal ParentOutline As Outline)
            ' Increments a page counter
            pageCounter = pageCounter + 1

            ' Adds to outlines to the page
            ParentOutline.ChildOutlines.Add("Page " + CStr(pageCounter) + " - Table and Additional Page Elements", New ZoomDestination(pageCounter, PageZoom.FitPage))

            ' Create a page to add to the document
            Dim MyPage As Page = New Page(PageSize.Letter, PageOrientation.Portrait, 54)

            ' Uncomment the line below to add a layout grid to the page
            'page.Elements.Add( new LayoutGrid() )

            ' Add the Table and other elements to the page
            AddTable(MyPage.Elements, 0, 0)
            AddListElements(MyPage, 0, 225)
            AddAdditional(MyPage.Elements, 0, 500)

            ' Add the page to the document
            MyDocument.Pages.Add(MyPage)
        End Sub

        Private Shared Sub AddTable(ByVal PageElements As Group, ByVal X As Single, ByVal Y As Single)
            Dim CaptionLabel1 As Label = New Label("Table Page Element", X, Y, 225, 10, Font.HelveticaBold, 10)
            PageElements.Add(CaptionLabel1)
            Dim CaptionLabel2 As Label = New Label("Table Row Overflow", X + 279, Y, 225, 10, Font.HelveticaBold, 10)
            PageElements.Add(CaptionLabel2)
            Dim MyTable As Table2 = New Table2(X, Y + 15, 225, 190, Font.TimesRoman, 10)
            MyTable.RepeatColumnHeaderCount = 1

            ' Add columns to the table
            MyTable.Columns.Add(95)
            MyTable.Columns.Add(65)
            MyTable.Columns.Add(65)

            ' Add the Header Row to the table
            Dim Row1 As Row2 = MyTable.Rows.Add(40, Font.HelveticaBold, 12, RgbColor.Black, RgbColor.LightBlue)
            Row1.CellDefault.Align = TextAlign.Center
            Row1.CellDefault.VAlign = VAlign.Center
            Row1.Cells.Add("Header 1")
            Row1.Cells.Add("Header 2")
            Row1.Cells.Add("Header 3")
            Row1.Cells.Add("Header 4")
            Row1.Cells.Add("Header 5")
            Row1.Cells.Add("Header 6")
            Row1.Cells.Add("Header 7")
            Row1.Cells.Add("Header 8")
            Row1.Cells.Add("Header 9")
            Row1.Cells.Add("Header 10")
            Row1.Cells.Add("Header 11")
            Row1.Cells.Add("Header 12")
            Row1.Cells.Add("Header 13")
            Row1.Cells.Add("Header 14")
            Row1.Cells.Add("Header 15")
            Row1.Cells.Add("Header 16")

            Dim Cell As Integer = 0
            ' Add the rest of the rows to the table
            AddRow(MyTable, Cell, 1)
            AddRow(MyTable, Cell, 2)
            AddRow(MyTable, Cell, 3)
            AddRow(MyTable, Cell, 4)
            AddRow(MyTable, Cell, 5)
            AddRow(MyTable, Cell, 6)
            AddRow(MyTable, Cell, 7)
            AddRow(MyTable, Cell, 8)
            AddRow(MyTable, Cell, 9)
            AddRow(MyTable, Cell, 10)
            AddRow(MyTable, Cell, 11)
            AddRow(MyTable, Cell, 12)
            AddRow(MyTable, Cell, 13)
            AddRow(MyTable, Cell, 14)
            AddRow(MyTable, Cell, 15)
            AddRow(MyTable, Cell, 16)

            ' Create an overflow table for the overflow columns
            Dim OverflowTable As Table2 = MyTable.GetOverflowRows(X + 279, Y + 15)
            PageElements.Add(MyTable)
            PageElements.Add(OverflowTable)
        End Sub

        Private Shared Sub AddRow(ByVal MyTable As Table2, ByRef CellNum As Integer, ByVal RowNum As Integer)
            Dim MyRow As Row2 = MyTable.Rows.Add()
            Dim MyCell As Cell2 = MyRow.Cells.Add("RowHeader " + CStr(RowNum), Font.HelveticaBold, 12,
                    RgbColor.Black, RgbColor.LightPink, 1)
            MyCell.Align = TextAlign.Center
            MyCell.VAlign = VAlign.Center
            CellNum = CellNum + 1
            MyRow.Cells.Add("Item " + CStr(CellNum))
            CellNum = CellNum + 1
            MyRow.Cells.Add("Item " + CStr(CellNum))
        End Sub

        Private Shared Sub AddAdditional(ByVal PageElements As Group, ByVal X As Single, ByVal Y As Single)
            ' Adds text explaining the additional page elements
            Dim Text As String = "An <b><u>AreaGroup</u></b> represents a group of page elements with an area.<p/>" +
              "A <b><u>BackgroundImage</u></b> page element is used to add an image to the background of a page. <p/>" +
              "The <b><u>Group</u></b> page element is used for grouping page elements together.<p/>" +
              "The <b><u>LayoutGrid</u></b> draws a coordinate grid to the page.<p/>" +
              "A <b><u>TransformationGroup</u></b> can rotate and scale a group of page elements.<p/>" +
              "A <b><u>TransparencyGroup</u></b> can be used to add transparency to page elements.<p/>" +
              "An <b><u>Anchor Group </u></b> can have Page Elements within it. It can be anchored to the edge or margins of the page.<p/>"
            Dim MyFormattedTextArea As FormattedTextArea = New FormattedTextArea(Text, X + 5, Y + 20, 494, 180, FontFamily.Times, 12, False)
            MyFormattedTextArea.Style.Paragraph.SpacingAfter = 5
            AddCaptionAndRectangle(PageElements, "Additional Page Elements", X, Y, 504, 180)
            PageElements.Add(MyFormattedTextArea)
        End Sub

        Private Shared Sub AddCaptionAndRectangle(ByVal PageElements As Group, ByVal Caption As String, ByVal X As Single, ByVal Y As Single, ByVal Width As Single, ByVal Height As Single)
            ' Adds a rectangle and caption to the pageElements
            Dim MyRectangle As Rectangle = New Rectangle(X, Y + 15, Width, Height - 15)
            Dim CaptionLabel As Label = New Label(Caption, X, Y, 225, 10, Font.HelveticaBold, 10)
            PageElements.Add(MyRectangle)
            PageElements.Add(CaptionLabel)
        End Sub

        Private Shared Sub AddCaptionAndRectangle(ByVal PageElements As Group, ByVal Caption As String, ByVal X As Single, ByVal Y As Single)
            AddCaptionAndRectangle(PageElements, Caption, X, Y, 225, 85)
        End Sub

        Private Shared Sub AddFormElementPage(ByVal MyDocument As Document, ByVal ParentOutline As Outline)
            pageCounter = pageCounter + 1
            ParentOutline.ChildOutlines.Add("Page " + CStr(pageCounter) + " - Form Page Elements", New ZoomDestination(pageCounter, PageZoom.FitPage))
            ' Create a page to add to the document 
            Dim MyPage As Page = New Page(PageSize.Letter, PageOrientation.Portrait, 54)
            AddTextField(MyPage.Elements, 0, 0)
            AddComboField(MyPage.Elements, 0, 105)
            AddListField(MyPage.Elements, 0, 210)
            AddRadioField(MyPage.Elements, 0, 315)
            AddCheckBoxField(MyPage.Elements, 0, 420)
            AddButtonField(MyPage.Elements, 0, 525)
            ' Add the page to the document 
            MyDocument.Pages.Add(MyPage)
        End Sub

        Private Shared Sub AddListElements(ByVal MyPage As Page, ByVal X As Single, ByVal Y As Single)
            Dim MyOrderedList As OrderedList = New OrderedList(X + 5, Y + 20, 400, 90, Font.Helvetica, 10, NumberingStyle.Numeric)
            MyOrderedList.Items.Add("Fruits")
            MyOrderedList.Items.Add("Vegetables")

            Dim MyOrderedSubList As OrderedSubList = MyOrderedList.Items(0).SubLists.AddOrderedSubList(NumberingStyle.RomanUpperCase)
            MyOrderedSubList.Items.Add("Citrus")
            MyOrderedSubList.Items.Add("Non-Citrus")

            AddCaptionAndRectangle(MyPage.Elements, "Ordered List Page Element", X, Y, 225, 110)
            Dim MyOrderedSubList2 As OrderedSubList = MyOrderedList.Items(1).SubLists.AddOrderedSubList(NumberingStyle.RomanUpperCase)
            MyOrderedSubList2.Items.Add("Potato")
            MyOrderedSubList2.Items.Add("Beans")

            Dim MySubOrderedSubList1 As OrderedSubList = MyOrderedSubList.Items(0).SubLists.AddOrderedSubList(NumberingStyle.RomanLowerCase)
            MySubOrderedSubList1.Items.Add("Lime")
            MySubOrderedSubList1.Items.Add("Orange")

            Dim MySubOrderedSubList2 As OrderedSubList = MyOrderedSubList.Items(1).SubLists.AddOrderedSubList(NumberingStyle.RomanLowerCase)
            MySubOrderedSubList2.Items.Add("Mango")
            MySubOrderedSubList2.Items.Add("Banana")

            Dim MySubOrderedSubList3 As OrderedSubList = MyOrderedSubList2.Items(0).SubLists.AddOrderedSubList(NumberingStyle.RomanLowerCase)
            MySubOrderedSubList3.Items.Add("Sweet Potato")

            Dim MySubOrderedSubList4 As OrderedSubList = MyOrderedSubList2.Items(1).SubLists.AddOrderedSubList(NumberingStyle.RomanLowerCase)
            MySubOrderedSubList4.Items.Add("String Bean")
            MySubOrderedSubList4.Items.Add("Lima Bean")
            MySubOrderedSubList4.Items.Add("Kidney Bean")

            MyPage.Elements.Add(MyOrderedList)
            X = X + 279

            ' Get the overflow from the ordered list
            MyOrderedList = MyOrderedList.GetOverFlowList(X + 5, Y + 20)
            AddCaptionAndRectangle(MyPage.Elements, "Ordered List Page Element Overflow", X, Y, 225, 110)
            MyPage.Elements.Add(MyOrderedList)

            X = 0
            Y += 138
            ' Create unordered list
            Dim MyUnorderedList As UnorderedList = New UnorderedList(X + 5, Y + 20, 400, 90, Font.Helvetica, 10)
            MyUnorderedList.Items.Add("Fruits")
            MyUnorderedList.Items.Add("Vegetables")

            Dim MyUnorderedSubList As UnorderedSubList = MyUnorderedList.Items(0).SubLists.AddUnorderedSubList()
            MyUnorderedSubList.Items.Add(" Citrus")
            MyUnorderedSubList.Items.Add(" Non-Citrus")

            AddCaptionAndRectangle(MyPage.Elements, "Unordered List Page Element", X, Y, 225, 110)

            Dim MyUnorderedSubList2 As UnorderedSubList = MyUnorderedList.Items(1).SubLists.AddUnorderedSubList()
            MyUnorderedSubList2.Items.Add("Potato")
            MyUnorderedSubList2.Items.Add("Beans")

            Dim MySubUnorderedSubList As UnorderedSubList = MyUnorderedSubList.Items(0).SubLists.AddUnorderedSubList()
            MySubUnorderedSubList.Items.Add("Lime")
            MySubUnorderedSubList.Items.Add("Orange")

            Dim MySubUnorderedSubList2 As UnorderedSubList = MyUnorderedSubList.Items(1).SubLists.AddUnorderedSubList()
            MySubUnorderedSubList2.Items.Add("Mango")
            MySubUnorderedSubList2.Items.Add("Banana")

            Dim MySubUnorderedSubList3 As UnorderedSubList = MyUnorderedSubList2.Items(0).SubLists.AddUnorderedSubList()
            MySubUnorderedSubList3.Items.Add("Sweet Potato")

            Dim MySubUnorderedSubList4 As UnorderedSubList = MyUnorderedSubList2.Items(1).SubLists.AddUnorderedSubList()
            MySubUnorderedSubList4.Items.Add("String Bean")
            MySubUnorderedSubList4.Items.Add("Lima Bean")
            MySubUnorderedSubList4.Items.Add("Kidney Bean")

            X = X + 279
            MyPage.Elements.Add(MyUnorderedList)

            ' Get the overflow from the unordered list
            MyUnorderedList = MyUnorderedList.GetOverFlowList(X + 5, Y + 20)
            AddCaptionAndRectangle(MyPage.Elements, "Unordered List Page Element Overflow", X, Y, 225, 110)
            MyPage.Elements.Add(MyUnorderedList)
        End Sub

        Private Shared Sub AddTextField(ByVal PageElements As Group, ByVal X As Single, ByVal Y As Single)
            Dim Txt As TextField = New TextField("txtfname", X + 20, Y + 40, 120, 20) With {
                .DefaultValue = "This is a Scrollable TextField",
                .BorderColor = RgbColor.Black,
                .BackgroundColor = RgbColor.AliceBlue,
                .ToolTip = "Scrollable"
            }
            PageElements.Add(Txt)

            Dim Txt1 As TextField = New TextField("txtf1name", X + 175, Y + 40, 120, 20) With {
                .DefaultValue = "TextField",
                .Password = True,
                .MaxLength = 9,
                .BorderColor = RgbColor.Black,
                .BackgroundColor = RgbColor.AliceBlue,
                .ToolTip = "Password with Maximum Length"
            }
            PageElements.Add(Txt1)

            Dim Txt2 As TextField = New TextField("txtf2name", X + 330, Y + 30, 150, 40) With {
                .DefaultValue = "This is a TextField which goes to the next line if the text exceeds width",
                .MultiLine = True,
                .BorderColor = RgbColor.Black,
                .BackgroundColor = RgbColor.AliceBlue,
                .ToolTip = "Multiline"
            }
            PageElements.Add(Txt2)

            AddCaptionAndRectangle(PageElements, "TextField Form Page Element", X, Y, 504, 85)
        End Sub

        Private Shared Sub AddComboField(ByVal PageElements As Group, ByVal X As Single, ByVal Y As Single)
            Dim MyComboBox As ComboBox = New ComboBox("cmbname", X + 51, Y + 40, 150, 20) With {
                .BorderColor = RgbColor.Black,
                .BackgroundColor = RgbColor.AliceBlue,
                .Font = Font.Helvetica,
                .FontSize = 15
            }
            MyComboBox.Items.Add("Item 1")
            MyComboBox.Items.Add("Item 2")
            MyComboBox.Items.Add("Item 3")
            MyComboBox.Items.Add("Item 4")
            MyComboBox.Items.Add("Editable")
            MyComboBox.Items("Editable").Selected = True
            MyComboBox.Editable = True
            MyComboBox.ToolTip = "Editable Combo Box"
            PageElements.Add(MyComboBox)

            Dim MyComboBox2 As ComboBox = New ComboBox("cmb1name", X + 303, Y + 40, 150, 20) With {
                .BorderColor = RgbColor.Black,
                .BackgroundColor = RgbColor.AliceBlue,
                .Font = Font.Helvetica,
                .FontSize = 15
            }
            MyComboBox2.Items.Add("Item 1")
            MyComboBox2.Items.Add("Item 2")
            MyComboBox2.Items.Add("Item 3")
            MyComboBox2.Items.Add("Item 4")
            MyComboBox2.Items.Add("Non Editable")
            MyComboBox2.Items("Non Editable").Selected = True
            MyComboBox2.Editable = False
            MyComboBox2.ToolTip = "Non Editable Combo Box"
            PageElements.Add(MyComboBox2)

            AddCaptionAndRectangle(PageElements, "ComboBox Form Page Element", X, Y, 504, 85)
        End Sub

        Private Shared Sub AddListField(ByVal PageElements As Group, ByVal X As Single, ByVal Y As Single)
            Dim MyListBox As ListBox = New ListBox("lbname", X + 51, Y + 30, 150, 40) With {
                .BorderColor = RgbColor.Black,
                .BackgroundColor = RgbColor.AliceBlue,
                .Font = Font.Helvetica,
                .FontSize = 15
            }
            MyListBox.Items.Add("Item 1")
            MyListBox.Items.Add("Item 2")
            MyListBox.Items.Add("Item 3")
            MyListBox.Items.Add("Item 4")
            MyListBox.Items.Add("Non MultiSelect")
            MyListBox.Items("Non MultiSelect").Selected = True
            MyListBox.Multiselect = False
            MyListBox.ToolTip = "Simple List Box"
            PageElements.Add(MyListBox)

            Dim MyListBox2 As ListBox = New ListBox("lb1name", X + 303, Y + 30, 150, 40) With {
                .BorderColor = RgbColor.Black,
                .BackgroundColor = RgbColor.AliceBlue,
                .Font = Font.Helvetica,
                .FontSize = 15
            }
            MyListBox2.Items.Add("Item 1")
            MyListBox2.Items.Add("Item 2")
            MyListBox2.Items.Add("Item 3")
            MyListBox2.Items.Add("Item 4")
            MyListBox2.Items("Item 1").Selected = True
            MyListBox2.Items.Add("MultiSelect")
            MyListBox2.Items("MultiSelect").Selected = True
            MyListBox2.Multiselect = True
            MyListBox2.ToolTip = "MultiSelect List Box"
            PageElements.Add(MyListBox2)

            AddCaptionAndRectangle(PageElements, "ListBox Form Page Element", X, Y, 504, 85)
        End Sub

        Private Shared Sub AddRadioField(ByVal PageElements As Group, ByVal X As Single, ByVal Y As Single)
            Dim MyRadioButton As RadioButton = New RadioButton("rbname", X + 40, Y + 42, 12, 12) With {
                .DefaultChecked = True,
                .BackgroundColor = RgbColor.AliceBlue,
                .TextColor = RgbColor.Red,
                .ExportValue = "Radio1"
            }
            Dim MyLabel As Label = New Label("Monthly", X + 75, Y + 43, 60, 15)
            PageElements.Add(MyRadioButton)
            PageElements.Add(MyLabel)

            Dim MyRadioButton2 As RadioButton = New RadioButton("rbname", X + 195, Y + 42, 12, 12) With {
                .BackgroundColor = RgbColor.AliceBlue,
                .TextColor = RgbColor.Green,
                .ExportValue = "Radio2"
            }
            Dim MyLabel2 As Label = New Label("Quarterly", X + 235, Y + 43, 60, 15)
            PageElements.Add(MyRadioButton2)
            PageElements.Add(MyLabel2)

            Dim MyRadioButton3 As RadioButton = New RadioButton("rbname", X + 350, Y + 42, 12, 12) With {
                .BackgroundColor = RgbColor.AliceBlue,
                .TextColor = RgbColor.Blue,
                .ExportValue = "Radio3"
            }
            Dim MyLabel3 As Label = New Label("Yearly", X + 385, Y + 43, 60, 15)
            PageElements.Add(MyRadioButton3)
            PageElements.Add(MyLabel3)

            AddCaptionAndRectangle(PageElements, "RadioButton Form Page Element", X, Y, 504, 85)
        End Sub

        Private Shared Sub AddCheckBoxField(ByVal PageElements As Group, ByVal X As Single, ByVal Y As Single)
            Dim MyCheckBox As CheckBox = New CheckBox("cbxname", X + 40, Y + 42, 15, 15) With {
                .Symbol = Symbol.Check,
                .BackgroundColor = RgbColor.AliceBlue
            }
            Dim MyLabel As Label = New Label("Onion", X + 75, Y + 43, 60, 15)
            PageElements.Add(MyCheckBox)
            PageElements.Add(MyLabel)

            Dim MyCheckBox2 As CheckBox = New CheckBox("cbxsecondname", X + 195, Y + 42, 15, 15) With {
                .Symbol = Symbol.Cross,
                .BackgroundColor = RgbColor.AliceBlue,
                .DefaultChecked = True
            }
            Dim MyLabel2 As Label = New Label("Capsicum", X + 235, Y + 43, 60, 15)
            PageElements.Add(MyCheckBox2)
            PageElements.Add(MyLabel2)

            Dim MyCheckBox3 As CheckBox = New CheckBox("cbxthirdname", X + 350, Y + 42, 15, 15) With {
                .Symbol = Symbol.Star,
                .BackgroundColor = RgbColor.AliceBlue
            }
            Dim MyLabel3 As Label = New Label("Jalapenos", X + 385, Y + 43, 80, 15)
            PageElements.Add(MyCheckBox3)
            PageElements.Add(MyLabel3)

            AddCaptionAndRectangle(PageElements, "CheckBox Form Page Element", X, Y, 504, 85)
        End Sub

        Private Shared Sub AddButtonField(ByVal PageElements As Group, ByVal X As Single, ByVal Y As Single)
            Dim urlToSubmitForm As String = ""
            Dim MyButton As Button = New Button("btonename", X + 40, Y + 40, 100, 25) With {
                .Behavior = Behavior.Push,
                .BorderStyle = BorderStyle.Beveled
            }
            Dim MySubmitAction As SubmitAction = New SubmitAction(urlToSubmitForm)
            MyButton.ToolTip = "Submit Button"
            MyButton.Label = "Submit"
            MyButton.Action = MySubmitAction
            PageElements.Add(MyButton)

            Dim MyButton2 As Button = New Button("bttwoname", X + 195, Y + 40, 100, 25) With {
                .Behavior = Behavior.Push,
                .BorderStyle = BorderStyle.Beveled
            }
            Dim MyResetAction As ResetAction = New ResetAction
            MyButton2.Action = MyResetAction
            MyButton2.ToolTip = "Reset Button"
            MyButton2.Label = "Reset"
            PageElements.Add(MyButton2)

            Dim MyButton3 As Button = New Button("btthreename", X + 350, Y + 40, 100, 25) With {
                .Behavior = Behavior.Push,
                .BorderStyle = BorderStyle.Beveled,
                .Action = New ZoomDestination(pageCounter, PageZoom.FitWidth)
            }
            MyButton3.Behavior = Behavior.CreatePush("Click", "Zoom")
            MyButton3.ToolTip = "Zoom to fit page width"
            MyButton3.Label = "Zoom"
            PageElements.Add(MyButton3)

            Dim MyButton4 As Button = New Button("btfourname", X + 101, Y + 90, 100, 25) With {
                .Behavior = Behavior.Push,
                .BorderStyle = BorderStyle.Beveled,
                .Action = New XYDestination(pageCounter, 100, 100)
            }
            MyButton4.Behavior = Behavior.CreatePush("Click", "Go To XY Destination")
            MyButton4.ToolTip = "Go to XY position"
            MyButton4.Label = "XY"
            PageElements.Add(MyButton4)

            Dim MyButton5 As Button = New Button("btfivename", X + 302, Y + 90, 100, 25) With {
                .Behavior = Behavior.Push,
                .BorderStyle = BorderStyle.Beveled,
                .Action = New JavaScriptAction("app.alert('Hello');"),
                .ToolTip = "Javascript Button",
                .Label = "OK"
            }
            PageElements.Add(MyButton5)

            AddCaptionAndRectangle(PageElements, "Button Form Page Element", X, Y, 504, 140)
        End Sub

        Private Shared Sub AddWatermark(ByVal MyDocument As Document, ByVal ParentOutline As Outline)
            ' Increments a page counter
            pageCounter = pageCounter + 1

            ' Adds to outlines to the page
            'ParentOutline.ChildOutlines.Add("Page " + CStr(PageCounter) + " - 2D and Stacked GS1 Databar Barcodes", New ZoomDestination(PageCounter, PageZoom.FitPage))
            ParentOutline.ChildOutlines.Add("Page " + CStr(pageCounter) + " - Watermark text", New ZoomDestination(pageCounter, PageZoom.FitPage))

            ' Create a page to add to the document
            Dim MyPage As Page = New Page(PageSize.Letter, PageOrientation.Portrait, 54)

            ' Add Heading to the page 
            Dim MyTextArea As TextArea = New TextArea("Text and Image Watermark Page Elements", 0, 235, 225, 10, Font.HelveticaBold, 10)

            ' Add formattedTextArea to page
            MyPage.Elements.Add(MyTextArea)

            ' Create Text watermark
            Dim watermark As TextWatermark = New TextWatermark("Draft")
            watermark.TextColor = Nothing
            watermark.TextOutlineColor = RgbColor.Black

            ' Add Text watermark to page
            MyPage.Elements.Add(watermark)

            ' Create Label and add discription text
            Dim text As String = "Text or Image watermarks can be placed on any page"
            Dim label As Label = New Label(text, 5, 255, 500, 100)
            label.FontSize = 40
            MyPage.Elements.Add(label)

            ' Create a Rectangle
            Dim rect As Rectangle = New Rectangle(0, 250, 500, 100)
            MyPage.Elements.Add(rect)

            ' Set Pdf version to 1.6
            MyDocument.PdfVersion = PdfVersion.v1_6

            ' Add page to document
            MyDocument.Pages.Add(MyPage)
        End Sub
    End Class
End Namespace