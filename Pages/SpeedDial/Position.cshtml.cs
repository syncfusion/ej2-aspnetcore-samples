using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.EJ2.Buttons;
namespace EJ2CoreSampleBrowser.Pages.SpeedDial;

public class PositionModel : PageModel
{
    public List<SpeedDialItem> Items { get; set; }
    
    public void OnGet()
    {
        Items = new List<SpeedDialItem>();
        Items.Add(new SpeedDialItem
        {
            Title="Image",
            IconCss = "speeddial-icons speeddial-icon-image"
        });
        Items.Add(new SpeedDialItem
        {
            Title="Audio",
            IconCss = "speeddial-icons speeddial-icon-audio"
        });
        Items.Add(new SpeedDialItem
        {
            Title="Video",
            IconCss = "speeddial-icons speeddial-icon-video"
        });
    }
}