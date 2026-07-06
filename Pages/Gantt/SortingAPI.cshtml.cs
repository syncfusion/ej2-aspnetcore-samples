using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Gantt
{
    public class SortingAPIModel : PageModel
    {
        public class DropDownList
        {
            public string id { get; set; }
            public string type { get; set; }
            public static List<DropDownList> Columns ()
            {
                List<DropDownList> Data = new List<DropDownList>();
                Data.Add(new DropDownList { id = "TaskName", type = "TaskName" });
                Data.Add(new DropDownList { id = "StartDate", type = "StartDate" });
                Data.Add(new DropDownList { id = "EndDate", type = "EndDate" });
                Data.Add(new DropDownList { id = "Duration", type = "Duration" });
                Data.Add(new DropDownList { id = "Progress", type = "Progress" });
                return Data;
            }
            public static List<DropDownList> Direction ()
            {
                List<DropDownList> Data = new List<DropDownList>();
                Data.Add(new DropDownList { id = "Ascending", type = "Ascending" });
                Data.Add(new DropDownList { id = "Descending", type = "Descending" });
                return Data;
            }
        }
    }
}