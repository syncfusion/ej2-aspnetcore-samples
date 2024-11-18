#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
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