#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser_NET8.Pages.Gantt
{
    public class GridLinesModel : PageModel
    {
        public class DropDownList
        {
            public string Id { get; set; }
            public string Type { get; set; }

            public static List<DropDownList> GridLinesData ()
            {
                List<DropDownList> Data = new List<DropDownList>();
                Data.Add(new DropDownList { Id = "Both", Type = "Both" });
                Data.Add(new DropDownList { Id = "Vertical", Type = "Vertical" });
                Data.Add(new DropDownList { Id = "Horizontal", Type = "Horizontal" });
                Data.Add(new DropDownList { Id = "None", Type = "None" });
                return Data;
            }
        }
    }
}
