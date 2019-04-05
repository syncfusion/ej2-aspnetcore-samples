using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EJ2CoreSampleBrowser.Controllers.ListBox
{
    public partial class ListBoxController : Controller
    {
        // GET: /<controller>/
        public ActionResult Checkbox()
        {
            List<object> data = new List<object>();
            data.Add(new { text = "Hennessey Venom", id = "list-01" });
            data.Add(new { text = "Bugatti Chiron", id = "list-02" });
            data.Add(new { text = "Bugatti Veyron Super Sport", id = "list-03" });
            data.Add(new { text = "SSC Ultimate Aero", id = "list-04" });
            data.Add(new { text = "Koenigsegg CCR", id = "list-05" });
            data.Add(new { text = "McLaren F1", id = "list-06" });
            data.Add(new { text = "Aston Martin One- 77", id = "list-07" });
            data.Add(new { text = "Jaguar XJ220", id = "list-08" });
            data.Add(new { text = "McLaren P1", id = "list-09" });
            data.Add(new { text = "Ferrari LaFerrari", id = "list-10" });
            ViewBag.data = data;
            return View();
        }
    }
}
