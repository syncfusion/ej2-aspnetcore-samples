#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Diagrams;

namespace EJ2CoreSampleBrowser.Controllers.Diagram
{
    public partial class DiagramController : Controller
    {
        public ActionResult Scrolling()
        {
            List<DiagramNode> basicShapes = new List<DiagramNode>();
            basicShapes.Add(new DiagramNode() { Id = "Rectangle", Shape = new { type = "Basic", shape = "Rectangle" },Style=new {StrokeWidth =2}});
            basicShapes.Add(new DiagramNode() { Id = "Ellipse", Shape = new { type = "Basic", shape = "Ellipse" }, Style = new  { StrokeWidth = 2 } });
            basicShapes.Add(new DiagramNode() { Id = "Hexagon", Shape = new { type = "Basic", shape = "Hexagon" }, Style = new  { StrokeWidth = 2 } });
            basicShapes.Add(new DiagramNode() { Id = "Parallelogram", Shape = new { type = "Basic", shape = "Parallelogram" }, Style = new  { StrokeWidth = 2 } });
            basicShapes.Add(new DiagramNode() { Id = "Triangle", Shape = new { type = "Basic", shape = "Triangle" }, Style = new  { StrokeWidth = 2 } });
            basicShapes.Add(new DiagramNode() { Id = "Plus", Shape = new { type = "Basic", shape = "Plus" }, Style = new  { StrokeWidth = 2 } });
            basicShapes.Add(new DiagramNode() { Id = "Star", Shape = new { type = "Basic", shape = "Star" }, Style = new  { StrokeWidth = 2 } });
            basicShapes.Add(new DiagramNode() { Id = "Pentagon", Shape = new { type = "Basic", shape = "Pentagon" }, Style = new  { StrokeWidth = 2 } });
            basicShapes.Add(new DiagramNode() { Id = "Heptagon", Shape = new { type = "Basic", shape = "Heptagon" }, Style = new  { StrokeWidth = 2 } });
            basicShapes.Add(new DiagramNode() { Id = "Octagon", Shape = new { type = "Basic", shape = "Octagon" }, Style = new  { StrokeWidth = 2 } });
            basicShapes.Add(new DiagramNode() { Id = "Trapezoid", Shape = new { type = "Basic", shape = "Trapezoid" }, Style = new  { StrokeWidth = 2 } });
            basicShapes.Add(new DiagramNode() { Id = "Decagon", Shape = new { type = "Basic", shape = "Decagon" }, Style = new  { StrokeWidth = 2 } });
            basicShapes.Add(new DiagramNode() { Id = "RightTriangle", Shape = new { type = "Basic", shape = "RightTriangle" }, Style = new  { StrokeWidth = 2 } });
            basicShapes.Add(new DiagramNode() { Id = "Cylinder", Shape = new { type = "Basic", shape = "Cylinder" }, Style = new  { StrokeWidth = 2 } });
            basicShapes.Add(new DiagramNode() { Id = "Diamond", Shape = new { type = "Basic", shape = "Diamond" }, Style = new  { StrokeWidth = 2 } });
            ViewBag.BasicShapes = basicShapes;

            List<DiagramConnector> SymbolPaletteConnectors = new List<DiagramConnector>();
            SymbolPaletteConnectors.Add(new DiagramConnector()
            {
                Id = "Link1",
                Type = Segments.Orthogonal,
                SourcePoint = new DiagramPoint() { X = 0, Y = 0 },
                TargetPoint = new DiagramPoint() { X = 40, Y = 40 },
                TargetDecorator = new ConnectorTargetDecoratorConnectors() { Shape = DecoratorShapes.Arrow, Style = new DiagramShapeStyle() { StrokeColor = "#757575", Fill = "#757575" } },
                Style = new DiagramStrokeStyle() { StrokeWidth = 2, StrokeColor = "#757575" }
            });
            SymbolPaletteConnectors.Add(new DiagramConnector()
            {
                Id = "Link2",
                Type = Segments.Orthogonal,
                SourcePoint = new DiagramPoint() { X = 0, Y = 0 },
                TargetPoint = new DiagramPoint() { X = 40, Y = 40 },
                TargetDecorator = new ConnectorTargetDecoratorConnectors() { Shape = DecoratorShapes.None },
                Style = new DiagramStrokeStyle() { StrokeWidth = 2, StrokeColor = "#757575" }
            });
            SymbolPaletteConnectors.Add(new DiagramConnector()
            {
                Id = "Link3",
                Type = Segments.Straight,
                SourcePoint = new DiagramPoint() { X = 0, Y = 0 },
                TargetPoint = new DiagramPoint() { X = 40, Y = 40 },
                TargetDecorator = new ConnectorTargetDecoratorConnectors() { Shape = DecoratorShapes.Arrow, Style = new DiagramShapeStyle() { StrokeColor = "#757575", Fill = "#757575" } },
                Style = new DiagramStrokeStyle() { StrokeWidth = 2, StrokeColor = "#757575" }
            });
            SymbolPaletteConnectors.Add(new DiagramConnector()
            {
                Id = "Link4",
                Type = Segments.Straight,
                SourcePoint = new DiagramPoint() { X = 0, Y = 0 },
                TargetPoint = new DiagramPoint() { X = 40, Y = 40 },
                TargetDecorator = new ConnectorTargetDecoratorConnectors() { Shape = DecoratorShapes.None },
                Style = new DiagramStrokeStyle() { StrokeWidth = 2, StrokeColor = "#757575" }
            });
            SymbolPaletteConnectors.Add(new DiagramConnector()
            {
                Id = "Link5",
                Type = Segments.Bezier,
                SourcePoint = new DiagramPoint() { X = 0, Y = 0 },
                TargetPoint = new DiagramPoint() { X = 40, Y = 40 },
                TargetDecorator = new ConnectorTargetDecoratorConnectors() { Shape = DecoratorShapes.None },
                Style = new DiagramStrokeStyle() { StrokeWidth = 2, StrokeColor = "#757575" }
            });

            List<SymbolPalettePalette> Palette = new List<SymbolPalettePalette>();
            Palette.Add(new SymbolPalettePalette() { Id = "basic", Expanded = true, Symbols = basicShapes, IconCss = "shapes", Title = "Basic Shapes" });
            Palette.Add(new SymbolPalettePalette() { Id = "connectors", Expanded = true, Symbols = SymbolPaletteConnectors, IconCss = "e-ddb-icons e-connector", Title = "Connectors" });
            ViewBag.Palette = Palette;
            return View();
        }
      
    }
}