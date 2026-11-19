using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
namespace EJ2CoreSampleBrowser.Pages.Maps;

public class Tooltip : PageModel
{
    public object GetWorldMap()
    {
        string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/WorldMap.json");
        return JsonConvert.DeserializeObject(allText);
    }
    public object GetWorldcup()
    {
        string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/worldcup.js");
        return JsonConvert.DeserializeObject(allText);
    }

    public void OnGet()
    {
        
    }
}