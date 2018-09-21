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
        public IActionResult TrendLines()
        {
            List<ChartTrendline> lines = new List<ChartTrendline>();
            ChartTrendline line = new ChartTrendline();
            line.Type = TrendlineTypes.Linear;
            line.Width = 3; line.Name = "Linear";
            line.Fill = "#C64A75";
            lines.Add(line);
            ViewBag.trendLines = lines;
            ViewBag.type = new String[] { "Linear", "Exponential", "Power", "Logarithmic", "Polynomial", "MovingAverage" };
            return View();
        }
    }
}