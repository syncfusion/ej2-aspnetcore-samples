using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.EJ2.Gantt;

namespace EJ2CoreSampleBrowser.Pages.Gantt
{
    public class DefaultSortingModel : PageModel
    {
        public List<GanttSortDescriptor> Columns { get; set; }
        public void OnGet()
        {
            Columns = new List<GanttSortDescriptor>();
            Columns.Add(new GanttSortDescriptor { Field = "TaskName", Direction = Syncfusion.EJ2.Gantt.SortDirection.Ascending });
            Columns.Add(new GanttSortDescriptor { Field = "TaskId", Direction = Syncfusion.EJ2.Gantt.SortDirection.Ascending });
        }
    }
}