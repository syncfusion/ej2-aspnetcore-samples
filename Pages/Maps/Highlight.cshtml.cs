using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
namespace EJ2CoreSampleBrowser.Pages.Maps;

public class Highlight : PageModel
{
    public string getHighlightMarkers()
    {
        return System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/highlightmarkers.js");
    }

    public object getOklahoma()
    {
        string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/oklahoma.js");
        return JsonConvert.DeserializeObject(allText);
    }

    public void OnGet()
    {
        
    }
}