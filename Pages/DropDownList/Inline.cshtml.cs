#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.DropDownList;

public class Inline : PageModel
{
    public List<InlineEmployees> Emp = new List<InlineEmployees>();
    public void OnGet()
    {
        Emp.Add(new InlineEmployees { Name = "Andrew", Eimg = "7" });
        Emp.Add(new InlineEmployees { Name = "Anne", Eimg = "1" });
        Emp.Add(new InlineEmployees { Name = "Janet", Eimg = "3" });
        Emp.Add(new InlineEmployees { Name = "Laura", Eimg = "2" });
        Emp.Add(new InlineEmployees { Name = "Michael", Eimg = "9" });
        Emp.Add(new InlineEmployees { Name = "Nancy", Eimg = "4" });
        Emp.Add(new InlineEmployees { Name = "Robert", Eimg = "8" });
        Emp.Add(new InlineEmployees { Name = "Steven", Eimg = "10" });
    }
}
public class InlineEmployees
{
    public string Name { get; set; }
    public string Eimg { get; set; }
}