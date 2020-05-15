using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EJ2CoreSampleBrowser.Models;

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class KanbanController : Controller
    {
        public IActionResult WipValidation()
        {
            ViewBag.data = new KanbanDataModels().KanbanTasks();
            ViewBag.ColumnDropDowns = new KanbanDataModels().ColumnDropDowns();
            ViewBag.StatusData = new KanbanDataModels().StatusData();
            ViewBag.button = new
            {
                content = "OK",
                isPrimary = true
            };
            return View();
        }
    }
}