using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;
namespace EJ2CoreSampleBrowser.Pages.Schedule;

public class GroupEditing : PageModel
{
    public List<ResourceDataSourceModel> conferences = new List<ResourceDataSourceModel>();
    public void OnGet()
    {
        conferences.Add(new ResourceDataSourceModel { text = "Margaret", id = 1, color = "#1aaa55" });
        conferences.Add(new ResourceDataSourceModel { text = "Robert", id = 2, color = "#357cd2" });
        conferences.Add(new ResourceDataSourceModel { text = "Laura", id = 3, color = "#7fa900" });
    }
}