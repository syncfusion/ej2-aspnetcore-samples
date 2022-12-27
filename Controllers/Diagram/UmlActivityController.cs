#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
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
using Syncfusion.EJ2.Navigations;

namespace EJ2CoreSampleBrowser.Controllers.Diagram
{
    public partial class DiagramController : Controller
    {
        public IActionResult UmlActivity()
        {
            List<DiagramNode> nodes = new List<DiagramNode>();
            List<DiagramNodeAnnotation> Node1 = new List<DiagramNodeAnnotation>();
            Node1.Add(new DiagramNodeAnnotation() { Content = "Receive Customer Call" });

            List<DiagramNodeAnnotation> Node3 = new List<DiagramNodeAnnotation>();
            Node3.Add(new DiagramNodeAnnotation() { Content = "Determine Type of Call" });

            List<DiagramNodeAnnotation> Node4 = new List<DiagramNodeAnnotation>();
            Node4.Add(new DiagramNodeAnnotation() { Content = "Customer Logging a Call" });

            List<DiagramNodeAnnotation> Node6 = new List<DiagramNodeAnnotation>();
            Node6.Add(new DiagramNodeAnnotation() { Content = "Transfer the Call to Sales" });

            List<DiagramNodeAnnotation> Node7 = new List<DiagramNodeAnnotation>();
            Node7.Add(new DiagramNodeAnnotation() { Content = "Transfer the Call to Help Desk" });

            List<DiagramNodeAnnotation> Node10 = new List<DiagramNodeAnnotation>();
            Node10.Add(new DiagramNodeAnnotation() { Content = "Close Call", Margin = new DiagramMargin() { Left = 25, Right = 25 } });

            List<DiagramConnectorAnnotation> Connector1 = new List<DiagramConnectorAnnotation>();
            Connector1.Add(new DiagramConnectorAnnotation() { Content = "Type = New Customer", Style = new DiagramTextStyle() { Fill = "White" } });

            List<DiagramConnectorAnnotation> Connector2 = new List<DiagramConnectorAnnotation>();
            Connector2.Add(new DiagramConnectorAnnotation() { Content = "Type = Existing Customer", Style = new DiagramTextStyle() { Fill = "White" } });
            nodes.Add(new DiagramNode()
            {
                Id = "Start",
                OffsetX = 288,
                OffsetY = 25.5,
                Height = 40,
                Width = 40,
                Shape = new { type = "UmlActivity", shape = "InitialNode" }
            });
            nodes.Add(new DiagramNode()
            {
                Id = "ReceiveCall",
                OffsetX = 288,
                OffsetY = 85.5,
                Height = 40,
                Width = 105,
                Annotations = Node1,
                Shape = new { type = "UmlActivity", shape = "Action" }
            });
            nodes.Add(new DiagramNode()
            {
                Id = "node2",
                OffsetX = 288,
                OffsetY = 130.5,
                Height = 10,
                Width = 70,
                Shape = new { type = "UmlActivity", shape = "ForkNode" }
            });
            nodes.Add(new DiagramNode()
            {
                Id = "Determine",
                OffsetX = 168,
                OffsetY = 210.5,
                Height = 40,
                Width = 105,
                Annotations = Node3,
                Shape = new { type = "UmlActivity", shape = "Action" }
            });
            nodes.Add(new DiagramNode()
            {
                Id = "Log",
                OffsetX = 408,
                OffsetY = 210.5,
                Height = 40,
                Width = 105,
                Annotations = Node4,
                Shape = new { type = "UmlActivity", shape = "Action" }
            });
            nodes.Add(new DiagramNode()
            {
                Id = "node5",
                OffsetX = 168,
                OffsetY = 290.5,
                Height = 50,
                Width = 50,
                Shape = new { type = "UmlActivity", shape = "Decision" }
            });
            nodes.Add(new DiagramNode()
            {
                Id = "transfer_sales",
                OffsetX = 88,
                OffsetY = 360.5,
                Height = 40,
                Width = 105,
                Annotations = Node6,
                Shape = new { type = "UmlActivity", shape = "Action" }
            });
            nodes.Add(new DiagramNode()
            {
                Id = "transfer_desk",
                OffsetX = 263,
                OffsetY = 360.5,
                Height = 40,
                Width = 105,
                Annotations = Node7,
                Shape = new { type = "UmlActivity", shape = "Action" }
            });
            nodes.Add(new DiagramNode()
            {
                Id = "node8",
                OffsetX = 168,
                OffsetY = 430.5,
                Height = 50,
                Width = 50,
                Shape = new { type = "UmlActivity", shape = "MergeNode" }
            });
            nodes.Add(new DiagramNode()
            {
                Id = "node9",
                OffsetX = 288,
                OffsetY = 500.5,
                Height = 10,
                Width = 70,
                Shape = new { type = "UmlActivity", shape = "JoinNode" }
            });
            nodes.Add(new DiagramNode()
            {
                Id = "CloseCall",
                OffsetX = 288,
                OffsetY = 550.5,
                Height = 40,
                Width = 105,
                Annotations = Node10,
                Shape = new { type = "UmlActivity", shape = "Action" }
            });
            nodes.Add(new DiagramNode()
            {
                Id = "node11",
                OffsetX = 288,
                OffsetY = 615.5,
                Height = 40,
                Width = 40,
                Shape = new { type = "UmlActivity", shape = "FinalNode" }
            });
            List<DiagramSegment> segments = new List<DiagramSegment>();
            segments.Add(new DiagramSegment() { Type = "Orthogonal", Length = 213, Direction = "Bottom" });
            segments.Add(new DiagramSegment() { Type = "Orthogonal", Length = 50, Direction = "Left" });
            List<DiagramConnector> Connectors = new List<DiagramConnector>();
            Connectors.Add(new DiagramConnector() { Id = "connector1", SourceID = "Start", TargetID = "ReceiveCall", });
            Connectors.Add(new DiagramConnector() { Id = "connector2", SourceID = "ReceiveCall", TargetID = "node2" });
            Connectors.Add(new DiagramConnector() { Id = "connector3", SourceID = "node2", TargetID = "Determine", SourcePortID = "port1", TargetPortID = "portTop" });
            Connectors.Add(new DiagramConnector() { Id = "connector4", SourceID = "node2", TargetID = "Log", SourcePortID = "port2", TargetPortID = "portTop" });
            Connectors.Add(new DiagramConnector() { Id = "connector5", SourceID = "Determine", TargetID = "node5", });
            Connectors.Add(new DiagramConnector() { Id = "connector6", SourceID = "node5", TargetID = "transfer_sales", Annotations = Connector1, SourcePortID = "portLeft", TargetPortID = "portTop", });
            Connectors.Add(new DiagramConnector() { Id = "connector7", SourceID = "node5", TargetID = "transfer_desk", Annotations = Connector2, SourcePortID = "portRight", TargetPortID = "portTop", });
            Connectors.Add(new DiagramConnector() { Id = "connector8", SourceID = "transfer_sales", TargetID = "node8", SourcePortID = "portBottom", TargetPortID = "portLeft" });
            Connectors.Add(new DiagramConnector() { Id = "connector9", SourceID = "transfer_desk", TargetID = "node8", SourcePortID = "portBottom", TargetPortID = "portRight" });
            Connectors.Add(new DiagramConnector() { Id = "connector10", SourceID = "node8", TargetID = "node9", SourcePortID = "portBottom", TargetPortID = "port3" });
            Connectors.Add(new DiagramConnector() { Id = "connector11", SourceID = "Log", TargetID = "node9", SourcePortID = "portBottom", TargetPortID = "port4", Segments = segments });
            Connectors.Add(new DiagramConnector() { Id = "connector12", SourceID = "node9", TargetID = "CloseCall", });
            Connectors.Add(new DiagramConnector() { Id = "connector13", SourceID = "CloseCall", TargetID = "node11", });
            ViewBag.nodes = nodes;
            ViewBag.connectors = Connectors;

            List<Syncfusion.EJ2.Diagrams.DiagramNode> umlShapes = new List<Syncfusion.EJ2.Diagrams.DiagramNode>();
            umlShapes.Add(new DiagramNode() { Id = "Action", Shape = new { type = "UmlActivity", shape = "Action" } });
            umlShapes.Add(new DiagramNode() { Id = "Decision", Shape = new { type = "UmlActivity", shape = "Decision" } });
            umlShapes.Add(new DiagramNode() { Id = "MergeNode", Shape = new { type = "UmlActivity", shape = "MergeNode" } });
            umlShapes.Add(new DiagramNode() { Id = "InitialNode", Shape = new { type = "UmlActivity", shape = "InitialNode" } });
            umlShapes.Add(new DiagramNode() { Id = "FinalNode", Shape = new { type = "UmlActivity", shape = "FinalNode" } });
            umlShapes.Add(new DiagramNode() { Id = "ForkNode", Shape = new { type = "UmlActivity", shape = "ForkNode" } });
            umlShapes.Add(new DiagramNode() { Id = "JoinNode", Shape = new { type = "UmlActivity", shape = "JoinNode" } });
            umlShapes.Add(new DiagramNode() { Id = "TimeEvent", Shape = new { type = "UmlActivity", shape = "TimeEvent" } });
            umlShapes.Add(new DiagramNode() { Id = "AcceptingEvent", Shape = new { type = "UmlActivity", shape = "AcceptingEvent" } });
            umlShapes.Add(new DiagramNode() { Id = "SendSignal", Shape = new { type = "UmlActivity", shape = "SendSignal" } });
            umlShapes.Add(new DiagramNode() { Id = "ReceiveSignal", Shape = new { type = "UmlActivity", shape = "ReceiveSignal" } });
            umlShapes.Add(new DiagramNode() { Id = "StructuredNode", Shape = new { type = "UmlActivity", shape = "StructuredNode" } });
            umlShapes.Add(new DiagramNode() { Id = "Note", Shape = new { type = "UmlActivity", shape = "Note" } });

            DiagramPoint sourcePoint = new DiagramPoint() { X = 0, Y = 0 };
            DiagramPoint targetPoint = new DiagramPoint() { X = 40, Y = 40 };
            ConnectorTargetDecoratorConnectors targetDecorator = new ConnectorTargetDecoratorConnectors() { Shape = DecoratorShapes.Arrow, Style = new DiagramShapeStyle() { Fill = "#757575", StrokeColor = "#757575" } };
            DiagramStrokeStyle style1 = new DiagramStrokeStyle() { StrokeWidth = 2, StrokeColor = "#757575", StrokeDashArray = "4 4" };
            DiagramStrokeStyle style2 = new DiagramStrokeStyle() { StrokeWidth = 2, StrokeColor = "#757575" };
            List<DiagramConnector> SymbolPaletteConnectors = new List<DiagramConnector>();
            SymbolPaletteConnectors.Add(new DiagramConnector()
            {
                Id = "Link1",
                Type = Segments.Orthogonal,
                SourcePoint = sourcePoint,
                TargetPoint = targetPoint,
                TargetDecorator = targetDecorator,
                Style = style1
            });
            SymbolPaletteConnectors.Add(new DiagramConnector()
            {
                Id = "Link2",
                Type = Segments.Orthogonal,
                SourcePoint = sourcePoint,
                TargetPoint = targetPoint,
                TargetDecorator = targetDecorator,
                Style = style2
            });
            SymbolPaletteConnectors.Add(new DiagramConnector()
            {
                Id = "Link3",
                Type = Segments.Straight,
                SourcePoint = sourcePoint,
                TargetPoint = targetPoint,
                TargetDecorator = targetDecorator,
                Style = style2
            });

            List<SymbolPalettePalette> Palette = new List<SymbolPalettePalette>();
            Palette.Add(new SymbolPalettePalette() { Id = "UMLActivity", Expanded = true, Symbols = umlShapes, Title = "UML Shapes" });
            Palette.Add(new SymbolPalettePalette() { Id = "connectors", Expanded = true, Symbols = SymbolPaletteConnectors, Title = "Connectors" });

            ViewBag.Palette = Palette;

            SymbolPaletteMargin margin = new SymbolPaletteMargin() { Left = 15, Right = 15, Bottom = 15, Top = 15 };
            ViewBag.margin = margin;
            ViewBag.Multiple = ExpandMode.Multiple;
            ViewBag.getSymbolDefaults = "getSymbolDefaults";
            ViewBag.getNodeDefaults = "getNodeDefaults";
            ViewBag.getConnectorDefaults = "getConnectorDefaults";
            ViewBag.getSymbolInfo = "getSymbolInfo";
            return View();
        }
    }
}
