#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.EJ2.Diagrams;
using Syncfusion.EJ2.Navigations;
using System.ComponentModel;
using Newtonsoft.Json;

namespace EJ2CoreSampleBrowser.Pages.Diagram;

public class VisioImportModel : PageModel
{
    public List<DiagramConnector> Connectors { get; set; }
    public List<DiagramNode> Nodes { get; set; }
    public List<ToolbarItem> items { get; set; }
    public List<ContextMenuItem> conTypeItems { get; set; }
    public List<ContextMenuItem> shapesItems { get; set; }
    public List<SymbolPalettePalette> Palette { get; set; }
    public Enum Multiple { get; set; }

    public void OnGet()
    {
        // Nodes
        Nodes = new List<DiagramNode>
        {
            CreateNode("start", "Start", 80, FlowShapes.Terminator),
            CreateNode("draft", "Draft", 180, FlowShapes.Process, 400, 100, 50, new List<DiagramPort>
            {
                new DiagramPort { Id = "rightport", Offset = new DiagramPoint { X = 1, Y = 0.5 } }
            }),
            CreateNode("approvedDecision", "Approved?", 280, FlowShapes.Decision, 400, 120, 60),
            CreateNode("revise", "Revise", 280, FlowShapes.Process, 600, 100, 50, new List<DiagramPort>
            {
                new DiagramPort { Id = "rightport", Offset = new DiagramPoint { X = 1, Y = 0.5 } }
            }),
            CreateNode("copyedit", "Copyedit", 400),
            CreateNode("proof", "Proof", 500),
            CreateNode("finalrevise", "Revise", 600),
            CreateNode("finalize", "Finalize", 700),
            CreateNode("publish", "Publish", 800, FlowShapes.Terminator)
        };

        // Connectors
        Connectors = new List<DiagramConnector>
        {
            CreateConnector("connector1", "start", "draft"),
            CreateConnector("connector2", "draft", "approvedDecision"),
            CreateConnector("connector3", "approvedDecision", "copyedit", "Yes"),
            CreateConnector("connector4", "approvedDecision", "revise", "No"),
            CreateConnector("connector5", "revise", "draft", null, "rightport", "rightport"),
            CreateConnector("connector6", "copyedit", "proof"),
            CreateConnector("connector7", "proof", "finalrevise"),
            CreateConnector("connector8", "finalrevise", "finalize"),
            CreateConnector("connector9", "finalize", "publish"),
        };

        // Palette symbols
        var flowShapes = new List<DiagramNode>{
            new DiagramNode{ Id="process", Shape = new { type = "Flow", shape = "Process" } },
            new DiagramNode{ Id="decision", Shape = new { type = "Flow", shape = "Decision" } },
            new DiagramNode{ Id="document", Shape = new { type = "Flow", shape = "Document" } },
            new DiagramNode{ Id="terminator", Shape = new { type = "Flow", shape = "Terminator" } },
            new DiagramNode{ Id="predefinedProcess", Shape = new { type = "Flow", shape = "PreDefinedProcess" } },
            new DiagramNode{ Id="data", Shape = new { type = "Flow", shape = "Data" } },
            new DiagramNode{ Id="directData", Shape = new { type = "Flow", shape = "DirectData" } },
            new DiagramNode{ Id="internalStorage", Shape = new { type = "Flow", shape = "InternalStorage" } },
            new DiagramNode{ Id="manualInput", Shape = new { type = "Flow", shape = "ManualInput" } },
            new DiagramNode{ Id="manualOperation", Shape = new { type = "Flow", shape = "ManualOperation" } }
        };
        var basicShapes = new List<DiagramNode>{
            new DiagramNode{ Id="rectangle", Shape = new { type = "Basic", shape = "Rectangle" } },
            new DiagramNode{ Id="ellipse", Shape = new { type = "Basic", shape = "Ellipse" } },
            new DiagramNode{ Id="hexagon", Shape = new { type = "Basic", shape = "Hexagon" } },
            new DiagramNode{ Id="parallelogram", Shape = new { type = "Basic", shape = "Parallelogram" } },
            new DiagramNode{ Id="pentagon", Shape = new { type = "Basic", shape = "Pentagon" } },
            new DiagramNode{ Id="heptagon", Shape = new { type = "Basic", shape = "Heptagon" } },
            new DiagramNode{ Id="octagon", Shape = new { type = "Basic", shape = "Octagon" } },
            new DiagramNode{ Id="triangle", Shape = new { type = "Basic", shape = "Triangle" } },
            new DiagramNode{ Id="star", Shape = new { type = "Basic", shape = "Star" } },
            new DiagramNode{ Id="plus", Shape = new { type = "Basic", shape = "Plus" } }
        };
        var connectorSymbols = new List<DiagramConnector>{
            new DiagramConnector{ Id = "link1", Type = Segments.Orthogonal, SourcePoint = new DiagramPoint{ X=0, Y=0 }, TargetPoint = new DiagramPoint{ X=60, Y=60 }, TargetDecorator = new ConnectorTargetDecoratorConnectors{ Shape = DecoratorShapes.Arrow, Style = new DiagramShapeStyle{ StrokeColor = "#757575", Fill = "#757575" } } },
            new DiagramConnector{ Id = "link2", Type = Segments.Orthogonal, SourcePoint = new DiagramPoint{ X=0, Y=0 }, TargetPoint = new DiagramPoint{ X=60, Y=60 }, TargetDecorator = new ConnectorTargetDecoratorConnectors{ Shape = DecoratorShapes.None } },
            new DiagramConnector{ Id = "link3", Type = Segments.Straight, SourcePoint = new DiagramPoint{ X=0, Y=0 }, TargetPoint = new DiagramPoint{ X=60, Y=60 }, TargetDecorator = new ConnectorTargetDecoratorConnectors{ Shape = DecoratorShapes.Arrow, Style = new DiagramShapeStyle{ StrokeColor = "#757575", Fill = "#757575" } } },
            new DiagramConnector{ Id = "link4", Type = Segments.Straight, SourcePoint = new DiagramPoint{ X=0, Y=0 }, TargetPoint = new DiagramPoint{ X=60, Y=60 }, TargetDecorator = new ConnectorTargetDecoratorConnectors{ Shape = DecoratorShapes.None } },
            new DiagramConnector{ Id = "link5", Type = Segments.Bezier, SourcePoint = new DiagramPoint{ X=0, Y=0 }, TargetPoint = new DiagramPoint{ X=60, Y=60 }, TargetDecorator = new ConnectorTargetDecoratorConnectors{ Shape = DecoratorShapes.None } },
        };

        Palette = new List<SymbolPalettePalette>{
            new SymbolPalettePalette{ Id="flowShapesPalette", Expanded=true, Symbols = flowShapes, Title = "Flow Shapes", IconCss = "e-ddb-icons e-flow" },
            new SymbolPalettePalette{ Id="basicShapesPalette", Expanded=false, Symbols = basicShapes, Title = "Basic Shapes", IconCss = "e-ddb-icons e-basic" },
            new SymbolPalettePalette{ Id="connectorsPalette", Expanded=false, Symbols = connectorSymbols, Title = "Connectors", IconCss = "e-ddb-icons e-connector" },
        };

        // Toolbar
        items = new List<ToolbarItem>();
        items.Add(new ToolbarItem { PrefixIcon = "e-icons e-circle-add", TooltipText = "New Diagram" });
        items.Add(new ToolbarItem { PrefixIcon = "e-icons e-import", TooltipText = "Import Visio (.vsdx)" });
        items.Add(new ToolbarItem { PrefixIcon = "e-icons e-export", TooltipText = "Export as Visio (.vsdx)" });
        items.Add(new ToolbarItem { Type = ItemType.Separator });
        items.Add(new ToolbarItem { Template = "#conTypeBtn", Type = ItemType.Input, TooltipText = "Draw Connectors" });
        items.Add(new ToolbarItem { Template = "#shapesBtn", Type = ItemType.Input, TooltipText = "Draw Shapes" });
        items.Add(new ToolbarItem { Type = ItemType.Separator });
        items.Add(new ToolbarItem { PrefixIcon = "e-cut e-icons", TooltipText = "Cut", Disabled = true });
        items.Add(new ToolbarItem { PrefixIcon = "e-copy e-icons", TooltipText = "Copy", Disabled = true });
        items.Add(new ToolbarItem { PrefixIcon = "e-icons e-paste", TooltipText = "Paste", Disabled = true });
        items.Add(new ToolbarItem { Type = ItemType.Separator });
        items.Add(new ToolbarItem { PrefixIcon = "e-icons e-undo", TooltipText = "Undo", Disabled = true });
        items.Add(new ToolbarItem { PrefixIcon = "e-icons e-redo", TooltipText = "Redo", Disabled = true });
        items.Add(new ToolbarItem { Type = ItemType.Separator });
        items.Add(new ToolbarItem { PrefixIcon = "e-trash e-icons", TooltipText = "Delete", Disabled = true });

        conTypeItems = new List<ContextMenuItem>{
            new ContextMenuItem{ Text = "Straight", IconCss = "e-icons e-line" },
            new ContextMenuItem{ Text = "Orthogonal", IconCss = "sf-icon-orthogonal" },
            new ContextMenuItem{ Text = "Bezier", IconCss = "sf-icon-bezier" },
        };
        shapesItems = new List<ContextMenuItem>{
            new ContextMenuItem{ Text = "Rectangle", IconCss = "e-rectangle e-icons" },
            new ContextMenuItem{ Text = "Ellipse", IconCss = " e-circle e-icons" },
        };

        Multiple = ExpandMode.Multiple;
    }

    // Helper method to create a process node
    public static DiagramNode CreateNode(
        string id,
        string content,
        double offsetY,
        FlowShapes shape = FlowShapes.Process,
        double offsetX = 400,
        double width = 100,
        double height = 50,
        List<DiagramPort> ports = null)
    {
        var node = new DiagramNode
        {
            Id = id,
            Shape = new DiagramFlowShape
            {
                Type = Syncfusion.EJ2.Diagrams.Shapes.Flow,
                Shape = shape
            },
            Style = new DiagramShapeStyle
            {
                Fill = "#357BD2",
                StrokeColor = "white"
            },
            Annotations = new List<DiagramNodeAnnotation>
                {
                    new DiagramNodeAnnotation
                    {
                        Content = content,
                        Style = new DiagramTextStyle
                        {
                            Color = "white"
                        }
                    }
                },
            OffsetX = offsetX,
            OffsetY = offsetY,
            Width = width,
            Height = height,
        };
        if (ports != null)
        {
            node.Ports = ports;
        }
        return node;
    }
    // Helper method to create a connector
    public static DiagramConnector CreateConnector(
        string id,
        string sourceID,
        string targetID,
        string annotation = "",
        string sourcePortID = "",
        string targetPortID = "")
    {
        var connector = new DiagramConnector
        {
            Id = id,
            SourceID = sourceID,
            TargetID = targetID,
            Type = Segments.Orthogonal
        };
        if (!string.IsNullOrEmpty(annotation))
        {
            connector.Annotations = new List<DiagramConnectorAnnotation>
                {
                    new DiagramConnectorAnnotation
                    {
                        Content = annotation,
                        Alignment = annotation == "Yes" ? AnnotationAlignment.After : AnnotationAlignment.Before,
                        Displacement = annotation == "Yes"
                            ? new DiagramPoint { X = 5, Y = 0 }
                            : new DiagramPoint { X = 5, Y = 5 }
                    }
                };
        }
        if (!string.IsNullOrEmpty(sourcePortID))
            connector.SourcePortID = sourcePortID;
        if (!string.IsNullOrEmpty(targetPortID))
            connector.TargetPortID = targetPortID;
        return connector;
    }
}
