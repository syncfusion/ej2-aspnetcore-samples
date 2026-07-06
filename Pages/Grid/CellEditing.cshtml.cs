using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;

namespace EJ2CoreSampleBrowser.Pages.Grid;

public class CellEditingModel : PageModel
{
    public List<AppointmentDetails> datasource { get; set; }

    public void OnGet()
    {
        datasource = AppointmentDetails.GetAllRecords();
    }
}