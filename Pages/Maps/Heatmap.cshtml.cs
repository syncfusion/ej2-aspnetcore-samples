using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
namespace EJ2CoreSampleBrowser.Pages.Maps;

public class Heatmap : PageModel
{
    public object GetIndiaData()
    {
        string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/india.json");
        return JsonConvert.DeserializeObject(allText);
    }
    public object GetIndianPopulation()
    {
        string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/indianpopulation.js");
        return JsonConvert.DeserializeObject(allText);
    }
    public void OnGet()
    {
        
    }
}