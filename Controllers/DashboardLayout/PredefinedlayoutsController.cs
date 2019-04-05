using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Controllers
{
    public class SpaceModel
    {
        public double[] cellSpacing { get; set; }

    }
    public partial class DashboardLayoutController : Controller
    {
        public IActionResult PredefinedLayouts()
        {
            SpaceModel modelValue = new SpaceModel();
            modelValue.cellSpacing = new double[] { 5, 5 };
            return View(modelValue);
        }
    }
}