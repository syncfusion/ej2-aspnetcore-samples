using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;

namespace EJ2CoreSampleBrowser.Pages.Grid;

public class SelectionAPIModel : PageModel
{
    public List<InventorDetails> datasource { get; set; }

    public void OnGet()
    {
        datasource = InventorDetails.GetAllRecords();
    }
}