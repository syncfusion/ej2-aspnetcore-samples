using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Sidebar;

public class API : PageModel
{
    public Dictionary<string, object> HtmlAttribute = new Dictionary<string, object>()
        {   {"class", "default-sidebar" } };

    public List<object> dataList = new List<object>();
    public void OnGet()
    {
        dataList.Add(new { Type = "Over", value = "Over" });
        dataList.Add(new { Type = "Push", value = "Push" });
        dataList.Add(new { Type = "Slide", value = "Slide" });
        dataList.Add(new { Type = "Auto", value = "Auto" });
    }
}