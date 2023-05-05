#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Navigations;


namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class ToolbarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DefaultFunctionalities()
        {
            List<ToolbarItem> items = new List<ToolbarItem>();
            {
                items.Add(new ToolbarItem { PrefixIcon = "e-icons e-cut", TooltipText = "Cut", Text = "Cut" });
                items.Add(new ToolbarItem { PrefixIcon = "e-icons e-copy", TooltipText = "Copy", Text = "Copy" });
                items.Add(new ToolbarItem { PrefixIcon = "e-icons e-paste", TooltipText = "Paste", Text = "Paste" });

                items.Add(new ToolbarItem { PrefixIcon = "e-icons e-bold", TooltipText = "Bold", Text = "Bold" });
                items.Add(new ToolbarItem { PrefixIcon = "e-icons e-underline", TooltipText = "Underline", Text = "Underline" });
                items.Add(new ToolbarItem { PrefixIcon = "e-icons e-italic", TooltipText = "Italic", Text = "Italic" });

                items.Add(new ToolbarItem { PrefixIcon = "e-icons e-align-left", TooltipText = "Align-Left", Text = "Align-Left" });
                items.Add(new ToolbarItem { PrefixIcon = "e-icons e-align-right", TooltipText = "Align-Right", Text = "Align-Right" });
                items.Add(new ToolbarItem { PrefixIcon = "e-icons e-align-center", TooltipText = "Align-Center", Text = "Align-Center" });
                items.Add(new ToolbarItem { PrefixIcon = "e-icons e-justify", TooltipText = "Align-Justify", Text = "Align-Justify" });

                items.Add(new ToolbarItem { PrefixIcon = "e-icons e-list-unordered", TooltipText = "Bullets", Text = "Bullets" });
                items.Add(new ToolbarItem { PrefixIcon = "e-icons e-list-ordered", TooltipText = "Numbering", Text = "Numbering" });

                items.Add(new ToolbarItem { PrefixIcon = "e-icons e-undo", TooltipText = "Undo", Text = "Undo" });
                items.Add(new ToolbarItem { PrefixIcon = "e-icons e-redo", TooltipText = "Redo", Text = "Redo" });

                items.Add(new ToolbarItem { PrefixIcon = "e-icons e-increase-indent", TooltipText = "Text Indent", Text = "Text Indent" });
                items.Add(new ToolbarItem { PrefixIcon = "e-icons e-decrease-indent", TooltipText = "Text Outdent", Text = "Text Outdent" });
                items.Add(new ToolbarItem { PrefixIcon = "e-icons e-erase", TooltipText = "Clear", Text = "Clear" });              
            }

            ViewBag.items = items;

            return View();
        }
    }
}
