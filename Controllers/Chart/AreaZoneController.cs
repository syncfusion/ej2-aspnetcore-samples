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
        public IActionResult AreaZone()
        {
            List<ChartSegment> segments = new List<ChartSegment>();
            ChartSegment segment1 = new ChartSegment();
            segment1.Value = new DateTime(2016, 5, 1);
            segment1.Color = "url(#winter)";
            segments.Add(segment1);

            ChartSegment segment2 = new ChartSegment();
            segment2.Value = new DateTime(2016, 8, 1);
            segment2.Color = "url(#summer)";
            segments.Add(segment2);

            ChartSegment segment3 = new ChartSegment();            
            segment3.Color = "url(#spring)";
            segments.Add(segment3);

            ViewBag.segment = segments;

            
            return View();
        }
    }
}