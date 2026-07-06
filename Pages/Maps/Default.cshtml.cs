using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
namespace EJ2CoreSampleBrowser.Pages.Maps;

public class Default : PageModel
{
    public object getDataSource()
    {
        string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/salescontinent.js");
        return JsonConvert.DeserializeObject(allText);
    }
    public object GetWorldMap()
    {
        string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/WorldMap.json");
        return JsonConvert.DeserializeObject(allText);
    }
    public void OnGet()
    {
        
    }
}