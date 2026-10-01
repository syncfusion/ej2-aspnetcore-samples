using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Tooltip;

public class AjaxContent : PageModel
{
    public List<object> country = new List<object>();
    public void OnGet()
    {
        country.Add(new { id = "1", text = "Australia" });
        country.Add(new { id = "2", text = "Bhutan" });
        country.Add(new { id = "3", text = "China" });
        country.Add(new { id = "4", text = "Cuba" });
        country.Add(new { id = "5", text = "India" });
        country.Add(new { id = "6", text = "Switzerland" });
        country.Add(new { id = "7", text = "United States" });
    }
}