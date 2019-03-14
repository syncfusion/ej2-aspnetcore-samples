using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EJ2CoreSampleBrowser.Models;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Grids;

namespace EJ2CoreSampleBrowser.Controllers.Grid
{
    public partial class TreeGridController : Controller
    {

        public IActionResult ShowHideColumns()
        {
            var order = TreeData.GetDefaultData();
            ViewBag.dataSource = order;
            var columns = new List<Object>() {
                new { value= "TaskId", text= "Task ID" },
                new { value= "StartDate", text= "Start Date" },
                new { value= "Duration", text= "Duration" },
                new { value= "Progress", text= "Progress" }
            };
            ViewBag.columns = columns;
            return View();

        }
    }
}