using System.Collections.Generic;
namespace EJ2CoreSampleBrowser.Models
{

   
        public class ProductDetail
        {
            public string ProductID { get; set; }
            public string ProductName { get; set; }
            public string Description { get; set; }
            public string SKU { get; set; }
            public string Category { get; set; }
            public int Stock { get; set; }

            public int SalesMonth1 { get; set; }
            public int SalesMonth2 { get; set; }
            public int SalesMonth3 { get; set; }

            public double Rating { get; set; }
            public int Reviews { get; set; }

            public double Price { get; set; }
            public double OriginalPrice { get; set; }
            public double CostPrice { get; set; }
            public string ProfitMargin { get; set; }

            public string Status { get; set; }
            public int Units { get; set; }

            public string Image { get; set; }

            public string ProductDescription { get; set; }

            public List<string> Highlights { get; set; }

            public Dictionary<string, string> Specifications { get; set; }
        }

        public static class ProductDetailsData
        {
            public static List<ProductDetail> GetProducts()
            {
                return new List<ProductDetail>
            {
                new ProductDetail
                {
                    ProductID = "PRD-1001",
                    ProductName = "MacBook Pro 14",
                    Description = "M3 Pro Chip • 16GB RAM",
                    SKU = "MBP14-M3",
                    Category = "Laptop",
                    Stock = 24,
                    SalesMonth1 = 380,
                    SalesMonth2 = 400,
                    SalesMonth3 = 420,
                    Rating = 4.8,
                    Reviews = 128,
                    Price = 2499,
                    OriginalPrice = 2799,
                    CostPrice = 2025,
                    ProfitMargin = "23.4%",
                    Status = "In Stock",
                    Units = 24,
                    Image = "MacBook",
                    ProductDescription = "The MacBook Pro 14-inch with M3 Pro chip delivers exceptional performance for demanding workflows.",
                    Highlights = new List<string>
                    {
                        "M3 Pro chip with 11-core CPU and 14-core GPU",
                        "14.2-inch Liquid Retina XDR display",
                        "16GB Unified Memory",
                        "512GB SSD storage",
                        "Up to 18 hours battery life"
                    },
                    Specifications = new Dictionary<string, string>
                    {
                        {"Display","14.2-inch Liquid Retina XDR"},
                        {"Resolution","3024 x 1964 pixels"},
                        {"Processor","Apple M3 Pro chip"},
                        {"Memory","16GB Unified Memory"},
                        {"Storage","512GB SSD"},
                        {"OS","macOS Sonoma"}
                    }
                },

                new ProductDetail
                {
                    ProductID = "PRD-1002",
                    ProductName = "iPhone 15 Pro Max",
                    Description = "256GB • Natural Titanium",
                    SKU = "IP15PM-256",
                    Category = "Smartphone",
                    Stock = 12,
                    SalesMonth1 = 290,
                    SalesMonth2 = 305,
                    SalesMonth3 = 275,
                    Rating = 4.7,
                    Reviews = 96,
                    Price = 1199,
                    OriginalPrice = 1299,
                    CostPrice = 930,
                    ProfitMargin = "22.4%",
                    Status = "Low Stock",
                    Units = 12,
                    Image = "iPhone",
                    ProductDescription = "The iPhone 15 Pro Max features a titanium design, A17 Pro chip and advanced camera system.",
                    Highlights = new List<string>
                    {
                        "6.7-inch Super Retina XDR",
                        "A17 Pro chip",
                        "48MP camera system",
                        "Titanium design",
                        "USB-C connectivity"
                    },
                    Specifications = new Dictionary<string, string>
                    {
                        {"Display","6.7-inch OLED"},
                        {"Processor","A17 Pro"},
                        {"Storage","256GB"},
                        {"Camera","48MP Triple Camera"},
                        {"Battery","Up to 29 hours video playback"}
                    }
                },

                new ProductDetail
                {
                    ProductID = "PRD-1003",
                    ProductName = "AirPods Pro",
                    Description = "USB-C • Active Noise",
                    SKU = "APP2-USB-C",
                    Category = "HeadPhone",
                    Stock = 56,
                    SalesMonth1 = 580,
                    SalesMonth2 = 600,
                    SalesMonth3 = 558,
                    Rating = 3.5,
                    Reviews = 210,
                    Price = 249,
                    OriginalPrice = 279,
                    CostPrice = 190,
                    ProfitMargin = "23.7%",
                    Status = "In Stock",
                    Units = 56,
                    Image = "AirPods",
                    ProductDescription = "Premium wireless earbuds with active noise cancellation and spatial audio.",
                    Highlights = new List<string>
                    {
                        "Active Noise Cancellation",
                        "Adaptive Audio",
                        "USB-C charging",
                        "Spatial Audio",
                        "Sweat resistant"
                    },
                    Specifications = new Dictionary<string, string>
                    {
                        {"Connectivity","Bluetooth 5.3"},
                        {"Battery","Up to 30 hours"},
                        {"Charging","USB-C"},
                        {"WaterResistance","IP54"}
                    }
                },

                new ProductDetail
                {
                    ProductID = "PRD-1004",
                    ProductName = "Apple Watch Series 9",
                    Description = "45mm • Midnight Aluminum",
                    SKU = "AW9-45-MID",
                    Category = "Wearables",
                    Stock = 31,
                    SalesMonth1 = 195,
                    SalesMonth2 = 205,
                    SalesMonth3 = 215,
                    Rating = 4.5,
                    Reviews = 78,
                    Price = 429,
                    OriginalPrice = 479,
                    CostPrice = 330,
                    ProfitMargin = "23.1%",
                    Status = "In Stock",
                    Units = 31,
                    Image = "Watch",
                    ProductDescription = "Advanced smartwatch with fitness tracking, health monitoring and Siri support.",
                    Highlights = new List<string>
                    {
                        "S9 SiP processor",
                        "Always-On Retina display",
                        "Blood oxygen monitoring",
                        "Fitness tracking",
                        "Water resistant"
                    },
                    Specifications = new Dictionary<string, string>
                    {
                        {"Size","45mm"},
                        {"Chip","S9 SiP"},
                        {"Display","Always-On Retina"},
                        {"Battery","18 hours"}
                    }
                },

                new ProductDetail
                {
                    ProductID = "PRD-1005",
                    ProductName = "iPad Air 5th Gen",
                    Description = "256GB • Wi‑Fi • Blue",
                    SKU = "IPA5-256-BLU",
                    Category = "Tablet",
                    Stock = 8,
                    SalesMonth1 = 170,
                    SalesMonth2 = 160,
                    SalesMonth3 = 142,
                    Rating = 4.4,
                    Reviews = 54,
                    Price = 749,
                    OriginalPrice = 799,
                    CostPrice = 575,
                    ProfitMargin = "23.2%",
                    Status = "Low Stock",
                    Units = 8,
                    Image = "iPad",
                    ProductDescription = "Powerful and lightweight tablet powered by the Apple M1 chip.",
                    Highlights = new List<string>
                    {
                        "Apple M1 chip",
                        "10.9-inch Liquid Retina",
                        "256GB Storage",
                        "Wi‑Fi 6",
                        "Touch ID"
                    },
                    Specifications = new Dictionary<string, string>
                    {
                        {"Display","10.9-inch Liquid Retina"},
                        {"Processor","Apple M1"},
                        {"Storage","256GB"},
                        {"Connectivity","Wi‑Fi 6"}
                    }
                },

                new ProductDetail
                {
                    ProductID = "PRD-1006",
                    ProductName = "LG UltraGear 27",
                    Description = "QHD • 144Hz • IPS",
                    SKU = "LG27-144",
                    Category = "Monitor",
                    Stock = 18,
                    SalesMonth1 = 125,
                    SalesMonth2 = 135,
                    SalesMonth3 = 142,
                    Rating = 2.4,
                    Reviews = 33,
                    Price = 329,
                    OriginalPrice = 349,
                    CostPrice = 250,
                    ProfitMargin = "24.0%",
                    Status = "In Stock",
                    Units = 18,
                    Image = "LGMonitor",
                    ProductDescription = "Gaming monitor delivering smooth visuals with a 144Hz refresh rate.",
                    Highlights = new List<string>
                    {
                        "27-inch IPS panel",
                        "QHD resolution",
                        "144Hz refresh rate",
                        "1ms response time",
                        "HDR10 support"
                    },
                    Specifications = new Dictionary<string, string>
                    {
                        {"Size","27-inch"},
                        {"Resolution","2560x1440"},
                        {"RefreshRate","144Hz"},
                        {"Panel","IPS"}
                    }
                },

                new ProductDetail
                {
                    ProductID = "PRD-1007",
                    ProductName = "Magic Keyboard",
                    Description = "Mac • Wireless",
                    SKU = "MK-ML/A22",
                    Category = "Accessories",
                    Stock = 72,
                    SalesMonth1 = 280,
                    SalesMonth2 = 290,
                    SalesMonth3 = 261,
                    Rating = 4.6,
                    Reviews = 137,
                    Price = 99,
                    OriginalPrice = 109,
                    CostPrice = 75,
                    ProfitMargin = "24.2%",
                    Status = "In Stock",
                    Units = 72,
                    Image = "MagicKeyboard",
                    ProductDescription = "Wireless keyboard designed for seamless productivity on Mac devices.",
                    Highlights = new List<string>
                    {
                        "Wireless connectivity",
                        "Rechargeable battery",
                        "Scissor mechanism keys",
                        "Compact design",
                        "Multi-device pairing"
                    },
                    Specifications = new Dictionary<string, string>
                    {
                        {"Connectivity","Bluetooth"},
                        {"Battery","Rechargeable"},
                        {"Layout","QWERTY"}
                    }
                },

                new ProductDetail
                {
                    ProductID = "PRD-1008",
                    ProductName = "Galaxy S24 Ultra",
                    Description = "512GB • Phantom Black",
                    SKU = "GS24U-512",
                    Category = "Smartphone",
                    Stock = 28,
                    SalesMonth1 = 395,
                    SalesMonth2 = 405,
                    SalesMonth3 = 420,
                    Rating = 3.2,
                    Reviews = 112,
                    Price = 1299,
                    OriginalPrice = 1399,
                    CostPrice = 1005,
                    ProfitMargin = "22.6%",
                    Status = "In Stock",
                    Units = 28,
                    Image = "GalaxyS24",
                    ProductDescription = "Samsung flagship smartphone with Galaxy AI and advanced camera features.",
                    Highlights = new List<string>
                    {
                        "Galaxy AI features",
                        "200MP camera",
                        "Snapdragon 8 Gen 3",
                        "512GB Storage",
                        "S Pen included"
                    },
                    Specifications = new Dictionary<string, string>
                    {
                        {"Display","6.8-inch Dynamic AMOLED"},
                        {"Storage","512GB"},
                        {"Camera","200MP"},
                        {"Processor","Snapdragon 8 Gen 3"}
                    }
                },

                new ProductDetail
                {
                    ProductID = "PRD-1009",
                    ProductName = "Sony WH-1000XM5",
                    Description = "Noise Cancelling Headphones",
                    SKU = "WH1000XM5",
                    Category = "HeadPhone",
                    Stock = 34,
                    SalesMonth1 = 235,
                    SalesMonth2 = 245,
                    SalesMonth3 = 218,
                    Rating = 4.7,
                    Reviews = 198,
                    Price = 349,
                    OriginalPrice = 379,
                    CostPrice = 270,
                    ProfitMargin = "22.6%",
                    Status = "In Stock",
                    Units = 34,
                    Image = "Sony",
                    ProductDescription = "Industry-leading noise cancelling wireless headphones.",
                    Highlights = new List<string>
                    {
                        "Noise cancellation",
                        "30-hour battery",
                        "Quick charge",
                        "Hi‑Res Audio",
                        "Multipoint connection"
                    },
                    Specifications = new Dictionary<string, string>
                    {
                        {"Connectivity","Bluetooth 5.2"},
                        {"Battery","30 Hours"},
                        {"Weight","250g"}
                    }
                },

                new ProductDetail
                {
                    ProductID = "PRD-1010",
                    ProductName = "Nintendo Switch",
                    Description = "Neon • Handheld Console",
                    SKU = "NS-NEON",
                    Category = "Gaming",
                    Stock = 15,
                    SalesMonth1 = 180,
                    SalesMonth2 = 195,
                    SalesMonth3 = 215,
                    Rating = 4.4,
                    Reviews = 89,
                    Price = 299,
                    OriginalPrice = 329,
                    CostPrice = 230,
                    ProfitMargin = "23.1%",
                    Status = "Low Stock",
                    Units = 15,
                    Image = "Nintendo",
                    ProductDescription = "Versatile gaming system usable as both a home and portable console.",
                    Highlights = new List<string>
                    {
                        "Portable gaming",
                        "Dock for TV play",
                        "Joy-Con controllers",
                        "Multiplayer support",
                        "Large game library"
                    },
                    Specifications = new Dictionary<string, string>
                    {
                        {"Screen","6.2-inch LCD"},
                        {"Storage","32GB"},
                        {"Connectivity","Wi‑Fi"},
                        {"Battery","4.5-9 Hours"}
                    }
                }
            };
            }
        }
    }

