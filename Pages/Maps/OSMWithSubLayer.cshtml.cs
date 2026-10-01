using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
namespace EJ2CoreSampleBrowser.Pages.Maps;

public class OSMWithSubLayer : PageModel
{
    public object GetAfrica()
    {
        string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/africa.js");
        return JsonConvert.DeserializeObject(allText);
    }
    public void OnGet()
    {
        
    }
}