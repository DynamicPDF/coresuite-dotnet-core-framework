Imports System.Data.SqlClient
Imports Microsoft.Extensions.Configuration
Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements

Namespace coresuite_dotnet_standard_vb.generator
    Public Class ContactList

        'Top, bottom, left and right margins of report
        Public Shared Margin As Single = 36
        'Height of the header
        Public Shared HeaderHeight As Single = 74
        'Height of the footer
        Public Shared FooterHeight As Single = 14
        'Size of paper to use
        Public Shared MyPageDimensions As PageDimensions = New PageDimensions(PageSize.Letter, PageOrientation.Landscape, Margin)
        'Bottom Y coordinate for the body of the report
        Public Shared BodyBottom As Single = MyPageDimensions.Height - (Margin * 2) - FooterHeight

        'Current MyPage that elements are being added to
        Public Shared CurrentPage As Page = Nothing
        'Template for header and footer elements
        Public Shared MyTemplate As Template = Nothing
        'Current Y coordinate where elements are being added
        Public Shared CurrentY As Single = 0
        'Used to control the alternating background
        Public Shared AlternateBG As Boolean = False
        'Used to test for grouping
        Public Shared CurrentFirstI As String = ""

        Public Shared Sub Run(outputPdfPath As String)
            If (MyTemplate Is Nothing) Then
                SetTemplate()
            End If

            'Create a MyDocument and set it's properties
            Dim MyDocument As Document = New Document With {
                .Creator = "ContactList.aspx",
                .Author = "ceTe Software",
                .Title = "Contact List",
                .Template = MyTemplate
            }

            'Establishes connection to the database
            Dim Connection As SqlConnection = GetOpenDBConn()
            Dim Data As SqlDataReader = GetContactListData(Connection)

            'Builds the report
            BuildDocument(MyDocument, Data)

            'Cleans up database connections
            Data.Close()
            Connection.Close()

            'Outputs the ContactList to the current web MyPage
            MyDocument.Draw(outputPdfPath)
        End Sub

        Public Shared Sub SetTemplate()
            MyTemplate = New Template

            ' Uncomment the line below to add a layout grid to the each MyPage
            'MyTemplate.Elements.Add(New LayoutGrid())

            ' Adds header elements to the template
            MyTemplate.Elements.Add(New Image(Util.GetResourcePath("Images/DPDFLogo.png"), 0, 0, 0.21F))
            MyTemplate.Elements.Add(New Label("Northwind Traders", 0, 0, 720, 18, Font.HelveticaBold, 18, TextAlign.Center))
            MyTemplate.Elements.Add(New Label("Contact List", 0, 21, 720, 12, Font.Helvetica, 12, TextAlign.Center))
            MyTemplate.Elements.Add(New Label(DateTime.Now.ToString("dd MMM yyyy, H:mm:ss EST"), 0, 36, 720, 12, Font.Helvetica, 12, TextAlign.Center))
            MyTemplate.Elements.Add(New Rectangle(0, 56, 720, 16, Grayscale.Black, New WebColor("0000A0"), 0.0F))
            MyTemplate.Elements.Add(New Label("Cust ID", 2, 56, 58, 12, Font.HelveticaBold, 12, TextAlign.Left, Grayscale.White))
            MyTemplate.Elements.Add(New Label("Company", 62, 56, 156, 12, Font.HelveticaBold, 12, TextAlign.Left, Grayscale.White))
            MyTemplate.Elements.Add(New Label("Contact", 222, 56, 156, 12, Font.HelveticaBold, 12, TextAlign.Left, Grayscale.White))
            MyTemplate.Elements.Add(New Label("Title", 362, 56, 156, 12, Font.HelveticaBold, 12, TextAlign.Left, Grayscale.White))
            MyTemplate.Elements.Add(New Label("Phone", 522, 56, 86, 12, Font.HelveticaBold, 12, TextAlign.Left, Grayscale.White))
            MyTemplate.Elements.Add(New Label("Fax", 622, 56, 86, 12, Font.HelveticaBold, 12, TextAlign.Left, Grayscale.White))

            ' Adds footer elements to the template
            Dim MyPageNumLabel As PageNumberingLabel = New PageNumberingLabel("Page %%CP(i)%% of %%TP(i)%%", 0, BodyBottom + 5, 720, 10, Font.Helvetica, 10, TextAlign.Center)
            MyTemplate.Elements.Add(MyPageNumLabel)
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
            'Creates TextAreas that are expandable
            Dim CompanyName As TextArea = New TextArea(Data.GetString(2), 62, CurrentY + 3, 156, 11, Font.TimesRoman, 11)
            Dim ContactName As TextArea = New TextArea(Data.GetString(3), 222, CurrentY + 3, 136, 11, Font.TimesRoman, 11)
            Dim ContactTitle As TextArea = New TextArea(Data.GetString(4), 362, CurrentY + 3, 156, 11, Font.TimesRoman, 11)

            'Gets the height required for the current record
            Dim RequiredHeight As Single = SetExpandableRecords(MyDocument, Data, CompanyName, ContactName, ContactTitle)

            'Creates non expandable Labels
            Dim CustomerID As Label = New Label(Data.GetString(0), 2, CurrentY + 3, 58, 11, Font.TimesRoman, 11)
            Dim Phone As Label = New Label(Data.GetString(5), 522, CurrentY + 3, 96, 11, Font.TimesRoman, 11)
            Dim Fax As Label = Nothing
            If Not Data.IsDBNull(6) Then
                Fax = New Label(Data.GetString(6), 622, CurrentY + 3, 96, 11, Font.TimesRoman, 11)
            End If

            'Adds alternating background if required
            If AlternateBG Then
                CurrentPage.Elements.Add(New Rectangle(0, CurrentY, 720, RequiredHeight + 6, Grayscale.Black, New WebColor("E0E0FF"), 0.0F))
            End If

            'Toggles alternating background
            AlternateBG = Not AlternateBG

            'Adds elements to the current MyPage
            CurrentPage.Elements.Add(CustomerID)
            CurrentPage.Elements.Add(CompanyName)
            CurrentPage.Elements.Add(ContactName)
            CurrentPage.Elements.Add(ContactTitle)
            CurrentPage.Elements.Add(Phone)
            If Not Data.IsDBNull(6) Then
                CurrentPage.Elements.Add(Fax)
            End If

            'increments the current Y position on the MyPage
            CurrentY += RequiredHeight + 6
        End Sub

        Public Shared Function SetExpandableRecords(ByVal MyDocument As Document, ByVal Data As SqlDataReader, ByVal CompanyName As TextArea, ByVal ContactName As TextArea, ByVal ContactTitle As TextArea) As Single
            'Gets the maximum height requred of the three TextAreas
            Dim RequiredHeight As Single = GetMaxRecordHeight(CompanyName, ContactName, ContactTitle)

            'Add space for the section header if required
            Dim SectionHeaderHeight As Single = 0
            If CurrentFirstI <> Data.GetString(1) Then
                SectionHeaderHeight = 26
            End If

            'Add a new MyPage if needed
            If BodyBottom < CurrentY + RequiredHeight + SectionHeaderHeight + 4 Then
                AddNewPage(MyDocument)
                If SectionHeaderHeight = 0 Then
                    'Update Y coordinate of TextArea when placed on the new MyPage
                    CompanyName.Y = CurrentY + 3
                    ContactName.Y = CurrentY + 3
                    ContactTitle.Y = CurrentY + 3
                End If
            End If

            'Add section header if required
            If SectionHeaderHeight > 0 Then
                AddSectionHeader(Data)
                CompanyName.Y = CurrentY + 3
                ContactName.Y = CurrentY + 3
                ContactTitle.Y = CurrentY + 3
            End If
            Return RequiredHeight
        End Function

        Public Shared Function GetMaxRecordHeight(ByVal CompanyName As TextArea, ByVal ContactName As TextArea, ByVal ContactTitle As TextArea) As Single
            'Returns the maximum required height of the three TextAreas
            Dim RequiredHeight As Single = 11
            Dim RequiredHeightB As Single = 0

            RequiredHeight = CompanyName.GetRequiredHeight()
            RequiredHeightB = ContactName.GetRequiredHeight()
            If RequiredHeightB > RequiredHeight Then
                RequiredHeight = RequiredHeightB
            End If
            RequiredHeightB = ContactTitle.GetRequiredHeight()
            If RequiredHeightB > RequiredHeight Then
                RequiredHeight = RequiredHeightB
            End If

            If RequiredHeight > 11 Then
                CompanyName.Height = RequiredHeight
                ContactName.Height = RequiredHeight
                ContactTitle.Height = RequiredHeight
            End If

            Return RequiredHeight
        End Function

        Public Shared Sub AddSectionHeader(ByVal Data As SqlDataReader)
            'Adds a section header to the current Y coordinate of the current MyPage
            CurrentFirstI = Data.GetString(1)
            CurrentPage.Elements.Add(New Label("- " + CurrentFirstI + " -", 0, CurrentY + 6, 720, 18, Font.HelveticaBold, 18, TextAlign.Center))

            CurrentY += 26
            AlternateBG = False
        End Sub

        Public Shared Sub AddNewPage(ByVal MyDocument As Document)
            'Adds a new MyPage to the documet
            CurrentPage = New Page(MyPageDimensions)

            CurrentY = HeaderHeight
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
            Command.CommandText = "SELECT CustomerID, FirstL = Left(CompanyName,1), " &
                "CompanyName, ContactName, ContactTitle, Phone, Fax " &
                "FROM Customers ORDER BY CompanyName"
            Dim DataReader As SqlDataReader = Command.ExecuteReader()

            Return DataReader
        End Function

    End Class
End Namespace