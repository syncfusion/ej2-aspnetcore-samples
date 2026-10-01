using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;

namespace EJ2CoreSampleBrowser.Pages.Grid;

public class DefaultAggregateModel : PageModel
{
    public List<OverallData> DataSource { get; set; }

    public void OnGet()
    {
        DataSource = OverallData.GetAllRecords();
    }
}