#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.ListBox;

public class TemplateModel : PageModel
{
    public List<object> Data { get; set; }
    public void OnGet()
    {
        Data = new List<object>();
        Data.Add(new { text = "JavaScript", pic = "javascript", description = "It is a lightweight interpreted or JIT-compil ed programming language." });
        Data.Add(new { text = "TypeScript", pic = "typescript", description = "It is a typed superset of JavaScript that compil es to plain JavaScript." });
        Data.Add(new { text = "Angular", pic = "angular", description = "It is a TypeScript-based open-source web application framework." });
        Data.Add(new { text = "React", pic = "react", description = "A JavaScript library for building user interfaces. It can also render on the server using Node."});
        Data.Add(new { text = "Vue", pic = "vue", description = "A progressive framework for building user interfaces. it is incrementally adoptable." });
    }
}