using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EJ2CoreSampleBrowser.Models;

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class ComboBoxController : Controller
    {
        public IActionResult MultiColumn()
        {
            ViewBag.data = new Employee().EmployeesList();
            return View();
        }
    }
    public class Employee
    {
        public string FirstName { get; set; }
        public string EmployeeID { get; set; }
        public string Designation { get; set; }
        public string Country { get; set; }
        public List<Employee> EmployeesList()
        {
            List<Employee> emp = new List<Employee>();
            emp.Add(new Employee { FirstName = "Andrew Fuller", EmployeeID = "1", Designation = "Team Lead", Country = "England" });
            emp.Add(new Employee { FirstName = "Anne Dodsworth", EmployeeID = "2", Designation = "Developer", Country = "USA" });
            emp.Add(new Employee { FirstName = "Janet Leverling", EmployeeID = "3", Designation = "HR", Country = "USA" });
            emp.Add(new Employee { FirstName = "Laura Callahan", EmployeeID = "4", Designation = "Product Manager", Country = "USA" });
            emp.Add(new Employee { FirstName = "Margaret Peacock", EmployeeID = "5", Designation = "Developer", Country = "USA" });
            emp.Add(new Employee { FirstName = "Michael Suyama", EmployeeID = "6", Designation = "Team Lead", Country = "USA" });
            emp.Add(new Employee { FirstName = "Nancy Davolio", EmployeeID = "7", Designation = "Product Manager", Country = "USA" });
            emp.Add(new Employee { FirstName = "Robert King", EmployeeID = "8", Designation = "Developer ", Country = "England" });
            emp.Add(new Employee { FirstName = "Steven Buchanan", EmployeeID = "9", Designation = "CEO", Country = "England" });
            return emp;
        }
    }
}