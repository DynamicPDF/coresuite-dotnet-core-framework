using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using System;

namespace coresuite_dotnet_framework_console_cs.Generator
{
    public class Calender
    {
        public static void Run(string outputPdfPath)
        {
            // Create a document and set it's properties
            Document document = new Document
            {
                Creator = "TableCalendar",
                Author = "ceTe Software",
                Title = "Table Calendar Example"
            };

            document.Pages.Add(CreateCalendarPage(DateTime.Now));
            document.Pages.Add(CreateCalendarPage(DateTime.Now.AddMonths(1)));
            document.Pages.Add(CreateCalendarPage(DateTime.Now.AddMonths(2)));

            // Output the Calendar to the current web page
            document.Draw(outputPdfPath);
        }

        public static Page CreateCalendarPage(DateTime date)
        {
            Page page = new Page(PageSize.Letter, PageOrientation.Landscape);

            // Uncomment the line below to add a loyout grid to the page
            //page.Elements.Add( new LayoutGrid() );

            // Create a table and set it's properties
            Table2 table = new Table2(0, 40, page.Dimensions.Body.Width, page.Dimensions.Body.Height - 40, Font.Helvetica, 12);
            table.CellDefault.TextColor = RgbColor.Navy;
            table.CellDefault.Border.Color = RgbColor.CornflowerBlue;
            table.Border.Color = RgbColor.CornflowerBlue;

            AddColumns(table, page.Dimensions.Body.Width);

            CreateDaysOfWeekHeader(table);

            // Calculate some properties of the month
            int startDay = (43 - date.Day + (int)date.DayOfWeek) % 7;
            int daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);
            int requiredRows = (int)Math.Ceiling((daysInMonth + startDay) / 7.0f);
            float rowHeight = (page.Dimensions.Body.Height - 60) / requiredRows;

            Row2 row = null;
            int position = 0;

            // Add a blank entry for Sunday
            if (startDay != 0)
            {
                row = table.Rows.Add(rowHeight, Font.Helvetica, 14);
                row.Cells.Add(" ", Font.Helvetica, 15, RgbColor.Red, RgbColor.AliceBlue, 1);
                position++;
            }

            // Add any additional blank entries days of previous month
            while (position < startDay)
            {
                row.Cells.Add(" ");
                position++;
            }

            // Add the days of the month to the myTable
            for (int day = 1; day <= daysInMonth; day++)
            {
                if (position++ % 7 == 0)
                {
                    row = table.Rows.Add(rowHeight, Font.Helvetica, 14);
                    row.Cells.Add(day.ToString(), Font.Helvetica, 14, RgbColor.Red, RgbColor.AliceBlue, 1);
                }
                else
                {
                    row.Cells.Add(day.ToString());
                }
            }

            // Add any additional blank entries to the end of the table
            while (position++ % 7 != 0)
            {
                row.Cells.Add(" ");
            }

            // Add the table to the Page
            page.Elements.Add(table);

            // Create and add a Month label to the calendar
            Label label = new Label(date.ToString("MMMM yyyy"), 0, 0, page.Dimensions.Body.Width, 50, Font.Helvetica, 23, TextAlign.Center, RgbColor.DeepPink);
            page.Elements.Add(label);
            return page;
        }

        public static void AddColumns(Table2 table, float width)
        {
            for (int i = 0; i < 7; i++)
                table.Columns.Add(width / 7);
        }

        public static void CreateDaysOfWeekHeader(Table2 table)
        {
            Row2 row = table.Rows.Add(20, Font.Helvetica, 12);
            row.Cells.Add(DayOfWeek.Sunday.ToString(), Font.HelveticaBold, 12, RgbColor.Red, RgbColor.AliceBlue, 1);
            row.Cells.Add(DayOfWeek.Monday.ToString());
            row.Cells.Add(DayOfWeek.Tuesday.ToString());
            row.Cells.Add(DayOfWeek.Wednesday.ToString());
            row.Cells.Add(DayOfWeek.Thursday.ToString());
            row.Cells.Add(DayOfWeek.Friday.ToString());
            row.Cells.Add(DayOfWeek.Saturday.ToString());
        }
    }
}
