#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;


namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class ScheduleController : Controller
    {

        public IActionResult RecurrencePopulateRule()
        {
            ViewBag.data = GetRecurrenceData();
            return View();
        }

        public List<RecurrenceData> GetRecurrenceData()
        {
            List<RecurrenceData> data = new List<RecurrenceData>();
            data.Add(new RecurrenceData { rule = "FREQ=DAILY;INTERVAL=1" });
            data.Add(new RecurrenceData { rule = "FREQ=DAILY;INTERVAL=2;UNTIL=20410606T000000Z" });
            data.Add(new RecurrenceData { rule = "FREQ=DAILY;INTERVAL=2;COUNT=8" });
            data.Add(new RecurrenceData { rule = "FREQ=WEEKLY;BYDAY=MO,TU,WE,TH,FR;INTERVAL=1;UNTIL=20410729T000000Z" });
            data.Add(new RecurrenceData { rule = "FREQ=MONTHLY;BYDAY=FR;BYSETPOS=2;INTERVAL=1;UNTIL=20410729T000000Z" });
            data.Add(new RecurrenceData { rule = "FREQ=MONTHLY;BYDAY=FR;BYSETPOS=2;INTERVAL=1" });
            data.Add(new RecurrenceData { rule = "FREQ=YEARLY;BYDAY=MO;BYSETPOS=-1;INTERVAL=1;COUNT=5" });
            return data;
        }
    }

    public class RecurrenceData
    {
        public string rule { get; set; }
    }
}
