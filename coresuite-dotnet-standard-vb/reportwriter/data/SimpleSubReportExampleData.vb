Imports System.Collections.Generic

Public Class SimpleSubReportExampleData
    Public Class Category
        Public Property Name As String
        Public Property Products As List(Of Product)
    End Class

    Public Class Product
        Public Property ProductID As Integer
        Public Property ProductName As String
        Public Property QuantityPerUnit As String
        Public Property UnitPrice As Decimal
        Public Property Discontinued As Boolean
    End Class
    Public Shared ReadOnly Property ProductsByCategory As List(Of Category)
        Get
            Return productsByCategory1
        End Get
    End Property

    Private Shared productsByCategory1 As List(Of Category) = New List(Of Category)() From {
        New Category With {.Name = "Beverages", .Products = New List(Of Product)() From {
                New Product With {.ProductID = 1, .ProductName = "Chai", .QuantityPerUnit = "10 boxes x 20 bags", .UnitPrice = 18D, .Discontinued = False},
                New Product With {.ProductID = 2, .ProductName = "Chang", .QuantityPerUnit = "24 - 12 oz bottles", .UnitPrice = 19D, .Discontinued = False},
                New Product With {.ProductID = 39, .ProductName = "Chartreuse verte", .QuantityPerUnit = "750 cc per bottle", .UnitPrice = 18D, .Discontinued = False},
                New Product With {.ProductID = 38, .ProductName = "Côte de Blaye", .QuantityPerUnit = "12 - 75 cl bottles", .UnitPrice = 263.5D, .Discontinued = False},
                New Product With {.ProductID = 24, .ProductName = "Guaraná Fantástica", .QuantityPerUnit = "12 - 355 ml cans", .UnitPrice = 4.5D, .Discontinued = True},
                New Product With {.ProductID = 43, .ProductName = "Ipoh Coffee", .QuantityPerUnit = "16 - 500 g tins", .UnitPrice = 46D, .Discontinued = False},
                New Product With {.ProductID = 76, .ProductName = "Lakkalikööri", .QuantityPerUnit = "500 ml", .UnitPrice = 18D, .Discontinued = False},
                New Product With {.ProductID = 67, .ProductName = "Laughing Lumberjack Lager", .QuantityPerUnit = "24 - 12 oz bottles", .UnitPrice = 14D, .Discontinued = False},
                New Product With {.ProductID = 70, .ProductName = "Outback Lager", .QuantityPerUnit = "24 - 355 ml bottles", .UnitPrice = 15D, .Discontinued = False},
                New Product With {.ProductID = 75, .ProductName = "Rhönbräu Klosterbier", .QuantityPerUnit = "24 - 0.5 l bottles", .UnitPrice = 7.75D, .Discontinued = False},
                New Product With {.ProductID = 34, .ProductName = "Sasquatch Ale", .QuantityPerUnit = "24 - 12 oz bottles", .UnitPrice = 14D, .Discontinued = False},
                New Product With {.ProductID = 35, .ProductName = "Steeleye Stout", .QuantityPerUnit = "24 - 12 oz bottles", .UnitPrice = 18D, .Discontinued = False}
            }
        },
        New Category With {.Name = "Condiments", .Products = New List(Of Product)() From {
                New Product With {.ProductID = 3, .ProductName = "Aniseed Syrup", .QuantityPerUnit = "12 - 550 ml bottles", .UnitPrice = 10D, .Discontinued = False},
                New Product With {.ProductID = 4, .ProductName = "Chef Anton's Cajun Seasoning", .QuantityPerUnit = "48 - 6 oz jars", .UnitPrice = 22D, .Discontinued = False},
                New Product With {.ProductID = 5, .ProductName = "Chef Anton's Gumbo Mix", .QuantityPerUnit = "36 boxes", .UnitPrice = 21.35D, .Discontinued = True},
                New Product With {.ProductID = 15, .ProductName = "Genen Shouyu", .QuantityPerUnit = "24 - 250 ml bottles", .UnitPrice = 15.5D, .Discontinued = False},
                New Product With {.ProductID = 6, .ProductName = "Grandma's Boysenberry Spread", .QuantityPerUnit = "12 - 8 oz jars", .UnitPrice = 25D, .Discontinued = False},
                New Product With {.ProductID = 44, .ProductName = "Gula Malacca", .QuantityPerUnit = "20 - 2 kg bags", .UnitPrice = 19.45D, .Discontinued = False},
                New Product With {.ProductID = 65, .ProductName = "Louisiana Fiery Hot Pepper Sauce", .QuantityPerUnit = "32 - 8 oz bottles", .UnitPrice = 21.05D, .Discontinued = False},
                New Product With {.ProductID = 66, .ProductName = "Louisiana Hot Spiced Okra", .QuantityPerUnit = "24 - 8 oz jars", .UnitPrice = 17D, .Discontinued = False},
                New Product With {.ProductID = 8, .ProductName = "Northwoods Cranberry Sauce", .QuantityPerUnit = "12 - 12 oz jars", .UnitPrice = 40D, .Discontinued = False},
                New Product With {.ProductID = 77, .ProductName = "Original Frankfurter grüne Soße", .QuantityPerUnit = "12 boxes", .UnitPrice = 13D, .Discontinued = False},
                New Product With {.ProductID = 61, .ProductName = "Sirop d'érable", .QuantityPerUnit = "24 - 500 ml bottles", .UnitPrice = 28.5D, .Discontinued = False},
                New Product With {.ProductID = 63, .ProductName = "Vegie-spread", .QuantityPerUnit = "15 - 625 g jars", .UnitPrice = 43.9D, .Discontinued = False}
            }
        },
        New Category With {.Name = "Confections", .Products = New List(Of Product)() From {
                New Product With {.ProductID = 48, .ProductName = "Chocolade", .QuantityPerUnit = "10 pkgs.", .UnitPrice = 12.75D, .Discontinued = False},
                New Product With {.ProductID = 26, .ProductName = "Gumbär Gummibärchen", .QuantityPerUnit = "100 - 250 g bags", .UnitPrice = 31.23D, .Discontinued = False},
                New Product With {.ProductID = 49, .ProductName = "Maxilaku", .QuantityPerUnit = "24 - 50 g pkgs.", .UnitPrice = 20D, .Discontinued = False},
                New Product With {.ProductID = 25, .ProductName = "NuNuCa Nuß-Nougat-Creme", .QuantityPerUnit = "20 - 450 g glasses", .UnitPrice = 14D, .Discontinued = False},
                New Product With {.ProductID = 16, .ProductName = "Pavlova", .QuantityPerUnit = "32 - 500 g boxes", .UnitPrice = 17.45D, .Discontinued = False},
                New Product With {.ProductID = 27, .ProductName = "Schoggi Schokolade", .QuantityPerUnit = "100 - 100 g pieces", .UnitPrice = 43.9D, .Discontinued = False},
                New Product With {.ProductID = 68, .ProductName = "Scottish Longbreads", .QuantityPerUnit = "10 boxes x 8 pieces", .UnitPrice = 12.5D, .Discontinued = False},
                New Product With {.ProductID = 20, .ProductName = "Sir Rodney's Marmalade", .QuantityPerUnit = "30 gift boxes", .UnitPrice = 81D, .Discontinued = False},
                New Product With {.ProductID = 21, .ProductName = "Sir Rodney's Scones", .QuantityPerUnit = "24 pkgs. x 4 pieces", .UnitPrice = 10D, .Discontinued = False},
                New Product With {.ProductID = 62, .ProductName = "Tarte au sucre", .QuantityPerUnit = "48 pies", .UnitPrice = 49.3D, .Discontinued = False},
                New Product With {.ProductID = 19, .ProductName = "Teatime Chocolate Biscuits", .QuantityPerUnit = "10 boxes x 12 pieces", .UnitPrice = 9.2D, .Discontinued = False},
                New Product With {.ProductID = 50, .ProductName = "Valkoinen suklaa", .QuantityPerUnit = "12 - 100 g bars", .UnitPrice = 16.25D, .Discontinued = False},
                New Product With {.ProductID = 47, .ProductName = "Zaanse koeken", .QuantityPerUnit = "10 - 4 oz boxes", .UnitPrice = 9.5D, .Discontinued = False}
            }
        },
        New Category With {.Name = "Dairy Products", .Products = New List(Of Product)() From {
                New Product With {.ProductID = 60, .ProductName = "Camembert Pierrot", .QuantityPerUnit = "15 - 300 g rounds", .UnitPrice = 34D, .Discontinued = False},
                New Product With {.ProductID = 71, .ProductName = "Flotemysost", .QuantityPerUnit = "10 - 500 g pkgs.", .UnitPrice = 21.5D, .Discontinued = False},
                New Product With {.ProductID = 33, .ProductName = "Geitost", .QuantityPerUnit = "500 g", .UnitPrice = 2.5D, .Discontinued = False},
                New Product With {.ProductID = 31, .ProductName = "Gorgonzola Telino", .QuantityPerUnit = "12 - 100 g pkgs", .UnitPrice = 12.5D, .Discontinued = False},
                New Product With {.ProductID = 69, .ProductName = "Gudbrandsdalsost", .QuantityPerUnit = "10 kg pkg.", .UnitPrice = 36D, .Discontinued = False},
                New Product With {.ProductID = 32, .ProductName = "Mascarpone Fabioli", .QuantityPerUnit = "24 - 200 g pkgs.", .UnitPrice = 32D, .Discontinued = False},
                New Product With {.ProductID = 72, .ProductName = "Mozzarella di Giovanni", .QuantityPerUnit = "24 - 200 g pkgs.", .UnitPrice = 34.8D, .Discontinued = False},
                New Product With {.ProductID = 11, .ProductName = "Queso Cabrales", .QuantityPerUnit = "1 kg pkg.", .UnitPrice = 21D, .Discontinued = False},
                New Product With {.ProductID = 12, .ProductName = "Queso Manchego La Pastora", .QuantityPerUnit = "10 - 500 g pkgs.", .UnitPrice = 38D, .Discontinued = False},
                New Product With {.ProductID = 59, .ProductName = "Raclette Courdavault", .QuantityPerUnit = "5 kg pkg.", .UnitPrice = 55D, .Discontinued = False}
            }
        },
        New Category With {.Name = "Grains/Cereals", .Products = New List(Of Product)() From {
                New Product With {.ProductID = 52, .ProductName = "Filo Mix", .QuantityPerUnit = "16 - 2 kg boxes", .UnitPrice = 7D, .Discontinued = False},
                New Product With {.ProductID = 56, .ProductName = "Gnocchi di nonna Alice", .QuantityPerUnit = "24 - 250 g pkgs.", .UnitPrice = 38D, .Discontinued = False},
                New Product With {.ProductID = 22, .ProductName = "Gustaf's Knäckebröd", .QuantityPerUnit = "24 - 500 g pkgs.", .UnitPrice = 21D, .Discontinued = False},
                New Product With {.ProductID = 57, .ProductName = "Ravioli Angelo", .QuantityPerUnit = "24 - 250 g pkgs.", .UnitPrice = 19.5D, .Discontinued = False},
                New Product With {.ProductID = 42, .ProductName = "Singaporean Hokkien Fried Mee", .QuantityPerUnit = "32 - 1 kg pkgs.", .UnitPrice = 14D, .Discontinued = True},
                New Product With {.ProductID = 23, .ProductName = "Tunnbröd", .QuantityPerUnit = "12 - 250 g pkgs.", .UnitPrice = 9D, .Discontinued = False},
                New Product With {.ProductID = 64, .ProductName = "Wimmers gute Semmelknödel", .QuantityPerUnit = "20 bags x 4 pieces", .UnitPrice = 33.25D, .Discontinued = False}
            }
        },
        New Category With {.Name = "Meat/Poultry", .Products = New List(Of Product)() From {
                New Product With {.ProductID = 17, .ProductName = "Alice Mutton", .QuantityPerUnit = "20 - 1 kg tins", .UnitPrice = 39D, .Discontinued = True},
                New Product With {.ProductID = 9, .ProductName = "Mishi Kobe Niku", .QuantityPerUnit = "18 - 500 g pkgs.", .UnitPrice = 97D, .Discontinued = True},
                New Product With {.ProductID = 55, .ProductName = "Pâté chinois", .QuantityPerUnit = "24 boxes x 2 pies", .UnitPrice = 24D, .Discontinued = False},
                New Product With {.ProductID = 53, .ProductName = "Perth Pasties", .QuantityPerUnit = "48 pieces", .UnitPrice = 32.8D, .Discontinued = True},
                New Product With {.ProductID = 29, .ProductName = "Thüringer Rostbratwurst", .QuantityPerUnit = "50 bags x 30 sausgs.", .UnitPrice = 123.79D, .Discontinued = True},
                New Product With {.ProductID = 54, .ProductName = "Tourtière", .QuantityPerUnit = "16 pies", .UnitPrice = 7.45D, .Discontinued = False}
            }
        },
        New Category With {.Name = "Produce", .Products = New List(Of Product)() From {
                New Product With {.ProductID = 74, .ProductName = "Longlife Tofu", .QuantityPerUnit = "5 kg pkg.", .UnitPrice = 10D, .Discontinued = False},
                New Product With {.ProductID = 51, .ProductName = "Manjimup Dried Apples", .QuantityPerUnit = "50 - 300 g pkgs.", .UnitPrice = 53D, .Discontinued = False},
                New Product With {.ProductID = 28, .ProductName = "Rössle Sauerkraut", .QuantityPerUnit = "25 - 825 g cans", .UnitPrice = 45.6D, .Discontinued = True},
                New Product With {.ProductID = 14, .ProductName = "Tofu", .QuantityPerUnit = "40 - 100 g pkgs.", .UnitPrice = 23.25D, .Discontinued = False},
                New Product With {.ProductID = 7, .ProductName = "Uncle Bob's Organic Dried Pears", .QuantityPerUnit = "12 - 1 lb pkgs.", .UnitPrice = 30D, .Discontinued = False}
            }
        },
        New Category With {.Name = "Seafood", .Products = New List(Of Product)() From {
                New Product With {.ProductID = 40, .ProductName = "Boston Crab Meat", .QuantityPerUnit = "24 - 4 oz tins", .UnitPrice = 18.4D, .Discontinued = False},
                New Product With {.ProductID = 18, .ProductName = "Carnarvon Tigers", .QuantityPerUnit = "16 kg pkg.", .UnitPrice = 62.5D, .Discontinued = False},
                New Product With {.ProductID = 58, .ProductName = "Escargots de Bourgogne", .QuantityPerUnit = "24 pieces", .UnitPrice = 13.25D, .Discontinued = False},
                New Product With {.ProductID = 37, .ProductName = "Gravad lax", .QuantityPerUnit = "12 - 500 g pkgs.", .UnitPrice = 26D, .Discontinued = False},
                New Product With {.ProductID = 10, .ProductName = "Ikura", .QuantityPerUnit = "12 - 200 ml jars", .UnitPrice = 31D, .Discontinued = False},
                New Product With {.ProductID = 36, .ProductName = "Inlagd Sill", .QuantityPerUnit = "24 - 250 g  jars", .UnitPrice = 19D, .Discontinued = False},
                New Product With {.ProductID = 41, .ProductName = "Jack's New England Clam Chowder", .QuantityPerUnit = "12 - 12 oz cans", .UnitPrice = 9.65D, .Discontinued = False},
                New Product With {.ProductID = 13, .ProductName = "Konbu", .QuantityPerUnit = "2 kg box", .UnitPrice = 6D, .Discontinued = False},
                New Product With {.ProductID = 30, .ProductName = "Nord-Ost Matjeshering", .QuantityPerUnit = "10 - 200 g glasses", .UnitPrice = 25.89D, .Discontinued = False},
                New Product With {.ProductID = 73, .ProductName = "Röd Kaviar", .QuantityPerUnit = "24 - 150 g jars", .UnitPrice = 15D, .Discontinued = False},
                New Product With {.ProductID = 45, .ProductName = "Rogede sild", .QuantityPerUnit = "1k pkg.", .UnitPrice = 9.5D, .Discontinued = False},
                New Product With {.ProductID = 46, .ProductName = "Spegesild", .QuantityPerUnit = "4 - 450 g glasses", .UnitPrice = 12D, .Discontinued = False}
            }
        }
    }

End Class
