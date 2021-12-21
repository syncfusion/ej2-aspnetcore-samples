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
        public IActionResult GroupedColumn()
        {
            List<ColumnData> chartData = new List<ColumnData>
            {
                new ColumnData { Year = "2012", USA_Total = 104, USA_Gold = 46, UK_Total = 65, UK_Gold = 29, China_Total = 91, China_Gold = 38},
                new ColumnData { Year = "2016", USA_Total = 121, USA_Gold = 46, UK_Total = 67, UK_Gold = 27, China_Total = 70, China_Gold = 26},
                new ColumnData { Year = "2020", USA_Total = 113, USA_Gold = 39, UK_Total = 65, UK_Gold = 22, China_Total = 88, China_Gold = 38},
            };
            ViewBag.dataSource = chartData;
            return View();
        }
        public class ColumnData
        {
            public string Year;
            public double USA_Total;
            public double USA_Gold;
            public double UK_Total;
            public double UK_Gold;
            public double China_Total;
            public double China_Gold;
        }
    }
}
