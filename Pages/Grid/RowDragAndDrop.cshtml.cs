using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;

namespace EJ2CoreSampleBrowser.Pages.Grid;

public class RowDragAndDropModel : PageModel
{
    public List<OrdersDetails> DataSource { get; set; }

    public void OnGet()
    {
        var order = OrdersDetails.GetAllRecords();
        DataSource = order.Take(24).ToList();
    }
}