using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
namespace EJ2CoreSampleBrowser.Pages.Maps;

public class MarkerTemplate : PageModel
{
    public object AustraliaMap()
    {
        string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/australia.js");
        return JsonConvert.DeserializeObject(allText);
    }
    public void OnGet()
    {
        
    }
}