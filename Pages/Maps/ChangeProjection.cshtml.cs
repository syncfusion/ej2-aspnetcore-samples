using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
namespace EJ2CoreSampleBrowser.Pages.Maps;

public class ChangeProjection : PageModel
{
    public object unocountries()
    {
        string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/unocontries.js");
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