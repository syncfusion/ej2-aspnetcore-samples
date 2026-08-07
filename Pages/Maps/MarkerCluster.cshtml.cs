using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
namespace EJ2CoreSampleBrowser.Pages.Maps;

public class MarkerCluster : PageModel
{
    public object WorldMap()
    {
        string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/WorldMap.json");
        return JsonConvert.DeserializeObject(allText);
    }
    public object Clustersettings()
    {
        string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/markercluster.js");
        return JsonConvert.DeserializeObject(allText);
    }
    public void OnGet()
    {
        
    }
}