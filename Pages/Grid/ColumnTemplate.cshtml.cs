using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;

namespace EJ2CoreSampleBrowser.Pages.Grid;

public class ColumnTemplateModel : PageModel
{
    public List<EmployeeDetails> DataSource { get; set; }

    public void OnGet()
    {
        DataSource = EmployeeDetails.GetAllRecords();

    }
}