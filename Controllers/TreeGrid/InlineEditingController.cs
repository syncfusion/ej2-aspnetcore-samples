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
       
        public IActionResult InlineEditing()
        {
            var order = TreeData.GetDefaultData();
            ViewBag.dataSource = order;
            List<Object> DropDownData = new List<object>();
            DropDownData.Add(new { id = "CellEditing", name = "Cell Editing" });
            DropDownData.Add(new { id = "RowEditing", name = "Row Editing" });
            ViewBag.DropDownData = DropDownData;
            return View();
        }       
    }
}