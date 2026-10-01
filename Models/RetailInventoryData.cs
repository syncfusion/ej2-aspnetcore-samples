using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EJ2CoreSampleBrowser.Models
{
    public class RetailInventoryData
    {
        public int productId { get; set; }
        public int? parentId { get; set; }
        public string productName { get; set; }
        public string supplier { get; set; }
        public int? stockQty { get; set; }
        public int? reorderLevel { get; set; }
        public double? unitPrice { get; set; }
        public string status { get; set; }

        public static List<RetailInventoryData> GetRetailInventoryData()
        {
            List<RetailInventoryData> data = new List<RetailInventoryData>();

            // Beverages
            data.Add(new RetailInventoryData() { productId = 1001, productName = "Beverages", supplier = "Prime Distributors", stockQty = null, reorderLevel = null, unitPrice = null, status = "Active", parentId = null });
            data.Add(new RetailInventoryData() { productId = 1002, productName = "Cola Drink 500ml", supplier = "Metro Distribution", stockQty = 250, reorderLevel = 50, unitPrice = 40, status = "Active", parentId = 1001 });
            data.Add(new RetailInventoryData() { productId = 1003, productName = "Lemon Soda 500ml", supplier = "City Supply Partners", stockQty = 180, reorderLevel = 40, unitPrice = 38, status = "Active", parentId = 1001 });
            data.Add(new RetailInventoryData() { productId = 1004, productName = "Orange Soda 500ml", supplier = "West End Traders", stockQty = 55, reorderLevel = 60, unitPrice = 40, status = "Low Stock", parentId = 1001 });
            data.Add(new RetailInventoryData() { productId = 1005, productName = "Energy Drink 250ml", supplier = "Global Retail Supplies", stockQty = 15, reorderLevel = 30, unitPrice = 125, status = "Pending Restock", parentId = 1001 });
            data.Add(new RetailInventoryData() { productId = 1006, productName = "Orange Juice 1L", supplier = "North Region Suppliers", stockQty = 0, reorderLevel = 20, unitPrice = 110, status = "Out of Stock", parentId = 1001 });
            data.Add(new RetailInventoryData() { productId = 1007, productName = "Mixed Fruit Juice 1L", supplier = "Universal Traders", stockQty = 140, reorderLevel = 30, unitPrice = 105, status = "Active", parentId = 1001 });

            // Dairy Products
            data.Add(new RetailInventoryData() { productId = 1008, productName = "Dairy Products", supplier = "Central Wholesale", stockQty = null, reorderLevel = null, unitPrice = null, status = "Active", parentId = null });
            data.Add(new RetailInventoryData() { productId = 1009, productName = "Fresh Milk 1L", supplier = "South Region Suppliers", stockQty = 320, reorderLevel = 75, unitPrice = 68, status = "Active", parentId = 1008 });
            data.Add(new RetailInventoryData() { productId = 1010, productName = "Low Fat Milk 1L", supplier = "Prime Distributors", stockQty = 45, reorderLevel = 60, unitPrice = 72, status = "Low Stock", parentId = 1008 });
            data.Add(new RetailInventoryData() { productId = 1011, productName = "Butter 100g", supplier = "National Supply Chain", stockQty = 155, reorderLevel = 30, unitPrice = 58, status = "Active", parentId = 1008 });
            data.Add(new RetailInventoryData() { productId = 1012, productName = "Cheese Slices", supplier = "Metro Distribution", stockQty = 120, reorderLevel = 25, unitPrice = 145, status = "Active", parentId = 1008 });
            data.Add(new RetailInventoryData() { productId = 1013, productName = "Probiotic Drink", supplier = "Global Retail Supplies", stockQty = 0, reorderLevel = 15, unitPrice = 95, status = "Out of Stock", parentId = 1008 });
            data.Add(new RetailInventoryData() { productId = 1014, productName = "Curd 400g", supplier = "City Supply Partners", stockQty = 170, reorderLevel = 35, unitPrice = 42, status = "Active", parentId = 1008 });

            // Snacks
            data.Add(new RetailInventoryData() { productId = 1015, productName = "Snacks", supplier = "Metro Distribution", stockQty = null, reorderLevel = null, unitPrice = null, status = "Active", parentId = null });
            data.Add(new RetailInventoryData() { productId = 1016, productName = "Potato Chips Classic", supplier = "West End Traders", stockQty = 350, reorderLevel = 80, unitPrice = 20, status = "Active", parentId = 1015 });
            data.Add(new RetailInventoryData() { productId = 1017, productName = "Potato Chips Masala", supplier = "North Region Suppliers", stockQty = 310, reorderLevel = 70, unitPrice = 20, status = "Active", parentId = 1015 });
            data.Add(new RetailInventoryData() { productId = 1018, productName = "Triangle Corn Chips", supplier = "Universal Traders", stockQty = 220, reorderLevel = 50, unitPrice = 25, status = "Active", parentId = 1015 });
            data.Add(new RetailInventoryData() { productId = 1019, productName = "Nacho Chips", supplier = "Prime Distributors", stockQty = 18, reorderLevel = 30, unitPrice = 55, status = "Pending Restock", parentId = 1015 });
            data.Add(new RetailInventoryData() { productId = 1020, productName = "Spicy Mixture", supplier = "South Region Suppliers", stockQty = 185, reorderLevel = 40, unitPrice = 48, status = "Active", parentId = 1015 });
            data.Add(new RetailInventoryData() { productId = 1021, productName = "Crunchy Corn Snacks", supplier = "Central Wholesale", stockQty = 45, reorderLevel = 60, unitPrice = 20, status = "Low Stock", parentId = 1015 });

            // Personal Care
            data.Add(new RetailInventoryData() { productId = 1022, productName = "Personal Care", supplier = "Universal Traders", stockQty = null, reorderLevel = null, unitPrice = null, status = "Active", parentId = null });
            data.Add(new RetailInventoryData() { productId = 1023, productName = "Moisturizing Soap", supplier = "Global Retail Supplies", stockQty = 140, reorderLevel = 30, unitPrice = 48, status = "Active", parentId = 1022 });
            data.Add(new RetailInventoryData() { productId = 1024, productName = "Beauty Soap", supplier = "Metro Distribution", stockQty = 190, reorderLevel = 40, unitPrice = 38, status = "Active", parentId = 1022 });
            data.Add(new RetailInventoryData() { productId = 1025, productName = "Mint Toothpaste", supplier = "City Supply Partners", stockQty = 210, reorderLevel = 50, unitPrice = 95, status = "Active", parentId = 1022 });
            data.Add(new RetailInventoryData() { productId = 1026, productName = "Herbal Toothpaste", supplier = "West End Traders", stockQty = 35, reorderLevel = 50, unitPrice = 88, status = "Low Stock", parentId = 1022 });
            data.Add(new RetailInventoryData() { productId = 1027, productName = "Body Lotion", supplier = "National Supply Chain", stockQty = 0, reorderLevel = 0, unitPrice = 225, status = "Discontinued", parentId = 1022 });
            data.Add(new RetailInventoryData() { productId = 1028, productName = "Daily Care Shampoo", supplier = "South Region Suppliers", stockQty = 130, reorderLevel = 30, unitPrice = 78, status = "Active", parentId = 1022 });

            // Household Essentials
            data.Add(new RetailInventoryData() { productId = 1029, productName = "Household Essentials", supplier = "National Supply Chain", stockQty = null, reorderLevel = null, unitPrice = null, status = "Active", parentId = null });
            data.Add(new RetailInventoryData() { productId = 1030, productName = "Laundry Detergent", supplier = "Prime Distributors", stockQty = 145, reorderLevel = 35, unitPrice = 265, status = "Active", parentId = 1029 });
            data.Add(new RetailInventoryData() { productId = 1031, productName = "Premium Detergent", supplier = "Universal Traders", stockQty = 25, reorderLevel = 30, unitPrice = 280, status = "Low Stock", parentId = 1029 });
            data.Add(new RetailInventoryData() { productId = 1032, productName = "Dishwash Gel", supplier = "North Region Suppliers", stockQty = 180, reorderLevel = 40, unitPrice = 75, status = "Active", parentId = 1029 });
            data.Add(new RetailInventoryData() { productId = 1033, productName = "Toilet Cleaner", supplier = "City Supply Partners", stockQty = 12, reorderLevel = 20, unitPrice = 115, status = "Pending Restock", parentId = 1029 });
            data.Add(new RetailInventoryData() { productId = 1034, productName = "Floor Cleaner", supplier = "West End Traders", stockQty = 110, reorderLevel = 25, unitPrice = 165, status = "Active", parentId = 1029 });
            data.Add(new RetailInventoryData() { productId = 1035, productName = "Glass Cleaner", supplier = "Global Retail Supplies", stockQty = 0, reorderLevel = 10, unitPrice = 95, status = "Out of Stock", parentId = 1029 });

            return data;
        }
    }
}