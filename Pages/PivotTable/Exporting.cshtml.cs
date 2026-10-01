using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.PivotTable;

public class Exporting : PageModel
{
    public List<ExportDropDownData> exportData = new List<ExportDropDownData>();
    public string[] YearFilterMembers;
    public string[] ProductsFilterMembers;
    public string[] drilledMembers;
    public void OnGet()
    {
        exportData.Add(new ExportDropDownData { Name = "Excel", Value = "excel" });
        exportData.Add(new ExportDropDownData { Name = "CSV", Value = "csv" });
        exportData.Add(new ExportDropDownData { Name = "PDF", Value = "pdf" });
        YearFilterMembers = new string[] { "FY 2026" };
        ProductsFilterMembers = new string[] { "Gloves", "Fenders" };
        drilledMembers = new string[] { "France" };
    }
}
public class ExportDropDownData
{
    public string Name { get; set; }
    public string Value { get; set; }
}