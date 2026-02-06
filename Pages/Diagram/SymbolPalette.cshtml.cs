#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.EJ2.Diagrams;

namespace EJ2CoreSampleBrowser.Pages.Diagram;

public class SymbolPaletteModel : PageModel
{
    public List<DiagramNode> BasicNodes { get; set; }
    public List<DiagramConnector> connector { get; set; }
    public List<SymbolPalettePalette> palettes { get; set; }
    public List<ExpandOptions> expand { get; set; }
    public DiagramMargin margin { get; set; }
    public void OnGet()
    {
        List<DiagramNode> FlowShapes =
        [
            new DiagramNode() { Id = "Terminator", Shape = new DiagramFlowShape() { Type = Syncfusion.EJ2.Diagrams.Shapes.Flow, Shape =  Syncfusion.EJ2.Diagrams.FlowShapes.Terminator } },
            new DiagramNode() { Id = "Process", Shape = new DiagramFlowShape() { Type = Syncfusion.EJ2.Diagrams.Shapes.Flow, Shape = Syncfusion.EJ2.Diagrams.FlowShapes.Process } },
            new DiagramNode() { Id = "Decision", Shape = new DiagramFlowShape() { Type = Syncfusion.EJ2.Diagrams.Shapes.Flow, Shape = Syncfusion.EJ2.Diagrams.FlowShapes.Decision } },
            new DiagramNode() { Id = "Document", Shape = new DiagramFlowShape() { Type = Syncfusion.EJ2.Diagrams.Shapes.Flow, Shape = Syncfusion.EJ2.Diagrams.FlowShapes.Document } },
            new DiagramNode() { Id = "PredefinedProcess", Shape = new DiagramFlowShape() { Type = Syncfusion.EJ2.Diagrams.Shapes.Flow, Shape = Syncfusion.EJ2.Diagrams.FlowShapes.PreDefinedProcess } },
            new DiagramNode() { Id = "PaperTap", Shape = new DiagramFlowShape() { Type = Syncfusion.EJ2.Diagrams.Shapes.Flow, Shape = Syncfusion.EJ2.Diagrams.FlowShapes.PaperTap } },
            new DiagramNode() { Id = "DirectData", Shape = new DiagramFlowShape() { Type = Syncfusion.EJ2.Diagrams.Shapes.Flow, Shape = Syncfusion.EJ2.Diagrams.FlowShapes.DirectData } },
            new DiagramNode() { Id = "SequentialData", Shape = new DiagramFlowShape() { Type = Syncfusion.EJ2.Diagrams.Shapes.Flow, Shape = Syncfusion.EJ2.Diagrams.FlowShapes.SequentialData } }
        ];


        BasicNodes =
        [
            new DiagramNode() { Id = "Rectangle", Shape = new DiagramBasicShape() { Type = Syncfusion.EJ2.Diagrams.Shapes.Basic, Shape = BasicShapes.Rectangle } },
            new DiagramNode() { Id = "Ellipse", Shape = new DiagramBasicShape() { Type = Syncfusion.EJ2.Diagrams.Shapes.Basic, Shape = BasicShapes.Ellipse } },
            new DiagramNode() { Id = "Parallelogram", Shape = new DiagramBasicShape() { Type = Syncfusion.EJ2.Diagrams.Shapes.Basic, Shape = BasicShapes.Parallelogram } },
            new DiagramNode() { Id = "Triangle", Shape = new DiagramBasicShape() { Type = Syncfusion.EJ2.Diagrams.Shapes.Basic, Shape = BasicShapes.Triangle } },
            new DiagramNode() { Id = "Hexagon", Shape = new DiagramBasicShape() { Type = Syncfusion.EJ2.Diagrams.Shapes.Basic, Shape = BasicShapes.Hexagon } },
            new DiagramNode() { Id = "Pentagon", Shape = new DiagramBasicShape() { Type = Syncfusion.EJ2.Diagrams.Shapes.Basic, Shape = BasicShapes.Pentagon } },
            new DiagramNode() { Id = "Cylinder", Shape = new DiagramBasicShape() { Type = Syncfusion.EJ2.Diagrams.Shapes.Basic, Shape = BasicShapes.Cylinder } },
            new DiagramNode() { Id = "Star", Shape = new DiagramBasicShape() { Type = Syncfusion.EJ2.Diagrams.Shapes.Basic, Shape = BasicShapes.Star } },
        ];

        List<DiagramNode> NativeShapes = new List<DiagramNode>
        {
            new DiagramNode() { Id = "Script", Width = 80, Height = 80, Shape = new DiagramNative() { Type = Syncfusion.EJ2.Diagrams.Shapes.Native, Scale = Stretch.Stretch } },
            new DiagramNode() { Id = "Settings", Width = 80, Height = 80, Shape = new DiagramNative() { Type = Syncfusion.EJ2.Diagrams.Shapes.Native, Scale = Stretch.Stretch } },
            new DiagramNode() { Id = "Bluetooth", Width = 70, Height = 70, Shape = new DiagramNative() { Type = Syncfusion.EJ2.Diagrams.Shapes.Native, Scale = Stretch.Stretch } },
            new DiagramNode() { Id = "Wi-Fi", Width = 70, Height = 55, Shape = new DiagramNative() { Type = Syncfusion.EJ2.Diagrams.Shapes.Native, Scale = Stretch.Stretch } }
        };
        List<DiagramNode> HTMLShapes = new List<DiagramNode>
            {
                new DiagramNode() { Id = "Meeting", Width = 80, Height = 80, Shape = new DiagramHtml() { Type = Syncfusion.EJ2.Diagrams.Shapes.HTML } },
                new DiagramNode() { Id = "Message", Width = 80, Height = 80, Shape = new DiagramHtml() { Type = Syncfusion.EJ2.Diagrams.Shapes.HTML } },
                new DiagramNode() { Id = "Weather", Width = 70, Height = 70, Shape = new DiagramHtml() { Type = Syncfusion.EJ2.Diagrams.Shapes.HTML } },
                new DiagramNode() { Id = "BugFix", Width = 70, Height = 55, Shape = new DiagramHtml() { Type = Syncfusion.EJ2.Diagrams.Shapes.HTML }, Constraints = NodeConstraints.Default | NodeConstraints.Tooltip, Tooltip = new DiagramDiagramTooltip(){ Content = "Bug Fix" } }
            };
        connector =
        [
            new DiagramConnector() { Id = "link1", Type = Segments.Orthogonal, SourcePoint = new DiagramPoint() { X = 0, Y = 0 }, TargetPoint = new DiagramPoint() { X = 40, Y = 40 }, TargetDecorator = new ConnectorTargetDecoratorConnectors() { Shape = DecoratorShapes.Arrow, Style = new DiagramShapeStyle() { StrokeColor = "#757575", Fill = "#757575" } }, Style = new DiagramStrokeStyle() { StrokeWidth = 2, StrokeColor = "#757575" } },
            new DiagramConnector() { Id = "link3", Type = Segments.Orthogonal, SourcePoint = new DiagramPoint() { X = 0, Y = 0 }, TargetPoint = new DiagramPoint() { X = 40, Y = 40 }, TargetDecorator = new ConnectorTargetDecoratorConnectors() { Shape = DecoratorShapes.None }, Style = new DiagramStrokeStyle() { StrokeWidth = 2, StrokeColor = "#757575" } },
            new DiagramConnector() { Id = "Link21", Type = Segments.Straight, SourcePoint = new DiagramPoint() { X = 0, Y = 0 }, TargetPoint = new DiagramPoint() { X = 40, Y = 40 }, TargetDecorator = new ConnectorTargetDecoratorConnectors() { Shape = DecoratorShapes.Arrow, Style = new DiagramShapeStyle() { StrokeColor = "#757575", Fill = "#757575" } }, Style = new DiagramStrokeStyle() { StrokeWidth = 2, StrokeColor = "#757575" } },
            new DiagramConnector() { Id = "link23", Type = Segments.Straight, SourcePoint = new DiagramPoint() { X = 0, Y = 0 }, TargetPoint = new DiagramPoint() { X = 40, Y = 40 }, TargetDecorator = new ConnectorTargetDecoratorConnectors() { Shape = DecoratorShapes.None }, Style = new DiagramStrokeStyle() { StrokeWidth = 2, StrokeColor = "#757575" } },
            new DiagramConnector() { Id = "link33", Type = Segments.Bezier, SourcePoint = new DiagramPoint() { X = 0, Y = 0 }, TargetPoint = new DiagramPoint() { X = 40, Y = 40 }, TargetDecorator = new ConnectorTargetDecoratorConnectors() { Shape = DecoratorShapes.None }, Style = new DiagramStrokeStyle() { StrokeWidth = 2, StrokeColor = "#757575" } },
        ];

        palettes =
        [
            new SymbolPalettePalette() { Id = "flow", Expanded = true, Symbols = FlowShapes, IconCss = "e-ddb-icons e-basic", Title = "Flow Shapes" },
            new SymbolPalettePalette() { Id = "basic", Expanded = true, Symbols = BasicNodes, IconCss = "e-ddb-icons e-flow", Title = "Basic Shapes" },
            new SymbolPalettePalette() { Id = "connectors", Expanded = true, Symbols = connector, IconCss = "e-ddb-icons e-connector", Title = "Connectors" },
            new SymbolPalettePalette() { Id = "native", Expanded = true, Symbols = NativeShapes, Title = "Native Shapes" },
            new SymbolPalettePalette() { Id = "html", Expanded = true, Symbols = HTMLShapes, Title = "HTML Shapes" }
        ];

        expand =
        [
            new ExpandOptions() { text = "Single", value = "single" },
            new ExpandOptions() { text = "Multiple", value = "multiple" },
        ];
            
        margin = new DiagramMargin() { Left = 15, Bottom = 15, Right = 15, Top = 15 };
    }
}
public class ExpandOptions
{
    public string text;
    public string value;
}