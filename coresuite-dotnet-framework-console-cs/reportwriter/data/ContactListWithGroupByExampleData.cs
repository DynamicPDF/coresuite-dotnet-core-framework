using System.Collections.Generic;

/// <summary>
/// Summary description for ContactListWithGroupByExampleData
/// </summary>
public class ContactListWithGroupByExampleData
{
    public class Contact
    {
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
    }

    private static List<Contact> contacts = new List<Contact>()
        {
            new Contact { CustomerID = "ALFKI", CompanyName = "Alfreds Futterkiste", ContactName = "Maria Anders", ContactTitle = "Sales Representative", Phone = "030-0074321", Fax = "030-0076545" },
            new Contact { CustomerID = "ANATR", CompanyName = "Ana Trujillo Emparedados y helados", ContactName = "Ana Trujillo", ContactTitle = "Owner", Phone = "(5) 555-4729", Fax = "(5) 555-3745" },
            new Contact { CustomerID = "ANTON", CompanyName = "Antonio Moreno Taquería", ContactName = "Antonio Moreno", ContactTitle = "Owner", Phone = "(5) 555-3932", Fax = null },
            new Contact { CustomerID = "AROUT", CompanyName = "Around the Horn", ContactName = "Thomas Hardy", ContactTitle = "Sales Representative", Phone = "(171) 555-7788", Fax = "(171) 555-6750" },
            new Contact { CustomerID = "BERGS", CompanyName = "Berglunds snabbköp", ContactName = "Christina Berglund", ContactTitle = "Order Administrator", Phone = "0921-12 34 65", Fax = "0921-12 34 67" },
            new Contact { CustomerID = "BLAUS", CompanyName = "Blauer See Delikatessen", ContactName = "Hanna Moos", ContactTitle = "Sales Representative", Phone = "0621-08460", Fax = "0621-08924" },
            new Contact { CustomerID = "BLONP", CompanyName = "Blondesddsl père et fils", ContactName = "Frédérique Citeaux", ContactTitle = "Marketing Manager", Phone = "88.60.15.31", Fax = "88.60.15.32" },
            new Contact { CustomerID = "BOLID", CompanyName = "Bólido Comidas preparadas", ContactName = "Martín Sommer", ContactTitle = "Owner", Phone = "(91) 555 22 82", Fax = "(91) 555 91 99" },
            new Contact { CustomerID = "BONAP", CompanyName = "Bon app'", ContactName = "Laurence Lebihan", ContactTitle = "Owner", Phone = "91.24.45.40", Fax = "91.24.45.41" },
            new Contact { CustomerID = "BOTTM", CompanyName = "Bottom-Dollar Markets", ContactName = "Elizabeth Lincoln", ContactTitle = "Accounting Manager", Phone = "(604) 555-4729", Fax = "(604) 555-3745" },
            new Contact { CustomerID = "BSBEV", CompanyName = "B's Beverages", ContactName = "Victoria Ashworth", ContactTitle = "Sales Representative", Phone = "(171) 555-1212", Fax = null },
            new Contact { CustomerID = "CACTU", CompanyName = "Cactus Comidas para llevar", ContactName = "Patricio Simpson", ContactTitle = "Sales Agent", Phone = "(1) 135-5555", Fax = "(1) 135-4892" },
            new Contact { CustomerID = "CENTC", CompanyName = "Centro comercial Moctezuma", ContactName = "Francisco Chang", ContactTitle = "Marketing Manager", Phone = "(5) 555-3392", Fax = "(5) 555-7293" },
            new Contact { CustomerID = "CHOPS", CompanyName = "Chop-suey Chinese", ContactName = "Yang Wang", ContactTitle = "Owner", Phone = "0452-076545", Fax = null },
            new Contact { CustomerID = "COMMI", CompanyName = "Comércio Mineiro", ContactName = "Pedro Afonso", ContactTitle = "Sales Associate", Phone = "(11) 555-7647", Fax = null },
            new Contact { CustomerID = "CONSH", CompanyName = "Consolidated Holdings", ContactName = "Elizabeth Brown", ContactTitle = "Sales Representative", Phone = "(171) 555-2282", Fax = "(171) 555-9199" },
            new Contact { CustomerID = "WANDK", CompanyName = "Die Wandernde Kuh", ContactName = "Rita Müller", ContactTitle = "Sales Representative", Phone = "0711-020361", Fax = "0711-035428" },
            new Contact { CustomerID = "DRACD", CompanyName = "Drachenblut Delikatessen", ContactName = "Sven Ottlieb", ContactTitle = "Order Administrator", Phone = "0241-039123", Fax = "0241-059428" },
            new Contact { CustomerID = "DUMON", CompanyName = "Du monde entier", ContactName = "Janine Labrune", ContactTitle = "Owner", Phone = "40.67.88.88", Fax = "40.67.89.89" },
            new Contact { CustomerID = "EASTC", CompanyName = "Eastern Connection", ContactName = "Ann Devon", ContactTitle = "Sales Agent", Phone = "(171) 555-0297", Fax = "(171) 555-3373" },
            new Contact { CustomerID = "ERNSH", CompanyName = "Ernst Handel", ContactName = "Roland Mendel", ContactTitle = "Sales Manager", Phone = "7675-3425", Fax = "7675-3426" },
            new Contact { CustomerID = "FAMIA", CompanyName = "Familia Arquibaldo", ContactName = "Aria Cruz", ContactTitle = "Marketing Assistant", Phone = "(11) 555-9857", Fax = null },
            new Contact { CustomerID = "FISSA", CompanyName = "FISSA Fabrica Inter. Salchichas S.A.", ContactName = "Diego Roel", ContactTitle = "Accounting Manager", Phone = "(91) 555 94 44", Fax = "(91) 555 55 93" },
            new Contact { CustomerID = "FOLIG", CompanyName = "Folies gourmandes", ContactName = "Martine Rancé", ContactTitle = "Assistant Sales Agent", Phone = "20.16.10.16", Fax = "20.16.10.17" },
            new Contact { CustomerID = "FOLKO", CompanyName = "Folk och fä HB", ContactName = "Maria Larsson", ContactTitle = "Owner", Phone = "0695-34 67 21", Fax = null },
            new Contact { CustomerID = "FRANR", CompanyName = "France restauration", ContactName = "Carine Schmitt", ContactTitle = "Marketing Manager", Phone = "40.32.21.21", Fax = "40.32.21.20" },
            new Contact { CustomerID = "FRANS", CompanyName = "Franchi S.p.A.", ContactName = "Paolo Accorti", ContactTitle = "Sales Representative", Phone = "011-4988260", Fax = "011-4988261" },
            new Contact { CustomerID = "FRANK", CompanyName = "Frankenversand", ContactName = "Peter Franken", ContactTitle = "Marketing Manager", Phone = "089-0877310", Fax = "089-0877451" },
            new Contact { CustomerID = "FURIB", CompanyName = "Furia Bacalhau e Frutos do Mar", ContactName = "Lino Rodriguez", ContactTitle = "Sales Manager", Phone = "(1) 354-2534", Fax = "(1) 354-2535" },
            new Contact { CustomerID = "GALED", CompanyName = "Galería del gastrónomo", ContactName = "Eduardo Saavedra", ContactTitle = "Marketing Manager", Phone = "(93) 203 4560", Fax = "(93) 203 4561" },
            new Contact { CustomerID = "GODOS", CompanyName = "Godos Cocina Típica", ContactName = "José Pedro Freyre", ContactTitle = "Sales Manager", Phone = "(95) 555 82 82", Fax = null },
            new Contact { CustomerID = "GOURL", CompanyName = "Gourmet Lanchonetes", ContactName = "André Fonseca", ContactTitle = "Sales Associate", Phone = "(11) 555-9482", Fax = null },
            new Contact { CustomerID = "GREAL", CompanyName = "Great Lakes Food Market", ContactName = "Howard Snyder", ContactTitle = "Marketing Manager", Phone = "(503) 555-7555", Fax = null },
            new Contact { CustomerID = "GROSR", CompanyName = "GROSELLA-Restaurante", ContactName = "Manuel Pereira", ContactTitle = "Owner", Phone = "(2) 283-2951", Fax = "(2) 283-3397" },
            new Contact { CustomerID = "HANAR", CompanyName = "Hanari Carnes", ContactName = "Mario Pontes", ContactTitle = "Accounting Manager", Phone = "(21) 555-0091", Fax = "(21) 555-8765" },
            new Contact { CustomerID = "HILAA", CompanyName = "HILARION-Abastos", ContactName = "Carlos Hernández", ContactTitle = "Sales Representative", Phone = "(5) 555-1340", Fax = "(5) 555-1948" },
            new Contact { CustomerID = "HUNGC", CompanyName = "Hungry Coyote Import Store", ContactName = "Yoshi Latimer", ContactTitle = "Sales Representative", Phone = "(503) 555-6874", Fax = "(503) 555-2376" },
            new Contact { CustomerID = "HUNGO", CompanyName = "Hungry Owl All-Night Grocers", ContactName = "Patricia McKenna", ContactTitle = "Sales Associate", Phone = "2967 542", Fax = "2967 3333" },
            new Contact { CustomerID = "ISLAT", CompanyName = "Island Trading", ContactName = "Helen Bennett", ContactTitle = "Marketing Manager", Phone = "(198) 555-8888", Fax = null },
            new Contact { CustomerID = "KOENE", CompanyName = "Königlich Essen", ContactName = "Philip Cramer", ContactTitle = "Sales Associate", Phone = "0555-09876", Fax = null },
            new Contact { CustomerID = "LACOR", CompanyName = "La corne d'abondance", ContactName = "Daniel Tonini", ContactTitle = "Sales Representative", Phone = "30.59.84.10", Fax = "30.59.85.11" },
            new Contact { CustomerID = "LAMAI", CompanyName = "La maison d'Asie", ContactName = "Annette Roulet", ContactTitle = "Sales Manager", Phone = "61.77.61.10", Fax = "61.77.61.11" },
            new Contact { CustomerID = "LAUGB", CompanyName = "Laughing Bacchus Wine Cellars", ContactName = "Yoshi Tannamuri", ContactTitle = "Marketing Assistant", Phone = "(604) 555-3392", Fax = "(604) 555-7293" },
            new Contact { CustomerID = "LAZYK", CompanyName = "Lazy K Kountry Store", ContactName = "John Steel", ContactTitle = "Marketing Manager", Phone = "(509) 555-7969", Fax = "(509) 555-6221" },
            new Contact { CustomerID = "LEHMS", CompanyName = "Lehmanns Marktstand", ContactName = "Renate Messner", ContactTitle = "Sales Representative", Phone = "069-0245984", Fax = "069-0245874" },
            new Contact { CustomerID = "LETSS", CompanyName = "Let's Stop N Shop", ContactName = "Jaime Yorres", ContactTitle = "Owner", Phone = "(415) 555-5938", Fax = null },
            new Contact { CustomerID = "LILAS", CompanyName = "LILA-Supermercado", ContactName = "Carlos González", ContactTitle = "Accounting Manager", Phone = "(9) 331-6954", Fax = "(9) 331-7256" },
            new Contact { CustomerID = "LINOD", CompanyName = "LINO-Delicateses", ContactName = "Felipe Izquierdo", ContactTitle = "Owner", Phone = "(8) 34-56-12", Fax = "(8) 34-93-93" },
            new Contact { CustomerID = "LONEP", CompanyName = "Lonesome Pine Restaurant", ContactName = "Fran Wilson", ContactTitle = "Sales Manager", Phone = "(503) 555-9573", Fax = "(503) 555-9646" },
            new Contact { CustomerID = "MAGAA", CompanyName = "Magazzini Alimentari Riuniti", ContactName = "Giovanni Rovelli", ContactTitle = "Marketing Manager", Phone = "035-640230", Fax = "035-640231" },
            new Contact { CustomerID = "MAISD", CompanyName = "Maison Dewey", ContactName = "Catherine Dewey", ContactTitle = "Sales Agent", Phone = "(02) 201 24 67", Fax = "(02) 201 24 68" },
            new Contact { CustomerID = "MEREP", CompanyName = "Mère Paillarde", ContactName = "Jean Fresnière", ContactTitle = "Marketing Assistant", Phone = "(514) 555-8054", Fax = "(514) 555-8055" },
            new Contact { CustomerID = "MORGK", CompanyName = "Morgenstern Gesundkost", ContactName = "Alexander Feuer", ContactTitle = "Marketing Assistant", Phone = "0342-023176", Fax = null },
            new Contact { CustomerID = "NORTS", CompanyName = "North/South", ContactName = "Simon Crowther", ContactTitle = "Sales Associate", Phone = "(171) 555-7733", Fax = "(171) 555-2530" },
            new Contact { CustomerID = "OCEAN", CompanyName = "Océano Atlántico Ltda.", ContactName = "Yvonne Moncada", ContactTitle = "Sales Agent", Phone = "(1) 135-5333", Fax = "(1) 135-5535" },
            new Contact { CustomerID = "OLDWO", CompanyName = "Old World Delicatessen", ContactName = "Rene Phillips", ContactTitle = "Sales Representative", Phone = "(907) 555-7584", Fax = "(907) 555-2880" },
            new Contact { CustomerID = "OTTIK", CompanyName = "Ottilies Käseladen", ContactName = "Henriette Pfalzheim", ContactTitle = "Owner", Phone = "0221-0644327", Fax = "0221-0765721" },
            new Contact { CustomerID = "PARIS", CompanyName = "Paris spécialités", ContactName = "Marie Bertrand", ContactTitle = "Owner", Phone = "(1) 42.34.22.66", Fax = "(1) 42.34.22.77" },
            new Contact { CustomerID = "PERIC", CompanyName = "Pericles Comidas clásicas", ContactName = "Guillermo Fernández", ContactTitle = "Sales Representative", Phone = "(5) 552-3745", Fax = "(5) 545-3745" },
            new Contact { CustomerID = "PICCO", CompanyName = "Piccolo und mehr", ContactName = "Georg Pipps", ContactTitle = "Sales Manager", Phone = "6562-9722", Fax = "6562-9723" },
            new Contact { CustomerID = "PRINI", CompanyName = "Princesa Isabel Vinhos", ContactName = "Isabel de Castro", ContactTitle = "Sales Representative", Phone = "(1) 356-5634", Fax = null },
            new Contact { CustomerID = "QUEDE", CompanyName = "Que Delícia", ContactName = "Bernardo Batista", ContactTitle = "Accounting Manager", Phone = "(21) 555-4252", Fax = "(21) 555-4545" },
            new Contact { CustomerID = "QUEEN", CompanyName = "Queen Cozinha", ContactName = "Lúcia Carvalho", ContactTitle = "Marketing Assistant", Phone = "(11) 555-1189", Fax = null },
            new Contact { CustomerID = "QUICK", CompanyName = "QUICK-Stop", ContactName = "Horst Kloss", ContactTitle = "Accounting Manager", Phone = "0372-035188", Fax = null },
            new Contact { CustomerID = "RANCH", CompanyName = "Rancho grande", ContactName = "Sergio Gutiérrez", ContactTitle = "Sales Representative", Phone = "(1) 123-5555", Fax = "(1) 123-5556" },
            new Contact { CustomerID = "RATTC", CompanyName = "Rattlesnake Canyon Grocery", ContactName = "Paula Wilson", ContactTitle = "Assistant Sales Representative", Phone = "(505) 555-5939", Fax = "(505) 555-3620" },
            new Contact { CustomerID = "REGGC", CompanyName = "Reggiani Caseifici", ContactName = "Maurizio Moroni", ContactTitle = "Sales Associate", Phone = "0522-556721", Fax = "0522-556722" },
            new Contact { CustomerID = "RICAR", CompanyName = "Ricardo Adocicados", ContactName = "Janete Limeira", ContactTitle = "Assistant Sales Agent", Phone = "(21) 555-3412", Fax = null },
            new Contact { CustomerID = "RICSU", CompanyName = "Richter Supermarkt", ContactName = "Michael Holz", ContactTitle = "Sales Manager", Phone = "0897-034214", Fax = null },
            new Contact { CustomerID = "ROMEY", CompanyName = "Romero y tomillo", ContactName = "Alejandra Camino", ContactTitle = "Accounting Manager", Phone = "(91) 745 6200", Fax = "(91) 745 6210" },
            new Contact { CustomerID = "SANTG", CompanyName = "Santé Gourmet", ContactName = "Jonas Bergulfsen", ContactTitle = "Owner", Phone = "07-98 92 35", Fax = "07-98 92 47" },
            new Contact { CustomerID = "SAVEA", CompanyName = "Save-a-lot Markets", ContactName = "Jose Pavarotti", ContactTitle = "Sales Representative", Phone = "(208) 555-8097", Fax = null },
            new Contact { CustomerID = "SEVES", CompanyName = "Seven Seas Imports", ContactName = "Hari Kumar", ContactTitle = "Sales Manager", Phone = "(171) 555-1717", Fax = "(171) 555-5646" },
            new Contact { CustomerID = "SIMOB", CompanyName = "Simons bistro", ContactName = "Jytte Petersen", ContactTitle = "Owner", Phone = "31 12 34 56", Fax = "31 13 35 57" },
            new Contact { CustomerID = "SPECD", CompanyName = "Spécialités du monde", ContactName = "Dominique Perrier", ContactTitle = "Marketing Manager", Phone = "(1) 47.55.60.10", Fax = "(1) 47.55.60.20" },
            new Contact { CustomerID = "SPLIR", CompanyName = "Split Rail Beer & Ale", ContactName = "Art Braunschweiger", ContactTitle = "Sales Manager", Phone = "(307) 555-4680", Fax = "(307) 555-6525" },
            new Contact { CustomerID = "SUPRD", CompanyName = "Suprêmes délices", ContactName = "Pascale Cartrain", ContactTitle = "Accounting Manager", Phone = "(071) 23 67 22 20", Fax = "(071) 23 67 22 21" },
            new Contact { CustomerID = "THEBI", CompanyName = "The Big Cheese", ContactName = "Liz Nixon", ContactTitle = "Marketing Manager", Phone = "(503) 555-3612", Fax = null },
            new Contact { CustomerID = "THECR", CompanyName = "The Cracker Box", ContactName = "Liu Wong", ContactTitle = "Marketing Assistant", Phone = "(406) 555-5834", Fax = "(406) 555-8083" },
            new Contact { CustomerID = "TOMSP", CompanyName = "Toms Spezialitäten", ContactName = "Karin Josephs", ContactTitle = "Marketing Manager", Phone = "0251-031259", Fax = "0251-035695" },
            new Contact { CustomerID = "TORTU", CompanyName = "Tortuga Restaurante", ContactName = "Miguel Angel Paolino", ContactTitle = "Owner", Phone = "(5) 555-2933", Fax = null },
            new Contact { CustomerID = "TRADH", CompanyName = "Tradição Hipermercados", ContactName = "Anabela Domingues", ContactTitle = "Sales Representative", Phone = "(11) 555-2167", Fax = "(11) 555-2168" },
            new Contact { CustomerID = "TRAIH", CompanyName = "Trail's Head Gourmet Provisioners", ContactName = "Helvetius Nagy", ContactTitle = "Sales Associate", Phone = "(206) 555-8257", Fax = "(206) 555-2174" },
            new Contact { CustomerID = "VAFFE", CompanyName = "Vaffeljernet", ContactName = "Palle Ibsen", ContactTitle = "Sales Manager", Phone = "86 21 32 43", Fax = "86 22 33 44" },
            new Contact { CustomerID = "VICTE", CompanyName = "Victuailles en stock", ContactName = "Mary Saveley", ContactTitle = "Sales Agent", Phone = "78.32.54.86", Fax = "78.32.54.87" },
            new Contact { CustomerID = "VINET", CompanyName = "Vins et alcools Chevalier", ContactName = "Paul Henriot", ContactTitle = "Accounting Manager", Phone = "26.47.15.10", Fax = "26.47.15.11" },
            new Contact { CustomerID = "WARTH", CompanyName = "Wartian Herkku", ContactName = "Pirkko Koskitalo", ContactTitle = "Accounting Manager", Phone = "981-443655", Fax = "981-443655" },
            new Contact { CustomerID = "WELLI", CompanyName = "Wellington Importadora", ContactName = "Paula Parente", ContactTitle = "Sales Manager", Phone = "(14) 555-8122", Fax = null },
            new Contact { CustomerID = "WHITC", CompanyName = "White Clover Markets", ContactName = "Karl Jablonski", ContactTitle = "Owner", Phone = "(206) 555-4112", Fax = "(206) 555-4115" },
            new Contact { CustomerID = "WILMK", CompanyName = "Wilman Kala", ContactName = "Matti Karttunen", ContactTitle = "Owner/Marketing Assistant", Phone = "90-224 8858", Fax = "90-224 8858" },
            new Contact { CustomerID = "WOLZA", CompanyName = "Wolski  Zajazd", ContactName = "Zbyszek Piestrzeniewicz", ContactTitle = "Owner", Phone = "(26) 642-7012", Fax = "(26) 642-7012" }
        };

    public static List<Contact> Contacts
    {
        get { return contacts; }
    }
}
