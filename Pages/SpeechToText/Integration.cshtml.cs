using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;
namespace EJ2CoreSampleBrowser.Pages.SpeechToText;
    public class IntegrationModel : PageModel
    {
    public List<ToolbarItemModel> Items { get; set; } = new List<ToolbarItemModel>();

    public void OnGet()
         {
        Items.Add(new ToolbarItemModel { align = "Right", iconCss = "e-icons e-refresh" });
         }
    }
public class ToolbarItemModel
{
    public string align { get; set; }

    public string iconCss { get; set; }
}