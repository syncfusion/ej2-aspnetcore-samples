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
