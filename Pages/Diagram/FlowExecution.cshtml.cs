#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
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
namespace EJ2CoreSampleBrowser_NET8.Pages.Diagram;

public class FlowExecutionModel : PageModel
{
    public List<DiagramNode> nodes { get; set; }
    public List<DiagramConnector> connectors { get; set; }
    public void OnGet()
    {
        nodes = GetFlowExecutionNodes();
        connectors = GetFlowExecutionConnectors();
    }
    private List<DiagramConnector> GetFlowExecutionConnectors()
        {
            List<DiagramConnector> connectors = new List<DiagramConnector>();
            connectors.Add(CreateConnector("connector1", "node1", "node2", "", "", "", "", 0));
            connectors.Add(CreateConnector("connector2", "node2", "node3", "", "", "", "", 0));
            connectors.Add(CreateConnector("connector3", "node3", "node4", "Yes", "", "", "", 0));
            connectors.Add(CreateConnector("connector4", "node3", "node5", "No", "", "", "", 0));
            connectors.Add(CreateConnector("connector5", "node5", "node6", "", "", "", "", 0));
            connectors.Add(CreateConnector("connector6", "node6", "node7", "", "", "", "", 0));
            connectors.Add(CreateConnector("connector7", "node8", "node6", "", "", "", "", 0));
            connectors.Add(CreateConnector("connector8", "node7", "node9", "", "", "", "", 0));
            connectors.Add(CreateConnector("connector10", "node4", "node5", "", "Orthogonal", "Bottom", "port", 220));

            return connectors;
        }

        private List<DiagramNode> GetFlowExecutionNodes()
        {
            List<DiagramNode> nodes = new List<DiagramNode>();
            nodes.Add(CreateNodes("node1", 100, 125, "Terminator", "Begin", 100, 35, new List<DiagramPort>() { new DiagramPort() { } }));
            nodes.Add(CreateNodes("node2", 300, 125, "Process", "Specify collection", 120, 25, new List<DiagramPort>() { new DiagramPort() { Id = "port1", Offset = new DiagramPoint() { X = 1, Y = 0.5 } } }));
            nodes.Add(CreateNodes("node3", 500, 125, "Decision", "Particulars \n required?", 100, 50, new List<DiagramPort>() { new DiagramPort() { Id = "port1", Offset = new DiagramPoint() { X = 0.5, Y = 1 } } }));
            nodes.Add(CreateNodes("node4", 730, 125, "Process", "Specify particulars", 90, 25,new List<DiagramPort>() { new DiagramPort() { } }));
            nodes.Add(CreateNodes("node5", 500, 225, "Process", "Design collection", 100, 25, new List<DiagramPort>() { new DiagramPort() { Id = "port", Offset = new DiagramPoint() { X = 1, Y = 0.5 } } }));
            nodes.Add(CreateNodes("node6", 500, 320, "Process", "Cluster of events", 100, 25, new List<DiagramPort>() { new DiagramPort() { } }));
            nodes.Add(CreateNodes("node7", 500, 420, "Process", "Start the process", 100, 25, new List<DiagramPort>() { new DiagramPort() { } }));
            nodes.Add(CreateNodes("node8", 730, 320, "Process", "Record and analyze \n results", 170, 25, new List<DiagramPort>() { new DiagramPort() { Id = "port1", Offset = new DiagramPoint() { X = 1, Y = 0.5 } } }));
            nodes.Add(CreateNodes("node9", 730, 420, "Terminator", "End ", 100, 35, new List<DiagramPort>() { new DiagramPort() { } }));
            return nodes;
        }

        public DiagramNode CreateNodes(string id, double x, double y, string shape, string annotation, double width, double height, List<DiagramPort> port)
        {
            DiagramNode node = new DiagramNode();
            node.Id = id;
            node.Width = 150;
            node.Height = 50;
            node.OffsetX = x;
            node.OffsetY = y;
            List<DiagramNodeAnnotation> label = new List<DiagramNodeAnnotation>();
            label.Add(new DiagramNodeAnnotation()
            {
                Content = annotation
            });
            node.Annotations = label;
            node.Shape = new { type = "Flow", shape = shape };
            node.Style = new NodeStyleNodes() {  Fill = "#FBF6E1", StrokeWidth = 2, StrokeColor = "#E8DFB6" };
            node.Ports = port;
            return node;
        }

        public DiagramConnector CreateConnector(string name, string source, string target, string content, string type, string direction, string targetPort, double length)
        {
            DiagramConnector connector = new DiagramConnector();
            connector.Id = name;
            connector.SourceID = source;
            connector.TargetID = target;
            connector.Style = new DiagramStrokeStyle()
            {
                StrokeWidth = 2,
                StrokeColor = "#8D8D8D"
            };
            connector.Annotations = new List<DiagramConnectorAnnotation>() { new DiagramConnectorAnnotation() {
                Content=content,Style=new DiagramTextStyle(){Fill="white"}
            }
            };
            connector.TargetDecorator = new DiagramDecorator() {Shape=DecoratorShapes.Arrow };
            connector.TargetDecorator.Style = new DiagramShapeStyle() { Fill = "#8D8D8D", StrokeColor = "#8D8D8D" };
            connector.TargetPortID = targetPort;
            if (type == "Orthogonal")
            {
                connector.Type = Segments.Orthogonal;
                List<DiagramSegment> segment = new List<DiagramSegment>();
                segment.Add(new DiagramSegment() { Direction = direction, Type = type, Length = length });
                connector.Segments = segment;
            }
            return connector;
        }
}

public class DiagramSegment
{
    [DefaultValue(null)]
    [HtmlAttributeName("type")]
    [JsonProperty("type")]
    public string Type { get; set; }

    [DefaultValue(null)]
    [HtmlAttributeName("length")]
    [JsonProperty("length")]
    public double Length { get; set; }

    [DefaultValue(null)]
    [HtmlAttributeName("direction")]
    [JsonProperty("direction")]
    public string Direction { get; set; }
}