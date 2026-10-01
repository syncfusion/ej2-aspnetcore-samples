using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
namespace EJ2CoreSampleBrowser.Pages.TreeMap;

public class DataLabel : PageModel
{
    public object getDataSource(string filename)
    {
        string allText = System.IO.File.ReadAllText("./wwwroot/scripts/TreeMapData/" + filename + ".js");
        return JsonConvert.DeserializeObject(allText);
    }
    public void OnGet()
    {
        
    }
}