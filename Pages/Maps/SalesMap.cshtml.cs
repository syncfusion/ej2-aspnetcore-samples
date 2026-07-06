using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
namespace EJ2CoreSampleBrowser.Pages.Maps;

public class SalesMap : PageModel
{
    public object SaleWorldMap()
    {
        string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/WorldMap.json");
        return JsonConvert.DeserializeObject(allText);
    }
    public object productWorth()
    {
        string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/ProductWorth.js");
        return JsonConvert.DeserializeObject(allText);
    }
    public void OnGet()
    {
        
    }
}