using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
namespace EJ2CoreSampleBrowser.Pages.Maps;

public class ColorMapping : PageModel
{
    public object getusMap()
    {
        string usmap = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/usMap.js");
        return JsonConvert.DeserializeObject(usmap);
    }
    public object GetColorMappingData()
    {
        string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/ColorMapping.json");
        return JsonConvert.DeserializeObject(allText);
    }
    public void OnGet()
    {
        
    }
}