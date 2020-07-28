Imports System.Collections.Generic

Public Class TableReportData
    Public Class Table
        Public Property ID As Integer
        Public Property ProductName As String
        Public Property SupplierID As Integer
        Public Property CategoryID As Integer
        Public Property QuantityPerUnit As String
        Public Property UnitPrice As Decimal
        Public Property UnitInStock As Integer
        Public Property UnitsOnOrder As Integer
        Public Property ReorderLevel As Integer
        Public Property Discontinued As Boolean
    End Class

    Private Shared tables_1 As List(Of Table) = New List(Of Table)() From {
        New Table() With {.ID = 1, .ProductName = "Chai", .SupplierID = 1, .CategoryID = 1, .QuantityPerUnit = "10 boxes x 20 bags", .UnitPrice = 18, .UnitInStock = 39, .UnitsOnOrder = 0, .ReorderLevel = 10, .Discontinued = False},
        New Table() With {.ID = 2, .ProductName = "Chang", .SupplierID = 1, .CategoryID = 1, .QuantityPerUnit = "24 - 12 oz bottles", .UnitPrice = 19, .UnitInStock = 17, .UnitsOnOrder = 40, .ReorderLevel = 25, .Discontinued = False},
        New Table() With {.ID = 3, .ProductName = "Aniseed Syrup", .SupplierID = 1, .CategoryID = 2, .QuantityPerUnit = "12 - 550 ml bottles", .UnitPrice = 10, .UnitInStock = 13, .UnitsOnOrder = 70, .ReorderLevel = 25, .Discontinued = False},
        New Table() With {.ID = 4, .ProductName = "Chef Anton's Cajun Seasoning", .SupplierID = 2, .CategoryID = 2, .QuantityPerUnit = "48 - 6 oz jars", .UnitPrice = 22, .UnitInStock = 53, .UnitsOnOrder = 0, .ReorderLevel = 0, .Discontinued = False},
        New Table() With {.ID = 5, .ProductName = "Chef Anton's Gumbo Mix", .SupplierID = 2, .CategoryID = 2, .QuantityPerUnit = "36 boxes", .UnitPrice = 21.35D, .UnitInStock = 0, .UnitsOnOrder = 0, .ReorderLevel = 0, .Discontinued = True},
        New Table() With {.ID = 6, .ProductName = "Grandma's Boysenberry Spread", .SupplierID = 3, .CategoryID = 2, .QuantityPerUnit = "12 - 8 oz jars", .UnitPrice = 25, .UnitInStock = 120, .UnitsOnOrder = 0, .ReorderLevel = 25, .Discontinued = False},
        New Table() With {.ID = 7, .ProductName = "Uncle Bob's Organic Dried Pears", .SupplierID = 3, .CategoryID = 7, .QuantityPerUnit = "12 - 1 lb pkgs.", .UnitPrice = 30, .UnitInStock = 15, .UnitsOnOrder = 0, .ReorderLevel = 10, .Discontinued = False},
        New Table() With {.ID = 8, .ProductName = "Northwoods Cranberry Sauce", .SupplierID = 3, .CategoryID = 2, .QuantityPerUnit = "12 - 12 oz jars", .UnitPrice = 40, .UnitInStock = 6, .UnitsOnOrder = 0, .ReorderLevel = 0, .Discontinued = False},
        New Table() With {.ID = 9, .ProductName = "Mishi Kobe Niku", .SupplierID = 4, .CategoryID = 6, .QuantityPerUnit = "18 - 500 g pkgs.", .UnitPrice = 97, .UnitInStock = 29, .UnitsOnOrder = 0, .ReorderLevel = 0, .Discontinued = True},
        New Table() With {.ID = 10, .ProductName = "Ikura", .SupplierID = 4, .CategoryID = 8, .QuantityPerUnit = "12 - 200 ml jars", .UnitPrice = 31, .UnitInStock = 31, .UnitsOnOrder = 0, .ReorderLevel = 0, .Discontinued = False},
        New Table() With {.ID = 11, .ProductName = "Queso Cabrales", .SupplierID = 5, .CategoryID = 4, .QuantityPerUnit = "1 kg pkg.", .UnitPrice = 21, .UnitInStock = 22, .UnitsOnOrder = 30, .ReorderLevel = 30, .Discontinued = False},
        New Table() With {.ID = 12, .ProductName = "Queso Manchego La Pastora", .SupplierID = 5, .CategoryID = 4, .QuantityPerUnit = "10 - 500 g pkgs.", .UnitPrice = 38, .UnitInStock = 86, .UnitsOnOrder = 0, .ReorderLevel = 0, .Discontinued = False},
        New Table() With {.ID = 13, .ProductName = "Konbu", .SupplierID = 6, .CategoryID = 8, .QuantityPerUnit = "2 kg box", .UnitPrice = 6, .UnitInStock = 24, .UnitsOnOrder = 0, .ReorderLevel = 5, .Discontinued = False},
        New Table() With {.ID = 14, .ProductName = "Tofu", .SupplierID = 6, .CategoryID = 7, .QuantityPerUnit = "40 - 100 g pkgs.", .UnitPrice = 23.25D, .UnitInStock = 35, .UnitsOnOrder = 0, .ReorderLevel = 0, .Discontinued = False},
        New Table() With {.ID = 15, .ProductName = "Genen Shouyu", .SupplierID = 6, .CategoryID = 2, .QuantityPerUnit = "24 - 250 ml bottles", .UnitPrice = 15.5D, .UnitInStock = 39, .UnitsOnOrder = 0, .ReorderLevel = 5, .Discontinued = False},
        New Table() With {.ID = 16, .ProductName = "Pavlova", .SupplierID = 7, .CategoryID = 3, .QuantityPerUnit = "32 - 500 g boxes", .UnitPrice = 17.45D, .UnitInStock = 29, .UnitsOnOrder = 0, .ReorderLevel = 0, .Discontinued = False},
        New Table() With {.ID = 17, .ProductName = "Alice Mutton", .SupplierID = 7, .CategoryID = 6, .QuantityPerUnit = "20 - 1 kg tins", .UnitPrice = 39, .UnitInStock = 0, .UnitsOnOrder = 0, .ReorderLevel = 5, .Discontinued = True},
        New Table() With {.ID = 18, .ProductName = "Carnarvon Tigers", .SupplierID = 7, .CategoryID = 8, .QuantityPerUnit = "16 kg pkg.", .UnitPrice = 62.5D, .UnitInStock = 42, .UnitsOnOrder = 0, .ReorderLevel = 10, .Discontinued = False},
        New Table() With {.ID = 19, .ProductName = "Teatime Chocolate Biscuits", .SupplierID = 8, .CategoryID = 3, .QuantityPerUnit = "10 boxes x 12 pieces", .UnitPrice = 9.2D, .UnitInStock = 25, .UnitsOnOrder = 0, .ReorderLevel = 0, .Discontinued = False},
        New Table() With {.ID = 20, .ProductName = "Sir Rodney's Marmalade", .SupplierID = 8, .CategoryID = 3, .QuantityPerUnit = "30 gift boxes", .UnitPrice = 81, .UnitInStock = 40, .UnitsOnOrder = 0, .ReorderLevel = 0, .Discontinued = False},
        New Table() With {.ID = 21, .ProductName = "Sir Rodney's Scones", .SupplierID = 8, .CategoryID = 3, .QuantityPerUnit = "24 pkgs. x 4 pieces", .UnitPrice = 10, .UnitInStock = 3, .UnitsOnOrder = 40, .ReorderLevel = 5, .Discontinued = False},
        New Table() With {.ID = 22, .ProductName = "Gustaf's Knäckebröd", .SupplierID = 9, .CategoryID = 5, .QuantityPerUnit = "24 - 500 g pkgs.", .UnitPrice = 21, .UnitInStock = 104, .UnitsOnOrder = 0, .ReorderLevel = 25, .Discontinued = False},
        New Table() With {.ID = 23, .ProductName = "Tunnbröd", .SupplierID = 9, .CategoryID = 5, .QuantityPerUnit = "12 - 250 g pkgs.", .UnitPrice = 9, .UnitInStock = 61, .UnitsOnOrder = 0, .ReorderLevel = 25, .Discontinued = False},
        New Table() With {.ID = 24, .ProductName = "Guaraná Fantástica", .SupplierID = 10, .CategoryID = 1, .QuantityPerUnit = "12 - 355 ml cans", .UnitPrice = 4.5D, .UnitInStock = 20, .UnitsOnOrder = 0, .ReorderLevel = 0, .Discontinued = True},
        New Table() With {.ID = 25, .ProductName = "NuNuCa Nuß-Nougat- Creme", .SupplierID = 11, .CategoryID = 3, .QuantityPerUnit = "20 - 450 g glasses", .UnitPrice = 14, .UnitInStock = 76, .UnitsOnOrder = 0, .ReorderLevel = 30, .Discontinued = False},
        New Table() With {.ID = 26, .ProductName = "Gumbär Gummibärchen", .SupplierID = 11, .CategoryID = 3, .QuantityPerUnit = "100 - 250 g bags", .UnitPrice = 31.23D, .UnitInStock = 15, .UnitsOnOrder = 0, .ReorderLevel = 0, .Discontinued = False},
        New Table() With {.ID = 27, .ProductName = "Schoggi Schokolade", .SupplierID = 11, .CategoryID = 3, .QuantityPerUnit = "100 - 100 g pieces", .UnitPrice = 43.9D, .UnitInStock = 46, .UnitsOnOrder = 0, .ReorderLevel = 30, .Discontinued = False},
        New Table() With {.ID = 28, .ProductName = "Rössle Sauerkraut", .SupplierID = 12, .CategoryID = 7, .QuantityPerUnit = "25 - 825 g cans", .UnitPrice = 45.6D, .UnitInStock = 26, .UnitsOnOrder = 0, .ReorderLevel = 0, .Discontinued = True},
        New Table() With {.ID = 29, .ProductName = "Thüringer Rostbratwurst", .SupplierID = 12, .CategoryID = 7, .QuantityPerUnit = "50 bags x 30 sausgs.", .UnitPrice = 45.6D, .UnitInStock = 0, .UnitsOnOrder = 0, .ReorderLevel = 0, .Discontinued = True},
        New Table() With {.ID = 30, .ProductName = "Nord-Ost Matjeshering", .SupplierID = 12, .CategoryID = 6, .QuantityPerUnit = "10 - 200 g glasses", .UnitPrice = 12.79D, .UnitInStock = 10, .UnitsOnOrder = 0, .ReorderLevel = 15, .Discontinued = False},
        New Table() With {.ID = 31, .ProductName = "Gorgonzola Telino", .SupplierID = 13, .CategoryID = 8, .QuantityPerUnit = "12 - 100 g pkgs", .UnitPrice = 25.89D, .UnitInStock = 0, .UnitsOnOrder = 70, .ReorderLevel = 20, .Discontinued = False},
        New Table() With {.ID = 32, .ProductName = "Mascarpone Fabioli", .SupplierID = 14, .CategoryID = 4, .QuantityPerUnit = "24 - 200 g pkgs.", .UnitPrice = 12.5D, .UnitInStock = 9, .UnitsOnOrder = 40, .ReorderLevel = 25, .Discontinued = False},
        New Table() With {.ID = 33, .ProductName = "Geitost", .SupplierID = 14, .CategoryID = 4, .QuantityPerUnit = "500 g", .UnitPrice = 32, .UnitInStock = 112, .UnitsOnOrder = 0, .ReorderLevel = 15, .Discontinued = False},
        New Table() With {.ID = 34, .ProductName = "Sasquatch Ale", .SupplierID = 15, .CategoryID = 4, .QuantityPerUnit = "24 - 12 oz bottles", .UnitPrice = 2.5D, .UnitInStock = 111, .UnitsOnOrder = 0, .ReorderLevel = 15, .Discontinued = False},
        New Table() With {.ID = 35, .ProductName = "Steeleye Stout", .SupplierID = 16, .CategoryID = 1, .QuantityPerUnit = "24 - 12 oz bottles", .UnitPrice = 14, .UnitInStock = 20, .UnitsOnOrder = 0, .ReorderLevel = 20, .Discontinued = False},
        New Table() With {.ID = 36, .ProductName = "Inlagd Sill", .SupplierID = 16, .CategoryID = 1, .QuantityPerUnit = "24 - 250 g jars", .UnitPrice = 18, .UnitInStock = 112, .UnitsOnOrder = 0, .ReorderLevel = 25, .Discontinued = False},
        New Table() With {.ID = 37, .ProductName = "Gravad lax", .SupplierID = 17, .CategoryID = 8, .QuantityPerUnit = "12 - 500 g pkgs.", .UnitPrice = 19, .UnitInStock = 11, .UnitsOnOrder = 50, .ReorderLevel = 0, .Discontinued = False},
        New Table() With {.ID = 38, .ProductName = "Côte de Blaye", .SupplierID = 17, .CategoryID = 8, .QuantityPerUnit = "12 - 75 cl bottles", .UnitPrice = 26, .UnitInStock = 17, .UnitsOnOrder = 0, .ReorderLevel = 30, .Discontinued = False},
        New Table() With {.ID = 39, .ProductName = "Chartreuse verte", .SupplierID = 18, .CategoryID = 1, .QuantityPerUnit = "750 cc per bottle", .UnitPrice = 26.3D, .UnitInStock = 69, .UnitsOnOrder = 0, .ReorderLevel = 5, .Discontinued = False},
        New Table() With {.ID = 40, .ProductName = "Boston Crab Meat", .SupplierID = 18, .CategoryID = 1, .QuantityPerUnit = "24 - 4 oz tins", .UnitPrice = 18, .UnitInStock = 123, .UnitsOnOrder = 0, .ReorderLevel = 20, .Discontinued = False},
        New Table() With {.ID = 41, .ProductName = "Jack's New England Clam Chowder", .SupplierID = 19, .CategoryID = 8, .QuantityPerUnit = "12 - 12 oz cans", .UnitPrice = 9.65D, .UnitInStock = 85, .UnitsOnOrder = 0, .ReorderLevel = 5, .Discontinued = False},
        New Table() With {.ID = 42, .ProductName = "Singaporean Hokkien Fried Mee", .SupplierID = 19, .CategoryID = 8, .QuantityPerUnit = "32 - 1 kg pkgs.", .UnitPrice = 14, .UnitInStock = 26, .UnitsOnOrder = 0, .ReorderLevel = 15, .Discontinued = True},
        New Table() With {.ID = 43, .ProductName = "Ipoh Coffee", .SupplierID = 20, .CategoryID = 5, .QuantityPerUnit = "16 - 500 g tins", .UnitPrice = 46, .UnitInStock = 17, .UnitsOnOrder = 19, .ReorderLevel = 40, .Discontinued = False},
        New Table() With {.ID = 44, .ProductName = "Gula Malacca", .SupplierID = 20, .CategoryID = 1, .QuantityPerUnit = "20 - 2 kg bags", .UnitPrice = 19.45D, .UnitInStock = 27, .UnitsOnOrder = 0, .ReorderLevel = 30, .Discontinued = False},
        New Table() With {.ID = 45, .ProductName = "Rogede sild", .SupplierID = 20, .CategoryID = 2, .QuantityPerUnit = "1k pkg.", .UnitPrice = 9.5D, .UnitInStock = 5, .UnitsOnOrder = 70, .ReorderLevel = 0, .Discontinued = False},
        New Table() With {.ID = 46, .ProductName = "Spegesild", .SupplierID = 21, .CategoryID = 8, .QuantityPerUnit = "4 - 450 g glasses", .UnitPrice = 12.75D, .UnitInStock = 95, .UnitsOnOrder = 0, .ReorderLevel = 15, .Discontinued = False},
        New Table() With {.ID = 47, .ProductName = "Zaanse koeken", .SupplierID = 21, .CategoryID = 8, .QuantityPerUnit = "", .UnitPrice = 20, .UnitInStock = 36, .UnitsOnOrder = 0, .ReorderLevel = 20, .Discontinued = False},
        New Table() With {.ID = 48, .ProductName = "Chocolade", .SupplierID = 22, .CategoryID = 3, .QuantityPerUnit = "10 - 4 oz boxes", .UnitPrice = 16.25D, .UnitInStock = 15, .UnitsOnOrder = 70, .ReorderLevel = 0, .Discontinued = False},
        New Table() With {.ID = 49, .ProductName = "Maxilaku", .SupplierID = 22, .CategoryID = 3, .QuantityPerUnit = "10 pkgs.", .UnitPrice = 53, .UnitInStock = 10, .UnitsOnOrder = 60, .ReorderLevel = 0, .Discontinued = False},
        New Table() With {.ID = 50, .ProductName = "Valkoinen suklaa", .SupplierID = 23, .CategoryID = 3, .QuantityPerUnit = "24 - 50 g pkgs.", .UnitPrice = 7, .UnitInStock = 65, .UnitsOnOrder = 0, .ReorderLevel = 30, .Discontinued = False},
        New Table() With {.ID = 51, .ProductName = "Manjimup Dried Apples", .SupplierID = 23, .CategoryID = 3, .QuantityPerUnit = "12 - 100 g bars", .UnitPrice = 32.8D, .UnitInStock = 20, .UnitsOnOrder = 0, .ReorderLevel = 5, .Discontinued = False},
        New Table() With {.ID = 52, .ProductName = "Filo Mix", .SupplierID = 24, .CategoryID = 7, .QuantityPerUnit = "50 - 300 g pkgs.", .UnitPrice = 74.5D, .UnitInStock = 38, .UnitsOnOrder = 0, .ReorderLevel = 20, .Discontinued = False},
        New Table() With {.ID = 53, .ProductName = "Perth Pasties", .SupplierID = 24, .CategoryID = 5, .QuantityPerUnit = "16 - 2 kg boxes", .UnitPrice = 24, .UnitInStock = 0, .UnitsOnOrder = 0, .ReorderLevel = 15, .Discontinued = False},
        New Table() With {.ID = 54, .ProductName = "Tourtière", .SupplierID = 24, .CategoryID = 6, .QuantityPerUnit = "48 pieces", .UnitPrice = 38, .UnitInStock = 21, .UnitsOnOrder = 0, .ReorderLevel = 30, .Discontinued = True},
        New Table() With {.ID = 55, .ProductName = "Pâté chinois", .SupplierID = 25, .CategoryID = 6, .QuantityPerUnit = "16 pies", .UnitPrice = 19, .UnitInStock = 115, .UnitsOnOrder = 0, .ReorderLevel = 30, .Discontinued = False},
        New Table() With {.ID = 56, .ProductName = "Gnocchi di nonna Alice", .SupplierID = 25, .CategoryID = 6, .QuantityPerUnit = "24 boxes x 2 pies", .UnitPrice = 30, .UnitInStock = 21, .UnitsOnOrder = 10, .ReorderLevel = 30, .Discontinued = False},
        New Table() With {.ID = 57, .ProductName = "Ravioli Angelo", .SupplierID = 26, .CategoryID = 5, .QuantityPerUnit = "24 - 250 g pkgs.", .UnitPrice = 6.7D, .UnitInStock = 36, .UnitsOnOrder = 0, .ReorderLevel = 30, .Discontinued = False},
        New Table() With {.ID = 58, .ProductName = "Escargots de Bourgogne", .SupplierID = 27, .CategoryID = 6, .QuantityPerUnit = "24 pieces", .UnitPrice = 22, .UnitInStock = 62, .UnitsOnOrder = 0, .ReorderLevel = 20, .Discontinued = False},
        New Table() With {.ID = 59, .ProductName = "Raclette Courdavault", .SupplierID = 28, .CategoryID = 8, .QuantityPerUnit = "5 kg pkg.", .UnitPrice = 13.25D, .UnitInStock = 79, .UnitsOnOrder = 0, .ReorderLevel = 0, .Discontinued = False},
        New Table() With {.ID = 60, .ProductName = "Camembert Pierrot", .SupplierID = 28, .CategoryID = 4, .QuantityPerUnit = "15 - 300 g rounds", .UnitPrice = 55, .UnitInStock = 19, .UnitsOnOrder = 0, .ReorderLevel = 0, .Discontinued = False},
        New Table() With {.ID = 61, .ProductName = "Sirop d'érable", .SupplierID = 29, .CategoryID = 4, .QuantityPerUnit = "24 - 500 ml bottles", .UnitPrice = 34, .UnitInStock = 113, .UnitsOnOrder = 0, .ReorderLevel = 25, .Discontinued = False},
        New Table() With {.ID = 62, .ProductName = "Tarte au sucre", .SupplierID = 29, .CategoryID = 2, .QuantityPerUnit = "48 pies", .UnitPrice = 28, .UnitInStock = 17, .UnitsOnOrder = 0, .ReorderLevel = 0, .Discontinued = False},
        New Table() With {.ID = 63, .ProductName = "Vegie-spread", .SupplierID = 7, .CategoryID = 3, .QuantityPerUnit = "15 - 625 g jars", .UnitPrice = 49, .UnitInStock = 24, .UnitsOnOrder = 0, .ReorderLevel = 5, .Discontinued = False},
        New Table() With {.ID = 64, .ProductName = "Wimmers gute Semmelknödel", .SupplierID = 12, .CategoryID = 2, .QuantityPerUnit = "20 bags x 4 pieces", .UnitPrice = 43, .UnitInStock = 22, .UnitsOnOrder = 80, .ReorderLevel = 30, .Discontinued = False},
        New Table() With {.ID = 65, .ProductName = "Louisiana Fiery Hot Pepper Sauce", .SupplierID = 2, .CategoryID = 5, .QuantityPerUnit = "32 - 8 oz bottles", .UnitPrice = 33.25D, .UnitInStock = 76, .UnitsOnOrder = 0, .ReorderLevel = 0, .Discontinued = False},
        New Table() With {.ID = 66, .ProductName = "Louisiana Hot Spiced Okra", .SupplierID = 2, .CategoryID = 2, .QuantityPerUnit = "24 - 8 oz jars", .UnitPrice = 21.05D, .UnitInStock = 4, .UnitsOnOrder = 100, .ReorderLevel = 20, .Discontinued = False},
        New Table() With {.ID = 67, .ProductName = "Laughing Lumberjack Lager", .SupplierID = 16, .CategoryID = 2, .QuantityPerUnit = "24 - 12 oz bottles", .UnitPrice = 17, .UnitInStock = 52, .UnitsOnOrder = 0, .ReorderLevel = 10, .Discontinued = False},
        New Table() With {.ID = 68, .ProductName = "Scottish Longbreads", .SupplierID = 8, .CategoryID = 1, .QuantityPerUnit = "10 boxes x 8 pieces", .UnitPrice = 14, .UnitInStock = 6, .UnitsOnOrder = 10, .ReorderLevel = 15, .Discontinued = False},
        New Table() With {.ID = 69, .ProductName = "Gudbrandsdalsost", .SupplierID = 15, .CategoryID = 3, .QuantityPerUnit = "10 kg pkg.", .UnitPrice = 12.5D, .UnitInStock = 26, .UnitsOnOrder = 0, .ReorderLevel = 15, .Discontinued = False},
        New Table() With {.ID = 70, .ProductName = "Outback Lager", .SupplierID = 7, .CategoryID = 4, .QuantityPerUnit = "24 - 355 ml bottles", .UnitPrice = 36, .UnitInStock = 14, .UnitsOnOrder = 10, .ReorderLevel = 30, .Discontinued = False},
        New Table() With {.ID = 71, .ProductName = "Flotemysost", .SupplierID = 15, .CategoryID = 1, .QuantityPerUnit = "10 - 500 g pkgs.", .UnitPrice = 15, .UnitInStock = 101, .UnitsOnOrder = 0, .ReorderLevel = 0, .Discontinued = False},
        New Table() With {.ID = 72, .ProductName = "Mozzarella di Giovanni", .SupplierID = 14, .CategoryID = 4, .QuantityPerUnit = "24 - 150 g jars", .UnitPrice = 21, .UnitInStock = 4, .UnitsOnOrder = 0, .ReorderLevel = 0, .Discontinued = False},
        New Table() With {.ID = 73, .ProductName = "Röd Kaviar", .SupplierID = 17, .CategoryID = 4, .QuantityPerUnit = "24 - 200 g pkgs.", .UnitPrice = 34.8D, .UnitInStock = 125, .UnitsOnOrder = 0, .ReorderLevel = 5, .Discontinued = False},
        New Table() With {.ID = 74, .ProductName = "Longlife Tofu", .SupplierID = 4, .CategoryID = 3, .QuantityPerUnit = "5 kg pkg.", .UnitPrice = 15, .UnitInStock = 26, .UnitsOnOrder = 20, .ReorderLevel = 5, .Discontinued = False},
        New Table() With {.ID = 75, .ProductName = "Rhönbräu Klosterbier", .SupplierID = 12, .CategoryID = 7, .QuantityPerUnit = "24 - 0.5 l bottles", .UnitPrice = 10, .UnitInStock = 4, .UnitsOnOrder = 0, .ReorderLevel = 25, .Discontinued = False},
        New Table() With {.ID = 76, .ProductName = "Lakkalikööri", .SupplierID = 23, .CategoryID = 1, .QuantityPerUnit = "500 ml", .UnitPrice = 18, .UnitInStock = 57, .UnitsOnOrder = 0, .ReorderLevel = 20, .Discontinued = False},
        New Table() With {.ID = 77, .ProductName = "Original Frankfurter grüne Soße", .SupplierID = 12, .CategoryID = 2, .QuantityPerUnit = "12 boxes", .UnitPrice = 13, .UnitInStock = 32, .UnitsOnOrder = 0, .ReorderLevel = 15, .Discontinued = False}
    }

    Public Shared ReadOnly Property Tables As List(Of Table)
        Get
            Return tables_1
        End Get
    End Property
End Class
