using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Diagrams;
using Syncfusion.EJ2.Navigations;

namespace EJ2CoreSampleBrowser.Controllers.Diagram
{
    public partial class DiagramController : Controller
    {
        public IActionResult FlowChart()
        {
            List<DiagramNode> Nodes = new List<DiagramNode>();
            List<DiagramNodeAnnotation> Node1 = new List<DiagramNodeAnnotation>();
            Node1.Add(new DiagramNodeAnnotation() { Content = "Place Order", Style = new DiagramTextStyle() { Color = "white", Fill = "transparent" } });

            List<DiagramNodeAnnotation> Node2 = new List<DiagramNodeAnnotation>();
            Node2.Add(new DiagramNodeAnnotation() { Content = "Start Transaction", Style = new DiagramTextStyle() { Color = "white", Fill = "transparent" } });

            List<DiagramNodeAnnotation> Node3 = new List<DiagramNodeAnnotation>();
            Node3.Add(new DiagramNodeAnnotation() { Content = "Verification", Style = new DiagramTextStyle() { Color = "white", Fill = "transparent" } });

            List<DiagramNodeAnnotation> Node4 = new List<DiagramNodeAnnotation>();
            Node4.Add(new DiagramNodeAnnotation() { Content = "Credit Card ValId?", Style = new DiagramTextStyle() { Color = "white", Fill = "transparent" } });

            List<DiagramNodeAnnotation> Node5 = new List<DiagramNodeAnnotation>();
            Node5.Add(new DiagramNodeAnnotation() { Content = "Funds Available", Style = new DiagramTextStyle() { Color = "white", Fill = "transparent" } });

            List<DiagramNodeAnnotation> Node6 = new List<DiagramNodeAnnotation>();
            Node6.Add(new DiagramNodeAnnotation() { Content = "Enter Payment Method", Style = new DiagramTextStyle() { Color = "white", Fill = "transparent" } });

            List<DiagramNodeAnnotation> Node7 = new List<DiagramNodeAnnotation>();
            Node7.Add(new DiagramNodeAnnotation() { Content = "Log Transaction", Style = new DiagramTextStyle() { Color = "white", Fill = "transparent" } });

            List<DiagramNodeAnnotation> Node8 = new List<DiagramNodeAnnotation>();
            Node8.Add(new DiagramNodeAnnotation() { Content = "Reconcile the entries", Style = new DiagramTextStyle() { Color = "white", Fill = "transparent" } });

            List<DiagramNodeAnnotation> Node9 = new List<DiagramNodeAnnotation>();
            Node9.Add(new DiagramNodeAnnotation() { Content = "Complete Transaction", Style = new DiagramTextStyle() { Color = "white", Fill = "transparent" } });

            List<DiagramNodeAnnotation> Node10 = new List<DiagramNodeAnnotation>();
            Node10.Add(new DiagramNodeAnnotation() { Content = "Send E-mail", Margin = new DiagramMargin() { Left = 25, Right = 25 }, Style = new DiagramTextStyle() { Color = "white", Fill = "transparent" } });

            List<DiagramNodeAnnotation> Node11 = new List<DiagramNodeAnnotation>();
            Node11.Add(new DiagramNodeAnnotation() { Content = "Customer Database", Margin = new DiagramMargin() { Left = 25, Right = 25 }, Style = new DiagramTextStyle() { Color = "white", Fill = "transparent" } });

            List<DiagramConnectorAnnotation> Connector1 = new List<DiagramConnectorAnnotation>();
            Connector1.Add(new DiagramConnectorAnnotation() { Content = "Yes", Style = new DiagramTextStyle() { Fill = "White" } });

            List<DiagramConnectorAnnotation> Connector2 = new List<DiagramConnectorAnnotation>();
            Connector2.Add(new DiagramConnectorAnnotation() { Content = "Yes", Style = new DiagramTextStyle() { Fill = "White" } });

            List<DiagramConnectorAnnotation> Connector3 = new List<DiagramConnectorAnnotation>();
            Connector3.Add(new DiagramConnectorAnnotation() { Content = "No", Style = new DiagramTextStyle() { Fill = "White" } });

            Nodes.Add(new DiagramNode()
            {
                Id = "NewIdea",
                OffsetY = 80,
                OffsetX = 340,
                Height = 60,
                Annotations = Node1,
                Shape = new { type = "Flow", shape = "Terminator" }
            });
            Nodes.Add(new DiagramNode()
            {
                Id = "Meeting",
                OffsetX = 340,
                OffsetY = 160,
                Height = 60,
                Annotations = Node2,
                Shape = new { type = "Flow", shape = "Process" }
            });
            Nodes.Add(new DiagramNode()
            {
                Id = "BoardDecision",
                OffsetX = 340,
                OffsetY = 240,
                Height = 60,
                Annotations = Node3,
                Shape = new { type = "Flow", shape = "Process" }
            });
            Nodes.Add(new DiagramNode()
            {
                Id = "Project",
                OffsetX = 340,
                OffsetY = 330,
                Height = 60,
                Annotations = Node4,
                Shape = new { type = "Flow", shape = "Decision" }
            });
            Nodes.Add(new DiagramNode()
            {
                Id = "End",
                OffsetY = 430,
                OffsetX = 340,
                Height = 60,
                Annotations = Node5,
                Shape = new { type = "Flow", shape = "Decision" }
            });
            Nodes.Add(new DiagramNode()
            {
                Id = "node11",
                OffsetY = 330,
                OffsetX = 550,
                Height = 60,
                Annotations = Node6,
                Shape = new { type = "Flow", shape = "Process" }
            });
            Nodes.Add(new DiagramNode()
            {
                Id = "transaction_entered",
                OffsetY = 630,
                OffsetX = 340,
                Height = 60,
                Annotations = Node7,
                Shape = new { type = "Flow", shape = "Terminator" }
            });
            Nodes.Add(new DiagramNode()
            {
                Id = "node12",
                OffsetY = 630,
                OffsetX = 550,
                Height = 60,
                Annotations = Node8,
                Shape = new { type = "Flow", shape = "Process" }
            });
            Nodes.Add(new DiagramNode()
            {
                Id = "transaction_completed",
                OffsetY = 530,
                OffsetX = 340,
                Height = 60,
                Annotations = Node9,
                Shape = new { type = "Flow", shape = "Process" }
            });
            Nodes.Add(new DiagramNode()
            {
                Id = "Data",
                OffsetY = 530,
                OffsetX = 120,
                Height = 60,
                Annotations = Node10,
                Shape = new { type = "Flow", shape = "Data" }
            });
            Nodes.Add(new DiagramNode()
            {
                Id = "node10",
                OffsetY = 530,
                OffsetX = 550,
                Height = 60,
                Annotations = Node11,
                Shape = new { type = "Flow", shape = "DirectData" }
            });

            List<DiagramConnector> Connectors = new List<DiagramConnector>();
            Connectors.Add(new DiagramConnector() { Id = "connector1", SourceID = "NewIdea", TargetID = "Meeting", });
            Connectors.Add(new DiagramConnector() { Id = "connector2", SourceID = "Meeting", TargetID = "BoardDecision" });
            Connectors.Add(new DiagramConnector() { Id = "connector3", SourceID = "BoardDecision", TargetID = "Project" });
            Connectors.Add(new DiagramConnector()
            {
                Id = "connector4",
                SourceID = "Project",
                TargetID = "End",
                Annotations = Connector1
            });
            Connectors.Add(new DiagramConnector()
            {
                Id = "connector5",
                SourceID = "End",
                TargetID = "transaction_completed",
                Annotations = Connector2
            });
            Connectors.Add(new DiagramConnector() { Id = "connector6", SourceID = "transaction_completed", TargetID = "transaction_entered" });
            Connectors.Add(new DiagramConnector() { Id = "connector7", SourceID = "transaction_completed", TargetID = "Data" });
            Connectors.Add(new DiagramConnector() { Id = "connector8", SourceID = "transaction_completed", TargetID = "node10" });
            Connectors.Add(new DiagramConnector() { Id = "connector9", SourceID = "node11", TargetID = "Meeting" });
            Connectors.Add(new DiagramConnector() { Id = "connector10", SourceID = "End", TargetID = "node11" });
            Connectors.Add(new DiagramConnector()
            {
                Id = "connector11",
                SourceID = "Project",
                TargetID = "node11",
                Annotations = Connector3
            });
            Connectors.Add(new DiagramConnector()
            {
                Id = "connector12",
                SourceID = "transaction_entered",
                TargetID = "node12",
                Style = new DiagramStrokeStyle() { StrokeDashArray = "2,2" }
            });
            ViewBag.nodes = Nodes;
            ViewBag.connectors = Connectors;

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



            List<DiagramConnector> SymbolPaletteConnectors = new List<DiagramConnector>();
            SymbolPaletteConnectors.Add(new DiagramConnector()
            {
                Id = "Link1",
                Type = Segments.Orthogonal,
                SourcePoint = new DiagramPoint() { X = 0, Y = 0 },
                TargetPoint = new DiagramPoint() { X = 40, Y = 40 },
                TargetDecorator = new ConnectorTargetDecoratorConnectors() { Shape = DecoratorShapes.Arrow },
                Style = new DiagramStrokeStyle() { StrokeWidth = 2 }
            });
            SymbolPaletteConnectors.Add(new DiagramConnector()
            {
                Id = "Link2",
                Type = Segments.Orthogonal,
                SourcePoint = new DiagramPoint() { X = 0, Y = 0 },
                TargetPoint = new DiagramPoint() { X = 40, Y = 40 },
                TargetDecorator = new ConnectorTargetDecoratorConnectors() { Shape = DecoratorShapes.None },
                Style = new DiagramStrokeStyle() { StrokeWidth = 2 }
            });
            SymbolPaletteConnectors.Add(new DiagramConnector()
            {
                Id = "Link3",
                Type = Segments.Straight,
                SourcePoint = new DiagramPoint() { X = 0, Y = 0 },
                TargetPoint = new DiagramPoint() { X = 40, Y = 40 },
                TargetDecorator = new ConnectorTargetDecoratorConnectors() { Shape = DecoratorShapes.Arrow },
                Style = new DiagramStrokeStyle() { StrokeWidth = 2 }
            });
            SymbolPaletteConnectors.Add(new DiagramConnector()
            {
                Id = "Link4",
                Type = Segments.Straight,
                SourcePoint = new DiagramPoint() { X = 0, Y = 0 },
                TargetPoint = new DiagramPoint() { X = 40, Y = 40 },
                TargetDecorator = new ConnectorTargetDecoratorConnectors() { Shape = DecoratorShapes.None },
                Style = new DiagramStrokeStyle() { StrokeWidth = 2 }
            });
            SymbolPaletteConnectors.Add(new DiagramConnector()
            {
                Id = "Link5",
                Type = Segments.Bezier,
                SourcePoint = new DiagramPoint() { X = 0, Y = 0 },
                TargetPoint = new DiagramPoint() { X = 40, Y = 40 },
                TargetDecorator = new ConnectorTargetDecoratorConnectors() { Shape = DecoratorShapes.None },
                Style = new DiagramStrokeStyle() { StrokeWidth = 2 }
            });

            List<SymbolPalettePalette> Palette = new List<SymbolPalettePalette>
            {
                new SymbolPalettePalette() { Id = "flow", Expanded = true, Symbols = SymbolPaletee, IconCss = "e-ddb-icons e-flow", Title = "Flow Shapes" },
                new SymbolPalettePalette() { Id = "connectors", Expanded = true, Symbols = SymbolPaletteConnectors, IconCss = "e-ddb-icons e-connector", Title = "Connectors" }
            };

            double[] intervals = { 1, 9, 0.25, 9.75, 0.25, 9.75, 0.25, 9.75, 0.25, 9.75, 0.25, 9.75, 0.25, 9.75, 0.25, 9.75, 0.25, 9.75, 0.25, 9.75 };
            DiagramGridlines grIdLines = new DiagramGridlines()
            { LineColor = "#e0e0e0", LineIntervals = intervals };
            ViewBag.gridLines = grIdLines;

            DiagramMargin margin = new DiagramMargin() { Left = 15, Right = 15, Bottom = 15, Top = 15 };
            ViewBag.margin = margin;
             

            ViewBag.Palette = Palette;
            ViewBag.Multiple = ExpandMode.Multiple;
            ViewBag.getSymbolNode = "getSymbolNodes";
            ViewBag.getNodeDefaults = "getNodeDefaults";
            ViewBag.getConnectorDefaults = "getConnectorDefaults";
            ViewBag.getSymbolInfo = "getSymbolInfo";
            return View();
        }
    }
}