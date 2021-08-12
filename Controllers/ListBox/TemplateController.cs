using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Controllers.ListBox
{
    public partial class ListBoxController : Controller
    {

        public IActionResult Template()
        {
            List<object> data = new List<object>();
            data.Add(new { text = "JavaScript", pic = "javascript", description = "It is a lightweight interpreted or JIT-compiled programming language." });
            data.Add(new { text = "TypeScript", pic = "typescript", description = "It is a typed superset of JavaScript that compiles to plain JavaScript." });
            data.Add(new { text = "Angular", pic = "angular", description = "It is a TypeScript-based open-source web application framework." });
            data.Add(new { text = "React", pic = "react", description = "A JavaScript library for building user interfaces. It can also render on the server using Node."});
            data.Add(new { text = "Vue", pic = "vue", description = "A progressive framework for building user interfaces. it is incrementally adoptable." });
            ViewBag.data = data;
            return View();
        }
    }
}