using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;
namespace EJ2CoreSampleBrowser.Pages.Grid;

public class PinnedRowsModel : PageModel
{
    public List<SupportData> datasource { get; set; }

    public void OnGet()
    {
        datasource = SupportData.GetAllRecords();
    }
}