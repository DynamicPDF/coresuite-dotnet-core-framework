Imports System.Convert
Imports System.Data.SqlClient
Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements
Imports Microsoft.Extensions.Configuration

Public Class MailingLabels
    '/////////////////////////////////////////////////
    ' Begin Setting Region
    ' This settings are for Avery Label number 5160. Modify the settings below based on your label number
    ' Set page dimensions
    Shared TopMargin As String = 36
    Shared BottomMargin As String = 36
    Shared RightMargin As String = 13.5
    Shared LeftMargin As String = 13.5

    'Set the number of labels per page
    Shared MaximumColumns As String = 3
    Shared MaximumRows As String = 10

    'Set the spacing between the labels
    Shared HorizontalSpace As String = 9
    Shared VerticalSpace As String = 0

    'These margins are on the labels themsleves
    Shared LabelTopBottomMargin As String = 5
    Shared LabelLeftRightMargin As String = 15

    ' End Setting Region
    '/////////////////////////////////////////////////

    'Dim the page level variables
    Shared MyDocument As ceTe.DynamicPDF.Document
    Shared MyPage As Page
    Shared CurrentColumn As Integer
    Shared CurrentRow As Integer
    Shared LabelWidth As Single
    Shared LabelHeight As Single
    Shared CompanyName As String
    Shared ContactName As String
    Shared Phone As String
    Shared Fax As String

    Public Shared mailingLablesData As List(Of MailingLabelsData.Customer) = MailingLabelsData.Customers

    Public Shared Sub Run(outputPdfPath As String)
        'Put user code to initialize the page here
        'Create Document object and set properties

        MyDocument = New ceTe.DynamicPDF.Document
        MyPage = New Page(PageSize.Letter, PageOrientation.Portrait)

        MyDocument.Creator = "MailingLabels.aspx"
        MyDocument.Author = "ceTe Software"
        MyDocument.Title = "Mailing Labels"

        'Entrypoint for the labels
        Dim CurrentRow = 1
        Dim CurrentColumn = 1

        'Loop over the RecordSet and add each label 
        For Each data As MailingLabelsData.Customer In mailingLablesData
            CompanyName = SafeDataNull(data.CompanyName)
            ContactName = SafeDataNull(data.ContactName)
            Phone = SafeDataNull(data.Phone)
            Fax = SafeDataNull(data.Fax)

            AddLabel()
        Next

        If MyPage.Elements.Count > 0 Then
            MyDocument.Pages.Add(MyPage)
        End If

        'Outputs the document to the current web page
        MyDocument.Draw(outputPdfPath)

    End Sub

    Public Shared Function FindLabelHeight() As Single

        FindLabelHeight = (MyPage.Dimensions.Height - (MyPage.Dimensions.TopMargin + MyPage.Dimensions.BottomMargin) - ((MaximumRows - 1) * VerticalSpace)) / MaximumRows

    End Function

    Public Shared Function FindLabelWidth() As Single

        FindLabelWidth = (MyPage.Dimensions.Width - (MyPage.Dimensions.RightMargin + MyPage.Dimensions.LeftMargin) - ((MaximumColumns - 1) * HorizontalSpace)) / MaximumColumns

    End Function

    Public Shared Sub AddLabel()

        'Add a new page if you are beyond the maximum Rows
        If CurrentRow = MaximumRows + 1 Then

            MyDocument.Pages.Add(MyPage)

            CurrentRow = 1
        End If

        'Determines if the the label belongs in the first row or first column of the page
        If CurrentColumn > 1 And CurrentRow > 1 Then
            AddToPage()
        ElseIf CurrentColumn > 1 And CurrentRow = 1 Then
            AddToFirstRow()
        ElseIf CurrentColumn = 1 And CurrentRow > 1 Then
            AddToFirstColumn()
        Else
            MyPage = New Page(PageSize.Letter, PageOrientation.Portrait)

            MyPage.Dimensions.TopMargin = TopMargin
            MyPage.Dimensions.BottomMargin = BottomMargin
            MyPage.Dimensions.RightMargin = RightMargin
            MyPage.Dimensions.LeftMargin = LeftMargin

            'Calculates how big the Width and height of each label should be according to the margins and dimensions provided above
            LabelWidth = FindLabelWidth()
            LabelHeight = FindLabelHeight()

            AddToFirstRowColumn()
        End If

        'Incremment your row if you are beyond the maximum columns
        If CurrentColumn = MaximumColumns + 1 Then
            CurrentRow = CurrentRow + 1
            CurrentColumn = 1
        End If
    End Sub

    'Adds the label on at least row 2 column 2 of the page
    Public Shared Sub AddToPage()
        Dim X, Y As Single
        Y = (CurrentRow - 1) * (LabelHeight + VerticalSpace)
        X = (CurrentColumn - 1) * (LabelWidth + HorizontalSpace)
        AddLabelInfo(X, Y)
        CurrentColumn = CurrentColumn + 1
    End Sub

    'Adds the label on the first row of labels
    Public Shared Sub AddToFirstRow()
        Dim X, Y As Single
        Y = 0
        X = (CurrentColumn - 1) * (LabelWidth + HorizontalSpace)
        AddLabelInfo(X, Y)
        CurrentColumn = CurrentColumn + 1
    End Sub

    'Adds the label to the First column of labels
    Public Shared Sub AddToFirstColumn()
        Dim X, Y As Single
        Y = (CurrentRow - 1) * (LabelHeight + VerticalSpace)
        X = 0
        AddLabelInfo(X, Y)
        CurrentColumn = CurrentColumn + 1
    End Sub

    'Adds only the first label of every page (row 1 column 1)
    Public Shared Sub AddToFirstRowColumn()
        Dim X, Y As Single
        Y = 0
        X = 0
        AddLabelInfo(X, Y)
        CurrentColumn = CurrentColumn + 1
    End Sub

    'This is where you format the look of each label
    Public Shared Sub AddLabelInfo(ByVal X As Single, ByVal Y As Single)

        Dim Txt1 As TextArea = New TextArea(CompanyName, X + LabelLeftRightMargin, Y + LabelTopBottomMargin, LabelWidth - (LabelLeftRightMargin * 2), 11, Font.TimesRoman, 11)
        Dim Txt2 As TextArea = New TextArea(ContactName, X + LabelLeftRightMargin, Y + LabelTopBottomMargin + 12, LabelWidth - (LabelLeftRightMargin * 2), 11, Font.TimesRoman, 11)
        Dim Txt3 As TextArea = New TextArea(Phone, X + LabelLeftRightMargin, Y + LabelTopBottomMargin + 24, LabelWidth - (LabelLeftRightMargin * 2), 11, Font.TimesRoman, 11)
        Dim Txt4 As TextArea = New TextArea(Fax, X + LabelLeftRightMargin, Y + LabelTopBottomMargin + 36, LabelWidth - (LabelLeftRightMargin * 2), 11, Font.TimesRoman, 11)

        MyPage.Elements.Add(Txt1)
        MyPage.Elements.Add(Txt2)
        MyPage.Elements.Add(Txt3)
        MyPage.Elements.Add(Txt4)

    End Sub

    Shared Function SafeDataNull(ByVal Value As String) As String
        If Value Is Nothing Then
            Return String.Empty
        Else
            Return Value
        End If
    End Function
End Class

