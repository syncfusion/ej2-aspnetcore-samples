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
        public IActionResult ToolbarIntegration()
        {
            List<object> menuItems = new List<object>() {
                new {
                    text = "Appliances",
                    items = new List<object>() {
                        new {
                            text = "Kitchen",
                            items = new List<object>() {
                                new { text= "Electric Cookers" },
                                new { text= "Coffee Makers" },
                                new { text= "Blenders" }
                            }
                        },
                        new {
                            text = "Washing Machine",
                            items = new List<object>() {
                                new { text= "Fully Automatic" },
                                new { text= "Semi Automatic" }
                            }
                        },
                        new {
                            text = "Air Conditioners",
                            items = new List<object>() {
                                new { text= "Inverter ACs" },
                                new { text= "Split ACs" },
                                new { text= "Window ACs" }
                            }
                        }
                    }
                },
                new {
                    text = "Accessories",
                    items = new List<object>() {
                        new {
                            text = "Mobile",
                            items = new List<object>() {
                                new { text= "Headphones" },
                                new { text= "Memory Cards" },
                                new { text= "Power Banks" }
                            }
                        },
                        new {
                            text = "Computer",
                            items = new List<object>() {
                                new { text= "Pendrives" },
                                new { text= "External Hard Disks" },
                                new { text= "Monitors" }
                            }
                        }
                    }
                },
                new {
                    text = "Fashion",
                    items = new List<object>() {
                        new {
                            text = "Men",
                            items = new List<object>() {
                                new { text= "Shirts" },
                                new { text= "Jackets" },
                                new { text= "Track Suits" }
                            }
                        },
                        new {
                            text = "Women",
                            items = new List<object>() {
                                new { text= "Kurtas" },
                                new { text= "Salwars" },
                                new { text= "Sarees" }
                            }
                        }
                    }
                },
                new {
                    text = "Home & Living",
                    items = new List<object>() {
                        new {
                            text = "Furniture",
                            items = new List<object>() {
                                new { text= "Beds" },
                                new { text= "Mattresses" },
                                new { text= "Dining Tables" }
                            }
                        },
                        new {
                            text = "Decor",
                            items = new List<object>() {
                                new { text= "Clocks" },
                                new { text= "Wall Decals" },
                                new { text= "Paintings" }
                            }
                        }
                    }
                }
            };

            List<object> userData = new List<object>() {
                new { text= "My Profile" },
                new { text= "Orders" },
                new { text= "Rewards" },
                new { text= "Logout" }
            };

            List<ToolbarItem> items = new List<ToolbarItem>()
            {
                new ToolbarItem { Template ="<ul id='menu'></ul>" },
                new ToolbarItem { Template ="<div class='e-input-group'><input class='e-input' type='text' placeholder='Search' /><span class='em-icons e-search'></span></div>", Align=Syncfusion.EJ2.Navigations.ItemAlign.Right },
                new ToolbarItem { Template ="<button id='userDBtn'>Andrew</button>", Align=Syncfusion.EJ2.Navigations.ItemAlign.Right },
                new ToolbarItem { PrefixIcon ="em-icons e-shopping-cart", Align=Syncfusion.EJ2.Navigations.ItemAlign.Right }
            };

            ViewBag.items = items;
            ViewBag.userData = userData;
            ViewBag.menuItems = menuItems;
            return View();
        }
    }
}
