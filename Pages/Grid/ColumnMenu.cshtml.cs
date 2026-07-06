using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;
namespace EJ2CoreSampleBrowser.Pages.Grid;

public class ColumnMenuModel : PageModel
{
    public List<OrdersDetails> datasource { get; set; }
    public string[] ddDataSource { get; set; }

    public void OnGet()
    {
        datasource = OrdersDetails.GetAllRecords();
        ddDataSource = new string[] { "Default", "Custom" };
    }
}