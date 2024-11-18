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

public class SymbolPaletteModel : PageModel
{
    public List<DiagramNode> BasicNodes { get; set; }
    public List<DiagramConnector> connector { get; set; }
    public List<SymbolPalettePalette> palettes { get; set; }
    public List<ExpandOptions> expand { get; set; }
    public DiagramMargin margin { get; set; }
    public void OnGet()
    {
        List<DiagramNode> SymbolPaletee = new List<DiagramNode>();
            SymbolPaletee.Add(new DiagramNode() { Id = "Terminator", Shape = new { type = "Flow", shape = "Terminator" } });
            SymbolPaletee.Add(new DiagramNode() { Id = "Terminator", Shape = new { type = "Flow", shape = "Terminator" } });
            SymbolPaletee.Add(new DiagramNode() { Id = "Process", Shape = new { type = "Flow", shape = "Process" } });
            SymbolPaletee.Add(new DiagramNode() { Id = "Decision", Shape = new { type = "Flow", shape = "Decision" } });
            SymbolPaletee.Add(new DiagramNode() { Id = "Document", Shape = new { type = "Flow", shape = "Document" } });
            SymbolPaletee.Add(new DiagramNode() { Id = "PreDefinedProcess", Shape = new { type = "Flow", shape = "PreDefinedProcess" } });
            SymbolPaletee.Add(new DiagramNode() { Id = "PaperTap", Shape = new { type = "Flow", shape = "PaperTap" } });
            SymbolPaletee.Add(new DiagramNode() { Id = "DirectData", Shape = new { type = "Flow", shape = "DirectData" } });
            SymbolPaletee.Add(new DiagramNode() { Id = "SequentialData", Shape = new { type = "Flow", shape = "SequentialData" } });


            BasicNodes = new List<DiagramNode>();
            BasicNodes.Add(new DiagramNode() { Id = "Rectangle", Shape = new DiagramBasicShape() { Type = Syncfusion.EJ2.Diagrams.Shapes.Basic, Shape = BasicShapes.Rectangle } });
            BasicNodes.Add(new DiagramNode() { Id = "Ellipse", Shape = new DiagramBasicShape() { Type = Syncfusion.EJ2.Diagrams.Shapes.Basic, Shape = BasicShapes.Ellipse } });
            BasicNodes.Add(new DiagramNode() { Id = "Parallelogram", Shape = new DiagramBasicShape() { Type = Syncfusion.EJ2.Diagrams.Shapes.Basic, Shape = BasicShapes.Parallelogram } });
            BasicNodes.Add(new DiagramNode() { Id = "Triangle", Shape = new DiagramBasicShape() { Type = Syncfusion.EJ2.Diagrams.Shapes.Basic, Shape = BasicShapes.Triangle } });
            BasicNodes.Add(new DiagramNode() { Id = "Hexagon", Shape = new DiagramBasicShape() { Type = Syncfusion.EJ2.Diagrams.Shapes.Basic, Shape = BasicShapes.Hexagon } });
            BasicNodes.Add(new DiagramNode() { Id = "Pentagon", Shape = new DiagramBasicShape() { Type = Syncfusion.EJ2.Diagrams.Shapes.Basic, Shape = BasicShapes.Pentagon } });
            BasicNodes.Add(new DiagramNode() { Id = "Cylinder", Shape = new DiagramBasicShape() { Type = Syncfusion.EJ2.Diagrams.Shapes.Basic, Shape = BasicShapes.Cylinder } });
            BasicNodes.Add(new DiagramNode() { Id = "Star", Shape = new DiagramBasicShape() { Type = Syncfusion.EJ2.Diagrams.Shapes.Basic, Shape = BasicShapes.Star } });

            connector = new List<DiagramConnector>();
            connector.Add(new DiagramConnector() { Id = "link1", Type = Segments.Orthogonal, SourcePoint = new DiagramPoint() { X = 0, Y = 0 }, TargetPoint = new DiagramPoint() { X = 40, Y = 40 }, TargetDecorator = new ConnectorTargetDecoratorConnectors() { Shape = DecoratorShapes.Arrow, Style = new DiagramShapeStyle() { StrokeColor = "#757575", Fill = "#757575" } }, Style = new DiagramStrokeStyle() { StrokeWidth = 2, StrokeColor = "#757575" } });
            connector.Add(new DiagramConnector() { Id = "link3", Type = Segments.Orthogonal, SourcePoint = new DiagramPoint() { X = 0, Y = 0 }, TargetPoint = new DiagramPoint() { X = 40, Y = 40 }, TargetDecorator = new ConnectorTargetDecoratorConnectors() { Shape = DecoratorShapes.None }, Style = new DiagramStrokeStyle() { StrokeWidth = 2, StrokeColor = "#757575" } });
            connector.Add(new DiagramConnector() { Id = "Link21", Type = Segments.Straight, SourcePoint = new DiagramPoint() { X = 0, Y = 0 }, TargetPoint = new DiagramPoint() { X = 40, Y = 40 }, TargetDecorator = new ConnectorTargetDecoratorConnectors() { Shape = DecoratorShapes.Arrow, Style = new DiagramShapeStyle() { StrokeColor = "#757575", Fill = "#757575" } }, Style = new DiagramStrokeStyle() { StrokeWidth = 2, StrokeColor = "#757575" } });
            connector.Add(new DiagramConnector() { Id = "link23", Type = Segments.Straight, SourcePoint = new DiagramPoint() { X = 0, Y = 0 }, TargetPoint = new DiagramPoint() { X = 40, Y = 40 }, TargetDecorator = new ConnectorTargetDecoratorConnectors() { Shape = DecoratorShapes.None }, Style = new DiagramStrokeStyle() { StrokeWidth = 2, StrokeColor = "#757575" } });
            connector.Add(new DiagramConnector() { Id = "link33", Type = Segments.Bezier, SourcePoint = new DiagramPoint() { X = 0, Y = 0 }, TargetPoint = new DiagramPoint() { X = 40, Y = 40 }, TargetDecorator = new ConnectorTargetDecoratorConnectors() { Shape = DecoratorShapes.None }, Style = new DiagramStrokeStyle() { StrokeWidth = 2, StrokeColor = "#757575" } });

            palettes = new List<SymbolPalettePalette>();
            palettes.Add(new SymbolPalettePalette() { Id = "flow", Expanded = true, Symbols = SymbolPaletee, IconCss = "e-ddb-icons e-basic", Title = "Flow Shapes" });
            palettes.Add(new SymbolPalettePalette() { Id = "basic", Expanded = true, Symbols = BasicNodes, IconCss = "e-ddb-icons e-flow", Title = "Basic Shapes" });
            palettes.Add(new SymbolPalettePalette() { Id = "connectors", Expanded = true, Symbols = connector, IconCss = "e-ddb-icons e-connector", Title = "Connectors" });

            expand = new List<ExpandOptions>();
            expand.Add(new ExpandOptions() { text = "Single", value = "single" });
            expand.Add(new ExpandOptions() { text = "Multiple", value = "multiple" });
            
             margin = new DiagramMargin() { Left = 15, Bottom = 15, Right = 15, Top = 15 };
    }
}
public class ExpandOptions
{
    public string text;
    public string value;
}