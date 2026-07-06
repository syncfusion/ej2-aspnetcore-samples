using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
namespace EJ2CoreSampleBrowser.Pages.Maps;

public class MapLabel : PageModel
{
    public object getusMap()
    {
        string usmap = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/usMap.js");
        return JsonConvert.DeserializeObject(usmap);
    }
    public void OnGet()
    {
        
    }
}