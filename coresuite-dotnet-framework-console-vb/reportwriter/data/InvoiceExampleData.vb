Public Class InvoiceExampleData
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

    Private Shared order11077_1 As Order = New Order With {
        .OrderID = 11077,
        .OrderDate = New DateTime(2019, 1, 6),
        .CustomerID = "RATTC",
        .ShippedDate = New DateTime(2019, 1, 30),
        .ShipperName = "United Package",
        .ShipTo = "Rattlesnake Canyon Grocery" & vbLf & "2817 Milton Dr." & vbLf & "Albuquerque, NM 87110" & vbLf & "USA",
        .BillTo = "Rattlesnake Canyon Grocery" & vbLf & "2817 Milton Dr." & vbLf & "Albuquerque, NM 87110" & vbLf & "USA",
        .Freight = 8.53D,
        .OrderDetails = New List(Of OrderDetail)() From {
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

    Public Shared ReadOnly Property Order11077 As Order
        Get
            Return order11077_1
        End Get
    End Property
End Class
