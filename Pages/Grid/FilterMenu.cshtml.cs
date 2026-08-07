using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;
namespace EJ2CoreSampleBrowser.Pages.Grid;

public class FilterMenuModel : PageModel
{ 
    public List<OrdersDetails> DataSource { get; set; }
    public string[] filtertype { get; set; }

    public void OnGet()
    {
        DataSource = OrdersDetails.GetAllRecords();
        filtertype = new string[] { "Menu","Excel","CheckBox"};    
    }
}