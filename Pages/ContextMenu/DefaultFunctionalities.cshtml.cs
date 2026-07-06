using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.EJ2.Navigations;
namespace EJ2CoreSampleBrowser.Pages.ContextMenu;

public class DefaultFunctionalitiesModel : PageModel
{
    public List<ContextMenuItem> Menuitems { get; set; }
    public void OnGet()
    {
        Menuitems = new List<ContextMenuItem>() {
            new ContextMenuItem{ Text="Cut", IconCss="e-cm-icons e-cut" },
            new ContextMenuItem{ Text="Copy", IconCss="e-cm-icons e-copy" },
            new ContextMenuItem{ Text="Paste", IconCss="e-cm-icons e-paste",
                Items = new List<ContextMenuItem>(){
                    new ContextMenuItem{ Text = "Paste Text", IconCss = "e-cm-icons e-pastetext" },
                    new ContextMenuItem{ Text = "Paste Special", IconCss = "e-cm-icons e-pastespecial" }
                }
            },
            new ContextMenuItem{ Separator= true},
            new ContextMenuItem{ Text = "Link", IconCss = "e-cm-icons e-link"},
            new ContextMenuItem{ Text = "New Comment", IconCss = "e-cm-icons e-comment"}
        };
    }
}