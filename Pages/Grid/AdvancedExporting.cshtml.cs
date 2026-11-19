using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;
namespace EJ2CoreSampleBrowser.Pages.Grid;

public class AdvancedExportingModel : PageModel
{
    public List<Product> datasource { get; set; }
    public void OnGet()
    {
        datasource = Product.GetAllRecords().ToList();
    }
}