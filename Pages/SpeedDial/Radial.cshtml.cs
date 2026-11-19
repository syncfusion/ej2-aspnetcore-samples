using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.EJ2.Buttons;
namespace EJ2CoreSampleBrowser.Pages.SpeedDial;

public class RadialModel : PageModel
{
    public List<SpeedDialItem> Items { get; set; }
    
    public void OnGet()
    {
        Items = new List<SpeedDialItem>();
        Items.Add(new SpeedDialItem
        {
            Title="Cut",
            IconCss = "speeddial-icons speeddial-icon-cut"
        });
        Items.Add(new SpeedDialItem
        {
            Title="Copy",
            IconCss = "speeddial-icons speeddial-icon-copy"
        });
        Items.Add(new SpeedDialItem
        {
            Title="Paste",
            IconCss = "speeddial-icons speeddial-icon-paste"
        });
        Items.Add(new SpeedDialItem
        {
            Title="Delete",
            IconCss = "speeddial-icons speeddial-icon-delete"
        });
    }
}