using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using System.Collections.Generic;

namespace coresuite_dotnet_core_console_cs.generator
{
    public class TableReport
    {
        public static List<TableReportData.Table> tableData = TableReportData.Tables;

        public static void Run(string outputPdfPath)
        {
            // Create a document and set it's properties
            Document document = new Document
            {
                Creator = "TableReport",
                Author = "ceTe Software",
                Title = "Table Report"
            };

            //Create a Table and set it's properties
            Table2 table = new Table2(0, 0, 512, 676, Font.Helvetica, 12);
            table.Border.Width = 1f;
            table.CellDefault.Border.Width = 1f;
            table.Border.Color = Grayscale.Black;
            table.RepeatColumnHeaderCount = 1;
            table.RepeatRowHeaderCount = 1;

            // Builds the report
            BuildTable(table);
            int currentRow = 0;
            int currentColumn = 0;
            do
            {
                currentRow++;
                currentColumn = 1;
                AddTableToPage(document, table, currentRow, currentColumn);
                Table2 overflowTable = table.GetOverflowColumns();
                do
                {
                    currentColumn++;
                    AddTableToPage(document, overflowTable, currentRow, currentColumn);
                    overflowTable = overflowTable.GetOverflowColumns();
                } while (overflowTable != null);
                table = table.GetOverflowRows();
            } while (table != null);

            // Outputs the SimpleReport to the current web page
            document.Draw(outputPdfPath);
        }

        public static void AddTableToPage(Document document, Table2 table, int currentRow, int currentColumn)
        {
            Page page = new Page(PageSize.Letter);
            if (table != null)
                page.Elements.Add(table);
            page.Elements.Add(new Label("(" + currentRow + "," + currentColumn + ")", 0, page.Dimensions.Body.Height - 12, page.Dimensions.Body.Width, 12, Font.Helvetica, 12, TextAlign.Center));
            document.Pages.Add(page);
        }

        public static void BuildTable(Table2 table)
        {
            CreateColumns(table);
            CreateRowHeadings(table);
            foreach (var data in tableData)
            {
                CreateRow(table, data);
            }
        }

        public static void CreateRowHeadings(Table2 table)
        {
            Row2 row = table.Rows.Add(40, Font.TimesBold, 12, RgbColor.Black, RgbColor.LightGrey);
            row.CellDefault.Align = TextAlign.Center;
            row.CellDefault.VAlign = VAlign.Top;
            row.Cells.Add("ID");
            row.Cells.Add("Product Name");
            row.Cells.Add("Supplier ID");
            row.Cells.Add("Category ID");
            row.Cells.Add("Quantity Per Unit");
            row.Cells.Add("Unit Price");
            row.Cells.Add("Unit In Stock");
            row.Cells.Add("Units On Order");
            row.Cells.Add("Reorder Level");
            row.Cells.Add("Discontinued");
        }

        public static void CreateRow(Table2 table, TableReportData.Table data)
        {
            Row2 row = table.Rows.Add(20);
            row.Cells.Add(data.ID.ToString(), Font.Helvetica, 12, RgbColor.Black, RgbColor.LightGrey, 1);
            row.Cells.Add(data.ProductName);
            row.Cells.Add(data.SupplierID.ToString());
            row.Cells.Add(data.CategoryID.ToString());
            row.Cells.Add(data.QuantityPerUnit);
            row.Cells.Add(data.UnitPrice.ToString("$0.00"));
            row.Cells.Add(data.UnitInStock.ToString());
            row.Cells.Add(data.UnitsOnOrder.ToString());
            row.Cells.Add(data.ReorderLevel.ToString());
            row.Cells.Add(data.Discontinued.ToString());
        }

        public static void CreateColumns(Table2 table)
        {
            table.Columns.Add(25);
            table.Columns.Add(150);
            table.Columns.Add(90);
            table.Columns.Add(90);
            table.Columns.Add(120);
            table.Columns.Add(60);
            table.Columns.Add(90);
            table.Columns.Add(90);
            table.Columns.Add(90);
            table.Columns.Add(90);
        }    
    }
}
