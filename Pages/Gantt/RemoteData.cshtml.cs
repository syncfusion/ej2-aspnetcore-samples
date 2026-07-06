using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Gantt
{
    public class RemoteDataModel : PageModel
    {
        public List<GanttDropDownList> DropdownData { get; set; }
        public string RecordCount { get; set; } = "1000";
        public void OnGet()
        {
            DropdownData = DLData();
        }
        public static List<GanttDropDownList> DLData()
        {
            return new List<GanttDropDownList>
                {
                new GanttDropDownList { Text = "1,000 Rows", Value = "1000" },
                new GanttDropDownList { Text = "2,500 Rows", Value = "2500" },
                new GanttDropDownList { Text = "5,000 Rows", Value = "5000" }
            };
        }
    }
    public class GanttDropDownList
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }
}