using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;

namespace EJ2CoreSampleBrowser.Pages.Grid;

public class DefaultSelectionModel : PageModel
{
    public List<EmployeeView> DataSource { get; set; }
    public string[] type { get; set; }
    public string[] mode { get; set; }

    public void OnGet()
    {
        DataSource = EmployeeView.GetAllRecords();
        type = new string[] { "Single", "Multiple" };
        mode = new string[] { "Row", "Cell", "Both" };
    }
}