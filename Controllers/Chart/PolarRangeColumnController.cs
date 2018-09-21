using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Charts;

namespace EJ2CoreSampleBrowser.Controllers.Chart
{
    public partial class ChartController : Controller
    {
        public IActionResult PolarRangeColumn()
        {
            List<PolarRangeColumnData> data = new List<PolarRangeColumnData>
            {
                new PolarRangeColumnData { x= "Jan", low= 2.7, high= 7.1 }, 
                new PolarRangeColumnData { x= "Feb", low= 3.9, high= 7.7 },
                new PolarRangeColumnData { x= "Mar", low= 3.2, high= 7.5 }, 
                new PolarRangeColumnData { x= "Apr", low= 4.5, high= 9.8 },
                new PolarRangeColumnData { x= "May", low= 6.7, high= 11.4 }, 
                new PolarRangeColumnData { x= "June", low= 8.4, high= 14.4 },
                new PolarRangeColumnData { x= "July", low= 11.6, high= 17.2 }, 
                new PolarRangeColumnData { x= "Aug", low= 12.7, high= 17.9 },
                new PolarRangeColumnData { x= "Sep", low= 9.5, high= 15.1 }, 
                new PolarRangeColumnData { x= "Oct", low= 5.0, high= 10.5 },
                new PolarRangeColumnData { x= "Nov", low= 3.2, high= 7.9 }, 
                new PolarRangeColumnData { x= "Dec", low= 6.1, high= 9.1 }
            };
            ViewBag.dataSource = data;
            ViewBag.select = new string[] { "Polar", "Radar" };
            return View();
        }
        public class PolarRangeColumnData
        {
            public string x;
            public double low;
            public double high;
        }
    }
}