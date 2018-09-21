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

        public IActionResult PieLegend()
        {
            List<PieData> chartData = new List<PieData>  
            {
                new PieData { xValue =  "Net-tution and Fees", yValue = 21, text = "21%" },
                new PieData { xValue =  "Self-supporting Operations", yValue = 21, text = "21%" },
                new PieData { xValue =  "Private Gifts", yValue = 8, text = "8%" },
                new PieData { xValue =  "All Other", yValue = 8, text = "8%" },
                new PieData { xValue =  "Local Revenue", yValue = 4, text = "4%" },
                new PieData { xValue =  "State Revenue", yValue = 21, text = "21%" },
                new PieData { xValue =  "Federal Revenue", yValue = 16, text = "16%" },
            };
            ViewBag.dataSource = chartData;
            return View();
        }        
    }
}
