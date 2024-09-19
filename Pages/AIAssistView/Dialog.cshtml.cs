#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser_NET8.Pages.AIAssistView
{
    public class DialogModel : PageModel
    {
        public List<ToolbarItemModel> DialogItems = new List<ToolbarItemModel>();
        public void OnGet()
        {
            DialogItems.Add(new ToolbarItemModel { align = "Right", iconCss = "e-icons e-close" });
        }

        public class ToolbarItemModel
        {
            public string align { get; set; }
            public string iconCss { get; set; }
        }
    }
}
