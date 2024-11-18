#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.EJ2.Navigations;

namespace EJ2CoreSampleBrowser.Pages.Toolbar
{
    public class DefaultFunctionalitiesModel : PageModel
    {
        public List<ToolbarItem> Items = new List<ToolbarItem>();
        public void OnGet()
        {
            Items.Add(new ToolbarItem { PrefixIcon = "e-icons e-cut", TooltipText = "Cut", Text = "Cut" });
            Items.Add(new ToolbarItem { PrefixIcon = "e-icons e-copy", TooltipText = "Copy", Text = "Copy" });
            Items.Add(new ToolbarItem { PrefixIcon = "e-icons e-paste", TooltipText = "Paste", Text = "Paste" });

            Items.Add(new ToolbarItem { PrefixIcon = "e-icons e-bold", TooltipText = "Bold", Text = "Bold" });
            Items.Add(new ToolbarItem { PrefixIcon = "e-icons e-underline", TooltipText = "Underline", Text = "Underline" });
            Items.Add(new ToolbarItem { PrefixIcon = "e-icons e-italic", TooltipText = "Italic", Text = "Italic" });

            Items.Add(new ToolbarItem { PrefixIcon = "e-icons e-align-left", TooltipText = "Align-Left", Text = "Align-Left" });
            Items.Add(new ToolbarItem { PrefixIcon = "e-icons e-align-right", TooltipText = "Align-Right", Text = "Align-Right" });
            Items.Add(new ToolbarItem { PrefixIcon = "e-icons e-align-center", TooltipText = "Align-Center", Text = "Align-Center" });
            Items.Add(new ToolbarItem { PrefixIcon = "e-icons e-justify", TooltipText = "Align-Justify", Text = "Align-Justify" });

            Items.Add(new ToolbarItem { PrefixIcon = "e-icons e-list-unordered", TooltipText = "Bullets", Text = "Bullets" });
            Items.Add(new ToolbarItem { PrefixIcon = "e-icons e-list-ordered", TooltipText = "Numbering", Text = "Numbering" });

            Items.Add(new ToolbarItem { PrefixIcon = "e-icons e-undo", TooltipText = "Undo", Text = "Undo" });
            Items.Add(new ToolbarItem { PrefixIcon = "e-icons e-redo", TooltipText = "Redo", Text = "Redo" });

            Items.Add(new ToolbarItem { PrefixIcon = "e-icons e-increase-indent", TooltipText = "Text Indent", Text = "Text Indent" });
            Items.Add(new ToolbarItem { PrefixIcon = "e-icons e-decrease-indent", TooltipText = "Text Outdent", Text = "Text Outdent" });
            Items.Add(new ToolbarItem { PrefixIcon = "e-icons e-erase", TooltipText = "Clear", Text = "Clear" });
        }
    }
}
