#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.EJ2.Navigations;

namespace EJ2CoreSampleBrowser.Pages.AppBar
{
    public class ColorModel : PageModel
    {
        public List<object> ProductDropDownButtonItems = new List<object>();
        public List<object> CompanyDropDownButtonItems = new List<object>();
        public List<MenuItem> VerticalMenuItems = new List<MenuItem>();
        public List<ColorData> AppBarColors = new List<ColorData>();
        public void OnGet()
        {
            ProductDropDownButtonItems.Add(new
            {
                text = "Developer",
            });
            ProductDropDownButtonItems.Add(new
            {
                text = "Analytics",
            });
            ProductDropDownButtonItems.Add(new
            {
                text = "Reporting",
            });
            ProductDropDownButtonItems.Add(new
            {
                text = "E-Signature",
            });
            ProductDropDownButtonItems.Add(new
            {
                text = "Help-Desk",
            });

            
            CompanyDropDownButtonItems.Add(new
            {
                text = "Dashboard",
            });
            CompanyDropDownButtonItems.Add(new
            {
                text = "Notifications",
            });
            CompanyDropDownButtonItems.Add(new
            {
                text = "User Settings",
            });
            CompanyDropDownButtonItems.Add(new
            {
                text = "Log Out",
            });

            VerticalMenuItems.Add(new MenuItem
            {
                IconCss = "e-icons e-more-vertical-1",
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
            });

            
            AppBarColors.Add(new ColorData
            {
                ColorMode = "Light",
                ColorClass = " e-light",
                AppBarColorMode = AppBarColor.Light,
                IsPrimary = true,
                LoginClass = "login"
            });
            AppBarColors.Add(new ColorData
            {
                ColorMode = "Dark",
                ColorClass = " e-dark",
                AppBarColorMode = AppBarColor.Dark,
                IsPrimary = false,
                LoginClass = "e-inherit login"
            });
            AppBarColors.Add(new ColorData
            {
                ColorMode = "Primary",
                ColorClass = " e-primary",
                AppBarColorMode = AppBarColor.Primary,
                IsPrimary = false,
                LoginClass = "e-inherit login"
            });
            AppBarColors.Add(new ColorData
            {
                ColorMode = "Inherit",
                ColorClass = "",
                AppBarColorMode = AppBarColor.Inherit,
                IsPrimary = true,
                LoginClass = "login"
            });
        }
        
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
