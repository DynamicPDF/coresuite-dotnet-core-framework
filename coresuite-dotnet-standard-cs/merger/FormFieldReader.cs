using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Merger;
using ceTe.DynamicPDF.Merger.Forms;
using ceTe.DynamicPDF.PageElements;

namespace coresuite_dotnet_standard_cs.merger
{
    public class FormFieldReader
    {
        public static void Run(string outputPdfPath)
        {
            // PDF to read form fields from
            PdfDocument pdfDocument = new PdfDocument(Util.GetResourcePath("PDFs/fw9AcroForm_18_filled.pdf"));

            // Create Table to display the form fields and values
            Table2 table = new Table2(0, 0, 512, 676, Font.Helvetica, 12);
            table.Border.Width = 1;
            table.Border.Color = RgbColor.Black;
            table.RepeatColumnHeaderCount = 1;
            table.RepeatRowHeaderCount = 1;
            BuildTable(table);
            CreateList(table, pdfDocument.Form.Fields);

            Document document = new Document();
            AddTableToPage(document, table);

            Table2 overflowRowTable = table.GetOverflowRows();
            while (overflowRowTable != null)
            {
                AddTableToPage(document, overflowRowTable);
                overflowRowTable = overflowRowTable.GetOverflowRows();
            }
            document.Draw(outputPdfPath);
        }

        private static void BuildTable(Table2 table)
        {
            CreateColumns(table);
            CreateRowHeadings(table);
        }

        private static void CreateList(Table2 table, PdfFormFieldList fieldList)
        {
            for (int i = 0; i < fieldList.Count; i++)
            {
                Row2 row = table.Rows.Add(20);
                row.Cells.Add(fieldList[i].FullName);
                row.Cells.Add(GetFieldType(fieldList[i]));
                row.Cells.Add(fieldList[i].GetValue());
                if (fieldList[i].HasChildFields == true)
                {
                    CreateList(table, fieldList[i].ChildFields);
                }
            }
        }

        private static string GetFieldType(PdfFormField pdfFormField)
        {
            if (pdfFormField is PdfTextField)
            {
                return "Text Field";
            }
            if (pdfFormField is PdfButtonField)
            {
                return "Button Field";
            }
            if (pdfFormField is PdfChoiceField)
            {
                return "Choice Field";
            }
            if (pdfFormField is PdfSignatureField)
            {
                return "Signature Field";
            }
            return "Container Field";
        }

        private static void AddTableToPage(Document document, Table2 table)
        {
            Page page = new Page(PageSize.Letter);
            if (table != null)
                page.Elements.Add(table);
            document.Pages.Add(page);
        }

        private static void CreateRowHeadings(Table2 table)
        {
            Row2 row = table.Rows.Add(40, Font.TimesBold, 12, RgbColor.Black, RgbColor.LightGrey);
            row.CellDefault.Align = TextAlign.Center;
            row.CellDefault.VAlign = VAlign.Top;
            row.Cells.Add("FormField Name");
            row.Cells.Add("FormField Type");
            row.Cells.Add("FormField Value");
        }

        private static void CreateColumns(Table2 table)
        {
            table.Columns.Add(150);
            table.Columns.Add(150);
            table.Columns.Add(212);
        }
    }
}