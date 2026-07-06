using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Schedule;

public class AddRemoveResources : PageModel
{
    public List<CalendarResource> calendarCollections = new List<CalendarResource>();
    public void OnGet()
    {
        calendarCollections.Add(new CalendarResource { CalendarName = "My Calendar", CalendarId = 1, CalendarColor = "#c43081" });
    }
}
public class CalendarResource
{
    public string CalendarName { set; get; }
    public int CalendarId { set; get; }
    public string CalendarColor { set; get; }
}