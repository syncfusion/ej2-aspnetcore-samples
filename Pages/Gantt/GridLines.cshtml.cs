using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Gantt
{
    public class GridLinesModel : PageModel
    {
        public class DropDownList
        {
            public string Id { get; set; }
            public string Type { get; set; }

            public static List<DropDownList> GridLinesData ()
            {
                List<DropDownList> Data = new List<DropDownList>();
                Data.Add(new DropDownList { Id = "Both", Type = "Both" });
                Data.Add(new DropDownList { Id = "Vertical", Type = "Vertical" });
                Data.Add(new DropDownList { Id = "Horizontal", Type = "Horizontal" });
                Data.Add(new DropDownList { Id = "None", Type = "None" });
                return Data;
            }
        }
    }
}