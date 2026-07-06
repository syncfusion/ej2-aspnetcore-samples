using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.RangeSlider;

public class Tooltip : PageModel
{
    public List<object> placement = new List<object>();
    public List<object> showON = new List<object>();
    public void OnGet()
    {
        placement.Add(new { value = "Before", text = "Before" });
        placement.Add(new { value = "After", text = "After" });
        
        showON.Add(new { value = "Auto", text = "Auto" });
        showON.Add(new { value = "Focus", text = "Focus" });
        showON.Add(new { value = "Hover", text = "Hover" });
        showON.Add(new { value = "Always", text = "Always" });
    }
}