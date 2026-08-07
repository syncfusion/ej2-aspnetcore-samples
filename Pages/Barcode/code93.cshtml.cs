using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Barcode;

public class code93Model : PageModel
{
    public List<ExpandOptions> position { get; set; }
    public List<alignment> align { get; set; }
    public void OnGet()
    {
        position = new List<ExpandOptions>();
        position.Add(new ExpandOptions() { text = "Bottom", value = "bottom" });
        position.Add(new ExpandOptions() { text = "Top", value = "top" });
        
        align = new List<alignment>();
        align.Add(new alignment() { text = "Left", value = "left" });
        align.Add(new alignment() { text = "Right", value = "right" });
        align.Add(new alignment() { text = "Center", value = "center" });
    }
}