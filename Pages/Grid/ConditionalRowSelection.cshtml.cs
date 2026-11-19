using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;
namespace EJ2CoreSampleBrowser.Pages.Grid;

public class ConditionalRowSelectionModel : PageModel
{
    public List<OrdersTrackData> datasource { get; set; }

    public void OnGet()
    {
        datasource = OrdersTrackData.GetAllRecords();
    }
}