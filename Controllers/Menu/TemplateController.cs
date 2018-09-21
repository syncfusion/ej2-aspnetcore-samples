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
        public IActionResult Template()
        {
            List<object> data = new List<object>() {
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
                        new  {
                            support = new List<object>() {
                                new { value= "Application Development", count= "1200+" },
                                new { value= "Maintenance & Support", count= "3700+" },
                                new { value= "Quality Assurance" },
                                new { value= "Cloud Integration", count= "900+" }
                            }
                        }
                    }
                },

                new {
                    category = "About Us",
                    options =  new List<object>(){
                        new {
                            about = new List<object>() { new { value = "We are on a mission to provide world-class best software solutions for web, mobile and desktop platforms. Around 900+ applications are desgined and delivered to our customers to make digital & strengthen their businesses." } }[0]
                        }
                    }
                },
                new { category = "Careers" },
                new { category = "Sign In" }
            };

            MenuFieldSettings menuFields = new MenuFieldSettings()
            {
                Text = new string[] { "category", "value" },
                Children = new string[] { "options" }
            };

            ViewBag.data = data;
            ViewBag.menuFields = menuFields;
            return View();
        }
    }
}
