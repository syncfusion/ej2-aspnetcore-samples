using EJ2CoreSampleBrowser.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Grid
{
    public class RowSpanningAPIModel : PageModel
    {
        public List<TelecastData> DataSource { get; set; }
        public void OnGet()
        {
            DataSource = TelecastData.GetAllRecords();
        }
    }
}