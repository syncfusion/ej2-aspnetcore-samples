#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using EJ2CoreSampleBrowser.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.TreeGrid
{
    public class ContextMenuModel : PageModel
    {
        public string[] ContextItems { get; set; }

        public void OnGet()
        {
            ContextItems = new string[] {"SortAscending", "SortDescending",
                "Edit", "Delete", "Save", "Cancel",
                "PdfExport", "ExcelExport", "CsvExport", "FirstPage", "PrevPage",
                "LastPage", "NextPage", "Indent", "Outdent" };

        }
        
    }
}