using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Charts;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class ChartController : Controller
    {

        public IActionResult InversedAxis()
        {
            List<CategoryData> chartData = new List<CategoryData>
            {
                new CategoryData { x = "2008", y = 1.5 },
                new CategoryData { x = "2009", y = 7.6 },
                new CategoryData { x = "2010", y = 11 },
                new CategoryData { x = "2011", y = 16.2 },
                new CategoryData { x = "2012", y = 18 },
                new CategoryData { x = "2013", y = 21.4 },
                new CategoryData { x = "2014", y = 16 },
                new CategoryData { x = "2015", y = 17.1 },
             };
            ViewBag.dataSource = chartData;
            return View();
        }        
    }
}
