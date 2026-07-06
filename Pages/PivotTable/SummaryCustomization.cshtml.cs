using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.PivotTable;

public class SummaryCustomization : PageModel
{
    public List<Fields> fields = new List<Fields>();
    public List<SummaryOption> summaryOption = new List<SummaryOption>();
    public void OnGet()
    {
        fields.Add(new Fields { Name = "Country" });
        fields.Add(new Fields { Name = "Year" });
        
        summaryOption.Add(new SummaryOption { value = "grandTotals", text = "Grand Totals" });
        summaryOption.Add(new SummaryOption { value = "subTotals", text = "Sub-totals" });
    }
}
public class Fields
{
    public string Name { get; set; }
    public string Code { get; set; }
}
public class SummaryOption
{
    public string value { get; set; }
    public string text { get; set; }
}