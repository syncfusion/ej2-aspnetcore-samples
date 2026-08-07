using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Grid;
using EJ2CoreSampleBrowser.Models;

public class DefaultScrollingModel : PageModel
{
    public List<OrdersDetails> DataSource { get; set; }

    public void OnGet()
    {
        DataSource = OrdersDetails.GetAllRecords();
    }
}