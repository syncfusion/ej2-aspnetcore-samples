#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Syncfusion.EJ2.Navigations;

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class AppBarController : Controller
    {
        public IActionResult Color()
        {
            List<object> productDropDownButtonItems = new List<object>();
            productDropDownButtonItems.Add(new
            {
                text = "Developer",
            });
            productDropDownButtonItems.Add(new
            {
                text = "Analytics",
            });
            productDropDownButtonItems.Add(new
            {
                text = "Reporting",
            });
            productDropDownButtonItems.Add(new
            {
                text = "E-Signature",
            });
            productDropDownButtonItems.Add(new
            {
                text = "Help-Desk",
            });
            ViewBag.ProductDropDownButtonItems = productDropDownButtonItems;

            List<object> companyDropDownButtonItems = new List<object>();
            companyDropDownButtonItems.Add(new
            {
                text = "Dashboard",
            });
            companyDropDownButtonItems.Add(new
            {
                text = "Notifications",
            });
            companyDropDownButtonItems.Add(new
            {
                text = "User Settings",
            });
            companyDropDownButtonItems.Add(new
            {
                text = "Log Out",
            });
            ViewBag.CompanyDropDownButtonItems = companyDropDownButtonItems;

            List<MenuItem> verticalMenuItems = new List<MenuItem>(){
                new MenuItem
                {
                    IconCss= "e-icons e-more-vertical-1",
                    Items = new List<MenuItem>()
                    {
                        new MenuItem { Text= "Home" },
                        new MenuItem
                        {
                            Text = "Products",
                            Items = new List<MenuItem>()
                            {
                                new MenuItem { Text= "Developer" },
                                new MenuItem { Text= "Analytics" },
                                new MenuItem { Text= "Reporting" },
                                new MenuItem { Text= "E-Signature" },
                                new MenuItem { Text= "Help Desk" }
                            }
                        },
                        new MenuItem
                        {
                             Text = "Company",
                             Items = new List<MenuItem>()
                             {
                                new MenuItem { Text= "About Us" },
                                new MenuItem { Text= "Customers" },
                                new MenuItem { Text= "Blog" },
                                new MenuItem { Text= "Careers" }
                             }
                        },
                        new MenuItem { Text = "Login" }
                    }
                }
            };
            ViewBag.VerticalMenuItems = verticalMenuItems;

            List<ColorData> appBarColors = new List<ColorData>();
            appBarColors.Add(new ColorData
            {
                ColorMode = "Light",
                ColorClass = " e-light",
                AppBarColorMode = AppBarColor.Light,
                IsPrimary = true,
                LoginClass = "login"
            });
            appBarColors.Add(new ColorData
            {
                ColorMode = "Dark",
                ColorClass = " e-dark",
                AppBarColorMode = AppBarColor.Dark,
                IsPrimary = false,
                LoginClass = "e-inherit login"
            });
            appBarColors.Add(new ColorData
            {
                ColorMode = "Primary",
                ColorClass = " e-primary",
                AppBarColorMode = AppBarColor.Primary,
                IsPrimary = false,
                LoginClass = "e-inherit login"
            });
            appBarColors.Add(new ColorData
            {
                ColorMode = "Inherit",
                ColorClass = "",
                AppBarColorMode = AppBarColor.Inherit,
                IsPrimary = true,
                LoginClass = "login"
            });
            ViewBag.AppBarColors = appBarColors;

            return View();
        }

        public class ColorData
        {
            public string? ColorMode { get; set; }
            public string? ColorClass { get; set; }
            public AppBarColor AppBarColorMode { get; set; }
            public bool IsPrimary { get; set; }
            public string? LoginClass { get; set; }
        }
    }
}
