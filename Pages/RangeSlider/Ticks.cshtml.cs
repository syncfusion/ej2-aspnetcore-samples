using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.RangeSlider;

public class Ticks : PageModel
{
    public List<object> placement = new List<object>();
    public void OnGet()
    {
        placement.Add(new { value = "Before", text = "Before" });
        placement.Add(new { value = "After", text = "After" });
        placement.Add(new { value = "Both", text = "Both" });
        placement.Add(new { value = "None", text = "None" });
    }
}