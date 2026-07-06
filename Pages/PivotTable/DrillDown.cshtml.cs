using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.PivotTable;

public class DrillDown : PageModel
{
    public List<DrillDownOptions> drillDownOptions = new List<DrillDownOptions>();
    public List<DrillDownFields> drillDownFields = new List<DrillDownFields>();
    public void OnGet()
    {
        drillDownOptions.Add(new DrillDownOptions { value = "allHeaders", text = "All headers" });
        drillDownOptions.Add(new DrillDownOptions { value = "rowHeaders", text = "Row headers" });
        drillDownOptions.Add(new DrillDownOptions { value = "columnHeader", text = "Column headers" });
        drillDownOptions.Add(new DrillDownOptions { value = "specificFields", text = "Specific fields" });
        drillDownOptions.Add(new DrillDownOptions { value = "specificHeaders", text = "Specific headers" });
        
        drillDownFields.Add(new DrillDownFields { Field = "Country", expandAll = false });
        drillDownFields.Add(new DrillDownFields { Field = "Year", expandAll = false });
    }
}
public class DrillDownOptions
{
    public string value { get; set; }
    public string text { get; set; }
}

public class DrillDownFields
{
    public string Field { get; set; }
    public bool expandAll { get; set; }
}