using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace EJ2CoreSampleBrowser.Pages.SparkLine;

public class SparkGridModel : PageModel
{
    public object DataSource { get; set; }
    
    public void OnGet()
    {
        DataSource = this.getDataSource("OrderData");
    }
    public object getDataSource(string filename)
    {
        string allText = System.IO.File.ReadAllText("./wwwroot/scripts/SparkLine/" + filename + ".js");
        return JsonConvert.DeserializeObject(allText);
    }
}
