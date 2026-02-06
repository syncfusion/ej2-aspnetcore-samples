#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Diagram;

public class HierarchicalTreeModel : PageModel
{
    public List<HierarchicalDetails> Nodes { get; set; }
    public void OnGet()
    {
        Nodes = HierarchicalDetails.GetAllRecords();
    }
}
public class HierarchicalDetails
{
    public string Name { get; set; }
    public string Category { get; set; }
    public string FillColor { get; set; }

    public HierarchicalDetails(string name, string category, string fillcolor)
    {
        this.Name = name;
        this.Category = category;
        this.FillColor = fillcolor;
    }

    public static List<HierarchicalDetails> GetAllRecords()
    {
        List<HierarchicalDetails> hierarchicaldetails = new List<HierarchicalDetails>();

        hierarchicaldetails.Add(new HierarchicalDetails("Diagram", "", "#916DAF"));
        hierarchicaldetails.Add(new HierarchicalDetails("Layout", "Diagram", "#916DAF"));
        hierarchicaldetails.Add(new HierarchicalDetails("Tree Layout", "Layout", "#916DAF"));
        hierarchicaldetails.Add(new HierarchicalDetails("Organizational Chart", "Layout", "#916DAF"));
        hierarchicaldetails.Add(new HierarchicalDetails("Hierarchical Tree", "Tree Layout", "#916DAF"));
        hierarchicaldetails.Add(new HierarchicalDetails("Radial Tree", "Tree Layout", "#916DAF"));
        hierarchicaldetails.Add(new HierarchicalDetails("Mind Map", "Hierarchical Tree", "#916DAF"));
        hierarchicaldetails.Add(new HierarchicalDetails("Family Tree", "Hierarchical Tree", "#916DAF"));
        hierarchicaldetails.Add(new HierarchicalDetails("Management", "Organizational Chart", "#916DAF"));
        hierarchicaldetails.Add(new HierarchicalDetails("Human Resource", "Management", "#916DAF"));
        hierarchicaldetails.Add(new HierarchicalDetails("University", "Management", "#916DAF"));
        hierarchicaldetails.Add(new HierarchicalDetails("Business", "Management", "#916DAF"));

        return hierarchicaldetails;
    }
}