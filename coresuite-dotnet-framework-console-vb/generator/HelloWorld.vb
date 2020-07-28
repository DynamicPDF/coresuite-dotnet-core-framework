Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements

Public Class HelloWorld

    Public Shared Sub Run(outputPdfPath As String)
        'Create a MyDocument and set it's properties
        Dim MyDocument As Document = New Document With {
            .Creator = "HelloWorld.aspx",
            .Author = "ceTe Software",
            .Title = "Hello World"
        }

        'Create a MyPage to add to the MyDocument
        Dim MyPage As Page = New Page(PageSize.Letter, PageOrientation.Portrait, 54.0F)

        'Uncomment the line below to add a layout grid to the MyPage
        'MyPage.Elements.Add(New LayoutGrid())

        'Create a label to add to the MyPage
        Dim Text As String = "Hello ASPX VB.NET World..." & vbCrLf & "From DynamicPDF Generator for .NET" & vbCrLf & "DynamicPDF.com"
        Dim MyLabel As Label = New Label(Text, 0, 0, 504, 100, Font.Helvetica, 18, TextAlign.Center)

        'Add label to MyPage
        MyPage.Elements.Add(MyLabel)

        'Add MyPage to MyDocument
        MyDocument.Pages.Add(MyPage)

        'Outputs the MyDocument to the current web MyPage
        MyDocument.Draw(outputPdfPath)
    End Sub
End Class

