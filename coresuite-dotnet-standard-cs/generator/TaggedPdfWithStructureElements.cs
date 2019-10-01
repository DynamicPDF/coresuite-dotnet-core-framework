using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;

namespace coresuite_dotnet_standard_cs.generator
{
    public class TaggedPdfWithStructureElements
    {
        public static void Run(string outputPdfPath)
        {
            // Create a PDF document 
            Document document = new Document();

            // Specify document as a tagged PDF
            document.Tag = new TagOptions(true);

            // Create a page and add it to the document
            Page page = new Page();
            document.Pages.Add(page);

            // Create a text area
            TextArea textArea1 = new TextArea("This is Paragraph one", 0, 0, 512, 100, Font.Helvetica, 15f);
            textArea1.Align = TextAlign.Center;

            // Create a structure element of tag type section
            StructureElement parentStrucutreElement = new StructureElement(TagType.Section);

            // Create a structure element 
            StructureElement structureElement1 = new StructureElement(TagType.Paragraph);
            structureElement1.IncludeDefaultAttributes = true;

            // Set structure element parent
            structureElement1.Parent = parentStrucutreElement;

            // Set strucute element order
            structureElement1.Order = 2;

            // Set structure element to the text area
            textArea1.Tag = structureElement1;

            // Create a text area
            TextArea textArea2 = new TextArea("This is Paragraph two", 0, 50, 512, 100, Font.Helvetica, 15f);
            textArea2.Align = TextAlign.Center;

            // Create a structure element 
            StructureElement structureElement2 = new StructureElement(TagType.Paragraph);
            structureElement2.IncludeDefaultAttributes = true;

            // Set structure element parent
            structureElement2.Parent = parentStrucutreElement;

            // Set strucute element order
            structureElement2.Order = 3;

            // Set structure element to the text area
            textArea2.Tag = structureElement2;

            // Create a text area
            TextArea textArea3 = new TextArea("This is Paragraph three", 0, 100, 512, 100, Font.Helvetica, 15f);
            textArea3.Align = TextAlign.Center;

            // Create a structure element 
            StructureElement structureElement3 = new StructureElement(TagType.Paragraph);
            structureElement3.IncludeDefaultAttributes = true;

            // Set structure element parent
            structureElement3.Parent = parentStrucutreElement;

            // Set strucute element order
            structureElement3.Order = 1;

            // Set structure element to the text area
            textArea3.Tag = structureElement3;

            // Add text areas to the page
            page.Elements.Add(textArea1);
            page.Elements.Add(textArea2);
            page.Elements.Add(textArea3);

            // Create an image
            Image image = new Image(Util.GetResourcePath("Images/DPDFLogo.png"), 180f, 150f, 0.24f);
            image.Height = 200;
            image.Width = 200;

            // Create a structure element 
            StructureElement imageStructureElement = new StructureElement(TagType.Figure);
            imageStructureElement.IncludeDefaultAttributes = true;
            imageStructureElement.AlternateText = "DynamicPDF Logo";

            // Set structure element to the image
            image.Tag = imageStructureElement;

            // Add image to the page
            page.Elements.Add(image);

            // Create an ordered list and add items to it
            OrderedList orderedList = new OrderedList(165, 400, 300, 300, Font.Helvetica, 12);
            orderedList.Items.Add("Fruits");
            orderedList.Items.Add("Vegetables");

            // Tag the ordered list with the structure element
            orderedList.Tag = new StructureElement(TagType.List);

            // Create an ordered sublist and add items to it
            OrderedSubList orderedSubList = orderedList.Items[0].SubLists.AddOrderedSubList(NumberingStyle.RomanUpperCase);
            orderedSubList.Items.Add("Citrus");
            orderedSubList.Items.Add("Non-Citrus");

            // Tag the item one child lists with the structure element
            orderedList.Items[0].Tag = new StructureElement(TagType.List);

            // Tag the item one body with the structure element
            orderedList.Items[0].BodyTag = new StructureElement(TagType.ListBody);

            // Tag the item one bullet with the structure element
            orderedList.Items[0].BulletTag = new StructureElement(TagType.Label);

            // Tag the item one  with the structure element
            orderedList.Items[0].ListItemTag = new StructureElement(TagType.ListItem);

            // Tag the sublist with the structure element
            orderedSubList.Tag = new StructureElement(TagType.List);

            // Create an ordered sublist and add items to it
            OrderedSubList orderedSubList2 = orderedList.Items[1].SubLists.AddOrderedSubList(NumberingStyle.RomanUpperCase);
            orderedSubList2.Items.Add("Potato");
            orderedSubList2.Items.Add("Beans");

            // Create an ordered sublist and add items to it
            OrderedSubList subOrderedSubList = orderedSubList.Items[0].SubLists.AddOrderedSubList(NumberingStyle.RomanLowerCase);
            subOrderedSubList.Items.Add("Lime");
            subOrderedSubList.Items.Add("Orange");

            // Create an ordered sublist and add items to it
            OrderedSubList subOrderedSubList2 = orderedSubList.Items[1].SubLists.AddOrderedSubList(NumberingStyle.RomanLowerCase);
            subOrderedSubList2.Items.Add("Mango");
            subOrderedSubList2.Items.Add("Banana");

            // Create an ordered sublist and add items to it
            OrderedSubList subOrderedSubList3 = orderedSubList2.Items[0].SubLists.AddOrderedSubList(NumberingStyle.RomanLowerCase);
            subOrderedSubList3.Items.Add("Sweet Potato");

            // Create an ordered sublist and add items to it
            OrderedSubList subOrderedSubList4 = orderedSubList2.Items[1].SubLists.AddOrderedSubList(NumberingStyle.RomanLowerCase);
            subOrderedSubList4.Items.Add("String Bean");
            subOrderedSubList4.Items.Add("Lima Bean");

            // Add ordered list to the page
            page.Elements.Add(orderedList);

            // Create a Page numbering label
            PageNumberingLabel pageNumberingLabel = new PageNumberingLabel("Page %%CP%% of %%TP%%", 0, 680, 512, 12, Font.Helvetica,
                  12, TextAlign.Center);

            // Create a artifact and add type
            Artifact artifact = new Artifact();
            artifact.SetType(ArtifactType.Pagination);

            // Set artifact to the page numbering label
            pageNumberingLabel.Tag = artifact;

            // Add page numbering label to the page
            page.Elements.Add(pageNumberingLabel);

            // Outputs the document to the current web page
            document.Draw(outputPdfPath);
        }
    }
}
