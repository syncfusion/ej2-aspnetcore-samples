using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;
namespace EJ2CoreSampleBrowser.Pages.Schedule;

public class GroupByChild : PageModel
{
    public List<ResourceDataSourceModel> projects = new List<ResourceDataSourceModel>();
    public List<ResourceDataSourceModel> categories = new List<ResourceDataSourceModel>();
    public void OnGet()
    {
        projects.Add(new ResourceDataSourceModel { text = "PROJECT 1", id = 1, color = "#cb6bb2" });
        projects.Add(new ResourceDataSourceModel { text = "PROJECT 2", id = 2, color = "#56ca85" });
        
        categories.Add(new ResourceDataSourceModel { text = "Development", id = 1, color = "#df5286" });
        categories.Add(new ResourceDataSourceModel { text = "Testing", id = 2, color = "#7fa900" });
    }
}