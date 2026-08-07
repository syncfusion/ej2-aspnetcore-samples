using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Schedule
{
    public class Clipboard : PageModel
    {
        public List<object> menuItems = new List<object>();

        public void OnGet()
        {
            menuItems.Add(new
            {
                text = "Cut Event",
                iconCss = "e-icons e-cut",
                id = "Cut"
            });
            menuItems.Add(new
            {
                text = "Copy Event",
                iconCss = "e-icons e-copy",
                id = "Copy"
            });
            menuItems.Add(new
            {
                text = "Paste",
                iconCss = "e-icons e-paste",
                id = "Paste"
            });
        }
    }
}
