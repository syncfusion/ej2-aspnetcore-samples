using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Controllers
{
    public class ModelSpace
    {
        public double[] cellSpacing { get; set; }

    }
    public partial class DashboardLayoutController : Controller
    {
        public IActionResult API()
        {
            ModelSpace modelValue = new ModelSpace();
            modelValue.cellSpacing = new double[] { 10, 10 };
            return View(modelValue);
        }
    }
}