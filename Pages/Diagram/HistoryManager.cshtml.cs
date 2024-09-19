#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.EJ2.Diagrams;

namespace EJ2CoreSampleBrowser_NET8.Pages.Diagram;

public class HistoryManagerModel : PageModel
{
    public List<DiagramConnector> connectors { get; set; }
    public List<DiagramNode> nodes { get; set; }
    public void OnGet()
    {
        nodes = GetHistoryManagerNodes();
        connectors = GetHistoryManagerConnectors();
    }
    private List<DiagramConnector> GetHistoryManagerConnectors()
            {
                connectors = new List<DiagramConnector>();
                connectors.Add(new DiagramConnector()
                {
                    Id = "connector1",
                    SourceID = "node1",
                    TargetID = "node2",
                });
                connectors.Add(new DiagramConnector()
                {
                    Id = "connector2",
                    SourceID = "node2",
                    TargetID = "node3",
                });
                connectors.Add(new DiagramConnector()
                {
                    Id = "connector3",
                    SourceID = "node3",
                    TargetID = "node4",
                });
                connectors.Add(new DiagramConnector()
                {
                    Id = "connector4",
                    SourceID = "node4",
                    TargetID = "node5",
                });
                connectors.Add(new DiagramConnector()
                {
                    Id = "connector5",
                    SourceID = "node5",
                    TargetID = "node6",
                    Annotations = new List<DiagramConnectorAnnotation>() { new DiagramConnectorAnnotation() { Content = "No", Style = new DiagramTextStyle() { Fill = "white" } } }
                });
                connectors.Add(new DiagramConnector()
                {
                    Id = "connector6",
                    SourceID = "node5",
                    TargetID = "node7",
                    Type = Segments.Orthogonal,
                    Segments = new List<DiagramSegment>() { new DiagramSegment() { Type = "Orthogonal", Length = 150, Direction = "Left" } },
                    Annotations = new List<DiagramConnectorAnnotation>() { new DiagramConnectorAnnotation() { Content = "Yes", Style = new DiagramTextStyle() { Fill = "white" } } }
                });
                connectors.Add(new DiagramConnector()
                {
                    Id = "connector7",
                    SourceID = "node7",
                    TargetID = "node3",
                    SourcePortID = "portcoding",
                    TargetPortID = "codingPort",
                    Annotations = new List<DiagramConnectorAnnotation>() { new DiagramConnectorAnnotation() { Content = "Yes", Style = new DiagramTextStyle() { Fill = "white" } } }
                });
                connectors.Add(new DiagramConnector()
                {
                    Id = "connector8",
                    SourceID = "node7",
                    TargetID = "node2",
                    SourcePortID = "porterror",
                    TargetPortID = "designPort",
                    Type = Segments.Orthogonal,
                    Annotations = new List<DiagramConnectorAnnotation>() { new DiagramConnectorAnnotation() { Content = "Yes", Style = new DiagramTextStyle() { Fill = "white" } } }
                });
                return connectors;
            }

            private List<DiagramNode> GetHistoryManagerNodes()
            {
                nodes = new List<DiagramNode>();
                {
                    nodes.Add(new DiagramNode()
                    {
                        Id = "node1",
                        OffsetX = 400,
                        OffsetY = 80,
                        Width = 70,
                        Height = 40,
                        Style = new DiagramShapeStyle() { Fill = "#FFB2B2", StrokeColor = "#FFB2B2" },
                        Annotations = new List<DiagramNodeAnnotation>() { new DiagramNodeAnnotation() { Id = "label1", Content = "Start" } },
                        Shape = new { type = "Flow", shape = "Terminator" }
                    });
                    nodes.Add(new DiagramNode()
                    {
                        Id = "node2",
                        OffsetX = 400,
                        OffsetY = 150,
                        Style = new DiagramShapeStyle() { Fill = "#DCDCDC", StrokeColor = "#DCDCDC" },
                        Annotations = new List<DiagramNodeAnnotation>() { new DiagramNodeAnnotation() { Id = "label1", Content = "Design" } },
                        Shape = new { type = "Flow", shape = "Process" },
                        Ports = new List<DiagramPort>() { new DiagramPort() { Id = "designPort", Offset = new DiagramPoint() { X = 0, Y = 0.5 } } }
                    });
                    nodes.Add(new DiagramNode()
                    {
                        Id = "node3",
                        OffsetX = 400,
                        OffsetY = 230,
                        Style = new DiagramShapeStyle() { Fill = "#DCDCDC", StrokeColor = "#DCDCDC" },
                        Annotations = new List<DiagramNodeAnnotation>() { new DiagramNodeAnnotation() { Id = "label1", Content = "Coding" } },
                        Shape = new { type = "Flow", shape = "Process" },
                        Ports = new List<DiagramPort>() { new DiagramPort() { Id = "codingPort", Offset = new DiagramPoint() { X = 0, Y = 0.5 } } }
                    });
                    List<DiagramPort> port = new List<DiagramPort>();
                    nodes.Add(new DiagramNode()
                    {
                        Id = "node4",
                        OffsetX = 400,
                        OffsetY = 310,
                        Style = new DiagramShapeStyle() { Fill = "#DCDCDC", StrokeColor = "#DCDCDC" },
                        Annotations = new List<DiagramNodeAnnotation>() { new DiagramNodeAnnotation() { Id = "label1", Content = "Testing" } },
                        Shape = new { type = "Flow", shape = "Process" }
                    });
                    nodes.Add(new DiagramNode()
                    {
                        Id = "node5",
                        OffsetX = 400,
                        OffsetY = 390,
                        Style = new DiagramShapeStyle() { Fill = "#A2D8B0", StrokeColor = "#A2D8B0" },
                        Height = 80,
                        Width = 60,
                        Annotations = new List<DiagramNodeAnnotation>() { new DiagramNodeAnnotation() { Id = "label1", Content = "Errors?" } },
                        Shape = new { type = "Flow", shape = "Decision" }
                    });
                    nodes.Add(new DiagramNode()
                    {
                        Id = "node6",
                        OffsetX = 400,
                        OffsetY = 480,
                        Style = new DiagramShapeStyle() { Fill = "#FFB2B2", StrokeColor = "#FFB2B2" },
                        Height = 40,
                        Width = 70,
                        Annotations = new List<DiagramNodeAnnotation>() { new DiagramNodeAnnotation() { Id = "label1", Content = "End" } },
                        Shape = new { type = "Flow", shape = "Terminator" }
                    });
                    port.Add(new DiagramPort() { Id = "porterror", Offset = new DiagramPoint() { X = 0.5, Y = 0 } });
                    port.Add(new DiagramPort() { Id = "portcoding", Offset = new DiagramPoint() { X = 1, Y = 0.5 } });
                    port.Add(new DiagramPort() { Id = "portdesign", Offset = new DiagramPoint() { X = 0.5, Y = 1 } });
                    nodes.Add(new DiagramNode()
                    {
                        Id = "node7",
                        Width = 100,
                        OffsetX = 220,
                        OffsetY = 230,
                        Style = new DiagramShapeStyle() { Fill = "#A2D8B0", StrokeColor = "#A2D8B0" },
                        Height = 60,
                        Annotations = new List<DiagramNodeAnnotation>() { new DiagramNodeAnnotation() { Id = "label1", Content = "Design Error?" } },
                        Shape = new { type = "Flow", shape = "Decision" },
                        Ports = port
                    });
                    return nodes;
                }
            }
}