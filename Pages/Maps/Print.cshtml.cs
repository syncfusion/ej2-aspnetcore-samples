using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
namespace EJ2CoreSampleBrowser.Pages.Maps;

public class Print : PageModel
{
    public object getusMap()
    {
        string usmap = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/usMap.js");
        return JsonConvert.DeserializeObject(usmap);
    }
    public object getPopulationDataSource()
    {
        string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/usPopulation.js");
        return JsonConvert.DeserializeObject(allText);
    }
    public void OnGet()
    {
        
    }
}