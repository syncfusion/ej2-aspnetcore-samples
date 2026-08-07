using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;

namespace EJ2CoreSampleBrowser.Pages.Grid;

public class BatchEditingModel : PageModel
{
    public List<InventoryStoreData> datasource { get; set; }

    public void OnGet()
    {
        datasource = InventoryStoreData.GetAllRecords();
    }
}