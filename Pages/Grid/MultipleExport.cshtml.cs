using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;

namespace EJ2CoreSampleBrowser.Pages.Grid;

public class MultipleExportModel : PageModel
{
    public List<OrdersDetails> DataSource { get; set; }
    public List<Customer> CustomerDataSource { get; set; }

    public void OnGet()
    {
        DataSource = OrdersDetails.GetAllRecords();
        CustomerDataSource = Customer.GetAllRecords();

    }

}