using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
namespace EJ2CoreSampleBrowser.Pages.Maps;

public class Selection : PageModel
{
    public object getusMap()
    {
        string usmap = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/usMap.js");
        return JsonConvert.DeserializeObject(usmap);
    }
    public object GetElectiondata()
    {
        string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/electiondata.js");
        return JsonConvert.DeserializeObject(allText);
    }
    public void OnGet()
    {
        
    }
}