using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;

namespace EJ2CoreSampleBrowser.Pages.Grid;

public class MultiSortingModel : PageModel
{
    public List<OrdersDetails> DataSource { get; set; }
    public List<object> cols { get; set; }
    public void OnGet()
    {
        DataSource = OrdersDetails.GetAllRecords();
        cols = new List<object>();
        cols.Add(new { field = "OrderDate", direction = "Ascending" });
        cols.Add(new { field = "Freight", direction= "Descending" });
    }

}