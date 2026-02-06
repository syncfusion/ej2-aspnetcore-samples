#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using EJ2CoreSampleBrowser.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.EJ2.BlockEditor;
using static EJ2CoreSampleBrowser.Models.BlockData;

namespace EJ2CoreSampleBrowser_NET9.Pages.BlockEditor
{
    public class OverviewModel : PageModel
    {
        public List<BlockModel> BlockDataOverview { get; set; }
        public List<UserModel> MentionUsers { get; set; }
        public string[] InlineToolbarItems { get; set; }
        public void OnGet()
        {
            BlockDataOverview = new BlockData().GetBlockDataOverview();
            MentionUsers = new BlockData().GetUniqueMentionUsers();
            InlineToolbarItems = new string[] { "Bold", "Italic", "Underline", "StrikeThrough", "Uppercase", "Lowercase", "Subscript", "Superscript", "Color", "Backgroundcolor" };
        }
    }
}
