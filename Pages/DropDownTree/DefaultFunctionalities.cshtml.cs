#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.DropDownTree;

public class DefaultFunctionalities : PageModel
{
    public List<Parent> Parent = new List<Parent>();
    public void OnGet()
    {
        List<Child> Child1 = new List<Child>();
        List<SubChildren> SubChildren1 = new List<SubChildren>();
        Parent.Add(new Parent
        {
            NodeId = "01",
            NodeText = "Local Disk (C:)",
            Expanded = true,
            Childs = Child1,
        });
        Child1.Add(new Child { NodeId = "01-01", NodeText = "Program Files", Childs = SubChildren1 });
        SubChildren1.Add(new SubChildren { NodeId = "01-01-01", NodeText = "Windows NT" });
        SubChildren1.Add(new SubChildren { NodeId = "01-01-02", NodeText = "Windows Mail" });
        SubChildren1.Add(new SubChildren { NodeId = "01-01-03", NodeText = "Windows Photo Viewer" });
        List<SubChildren> SubChildren2 = new List<SubChildren>();
        Child1.Add(new Child { NodeId = "01-02", NodeText = "Users", Expanded = true, Childs = SubChildren2 });
        SubChildren2.Add(new SubChildren { NodeId = "01-02-01", NodeText = "Smith" });
        SubChildren2.Add(new SubChildren { NodeId = "01-02-02", NodeText = "Public" });
        SubChildren2.Add(new SubChildren { NodeId = "01-02-03", NodeText = "Admin" });
        List<SubChildren> SubChildren3 = new List<SubChildren>();
        Child1.Add(new Child { NodeId = "01-03", NodeText = "Windows", Childs = SubChildren3 });
        SubChildren3.Add(new SubChildren { NodeId = "01-03-01", NodeText = "Boot" });
        SubChildren3.Add(new SubChildren { NodeId = "01-03-02", NodeText = "FileManager" });
        SubChildren3.Add(new SubChildren { NodeId = "01-03-03", NodeText = "System32" });
        List<Child> Child2 = new List<Child>();
        Parent.Add(new Parent
        {
            NodeId = "02",
            NodeText = "Local Disk (D:)",
            Childs = Child2,
        });
        List<SubChildren> SubChildren4 = new List<SubChildren>();
        Child2.Add(new Child { NodeId = "02-01", NodeText = "Personals", Childs = SubChildren4 });
        SubChildren4.Add(new SubChildren { NodeId = "02-01-01", NodeText = "My photo.png" });
        SubChildren4.Add(new SubChildren { NodeId = "02-01-02", NodeText = "Rental document.docx" });
        SubChildren4.Add(new SubChildren { NodeId = "02-01-03", NodeText = "Pay slip.pdf" });
        List<SubChildren> SubChildren5 = new List<SubChildren>();
        Child2.Add(new Child { NodeId = "02-02", NodeText = "Projects", Childs = SubChildren5 });
        SubChildren5.Add(new SubChildren { NodeId = "02-02-01", NodeText = "ASP Application " });
        SubChildren5.Add(new SubChildren { NodeId = "02-02-02", NodeText = "TypeScript Application" });
        SubChildren5.Add(new SubChildren { NodeId = "02-02-03", NodeText = "React Application" });

        List<SubChildren> SubChildren6 = new List<SubChildren>();
        Child2.Add(new Child { NodeId = "02-02", NodeText = "Office", Childs = SubChildren6 });
        SubChildren6.Add(new SubChildren { NodeId = "02-03-01", NodeText = "Work details.docx " });
        SubChildren6.Add(new SubChildren { NodeId = "02-03-02", NodeText = "Weekly report.docx" });
        SubChildren6.Add(new SubChildren { NodeId = "02-03-03", NodeText = "Wish list.csv" });
        List<Child> Child3 = new List<Child>();
        Parent.Add(new Parent
        {
            NodeId = "03",
            NodeText = "Local Disk (E:)",
            Childs = Child3,
        });

        List<SubChildren> SubChildren7 = new List<SubChildren>();
        Child3.Add(new Child { NodeId = "03-01", NodeText = "Pictures", Childs = SubChildren7 });
        SubChildren7.Add(new SubChildren { NodeId = "03-01-01", NodeText = "Wind.jpg " });
        SubChildren7.Add(new SubChildren { NodeId = "03-01-02", NodeText = "Stone.jpg" });
        SubChildren7.Add(new SubChildren { NodeId = "03-01-03", NodeText = "Home.jpg" });

        List<SubChildren> SubChildren8 = new List<SubChildren>();
        Child3.Add(new Child { NodeId = "03-02", NodeText = "Documents", Icon = "docx", Childs = SubChildren8 });
        SubChildren8.Add(new SubChildren { NodeId = "03-02-01", NodeText = "Environment Pollution.docx " });
        SubChildren8.Add(new SubChildren { NodeId = "03-02-02", NodeText = "Global Warming.ppt" });
        SubChildren8.Add(new SubChildren { NodeId = "03-02-03", NodeText = "Social Network.pdf" });

        List<SubChildren> SubChildren9 = new List<SubChildren>();
        Child3.Add(new Child { NodeId = "03-03", NodeText = "Study Materials", Childs = SubChildren9 });
        SubChildren9.Add(new SubChildren { NodeId = "03-03-01", NodeText = "UI-Guide.pdf" });
        SubChildren9.Add(new SubChildren { NodeId = "03-03-02", NodeText = "Tutorials.zip" });
        SubChildren9.Add(new SubChildren { NodeId = "03-03-03", NodeText = "TypeScript.7z" });
    }
}

public class Parent
{
    public string NodeId;
    public string NodeText;
    public string Icon;
    public bool Expanded;
    public bool Selected;
    public List<Child> Childs;

}
public class Child
{
    public string NodeId;
    public string NodeText;
    public string Icon;
    public bool Expanded;
    public bool Selected;
    public List<SubChildren> Childs;

}

public class SubChildren
{
    public string NodeId;
    public string NodeText;
    public string Icon;
    public bool Expanded;
    public bool Selected;
}
