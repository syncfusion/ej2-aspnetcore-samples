using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.PivotTable;

public class Performance : PageModel
{
    public List<PerformanceOptions> performanceOptions = new List<PerformanceOptions>();
    public void OnGet()
    {
        performanceOptions.Add(new PerformanceOptions { text = "10,000 Rows and 10 Columns", value = 10000 });
        performanceOptions.Add(new PerformanceOptions { text = "1,00,000 Rows and 10 Columns", value = 100000 });
        performanceOptions.Add(new PerformanceOptions { text = "1,000,000 Rows and 10 Columns", value = 1000000 });
    }
}

public class PerformanceOptions
{
    public string text { get; set; }

    public int value { get; set; }
}