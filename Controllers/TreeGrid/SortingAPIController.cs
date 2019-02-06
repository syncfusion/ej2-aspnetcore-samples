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
       
        public IActionResult SortingAPI()
        {
            var order = TreeData.GetDefaultData();
            ViewBag.dataSource = order;
            var columns = new List<object>() {
               new { id= "TaskId", name= "Task ID" },
               new { id= "TaskName", name= "Task Name" },
               new { id= "progress", name= "Progress" },
               new { id= "Duration", name= "Duration" }
            };
            ViewBag.columnsdata = columns;
            var directions = new List<object>() {
               new { id= "Ascending", name= "Ascending" },
               new { id= "Descending", name= "Descending" }
            };
            ViewBag.directionData = directions;
            return View();
        }       
    }
}