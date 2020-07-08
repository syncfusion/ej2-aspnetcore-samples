using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EJ2CoreSampleBrowser.Models;
using HeatMapAxis = Syncfusion.EJ2.HeatMap;
namespace EJ2CoreSampleBrowser.Controllers.HeatMapChart
{
    public partial class HeatMapChartController : Controller
    {
        public IActionResult MultiLevelLabels()
        {
            ViewBag.AxisBorder = new HeatMapAxis.HeatMapAxisLabelBorder() { Color= "#a19d9d" , Width=1, Type=Syncfusion.EJ2.HeatMap.BorderType.Rectangle };
            ViewBag.dataSource = new HeatMapData().GetMultiLevelData();
            return View();
        }
    }
}