using EJ2CoreSampleBrowser.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Grid
{
    public class ChartModel : PageModel
    {
        public List<SalesData> DataSource { get; set; }
        public void OnGet()
        {
            DataSource = SalesData.GetAllRecords();
        }
    }
}
