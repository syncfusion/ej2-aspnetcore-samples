#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using EJ2CoreSampleBrowser.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.EJ2.BlockEditor;

namespace EJ2CoreSampleBrowser_NET9.Pages.BlockEditor
{
    public class APIModel : PageModel
    {
        public List<Block> BlockDataAPI { get; set; }
        public void OnGet()
        {
            BlockDataAPI = new BlockData().GetBlockDataAPI();
        }
    }
}
