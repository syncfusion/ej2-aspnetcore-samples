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

public class SerializationModel : PageModel
{
    public List<DiagramConnector> Connectors { get; set; }
    public List<DiagramNode> Nodes { get; set; }
    public List<SymbolPalettePalette> Palette { get; set; }
    public List<DiagramConnector> SymbolPaletteConnectors { get; set; }
    public DiagramGridlines gridLines { get; set; }
    public DiagramMargin margin { get; set; }
    public void OnGet()
    {
         List<DiagramNodeAnnotation> Node1 = new List<DiagramNodeAnnotation>();
            Node1.Add(new DiagramNodeAnnotation() { Content = "Start" });
            List<DiagramNodeAnnotation> Node2 = new List<DiagramNodeAnnotation>();
            Node2.Add(new DiagramNodeAnnotation() { Content = "Alarm Rings" });
            List<DiagramNodeAnnotation> Node3 = new List<DiagramNodeAnnotation>();
            Node3.Add(new DiagramNodeAnnotation() { Content = "Ready to Get Up" });
            List<DiagramNodeAnnotation> Node4 = new List<DiagramNodeAnnotation>();
            Node4.Add(new DiagramNodeAnnotation() { Content = "Climb Out of Bed" });
            List<DiagramNodeAnnotation> Node5 = new List<DiagramNodeAnnotation>();
            Node5.Add(new DiagramNodeAnnotation() { Content = "End" });
            List<DiagramNodeAnnotation> Node6 = new List<DiagramNodeAnnotation>();
            Node6.Add(new DiagramNodeAnnotation() { Content = "Relay" });
            List<DiagramNodeAnnotation> Node7 = new List<DiagramNodeAnnotation>();
            Node7.Add(new DiagramNodeAnnotation() { Content = "Hit Snooze Button", Margin = new DiagramMargin() { Left = 10, Right = 10, Bottom = 10, Top = 10 } });
            Nodes = new List<DiagramNode>();

            List<DiagramConnectorAnnotation> Connector1 = new List<DiagramConnectorAnnotation>();
            Connector1.Add(new DiagramConnectorAnnotation() { Content = "Yes", Style = new DiagramTextStyle() { Fill = "White" } });

            List<DiagramConnectorAnnotation> Connector2 = new List<DiagramConnectorAnnotation>();
            Connector2.Add(new DiagramConnectorAnnotation() { Content = "No", Style = new DiagramTextStyle() { Fill = "White" } });

            Nodes.Add(new DiagramNode()
            {
                Id = "Start",
                OffsetX = 250,
                OffsetY = 60,
				Width = 100,
				Height = 50, 
                Style = new DiagramShapeStyle() { Fill = "#d0f0f1", StrokeColor = "#797979" },
                Annotations = Node1,
                Shape = new { type = "Flow", shape = "Terminator" }
            });
            Nodes.Add(new DiagramNode()
            {
                Id = "Alarm",
                OffsetX = 250,
                OffsetY = 160,
				Width = 100,
				Height = 50,
                Style = new DiagramShapeStyle() { Fill = "#fbfdc5", StrokeColor = "#797979" },
                Annotations = Node2,
                Shape = new { type = "Flow", shape = "Process" }
            });
            Nodes.Add(new DiagramNode()
            {
                Id = "Ready",
                OffsetX = 250,
                OffsetY = 260,
				Width = 100,
                Height = 80,
                Style = new DiagramShapeStyle() { Fill = "#c5efaf", StrokeColor = "#797979" },
                Annotations = Node3,
                Shape = new { type = "Flow", shape = "Decision" }
            });
            Nodes.Add(new DiagramNode()
            {
                Id = "Climb",
                OffsetX = 250,
                OffsetY = 370,
				Width = 100,
				Height = 50,
                Style = new DiagramShapeStyle() { Fill = "#fbfdc5", StrokeColor = "#797979" },
                Annotations = Node4,
                Shape = new { type = "Flow", shape = "Process" }
            });
            Nodes.Add(new DiagramNode()
            {
                Id = "End",
                OffsetX = 250,
                OffsetY = 460,
				Width = 100,
				Height = 50,
                Style = new DiagramShapeStyle() { Fill = "#d0f0f1", StrokeColor = "#797979" },
                Annotations = Node5,
                Shape = new { type = "Flow", shape = "Terminator" }
            });
            Nodes.Add(new DiagramNode()
            {
                Id = "Relay",
                OffsetX = 450,
                OffsetY = 160,
				Width = 100,
				Height = 50,
                Style = new DiagramShapeStyle() { Fill = "#f8eee5", StrokeColor = "#797979" },
                Annotations = Node6,
                Shape = new { type = "Flow", shape = "Delay" }
            });
            Nodes.Add(new DiagramNode()
            {
                Id = "Hit",
                OffsetX = 450,
                OffsetY = 260,
				Width = 100,
				Height = 50,
                Style = new DiagramShapeStyle() { Fill = "#fbfdc5", StrokeColor = "#797979" },
                Annotations = Node7,
                Shape = new { type = "Flow", shape = "Process" }
            });

            Connectors = new List<DiagramConnector>();
            Connectors.Add(new DiagramConnector() { Id = "connector1", SourceID = "Start", TargetID = "Alarm",  });
            Connectors.Add(new DiagramConnector() { Id = "connector2", SourceID = "Alarm", TargetID = "Ready" });
            Connectors.Add(new DiagramConnector() { Id = "connector3", SourceID = "Ready", TargetID = "Climb", Annotations = Connector1 });
            Connectors.Add(new DiagramConnector() { Id = "connector4", SourceID = "Climb", TargetID = "End" });
            Connectors.Add(new DiagramConnector() { Id = "connector5", SourceID = "Ready", TargetID = "Hit", Annotations = Connector2 });
            Connectors.Add(new DiagramConnector() { Id = "connector6", SourceID = "Hit", TargetID = "Relay" });
            Connectors.Add(new DiagramConnector() { Id = "connector7", SourceID = "Relay", TargetID = "Alarm" });
           
            List<DiagramNode> SymbolPaletee = new List<DiagramNode>();
            SymbolPaletee.Add(new DiagramNode() { Id = "Terminator", Shape = new { type = "Flow", shape = "Terminator" } });
            SymbolPaletee.Add(new DiagramNode() { Id = "Process", Shape = new { type = "Flow", shape = "Process" } });
            SymbolPaletee.Add(new DiagramNode() { Id = "Decision", Shape = new { type = "Flow", shape = "Decision" } });
            SymbolPaletee.Add(new DiagramNode() { Id = "Document", Shape = new { type = "Flow", shape = "Document" } });
            SymbolPaletee.Add(new DiagramNode() { Id = "PreDefinedProcess", Shape = new { type = "Flow", shape = "PreDefinedProcess" } });
            SymbolPaletee.Add(new DiagramNode() { Id = "PaperTap", Shape = new { type = "Flow", shape = "PaperTap" } });
            SymbolPaletee.Add(new DiagramNode() { Id = "DirectData", Shape = new { type = "Flow", shape = "DirectData" } });
            SymbolPaletee.Add(new DiagramNode() { Id = "SequentialData", Shape = new { type = "Flow", shape = "SequentialData" } });
            SymbolPaletee.Add(new DiagramNode() { Id = "Sort", Shape = new { type = "Flow", shape = "Sort" } });
            SymbolPaletee.Add(new DiagramNode() { Id = "MultiDocument", Shape = new { type = "Flow", shape = "MultiDocument" } });
            SymbolPaletee.Add(new DiagramNode() { Id = "Collate", Shape = new { type = "Flow", shape = "Collate" } });
            SymbolPaletee.Add(new DiagramNode() { Id = "SummingJunction", Shape = new { type = "Flow", shape = "SummingJunction" } });
            SymbolPaletee.Add(new DiagramNode() { Id = "Or", Shape = new { type = "Flow", shape = "Or" } });
            SymbolPaletee.Add(new DiagramNode() { Id = "InternalStorage", Shape = new { type = "Flow", shape = "InternalStorage" } });
            SymbolPaletee.Add(new DiagramNode() { Id = "Extract", Shape = new { type = "Flow", shape = "Extract" } });
            SymbolPaletee.Add(new DiagramNode() { Id = "ManualOperation", Shape = new { type = "Flow", shape = "ManualOperation" } });
            SymbolPaletee.Add(new DiagramNode() { Id = "Merge", Shape = new { type = "Flow", shape = "Merge" } });
            SymbolPaletee.Add(new DiagramNode() { Id = "OffPageReference", Shape = new { type = "Flow", shape = "OffPageReference" } });
            SymbolPaletee.Add(new DiagramNode() { Id = "SequentialAccessStorage", Shape = new { type = "Flow", shape = "SequentialAccessStorage" } });
            SymbolPaletee.Add(new DiagramNode() { Id = "Annotation", Shape = new { type = "Flow", shape = "Annotation" } });
            SymbolPaletee.Add(new DiagramNode() { Id = "Annotation2", Shape = new { type = "Flow", shape = "Annotation2" } });
            SymbolPaletee.Add(new DiagramNode() { Id = "Data", Shape = new { type = "Flow", shape = "Data" } });
            SymbolPaletee.Add(new DiagramNode() { Id = "Card", Shape = new { type = "Flow", shape = "Card" } });
            SymbolPaletee.Add(new DiagramNode() { Id = "Delay", Shape = new { type = "Flow", shape = "Delay" } });


            SymbolPaletteConnectors = new List<DiagramConnector>();
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

            Palette = new List<SymbolPalettePalette>();
            Palette.Add(new SymbolPalettePalette() { Id = "flow", Expanded = true, Symbols = SymbolPaletee, IconCss = "e-ddb-icons1 e-flow", Title = "Flow Shapes" });
            Palette.Add(new SymbolPalettePalette() { Id = "connectors", Expanded = true, Symbols = SymbolPaletteConnectors, IconCss = "e-ddb-icons1 e-connector", Title = "Connectors" });

            

            double[] intervals = { 1, 9, 0.25, 9.75, 0.25, 9.75, 0.25, 9.75, 0.25, 9.75, 0.25, 9.75, 0.25, 9.75, 0.25, 9.75, 0.25, 9.75, 0.25, 9.75 };
            gridLines = new DiagramGridlines()
            { LineColor = "#e0e0e0", LineIntervals = intervals };

            margin = new DiagramMargin() { Left = 15, Right = 15, Bottom = 15, Top = 15 };
            
    }
}