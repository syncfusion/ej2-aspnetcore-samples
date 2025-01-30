#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.EJ2.Diagrams;
using System.ComponentModel;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Newtonsoft.Json;
namespace EJ2CoreSampleBrowser.Pages.Diagram;

public class FlowchartLayoutModel : PageModel
{
    public List<BranchDirectionList> branchDirectionList { get; set; }
    public List<BranchDirectionList> orientationList { get; set; }

    public List<FlowchartDetails> Data { get; set; }
    public void OnGet()
    {
        branchDirectionList = new List<BranchDirectionList>();
        branchDirectionList.Add(new BranchDirectionList() { Text = "Left in flow", Value="LeftInFlow" });
        branchDirectionList.Add(new BranchDirectionList() { Text = "Right in flow", Value = "RightInFlow" });
        branchDirectionList.Add(new BranchDirectionList() { Text = "Same as flow", Value = "SameAsFlow" });

        orientationList = new List<BranchDirectionList>();
        orientationList.Add(new BranchDirectionList() { Text = "Top to bottom", Value = "TopToBottom" });
        orientationList.Add(new BranchDirectionList() { Text = "Left to right", Value = "LeftToRight" });
        Data = FlowchartDetails.GetAllRecords();
    }

}
public class FlowchartDetails
{
    public string id { get; set; }
    public string name { get; set; }
    public string shape { get; set; }
    public string color { get; set; }
    public string[] parentId { get; set; }
    public string stroke { get; set; }
    public int strokeWidth { get; set; }
    public string arrowType { get; set; }
    public string[] label { get; set; }
 
    public FlowchartDetails(string id, string name, string shape, string color, string[] parentId, string stroke, int strokeWidth, string arrowType, string[] label)
    {
        this.id = id;
        this.name = name;
        this.shape = shape;
        this.color = color;
        this.parentId = parentId;
        this.stroke = stroke;
        this.strokeWidth = strokeWidth;
        this.arrowType = arrowType;
        this.label = label;
    }
 
    public static List<FlowchartDetails> GetAllRecords()
    {
        List<FlowchartDetails> flowChartDetails = new List<FlowchartDetails>
        {
            new FlowchartDetails("A", "Start", "Terminator", "#90EE90", null, "#333", 1, "", null),
            new FlowchartDetails("B", "Open the browser and go to Amazon site", "Rectangle", "#1759B7", new string[] { "A" }, "#333", 1, "single-line-arrow", null),
            new FlowchartDetails("C", "Already a customer?", "Decision", "#2F95D8", new string[] { "B" }, "#333", 1, "single-line-arrow", null),
            new FlowchartDetails("D", "Create an account", "Rectangle", "#70AF16", new string[] { "C" }, "#333", 1, "single-line-arrow", new string[] { "No" }),
            new FlowchartDetails("E", "Enter login information", "Rectangle", "#70AF16", new string[] { "C" }, "#333", 1, "single-line-arrow", new string[] { "Yes" }),
            new FlowchartDetails("F", "Search for the book in the search bar", "Predefined Process", "#1759B7", new string[] { "E", "D" }, "#333", 1, "single-line-arrow", new string[] { "", "" }),
            new FlowchartDetails("G", "Select the preferred book", "Rectangle", "#1759B7", new string[] { "F" }, "#333", 1, "single-line-arrow", null),
            new FlowchartDetails("H", "Is the book new or used?", "Rectangle", "#2F95D8", new string[] { "G" }, "#333", 1, "single-line-arrow", null),
            new FlowchartDetails("I", "Select the new book", "Rectangle", "#70AF16", new string[] { "H" }, "#333", 1, "single-line-arrow", new string[] { "Yes" }),
            new FlowchartDetails("J", "Select the used book", "Rectangle", "#70AF16", new string[] { "H" }, "#333", 1, "single-line-arrow", new string[] { "No" }),
            new FlowchartDetails("K", "Add to Cart & Proceed to Checkout", "Rectangle", "#1759B7", new string[] { "I", "J" }, "#333", 1, "single-line-arrow", new string[] { "", "" }),
            new FlowchartDetails("L", "Enter shipping and payment details", "Rectangle", "#1759B7", new string[] { "K", "M" }, "#333", 1, "single-line-arrow", new string[] { "", "" }),
            new FlowchartDetails("M", "Is the information correct?", "Decision", "#2F95D8", new string[] { "L" }, "#333", 1, "single-line-arrow", null),
            new FlowchartDetails("N", "Review and place the order", "Rectangle", "#1759B7", new string[] { "M" }, "#333", 1, "single-line-arrow", new string[] { "True" }),
            new FlowchartDetails("O", "End", "Terminator", "#8E44CC", new string[] { "N" }, "#333", 1, "single-line-arrow", null)
        };
 
        return flowChartDetails;
    }
}
public class BranchDirectionList
{
    public string Text;
    public string Value;
}