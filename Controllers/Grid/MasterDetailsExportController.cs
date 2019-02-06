using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EJ2CoreSampleBrowser.Models;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Controllers.Grid
{
    public partial class GridController : Controller
    {
        public IActionResult MasterDetailsExport()
        {
            var order = OrdersDetails.GetAllRecords();
            ViewBag.Datasource = order;
            ViewBag.EmpDataSource = EmployeeView.GetAllRecords();
            ViewBag.CustomerDataSource = Customer.GetAllRecords();
            return View();
        }
    }
}