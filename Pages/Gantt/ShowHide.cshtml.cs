using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Gantt
{
    public class ShowHideModel : PageModel
    {
        public List<object> ColumnNames { get; set; }
        public void OnGet ()
        {
            ColumnNames = new List<object>();
            ColumnNames.Add(new { text = "ID", value = "TaskId" });
            ColumnNames.Add(new { text = "Start Date", value = "StartDate" });
            ColumnNames.Add(new { text = "End Date", value = "EndDate" });
            ColumnNames.Add(new { text = "Duration", value = "Duration" });
            ColumnNames.Add(new { text = "Progress", value = "Progress" });
            ColumnNames.Add(new { text = "Dependency", value = "Predecessor" });
        }
    }
}