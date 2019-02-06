using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Navigations;

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class MenuController : Controller
    {
        public IActionResult Scrollable()
        {
            List<object> menuItems = new List<object>();
            menuItems.Add(new
            {
                text = "Appliances",
                items = new List<object>()
                {
                    new {
                        text= "Kitchen",
                        items = new List<object>()
                        {
                            new { text= "Electric Cookers" },
                            new { text= "Coffee Makers" },
                            new { text= "Blenders" },
                            new { text= "Microwave Ovens" }
                        }
                    },
                    new {
                        text= "Television",
                        items = new List<object>()
                        {
                            new { text= "Our Exclusive TVs" },
                            new { text= "Smart TVs" },
                            new { text= "Big Screen TVs" }
                        }
                    },
                    new { text= "Washing Machine" },
                    new {
                        text= "Refrigerators",
                        items = new List<object>()
                        {
                            new { text= "Inverter ACs" },
                            new { text= "Split ACs" },
                            new { text= "Window ACs" }
                        }
                    },
                    new { text= "Air Conditioners" },
                    new { text= "Water Purifiers" },
                    new { text= "Air Purifiers" },
                    new { text= "Chimneys" },
                    new { text= "Inverters" },
                    new { text= "Healthy Living" },
                    new { text= "Vacuum Cleaners" },
                    new { text= "Room Heaters" },
                    new { text= "New Launches" }
                }
            });

            menuItems.Add(new
            {
                text = "Accessories",
                items = new List<object>()
                {
                    new {
                        text= "Mobile",
                        items = new List<object>()
                        {
                            new { text= "Headphones" },
                            new { text= "Batteries" },
                            new { text= "Memory Cards" },
                            new { text= "Power Banks" },
                            new { text= "Mobile Cases" },
                            new { text= "Screen Protectors" },
                            new { text= "Data Cables" },
                            new { text= "Chargers" },
                            new { text= "Selfie Sticks" },
                            new { text= "OTG Cable" }
                        }
                    },
                    new { text= "Laptops" },
                    new {
                        text= "Desktop PC",
                        items = new List<object>()
                        {
                            new { text= "Pendrives" },
                            new { text= "External Hard Disks" },
                            new { text= "Monitors" },
                            new { text= "Keyboards" }
                        }
                    },
                    new {
                        text= "Camera",
                        items = new List<object>()
                        {
                            new { text= "Lens" },
                            new { text= "Tripods" }
                        }
                    }
                }
            });

            menuItems.Add(new
            {
                text = "Fashion",
                items = new List<object>()
                {
                    new { text = "Men" },
                    new { text = "Women" }
                }
            });

            menuItems.Add(new
            {
                text = "Home & Living",
                items = new List<object>()
                {
                    new { text= "Furniture" },
                    new { text= "Decor" },
                    new { text= "Smart Home Automation" },
                    new { text= "Dining & Serving" }
                }
            });

            menuItems.Add(new
            {
                text = "Entertainment",
                items = new List<object>()
                {
                    new { text= "Televisions" },
                    new { text= "Home Theatres" },
                    new { text= "Gaming Laptops" }
                }
            });

            menuItems.Add(new
            {
                text = "Contact Us",
            });

            menuItems.Add(new
            {
                text = "Help",
            });

            MenuAnimationSettings animationSettings = new MenuAnimationSettings()
            {
                Duration = 800
            };

            ViewBag.menuItems = menuItems;
            ViewBag.animationSettings = animationSettings;
            return View();
        }
    }
}
