#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.ComboBox;

public class MultiColumn : PageModel
{
    public List<Employee> Emp = new List<Employee>();
    public void OnGet()
    {
        Emp.Add(new Employee { FirstName = "Andrew Fuller", EmployeeID = "1", Designation = "Team Lead", Country = "England" });
        Emp.Add(new Employee { FirstName = "Anne Dodsworth", EmployeeID = "2", Designation = "Developer", Country = "USA" });
        Emp.Add(new Employee { FirstName = "Janet Leverling", EmployeeID = "3", Designation = "HR", Country = "USA" });
        Emp.Add(new Employee { FirstName = "Laura Callahan", EmployeeID = "4", Designation = "Product Manager", Country = "USA" });
        Emp.Add(new Employee { FirstName = "Margaret Peacock", EmployeeID = "5", Designation = "Developer", Country = "USA" });
        Emp.Add(new Employee { FirstName = "Michael Suyama", EmployeeID = "6", Designation = "Team Lead", Country = "USA" });
        Emp.Add(new Employee { FirstName = "Nancy Davolio", EmployeeID = "7", Designation = "Product Manager", Country = "USA" });
        Emp.Add(new Employee { FirstName = "Robert King", EmployeeID = "8", Designation = "Developer ", Country = "England" });
        Emp.Add(new Employee { FirstName = "Steven Buchanan", EmployeeID = "9", Designation = "CEO", Country = "England" });
    }
}
public class Employee
{
    public string FirstName { get; set; }
    public string EmployeeID { get; set; }
    public string Designation { get; set; }
    public string Country { get; set; }
}