using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EJ2CoreSampleBrowser.Models
{
    public class FormulaData
    {
        public FormulaData(int OrderID, string ProductName, string Category, int Quantity, double PricePerUnit, string GrossAmount, string TaxAmount, string TotalAmount)
        {
            this.OrderID = OrderID;
            this.ProductName = ProductName;
            this.Category = Category;
            this.Quantity = Quantity;
            this.PricePerUnit = PricePerUnit;
            this.GrossAmount = GrossAmount;
            this.TaxAmount = TaxAmount;
            this.TotalAmount = TotalAmount;
        }

        public static List<FormulaData> GetData()
        {
            string[] products =
            {
            "Chai", "Chang", "Aniseed Syrup", "Chef Anton Gumbo Mix",
            "Chef Anton Seasoning", "Grandmas Boysenberry Spread",
            "Uncle Bob Organic Dried Pears", "Northwoods Cranberry Sauce",
            "Mishi Kobe Niku", "Ikura", "Queso Cabrales", "Queso Manchego",
            "Konbu", "Tofu", "Genen Shouyu", "Pavlova", "Alice Mutton",
            "Carnarvon Tigers", "Teatime Chocolate Biscuits",
            "Sir Rodneys Marmalade", "Sir Rodneys Scones",
            "Gustafs Knackebrod", "Tunnbrod", "Guarana Fantastica",
            "NuNuCa Nuss Nougat Creme", "Gumbear Gummibarchen",
            "Schoggi Schokolade", "Rassle Sauerkraut",
            "Thuringer Rostbratwurst", "Nord Ost Matjeshering",
            "Gorgonzola Telino", "Mascarpone Fabioli", "Geitost",
            "Sasquatch Ale", "Steeleye Stout", "Inlagd Sill",
            "Gravad Lax", "Cote de Blaye", "Chartreuse Verte",
            "Boston Crab Meat", "Jack New England Clam Chowder",
            "Singaporean Hokkien Fried Mee", "Ipoh Coffee",
            "Rogede Sild", "Spegesild", "Zaanse Koeken",
            "Chocolade", "Maxilaku", "Valkoinen Suklaa",
            "Manjimup Dried Apples", "Filo Mix", "Perth Pasties",
            "Tourtiere", "Pate Chinois", "Gnocchi di Nonna Alice",
            "Ravioli Angelo", "Escargots de Bourgogne",
            "Raclette Courdavault", "Camembert Pierrot",
            "Laughing Lumberjack Lager"
        };

            string[] categories =
            {
            "Beverages", "Beverages", "Condiments", "Condiments",
            "Condiments", "Condiments", "Produce", "Condiments",
            "Meat/Poultry", "Seafood", "Dairy Products",
            "Dairy Products", "Seafood", "Produce", "Condiments",
            "Confections", "Meat/Poultry", "Seafood", "Confections",
            "Confections", "Confections", "Grains/Cereals",
            "Grains/Cereals", "Beverages", "Confections",
            "Confections", "Confections", "Produce",
            "Meat/Poultry", "Seafood", "Dairy Products",
            "Dairy Products", "Dairy Products", "Beverages",
            "Beverages", "Seafood", "Seafood", "Beverages",
            "Beverages", "Seafood", "Seafood", "Grains/Cereals",
            "Beverages", "Seafood", "Seafood", "Confections",
            "Confections", "Confections", "Confections",
            "Produce", "Grains/Cereals", "Meat/Poultry",
            "Meat/Poultry", "Meat/Poultry", "Grains/Cereals",
            "Grains/Cereals", "Seafood", "Dairy Products",
            "Dairy Products", "Beverages"
        };

            var random = new Random(12345);
            var data = new List<FormulaData>();

            for (int i = 1; i <= 100; i++)
            {
                int index = (i - 1) % products.Length;

                int quantity = random.Next(1, 11);
                double pricePerUnit = Math.Round(random.NextDouble() * 100 + 5, 2);

                data.Add(new FormulaData(
                    i,
                    products[index],
                    categories[index],
                    quantity,
                    pricePerUnit,
                    $"=REF(COLUMN(\"Quantity\"),ROW({i}))*REF(COLUMN(\"PricePerUnit\"),ROW({i}))",
                    $"=REF(COLUMN(\"GrossAmount\"),ROW({i}))*0.07",
                    $"=REF(COLUMN(\"GrossAmount\"),ROW({i}))+REF(COLUMN(\"TaxAmount\"),ROW({i}))"
                ));
            }

            return data;
        }
        public int OrderID { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        public double PricePerUnit { get; set; }
        public string GrossAmount { get; set; }
        public string TaxAmount { get; set; }
        public string TotalAmount { get; set; }
    }
}
