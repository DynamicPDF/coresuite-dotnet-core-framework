using System;
using System.Collections.Generic;
using System.Text;

 public  class GeneratorInvoiceData
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

        private static List<Order> orders = new List<Order>()
        {
           new Order(){ OrderID = 10248, OrderDate = new DateTime(1996, 7, 4), CustomerID = "VINET", ShippedDate = new DateTime(1996, 7, 16),ShipperName = "Federal Shipping",ShipTo = "Vins et alcools Chevalier\n59 rue de l'Abbaye\nReims, 51100\nFrance",
            BillTo = "Vins et alcools Chevalier\n59 rue de l'Abbaye\nReims, 51100\nFrance", Freight = 32.38M, OrderDetails = new List<OrderDetail>() {
                new OrderDetail { ProductID = 11, Quantity = 12, ProductName= "Queso Cabrales", UnitPrice = 14M },
                new OrderDetail { ProductID = 42, Quantity = 10, ProductName= "Singaporean Hokkien Fried Mee", UnitPrice = 9.80M },
                new OrderDetail { ProductID = 72, Quantity = 5, ProductName= "Mozzarella di Giovanni", UnitPrice = 34.80M }             
              }
           },

            new Order(){ OrderID = 10249, OrderDate = new DateTime(1996, 7, 5), CustomerID = "TOMSP", ShippedDate = new DateTime(1996, 7, 10),ShipperName = "Speedy Express",ShipTo = "Toms Spezialitäten\nLuisenstr. 48\nMünster, 44087\nGermany",
            BillTo = "Toms Spezialitäten\nLuisenstr. 48\nMünster, 44087\nGermany", Freight = 11.61M, OrderDetails = new List<OrderDetail>() {
                new OrderDetail { ProductID = 74, Quantity = 9, ProductName= "Tofu", UnitPrice = 18.60M },
                new OrderDetail { ProductID = 51, Quantity = 40, ProductName= "Manjimup Dried Apples", UnitPrice = 42.40M }            
              }
           },

             new Order(){ OrderID = 10250, OrderDate = new DateTime(1996, 7, 8), CustomerID = "HANAR", ShippedDate = new DateTime(1996, 7, 12),ShipperName = "United Package",ShipTo = "Hanari Carnes\nRua do Paço, 67\nRio de Janeiro, 05454-876\nBrazil",
            BillTo = "Hanari Carnes\nRua do Paço, 67\nRio de Janeiro, 05454-876\nBrazil", Freight = 65.83M, OrderDetails = new List<OrderDetail>() {
                new OrderDetail { ProductID = 41, Quantity = 10, ProductName= "Jack's New England Clam Chowder", UnitPrice = 7.70M },
                new OrderDetail { ProductID = 51, Quantity = 35, ProductName= "Manjimup Dried Apples", UnitPrice = 42.40M },
                new OrderDetail { ProductID = 65, Quantity = 15, ProductName= "Louisiana Fiery Hot Pepper Sauce", UnitPrice = 16.80M }
             }
           },

               new Order(){ OrderID = 10251, OrderDate = new DateTime(1996, 7, 8), CustomerID = "VICTE", ShippedDate = new DateTime(1996, 7, 15),ShipperName = "Speedy Express",ShipTo = "Victuailles en stock\n2, rue du Commerce\nLyon, 69004\nFrance",
            BillTo = "Victuailles en stock\n2, rue du Commerce\nLyon, 69004\nFrance", Freight = 41.34M, OrderDetails = new List<OrderDetail>() {
                new OrderDetail { ProductID = 22, Quantity = 6, ProductName= "Gustaf's Knäckebröd", UnitPrice = 16.80M },
                new OrderDetail { ProductID = 57, Quantity = 15, ProductName= "Ravioli Angelo", UnitPrice = 15.60M },
                new OrderDetail { ProductID = 65, Quantity = 20, ProductName= "Louisiana Fiery Hot Pepper Sauce", UnitPrice = 16.80M }
             }
           },

                 new Order(){ OrderID = 10252, OrderDate = new DateTime(1996, 7, 9), CustomerID = "SUPRD", ShippedDate = new DateTime(1996, 7, 11),ShipperName = "United Package",ShipTo = "Suprêmes délices\nBoulevard Tirou, 255\nCharleroi, B-6000\nBelgium",
            BillTo =  "Suprêmes délices\nBoulevard Tirou, 255\nCharleroi, B-6000\nBelgium", Freight = 51.30M, OrderDetails = new List<OrderDetail>() {
                new OrderDetail { ProductID = 20, Quantity = 6, ProductName= "Sir Rodney's Marmalade", UnitPrice = 64.80M },
                new OrderDetail { ProductID = 33, Quantity = 15, ProductName= "Geitost", UnitPrice = 2.00M },
                new OrderDetail { ProductID = 60, Quantity = 20, ProductName= "Camembert Pierrot", UnitPrice = 27.20M }
             }
           },
                  new Order(){ OrderID = 10360, OrderDate = new DateTime(1996, 11, 22), CustomerID = "BLONP", ShippedDate = new DateTime(1996, 12, 2),ShipperName = "Federal Shipping",ShipTo = "Blondel père et fils\n24, place Kléber\nStrasbourg, 67000\nFrance",
            BillTo ="Blondel père et fils\n24, place Kléber\nStrasbourg, 67000\nFrance", Freight = 131.70M, OrderDetails = new List<OrderDetail>() {
                new OrderDetail { ProductID = 28, Quantity = 30, ProductName= "Rössle Sauerkraut", UnitPrice = 36.40M },
                new OrderDetail { ProductID = 29, Quantity = 35, ProductName= "Thüringer Rostbratwurst", UnitPrice = 99M },
                new OrderDetail { ProductID = 38, Quantity = 10, ProductName= "Côte de Blaye", UnitPrice = 210.80M },
                new OrderDetail { ProductID = 49, Quantity = 35, ProductName= "Maxilaku", UnitPrice = 16M },
                new OrderDetail { ProductID = 54, Quantity = 28, ProductName= "Tourtière", UnitPrice = 5.90M }
            }
           },

                     new Order(){ OrderID = 10979, OrderDate = new DateTime(1998, 3, 26), CustomerID = "ERNSH", ShippedDate = new DateTime(1998, 3, 31),ShipperName = "United Package",ShipTo = "Ernst Handel\nKirchgasse 6\nGraz, 8010\nAustria",
            BillTo ="Ernst Handel\nKirchgasse 6\nGraz, 8010\nAustria", Freight = 353.07M, OrderDetails = new List<OrderDetail>() {
                new OrderDetail { ProductID = 7, Quantity = 18, ProductName= "Uncle Bob's Organic Dried Pears", UnitPrice = 30M },
                new OrderDetail { ProductID = 12, Quantity = 20, ProductName= "Queso Manchego La Pastora", UnitPrice = 38M },
                new OrderDetail { ProductID = 24, Quantity = 80, ProductName= "Guaraná Fantástica", UnitPrice = 4.50M },
                new OrderDetail { ProductID = 27, Quantity = 30, ProductName= "Schoggi Schokolade", UnitPrice = 43.90M },
                new OrderDetail { ProductID = 31, Quantity = 24, ProductName= "Gorgonzola Telino", UnitPrice = 12.50M },
                new OrderDetail { ProductID = 63, Quantity = 35, ProductName= "Vegie-spread", UnitPrice = 43.90M }
            }
           },

             new Order(){ OrderID = 11077, OrderDate = new DateTime(2019, 1, 6), CustomerID = "RATTC", ShippedDate = new DateTime(2019, 1, 30),ShipperName = "United Package",ShipTo = "Rattlesnake Canyon Grocery\n2817 Milton Dr.\nAlbuquerque, NM 87110\nUSA",
            BillTo = "Rattlesnake Canyon Grocery\n2817 Milton Dr.\nAlbuquerque, NM 87110\nUSA", Freight = 8.53M, OrderDetails = new List<OrderDetail>() {
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
           },
        };

    public static List<Order> Orders
    {
        get { return orders; }
    }
}

