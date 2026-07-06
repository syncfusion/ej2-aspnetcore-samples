using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
namespace EJ2CoreSampleBrowser.Pages.Maps;

public class MultiLayer : PageModel
{
    public object getusMap()
    {
        string usmap = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/usMap.js");
        return JsonConvert.DeserializeObject(usmap);
    }
    public object TexasMap()
    {
        string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/texas.json");
        return JsonConvert.DeserializeObject(allText);
    }
    public object CaliforniaMap()
    {
        string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/california.json");
        return JsonConvert.DeserializeObject(allText);
    }
    public void OnGet()
    {
        
    }
}