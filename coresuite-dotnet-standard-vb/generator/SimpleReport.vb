Imports System.Data
Imports System.Data.SqlClient
Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements
Imports Microsoft.Extensions.Configuration

Namespace coresuite_dotnet_standard_vb.generator
    Public Class SimpleReport

        ' Template for document elements
        Public Shared MyTemplate As ceTe.DynamicPDF.Template = New ceTe.DynamicPDF.Template()

        'Page Dimensions of MyPages
        Public Shared MyPageDimensions As PageDimensions = New PageDimensions(PageSize.Letter, PageOrientation.Portrait, 54.0F)
        'Current MyPage that elements are being added to
        Public Shared CurrentPage As Page = Nothing
        'Top Y coordinate for the body of the report
        Public Shared BodyTop As Single = 38
        'Bottom Y coordinate for the body of the report
        Public Shared BodyBottom As Single = MyPageDimensions.Body.Bottom - MyPageDimensions.Body.Top
        'Current Y coordinate where elements are being added
        Public Shared CurrentY As Single = 0
        'Used to control the alternating background
        Public Shared AlternateBG As Boolean = False

        Public Shared Sub Run(outputPdfPath As String)
            'Create a MyDocument and set it's properties
            Dim MyDocument As Document = New Document
            MyDocument.Creator = "SimpleReport.aspx"
            MyDocument.Author = "ceTe Software"
            MyDocument.Title = "Simple Report"

            'Adds elements to the header template
            SetTemplate()
            MyDocument.Template = MyTemplate

            'Establises connection to the database
            Dim Connection As SqlConnection = GetOpenDBConn()
            Dim Data As SqlDataReader = GetContactListData(Connection)

            'Builds the report
            BuildDocument(MyDocument, Data)

            'Cleans up database connections
            Data.Close()
            Connection.Close()

            'Outputs the SimpleReport to the current web MyPage
            MyDocument.Draw(outputPdfPath)
        End Sub

        Public Shared Sub SetTemplate()
            'Adds elements to the header tamplate
            MyTemplate.Elements.Add(New Label(DateTime.Now.ToString("dd MMM yyyy, H:mm:ss EST"), 0, 0, 504, 12, Font.HelveticaBold, 12))
            MyTemplate.Elements.Add(New Label("Northwind Product List", 0, 0, 504, 12, Font.HelveticaBold, 12, TextAlign.Center))
            Dim MyPageNumLabel As PageNumberingLabel = New PageNumberingLabel("Page %%CP%% of %%TP%%", 0, 0, 504, 12, Font.HelveticaBold, 12, TextAlign.Right)
            MyTemplate.Elements.Add(MyPageNumLabel)
            MyTemplate.Elements.Add(New Label("Product", 2, 22, 236, 11, Font.TimesBold, 11))
            MyTemplate.Elements.Add(New Label("Qty Per Unit", 242, 22, 156, 11, Font.TimesBold, 11))
            MyTemplate.Elements.Add(New Label("Unit Price", 402, 22, 100, 11, Font.TimesBold, 11, TextAlign.Right))
            MyTemplate.Elements.Add(New Line(0, 36, 504, 36))

            ' Uncomment the line below to add a layout grid to each MyPage
            'MyTemplate.Elements.Add(New LayoutGrid())
        End Sub

        Public Shared Sub BuildDocument(ByVal MyDocument As Document, ByVal Data As SqlDataReader)
            'Builds the PDF MyDocument with data from the DataReader
            AddNewPage(MyDocument)
            While Data.Read()
                'Add current record to the MyDocument
                AddRecord(MyDocument, Data)
            End While
        End Sub

        Public Shared Sub AddRecord(ByVal MyDocument As Document, ByVal Data As SqlDataReader)
            'Adds a new MyPage to the MyDocument if needed
            If CurrentY > BodyBottom Then AddNewPage(MyDocument)

            'Adds alternating background to MyDocument if needed
            If AlternateBG Then
                CurrentPage.Elements.Add(New Rectangle(0, CurrentY, 504, 18, Grayscale.Black, New WebColor("E0E0FF"), 0.0F))
            End If

            'Adds Labels to the MyDocument with data from current record
            CurrentPage.Elements.Add(New Label(Data.GetString(0), 2, CurrentY + 2, 236, 11, Font.TimesRoman, 11))
            CurrentPage.Elements.Add(New Label(Data.GetString(1), 242, CurrentY + 2, 156, 11, Font.TimesRoman, 11))
            CurrentPage.Elements.Add(New Label(Data.GetDecimal(2).ToString("0.00"), 402, CurrentY + 2, 100, 11, Font.TimesRoman, 11, TextAlign.Right))

            'Toggles alternating background
            AlternateBG = Not AlternateBG
            'Increments the current Y position on the MyPage
            CurrentY += 18
        End Sub

        Public Shared Sub AddNewPage(ByVal MyDocument As Document)
            'Adds a new MyPage to the MyDocument
            CurrentPage = New Page(MyPageDimensions)

            CurrentY = BodyTop
            AlternateBG = False

            MyDocument.Pages.Add(CurrentPage)
        End Sub

        Public Shared Function GetOpenDBConn() As SqlConnection
            'Creates and opens a database connection
            Dim Connection As SqlConnection = New SqlConnection(Util.DynamicPDFConfiguration.GetConnectionString("NorthWindConnectionString"))
            Connection.Open()
            Return Connection
        End Function

        Public Shared Function GetContactListData(ByVal Connection As SqlConnection) As SqlDataReader
            'Creates a DataReader for the report
            Dim Command As SqlCommand = Connection.CreateCommand()
            Command.CommandText = "SELECT ProductName, QuantityPerUnit, UnitPrice FROM Products"
            Dim DataReader As SqlDataReader = Command.ExecuteReader()

            Return DataReader
        End Function
    End Class
End Namespace