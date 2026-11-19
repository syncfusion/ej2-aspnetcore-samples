using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Button;

public class DropDownButtonModel : PageModel
{
    public List<object> Items { get; set; }
    public void OnGet()
    {
        Items = new List<object>();
        Items.Add(new
        {
            text = "Dashboard",
            iconCss = "e-ddb-icons e-dashboard"
        });
        Items.Add(new
        {
            text = "Notifications",
            iconCss = "e-ddb-icons e-notifications"
        });
        Items.Add(new
        {
            text = "User Settings",
            iconCss = "e-ddb-icons e-settings"
        });
        Items.Add(new
        {
            text = "Log Out",
            iconCss = "e-ddb-icons e-logout"
        });
    }
}