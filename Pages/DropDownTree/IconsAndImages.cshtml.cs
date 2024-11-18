#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.DropDownTree;

public class IconsAndImages : PageModel
{
    public List<ParentItem> Parent = new List<ParentItem>();
    public void OnGet()
    {
        List<ChildItem> Child1 = new List<ChildItem>();
        List<ChildItem> Child2 = new List<ChildItem>();
        List<ChildItem> Child3 = new List<ChildItem>();
        List<ChildItem> Child4 = new List<ChildItem>();
        List<ChildItem> Child5 = new List<ChildItem>();
        List<SubChild> SubChild = new List<SubChild>();

        Parent.Add(new ParentItem { NodeId = "01", NodeText = "Music", Icon = "folder", Child = Child1, });
        Child1.Add(new ChildItem { NodeId = "01-01", NodeText = "Gouttes.mp3", Icon = "audio" });

        Parent.Add(new ParentItem { NodeId = "02", NodeText = "Videos", Icon = "folder", Child = Child2, });
        Child2.Add(new ChildItem { NodeId = "02-01", NodeText = "Naturals.mp4", Icon = "video" });
        Child2.Add(new ChildItem { NodeId = "02-02", NodeText = "Wild.mpeg", Icon = "video" });

        Parent.Add(new ParentItem { NodeId = "03", NodeText = "Documents", Icon = "folder", Child = Child3, });
        Child3.Add(new ChildItem { NodeId = "03-01", NodeText = "Environment Pollution.docx", Icon = "docx" });
        Child3.Add(new ChildItem { NodeId = "03-02", NodeText = "Global Water, Sanitation, & Hygiene.docx", Icon = "docx" });
        Child3.Add(new ChildItem { NodeId = "03-03", NodeText = "Global Warming.ppt", Icon = "ppt" });
        Child3.Add(new ChildItem { NodeId = "03-04", NodeText = "Social Network.pdf", Icon = "pdf" });
        Child3.Add(new ChildItem { NodeId = "03-05", NodeText = "Youth Empowerment.pdf", Icon = "pdf" });

        Parent.Add(new ParentItem { NodeId = "04", NodeText = "Pictures", Icon = "folder", Child = Child4, Expanded = true, });
        Child4.Add(new ChildItem { NodeId = "04-01", NodeText = "Camera Roll", Icon = "folder", Child = SubChild, Expanded = true });
        SubChild.Add(new SubChild { NodeId = "04-01-01", NodeText = "WIN_20160726_094117.JPG", Image = "../images/dropdown-tree/2.png" });
        SubChild.Add(new SubChild { NodeId = "04-01-02", NodeText = "WIN_20160726_094118.JPG", Image = "../images/dropdown-tree/9.png" });
        Child4.Add(new ChildItem { NodeId = "04-02", NodeText = "Wind.jpg", Icon = "images" });
        Child4.Add(new ChildItem { NodeId = "04-03", NodeText = "Stone.jpg", Icon = "images" });

        Parent.Add(new ParentItem { NodeId = "05", NodeText = "Downloads", Icon = "folder", Child = Child5, });
        Child5.Add(new ChildItem { NodeId = "05-01", NodeText = "UI-Guide.pdf", Icon = "pdf" });
        Child5.Add(new ChildItem { NodeId = "05-02", NodeText = "Tutorials.zip", Icon = "zip" });
        Child5.Add(new ChildItem { NodeId = "05-03", NodeText = "Game.exe", Icon = "exe" });
        Child5.Add(new ChildItem { NodeId = "05-04", NodeText = "TypeScript.7z", Icon = "zip" });
    }
}

public class ParentItem
{
    public string NodeId;
    public string NodeText;
    public string Icon;
    public string Image;
    public bool Expanded;
    public List<ChildItem> Child;
}
public class ChildItem
{
    public string NodeId;
    public string NodeText;
    public string Icon;
    public string Image;
    public bool Expanded;
    public List<SubChild> Child;
}
public class SubChild
{
    public string NodeId;
    public string NodeText;
    public string Icon;
    public string Image;
    public bool Expanded;
}