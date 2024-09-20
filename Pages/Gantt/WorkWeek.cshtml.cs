#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.EJ2.Navigations;

namespace EJ2CoreSampleBrowser_NET8.Pages.Gantt
{
    public class WorkWeekModel : PageModel
    {
     
        public string[] WorkWeek {  get; set; }
        public void OnGet ()
        {

            WorkWeek = new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
        }
        public class DropDownData
        {
            public string Id { get; set; }
            public string Day { get; set; }

            public static List<DropDownData> GetDayOfWeek ()
            {
                List<DropDownData> dayOfWeek = new List<DropDownData>();
                dayOfWeek.Add(new DropDownData { Id = "Sunday", Day = "Sunday" });
                dayOfWeek.Add(new DropDownData { Id = "Monday", Day = "Monday" });
                dayOfWeek.Add(new DropDownData { Id = "Tuesday", Day = "Tuesday" });
                dayOfWeek.Add(new DropDownData { Id = "Wednesday", Day = "Wednesday" });
                dayOfWeek.Add(new DropDownData { Id = "Thursday", Day = "Thursday" });
                dayOfWeek.Add(new DropDownData { Id = "Friday", Day = "Friday" });
                dayOfWeek.Add(new DropDownData { Id = "Saturday", Day = "Saturday" });
                return dayOfWeek;
            }
            
        }
    }
}
