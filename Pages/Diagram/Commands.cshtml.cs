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

public class CommandsModel : PageModel
{
    public List<DiagramNode> nodes { get; set; }
    public void OnGet()
    {
            nodes = new List<DiagramNode>();
            nodes.Add(new DiagramNode()
            {
                Shape = new { type = "Text", content = "Select the below shapes" },
                Constraints = NodeConstraints.PointerEvents,
                Style = new NodeStyleNodes()
                {
                    FontSize = 10,
                    Fill = "None",
                    FontFamily = "sans-serif",
                    StrokeWidth = 0
                },
                OffsetX = 150,
                OffsetY = 40,
            });
            nodes.Add(new DiagramNode()
            {
                Id = "node1",
                Width = 60,
                Height = 40,
                Style = new NodeStyleNodes()
                {
                    Fill = "#DAEBFF",
                    StrokeColor = "white"
                },
                OffsetX = 150,
                OffsetY = 100,
            });
            nodes.Add(new DiagramNode()
            {
                Id = "node2",
                Width = 80,
                Height = 40,
                Style = new NodeStyleNodes()
                {
                    Fill = "#F5E0F7",
                    StrokeColor = "white"
                },
                OffsetX = 150,
                OffsetY = 170,
            });
            nodes.Add(new DiagramNode()
            {
                Id = "node3",
                Width = 100,
                Height = 40,
                Style = new NodeStyleNodes()
                {
                    Fill = "#E0E5BB",
                    StrokeColor = "white"
                },
                OffsetX = 150,
                OffsetY = 240,
            });
            nodes.Add(new DiagramNode()
            {
                Shape = new { type = "Text", content = "Try Alignment Commandss(AlignRight, AlignLeft \n and AlignCenter)" },
                Constraints = NodeConstraints.PointerEvents,
                Style = new NodeStyleNodes()
                {
                    FontSize = 10,
                    Fill = "None",
                    FontFamily = "sans-serif",
                    StrokeWidth = 0
                },
                OffsetX = 150,
                OffsetY = 310,

            });
            nodes.Add(new DiagramNode()
            {
                Shape = new { type = "Text", content = "Select the below shapes" },
                Constraints = NodeConstraints.PointerEvents,
                Style = new NodeStyleNodes()
                {
                    FontSize = 10,
                    Fill = "None",
                    FontFamily = "sans-serif",
                    StrokeWidth = 0
                },
                OffsetX = 150,
                OffsetY = 380,
            });
            nodes.Add(new DiagramNode()
            {
                Id = "node4",
                Width = 40,
                Height = 60,
                Style = new NodeStyleNodes()
                {
                    Fill = "#DAEBFF",
                    StrokeColor = "white"
                },
                OffsetX = 80,
                OffsetY = 470,
            });
            nodes.Add(new DiagramNode()
            {
                Id = "node5",
                Width = 40,
                Height = 80,
                Style = new NodeStyleNodes()
                {
                    Fill = "#F5E0F7",
                    StrokeColor = "white"
                },
                OffsetX = 160,
                OffsetY = 470,
            });
            nodes.Add(new DiagramNode()
            {
                Id = "node6",
                Width = 40,
                Height = 100,
                Style = new NodeStyleNodes()
                {
                    Fill = "#E0E5BB",
                    StrokeColor = "white"
                },
                OffsetX = 240,
                OffsetY = 470,
            });
            nodes.Add(new DiagramNode()
            {
                Shape = new { type = "Text", content = "Try Alignment Commandss(AlignTop, AlignBottom \n and AlignMiddle)" },
                Constraints = NodeConstraints.PointerEvents,
                Style = new NodeStyleNodes()
                {
                    FontSize = 10,
                    Fill = "None",
                    FontFamily = "sans-serif",
                    StrokeWidth = 0
                },
                OffsetX = 150,
                OffsetY = 550,
            });
            nodes.Add(new DiagramNode()
            {
                Shape = new { type = "Text", content = "Select the below shapes" },
                Constraints = NodeConstraints.PointerEvents,
                Style = new NodeStyleNodes()
                {
                    FontSize = 10,
                    Fill = "None",
                    FontFamily = "sans-serif",
                    StrokeWidth = 0
                },
                OffsetX = 550,
                OffsetY = 40,
            });
            nodes.Add(new DiagramNode()
            {
                Id = "node7",
                Width = 80,
                Height = 40,
                Style = new NodeStyleNodes()
                {
                    Fill = "#DAEBFF",
                    StrokeColor = "white"
                },
                OffsetX = 475,
                OffsetY = 100,
            });
            nodes.Add(new DiagramNode()
            {
                Id = "node8",
                Width = 80,
                Height = 40,
                Style = new NodeStyleNodes()
                {
                    Fill = "#F5E0F7",
                    StrokeColor = "white"
                },
                OffsetX = 625,
                OffsetY = 100,
            });
            nodes.Add(new DiagramNode()
            {
                Id = "node9",
                Width = 80,
                Height = 40,
                Style = new NodeStyleNodes()
                {
                    Fill = "#E0E5BB",
                    StrokeColor = "white"
                },
                OffsetX = 595,
                OffsetY = 180,
            });
            nodes.Add(new DiagramNode()
            {
                Shape = new { type = "Text", content = "Try SpaceAcross Commands" },
                Constraints = NodeConstraints.PointerEvents,
                Style = new NodeStyleNodes()
                {
                    FontSize = 10,
                    Fill = "None",
                    FontFamily = "sans-serif",
                    StrokeWidth = 0
                },
                OffsetX = 550,
                OffsetY = 240,
            });
            nodes.Add(new DiagramNode()
            {
                Shape = new { type = "Text", content = "Select the below shapes" },
                Constraints = NodeConstraints.PointerEvents,
                Style = new NodeStyleNodes()
                {
                    FontSize = 10,
                    Fill = "None",
                    FontFamily = "sans-serif",
                    StrokeWidth = 0
                },
                OffsetX = 550,
                OffsetY = 320,
            });
            nodes.Add(new DiagramNode()
            {
                Id = "node10",
                Width = 80,
                Height = 40,
                Style = new NodeStyleNodes()
                {
                    Fill = "#DAEBFF",
                    StrokeColor = "white"
                },
                OffsetX = 475,
                OffsetY = 400,
            });
            nodes.Add(new DiagramNode()
            {
                Id = "node11",
                Width = 80,
                Height = 40,
                Style = new NodeStyleNodes()
                {
                    Fill = "#F5E0F7",
                    StrokeColor = "white"
                },
                OffsetX = 475,
                OffsetY = 500,
            });
            nodes.Add(new DiagramNode()
            {
                Id = "node12",
                Width = 80,
                Height = 40,
                Style = new NodeStyleNodes()
                {
                    Fill = "#E0E5BB",
                    StrokeColor = "white"
                },
                OffsetX = 625,
                OffsetY = 430,
            });
            nodes.Add(new DiagramNode()
            {
                Shape = new { type = "Text", content = "Try SpaceAcross Commands" },
                Constraints = NodeConstraints.PointerEvents,
                Style = new NodeStyleNodes()
                {
                    FontSize = 10,
                    Fill = "None",
                    FontFamily = "sans-serif",
                    StrokeWidth = 0
                },
                OffsetX = 550,
                OffsetY = 550,
            });
            nodes.Add(new DiagramNode()
            {
                Shape = new { type = "Text", content = "Select the below shapes" },
                Constraints = NodeConstraints.PointerEvents,
                Style = new NodeStyleNodes()
                {
                    FontSize = 10,
                    Fill = "None",
                    FontFamily = "sans-serif",
                    StrokeWidth = 0
                },
                OffsetX = 950,
                OffsetY = 40,
            });
            nodes.Add(new DiagramNode()
            {
                Id = "RightTriangle",
                Width = 100,
                Height = 100,
                Style = new NodeStyleNodes()
                {
                    Fill = "#E0E5BB",
                    StrokeColor = "white"
                },
                Shape = new { type = "Basic", shape = "RightTriangle" },
                OffsetX = 950,
                OffsetY = 120,
            });
            nodes.Add(new DiagramNode()
            {
                Shape = new { type = "Text", content = "Try Flip Commands" },
                Constraints = NodeConstraints.PointerEvents,
                Style = new NodeStyleNodes()
                {
                    FontSize = 10,
                    Fill = "None",
                    FontFamily = "sans-serif",
                    StrokeWidth = 0
                },
                OffsetX = 950,
                OffsetY = 240,
            });
            nodes.Add(new DiagramNode()
            {
                Shape = new { type = "Text", content = "Select the below shapes" },
                Constraints = NodeConstraints.PointerEvents,
                Style = new NodeStyleNodes()
                {
                    FontSize = 10,
                    Fill = "None",
                    FontFamily = "sans-serif",
                    StrokeWidth = 0
                },
                OffsetX = 950,
                OffsetY = 300,
            });
            nodes.Add(new DiagramNode()
            {
                Id = "node14",
                Width = 60,
                Height = 20,
                Style = new NodeStyleNodes()
                {
                    Fill = "#DAEBFF",
                    StrokeColor = "white"
                },
                OffsetX = 950,
                OffsetY = 350,
            });
            nodes.Add(new DiagramNode()
            {
                Id = "node15",
                Width = 80,
                Height = 40,
                Style = new NodeStyleNodes()
                {
                    Fill = "#F5E0F7",
                    StrokeColor = "white"
                },
                OffsetX = 950,
                OffsetY = 420,
            });
            nodes.Add(new DiagramNode()
            {
                Id = "node16",
                Width = 100,
                Height = 50,
                Style = new NodeStyleNodes()
                {
                    Fill = "#E0E5BB",
                    StrokeColor = "white"
                },
                OffsetX = 950,
                OffsetY = 500,
            });
            nodes.Add(new DiagramNode()
            {
                Shape = new { type = "Text", content = "Try Sizing Commands" },
                Constraints = NodeConstraints.PointerEvents,
                Style = new NodeStyleNodes()
                {
                    FontSize= 10,
                    Fill = "None",
                    FontFamily = "sans-serif",
                    StrokeWidth = 0
                },
                OffsetX = 950,
                OffsetY = 550,
            });
    }
}