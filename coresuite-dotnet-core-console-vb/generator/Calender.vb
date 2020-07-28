Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements

    Public Class Calendar

        Public Shared Sub Run(outputPdfPath As String)
            ' Create a MyDocument and set it's properties
            Dim MyDocument As Document = New Document With {
                .Creator = "TableCalendar",
                .Author = "ceTe Software",
                .Title = "Table Calendar Example"
            }

            MyDocument.Pages.Add(CreateCalendarPage(Date.Now))
            MyDocument.Pages.Add(CreateCalendarPage(Date.Now.AddMonths(1)))
            MyDocument.Pages.Add(CreateCalendarPage(Date.Now.AddMonths(2)))

            ' Output the Calendar to the current web MyPage
            MyDocument.Draw(outputPdfPath)
        End Sub

        Private Shared Function CreateCalendarPage(ByVal Today As DateTime) As Page
            Dim MyPage As Page = New Page(PageSize.Letter, PageOrientation.Landscape)
            ' Uncomment the line below to add a loyout grid to the MyPage
            'MyPage.Elements.Add( new LayoutGrid() );

            ' Create a table and set it's properties
            Dim MyTable As Table2 = New Table2(0, 40, MyPage.Dimensions.Body.Width, MyPage.Dimensions.Body.Height - 40, Font.Helvetica, 12)
            MyTable.CellDefault.TextColor = RgbColor.Navy
            MyTable.CellDefault.Border.Color = RgbColor.CornflowerBlue
            MyTable.Border.Color = RgbColor.CornflowerBlue

            AddColumns(MyTable, MyPage.Dimensions.Body.Width)

            CreateDaysOfWeekHeader(MyTable)

            ' Calculate some properties of the month
            Dim StartDay As Integer = (43 - Today.Day + CType(Today.DayOfWeek, Integer)) Mod 7
            Dim DaysInMonth As Integer = DateTime.DaysInMonth(Today.Year, Today.Month)
            Dim RequiredRows As Integer = CType(Math.Ceiling((DaysInMonth + StartDay) / 7.0F), Integer)
            Dim RowHeight As Single = (MyPage.Dimensions.Body.Height - 60) / RequiredRows

            Dim Row As Row2 = Nothing
            Dim Position As Integer = 0

            ' Add a blank entry for Sunday
            If StartDay <> 0 Then
                Row = MyTable.Rows.Add(RowHeight, Font.Helvetica, 14)
                Row.Cells.Add(" ", Font.Helvetica, 15, RgbColor.Red, RgbColor.AliceBlue, 1)
                Position = Position + 1
            End If

            ' Add any additional blank entries days of previous month
            While Position < StartDay
                Row.Cells.Add(" ")
                Position = Position + 1
            End While

            ' Add the days of the month to the MyTable
            Dim Day As Integer
            For Day = 1 To DaysInMonth
                If (Position Mod 7) = 0 Then
                    Row = MyTable.Rows.Add(RowHeight, Font.Helvetica, 14)
                    Row.Cells.Add(Day.ToString(), Font.Helvetica, 14, RgbColor.Red, RgbColor.AliceBlue, 1)
                Else
                    Row.Cells.Add(Day.ToString())
                End If
                Position = Position + 1
            Next

            ' Add any additional blank entries to the end of the table
            While ((Position Mod 7) <> 0)
                Row.Cells.Add(" ")
                Position = Position + 1
            End While

            ' Add the table to the Page
            MyPage.Elements.Add(MyTable)

            ' Create and add a Month label to the calendar
            Dim MyLabel As Label = New Label(Today.ToString("MMMM yyyy"), 0, 0, MyPage.Dimensions.Body.Width, 50, Font.Helvetica, 23, TextAlign.Center, RgbColor.DeepPink)
            MyPage.Elements.Add(MyLabel)

            Return MyPage
        End Function

        Private Shared Sub AddColumns(ByVal MyTable As Table2, ByVal width As Single)
            Dim I As Integer
            For I = 0 To 6
                MyTable.Columns.Add(width / 7)
            Next
        End Sub

        Private Shared Sub CreateDaysOfWeekHeader(ByVal MyTable As Table2)
            Dim Row As Row2 = MyTable.Rows.Add(20, Font.Helvetica, 12)
            Row.Cells.Add(DayOfWeek.Sunday.ToString(), Font.HelveticaBold, 12, RgbColor.Red, RgbColor.AliceBlue, 1)
            Row.Cells.Add(DayOfWeek.Monday.ToString())
            Row.Cells.Add(DayOfWeek.Tuesday.ToString())
            Row.Cells.Add(DayOfWeek.Wednesday.ToString())
            Row.Cells.Add(DayOfWeek.Thursday.ToString())
            Row.Cells.Add(DayOfWeek.Friday.ToString())
            Row.Cells.Add(DayOfWeek.Saturday.ToString())
        End Sub
    End Class

