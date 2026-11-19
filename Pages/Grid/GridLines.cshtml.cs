using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;

namespace EJ2CoreSampleBrowser.Pages.Grid;

public class GridLinesModel : PageModel
{
    public List<EmployeeView> DataSource { get; set; }
    public string[] data { get; set; }
    
    public void OnGet()
    {
        DataSource = EmployeeView.GetAllRecords();
        data = new string[] { "Default", "Both", "None","Horizontal", "Vertical" };
    }
}