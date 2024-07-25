#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class SpreadsheetController : Controller
    {
        public IActionResult DataValidation()
        {
            List<object> data = new List<object>()
            {
                new { EmployeeId= "1001",  EmployeeName= "Vin Disel",  Date= "4/5/2021",  Weekday= "Mon",  TimeIn= "8:00 AM",  TimeOut= "10:00 PM",  HoursWorked= "14",  Basic= "=G4*30",  GrossPay= "=Sum(H4 + ((G4-8)*15))" },
                new { EmployeeId= "1002",  EmployeeName= "Steve",  Date= "4/6/2021",  Weekday= "Tue",  TimeIn= "8:00 AM",  TimeOut= "6:00 PM",  HoursWorked= "10",  Basic= "=G5*30",  GrossPay= "=Sum(H5 + ((G5-8)*15))" },
                new { EmployeeId= "1003",  EmployeeName= "Paul Waulker",  Date= "4/6/2021",  Weekday= "Tue",  TimeIn= "11:00 AM",  TimeOut= "4:00 PM",  HoursWorked= "9",  Basic= "=G6*30",  GrossPay= "=Sum(H6 + ((G6-8)*15))" },
                new { EmployeeId= "1004",  EmployeeName= "John",  Date= "4/8/2021",  Weekday= "Thu",  TimeIn= "8:00 AM",  TimeOut= "4:00 PM",  HoursWorked= "8",  Basic= "=G7*30",  GrossPay= "=Sum(H7 + ((G7-8)*15))" },
                new { EmployeeId= "1005",  EmployeeName= "Sam",  Date= "4/9/2021",  Weekday= "Fri",  TimeIn= "7:00 AM",  TimeOut= "6:00 PM",  HoursWorked= "11",  Basic= "=G8*30",  GrossPay= "=Sum(H8 + ((G8-8)*15))" },
                new { EmployeeId= "1006",  EmployeeName= "Chistoper",  Date= "4/12/2021",  Weekday= "Mon",  TimeIn= "10:00 AM",  TimeOut= "6:00 PM",  HoursWorked= "8",  Basic= "=G9*30",  GrossPay= "=Sum(H9 + ((G9-8)*15))" },
                new { EmployeeId= "1007",  EmployeeName= "Adrew",  Date= "4/13/2021",  Weekday= "Tue",  TimeIn= "10:00 AM",  TimeOut= "7:00 PM",  HoursWorked= "9",  Basic= "=G10*30",  GrossPay= "=Sum(H10 + ((G10-8)*15))" },
                new { EmployeeId= "1004",  EmployeeName= "John",  Date= "4/14/2021  ",  Weekday= "Wed",  TimeIn= "8:00 AM",  TimeOut= "4:00 PM",  HoursWorked= "8",  Basic= "=G11*30",  GrossPay= "=Sum(H11 + ((G11-8)*15))" },
                new { EmployeeId= "1009",  EmployeeName= "Bravo",  Date= "4/14/2021",  Weekday= "Wed",  TimeIn= "11:00 AM",  TimeOut= "8:00 PM",  HoursWorked= "9",  Basic= "=G12*30",  GrossPay= "=Sum(H12 + ((G12-8)*15))" },
                new { EmployeeId= "1002",  EmployeeName= "Steve",  Date= "4/15/2021",  Weekday= "Thu",  TimeIn= "9:00 AM",  TimeOut= "8:00 PM",  HoursWorked= "11",  Basic= "=G13*30",  GrossPay= "=Sum(H13 + ((G13-8)*15))" }
            };
            ViewBag.GrossPay = data;
            return View();
        }
    }
}