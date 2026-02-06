#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.MultiColumnComboBox;

public class TemplateModel : PageModel
{
    public List<EmployeeList> Employees { get; set; }
    public void OnGet()
    {
        Employees = GetEmployees();
    }
    public List<EmployeeList> GetEmployees()
    {
        return new List<EmployeeList>
        {
            new EmployeeList { Name = "Andrew Fuller", Eimg = "7", Designation = "Team Lead", Country = "England", DateofJoining = "2010/12/10" },
            new EmployeeList { Name = "Anne Dodsworth", Eimg = "1", Designation = "Developer", Country = "USA", DateofJoining = "2000/10/05" },
            new EmployeeList { Name = "Janet Leverling", Eimg = "3", Designation = "HR", Country = "Russia", DateofJoining = "2016/02/23" },
            new EmployeeList { Name = "Laura Callahan", Eimg = "2", Designation = "Product Manager", Country = "Ukraine", DateofJoining = "2012/01/30" },
            new EmployeeList { Name = "Margaret Peacock", Eimg = "6", Designation = "Developer", Country = "Egypt", DateofJoining = "2014/08/15" },
            new EmployeeList { Name = "Michael Suyama", Eimg = "9", Designation = "Team Lead", Country = "Africa", DateofJoining = "2015/07/27" },
            new EmployeeList { Name = "Nancy Davolio", Eimg = "4", Designation = "Product Manager", Country = "Australia", DateofJoining = "2017/05/24" },
            new EmployeeList { Name = "Robert King", Eimg = "8", Designation = "Developer", Country = "India", DateofJoining = "2018/09/08" },
            new EmployeeList { Name = "Steven Buchanan", Eimg = "10", Designation = "CEO", Country = "Ireland", DateofJoining = "2020/03/05" }
        };
    }

    public class EmployeeList
    {
        public string Name { get; set; }
        public string Eimg { get; set; }
        public string Designation { get; set; }
        public string Country { get; set; }
        public string DateofJoining { get; set; }
    }
}