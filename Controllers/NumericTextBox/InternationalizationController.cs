using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class NumericTextBoxController : Controller
    {
		 public class Cultures
        {
            public string CultureName { get; set; }
           
        }
        // GET: /<controller>/
        public IActionResult Internationalization()
        {
			
            List<Cultures> cultureData = new List<Cultures>();
            cultureData.Add(new Cultures() { CultureName = "de" });
            cultureData.Add(new Cultures() { CultureName = "zh" });
            cultureData.Add(new Cultures() { CultureName = "en" });
            ViewBag.cultureData = cultureData;
            return View();
        }
    }
}
