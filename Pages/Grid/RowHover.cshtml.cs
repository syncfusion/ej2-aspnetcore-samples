using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;

namespace EJ2CoreSampleBrowser.Pages.Grid;

public class RowHoverModel : PageModel
{
    public List<Product> DataSource { get; set; }

    public void OnGet()
    {
        DataSource = Product.GetAllRecords().ToList();
    }
}