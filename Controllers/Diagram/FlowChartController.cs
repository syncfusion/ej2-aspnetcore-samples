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
            Connectors.Add(new DiagramConnector() { Id = "connector9", SourceID = "node11", TargetID = "Meeting",  Type = Segments.Orthogonal, });
            Connectors.Add(new DiagramConnector() { Id = "connector10", SourceID = "End", TargetID = "node11",  Type = Segments.Orthogonal, });
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
                TargetDecorator = new ConnectorTargetDecoratorConnectors() { Shape = DecoratorShapes.Arrow, Style = new DiagramShapeStyle() { StrokeColor = "#757575", Fill = "#757575"} },
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

            List<ToolbarItem> items = new List<ToolbarItem>();
            {
                items.Add(new ToolbarItem { PrefixIcon = "e-icons e-circle-add", TooltipText = "New Diagram" });
                items.Add(new ToolbarItem { PrefixIcon = "e-icons e-folder-open", TooltipText = "Open Diagram" });
                items.Add(new ToolbarItem { PrefixIcon = "e-icons e-save", TooltipText = "Save Diagram" });
                items.Add(new ToolbarItem { PrefixIcon = "e-print e-icons", TooltipText = "Print Diagram" });
                items.Add(new ToolbarItem { Template = "#exportBtn", Type = ItemType.Input, TooltipText = "Export Diagram" });
                items.Add(new ToolbarItem { Type = ItemType.Separator });
                items.Add(new ToolbarItem { PrefixIcon = "e-cut e-icons", TooltipText = "Cut", Disabled = true });
                items.Add(new ToolbarItem { PrefixIcon = "e-copy e-icons", TooltipText = "Copy", Disabled = true });
                items.Add(new ToolbarItem { PrefixIcon = "e-icons e-paste", TooltipText = "Paste", Disabled = true });
                items.Add(new ToolbarItem { Type = ItemType.Separator });
                items.Add(new ToolbarItem { PrefixIcon = "e-icons e-undo", TooltipText = "Undo", Disabled = true });
                items.Add(new ToolbarItem { PrefixIcon = "e-icons e-redo", TooltipText = "Redo", Disabled = true });
                items.Add(new ToolbarItem { Type = ItemType.Separator });
                items.Add(new ToolbarItem { PrefixIcon = "e-pan e-icons", TooltipText = "Pan Tool", CssClass = "tb-item-start pan-item" });
                items.Add(new ToolbarItem { PrefixIcon = "e-mouse-pointer e-icons", TooltipText = "Select Tool", CssClass = "tb-item-middle tb-item-selected" });
                items.Add(new ToolbarItem { Template = "#conTypeBtn", Type = ItemType.Input, TooltipText = "Draw Connectors", CssClass = "tb-item-middle" });
                items.Add(new ToolbarItem { Template = "#shapesBtn", Type = ItemType.Input, TooltipText = "Draw Shapes", CssClass = "tb-item-middle" });
                items.Add(new ToolbarItem { PrefixIcon = "e-caption e-icons", TooltipText = "Text Tool", CssClass = "tb-item-end" });
                items.Add(new ToolbarItem { Type = ItemType.Separator });
                items.Add(new ToolbarItem { PrefixIcon = "e-icons e-lock", TooltipText = "Lock", Disabled = true, CssClass = "tb-item-middle tb-item-lock-category" });
                items.Add(new ToolbarItem { PrefixIcon = "e-trash e-icons", TooltipText = "Delete", Disabled = true, CssClass = "tb-item-middle tb-item-lock-category" });
                items.Add(new ToolbarItem { Type = ItemType.Separator });
                items.Add(new ToolbarItem { Template = "#alignBtn", Type = ItemType.Input, TooltipText = "Align Objects", CssClass = "tb-item-middle  tb-item-align-category item-double-lock" });
                items.Add(new ToolbarItem { Template = "#distributeBtn", Type = ItemType.Input, TooltipText = "Distribute Objects", CssClass = "tb-item-middle tb-item-space-category item-tripple-lock" });
                items.Add(new ToolbarItem { Type = ItemType.Separator });
                items.Add(new ToolbarItem { Template = "#orderBtn", Type = ItemType.Input, TooltipText = "Order Commands", CssClass = "tb-item-middle tb-item-lock-category item-single-lock" });
                items.Add(new ToolbarItem { Type = ItemType.Separator });
                items.Add(new ToolbarItem { Template = "#groupBtn", Type = ItemType.Input, TooltipText = "Group/Ungroup", CssClass = "tb-item-middle  tb-item-align-category item-double-lock" });
                items.Add(new ToolbarItem { Type = ItemType.Separator });
                items.Add(new ToolbarItem { Template = "#rotateBtn", Type = ItemType.Input, TooltipText = "Rotate", CssClass = "tb-item-middle tb-item-lock-category item-single-lock" });
                items.Add(new ToolbarItem { Type = ItemType.Separator });
                items.Add(new ToolbarItem { Template = "#flipBtn", Type = ItemType.Input, TooltipText = "Flip", CssClass = "tb-item-middle tb-item-lock-category item-single-lock" });
                items.Add(new ToolbarItem { Type = ItemType.Separator });
                items.Add(new ToolbarItem { Template = "#btnZoomIncrement", Type = ItemType.Input, CssClass = "tb-item-end tb-zoom-dropdown-btn" });
            }
            ViewBag.tbItems = items;
            List<MenuItems> exportItems = new List<MenuItems>();
            {
                exportItems.Add(new MenuItems { Text = "JPG" });
                exportItems.Add(new MenuItems { Text = "PNG" });
                exportItems.Add(new MenuItems { Text = "SVG" });
            }
            ViewBag.exportItems = exportItems;
            List<ContextMenuItem> conTypeItems = new List<ContextMenuItem>();
            {
                conTypeItems.Add(new ContextMenuItem { Text = "Straight", IconCss = "e-icons e-line" });
                conTypeItems.Add(new ContextMenuItem { Text = "Orthogonal", IconCss = "sf-icon-orthogonal" });
                conTypeItems.Add(new ContextMenuItem { Text = "Bezier", IconCss = "sf-icon-bezier" });
            }
            ViewBag.conTypeItems = conTypeItems;
            List<ContextMenuItem> shapesItems = new List<ContextMenuItem>();
            {
                shapesItems.Add(new ContextMenuItem { Text = "Rectangle", IconCss = "e-rectangle e-icons" });
                shapesItems.Add(new ContextMenuItem { Text = "Ellipse", IconCss = " e-circle e-icons" });
                shapesItems.Add(new ContextMenuItem { Text = "Polygon", IconCss = "e-line e-icons" });
            }
            ViewBag.shapesItems = shapesItems;
            List<ContextMenuItem> alignItems = new List<ContextMenuItem>();
            {
                alignItems.Add(new ContextMenuItem { Text = "Align Left", IconCss = "sf-icon-align-left-1" });
                alignItems.Add(new ContextMenuItem { Text = "Align Center", IconCss = "sf-icon-align-center-1" });
                alignItems.Add(new ContextMenuItem { Text = "Align Right", IconCss = "sf-icon-align-right-1" });
                alignItems.Add(new ContextMenuItem { Text = "Align Top", IconCss = "sf-icon-align-top-1" });
                alignItems.Add(new ContextMenuItem { Text = "Align Middle", IconCss = "sf-icon-align-middle-1" });
                alignItems.Add(new ContextMenuItem { Text = "Align Bottom", IconCss = "sf-icon-align-bottom-1" });
            }
            ViewBag.alignItems = alignItems;
            List<ContextMenuItem> distributeItems = new List<ContextMenuItem>();
            {
                distributeItems.Add(new ContextMenuItem { Text = "Distribute Objects Vertically", IconCss = "sf-icon-distribute-vertical" });
                distributeItems.Add(new ContextMenuItem { Text = "Distribute Objects Horizontally", IconCss = "sf-icon-distribute-horizontal" });
            }
            ViewBag.distributeItems = distributeItems;

            List<ContextMenuItem> orderItems = new List<ContextMenuItem>();
            {
                orderItems.Add(new ContextMenuItem { Text = "Bring Forward", IconCss = "e-icons e-bring-forward" });
                orderItems.Add(new ContextMenuItem { Text = "Bring To Front", IconCss = "e-icons e-bring-to-front" });
                orderItems.Add(new ContextMenuItem { Text = "Send Backward", IconCss = "e-icons e-send-backward" });
                orderItems.Add(new ContextMenuItem { Text = "Send To Back", IconCss = "e-icons e-send-to-back" });
            }
            ViewBag.orderItems = orderItems;

            List<ContextMenuItem> groupItems = new List<ContextMenuItem>();
            {
                groupItems.Add(new ContextMenuItem { Text = "Group", IconCss = "e-icons e-group-1" });
                groupItems.Add(new ContextMenuItem { Text = "Ungroup", IconCss = "e-icons e-ungroup-1" });
            }
            ViewBag.groupItems = groupItems;

            List<ContextMenuItem> rotateItems = new List<ContextMenuItem>();
            {
                rotateItems.Add(new ContextMenuItem { Text = "Rotate Clockwise", IconCss = "e-icons e-transform-right" });
                rotateItems.Add(new ContextMenuItem { Text = "Rotate Counter-Clockwise", IconCss = "e-icons e-transform-left" });
            }
            ViewBag.rotateItems = rotateItems;

            List<ContextMenuItem> flipItems = new List<ContextMenuItem>();
            {
                flipItems.Add(new ContextMenuItem { Text = "Flip Horizontal", IconCss = "e-icons e-flip-horizontal" });
                flipItems.Add(new ContextMenuItem { Text = "Flip Vertical", IconCss = "e-icons e-flip-vertical" });
            }
            ViewBag.flipItems = flipItems;

            List<ContextMenuItem> zoomMenuItems = new List<ContextMenuItem>();
            {
                zoomMenuItems.Add(new ContextMenuItem { Text = "Zoom In" });
                zoomMenuItems.Add(new ContextMenuItem { Text = "Zoom Out" });
                zoomMenuItems.Add(new ContextMenuItem { Text = "Zoom to Fit" });
                zoomMenuItems.Add(new ContextMenuItem { Text = "Zoom to 50%" });
                zoomMenuItems.Add(new ContextMenuItem { Text = "Zoom to 100%" });
                zoomMenuItems.Add(new ContextMenuItem { Text = "Zoom to 200%" });
            }
            ViewBag.zoomMenuItems = zoomMenuItems;

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