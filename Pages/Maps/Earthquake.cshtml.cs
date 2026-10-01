using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
namespace EJ2CoreSampleBrowser.Pages.Maps;

public class Earthquake : PageModel
{
    public object GetAsia()
    {
        string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/asia.json");
        return JsonConvert.DeserializeObject(allText);
    }
    public void OnGet()
    {
        
    }
}