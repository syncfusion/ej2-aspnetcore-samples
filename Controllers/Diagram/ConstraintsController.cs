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
        public ActionResult Constraints()
        {
            List<DiagramNode> nodes = new List<DiagramNode>();
            List<DiagramNodeAnnotation> Node1 = new List<DiagramNodeAnnotation>();
            Node1.Add(new DiagramNodeAnnotation() { Content = "Selection = False" });
            List<DiagramNodeAnnotation> Node2 = new List<DiagramNodeAnnotation>();
            Node2.Add(new DiagramNodeAnnotation() { Content = "Dragging = False" });
            List<DiagramNodeAnnotation> Node3 = new List<DiagramNodeAnnotation>();
            Node3.Add(new DiagramNodeAnnotation() { Content = "Delete = False" });
            List<DiagramNodeAnnotation> Node4 = new List<DiagramNodeAnnotation>();
            Node4.Add(new DiagramNodeAnnotation() { Content = "Rotate = False" });
            List<DiagramNodeAnnotation> Node5 = new List<DiagramNodeAnnotation>();
            Node5.Add(new DiagramNodeAnnotation() { Content = "TextEdit = False", Constraints = AnnotationConstraints.ReadOnly });
            List<DiagramNodeAnnotation> Node6 = new List<DiagramNodeAnnotation>();
            Node6.Add(new DiagramNodeAnnotation() { Content = "Resizing = False" });
            nodes.Add(new Node()
            {
                Id = "textNode1",
                Width = 500,
                Height = 50,
                Style = new NodeStyleNodes()
                {
                    Fill = "none",
                    StrokeColor = "none",
                    Color = "black",
                    TextAlign = TextAlign.Center,
                },
                OffsetX = 340,
                OffsetY = 50,
                Constraints = NodeConstraints.None,
                Shape = new { type = "Text", content = "Use Node Constraints to restrict end-users from performing certain operations on Node." },
            });
            nodes.Add(new Node()
            {
                Id = "rectangle",
                Width = 80,
                Height = 65,
                OffsetX = 80,
                OffsetY = 160,
                Constraints = NodeConstraints.None,
                Annotations = Node1,
                Shape = new { type = "Basic", shape = "Rectangle" },
            });
            nodes.Add(new Node()
            {
                Id = "ellipse",
                Width = 80,
                Height = 80,
                OffsetX = 190,
                OffsetY = 160,
                Constraints = NodeConstraints.Default & ~NodeConstraints.Drag,
                Annotations = Node2,
                Shape = new { type = "Basic", shape = "Ellipse", cornerRadius = 10 },
            });
            nodes.Add(new Node()
            {
                Id = "heptagon",
                Width = 80,
                Height = 80,
                OffsetX = 295,
                OffsetY = 160,
                Constraints = NodeConstraints.Default & ~NodeConstraints.Delete,
                Annotations = Node3,
                Shape = new { type = "Basic", shape = "Heptagon" },
            });
            nodes.Add(new Node()
            {
                Id = "directData",
                Width = 80,
                Height = 80,
                OffsetX = 410,
                OffsetY = 160,
                RotateAngle = -45,
                Constraints = NodeConstraints.Default & ~NodeConstraints.Rotate,
                Annotations = Node4,
                Shape = new { type = "Flow", shape = "DirectData" },
            });
            nodes.Add(new Node()
            {
                Id = "Plus",
                Width = 80,
                Height = 80,
                OffsetX = 530,
                OffsetY = 160,
                Annotations = Node5,
                Shape = new { type = "Basic", shape = "Plus" },
            });
            nodes.Add(new Node()
            {
                Id = "decision",
                Width = 80,
                Height = 80,
                OffsetX = 630,
                OffsetY = 160,
                Annotations = Node6,
                Constraints = NodeConstraints.Default & ~NodeConstraints.Resize,
                Shape = new { type = "Flow", shape = "Decision" },
            });
            nodes.Add(new Node()
            {
                Id = "textNode2",
                Width = 550,
                Height = 50,
                OffsetX = 350,
                OffsetY = 280,
                Style = new NodeStyleNodes()
                {
                    Fill = "none",
                    StrokeColor = "none",
                    Color = "black",
                    TextAlign = TextAlign.Center,
                },
                Constraints = NodeConstraints.None,
                Shape = new { type = "Text", content = "Use Connector Constraints to restrict end-users from performing certain operations on Connector." },
            });

            List<DiagramConnector> Connectors = new List<DiagramConnector>();
            List<DiagramConnectorAnnotation> Connector1 = new List<DiagramConnectorAnnotation>();
            Connector1.Add(new DiagramConnectorAnnotation()
            {
                Content = "Selection = False",
                HorizontalAlignment = Syncfusion.EJ2.Diagrams.HorizontalAlignment.Right,
                VerticalAlignment = Syncfusion.EJ2.Diagrams.VerticalAlignment.Bottom

            });
            List<DiagramConnectorAnnotation> Connector2 = new List<DiagramConnectorAnnotation>();
            Connector2.Add(new DiagramConnectorAnnotation()
            {
                Content = "Dragging = True",
                HorizontalAlignment = Syncfusion.EJ2.Diagrams.HorizontalAlignment.Right,
                VerticalAlignment = Syncfusion.EJ2.Diagrams.VerticalAlignment.Bottom

            });
            List<DiagramConnectorAnnotation> Connector3 = new List<DiagramConnectorAnnotation>();
            Connector3.Add(new DiagramConnectorAnnotation()
            {
                Content = "Delete = False",
                HorizontalAlignment = Syncfusion.EJ2.Diagrams.HorizontalAlignment.Right,
                VerticalAlignment = Syncfusion.EJ2.Diagrams.VerticalAlignment.Bottom

            });
            List<DiagramConnectorAnnotation> Connector4 = new List<DiagramConnectorAnnotation>();
            Connector4.Add(new DiagramConnectorAnnotation()
            {
                Content = "EndThumb = False",
                HorizontalAlignment = Syncfusion.EJ2.Diagrams.HorizontalAlignment.Right,
                VerticalAlignment = Syncfusion.EJ2.Diagrams.VerticalAlignment.Bottom

            });
            List<DiagramConnectorAnnotation> Connector5 = new List<DiagramConnectorAnnotation>();
            Connector5.Add(new DiagramConnectorAnnotation()
            {
                Content = "EndDraggable = False",
                HorizontalAlignment = Syncfusion.EJ2.Diagrams.HorizontalAlignment.Right,
                VerticalAlignment = Syncfusion.EJ2.Diagrams.VerticalAlignment.Bottom

            });
            List<DiagramConnectorAnnotation> Connector6 = new List<DiagramConnectorAnnotation>();
            Connector6.Add(new DiagramConnectorAnnotation()
            {
                Content = "SegmentThumb = False",
                HorizontalAlignment = Syncfusion.EJ2.Diagrams.HorizontalAlignment.Right,
                VerticalAlignment = Syncfusion.EJ2.Diagrams.VerticalAlignment.Bottom

            });
            Connectors.Add(new DiagramConnector()
            {
                Id = "select",
                SourcePoint = new DiagramPoint() { X = 40, Y = 350 },
                TargetPoint = new DiagramPoint() { X = 120, Y = 430 },
                Type = Segments.Orthogonal,
                Constraints = ConnectorConstraints.Default & ~ConnectorConstraints.Select,
                TargetDecorator = new DiagramDecorator()
                {
                    Style = new DiagramShapeStyle()
                    {
                        StrokeColor = "#6BA5D7",
                        Fill = "#6BA5D7"
                    }
                },
                Annotations = Connector1,
                Style = new DiagramStrokeStyle() { StrokeColor = "#6BA5D7", Fill = "#6BA5D7", StrokeWidth = 2 }

            });
            Connectors.Add(new DiagramConnector()
            {
                Id = "connector2",
                SourcePoint = new DiagramPoint() { X = 140, Y = 350 },
                TargetPoint = new DiagramPoint() { X = 220, Y = 430 },
                Type = Segments.Orthogonal,
                Constraints = ConnectorConstraints.Default | ConnectorConstraints.Drag | ConnectorConstraints.DragSegmentThumb,
                TargetDecorator = new DiagramDecorator()
                {
                    Style = new DiagramShapeStyle()
                    {
                        StrokeColor = "#6BA5D7",
                        Fill = "#6BA5D7"
                    }
                },
                Annotations = Connector2,
                Style = new DiagramStrokeStyle() { StrokeColor = "#6BA5D7", Fill = "#6BA5D7", StrokeWidth = 2 }

            });
            Connectors.Add(new DiagramConnector()
            {
                Id = "delete",
                SourcePoint = new DiagramPoint() { X = 250, Y = 350 },
                TargetPoint = new DiagramPoint() { X = 320, Y = 430 },
                Type = Segments.Orthogonal,
                Constraints = (ConnectorConstraints.Default | ConnectorConstraints.DragSegmentThumb) &
                               ~(ConnectorConstraints.Delete | ConnectorConstraints.Drag),
                TargetDecorator = new DiagramDecorator()
                {
                    Style = new DiagramShapeStyle()
                    {
                        StrokeColor = "#6BA5D7",
                        Fill = "#6BA5D7"
                    }
                },
                Annotations = Connector3,
                Style = new DiagramStrokeStyle() { StrokeColor = "#6BA5D7", Fill = "#6BA5D7", StrokeWidth = 2 }

            });
            Connectors.Add(new DiagramConnector()
            {
                Id = "endThumb",
                SourcePoint = new DiagramPoint() { X = 360, Y = 350 },
                TargetPoint = new DiagramPoint() { X = 440, Y = 430 },
                Type = Segments.Orthogonal,
                Constraints =
                    (ConnectorConstraints.Default | ConnectorConstraints.DragSegmentThumb) &
                    ~(
                      ConnectorConstraints.DragSourceEnd | ConnectorConstraints.DragTargetEnd
                    ),
                TargetDecorator = new DiagramDecorator()
                {
                    Style = new DiagramShapeStyle()
                    {
                        StrokeColor = "#6BA5D7",
                        Fill = "#6BA5D7"
                    }
                },
                Annotations = Connector4,
                Style = new DiagramStrokeStyle() { StrokeColor = "#6BA5D7", Fill = "#6BA5D7", StrokeWidth = 2 }

            });
            Connectors.Add(new DiagramConnector()
            {
                Id = "draggable",
                SourcePoint = new DiagramPoint() { X = 460, Y = 350 },
                TargetPoint = new DiagramPoint() { X = 540, Y = 430 },
                Type = Segments.Orthogonal,
                Constraints=
                    (ConnectorConstraints.Default | ConnectorConstraints.DragSegmentThumb) &
                    ~(
                      ConnectorConstraints.DragSourceEnd | ConnectorConstraints.DragTargetEnd
                    ),
                TargetDecorator = new DiagramDecorator()
                {
                    Style = new DiagramShapeStyle()
                    {
                        StrokeColor = "#6BA5D7",
                        Fill = "#6BA5D7"
                    }
                },
                Annotations = Connector5,
                Style = new DiagramStrokeStyle() { StrokeColor = "#6BA5D7", Fill = "#6BA5D7", StrokeWidth = 2 }

            });
            Connectors.Add(new DiagramConnector()
            {
                Id = "segmentThumb",
                SourcePoint = new DiagramPoint() { X = 580, Y = 350 },
                TargetPoint = new DiagramPoint() { X = 660, Y = 430 },
                Type = Segments.Orthogonal,
                Constraints = ConnectorConstraints.Default & ~ConnectorConstraints.Drag,
                TargetDecorator = new DiagramDecorator()
                {
                    Style = new DiagramShapeStyle()
                    {
                        StrokeColor = "#6BA5D7",
                        Fill = "#6BA5D7"
                    }
                },
                Annotations = Connector6,
                Style = new DiagramStrokeStyle() { StrokeColor = "#6BA5D7", Fill = "#6BA5D7", StrokeWidth = 2 }

            });
            List<DiagramUserHandle> handle = new List<DiagramUserHandle>();
            handle.Add(new DiagramUserHandle()
            {
                Name = "delete",
                PathData = "M 7.04 22.13 L 92.95 22.13 L 92.95 88.8 C 92.95 91.92 91.55 94.58 88.76 96.74 C 85.97 98.91 82.55 100 78.52 100 L 21.48 100 C 17.45 100 14.03 98.91 11.24 96.74 C 8.45 94.58 7.04 91.92 7.04 88.8 z M 32.22 0 L 67.78 0 L 75.17 5.47 L 100 5.47 L 100 16.67 L 0 16.67 L 0 5.47 L 24.83 5.47 z",
                Visible = true,
                Offset = 0.5,
                Side = Side.Bottom,
                Margin = new DiagramMargin() { Left = 0, Right = 0, Top = 0, Bottom = 0 }
            });

            DiagramSelector userHandle = new DiagramSelector();
            userHandle.Constraints = SelectorConstraints.UserHandle;
            userHandle.UserHandles = handle;
            ViewBag.selectedItems = userHandle;
            ViewBag.userhandle = handle;
            ViewBag.nodes = nodes;
            ViewBag.connectors = Connectors;
            ViewBag.getTool = "getTool";
            return View();
        }
    }
}