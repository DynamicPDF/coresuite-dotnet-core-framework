Imports System
Imports System.Xml
Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements

Namespace coresuite_dotnet_standard_vb.generator

    Public Class SimpleXMLReport
        'Template for document elements
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
            Dim MyDocument As Document = New Document With {
                .Creator = "SimpleXMLReport.aspx",
                .Author = "ceTe Software",
                .Title = "Simple XML Report"
            }

            Dim Reader As XmlTextReader = New XmlTextReader(Util.GetResourcePath("Data/ProductList.xml"))

            'Adds elements to the header groups
            SetTemplate()

            ' Add the template to the MyDocument
            MyDocument.Template = MyTemplate

            'Builds the report
            BuildDocument(MyDocument, Reader)

            'Outputs the SimpleReport to the current web MyPage
            MyDocument.Draw(outputPdfPath)
        End Sub

        Public Shared Sub SetTemplate()
            ' Adds elements to the header template
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

        Public Shared Sub BuildDocument(ByVal MyDocument As Document, ByVal reader As XmlTextReader)
            ' Builds the PDF MyDocument with data from the XML Data
            AddNewPage(MyDocument)
            While reader.Read()
                If reader.NodeType = XmlNodeType.Element And reader.Name = "Products" Then
                    'Add current node to the MyDocument
                    AddRecord(MyDocument, reader)
                End If
            End While
        End Sub

        Public Shared Sub AddRecord(ByVal MyDocument As Document, ByVal reader As XmlTextReader)
            ' Adds a new MyPage to the MyDocument if needed
            If CurrentY > BodyBottom Then AddNewPage(MyDocument)

            ' Adds alternating background to MyDocument if needed
            If AlternateBG Then
                CurrentPage.Elements.Add(New Rectangle(0, CurrentY, 504, 18, Grayscale.Black, New WebColor("E0E0FF"), 0.0F))
            End If

            ' Adds Labels to the MyDocument with data from the current node
            CurrentPage.Elements.Add(New Label(reader.GetAttribute("ProductName"), 2, CurrentY + 2, 236, 11, Font.TimesRoman, 11))
            CurrentPage.Elements.Add(New Label(reader.GetAttribute("QuantityPerUnit"), 242, CurrentY + 2, 156, 11, Font.TimesRoman, 11))
            CurrentPage.Elements.Add(New Label(reader.GetAttribute("UnitPrice"), 402, CurrentY + 2, 100, 11, Font.TimesRoman, 11, TextAlign.Right))

            'Toggles alternating background
            AlternateBG = Not AlternateBG
            'Increments the current Y position on the MyPage
            CurrentY += 18
        End Sub

        Public Shared Sub AddNewPage(ByVal MyDocument As Document)
            'Adds a new MyPage to the MyDocument
            CurrentPage = New Page(MyPageDimensions)

            'Uncomment the line below to add a layout grid to the each MyPage
            'currentPage.Elements.Add(New LayoutGrid())

            CurrentY = BodyTop
            AlternateBG = False

            MyDocument.Pages.Add(CurrentPage)
        End Sub
    End Class
End Namespace