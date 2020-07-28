Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements

Public Class TaggedPdfWithStructureElements

    Public Shared Sub Run(outputPdfPath As String)
        ' Create a PDF document 
        ' Specify document as a tagged PDF
        Dim MyDocument As Document = New Document With {
            .Tag = New TagOptions(True)
        }

        ' Create a page and add it to the document
        Dim MyPage As Page = New Page()
        MyDocument.Pages.Add(MyPage)

        ' Create a text area
        Dim MyTextArea1 As TextArea = New TextArea("This is Paragraph one", 0, 0, 512, 100, Font.Helvetica, 15.0F)
        MyTextArea1.Align = TextAlign.Center

        ' Create a structure element of tag type section
        Dim MyParentStrucutreElement As StructureElement = New StructureElement(TagType.Section)

        ' Create a structure element 
        Dim MyStructureElement1 As StructureElement = New StructureElement(TagType.Paragraph)
        MyStructureElement1.IncludeDefaultAttributes = True

        ' Set structure element parent
        MyStructureElement1.Parent = MyParentStrucutreElement

        ' Set strucute element order
        MyStructureElement1.Order = 2

        ' Set structure element to the text area
        MyTextArea1.Tag = MyStructureElement1

        ' Create a text area
        Dim MyTextArea2 As TextArea = New TextArea("This is Paragraph two", 0, 50, 512, 100, Font.Helvetica, 15.0F)
        MyTextArea2.Align = TextAlign.Center

        ' Create a structure element 
        Dim MyStructureElement2 As StructureElement = New StructureElement(TagType.Paragraph)
        MyStructureElement2.IncludeDefaultAttributes = True

        ' Set structure element parent
        MyStructureElement2.Parent = MyParentStrucutreElement

        ' Set strucute element order
        MyStructureElement2.Order = 3

        ' Set structure element to the text area
        MyTextArea2.Tag = MyStructureElement2

        ' Create a text area
        Dim MyTextArea3 As TextArea = New TextArea("This is Paragraph three", 0, 100, 512, 100, Font.Helvetica, 15.0F)
        MyTextArea3.Align = TextAlign.Center

        ' Create a structure element 
        Dim MyStructureElement3 As StructureElement = New StructureElement(TagType.Paragraph)
        MyStructureElement3.IncludeDefaultAttributes = True

        ' Set structure element parent
        MyStructureElement3.Parent = MyParentStrucutreElement

        ' Set strucute element order
        MyStructureElement3.Order = 1

        ' Set structure element to the text area
        MyTextArea3.Tag = MyStructureElement3

        ' Add text areas to the page
        MyPage.Elements.Add(MyTextArea1)
        MyPage.Elements.Add(MyTextArea2)
        MyPage.Elements.Add(MyTextArea3)

        ' Create an image
        Dim MyImage As Image = New Image(Util.GetResourcePath("Images/DPDFLogo.png"), 180.0F, 150.0F, 0.24F)
        MyImage.Height = 200
        MyImage.Width = 200

        ' Create a structure element 
        Dim MyImageStructureElement As StructureElement = New StructureElement(TagType.Figure)
        MyImageStructureElement.IncludeDefaultAttributes = True
        MyImageStructureElement.AlternateText = "DynamicPDF Logo"

        ' Set structure element to the image
        MyImage.Tag = MyImageStructureElement

        ' Add image to the page
        MyPage.Elements.Add(MyImage)

        ' Create an ordered list
        Dim MyOrderedList As OrderedList = New OrderedList(165, 400, 300, 300, Font.Helvetica, 12, NumberingStyle.Numeric)
        MyOrderedList.Items.Add("Fruits")
        MyOrderedList.Items.Add("Vegetables")

        ' Tag the ordered list with the structure element
        MyOrderedList.Tag = New StructureElement(TagType.List)

        Dim MyOrderedSubList As OrderedSubList = MyOrderedList.Items(0).SubLists.AddOrderedSubList(NumberingStyle.RomanUpperCase)
        MyOrderedSubList.Items.Add("Citrus")
        MyOrderedSubList.Items.Add("Non-Citrus")

        ' Tag the item one child lists with the structure element
        MyOrderedList.Items(0).Tag = New StructureElement(TagType.List)

        ' Tag the item one body with the structure element
        MyOrderedList.Items(0).BodyTag = New StructureElement(TagType.ListBody)

        ' Tag the item one bullet with the structure element
        MyOrderedList.Items(0).BulletTag = New StructureElement(TagType.Label)

        ' Tag the item one  with the structure element
        MyOrderedList.Items(0).ListItemTag = New StructureElement(TagType.ListItem)

        ' Tag the sublist with the structure element
        MyOrderedSubList.Tag = New StructureElement(TagType.List)

        ' Create an ordered sublist and add items to it
        Dim MyOrderedSubList2 As OrderedSubList = MyOrderedList.Items(1).SubLists.AddOrderedSubList(NumberingStyle.RomanUpperCase)
        MyOrderedSubList2.Items.Add("Potato")
        MyOrderedSubList2.Items.Add("Beans")

        ' Create an ordered sublist and add items to it
        Dim MySubOrderedSubList1 As OrderedSubList = MyOrderedSubList.Items(0).SubLists.AddOrderedSubList(NumberingStyle.RomanLowerCase)
        MySubOrderedSubList1.Items.Add("Lime")
        MySubOrderedSubList1.Items.Add("Orange")

        ' Create an ordered sublist and add items to it
        Dim MySubOrderedSubList2 As OrderedSubList = MyOrderedSubList.Items(1).SubLists.AddOrderedSubList(NumberingStyle.RomanLowerCase)
        MySubOrderedSubList2.Items.Add("Mango")
        MySubOrderedSubList2.Items.Add("Banana")

        ' Create an ordered sublist and add items to it
        Dim MySubOrderedSubList3 As OrderedSubList = MyOrderedSubList2.Items(0).SubLists.AddOrderedSubList(NumberingStyle.RomanLowerCase)
        MySubOrderedSubList3.Items.Add("Sweet Potato")

        ' Create an ordered sublist and add items to it
        Dim MySubOrderedSubList4 As OrderedSubList = MyOrderedSubList2.Items(1).SubLists.AddOrderedSubList(NumberingStyle.RomanLowerCase)
        MySubOrderedSubList4.Items.Add("String Bean")
        MySubOrderedSubList4.Items.Add("Lima Bean")

        ' Add ordered list to the page
        MyPage.Elements.Add(MyOrderedList)

        ' Create a Page numbering label
        Dim MyPageNumberingLabel As PageNumberingLabel = New PageNumberingLabel("Page %%CP%% of %%TP%%", 0, 680, 512, 12, Font.Helvetica, 12, TextAlign.Center)

        ' Create a artifact and add type
        Dim MyArtifact As Artifact = New Artifact()
        MyArtifact.SetType(ArtifactType.Pagination)

        ' Set artifact to the page numbering label
        MyPageNumberingLabel.Tag = MyArtifact

        ' Add page numbering label to the page
        MyPage.Elements.Add(MyPageNumberingLabel)

        ' Outputs the document to the current web page
        MyDocument.Draw(outputPdfPath)
    End Sub
End Class

