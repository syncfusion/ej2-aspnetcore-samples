#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
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