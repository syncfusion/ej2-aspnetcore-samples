using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EJ2CoreSampleBrowser.Controllers.ListBox
{
    public partial class ListBoxController : Controller
    {
        // GET: /<controller>/
        public IActionResult DragAndDrop()
        {
            List<object> groupA = new List<object>();
            groupA.Add(new { Name = "Australia", Code = "AU" });
            groupA.Add(new { Name = "Bermuda", Code = "BM" });
            groupA.Add(new { Name = "Canada", Code = "CA" });
            groupA.Add(new { Name = "Cameroon", Code = "CM" });
            groupA.Add(new { Name = "Denmark", Code = "DK" });
            groupA.Add(new { Name = "France", Code = "FR" });
            groupA.Add(new { Name = "Finland", Code = "FI" });
            groupA.Add(new { Name = "Germany", Code = "DE" });
            groupA.Add(new { Name = "Hong Kong", Code = "HK" });
            ViewBag.groupA = groupA.ToArray();

            List<object> groupB = new List<object>();
            groupB.Add(new { Name = "India", Code = "IN" });
            groupB.Add(new { Name = "Italy", Code = "IT" });
            groupB.Add(new { Name = "Japan", Code = "JP" });
            groupB.Add(new { Name = "Mexico", Code = "MX" });
            groupB.Add(new { Name = "Norway", Code = "NO" });
            groupB.Add(new { Name = "Poland", Code = "PL" });
            groupB.Add(new { Name = "Switzerland", Code = "CH" });
            groupB.Add(new { Name = "United Kingdom", Code = "GB" });
            groupB.Add(new { Name = "United States", Code = "US" });
            ViewBag.groupB = groupB.ToArray();
            return View();
        }
    }
}
