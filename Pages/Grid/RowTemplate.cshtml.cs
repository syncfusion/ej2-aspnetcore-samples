using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;

namespace EJ2CoreSampleBrowser.Pages.Grid;

public class RowTemplateModel : PageModel
{
    public List<PizzaData> DataSource { get; set; }

    public void OnGet()
    {
        DataSource = PizzaData.GetAllRecords();
    }
}