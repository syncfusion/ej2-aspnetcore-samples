using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;

namespace EJ2CoreSampleBrowser.Pages.Grid;
public class FifaStatisticsModel : PageModel
{
    public List<FifaStatisticsData> FifaData { get; set; }

    public void OnGet()
    {
        FifaData = FifaStatisticsData.GetFifaData();
    }
}
