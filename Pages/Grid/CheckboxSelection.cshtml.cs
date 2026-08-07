using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;
namespace EJ2CoreSampleBrowser.Pages.Grid;

public class CheckboxSelectionModel : PageModel
{
    public List<OrdersDetails> datasource { get; set; }

    public void OnGet()
    {
        datasource = OrdersDetails.GetAllRecords();
    }
}