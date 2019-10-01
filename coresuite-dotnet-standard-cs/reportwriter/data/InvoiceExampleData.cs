using System;
using System.Collections.Generic;

/// <summary>
/// Summary description for InvoiceExampleData
/// </summary>
public class InvoiceExampleData
{
    public class Order
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerID { get; set; }
        public DateTime ShippedDate { get; set; }
        public string ShipperName { get; set; }
        public string ShipTo { get; set; }
        public string BillTo { get; set; }
        public decimal Freight { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
    public class OrderDetail
    {
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
    }

    private static Order order11077 = new Order
    {
        OrderID = 11077,
        OrderDate = new DateTime(2019, 1, 6),
        CustomerID = "RATTC",
        ShippedDate = new DateTime(2019, 1, 30),
        ShipperName = "United Package",
        ShipTo = "Rattlesnake Canyon Grocery\n2817 Milton Dr.\nAlbuquerque, NM 87110\nUSA",
        BillTo = "Rattlesnake Canyon Grocery\n2817 Milton Dr.\nAlbuquerque, NM 87110\nUSA",
        Freight = 8.53M,
        OrderDetails = new List<OrderDetail>() {
                new OrderDetail { ProductID = 2, Quantity = 24, ProductName= "Chang", UnitPrice = 19M },
                new OrderDetail { ProductID = 3, Quantity = 4, ProductName= "Aniseed Syrup", UnitPrice = 10M },
                new OrderDetail { ProductID = 4, Quantity = 1, ProductName= "Chef Anton's Cajun Seasoning", UnitPrice = 22M },
                new OrderDetail { ProductID = 6, Quantity = 1, ProductName= "Grandma's Boysenberry Spread", UnitPrice = 25M },
                new OrderDetail { ProductID = 7, Quantity = 1, ProductName= "Uncle Bob's Organic Dried Pears", UnitPrice = 30M },
                new OrderDetail { ProductID = 8, Quantity = 2, ProductName= "Northwoods Cranberry Sauce", UnitPrice = 40M },
                new OrderDetail { ProductID = 10, Quantity = 1, ProductName= "Ikura", UnitPrice = 31M },
                new OrderDetail { ProductID = 12, Quantity = 2, ProductName= "Queso Manchego La Pastora", UnitPrice = 38M },
                new OrderDetail { ProductID = 13, Quantity = 4, ProductName= "Konbu", UnitPrice = 6M },
                new OrderDetail { ProductID = 14, Quantity = 1, ProductName= "Tofu", UnitPrice = 23.25M },
                new OrderDetail { ProductID = 16, Quantity = 2, ProductName= "Pavlova", UnitPrice = 17.45M },
                new OrderDetail { ProductID = 20, Quantity = 1, ProductName= "Sir Rodney's Marmalade", UnitPrice = 81M },
                new OrderDetail { ProductID = 23, Quantity = 2, ProductName= "Tunnbröd", UnitPrice = 9M },
                new OrderDetail { ProductID = 32, Quantity = 1, ProductName= "Mascarpone Fabioli", UnitPrice = 32M },
                new OrderDetail { ProductID = 39, Quantity = 2, ProductName= "Chartreuse verte", UnitPrice = 18M },
                new OrderDetail { ProductID = 41, Quantity = 3, ProductName= "Jack's New England Clam Chowder", UnitPrice = 9.65M },
                new OrderDetail { ProductID = 46, Quantity = 3, ProductName= "Spegesild", UnitPrice = 12M },
                new OrderDetail { ProductID = 52, Quantity = 2, ProductName= "Filo Mix", UnitPrice = 7M },
                new OrderDetail { ProductID = 55, Quantity = 2, ProductName= "Pâté chinois", UnitPrice = 24M },
                new OrderDetail { ProductID = 60, Quantity = 2, ProductName= "Camembert Pierrot", UnitPrice = 34M },
                new OrderDetail { ProductID = 64, Quantity = 2, ProductName= "Wimmers gute Semmelknödel", UnitPrice = 33.25M },
                new OrderDetail { ProductID = 66, Quantity = 1, ProductName= "Louisiana Hot Spiced Okra", UnitPrice = 17M },
                new OrderDetail { ProductID = 73, Quantity = 2, ProductName= "Röd Kaviar", UnitPrice = 15M },
                new OrderDetail { ProductID = 75, Quantity = 4, ProductName= "Rhönbräu Klosterbier", UnitPrice = 7.75M },
                new OrderDetail { ProductID = 77, Quantity = 2, ProductName= "Original Frankfurter grüne Soße", UnitPrice = 13M }
        }
    };

    public static Order Order11077
    {
        get { return order11077; }
    }
}

