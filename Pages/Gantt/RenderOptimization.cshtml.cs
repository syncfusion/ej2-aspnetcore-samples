using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Gantt
{
    public class RenderOptimizationModel : PageModel
    {
        public List<RecordCountData> DropDownData { get; set; }
        public string RecordCount { get; set; } = "5000";
        public void OnGet()
        {
            DropDownData = new List<RecordCountData>()
            {
                new RecordCountData
                {
                    Text = "5,000 Rows",
                    Value = "5000"
                },
                new RecordCountData
                {
                    Text = "10,000 Rows",
                    Value = "10000"
                }
            };
        }
    }
    public class RecordCountData
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }
}
