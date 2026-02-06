#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Avatar;

public class Listview : PageModel
{
    public List<object> data = new List<object>();
    public void OnGet()
    {
        data.Add(new { id = "s_01", text = "Robert", avatar = "", pic = "pic04" });
        data.Add(new { id = "s_02", text = "Nancy", avatar = "N", pic = "" });
        data.Add(new { id = "s_05", text = "John", pic = "pic01", avatar = "" });
        data.Add(new { id = "s_03", text = "Andrew", avatar = "A", pic = "" });
        data.Add(new { id = "s_06", text = "Michael", pic = "pic02", avatar = "" });
        data.Add(new { id = "s_07", text = "Steven", pic = "pic03", avatar = "" });
        data.Add(new { id = "s_08", text = "Margaret", avatar = "M", pic = "" });
    }
}