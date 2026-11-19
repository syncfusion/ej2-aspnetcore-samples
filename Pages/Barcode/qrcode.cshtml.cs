using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Barcode;

public class qrcodeModel : PageModel
{
    public  List<coorectionLevel> level { get; set; }
    public void OnGet()
    {
        level = new List<coorectionLevel>();
        level.Add(new coorectionLevel() { text = "Low", value = "7" });
        level.Add(new coorectionLevel() { text = "Medium", value = "15" });
        level.Add(new coorectionLevel() { text = "Quartile", value = "25" });
        level.Add(new coorectionLevel() { text = "High", value = "30" });
    }
}