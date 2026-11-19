using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Grid;

public class GridOverviewModel : PageModel
{
    public List<object> DataRange { get; set; }
    public void OnGet()
    {
        DataRange = new List<object>();
        DataRange.Add(new { Text = "1,000 Rows 11 Columns", Value = "1000" });
        DataRange.Add(new { Text = "10,000 Rows 11 Columns", Value = "10000" });
        DataRange.Add(new { Text = "1,00,000 Rows 11 Columns", Value = "100000" });
    }
}