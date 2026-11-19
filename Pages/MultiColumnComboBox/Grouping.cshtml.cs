using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;

namespace EJ2CoreSampleBrowser.Pages.MultiColumnComboBox;

public class GroupingModel : PageModel
{
    public List<Products> products { get; set; }
    public void OnGet()
    {
        products = new Products().GetAllRecords();
    }
}