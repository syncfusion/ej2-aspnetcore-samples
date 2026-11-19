using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;

namespace EJ2CoreSampleBrowser.Pages.MultiColumnComboBox;

public class KeyboardNavigationModel : PageModel
{
    public List<ProductDetails> product { get; set; }
    public void OnGet()
    {
        product = new ProductDetails().GetAllRecords();
    }
}