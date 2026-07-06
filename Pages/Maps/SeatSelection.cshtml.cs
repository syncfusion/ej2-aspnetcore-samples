using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
namespace EJ2CoreSampleBrowser.Pages.Maps;

public class SeatSelection : PageModel
{
    public object GetSeatData()
    {
        string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/seatdata.json");
        return JsonConvert.DeserializeObject(allText);
    }
    public void OnGet()
    {
        
    }
}