using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;

namespace EJ2CoreSampleBrowser.Pages.Grid;

public class EventsModel : PageModel
{
    public List<Category> DataSource { get; set; }

    public void OnGet()
    {
        DataSource = Category.GetAllRecords().ToList();

    }
}