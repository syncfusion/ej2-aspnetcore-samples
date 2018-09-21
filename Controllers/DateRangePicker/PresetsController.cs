using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class DateRangePickerController : Controller
    {
        public IActionResult Presets()
        {
            int days = (int)DateTime.Now.DayOfWeek;
            DateTime lastMonth = DateTime.Now.AddMonths(-1);
            ViewBag.weekStart = DateTime.Now.AddDays(-days);
            ViewBag.weekEnd = ViewBag.weekStart.AddDays(6);
            ViewBag.monthStart = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            ViewBag.monthEnd = ViewBag.monthStart.AddMonths(1).AddDays(-1);
            ViewBag.lastMonthStart = new DateTime(DateTime.Now.Year, (DateTime.Now.Month - 1), 1);
            ViewBag.lastMonthEnd = ViewBag.lastMonthStart.AddMonths(1).AddDays(-1);
            ViewBag.lastYearStart = new DateTime(DateTime.Now.Year - 1, 1, 1);
            ViewBag.lastYearEnd = new DateTime(DateTime.Now.Year - 1, 12, 31);
            return View();
        }
    }
}