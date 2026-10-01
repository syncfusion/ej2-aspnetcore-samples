using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
namespace EJ2CoreSampleBrowser.Pages.Maps;

public class MapPie : PageModel
{
    public object GetWroldContinentMap()
    {
        string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/world_continent.js");
        return JsonConvert.DeserializeObject(allText);
    }
    public void OnGet()
    {
        
    }
}