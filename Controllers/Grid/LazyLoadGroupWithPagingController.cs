#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Controllers.Grid
{
    public partial class GridController : Controller
    {
        public static List<Customers> customers = new List<Customers>();
        public IActionResult LazyLoadGroupWithPaging()
        {
            if (customers.Count == 0)
                BindDataSource();
            ViewBag.lazyLoadData = customers;
            return View();
        }
        private void BindDataSource()
        {
            string[] customerid = {"VINET", "TOMSP", "HANAR", "VICTE", "SUPRD", "HANAR", "CHOPS", "RICSU", "WELLI", "HILAA", "ERNSH", "CENTC",
                "OTTIK", "QUEDE", "RATTC", "ERNSH", "FOLKO", "BLONP", "WARTH", "FRANK", "GROSR", "WHITC", "WARTH", "SPLIR", "RATTC", "QUICK", "VINET",
                "MAGAA", "TORTU", "MORGK", "BERGS", "LEHMS", "BERGS", "ROMEY", "ROMEY", "LILAS", "LEHMS", "QUICK", "QUICK", "RICAR", "REGGC", "BSBEV",
                "COMMI", "QUEDE", "TRADH", "TORTU", "RATTC", "VINET", "LILAS", "BLONP", "HUNGO", "RICAR", "MAGAA", "WANDK", "SUPRD", "GODOS", "TORTU",
                "OLDWO", "ROMEY", "LONEP", "ANATR", "HUNGO", "THEBI", "DUMON", "WANDK", "QUICK", "RATTC", "ISLAT", "RATTC", "LONEP", "ISLAT", "TORTU",
                "WARTH", "ISLAT", "PERIC", "KOENE", "SAVEA", "KOENE", "BOLID", "FOLKO", "FURIB", "SPLIR", "LILAS", "BONAP", "MEREP", "WARTH", "VICTE",
                "HUNGO", "PRINI", "FRANK", "OLDWO", "MEREP", "BONAP", "SIMOB", "FRANK", "LEHMS", "WHITC", "QUICK", "RATTC", "FAMIA" };

            string[] product = { "Chai", "Chang", "Aniseed Syrup", "Chef Anton\"s Cajun Seasoning", "Chef Anton\"s Gumbo Mix", "Grandma\"s Boysenberry Spread",
                "Uncle Bob\"s Organic Dried Pears", "Northwoods Cranberry Sauce", "Mishi Kobe Niku", "Ikura", "Queso Cabrales", "Queso Manchego La Pastora", "Konbu",
                "Tofu", "Genen Shouyu", "Pavlova", "Alice Mutton", "Carnarvon Tigers", "Teatime Chocolate Biscuits", "Sir Rodney\"s Marmalade", "Sir Rodney\"s Scones",
                "Gustaf\"s Knäckebröd", "Tunnbröd", "Guaraná Fantástica", "NuNuCa Nuß-Nougat-Creme", "Gumbär Gummibärchen", "Schoggi Schokolade", "Rössle Sauerkraut",
                "Thüringer Rostbratwurst", "Nord-Ost Matjeshering", "Gorgonzola Telino", "Mascarpone Fabioli", "Geitost", "Sasquatch Ale", "Steeleye Stout", "Inlagd Sill",
                "Gravad lax", "Côte de Blaye", "Chartreuse verte", "Boston Crab Meat", "Jack\"s New England Clam Chowder", "Singaporean Hokkien Fried Mee", "Ipoh Coffee",
                "Gula Malacca", "Rogede sild", "Spegesild", "Zaanse koeken", "Chocolade", "Maxilaku", "Valkoinen suklaa", "Manjimup Dried Apples", "Filo Mix", "Perth Pasties",
                "Tourtičre", "Pâté chinois", "Gnocchi di nonna Alice", "Ravioli Angelo", "Escargots de Bourgogne", "Raclette Courdavault", "Camembert Pierrot", "Sirop d\"érable",
                "Tarte au sucre", "Vegie-spread", "Wimmers gute Semmelknödel", "Louisiana Fiery Hot Pepper Sauce", "Louisiana Hot Spiced Okra", "Laughing Lumberjack Lager", "Scottish Longbreads",
                "Gudbrandsdalsost", "Outback Lager", "Flotemysost", "Mozzarella di Giovanni", "Röd Kaviar", "Longlife Tofu", "Rhönbräu Klosterbier", "Lakkalikööri", "Original Frankfurter grüne Soße" };

            string[] customername = { "Maria", "Ana Trujillo", "Antonio Moreno", "Thomas Hardy", "Christina Berglund", "Hanna Moos", "Frédérique Citeaux", "Martín Sommer", "Laurence Lebihan", "Elizabeth Lincoln",
                "Victoria Ashworth", "Patricio Simpson", "Francisco Chang", "Yang Wang", "Pedro Afonso", "Elizabeth Brown", "Sven Ottlieb", "Janine Labrune", "Ann Devon", "Roland Mendel", "Aria Cruz", "Diego Roel",
                "Martine Rancé", "Maria Larsson", "Peter Franken", "Carine Schmitt", "Paolo Accorti", "Lino Rodriguez", "Eduardo Saavedra", "José Pedro Freyre", "André Fonseca", "Howard Snyder", "Manuel Pereira",
                "Mario Pontes", "Carlos Hernández", "Yoshi Latimer", "Patricia McKenna", "Helen Bennett", "Philip Cramer", "Daniel Tonini", "Annette Roulet", "Yoshi Tannamuri", "John Steel", "Renate Messner", "Jaime Yorres",
                "Carlos González", "Felipe Izquierdo", "Fran Wilson", "Giovanni Rovelli", "Catherine Dewey", "Jean Fresničre", "Alexander Feuer", "Simon Crowther", "Yvonne Moncada", "Rene Phillips", "Henriette Pfalzheim",
                "Marie Bertrand", "Guillermo Fernández", "Georg Pipps", "Isabel de Castro", "Bernardo Batista", "Lúcia Carvalho", "Horst Kloss", "Sergio Gutiérrez", "Paula Wilson", "Maurizio Moroni", "Janete Limeira", "Michael Holz",
                "Alejandra Camino", "Jonas Bergulfsen", "Jose Pavarotti", "Hari Kumar", "Jytte Petersen", "Dominique Perrier", "Art Braunschweiger", "Pascale Cartrain", "Liz Nixon", "Liu Wong", "Karin Josephs", "Miguel Angel Paolino",
                "Anabela Domingues", "Helvetius Nagy", "Palle Ibsen", "Mary Saveley", "Paul Henriot", "Rita Müller", "Pirkko Koskitalo", "Paula Parente", "Karl Jablonski", "Matti Karttunen", "Zbyszek Piestrzeniewicz" };

            string[] customeraddress = { "507 - 20th Ave. E.\r\nApt. 2A", "908 W. Capital Way", "722 Moss Bay Blvd.", "4110 Old Redmond Rd.", "14 Garrett Hill", "Coventry House\r\nMiner Rd.", "Edgeham Hollow\r\nWinchester Way",
                "4726 - 11th Ave. N.E.", "7 Houndstooth Rd.", "59 rue de l\"Abbaye", "Luisenstr. 48", "908 W. Capital Way", "722 Moss Bay Blvd.", "4110 Old Redmond Rd.", "14 Garrett Hill", "Coventry House\r\nMiner Rd.", "Edgeham Hollow\r\nWinchester Way",
                "7 Houndstooth Rd.", "2817 Milton Dr.", "Kirchgasse 6", "Sierras de Granada 9993", "Mehrheimerstr. 369", "Rua da Panificadora, 12", "2817 Milton Dr.", "Mehrheimerstr. 369" };

            string[] quantityperunit = { "10 boxes x 20 bags", "24 - 12 oz bottles", "12 - 550 ml bottles", "48 - 6 oz jars", "36 boxes", "12 - 8 oz jars", "12 - 1 lb pkgs.", "12 - 12 oz jars", "18 - 500 g pkgs.", "12 - 200 ml jars",
                "1 kg pkg.", "10 - 500 g pkgs.", "2 kg box", "40 - 100 g pkgs.", "24 - 250 ml bottles", "32 - 500 g boxes", "20 - 1 kg tins", "16 kg pkg.", "10 boxes x 12 pieces", "30 gift boxes", "24 pkgs. x 4 pieces", "24 - 500 g pkgs.", "12 - 250 g pkgs.",
                "12 - 355 ml cans", "20 - 450 g glasses", "100 - 250 g bags" };
            int OrderID = 10248;
            int i = 0; int j = 0; int k = 0; int l = 0; int m = 0;
            for (int x = 0; x < 20000; x++)
            {
                i = i >= customerid.Length ? 0 : i; j = j >= customername.Length ? 0 : j; k = k >= customeraddress.Length ? 0 : k; l = l >= product.Length ? 0 : l; m = m >= quantityperunit.Length ? 0 : m;
                customers.Add(new Customers() { OrderID = OrderID + x, CustomerID = customerid[i], CustomerName = customername[j], CustomerAddress = customeraddress[k], ProductName = product[l], ProductID = x, Quantity = quantityperunit[m] });
                i++; j++; k++; l++; m++;
            }
        }
        public class Customers
        {
            public int OrderID { get; set; }
            public string CustomerID { get; set; }
            public string CustomerName { get; set; }
            public string CustomerAddress { get; set; }
            public string ProductName { get; set; }
            public int ProductID { get; set; }
            public string Quantity { get; set; }
        }
    }
}