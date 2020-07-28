Imports ceTe.DynamicPDF.PageElements
Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements.Charting
Imports ceTe.DynamicPDF.PageElements.Charting.Axes
Imports ceTe.DynamicPDF.PageElements.Charting.Series

Public Class Charting

    Public Shared Sub Run(outputPdfPath As String)
        ' Create a PDF Document and Add a Page
        Dim MyDocument As Document = New Document With {
            .Creator = "Charting.aspx",
            .Author = "ceTe Software",
            .Title = "All Types Of Charts"
        }
        AddCharts(MyDocument)

        'Output the PDF
        MyDocument.Draw(outputPdfPath)
    End Sub

    Public Shared Sub AddCharts(ByVal MyDocument As Document)
        ' Create a Template and assign it to the document
        Dim MYDocumentTemplate As Template = New Template()
        MyDocument.Template = MYDocumentTemplate
        MYDocumentTemplate.Elements.Add(New PageNumberingLabel("Page %%CP%% of %%TP%%", 100, 525, 512, 12, Font.Helvetica, 12, TextAlign.Center))

        ' Create a Page
        Dim MyPage1 As Page = New Page(PageSize.Letter, PageOrientation.Landscape, 35)
        Dim MyPage2 As Page = New Page(PageSize.Letter, PageOrientation.Landscape)

        ' Add charts to the page
        AddAreaChart(MyPage1.Elements, 0, 40)
        AddPieChart(MyPage1.Elements, 0, 280)
        AddLineChart(MyPage1.Elements, 250, 40)
        AddBarChart(MyPage1.Elements, 250, 280)
        AddColumnChart(MyPage1.Elements, 500, 40)
        AddXYScatterChart(MyPage1.Elements, 500, 280)
        AddMultiTypeSeriesChart(MyPage2.Elements, 20, 50)

        ' Add page to the Document
        MyDocument.Pages.Add(MyPage2)
        MyDocument.Pages.Add(MyPage1)
    End Sub

    Public Shared Sub AddAreaChart(ByVal Elements As Group, ByVal X As Single, ByVal Y As Single)
        AddCaptionAndRectangle(Elements, "Stacked Area Chart", X, Y, 225, 225)

        ' Create a MyChart
        Dim MyChart As New Chart(X + 10, Y + 25, 200, 200, Font.Helvetica, 10, RgbColor.Black)

        ' Create a plot area
        Dim MyPlotArea As PlotArea = MyChart.PrimaryPlotArea

        ' Create header title and add it to the MyChart
        Dim MyTitle1 As New Title("Website Visitors")
        MyChart.HeaderTitles.Add(MyTitle1)

        'Create indexed stacked are series elements and add values to it
        Dim MySeriesElement1 As New IndexedStackedAreaSeriesElement("Website A")
        MySeriesElement1.Values.Add(New Single() {5, 7, 9, 6})
        Dim MySeriesElement2 As New IndexedStackedAreaSeriesElement("Website B")
        MySeriesElement2.Values.Add(New Single() {4, 2, 5, 8})
        Dim MySeriesElement3 As New IndexedStackedAreaSeriesElement("Website C")
        MySeriesElement3.Values.Add((New Single() {2, 4, 6, 9}))

        ' Add autogradient colors to series
        MySeriesElement1.Color = New AutoGradient(90.0F, CmykColor.Red, CmykColor.IndianRed)
        MySeriesElement2.Color = New AutoGradient(90.0F, CmykColor.Green, CmykColor.YellowGreen)
        MySeriesElement3.Color = New AutoGradient(120.0F, CmykColor.Blue, CmykColor.LightBlue)

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
        MyChart.Legends(0).Visible = False
        Elements.Add(MyChart)
    End Sub

    Public Shared Sub AddLineChart(ByVal Elements As Group, ByVal X As Single, ByVal Y As Single)
        AddCaptionAndRectangle(Elements, "Line Chart", X, Y, 225, 225)

        ' Create a MyChart
        Dim MyChart As New Chart(X + 10, Y + 25, 200, 200, Font.Helvetica, 10, RgbColor.Black)

        ' Create a plot area
        Dim MyPlotArea As PlotArea = MyChart.PrimaryPlotArea

        ' Create header title and add it to the MyChart
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
        MyChart.Legends(0).Visible = False
        Elements.Add(MyChart)
    End Sub

    Public Shared Sub AddPieChart(ByVal Elements As Group, ByVal X As Single, ByVal Y As Single)
        AddCaptionAndRectangle(Elements, "Pie Chart", X, Y, 225, 225)

        ' Create a MyChart
        Dim MyChart As New Chart(X + 10, Y + 25, 200, 200, Font.Helvetica, 10, RgbColor.Black)

        ' Add a plot area to the MyChart
        Dim MyPlotArea As PlotArea = MyChart.PlotAreas.Add(50, 50, 300, 300)

        ' Create the Header title and add it to the MyChart
        Dim MytTitle As New Title("Website Visitors (in millions)")
        MyChart.HeaderTitles.Add(MytTitle)

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

        ' Create autogradient colors 
        Dim MyAutogradient1 As AutoGradient = New AutoGradient(90.0F, CmykColor.Red, CmykColor.IndianRed)
        ' Assign autogradient colors to series elements
        MyPieSeries.Elements(0).Color = MyAutogradient1

        Dim MyAutogradient2 As AutoGradient = New AutoGradient(90.0F, CmykColor.Green, CmykColor.YellowGreen)
        MyPieSeries.Elements(1).Color = MyAutogradient2

        Dim MyAutogradient3 As AutoGradient = New AutoGradient(120.0F, CmykColor.Blue, CmykColor.LightBlue)
        MyPieSeries.Elements(2).Color = MyAutogradient3
        MyChart.Legends(0).Visible = False
        Elements.Add(MyChart)
    End Sub

    Public Shared Sub AddBarChart(ByVal Elements As Group, ByVal X As Single, ByVal Y As Single)
        AddCaptionAndRectangle(Elements, "Bar Chart", X, Y, 225, 225)

        ' Create a MyChart
        Dim MyChart As New Chart(X + 10, Y + 25, 200, 200, Font.Helvetica, 10, RgbColor.Black)

        ' Create a plot area
        Dim MyPlotArea As PlotArea = MyChart.PrimaryPlotArea

        ' Create header title and add it to the MyChart
        Dim MyTitle1 As New Title("Website Visitors")
        MyChart.HeaderTitles.Add(MyTitle1)

        ' Create a indexed bar series and add values to it
        Dim MyBarSeries1 As New IndexedBarSeries("Website A")
        MyBarSeries1.Values.Add(New Single() {5, 7, 9, 6})
        Dim MyBarSeries2 As New IndexedBarSeries("Website B")
        MyBarSeries2.Values.Add(New Single() {4, 2, 5, 8})
        Dim MyBarSeries3 As New IndexedBarSeries("Website C")
        MyBarSeries3.Values.Add(New Single() {2, 4, 6, 9})

        Dim MyAutogradient1 As AutoGradient = New AutoGradient(180.0F, CmykColor.Red, CmykColor.IndianRed)
        MyBarSeries1.Color = MyAutogradient1
        Dim MyAutogradient2 As AutoGradient = New AutoGradient(180.0F, CmykColor.Green, CmykColor.YellowGreen)
        MyBarSeries2.Color = MyAutogradient2
        Dim MyAutogradient3 As AutoGradient = New AutoGradient(180.0F, CmykColor.Blue, CmykColor.LightBlue)
        MyBarSeries3.Color = MyAutogradient3

        ' Add indexed bar series to the plot area
        MyPlotArea.Series.Add(MyBarSeries1)
        MyPlotArea.Series.Add(MyBarSeries2)
        MyPlotArea.Series.Add(MyBarSeries3)

        ' Create a title and add it to the xaxis
        Dim MylTitle As New Title("Visitors (in millions)")
        MyBarSeries1.XAxis.Titles.Add(MylTitle)

        'Adding AxisLabels to the yAxis
        MyBarSeries1.YAxis.Labels.Add(New IndexedYAxisLabel("Q1", 0))
        MyBarSeries1.YAxis.Labels.Add(New IndexedYAxisLabel("Q2", 1))
        MyBarSeries1.YAxis.Labels.Add(New IndexedYAxisLabel("Q3", 2))
        MyBarSeries1.YAxis.Labels.Add(New IndexedYAxisLabel("Q4", 3))
        MyChart.Legends(0).Visible = False
        Elements.Add(MyChart)
    End Sub

    Public Shared Sub AddColumnChart(ByVal Elements As Group, ByVal X As Single, ByVal Y As Single)
        AddCaptionAndRectangle(Elements, "100% Stacked Column Chart", X, Y, 225, 225)

        ' Create a MyChart
        Dim MyChart As New Chart(X + 10, Y + 25, 200, 200, Font.Helvetica, 10, RgbColor.Black)

        ' Create a plot area
        Dim MyPlotArea As PlotArea = MyChart.PrimaryPlotArea

        ' Create header title and add it to the MyChart
        Dim MyTitle1 As New Title("Website Visitors")
        MyChart.HeaderTitles.Add(MyTitle1)

        ' Create a indexed 100% column series elements and add values to it
        Dim MySeriesElement1 As New Indexed100PercentStackedColumnSeriesElement("Website A")
        MySeriesElement1.Values.Add(New Single() {5, 7, 9, 6})
        Dim MySeriesElement2 As New Indexed100PercentStackedColumnSeriesElement("Website B")
        MySeriesElement2.Values.Add(New Single() {4, 2, 5, 8})
        Dim MySeriesElement3 As New Indexed100PercentStackedColumnSeriesElement("Website C")
        MySeriesElement3.Values.Add(New Single() {2, 4, 6, 9})

        ' Create a Indexed 100% Stacked Column Series
        Dim MyColumnSeries As New Indexed100PercentStackedColumnSeries()

        'Add indexed 100% column series elements to the Indexed 100% Stacked Column Series
        MyColumnSeries.Add(MySeriesElement1)
        MyColumnSeries.Add(MySeriesElement2)
        MyColumnSeries.Add(MySeriesElement3)

        ' Add series to the plot area
        MyPlotArea.Series.Add(MyColumnSeries)

        ' Create a title and add it to the yaxis
        Dim MylTitle As New Title("Visitors (in millions)")
        MyColumnSeries.YAxis.Titles.Add(MylTitle)

        'Adding AxisLabels to the XAxis
        MyColumnSeries.XAxis.Labels.Add(New IndexedXAxisLabel("Q1", 0))
        MyColumnSeries.XAxis.Labels.Add(New IndexedXAxisLabel("Q2", 1))
        MyColumnSeries.XAxis.Labels.Add(New IndexedXAxisLabel("Q3", 2))
        MyColumnSeries.XAxis.Labels.Add(New IndexedXAxisLabel("Q4", 3))
        MyChart.Legends(0).Visible = False
        Elements.Add(MyChart)
    End Sub

    Public Shared Sub AddXYScatterChart(ByVal Elements As Group, ByVal X As Single, ByVal Y As Single)
        AddCaptionAndRectangle(Elements, "XYScatter Chart", X, Y, 225, 225)

        ' Create a chart
        Dim MyChart As New Chart(X + 10, Y + 25, 200, 200, Font.Helvetica, 10, RgbColor.Black)

        ' Add a plot Area to the chart
        Dim MyPlotArea As PlotArea = MyChart.PrimaryPlotArea

        ' Create a Header title and add it to the chart
        Dim MytTitle As New Title("Player Height and Weight")
        MyChart.HeaderTitles.Add(MytTitle)

        ' Create a xyScatter series and add values to it
        Dim MyXYScatterSeries1 As New XYScatterSeries("Team A")
        MyXYScatterSeries1.Values.Add(112, 55)
        MyXYScatterSeries1.Values.Add(125, 60)
        MyXYScatterSeries1.Values.Add(138, 68)
        MyXYScatterSeries1.Values.Add(150, 73)
        MyXYScatterSeries1.Values.Add(172, 80)
        Dim MyXYScatterSeries2 As New XYScatterSeries("Team B")
        MyXYScatterSeries2.Values.Add(110, 54)
        MyXYScatterSeries2.Values.Add(128, 62)
        MyXYScatterSeries2.Values.Add(140, 70)
        MyXYScatterSeries2.Values.Add(155, 75)
        MyXYScatterSeries2.Values.Add(170, 80)

        ' Add xyScatter series to the plot Area
        MyPlotArea.Series.Add(MyXYScatterSeries1)
        MyPlotArea.Series.Add(MyXYScatterSeries2)

        ' Create axis titles and add it to the axis
        Dim Mytitle1 As New Title("Height (inches)")
        Dim Mytitle2 As New Title("Weight (pounds)")
        MyXYScatterSeries1.YAxis.Titles.Add(Mytitle1)
        MyXYScatterSeries1.XAxis.Titles.Add(Mytitle2)

        ' Set XAxis min  value
        MyXYScatterSeries1.XAxis.Min = 50

        ' Set YAxis min  value
        MyXYScatterSeries1.YAxis.Min = 100
        MyChart.Legends(0).Visible = False
        Elements.Add(MyChart)
    End Sub

    Public Shared Sub AddMultiTypeSeriesChart(ByVal Elements As Group, ByVal X As Single, ByVal Y As Single)
        AddCaptionAndRectangle(Elements, "Plot Area With Different Kinds of Series and Multiple Axis ", X, Y, 650, 410)

        ' Create a chart
        Dim MyChart As New Chart(X + 25, Y + 37, 600, 350)

        ' Create Autogradient color and assign it to chart background color
        Dim MyAutogradient As AutoGradient = New AutoGradient(90.0F, CmykColor.LightYellow, CmykColor.LightSkyBlue)
        MyChart.BackgroundColor = MyAutogradient

        ' Add a plot Area to the chart
        Dim MyPlotArea As PlotArea = MyChart.PrimaryPlotArea

        ' Create a Header title and add it to the chart
        Dim MytTitle As New Title("Company Sales and Website Visitors ") With {
            .Align = Align.Left
        }
        MyChart.HeaderTitles.Add(MytTitle)

        ' Create a indexed line series and add values to it
        Dim MyLineSeries1 As New IndexedLineSeries("Website A Visitors")
        MyLineSeries1.Values.Add(New Single() {1.5F, 8, 7.5F, 5.5F})
        MyLineSeries1.Color = RgbColor.DarkBlue
        Dim MyLineSeries2 As New IndexedLineSeries("Website B Visitors")
        MyLineSeries2.Values.Add(New Single() {4, 3, 7, 7.5F})
        MyLineSeries2.Color = RgbColor.LimeGreen

        ' Create markers and assign it to the series
        Dim MyMarker1 As Marker = Marker.GetTriangle(7)
        MyLineSeries1.Marker = MyMarker1
        Dim MyMarker2 As Marker = Marker.GetCircle(7)
        MyLineSeries2.Marker = MyMarker2

        ' Add indexed line series to the plot area
        MyPlotArea.Series.Add(MyLineSeries1)
        MyPlotArea.Series.Add(MyLineSeries2)

        ' Create a NumericYAxis and a title to it
        Dim MyNumericyaxis1 As NumericYAxis = New NumericYAxis With {
            .AnchorType = YAxisAnchorType.Right
        }
        MyNumericyaxis1.Titles.Add(New Title("Sales (in $ millions)"))
        MyNumericyaxis1.Interval = 1

        ' Create a indexed column series and add values to it
        Dim MyColumnSeries1 As New IndexedColumnSeries("Company A Sales", MyNumericyaxis1)
        MyColumnSeries1.Values.Add(New Single() {2, 10, 14, 17})
        MyColumnSeries1.Color = RgbColor.Blue
        Dim MyColumnSeries2 As New IndexedColumnSeries("Company B Sales", MyNumericyaxis1)
        MyColumnSeries2.Values.Add(New Single() {7, 4, 10, 15})
        MyColumnSeries2.Color = RgbColor.Lime

        ' Create a bar column value position data label
        Dim MyBarcolumnvaluepositiondatalabel As BarColumnValuePositionDataLabel = New BarColumnValuePositionDataLabel(True, True, False)
        MyColumnSeries1.DataLabel = MyBarcolumnvaluepositiondatalabel
        MyBarcolumnvaluepositiondatalabel.FontSize = 7
        MyColumnSeries1.DataLabel.Prefix = "("
        MyColumnSeries1.DataLabel.Suffix = ")"
        MyColumnSeries2.DataLabel = MyBarcolumnvaluepositiondatalabel

        ' Add indexed column series to the plot area
        MyPlotArea.Series.Add(MyColumnSeries1)
        MyPlotArea.Series.Add(MyColumnSeries2)
        Dim MyMinorGridLines As YAxisGridLines = New YAxisGridLines With {
            .LineStyle = LineStyle.Dots
        }

        ' Create Yaxis Grid lines 
        MyPlotArea.YAxes.DefaultNumericAxis.MajorGridLines = New YAxisGridLines()
        MyPlotArea.YAxes.DefaultNumericAxis.MinorGridLines = MyMinorGridLines
        MyPlotArea.XAxes.DefaultIndexedAxis.MajorGridLines = New XAxisGridLines()
        MyPlotArea.YAxes.DefaultNumericAxis.MinorTickMarks = New YAxisTickMarks()
        MyPlotArea.YAxes.DefaultNumericAxis.MajorTickMarks = New YAxisTickMarks()

        ' Add title to Yaxis
        MyLineSeries1.YAxis.Titles.Add(New Title("Visitors (in millions)"))

        ' Adding AxisLabels to the XAxis
        MyColumnSeries1.XAxis.Labels.Add(New IndexedXAxisLabel("Q1", 0))
        MyColumnSeries1.XAxis.Labels.Add(New IndexedXAxisLabel("Q2", 1))
        MyColumnSeries1.XAxis.Labels.Add(New IndexedXAxisLabel("Q3", 2))
        MyColumnSeries1.XAxis.Labels.Add(New IndexedXAxisLabel("Q4", 3))
        MyChart.Legends(0).BorderStyle = LineStyle.Dots
        MyChart.Legends(0).BorderColor = RgbColor.Black
        MyChart.Legends(0).BackgroundColor = CmykColor.Lavender
        Elements.Add(MyChart)
    End Sub

    Public Shared Sub AddCaptionAndRectangle(ByVal PageElements As Group, ByVal Caption As String, ByVal X As Single, ByVal Y As Single, ByVal Width As Single, ByVal Height As Single)
        ' Adds a rectangle and caption to the pageElements
        Dim MyRectangle As Rectangle = New Rectangle(X, Y + 15, Width, Height - 15)
        Dim CaptionLabel As Label = New Label(Caption, X, Y, 300, 10, Font.HelveticaBold, 10)
        PageElements.Add(MyRectangle)
        PageElements.Add(CaptionLabel)
    End Sub
End Class

