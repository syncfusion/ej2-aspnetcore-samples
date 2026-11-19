using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;

namespace EJ2CoreSampleBrowser.Pages.Grid;

public class GroupAndCaptionAggregateModel : PageModel
{
    public List<EnergyData> DataSource { get; set; }

    public void OnGet()
    {
        DataSource = EnergyData.GetAllRecords().ToList();
    }
}