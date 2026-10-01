using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;

namespace EJ2CoreSampleBrowser.Pages.Grid;

public class RowNumberModel : PageModel
{
    public List<GroceryProduct> datasource { get; set; }

    public void OnGet()
    {
        datasource = GroceryProduct.GetAllProducts();
    }
}
