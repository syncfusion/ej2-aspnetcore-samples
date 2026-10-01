using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EJ2CoreSampleBrowser.Models
{
    public class DomVirtualizationData
    {
        public int ItemID { get; set; }
        public int? ParentItemID { get; set; }
        public string ItemName { get; set; }
        public string ItemType { get; set; }
        public string SKU { get; set; }
        public string Category { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string Supplier { get; set; }
        public string StockStatus { get; set; }
        public int Quantity { get; set; }
        public int ReservedQuantity { get; set; }
        public int AvailableQuantity { get; set; }
        public int ReorderLevel { get; set; }
        public double? UnitPrice { get; set; }
        public double InventoryValue { get; set; }
        public int DailyOrders { get; set; }
        public int MonthlyUnitsSold { get; set; }
        public double FulfillmentRate { get; set; }
        public string DemandProfile { get; set; }
        public DateTime? LastRestocked { get; set; }
        public DateTime? NextDeliveryDate { get; set; }
        public int? StorageCapacity { get; set; }

        private static string[] warehouseNames = new string[]
        {
            "Chicago Central Fulfillment Center",
            "Dallas South Distribution Center",
            "Newark East Coast Hub",
            "Atlanta Regional Warehouse",
            "Reno West Fulfillment Center",
            "Seattle Pacific Hub",
            "Columbus Midwest Distribution Center",
            "Denver Mountain Warehouse",
            "Phoenix Desert Logistics Center",
            "Portland Northwest Terminal",
            "Memphis River Valley Depot",
            "Salt Lake City Intermountain Hub",
            "Richmond Mid-Atlantic Warehouse",
            "Kansas City Central Plains Center",
            "Nashville Southeast Logistics",
            "Detroit Great Lakes Facility",
            "Houston Gulf Coast Terminal",
            "Charlotte Southern Hub",
            "Omaha Heartland Distribution",
            "Tampa Bay Southeast Depot",
            "Milwaukee North Central Warehouse",
            "Louisville Derby City Logistics",
            "San Antonio Alamo Distribution",
            "Indianapolis Crossroads Hub",
            "Oakland Bay Area Terminal",
            "Raleigh Research Triangle Depot",
            "Orlando Sunshine Warehouse",
            "Hartford Northeast Logistics"
        };

        private static string[] warehouseRegions = new string[]
        {
            "United States", "Canada", "United Kingdom", "France", "Australia", "Japan", "Germany", "Singapore",
            "Brazil", "Netherlands", "South Korea", "Switzerland", "Sweden", "Italy", "Spain", "India"
        };

        private static string[] productNames = new string[]
        {
            "Wireless Noise-Cancelling Headphones",
            "Stainless Steel Water Bottle (750ml)",
            "Adjustable Ergonomic Laptop Stand",
            "USB-C 7-in-1 Fast Charging Hub",
            "Memory Foam Travel Neck Pillow",
            "Smart LED Desk Lamp with Dimmer",
            "Compact Digital Air Fryer (3.5L)",
            "Resistance Band Set (5-piece)",
            "Waterproof Hiking Daypack (35L)",
            "Ergonomic Mesh Office Chair",
            "Portable Bluetooth Speaker (Waterproof)",
            "Double-Wall Insulated Coffee Mug",
            "Ultra-Slim Wireless Charging Pad",
            "Electric Kettle with Temperature Control",
            "Bamboo Laptop Desk Table",
            "Yoga Mat with Alignment Lines (6mm)",
            "Cordless Vacuum Cleaner (Handheld)",
            "LED Ring Light for Video Conferencing",
            "Collapsible Silicone Food Storage Set",
            "Car Phone Mount (Dashboard/Air Vent)",
            "Mechanical Keyboard (Wireless RGB)",
            "Portable Power Bank (20000mAh)",
            "Scented Soy Candle Collection (3-pack)",
            "Electric Toothbrush with UV Sanitizer",
            "Anti-Fatigue Kitchen Mat (Gel Core)",
            "Laptop Privacy Screen Filter (14-inch)",
            "Reusable Beeswax Food Wraps (Set of 6)",
            "Smart Plug with Energy Monitoring",
            "Stainless Steel Lunch Box (3-compartment)",
            "Adjustable Standing Desk Converter",
            "Home Security Camera (Indoor/Outdoor)",
            "Compostable Trash Bags (30-pack)",
            "Digital Kitchen Scale (Precision 0.1g)",
            "Retractable USB-C Cable (1m/3ft)",
            "Cold Brew Coffee Maker (1.5L)",
            "Foam Roller for Muscle Recovery",
            "Desk Organizer with Wireless Charger",
            "Portable Espresso Maker (Manual)",
            "LED Strip Lights with Remote (5m)",
            "Fitness Tracker Watch (Heart Rate Monitor)",
            "Glass Meal Prep Containers (Set of 5)",
            "Electric Salt and Pepper Grinder Set",
            "Laptop Backpack with USB Charging Port",
            "Silicone Baking Mat Set (2-pack)",
            "Pocket-sized Multitool (12-in-1)",
            "Showerhead with Handheld Attachment",
            "Desktop Whiteboard (Magnetic, 24x18)",
            "Automatic Pet Feeder (Programmable)",
            "Sustainable Bamboo Toilet Paper (24 rolls)",
            "Car Windshield Sun Shade (Foldable)",
            "Wall-Mounted Jewelry Organizer Cabinet",
            "Stainless Steel French Press (1L)",
            "Wireless Ergonomic Vertical Mouse",
            "Tea Infuser Water Bottle (500ml)",
            "Drawer Organizer Dividers (Set of 8)",
            "Laptop Cooling Pad with Dual Fans",
            "Rechargeable Hand Warmers (Pair)",
            "Kitchen Knife Block Set (6-piece)",
            "Waterproof Phone Pouch for Swimming",
            "Portable Clothes Steamer (Handheld)",
            "Smart Thermostat (WiFi Enabled)",
            "Stainless Steel Straws (Set of 8)",
            "Cordless Phone Stand with Charger",
            "Adjustable Weight Bench (Foldable)",
            "Magnetic Fridge Storage Organizers",
            "Electric Wine Opener with Foil Cutter",
            "Memory Card Reader (USB-C/MicroSD/SD)",
            "Insulated Grocery Bag (Cold/Hot)",
            "Desk Cable Management Tray (Under-desk)",
            "Cast Iron Skillet (12-inch Pre-seasoned)",
            "WiFi Range Extender (Mesh Compatible)",
            "Pressure Cooker with Slow Cook Mode",
            "Hanging Toiletry Bag (Travel Size)",
            "Monitor Stand with Storage Drawer",
            "Electric Griddle (Non-stick, 20-inch)",
            "Personal Blender (600ml, Portable)",
            "Adjustable Ankle Weights (2 x 2.5kg)",
            "Smart Doorbell Camera (Battery Powered)",
            "Silicone Spatula Set (Heat-resistant)",
            "Laptop Sleeve with Handle (15.6-inch)",
            "Humidifier with Essential Oil Tray",
            "Self-Stick Wall Hooks (Set of 10)",
            "Portable Jump Rope (Adjustable Length)",
            "Vacuum Sealer Machine with Bags",
            "Stainless Steel Colander (3 sizes)",
            "USB Desk Fan with Silent Operation",
            "Luggage Scale (Digital, Portable)",
            "Bathroom Shelf Set (Corner, Rust-proof)",
            "Electric Can Opener (One-touch)",
            "Gaming Mouse Pad with LED Edge (Large)",
            "Stackable Food Storage Jars (Set of 6)",
            "Car Trunk Organizer (Collapsible)",
            "Wall-mounted Key Holder with Shelf",
            "Rice Cooker with Steamer Basket (5-cup)",
            "Sleep Mask with Built-in Bluetooth",
            "Pill Organizer (Weekly, 4-compartment)",
            "Smart Air Purifier with HEPA Filter",
            "Anti-Slip Yoga Towel (Microfiber)",
            "Bike Phone Mount (Universal Fit)",
            "Over-the-Door Towel Rack (No Drill)",
            "Bread Maker Machine (2 lb Loaf)",
            "Lid Organizer for Pots and Pans"
        };

        private static string[] categories = new string[]
        {
            "Consumer Electronics", "Home and Kitchen", "Office Supplies", "Travel Accessories",
            "Fitness Equipment", "Audio and Entertainment", "Pet Supplies", "Automotive Accessories",
            "Health and Personal Care", "Garden and Outdoor", "Baby and Kids", "Smart Home",
            "Kitchen Appliances", "Sports Gear", "Storage and Organization"
        };

        private static string[] suppliers = new string[]
        {
            "Northstar Imports", "Blue Ridge Manufacturing", "Evergreen Consumer Goods",
            "Summit Products", "Harbor Wholesale", "Pacific Rim Trading",
            "Arrowhead Distributors", "Crestline Supply Co.", "Westbridge Logistics",
            "Oakwood Merchandising", "Redwood Partners", "Silver Creek Enterprises",
            "Ironclad Industrial", "Clearview Procurement", "Stonebridge Exports"
        };

        private static string[] demandProfiles = new string[]
        {
            "High Volume", "Steady", "Seasonal", "Low Volume",
            "Peak Season Only", "Evergreen", "Rapid Growth", "Declining",
            "New Product Launch", "Promotional Only"
        };

        private static Dictionary<string, string[]> countryCities = new Dictionary<string, string[]>()
        {
            { "United States", new string[] { "New York", "Chicago", "Dallas", "Newark", "Atlanta", "Reno", "Seattle", "Columbus", "Denver", "Phoenix", "Portland", "Memphis", "Salt Lake City", "Richmond", "Kansas City", "Nashville", "Detroit", "Houston", "Charlotte", "Omaha", "Tampa", "Milwaukee", "Louisville", "San Antonio", "Indianapolis", "Oakland", "Raleigh", "Orlando", "Hartford" } },
            { "Canada", new string[] { "Toronto", "Montreal", "Vancouver", "Calgary", "Edmonton", "Ottawa", "Winnipeg", "Quebec City", "Hamilton", "Halifax", "London", "Mississauga", "Surrey", "Burnaby", "Laval", "Saskatoon", "Regina", "St. John's", "Kitchener", "Victoria", "Barrie", "Oshawa", "Gatineau", "Windsor", "Sudbury", "Brampton", "Markham", "Vaughan", "Richmond Hill", "Oakville", "Burlington", "St. Catharines", "Thunder Bay", "Kelowna", "Moncton" } },
            { "United Kingdom", new string[] { "London", "Birmingham", "Manchester", "Liverpool", "Leeds", "Glasgow", "Edinburgh", "Bristol", "Sheffield", "Newcastle", "Nottingham", "Leicester", "Cardiff", "Belfast", "Southampton", "Portsmouth", "Oxford", "Cambridge", "Brighton", "York" } },
            { "France", new string[] { "Paris", "Marseille", "Lyon", "Toulouse", "Nice", "Nantes", "Strasbourg", "Montpellier", "Bordeaux", "Lille", "Rennes", "Reims", "Le Havre", "Toulon", "Grenoble", "Dijon", "Angers", "Nimes", "Clermont-Ferrand" } },
            { "Australia", new string[] { "Sydney", "Melbourne", "Brisbane", "Perth", "Adelaide", "Gold Coast", "Canberra", "Newcastle", "Wollongong", "Hobart", "Darwin", "Cairns", "Geelong", "Townsville", "Launceston", "Toowoomba" } },
            { "Japan", new string[] { "Tokyo", "Osaka", "Kyoto", "Yokohama", "Nagoya", "Sapporo", "Fukuoka", "Kobe", "Kawasaki", "Hiroshima", "Sendai", "Kitakyushu", "Chiba", "Saitama", "Shizuoka", "Kumamoto" } },
            { "Germany", new string[] { "Berlin", "Hamburg", "Munich", "Cologne", "Frankfurt", "Stuttgart", "Dusseldorf", "Leipzig", "Dortmund", "Essen", "Bremen", "Dresden", "Hanover", "Nuremberg", "Duisburg", "Bochum" } },
            { "Singapore", new string[] { "Singapore Central", "Woodlands", "Tampines", "Jurong East", "Bedok", "Punggol", "Sengkang", "Ang Mo Kio", "Bukit Merah", "Clementi", "Toa Payoh", "Yishun", "Changi", "Marina Bay", "Orchard", "Novena" } },
            { "Brazil", new string[] { "Sao Paulo", "Rio de Janeiro", "Brasilia", "Salvador", "Fortaleza", "Belo Horizonte", "Manaus", "Curitiba", "Recife", "Porto Alegre", "Belem", "Goiania", "Campinas", "Florianopolis", "Natal", "Vitoria" } },
            { "Netherlands", new string[] { "Amsterdam", "Rotterdam", "The Hague", "Utrecht", "Eindhoven", "Groningen", "Tilburg", "Almere", "Breda", "Nijmegen", "Haarlem", "Arnhem", "Leiden", "Maastricht", "Zwolle", "Delft" } },
            { "South Korea", new string[] { "Seoul", "Busan", "Incheon", "Daegu", "Daejeon", "Gwangju", "Suwon", "Ulsan", "Changwon", "Goyang", "Yongin", "Seongnam", "Jeonju", "Cheongju", "Pohang", "Jeju City" } },
            { "Switzerland", new string[] { "Zurich", "Geneva", "Basel", "Lausanne", "Bern", "Winterthur", "Lucerne", "St. Gallen", "Lugano", "Biel", "Thun", "Fribourg", "Neuchatel", "Zug", "Schaffhausen", "Sion" } },
            { "Sweden", new string[] { "Stockholm", "Gothenburg", "Malmo", "Uppsala", "Vasteras", "Orebro", "Linkoping", "Helsingborg", "Jonkoping", "Norrkoping", "Lund", "Umea", "Gavle", "Boras", "Sodertalje", "Eskilstuna" } },
            { "Italy", new string[] { "Rome", "Milan", "Naples", "Turin", "Palermo", "Genoa", "Bologna", "Florence", "Venice", "Verona", "Bari", "Catania", "Padua", "Trieste", "Brescia", "Parma" } },
            { "Spain", new string[] { "Madrid", "Barcelona", "Valencia", "Seville", "Zaragoza", "Malaga", "Murcia", "Palma", "Las Palmas", "Bilbao", "Alicante", "Cordoba", "Valladolid", "Vigo", "Gijon", "Granada" } },
            { "India", new string[] { "Mumbai", "Delhi", "Bengaluru", "Hyderabad", "Chennai", "Kolkata", "Pune", "Ahmedabad", "Jaipur", "Surat", "Lucknow", "Kanpur", "Nagpur", "Indore", "Thane", "Bhopal", "Visakhapatnam", "Patna", "Vadodara", "Ghaziabad" } }
        };

        public static List<DomVirtualizationData> GetDomVirtualizationData()
        {
            List<DomVirtualizationData> data = new List<DomVirtualizationData>();
            var random = new Random(42);
            int recordId = 10000;

            for (int warehouseIndex = 1; warehouseIndex <= 25000; warehouseIndex++)
            {
                int warehouseId = ++recordId;
                int regionIndex = (warehouseIndex - 1) % warehouseRegions.Length;
                var childRecords = new List<DomVirtualizationData>();

                int warehouseQuantity = 0;
                int warehouseReserved = 0;
                int warehouseAvailable = 0;
                double warehouseInventoryValue = 0;
                int availableCount = 0;
                int lowStockCount = 0;
                int outOfStockCount = 0;
                int discontinuedCount = 0;

                for (int itemIndex = 1; itemIndex <= 3; itemIndex++)
                {
                    int itemId = ++recordId;
                    string region = warehouseRegions[regionIndex];
                    int categoryIndex = random.Next(categories.Length);
                    int supplierIndex = random.Next(suppliers.Length);
                    string[] cities = countryCities[region];
                    string childRegion = cities[(warehouseIndex + itemIndex) % cities.Length];
                    string childItemName = childRegion + " Facility";
                    int monthlyUnitsSold = 200 + ((warehouseIndex * (itemIndex + 9)) % 2500);
                    double unitPrice = 15 + ((warehouseIndex * itemIndex * 13) % 250);
                    int quantity = 100 + ((warehouseIndex * itemIndex * 29) % 3000);
                    int reservedQuantity = 0;
                    int availableQuantity = 0;
                    int reorderLevel = 0;
                    string stockStatus = "";
                    int statusSeed = (warehouseIndex + itemIndex) % 20;

                    if (statusSeed == 0)
                    {
                        stockStatus = "Out of Stock";
                        quantity = 0;
                        reservedQuantity = 0;
                        availableQuantity = 0;
                        reorderLevel = 100;
                        outOfStockCount++;
                    }
                    else if (statusSeed <= 3)
                    {
                        stockStatus = "Low Stock";
                        availableQuantity = Math.Max(10, (int)Math.Floor(quantity * 0.10));
                        reservedQuantity = quantity - availableQuantity;
                        reorderLevel = availableQuantity + 150;
                        lowStockCount++;
                    }
                    else if (statusSeed == 4)
                    {
                        stockStatus = "Discontinued";
                        availableQuantity = (int)Math.Floor(quantity * 0.30);
                        reservedQuantity = 0;
                        reorderLevel = 0;
                        discontinuedCount++;
                    }
                    else
                    {
                        stockStatus = "Available";
                        reservedQuantity = (int)Math.Floor(quantity * 0.15);
                        availableQuantity = quantity - reservedQuantity;
                        reorderLevel = (int)Math.Floor(quantity * 0.25);
                        availableCount++;
                    }

                    warehouseQuantity += quantity;
                    warehouseReserved += reservedQuantity;
                    warehouseAvailable += availableQuantity;
                    warehouseInventoryValue += quantity * unitPrice;

                    childRecords.Add(new DomVirtualizationData()
                    {
                        ItemID = itemId,
                        ParentItemID = warehouseId,
                        ItemName = childItemName,
                        ItemType = "Product",
                        SKU = "SKU-" + warehouseIndex.ToString("D5") + "-" + itemIndex.ToString("D2"),
                        Category = categories[categoryIndex],
                        Region = childRegion,
                        Country = region,
                        Supplier = suppliers[supplierIndex],
                        StockStatus = stockStatus,
                        Quantity = quantity,
                        ReservedQuantity = reservedQuantity,
                        AvailableQuantity = availableQuantity,
                        ReorderLevel = reorderLevel,
                        UnitPrice = unitPrice,
                        InventoryValue = quantity * unitPrice,
                        DailyOrders = (int)Math.Ceiling(monthlyUnitsSold / 30.0),
                        MonthlyUnitsSold = monthlyUnitsSold,
                        FulfillmentRate = 93 + ((warehouseIndex + itemIndex) % 7),
                        DemandProfile = demandProfiles[(warehouseIndex + itemIndex) % demandProfiles.Length],
                        LastRestocked = new DateTime(2025, ((warehouseIndex + itemIndex) % 12) + 1, ((warehouseIndex + itemIndex * 2) % 27) + 1),
                        NextDeliveryDate = new DateTime(2025, ((warehouseIndex + itemIndex + 1) % 12) + 1, ((warehouseIndex + itemIndex * 4) % 27) + 1)
                    });
                }

                string warehouseStatus = "Available";
                if (discontinuedCount == childRecords.Count)
                {
                    warehouseStatus = "Discontinued";
                }
                else if (outOfStockCount == childRecords.Count)
                {
                    warehouseStatus = "Out of Stock";
                }
                else if (lowStockCount > 0 || outOfStockCount > 0)
                {
                    warehouseStatus = "Low Stock";
                }

                data.Add(new DomVirtualizationData()
                {
                    ItemID = warehouseId,
                    ParentItemID = null,
                    ItemName = warehouseNames[regionIndex] + " " + ((warehouseIndex - 1) / warehouseNames.Length + 1),
                    ItemType = "Warehouse",
                    Category = "Multi-category inventory",
                    Region = warehouseRegions[regionIndex],
                    Country = warehouseRegions[regionIndex],
                    Supplier = "Regional supplier network",
                    StockStatus = warehouseStatus,
                    Quantity = warehouseQuantity,
                    ReservedQuantity = warehouseReserved,
                    AvailableQuantity = warehouseAvailable,
                    ReorderLevel = (int)Math.Floor(warehouseQuantity * 0.20),
                    UnitPrice = null,
                    InventoryValue = warehouseInventoryValue,
                    DailyOrders = 500 + ((warehouseIndex * 23) % 2500),
                    MonthlyUnitsSold = 15000 + ((warehouseIndex * 97) % 55000),
                    FulfillmentRate = 95 + ((warehouseIndex % 10) / 10.0),
                    DemandProfile = demandProfiles[warehouseIndex % demandProfiles.Length],
                    StorageCapacity = warehouseQuantity + (int)Math.Floor(warehouseQuantity * 0.25),
                    LastRestocked = new DateTime(2025, ((warehouseIndex + 2) % 12) + 1, ((warehouseIndex * 3) % 27) + 1)
                });

                data.AddRange(childRecords);
            }

            return data;
        }
    }
}
