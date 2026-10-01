using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;

namespace EJ2CoreSampleBrowser.Pages.Grid;

public class ForumulaCellModel : PageModel
{
    public List<FormulaData> datasource { get; set; }

    public void OnGet()
    {
        datasource = FormulaData.GetData();
    }
}
