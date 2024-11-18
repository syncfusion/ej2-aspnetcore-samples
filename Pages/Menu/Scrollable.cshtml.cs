#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.EJ2.Navigations;
namespace EJ2CoreSampleBrowser.Pages.Menu;

public class ScrollableModel : PageModel
{
    public List<object> menuItems { get; set; }
    public MenuAnimationSettings animationSettings { get; set; }

    public void OnGet()
    {
        menuItems = new List<object>();
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

        animationSettings = new MenuAnimationSettings()
        {
            Duration = 800
        };
    }
}