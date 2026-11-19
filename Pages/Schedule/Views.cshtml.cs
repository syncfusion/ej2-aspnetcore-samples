using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Schedule;

public class Views : PageModel
{
    public List<ViewData> view = new List<ViewData>();
    public void OnGet()
    {
        view.Add(new ViewData { Name = "Day", Value = "Day" });
        view.Add(new ViewData { Name = "Week", Value = "Week" });
        view.Add(new ViewData { Name = "Work Week", Value = "WorkWeek" });
        view.Add(new ViewData { Name = "Month", Value = "Month" });
    }
}

public class ViewData
{
    public string Name { get; set; }
    public string Value { get; set; }
}