#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using EJ2CoreSampleBrowser_NET6.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.JSInterop;
using Syncfusion.EJ2.Charts;
using Syncfusion.EJ2.Diagrams;

namespace EJ2CoreSampleBrowser.Pages.Diagram;

public class ShortestPathModel : PageModel
{
    public List<DiagramNode> Nodes { get; set; } = new List<DiagramNode>();
    public List<DiagramConnector> Connectors { get; set; } = new List<DiagramConnector>();
    public DiagramConstraints Constraints { get; set; } = DiagramConstraints.Default & ~DiagramConstraints.UndoRedo;

    private const string NodeHighlightFill = "#6495ED";
    private const string NodeHighlightStroke = "#4472C4";
    private const string NodeDefaultFill = "white";
    private const string NodeDefaultStroke = "#333333";
    private const string NodeErrorFill = "#FF6565";
    private const string NodeErrorStroke = "#EE3636";
    private const string ConnectorHighlightStroke = "#4472C4";
    private const string ConnectorDefaultStroke = "#333333";
    public void OnGet()
    {
        CreateNodes();
        CreateConnectors();
       
    }
    private void CreateNodes()
    {
        Nodes.Add(CreateNode("A", 75, 75));
        Nodes.Add(CreateNode("B", 384, 300));
        Nodes.Add(CreateNode("C", 700, 200));
        Nodes.Add(CreateNode("D", 100, 300));
        Nodes.Add(CreateNode("E", 825, 20));
        Nodes.Add(CreateNode("F", 90, 440));
        Nodes.Add(CreateNode("G", 460, 660));
        Nodes.Add(CreateNode("H", 270, 530));
        Nodes.Add(CreateNode("I", 750, 350));
        Nodes.Add(CreateNode("J", 1000, 450));
        Nodes.Add(CreateNode("K", 750, 450));
        Nodes.Add(CreateNode("L", 929, 210));
        Nodes.Add(CreateNode("X", 420, 100));
        Nodes.Add(CreateNode("Y", 850, 620));
    }
    private DiagramNode CreateNode(string id, double x, double y)
    {
        return new DiagramNode()
        {
            Id = id,
            OffsetX = x,
            OffsetY = y,
            Constraints = (NodeConstraints.Default | NodeConstraints.Tooltip) & ~NodeConstraints.Select,
            Width = 50,
            Height = 50,
           Shape= new { type = "Basic", shape = "Ellipse" },
            Tooltip = new DiagramDiagramTooltip() { OpenOn  =TooltipMode.Custom,RelativeMode=TooltipRelativeMode.Object },
            Style = id == "A" ? new NodeStyleNodes()
            {
                StrokeColor = NodeHighlightStroke,
                StrokeWidth = 3,
                Fill = NodeHighlightFill
            } : new NodeStyleNodes() { Fill = NodeDefaultFill },
            Annotations = new List<DiagramNodeAnnotation>()
            {
                new DiagramNodeAnnotation()
                {
                    Content = id,
                    Constraints = AnnotationConstraints.ReadOnly,
                    Style = new DiagramTextStyle()
                    {
                        Color = "black",
                        FontSize = 16,
                    }
                }
            }
        };
    }
    private void CreateConnectors()
    {
        Connectors.Add(CreateConnector("A", "B"));
        Connectors.Add(CreateConnector("A", "D"));
        Connectors.Add(CreateConnector("A", "X"));
        Connectors.Add(CreateConnector("B", "D"));
        Connectors.Add(CreateConnector("B", "H"));
        Connectors.Add(CreateConnector("B", "X"));
        Connectors.Add(CreateConnector("C", "L"));
        Connectors.Add(CreateConnector("C", "X"));
        Connectors.Add(CreateConnector("D", "F"));
        Connectors.Add(CreateConnector("E", "X"));
        Connectors.Add(CreateConnector("G", "H"));
        Connectors.Add(CreateConnector("G", "Y"));
        Connectors.Add(CreateConnector("H", "F"));
        Connectors.Add(CreateConnector("I", "J"));
        Connectors.Add(CreateConnector("I", "K"));
        Connectors.Add(CreateConnector("I", "L"));
        Connectors.Add(CreateConnector("J", "L"));
        Connectors.Add(CreateConnector("K", "Y"));
        Connectors.Add(CreateConnector("B", "K"));
        Connectors.Add(CreateConnector("B", "C"));
        Connectors.Add(CreateConnector("G", "K"));
        Connectors.Add(CreateConnector("H", "I"));
    }
    private DiagramConnector CreateConnector(string sourceId, string targetId)
    {
        return new DiagramConnector()
        {
            Id = $"{sourceId}{targetId}",
            SourceID = sourceId,
            TargetID = targetId,
            Type = Segments.Straight,
            Style = new DiagramStrokeStyle()
            {
                StrokeColor = ConnectorDefaultStroke,
                StrokeWidth = 2,
                StrokeDashArray = "5,5"
            },
            Annotations = new List<DiagramConnectorAnnotation>()
            {
                new DiagramConnectorAnnotation()
                {
                    Style = new DiagramTextStyle()
                    {
                        Color = "white",
                        FontSize = 12,
                        Bold = true,
                        Fill = "Transparent"
                    },
                    Offset = 0.5,
                    Constraints = AnnotationConstraints.ReadOnly,
                    Alignment = AnnotationAlignment.Center,
                    Width = 20,
                    Height = 20
                }
            },
            Constraints = ConnectorConstraints.ReadOnly,
            TargetDecorator = new DiagramDecorator()
            {
                Shape = DecoratorShapes.Arrow,
            }
        };
    }      
}
