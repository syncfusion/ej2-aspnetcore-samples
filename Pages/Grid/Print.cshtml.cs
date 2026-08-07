using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;

namespace EJ2CoreSampleBrowser.Pages.Grid;

public class PrintModel : PageModel
{
    public List<OrdersDetails> DataSource { get; set; }
    public List<EmployeeView> EmpDataSource { get; set; }
    public List<Customer> CustomerDataSource { get; set; }
    public List<string> data { get; set; }
    
    public void OnGet()
    {
        DataSource = OrdersDetails.GetAllRecords();
        EmpDataSource = EmployeeView.GetAllRecords();
        CustomerDataSource = Customer.GetAllRecords();
        data = new List<string>() { "Expanded", "All", "None" };
    }
}