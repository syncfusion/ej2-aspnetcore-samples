#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.EJ2.Navigations;
namespace EJ2CoreSampleBrowser.Pages.Menu;

public class TemplateModel : PageModel
{
    public List<object> data { get; set; }
    public MenuFieldSettings menuFields { get; set; }
    
    public void OnGet()
    {
        data = new List<object>() {
            new {
                category = "Products",
                options = new List<object>(){
                    new { value= "JavaScript", url= "javascript" },
                    new { value= "Angular", url= "angular" },
                    new { value= "ASP.NET Core", url= "core" },
                    new { value= "ASP.NET MVC", url= "mvc" }
                }
            },

            new  {
                category = "Services",
                options = new List<object>(){
                    new { value= "Application Development", count= "1200+" },
                    new { value= "Maintenance & Support", count= "3700+" },
                    new { value= "Quality Assurance" },
                    new { value= "Cloud Integration", count= "900+" }
                }
            },

            new {
                category = "About Us",
                options =  new List<object>(){
                    new {
                        id = "about",
                        about = new List<object>() { new { value = "We are on a mission to provide world-class best software solutions for web, mobile and desktop platforms. Around 900+ applications are desgined and delivered to our customers to make digital & strengthen their businesses." } }[0]
                    }
                }
            },
            new { category = "Careers" },
            new { category = "Sign In" }
        };

        menuFields = new MenuFieldSettings()
        {
            Text = new string[] { "category", "value" },
            Children = new string[] { "options" }
        };
    }
}