using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;
namespace EJ2CoreSampleBrowser.Pages.Grid;

public class ColumnChooserModel : PageModel
{
    public List<OrderedData> datasource { get; set; }

    public void OnGet()
    {
        datasource = OrderedData.GetAllRecords();
    }
}