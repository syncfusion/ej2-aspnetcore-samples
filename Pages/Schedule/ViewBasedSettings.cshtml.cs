using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Schedule;

public class ViewBasedSettings : PageModel
{
    public List<ResourceFields> Resources = new List<ResourceFields>();
    public void OnGet()
    {
        Resources.Add(new ResourceFields { GroupText = "Group A", GroupId = 1, GroupColor = "#1aaa55" });
        Resources.Add(new ResourceFields { GroupText = "Group B", GroupId = 2, GroupColor = "#357cd2" });
    }
}
public class ResourceFields
{
    public string GroupText { set; get; }
    public int GroupId { set; get; }
    public string GroupColor { set; get; }
}