using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;

namespace EJ2CoreSampleBrowser.Pages.Grid;

public class HeaderTemplateModel : PageModel
{
    public List<EmployeeDetails> DataSource { get; set; }

    public void OnGet()
    {
        DataSource = EmployeeDetails.GetAllRecords();
    }
}