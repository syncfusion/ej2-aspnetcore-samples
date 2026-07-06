using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.EJ2.Buttons;
namespace EJ2CoreSampleBrowser.Pages.SpeedDial;

public class TemplateModel : PageModel
{
    public List<SpeedDialItem> Items { get; set; }
    
    public void OnGet()
    {
        Items = new List<SpeedDialItem>();
        Items.Add(new SpeedDialItem
        {
            Text = "Cut",
            IconCss = "speeddial-icons speeddial-icon-cut"
        });
        Items.Add(new SpeedDialItem
        {
            Text = "Copy",
            IconCss = "speeddial-icons speeddial-icon-copy"
        });
        Items.Add(new SpeedDialItem
        {
            Text = "Paste",
            IconCss = "speeddial-icons speeddial-icon-paste"
        });
        Items.Add(new SpeedDialItem
        {
            Text = "Delete",
            IconCss = "speeddial-icons speeddial-icon-delete"
        });
    }
}