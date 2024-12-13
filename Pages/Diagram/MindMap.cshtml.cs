#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.EJ2.Diagrams;

namespace EJ2CoreSampleBrowser.Pages.Diagram;

public class MindMapModel : PageModel
{
    public List<MindMapDetails> Nodes { get; set; }
    public DiagramSelector selectedItems { get; set; }
    public void OnGet()
    {
        List<MindMapDetails> mindmapDetails = new List<MindMapDetails>();

            mindmapDetails.Add(new MindMapDetails("1", "Creativity", "", "Root", "red"));
            mindmapDetails.Add(new MindMapDetails("3", "Brainstorming", "1", "Right", "red"));
            mindmapDetails.Add(new MindMapDetails("4", "Complementing", "1", "Left", "red"));

            mindmapDetails.Add(new MindMapDetails("22", "Sessions", "3", "subRight", "red"));
            mindmapDetails.Add(new MindMapDetails("23", "Complementing", "3", "subRight", "red"));

            mindmapDetails.Add(new MindMapDetails("25", "Local", "22", "subRight", ""));
            mindmapDetails.Add(new MindMapDetails("26", "Remote", "22", "subRight", ""));
            mindmapDetails.Add(new MindMapDetails("27", "Individual", "22", "subRight", ""));
            mindmapDetails.Add(new MindMapDetails("28", "Teams", "22", "subRight", ""));
            mindmapDetails.Add(new MindMapDetails("29", "Ideas", "23", "subRight", ""));
            mindmapDetails.Add(new MindMapDetails("30", "Engagement", "23", "subRight", ""));

            mindmapDetails.Add(new MindMapDetails("31", "Product", "29", "subRight", ""));
            mindmapDetails.Add(new MindMapDetails("32", "Service", "29", "subRight", ""));
            mindmapDetails.Add(new MindMapDetails("33", "Business Direction", "29", "subRight", ""));
            mindmapDetails.Add(new MindMapDetails("34", "Empowering", "30", "subRight", ""));
            mindmapDetails.Add(new MindMapDetails("35", "Ownership", "30", "subRight", ""));

            mindmapDetails.Add(new MindMapDetails("50", "Information", "4", "subLeft", ""));
            mindmapDetails.Add(new MindMapDetails("51", "Expectations", "4", "subLeft", ""));


            mindmapDetails.Add(new MindMapDetails("53", "Competetors", "50", "subLeft", ""));
            mindmapDetails.Add(new MindMapDetails("54", "Products", "50", "subLeft", ""));
            mindmapDetails.Add(new MindMapDetails("55", "Features", "50", "subLeft", ""));
            mindmapDetails.Add(new MindMapDetails("56", "Other Data", "50", "subLeft", ""));

            mindmapDetails.Add(new MindMapDetails("59", "Organization", "51", "subLeft", ""));
            mindmapDetails.Add(new MindMapDetails("60", "Customer", "51", "subLeft", ""));
            mindmapDetails.Add(new MindMapDetails("61", "Staff", "51", "subLeft", ""));
            mindmapDetails.Add(new MindMapDetails("62", "Stakeholders", "51", "subLeft", ""));

            List<DiagramUserHandle> handle = new List<DiagramUserHandle>();
            handle.Add(new DiagramUserHandle()
            {
                Name = "leftHandle",
                PathData = "M11.924,6.202 L4.633,6.202 L4.633,9.266 L0,4.633 L4.632,0 L4.632,3.551 L11.923,3.551 L11.923,6.202Z",
                Visible = true,
                BackgroundColor = "black",
                Offset = 1,
                Side = Side.Left,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new DiagramMargin() { Left = 0, Right = 10, Top = 0, Bottom = 0 },
                PathColor = "white"
            });
            handle.Add(new DiagramUserHandle()
            {
                Name = "delete",
                Visible = true,
                PathData = "M 7.04 22.13 L 92.95 22.13 L 92.95 88.8 C 92.95 91.92 91.55 94.58 88.76" +
            "96.74 C 85.97 98.91 82.55 100 78.52 100 L 21.48 100 C 17.45 100 14.03 98.91 11.24 96.74 C 8.45 94.58 7.04" +
            "91.92 7.04 88.8 z M 32.22 0 L 67.78 0 L 75.17 5.47 L 100 5.47 L 100 16.67 L 0 16.67 L 0 5.47 L 24.83 5.47 z",
                BackgroundColor = "black",
                Offset = 0.5,
                Side = Side.Top,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new DiagramMargin() { Left = 0, Right = 0, Top = 0, Bottom = 10 },
                PathColor = "white"
            });
            handle.Add(new DiagramUserHandle()
            {
                Name = "rightHandle",
                Visible = true,
                PathData = "M0,3.063 L7.292,3.063 L7.292,0 L11.924,4.633 L7.292,9.266 L7.292,5.714 L0.001,5.714 L0.001,3.063Z",
                BackgroundColor = "black",
                Offset = 1,
                Side = Side.Right,
                HorizontalAlignment = HorizontalAlignment.Right,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new DiagramMargin() { Left = 10, Right = 0, Top = 0, Bottom = 0 },
                PathColor = "white"
            });

            DiagramSelector userHandle = new DiagramSelector();
            userHandle.Constraints = SelectorConstraints.UserHandle;
            userHandle.UserHandles = handle;
            selectedItems = userHandle;
             
            Nodes = mindmapDetails;
    }
}
public class MindMapDetails
{
    public string Id { get; set; }
    public string Label { get; set; }
    public string ParentId { get; set; }
    public string Branch { get; set; }
    public string Fill { get; set; }

    public MindMapDetails(string id, string label, string parent, string branch, string fill)
    {
        this.Id = id;
        this.Label = label;
        this.ParentId = parent;
        this.Branch = branch;
        this.Fill = fill;
    }

}