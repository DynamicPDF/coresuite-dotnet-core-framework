using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.PageElements.Charting;
using ceTe.DynamicPDF.PageElements.Charting.Axes;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace coresuite_dotnet_core_console_cs.generator
{
    public class Charting
    {
        public static void Run(string outputPdfPath)
        {
            // Create a Document
            Document document = new Document
            {
                Creator = "Charting.aspx",
                Author = "ceTe Software",
                Title = "All Types Of Charts"
            };
            AddCharts(document);

            // Output the PDF
            document.Draw(outputPdfPath);
        }
        public static void AddCharts(Document document)
        {
            // Create a template and assign it to the document
            Template documentTemplate = new Template();
            document.Template = documentTemplate;
            documentTemplate.Elements.Add(new PageNumberingLabel(
                "Page %%CP%% of %%TP%%", 100, 525, 512, 12, Font.Helvetica,
                12, TextAlign.Center));

            // Create a Page
            Page page1 = new Page(PageSize.Letter, PageOrientation.Landscape, 35);
            Page page2 = new Page(PageSize.Letter, PageOrientation.Landscape);

            // Adds charts to the Page
            AddAreaChart(page1.Elements, 0, 40);
            AddPieChart(page1.Elements, 0, 280);
            AddLineChart(page1.Elements, 250, 40);
            AddBarChart(page1.Elements, 250, 280);
            AddColumnChart(page1.Elements, 500, 40);
            AddXYScatterChart(page1.Elements, 500, 280);
            AddMultiTypeSeriesChart(page2.Elements, 20, 50);

            // Add Pages to the document
            document.Pages.Add(page2);
            document.Pages.Add(page1);
        }
        public static void AddAreaChart(Group elements, float x, float y)
        {
            AddCaptionAndRectangle(elements, "Stacked Area Chart", x, y, 225, 225);

            // Create a chart
            Chart chart = new Chart(x + 10, y + 25, 200, 200, Font.Helvetica, 10, RgbColor.Black);

            // Create a plot area
            PlotArea plotArea = chart.PrimaryPlotArea;

            // Create header title and add it to the chart
            Title title1 = new Title("Website Visitors");
            chart.HeaderTitles.Add(title1);

            // Create indexed stacked area series elements and add values to it
            IndexedStackedAreaSeriesElement seriesElement1 = new IndexedStackedAreaSeriesElement("Website A");
            seriesElement1.Values.Add(new float[] { 5, 7, 9, 6 });
            IndexedStackedAreaSeriesElement seriesElement2 = new IndexedStackedAreaSeriesElement("Website B");
            seriesElement2.Values.Add(new float[] { 4, 2, 5, 8 });
            IndexedStackedAreaSeriesElement seriesElement3 = new IndexedStackedAreaSeriesElement("Website C");
            seriesElement3.Values.Add(new float[] { 2, 4, 6, 9 });

            // Create autogradient and assign it to series
            AutoGradient autogradient1 = new AutoGradient(90f, CmykColor.Red, CmykColor.IndianRed);
            seriesElement1.Color = autogradient1;
            AutoGradient autogradient2 = new AutoGradient(90f, CmykColor.Green, CmykColor.YellowGreen);
            seriesElement2.Color = autogradient2;
            AutoGradient autogradient3 = new AutoGradient(120f, CmykColor.Blue, CmykColor.LightBlue);
            seriesElement3.Color = autogradient3;

            // Create a Indexed Stacked Area Series
            IndexedStackedAreaSeries areaSeries = new IndexedStackedAreaSeries();

            // Add indexed stacked area series elements to the Indexed Stacked Area Series
            areaSeries.Add(seriesElement1);
            areaSeries.Add(seriesElement2);
            areaSeries.Add(seriesElement3);

            // Add series to the plot area
            plotArea.Series.Add(areaSeries);

            // Create a title and add it to the YAxis
            Title lTitle = new Title("Visitors (in millions)");
            areaSeries.YAxis.Titles.Add(lTitle);

            //Adding AxisLabels to the XAxis
            areaSeries.XAxis.Labels.Add(new IndexedXAxisLabel("Q1", 0));
            areaSeries.XAxis.Labels.Add(new IndexedXAxisLabel("Q2", 1));
            areaSeries.XAxis.Labels.Add(new IndexedXAxisLabel("Q3", 2));
            areaSeries.XAxis.Labels.Add(new IndexedXAxisLabel("Q4", 3));
            chart.Legends[0].Visible = false;
            elements.Add(chart);
        }
        public static void AddLineChart(Group elements, float x, float y)
        {
            AddCaptionAndRectangle(elements, "Line Chart", x, y, 225, 225);

            // Create a chart
            Chart chart = new Chart(x + 10, y + 25, 200, 200, Font.Helvetica, 10, RgbColor.Black);

            // Create a plot area
            PlotArea plotArea = chart.PrimaryPlotArea;

            // Create header title and add it to the chart
            Title title1 = new Title("Website Visitors");
            chart.HeaderTitles.Add(title1);

            // Create a indexed line series and add values to it
            IndexedLineSeries lineSeries1 = new IndexedLineSeries("Website A");
            lineSeries1.Values.Add(new float[] { 5, 7, 9, 6 });
            IndexedLineSeries lineSeries2 = new IndexedLineSeries("Website B");
            lineSeries2.Values.Add(new float[] { 4, 2, 5, 8 });
            IndexedLineSeries lineSeries3 = new IndexedLineSeries("Website C");
            lineSeries3.Values.Add(new float[] { 2, 4, 6, 9 });

            // Add indexed line series to the plot area
            plotArea.Series.Add(lineSeries1);
            plotArea.Series.Add(lineSeries2);
            plotArea.Series.Add(lineSeries3);

            // Create a title and add it to the yaxis
            Title lTitle = new Title("Visitors (in millions)");
            lineSeries1.YAxis.Titles.Add(lTitle);

            //Adding AxisLabels to the XAxis
            lineSeries1.XAxis.Labels.Add(new IndexedXAxisLabel("Q1", 0));
            lineSeries1.XAxis.Labels.Add(new IndexedXAxisLabel("Q2", 1));
            lineSeries1.XAxis.Labels.Add(new IndexedXAxisLabel("Q3", 2));
            lineSeries1.XAxis.Labels.Add(new IndexedXAxisLabel("Q4", 3));
            chart.Legends[0].Visible = false;
            elements.Add(chart);
        }
        public static void AddPieChart(Group elements, float x, float y)
        {
            AddCaptionAndRectangle(elements, "Pie Chart", x, y, 225, 225);

            // Create a chart
            Chart chart = new Chart(x + 10, y + 25, 200, 200, Font.Helvetica, 10, RgbColor.Black);

            // Add a plot area to the chart
            PlotArea plotArea = chart.PlotAreas.Add(50, 50, 300, 300);

            // Create the Header title and add it to the chart
            Title tTitle = new Title("Website Visitors (in millions)");
            chart.HeaderTitles.Add(tTitle);

            // Create a scalar datalabel
            ScalarDataLabel da = new ScalarDataLabel(true, false, false);

            // Create autogradient colors
            AutoGradient autogradient1 = new AutoGradient(90f, CmykColor.Red, CmykColor.IndianRed);
            AutoGradient autogradient2 = new AutoGradient(90f, CmykColor.Green, CmykColor.YellowGreen);
            AutoGradient autogradient3 = new AutoGradient(90f, CmykColor.Blue, CmykColor.LightBlue);

            // Create a pie series 
            PieSeries pieSeries = new PieSeries();

            // Set scalar datalabel to the pie series
            pieSeries.DataLabel = da;

            // Add series to the plot area
            plotArea.Series.Add(pieSeries);

            //Add pie series elements to the pie series
            pieSeries.Elements.Add(27, "Website A");
            pieSeries.Elements.Add(19, "Website B");
            pieSeries.Elements.Add(21, "Website C");

            // Assign autogradient colors to series elements
            pieSeries.Elements[0].Color = autogradient1;
            pieSeries.Elements[1].Color = autogradient2;
            pieSeries.Elements[2].Color = autogradient3;
            chart.Legends[0].Visible = false;
            elements.Add(chart);
        }
        public static void AddBarChart(Group elements, float x, float y)
        {
            AddCaptionAndRectangle(elements, "Bar Chart", x, y, 225, 225);

            // Create a chart
            Chart chart = new Chart(x + 10, y + 25, 200, 200, Font.Helvetica, 10, RgbColor.Black);

            // Create a plot area
            PlotArea plotArea = chart.PrimaryPlotArea;

            // Create header title and add it to the chart
            Title title1 = new Title("Website Visitors");
            chart.HeaderTitles.Add(title1);

            // Create a indexed bar series and add values to it
            IndexedBarSeries barSeries1 = new IndexedBarSeries("Website A");
            barSeries1.Values.Add(new float[] { 5, 7, 9, 6 });
            IndexedBarSeries barSeries2 = new IndexedBarSeries("Website B");
            barSeries2.Values.Add(new float[] { 4, 2, 5, 8 });
            IndexedBarSeries barSeries3 = new IndexedBarSeries("Website C");
            barSeries3.Values.Add(new float[] { 2, 4, 6, 9 });

            // Create autogradient and assign it to series
            AutoGradient autogradient1 = new AutoGradient(180f, CmykColor.Red, CmykColor.IndianRed);
            barSeries1.Color = autogradient1;
            AutoGradient autogradient2 = new AutoGradient(180f, CmykColor.Green, CmykColor.YellowGreen);
            barSeries2.Color = autogradient2;
            AutoGradient autogradient3 = new AutoGradient(180f, CmykColor.Blue, CmykColor.LightBlue);
            barSeries3.Color = autogradient3;

            // Add indexed bar series to the plot area
            plotArea.Series.Add(barSeries1);
            plotArea.Series.Add(barSeries2);
            plotArea.Series.Add(barSeries3);

            // Create a title and add it to the xaxis
            Title lTitle = new Title("Visitors (in millions)");
            barSeries1.XAxis.Titles.Add(lTitle);

            //Adding AxisLabels to the yAxis
            barSeries1.YAxis.Labels.Add(new IndexedYAxisLabel("Q1", 0));
            barSeries1.YAxis.Labels.Add(new IndexedYAxisLabel("Q2", 1));
            barSeries1.YAxis.Labels.Add(new IndexedYAxisLabel("Q3", 2));
            barSeries1.YAxis.Labels.Add(new IndexedYAxisLabel("Q4", 3));
            chart.Legends[0].Visible = false;
            elements.Add(chart);
        }
        public static void AddColumnChart(Group elements, float x, float y)
        {
            AddCaptionAndRectangle(elements, "100% Stacked Column Chart", x, y, 225, 225);

            // Create a chart
            Chart chart = new Chart(x + 10, y + 25, 200, 200, Font.Helvetica, 10, RgbColor.Black);

            // Create a plot area
            PlotArea plotArea = chart.PrimaryPlotArea;

            // Create header titles and add it to the chart
            Title title1 = new Title("Website Visitors");
            chart.HeaderTitles.Add(title1);

            // Create a indexed 100% column series elements and add values to it
            Indexed100PercentStackedColumnSeriesElement seriesElement1 = new Indexed100PercentStackedColumnSeriesElement("Website A");
            seriesElement1.Values.Add(new float[] { 5, 7, 9, 6 });
            Indexed100PercentStackedColumnSeriesElement seriesElement2 = new Indexed100PercentStackedColumnSeriesElement("Website B");
            seriesElement2.Values.Add(new float[] { 4, 2, 5, 8 });
            Indexed100PercentStackedColumnSeriesElement seriesElement3 = new Indexed100PercentStackedColumnSeriesElement("Website C");
            seriesElement3.Values.Add(new float[] { 2, 4, 6, 9 });

            // Create a Indexed 100% Stacked Column Series
            Indexed100PercentStackedColumnSeries columnSeries = new Indexed100PercentStackedColumnSeries();

            // Add indexed 100% column series elements to the Indexed 100% Stacked Column Series
            columnSeries.Add(seriesElement1);
            columnSeries.Add(seriesElement2);
            columnSeries.Add(seriesElement3);

            // Add series to the plot area
            plotArea.Series.Add(columnSeries);

            // Create a title and add it to the yaxis
            Title lTitle = new Title("Visitors (in millions)");
            columnSeries.YAxis.Titles.Add(lTitle);

            //Adding AxisLabels to the XAxis
            columnSeries.XAxis.Labels.Add(new IndexedXAxisLabel("Q1", 0));
            columnSeries.XAxis.Labels.Add(new IndexedXAxisLabel("Q2", 1));
            columnSeries.XAxis.Labels.Add(new IndexedXAxisLabel("Q3", 2));
            columnSeries.XAxis.Labels.Add(new IndexedXAxisLabel("Q4", 3));
            chart.Legends[0].Visible = false;
            elements.Add(chart);
        }
        public static void AddXYScatterChart(Group elements, float x, float y)
        {
            AddCaptionAndRectangle(elements, "XYScatter Chart", x, y, 225, 225);

            // Create a chart
            Chart chart = new Chart(x + 10, y + 25, 200, 200, Font.Helvetica, 10, RgbColor.Black);

            // Add a plot Area to the chart
            PlotArea plotArea = chart.PrimaryPlotArea;

            // Create a Header title and add it to the chart
            Title tTitle = new Title("Player Height and Weight");
            chart.HeaderTitles.Add(tTitle);

            // Create a xyScatter series and add values to it
            XYScatterSeries xyScatterSeries1 = new XYScatterSeries("Team A");
            xyScatterSeries1.Values.Add(112, 55);
            xyScatterSeries1.Values.Add(125, 60);
            xyScatterSeries1.Values.Add(138, 68);
            xyScatterSeries1.Values.Add(150, 73);
            xyScatterSeries1.Values.Add(172, 80);
            XYScatterSeries xyScatterSeries2 = new XYScatterSeries("Team B");
            xyScatterSeries2.Values.Add(110, 54);
            xyScatterSeries2.Values.Add(128, 62);
            xyScatterSeries2.Values.Add(140, 70);
            xyScatterSeries2.Values.Add(155, 75);
            xyScatterSeries2.Values.Add(170, 80);

            // Add xyScatter series to the plot Area
            plotArea.Series.Add(xyScatterSeries1);
            plotArea.Series.Add(xyScatterSeries2);

            // Create axis titles and add it to the axis
            Title title1 = new Title("Height (inches)");
            Title title2 = new Title("Weight (pounds)");
            xyScatterSeries1.YAxis.Titles.Add(title1);
            xyScatterSeries1.XAxis.Titles.Add(title2);

            // Set XAxis min  value
            xyScatterSeries1.XAxis.Min = 50;

            // Set YAxis min  value
            xyScatterSeries1.YAxis.Min = 100;
            chart.Legends[0].Visible = false;
            elements.Add(chart);
        }
        public static void AddMultiTypeSeriesChart(Group elements, float x, float y)
        {
            AddCaptionAndRectangle(elements, "Plot Area With Different Kinds of Series and Multiple Axis ", x, y, 650, 410);

            // Create a chart
            Chart chart = new Chart(x + 25, y + 37, 600, 350);

            // Create a Auto gradient and set it to chart back ground color
            AutoGradient autogradient = new AutoGradient(90f, CmykColor.LightYellow, CmykColor.LightSkyBlue);
            chart.BackgroundColor = autogradient;

            // Create a plot area
            PlotArea plotArea = chart.PrimaryPlotArea;

            // Create header titles and add it to the chart
            Title title1 = new Title("Company Sales and Website Visitors ");
            title1.Align = Align.Left;
            chart.HeaderTitles.Add(title1);

            // Create a indexed line series and add values to it
            IndexedLineSeries lineSeries1 = new IndexedLineSeries("Website A Visitors");
            lineSeries1.Values.Add(new float[] { 1.5f, 8, 7.5f, 5.5f });
            lineSeries1.Color = RgbColor.DarkBlue;
            IndexedLineSeries lineSeries2 = new IndexedLineSeries("Website B Visitors");
            lineSeries2.Color = RgbColor.LimeGreen;
            lineSeries2.Values.Add(new float[] { 4, 3, 7, 7.5f });

            // Create markers and add it to the series
            Marker marker1 = Marker.GetTriangle(7);
            lineSeries1.Marker = marker1;
            Marker marker2 = Marker.GetCircle(7);
            lineSeries2.Marker = marker2;

            // Add indexed line series to the plot area
            plotArea.Series.Add(lineSeries1);
            plotArea.Series.Add(lineSeries2);

            // Create a NumericYAxis and a title to it
            NumericYAxis numericyaxis1 = new NumericYAxis();
            numericyaxis1.AnchorType = YAxisAnchorType.Right;
            numericyaxis1.Titles.Add(new Title("Sales (in $ millions)"));
            numericyaxis1.Interval = 1;

            // Create a indexed column series and add values to it
            IndexedColumnSeries columnSeries1 = new IndexedColumnSeries("Company A Sales", numericyaxis1);
            columnSeries1.Values.Add(new float[] { 2, 10, 14, 17 });
            columnSeries1.Color = RgbColor.Blue;
            IndexedColumnSeries columnSeries2 = new IndexedColumnSeries("Company B Sales", numericyaxis1);
            columnSeries2.Color = RgbColor.Lime;
            columnSeries2.Values.Add(new float[] { 7, 4, 10, 15 });

            // Create a bar column value position data label
            BarColumnValuePositionDataLabel barColumnValuePositionDataLabel = new BarColumnValuePositionDataLabel(true, true, false);
            columnSeries1.DataLabel = barColumnValuePositionDataLabel;
            barColumnValuePositionDataLabel.FontSize = 7;
            columnSeries1.DataLabel.Prefix = "(";
            columnSeries1.DataLabel.Suffix = ")";
            columnSeries2.DataLabel = barColumnValuePositionDataLabel;

            // Add indexed column series to the plot area
            plotArea.Series.Add(columnSeries1);
            plotArea.Series.Add(columnSeries2);
            YAxisGridLines minorGridLines = new YAxisGridLines();
            minorGridLines.LineStyle = LineStyle.Dots;
            plotArea.YAxes.DefaultNumericAxis.MajorGridLines = new YAxisGridLines();
            plotArea.YAxes.DefaultNumericAxis.MinorGridLines = minorGridLines;
            plotArea.XAxes.DefaultIndexedAxis.MajorGridLines = new XAxisGridLines();
            plotArea.YAxes.DefaultNumericAxis.MinorTickMarks = new YAxisTickMarks();
            plotArea.YAxes.DefaultNumericAxis.MajorTickMarks = new YAxisTickMarks();

            // Add title to Yaxis
            lineSeries1.YAxis.Titles.Add(new Title("Visitors (in millions)"));

            //Adding AxisLabels to the XAxis
            columnSeries1.XAxis.Labels.Add(new IndexedXAxisLabel("Q1", 0));
            columnSeries1.XAxis.Labels.Add(new IndexedXAxisLabel("Q2", 1));
            columnSeries1.XAxis.Labels.Add(new IndexedXAxisLabel("Q3", 2));
            columnSeries1.XAxis.Labels.Add(new IndexedXAxisLabel("Q4", 3));
            chart.Legends[0].BorderStyle = LineStyle.Dots;
            chart.Legends[0].BorderColor = RgbColor.Black;
            chart.Legends[0].BackgroundColor = CmykColor.Lavender;
            elements.Add(chart);
        }
        public static void AddCaptionAndRectangle(Group pageElements, string caption, float x, float y, float width, float height)
        {
            // Adds a rectangle and caption to the pageElements
            Rectangle rectangle = new Rectangle(x, y + 15, width, height - 15);
            Label captionLabel = new Label(caption, x, y, 300, 10, Font.HelveticaBold, 10);
            pageElements.Add(rectangle);
            pageElements.Add(captionLabel);
        }
    }
}
