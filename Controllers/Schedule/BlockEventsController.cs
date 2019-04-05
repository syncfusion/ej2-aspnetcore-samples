using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EJ2CoreSampleBrowser.Models;

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class ScheduleController : Controller
    {

        public IActionResult BlockEvents()
        {
            ViewBag.dataSource = new ScheduleData().getBlockData();
            List<EmployeeData> employees = new List<EmployeeData>();
            employees.Add(new EmployeeData { text = "Alice", id = 1, groupId = 1, color = "#bbdc00", designation = "Content writer" });
            employees.Add(new EmployeeData { text = "Nancy", id = 2, groupId = 2, color = "#9e5fff", designation = "Designer" });
            employees.Add(new EmployeeData { text = "Robert", id = 3, groupId = 1, color = "#bbdc00", designation = "Software Engineer" });
            employees.Add(new EmployeeData { text = "Robson", id = 4, groupId = 2, color = "#9e5fff", designation = "Support Engineer" });
            employees.Add(new EmployeeData { text = "Laura", id = 5, groupId = 1, color = "#bbdc00", designation = "Human Resource" });
            employees.Add(new EmployeeData { text = "Margaret", id = 6, groupId = 2, color = "#9e5fff", designation = "Content Analyst" });
            ViewBag.Employees = employees;

            ViewBag.Resources = new string[] { "Employee" };
            return View();
        }

        public class EmployeeData
        {
            public string text { set; get; }
            public int id { set; get; }
            public int groupId { set; get; }
            public string color { set; get; }
            public string designation { set; get; }
        }
    }
}
