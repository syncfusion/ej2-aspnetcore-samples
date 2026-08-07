using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;
namespace EJ2CoreSampleBrowser.Pages.Schedule;

public class MultipleDrag : PageModel
{
    public List<ResourceDataSourceModel> categories = new List<ResourceDataSourceModel>();
    public void OnGet()
    {
        categories.Add(new ResourceDataSourceModel { text = "Nancy", id = 1, color = "#df5286" });
        categories.Add(new ResourceDataSourceModel { text = "Steven", id = 2, color = "#7fa900" });
        categories.Add(new ResourceDataSourceModel { text = "Robert", id = 3, color = "#ea7a57" });
        categories.Add(new ResourceDataSourceModel { text = "Smith", id = 4, color = "#5978ee" });
        categories.Add(new ResourceDataSourceModel { text = "Michael", id = 5, color = "#df5286" });
        categories.Add(new ResourceDataSourceModel { text = "Root", id = 6, color = "#00bdae" });
    }
}