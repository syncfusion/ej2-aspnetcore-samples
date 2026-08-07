using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Schedule;

public class ContextMenu : PageModel
{
    public List<object> menuItems = new List<object>();
    public void OnGet()
    {
        menuItems.Add(new
        {
            text = "New Event",
            iconCss = "e-icons e-plus",
            id = "Add"
        });
        menuItems.Add(new
        {
            text = "New Recurring Event",
            iconCss = "e-icons e-repeat",
            id = "AddRecurrence"
        });
        menuItems.Add(new
        {
            text = "Today",
            iconCss = "e-icons e-timeline-today",
            id = "Today"
        });
        menuItems.Add(new
        {
            text = "Edit Event",
            iconCss = "e-icons e-edit",
            id = "Save"
        });
        menuItems.Add(new
        {
            text = "Edit Event",
            id = "EditRecurrenceEvent",
            iconCss = "e-icons e-edit",
            items = new List<object>()
            {
                new { text = "Edit Occurrence", id = "EditOccurrence" },
                new { text = "Edit Series", id = "EditSeries" }
            }
        });
        menuItems.Add(new
        {
            text = "Delete Event",
            iconCss = "e-icons e-trash",
            id = "Delete"
        });
        menuItems.Add(new
        {
            text = "Delete Event",
            id = "DeleteRecurrenceEvent",
            iconCss = "e-icons e-trash",
            items = new List<object>()
            {
                new { text = "Delete Occurrence", id = "DeleteOccurrence" },
                new { text = "Delete Series", id = "DeleteSeries" }
            }
        });
    }
}