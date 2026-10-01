using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EJ2CoreSampleBrowser.Models
{
    public class InventoryStoreData
    {
        public string ID { get; set; }
        public string Product { get; set; }
        public string Category { get; set; }
        public decimal UnitPrice { get; set; }
        public int VendorA { get; set; }
        public int VendorB { get; set; }
        public int VendorC { get; set; }
        public int VendorD { get; set; }

        // ✅ Static Data Method
        public static List<InventoryStoreData> GetAllRecords()
        {
            return new List<InventoryStoreData>()
            {
                new InventoryStoreData { ID = "ID-1001", Product = "MacBook Pro", Category = "IT Asset", UnitPrice = 1200, VendorA = 55, VendorB = 40, VendorC = 60, VendorD = 35 },
                new InventoryStoreData { ID = "ID-1002", Product = "Wireless Mouse", Category = "IT Asset", UnitPrice = 25, VendorA = 120, VendorB = 95, VendorC = 110, VendorD = 80 },
                new InventoryStoreData { ID = "ID-1003", Product = "4K Monitor", Category = "IT Asset", UnitPrice = 400, VendorA = 45, VendorB = 50, VendorC = 38, VendorD = 42 },
                new InventoryStoreData { ID = "ID-1004", Product = "WiFi Router", Category = "IT Infrastructure", UnitPrice = 120, VendorA = 75, VendorB = 68, VendorC = 80, VendorD = 72 },
                new InventoryStoreData { ID = "ID-1005", Product = "SSD Drive", Category = "IT Asset", UnitPrice = 150, VendorA = 110, VendorB = 90, VendorC = 105, VendorD = 88 },
                new InventoryStoreData { ID = "ID-1006", Product = "Laser Printer", Category = "Admin", UnitPrice = 300, VendorA = 35, VendorB = 30, VendorC = 28, VendorD = 25 },
                new InventoryStoreData { ID = "ID-1007", Product = "Security Camera", Category = "Security", UnitPrice = 120, VendorA = 50, VendorB = 45, VendorC = 55, VendorD = 48 },
                new InventoryStoreData { ID = "ID-1008", Product = "HP Laptop", Category = "IT Asset", UnitPrice = 750, VendorA = 65, VendorB = 58, VendorC = 70, VendorD = 62 },
                new InventoryStoreData { ID = "ID-1009", Product = "UltraWide Monitor", Category = "IT Asset", UnitPrice = 500, VendorA = 48, VendorB = 42, VendorC = 50, VendorD = 45 },
                new InventoryStoreData { ID = "ID-1010", Product = "Network Switch", Category = "IT Infrastructure", UnitPrice = 220, VendorA = 60, VendorB = 55, VendorC = 65, VendorD = 58 },
                new InventoryStoreData { ID = "ID-1011", Product = "External Hard Drive", Category = "IT Asset", UnitPrice = 130, VendorA = 95, VendorB = 88, VendorC = 100, VendorD = 90 },
                new InventoryStoreData { ID = "ID-1012", Product = "Standing Desk", Category = "Facilities", UnitPrice = 350, VendorA = 35, VendorB = 30, VendorC = 32, VendorD = 28 },
                new InventoryStoreData { ID = "ID-1013", Product = "Scanner", Category = "Finance", UnitPrice = 150, VendorA = 25, VendorB = 22, VendorC = 28, VendorD = 20 },
                new InventoryStoreData { ID = "ID-1014", Product = "Tablet Device", Category = "Sales", UnitPrice = 220, VendorA = 45, VendorB = 40, VendorC = 48, VendorD = 42 },
                new InventoryStoreData { ID = "ID-1015", Product = "Dell Laptop", Category = "IT Asset", UnitPrice = 800, VendorA = 70, VendorB = 65, VendorC = 75, VendorD = 60 },
                new InventoryStoreData { ID = "ID-1016", Product = "USB Hub", Category = "IT Asset", UnitPrice = 20, VendorA = 95, VendorB = 85, VendorC = 100, VendorD = 88 },
                new InventoryStoreData { ID = "ID-1017", Product = "LED Screen", Category = "Marketing", UnitPrice = 300, VendorA = 55, VendorB = 50, VendorC = 60, VendorD = 52 },
                new InventoryStoreData { ID = "ID-1018", Product = "Access Point", Category = "IT Infrastructure", UnitPrice = 180, VendorA = 58, VendorB = 52, VendorC = 60, VendorD = 55 },
                new InventoryStoreData { ID = "ID-1019", Product = "NAS Storage", Category = "IT Infrastructure", UnitPrice = 600, VendorA = 65, VendorB = 60, VendorC = 70, VendorD = 62 },
                new InventoryStoreData { ID = "ID-1020", Product = "Filing Cabinet", Category = "Facilities", UnitPrice = 180, VendorA = 45, VendorB = 40, VendorC = 50, VendorD = 42 },
                new InventoryStoreData { ID = "ID-1021", Product = "Projector", Category = "Training", UnitPrice = 450, VendorA = 20, VendorB = 18, VendorC = 22, VendorD = 19 },
                new InventoryStoreData { ID = "ID-1022", Product = "Smart Phone", Category = "IT Asset", UnitPrice = 700, VendorA = 75, VendorB = 70, VendorC = 80, VendorD = 68 },
                new InventoryStoreData { ID = "ID-1023", Product = "Desktop Workstation", Category = "IT Asset", UnitPrice = 950, VendorA = 65, VendorB = 60, VendorC = 70, VendorD = 55 },
                new InventoryStoreData { ID = "ID-1024", Product = "Laptop Stand", Category = "IT Asset", UnitPrice = 35, VendorA = 85, VendorB = 75, VendorC = 90, VendorD = 80 },
                new InventoryStoreData { ID = "ID-1025", Product = "UltraWide Monitor", Category = "IT Asset", UnitPrice = 520, VendorA = 42, VendorB = 38, VendorC = 45, VendorD = 40 },
                new InventoryStoreData { ID = "ID-1026", Product = "WiFi Router", Category = "IT Infrastructure", UnitPrice = 125, VendorA = 80, VendorB = 75, VendorC = 85, VendorD = 70 },
                new InventoryStoreData { ID = "ID-1027", Product = "SSD Drive", Category = "IT Asset", UnitPrice = 155, VendorA = 100, VendorB = 95, VendorC = 105, VendorD = 90 },
                new InventoryStoreData { ID = "ID-1028", Product = "Docking Station", Category = "IT Asset", UnitPrice = 150, VendorA = 60, VendorB = 55, VendorC = 65, VendorD = 50 },
                new InventoryStoreData { ID = "ID-1029", Product = "Conference Speaker", Category = "Admin", UnitPrice = 220, VendorA = 30, VendorB = 25, VendorC = 28, VendorD = 22 },
                new InventoryStoreData { ID = "ID-1030", Product = "Biometric Device", Category = "Security", UnitPrice = 180, VendorA = 40, VendorB = 35, VendorC = 45, VendorD = 38 }
            };
        }
    }
}