Public Class MergerInvoiceData
    Public Class Order
        Public Property OrderID As Integer
        Public Property OrderDate As DateTime
        Public Property CustomerID As String
        Public Property ShippedDate As DateTime
        Public Property ShipperName As String
        Public Property ShipTo As String
        Public Property BillTo As String
        Public Property Freight As Decimal
        Public Property OrderDetails As List(Of OrderDetail)
    End Class

    Public Class OrderDetail

        Public Property ProductID As Integer
        Public Property Quantity As Integer
        Public Property ProductName As String
        Public Property UnitPrice As Decimal
    End Class
    Shared n As String = vbNewLine

    Private Shared orders_1 As List(Of Order) = New List(Of Order)() From {
           New Order() With {.OrderID = 10248, .OrderDate = New DateTime(1996, 7, 4), .CustomerID = "VINET", .ShippedDate = New DateTime(1996, 7, 16), .ShipperName = "Federal Shipping", .ShipTo = "Vins et alcools Chevalier" + n + "59 rue de l'Abbaye" + n + "Reims, 51100" + n + "France",
            .BillTo = "Vins et alcools Chevalier" + n + "59 rue de l'Abbaye" + n + "Reims, 51100" + n + "France", .Freight = 32.38D, .OrderDetails = New List(Of OrderDetail)() From {
                New OrderDetail With {.ProductID = 11, .Quantity = 12, .ProductName = "Queso Cabrales", .UnitPrice = 14D},
                New OrderDetail With {.ProductID = 42, .Quantity = 10, .ProductName = "Singaporean Hokkien Fried Mee", .UnitPrice = 9.8D},
                New OrderDetail With {.ProductID = 72, .Quantity = 5, .ProductName = "Mozzarella di Giovanni", .UnitPrice = 34.8D}
              }
           },
            New Order() With {.OrderID = 10249, .OrderDate = New DateTime(1996, 7, 5), .CustomerID = "TOMSP", .ShippedDate = New DateTime(1996, 7, 10), .ShipperName = "Speedy Express", .ShipTo = "Toms Spezialitäten" + n + "Luisenstr. 48" + n + "Münster, 44087" + n + "Germany",
            .BillTo = "Toms Spezialitäten" + n + "Luisenstr. 48" + n + "Münster, 44087" + n + "Germany", .Freight = 11.61D, .OrderDetails = New List(Of OrderDetail)() From {
                New OrderDetail With {.ProductID = 74, .Quantity = 9, .ProductName = "Tofu", .UnitPrice = 18.6D},
                New OrderDetail With {.ProductID = 51, .Quantity = 40, .ProductName = "Manjimup Dried Apples", .UnitPrice = 42.4D}
              }
           },
             New Order() With {.OrderID = 10250, .OrderDate = New DateTime(1996, 7, 8), .CustomerID = "HANAR", .ShippedDate = New DateTime(1996, 7, 12), .ShipperName = "United Package", .ShipTo = "Hanari Carnes" + n + "Rua do Paço, 67" + n + "Rio de Janeiro, 05454-876" + n + "Brazil",
            .BillTo = "Hanari Carnes" + n + "Rua do Paço, 67" + n + "Rio de Janeiro, 05454-876" + n + "Brazil", .Freight = 65.83D, .OrderDetails = New List(Of OrderDetail)() From {
                New OrderDetail With {.ProductID = 41, .Quantity = 10, .ProductName = "Jack's New England Clam Chowder", .UnitPrice = 7.7D},
                New OrderDetail With {.ProductID = 51, .Quantity = 35, .ProductName = "Manjimup Dried Apples", .UnitPrice = 42.4D},
                New OrderDetail With {.ProductID = 65, .Quantity = 15, .ProductName = "Louisiana Fiery Hot Pepper Sauce", .UnitPrice = 16.8D}
             }
           },
               New Order() With {.OrderID = 10251, .OrderDate = New DateTime(1996, 7, 8), .CustomerID = "VICTE", .ShippedDate = New DateTime(1996, 7, 15), .ShipperName = "Speedy Express", .ShipTo = "Victuailles en stock" + n + "2, rue du Commerce" + n + "Lyon, 69004" + n + "France",
            .BillTo = "Victuailles en stock" + n + "2, rue du Commerce" + n + "Lyon, 69004" + n + "France", .Freight = 41.34D, .OrderDetails = New List(Of OrderDetail)() From {
                New OrderDetail With {.ProductID = 22, .Quantity = 6, .ProductName = "Gustaf's Knäckebröd", .UnitPrice = 16.8D},
                New OrderDetail With {.ProductID = 57, .Quantity = 15, .ProductName = "Ravioli Angelo", .UnitPrice = 15.6D},
                New OrderDetail With {.ProductID = 65, .Quantity = 20, .ProductName = "Louisiana Fiery Hot Pepper Sauce", .UnitPrice = 16.8D}
             }
           },
                 New Order() With {.OrderID = 10252, .OrderDate = New DateTime(1996, 7, 9), .CustomerID = "SUPRD", .ShippedDate = New DateTime(1996, 7, 11), .ShipperName = "United Package", .ShipTo = "Suprêmes délices" + n + "Boulevard Tirou, 255" + n + "Charleroi, B-6000" + n + "Belgium",
            .BillTo = "Suprêmes délices" + n + "Boulevard Tirou, 255" + n + "Charleroi, B-6000" + n + "Belgium", .Freight = 51.3D, .OrderDetails = New List(Of OrderDetail)() From {
                New OrderDetail With {.ProductID = 20, .Quantity = 6, .ProductName = "Sir Rodney's Marmalade", .UnitPrice = 64.8D},
                New OrderDetail With {.ProductID = 33, .Quantity = 15, .ProductName = "Geitost", .UnitPrice = 2D},
                New OrderDetail With {.ProductID = 60, .Quantity = 20, .ProductName = "Camembert Pierrot", .UnitPrice = 27.2D}
             }
           },
                  New Order() With {.OrderID = 10360, .OrderDate = New DateTime(1996, 11, 22), .CustomerID = "BLONP", .ShippedDate = New DateTime(1996, 12, 2), .ShipperName = "Federal Shipping", .ShipTo = "Blondel père et fils" + n + "24, place Kléber" + n + "Strasbourg, 67000" + n + "France",
            .BillTo = "Blondel père et fils" + n + "24, place Kléber" + n + "Strasbourg, 67000" + n + "France", .Freight = 131.7D, .OrderDetails = New List(Of OrderDetail)() From {
                New OrderDetail With {.ProductID = 28, .Quantity = 30, .ProductName = "Rössle Sauerkraut", .UnitPrice = 36.4D},
                New OrderDetail With {.ProductID = 29, .Quantity = 35, .ProductName = "Thüringer Rostbratwurst", .UnitPrice = 99D},
                New OrderDetail With {.ProductID = 38, .Quantity = 10, .ProductName = "Côte de Blaye", .UnitPrice = 210.8D},
                New OrderDetail With {.ProductID = 49, .Quantity = 35, .ProductName = "Maxilaku", .UnitPrice = 16D},
                New OrderDetail With {.ProductID = 54, .Quantity = 28, .ProductName = "Tourtière", .UnitPrice = 5.9D}
            }
           },
                     New Order() With {.OrderID = 10979, .OrderDate = New DateTime(1998, 3, 26), .CustomerID = "ERNSH", .ShippedDate = New DateTime(1998, 3, 31), .ShipperName = "United Package", .ShipTo = "Ernst Handel" + n + "Kirchgasse 6" + n + "Graz, 8010" + n + "Austria",
            .BillTo = "Ernst Handel" + n + "Kirchgasse 6" + n + "Graz, 8010" + n + "Austria", .Freight = 353.07D, .OrderDetails = New List(Of OrderDetail)() From {
                New OrderDetail With {.ProductID = 7, .Quantity = 18, .ProductName = "Uncle Bob's Organic Dried Pears", .UnitPrice = 30D},
                New OrderDetail With {.ProductID = 12, .Quantity = 20, .ProductName = "Queso Manchego La Pastora", .UnitPrice = 38D},
                New OrderDetail With {.ProductID = 24, .Quantity = 80, .ProductName = "Guaraná Fantástica", .UnitPrice = 4.5D},
                New OrderDetail With {.ProductID = 27, .Quantity = 30, .ProductName = "Schoggi Schokolade", .UnitPrice = 43.9D},
                New OrderDetail With {.ProductID = 31, .Quantity = 24, .ProductName = "Gorgonzola Telino", .UnitPrice = 12.5D},
                New OrderDetail With {.ProductID = 63, .Quantity = 35, .ProductName = "Vegie-spread", .UnitPrice = 43.9D}
            }
           },
             New Order() With {.OrderID = 11077, .OrderDate = New DateTime(2019, 1, 6), .CustomerID = "RATTC", .ShippedDate = New DateTime(2019, 1, 30), .ShipperName = "United Package", .ShipTo = "Rattlesnake Canyon Grocery" + n + "2817 Milton Dr." + n + "Albuquerque, NM 87110" + n + "USA",
            .BillTo = "Rattlesnake Canyon Grocery" + n + "2817 Milton Dr." + n + "Albuquerque, NM 87110" + n + "USA", .Freight = 8.53D, .OrderDetails = New List(Of OrderDetail)() From {
                New OrderDetail With {.ProductID = 2, .Quantity = 24, .ProductName = "Chang", .UnitPrice = 19D},
                New OrderDetail With {.ProductID = 3, .Quantity = 4, .ProductName = "Aniseed Syrup", .UnitPrice = 10D},
                New OrderDetail With {.ProductID = 4, .Quantity = 1, .ProductName = "Chef Anton's Cajun Seasoning", .UnitPrice = 22D},
                New OrderDetail With {.ProductID = 6, .Quantity = 1, .ProductName = "Grandma's Boysenberry Spread", .UnitPrice = 25D},
                New OrderDetail With {.ProductID = 7, .Quantity = 1, .ProductName = "Uncle Bob's Organic Dried Pears", .UnitPrice = 30D},
                New OrderDetail With {.ProductID = 8, .Quantity = 2, .ProductName = "Northwoods Cranberry Sauce", .UnitPrice = 40D},
                New OrderDetail With {.ProductID = 10, .Quantity = 1, .ProductName = "Ikura", .UnitPrice = 31D},
                New OrderDetail With {.ProductID = 12, .Quantity = 2, .ProductName = "Queso Manchego La Pastora", .UnitPrice = 38D},
                New OrderDetail With {.ProductID = 13, .Quantity = 4, .ProductName = "Konbu", .UnitPrice = 6D},
                New OrderDetail With {.ProductID = 14, .Quantity = 1, .ProductName = "Tofu", .UnitPrice = 23.25D},
                New OrderDetail With {.ProductID = 16, .Quantity = 2, .ProductName = "Pavlova", .UnitPrice = 17.45D},
                New OrderDetail With {.ProductID = 20, .Quantity = 1, .ProductName = "Sir Rodney's Marmalade", .UnitPrice = 81D},
                New OrderDetail With {.ProductID = 23, .Quantity = 2, .ProductName = "Tunnbröd", .UnitPrice = 9D},
                New OrderDetail With {.ProductID = 32, .Quantity = 1, .ProductName = "Mascarpone Fabioli", .UnitPrice = 32D},
                New OrderDetail With {.ProductID = 39, .Quantity = 2, .ProductName = "Chartreuse verte", .UnitPrice = 18D},
                New OrderDetail With {.ProductID = 41, .Quantity = 3, .ProductName = "Jack's New England Clam Chowder", .UnitPrice = 9.65D},
                New OrderDetail With {.ProductID = 46, .Quantity = 3, .ProductName = "Spegesild", .UnitPrice = 12D},
                New OrderDetail With {.ProductID = 52, .Quantity = 2, .ProductName = "Filo Mix", .UnitPrice = 7D},
                New OrderDetail With {.ProductID = 55, .Quantity = 2, .ProductName = "Pâté chinois", .UnitPrice = 24D},
                New OrderDetail With {.ProductID = 60, .Quantity = 2, .ProductName = "Camembert Pierrot", .UnitPrice = 34D},
                New OrderDetail With {.ProductID = 64, .Quantity = 2, .ProductName = "Wimmers gute Semmelknödel", .UnitPrice = 33.25D},
                New OrderDetail With {.ProductID = 66, .Quantity = 1, .ProductName = "Louisiana Hot Spiced Okra", .UnitPrice = 17D},
                New OrderDetail With {.ProductID = 73, .Quantity = 2, .ProductName = "Röd Kaviar", .UnitPrice = 15D},
                New OrderDetail With {.ProductID = 75, .Quantity = 4, .ProductName = "Rhönbräu Klosterbier", .UnitPrice = 7.75D},
                New OrderDetail With {.ProductID = 77, .Quantity = 2, .ProductName = "Original Frankfurter grüne Soße", .UnitPrice = 13D}
              }
           }
        }

    Public Shared ReadOnly Property Orders As List(Of Order)
        Get
            Return orders_1
        End Get
    End Property
End Class
