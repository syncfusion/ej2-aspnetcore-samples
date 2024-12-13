#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.EJ2.Diagrams;
using Syncfusion.EJ2.Navigations;

namespace EJ2CoreSampleBrowser.Pages.Diagram;

public class DiagramEventsModel : PageModel
{
    public List<object> data { get; set; }
    public  List<SymbolPalettePalette> Palettes { get; set; }
    public Enum Multiple { get; set; }
    
    public void OnGet()
    {
        data = new List<object>();
            data.Add(new { text= "Drag Enter", id= "dragEnter" });
            data.Add(new { text= "Drag Leave", id= "dragLeave"  });
            data.Add(new { text= "Drag Over", id= "dragOver"  });
            data.Add(new { text= "Click", id= "click", isChecked = true });
            data.Add(new { text= "History Change", id= "historyChange", isChecked = true });
            data.Add(new { text= "Double Click", id= "doubleClick"  });
            data.Add(new { text= "Text Edit", id= "textEdit", isChecked = true });
            data.Add(new { text= "Scroll Change", id= "scrollChange"  });
            data.Add(new { text= "Selection Change", id= "selectionChange", isChecked = true });
            data.Add(new { text= "Size Change", id= "sizeChange", isChecked = true });
            data.Add(new { text= "Connection Change", id= "connectionChange", isChecked = true });
            data.Add(new { text= "SourcePoint Change", id= "sourcePointChange"  });
            data.Add(new { text= "TargetPoint Change", id= "targetPointChange"  });
            data.Add(new { text= "Position Change", id= "positionChange", isChecked = true });
            data.Add(new { text= "Rotate Change", id= "rotateChange", isChecked = true });
            data.Add(new { text= "Collection Change", id= "collectionChange", isChecked = true });
            data.Add(new { text= "Mouse Enter", id= "mouseEnter"  });
            data.Add(new { text= "Mouse Leave", id= "mouseLeave"  });
            data.Add(new { text= "Mouse Over", id= "mouseOver"  });
            data.Add(new { text= "contextMenuOpen", id= "contextMenuOpen"  });
            data.Add(new { text= "contextMenuBeforeItemRender", id= "contextMenuBeforeItemRender"  });
            data.Add(new { text= "contextMenuClick", id= "contextMenuClick"  });

            List<DiagramNode> SymbolPaletee = new List<DiagramNode>();
            SymbolPaletee.Add(new DiagramNode() { Id = "Rectangle", Shape = new { type = "Basic", shape = "Rectangle" } });
            SymbolPaletee.Add(new DiagramNode() { Id = "Ellipse", Shape = new { type = "Basic", shape = "Ellipse" } });
            SymbolPaletee.Add(new DiagramNode() { Id = "Parallelogram", Shape = new { type = "Basic", shape = "Parallelogram" } });
            SymbolPaletee.Add(new DiagramNode() { Id = "Triangle", Shape = new { type = "Basic", shape = "Triangle" } });
            SymbolPaletee.Add(new DiagramNode() { Id = "Hexagon", Shape = new { type = "Basic", shape = "Hexagon" } });
            SymbolPaletee.Add(new DiagramNode() { Id = "Pentagon", Shape = new { type = "Basic", shape = "Pentagon" } });
            SymbolPaletee.Add(new DiagramNode() { Id = "Cylinder", Shape = new { type = "Basic", shape = "Cylinder" } });
            SymbolPaletee.Add(new DiagramNode() { Id = "Plus", Shape = new { type = "Basic", shape = "Plus" } });
            SymbolPaletee.Add(new DiagramNode() { Id = "Heptagon", Shape = new { type = "Basic", shape = "Heptagon" } });
            SymbolPaletee.Add(new DiagramNode() { Id = "Octagon", Shape = new { type = "Basic", shape = "Octagon" } });
            SymbolPaletee.Add(new DiagramNode() { Id = "Trapezoid", Shape = new { type = "Basic", shape = "Trapezoid" } });
            SymbolPaletee.Add(new DiagramNode() { Id = "Decagon", Shape = new { type = "Basic", shape = "Decagon" } });
            SymbolPaletee.Add(new DiagramNode() { Id = "RightTriangle", Shape = new { type = "Basic", shape = "RightTriangle" } });
            SymbolPaletee.Add(new DiagramNode() { Id = "Diamond", Shape = new { type = "Basic", shape = "Diamond" } });
            SymbolPaletee.Add(new DiagramNode() { Id = "Star", Shape = new { type = "Basic", shape = "Star" } });
            

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

            Palettes = new List<SymbolPalettePalette>
            {
                new SymbolPalettePalette() { Id = "basic", Expanded = true, Symbols = SymbolPaletee, IconCss = "e-ddb-icons e-basic", Title = "Basic Shapes" },
                new SymbolPalettePalette() { Id = "connectors", Expanded = true, Symbols = SymbolPaletteConnectors, IconCss = "e-ddb-icons e-connector", Title = "Connectors" }
            };
            
            Multiple = ExpandMode.Multiple;
    }
}