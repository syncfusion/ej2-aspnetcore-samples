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

        public IActionResult DataEditing()
        {
            List<DataEditingData> chartData = new List<DataEditingData>
            {
                new DataEditingData { xValue = "2005", y = 21, y1= 21},
                new DataEditingData { xValue = "2006", y = 60, y1= 22},
                new DataEditingData { xValue = "2007", y = 45, y1= 36 },
                new DataEditingData { xValue = "2008", y = 50, y1= 34},
                new DataEditingData { xValue = "2009", y = 74, y1= 54 },
                new DataEditingData { xValue = "2010", y = 65, y1= 55},
                new DataEditingData { xValue = "2011", y = 85, y1= 60}
                
             };
            ViewBag.dataSource = chartData;
            return View();
        }
        
        public class DataEditingData
        {
            public string xValue;
            public double y;
            public double y1;
        }
    }
}
