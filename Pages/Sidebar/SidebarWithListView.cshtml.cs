#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Sidebar;

public class SidebarWithListView : PageModel
{
    public Dictionary<string, object> HtmlAttribute = new Dictionary<string, object>()
        { { "class", "sidebar-list" } };

    public List<listDatas> List = new List<listDatas>();
    public void OnGet()
    {

        List.Add(new listDatas
        {
            Id = "1", Text = "JavaScript", Pic = "javascript",
            Description =
                "JavaScript (JS) is an interpreted computer programming language. It was originally implemented as part of web browsers so that client-side scripts could interact with the user, control the browser, communicate asynchronously, and alter the document content that was displayed. However, it has recently become common in both game development and the creation of desktop applications."
        });
        List.Add(new listDatas
        {
            Id = "2", Text = "TypeScript", Pic = "typescript",
            Description =
                "It is a typed superset of JavaScript that compiles to plain JavaScript. TypeScript is an open-source, object-oriented programing language. It contains all elements of JavaScript. It is a language designed for large-scale JavaScript application development, which can be executed on any browser, any Host, and any Operating System. TypeScript is a language as well as a set of tools. TypeScript is the ES6 version of JavaScript with some additional features."
        });
        List.Add(new listDatas
        {
            Id = "3", Text = "Angular", Pic = "angular",
            Description =
                "Angular is a platform and framework for building single-page client applications using HTML and TypeScript. Angular is written in TypeScript. It implements core and optional functionality as a set of TypeScript libraries that you import into your applications."
        });
        List.Add(new listDatas
        {
            Id = "4", Text = "React", Pic = "react",
            Description =
                "React is a declarative, efficient, and flexible JavaScript library for building user interfaces. It lets you compose complex UIs from small and isolated pieces of code called �components�. It can also render on the server using Node."
        });
        List.Add(new listDatas {Id="5", Text = "Vue", Pic = "vue", Description = "A progressive framework for building user interfaces. It is incrementally adoptable. The core library is focused on the view layer only and is easy to pick up and integrate with other libraries or existing projects. On the other hand, Vue is also perfectly capable of powering sophisticated Single-Page Applications when used in combination with modern tooling and supporting libraries." });
    }
}
public class listDatas
{
    public string Id { get; set; }
    public string Text { get; set; }
    public string Pic { get; set; }
    public string Description { get; set; }
}