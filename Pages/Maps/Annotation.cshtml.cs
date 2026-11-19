using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
namespace EJ2CoreSampleBrowser.Pages.Maps;

public class Annotation : PageModel
{
    public object GetAfricaSingle()
    {
        string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/africasingle.js");
        return JsonConvert.DeserializeObject(allText);
    }
    public void OnGet()
    {
        
    }
}