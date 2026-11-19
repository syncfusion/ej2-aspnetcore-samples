using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;

namespace EJ2CoreSampleBrowser.Pages.Grid;

public class DefaultExportingModel : PageModel
{
    public List<ExportEmployeeDetails> DataSource { get; set; }

    public void OnGet()
    {
        DataSource = ExportEmployeeDetails.GetAllRecords();
    }
}