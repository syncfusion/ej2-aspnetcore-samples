using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;

namespace EJ2CoreSampleBrowser.Pages.Grid;

public class RowSpanningModel : PageModel
{
    public List<Merge> DataSource { get; set; }

    public void OnGet()
    {
        DataSource = Merge.GetRowSpanData();

    }
}