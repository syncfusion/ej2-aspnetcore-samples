#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Diagram;
using Syncfusion.EJ2.Diagrams;

public class ComplexHierarchicalLayoutModel : PageModel
{
    public List<ComplexHierarchicalDataDetails> Nodes { get; set; }
    public DiagramMargin marginValue { get; set; }
    public void OnGet()
    {
        Nodes = ComplexHierarchicalDataDetails.GetAllRecords();
        
        marginValue = new DiagramMargin() { Left = 10, Top = 50 };
        
    }
    
}
public class ComplexHierarchicalDataDetails
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public string[] ReportingPersons { get; set; }
        public string Border { get; set; }

        public ComplexHierarchicalDataDetails(string name, string color, string[] reportingPersons, string border)
        {
            this.Name = name;
            this.Color = color;
            this.ReportingPersons = reportingPersons;
            this.Border = border;
        }

        public static List<ComplexHierarchicalDataDetails> GetAllRecords()
        {
            List<ComplexHierarchicalDataDetails> multiParents = new List<ComplexHierarchicalDataDetails>();

            multiParents.Add(new ComplexHierarchicalDataDetails("node11", "#e7704c", null, "#c15433"));

            multiParents.Add(new ComplexHierarchicalDataDetails("node12", "#efd46e", new string[] { "node114" }, "#d6b123"));
            multiParents.Add(new ComplexHierarchicalDataDetails("node13", "#58b087", new string[] { "node12" }, "#16955e"));
            multiParents.Add(new ComplexHierarchicalDataDetails("node14", "#58b087", new string[] { "node12" }, "#16955e"));
            multiParents.Add(new ComplexHierarchicalDataDetails("node15", "#58b087", new string[] { "node12" }, "#16955e"));
            multiParents.Add(new ComplexHierarchicalDataDetails("node116", "#58b087", new string[] { "node22", "node12" }, "#d3722e"));
            multiParents.Add(new ComplexHierarchicalDataDetails("node16", "#14ad85", new string[] { }, ""));

            multiParents.Add(new ComplexHierarchicalDataDetails("node17", "#659be5", new string[] { "node13", "node14", "node15" }, "#3a6eb5"));
            multiParents.Add(new ComplexHierarchicalDataDetails("node18", "#14ad85", new string[] { }, ""));
            multiParents.Add(new ComplexHierarchicalDataDetails("node19", "#8dbe6c", new string[] { "node16", "node17", "node18" }, "#489911"));

            multiParents.Add(new ComplexHierarchicalDataDetails("node110", "#8dbe6c", new string[] { "node16", "node17", "node18" }, "#489911"));
            multiParents.Add(new ComplexHierarchicalDataDetails("node111", "#8dbe6c", new string[] { "node16", "node17", "node18", "node116" }, "#489911"));

            multiParents.Add(new ComplexHierarchicalDataDetails("node21", "#e7704c", null, "#c15433"));

            multiParents.Add(new ComplexHierarchicalDataDetails("node22", "#efd46e", new string[] { "node114" }, "#d6b123"));
            multiParents.Add(new ComplexHierarchicalDataDetails("node23", "#58b087", new string[] { "node22" }, "#16955e"));
            multiParents.Add(new ComplexHierarchicalDataDetails("node24", "#58b087", new string[] { "node22" }, "#16955e"));
            multiParents.Add(new ComplexHierarchicalDataDetails("node25", "#58b087", new string[] { "node22" }, "#16955e"));

            multiParents.Add(new ComplexHierarchicalDataDetails("node26", "#14ad85", new string[] { }, "#14ad85"));

            multiParents.Add(new ComplexHierarchicalDataDetails("node27", "#659be5", new string[] { "node23", "node24", "node25" }, "#3a6eb5"));

            multiParents.Add(new ComplexHierarchicalDataDetails("node28", "#14ad85", new string[] { }, ""));

            multiParents.Add(new ComplexHierarchicalDataDetails("node29", "#8dbe6c", new string[] { "node26", "node27", "node28", "node116" }, "#489911"));
            multiParents.Add(new ComplexHierarchicalDataDetails("node210", "#8dbe6c", new string[] { "node26", "node27", "node28" }, "#489911"));
            multiParents.Add(new ComplexHierarchicalDataDetails("node211", "#8dbe6c", new string[] { "node26", "node27", "node28" }, "#489911"));

            multiParents.Add(new ComplexHierarchicalDataDetails("node31", "#e7704c", null, "#c15433"));

            multiParents.Add(new ComplexHierarchicalDataDetails("node114", "#f3904a", new string[] { "node11", "node21", "node31" }, "#d3722e"));

            return multiParents;
        }
    }