#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Gantt
{
    public class SelectionModel : PageModel
    {
        public class DropDownListData1
        {
            public string Id { get; set; }
            public string Type { get; set; }

            public static List<DropDownListData1> SelectionModeList ()
            {
                List<DropDownListData1> Data = new List<DropDownListData1>();
                Data.Add(new DropDownListData1 { Id = "Row", Type = "Row" });
                Data.Add(new DropDownListData1 { Id = "Cell", Type = "Cell" });
                return Data;
            }

            public static List<DropDownListData1> SelectionTypeList ()
            {
                List<DropDownListData1> Data = new List<DropDownListData1>();
                Data.Add(new DropDownListData1 { Id = "Single", Type = "Single" });
                Data.Add(new DropDownListData1 { Id = "Multiple", Type = "Multiple" });
                return Data;
            }
        }
        public class DropDownListData2
        {
            public bool Id { get; set; }
            public string Type { get; set; }

            public static List<DropDownListData2> ToggleList ()
            {
                List<DropDownListData2> Data = new List<DropDownListData2>();
                Data.Add(new DropDownListData2 { Id = true, Type = "Enable" });
                Data.Add(new DropDownListData2 { Id = false, Type = "Disable" });
                return Data;
            }
        }
    }
}
