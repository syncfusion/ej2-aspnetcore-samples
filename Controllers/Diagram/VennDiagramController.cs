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

namespace EJ2CoreSampleBrowser.Controllers.Diagram
{
    public partial class DiagramController : Controller
    {
        public IActionResult VennDiagram()
        {
            List<DiagramNode> Nodes = new List<DiagramNode>();
            List<DiagramNodeAnnotation> Node1 = new List<DiagramNodeAnnotation>();
            Node1.Add(new DiagramNodeAnnotation() { Content = "Data Science", Offset = new DiagramPoint() { X = 0.5, Y = 0.10 } });
            List<DiagramNodeAnnotation> Node3 = new List<DiagramNodeAnnotation>();
            Node3.Add(new DiagramNodeAnnotation() { Content = "Expertise", Offset = new DiagramPoint() { X = 0.5, Y = 0.7 }, VerticalAlignment = VerticalAlignment.Top });
            List<DiagramNodeAnnotation> Annotations = new List<DiagramNodeAnnotation>();
            Annotations.Add(new DiagramNodeAnnotation() { Content = "Trignometry", Offset = new DiagramPoint() { X = 0.5, Y = 0.4 }, HorizontalAlignment = Syncfusion.EJ2.Diagrams.HorizontalAlignment.Left });
            Annotations.Add(new DiagramNodeAnnotation() { Content = "Thesis", Offset = new DiagramPoint() { X = 0.45, Y = 0.8 } });
            List<DiagramNodeAnnotation> Node4 = new List<DiagramNodeAnnotation>();
            Node4.Add(new DiagramNodeAnnotation() { Content = "Programming", Offset = new DiagramPoint() { X = 0.5, Y = 0.4 }, HorizontalAlignment = Syncfusion.EJ2.Diagrams.HorizontalAlignment.Right });
            Node4.Add(new DiagramNodeAnnotation() { Content = "Assembly", Offset = new DiagramPoint() { X = 0.7, Y = 0.35 }, HorizontalAlignment = Syncfusion.EJ2.Diagrams.HorizontalAlignment.Left });
            Node4.Add(new DiagramNodeAnnotation() { Content = "Horizon", Offset = new DiagramPoint() { X = 0.7, Y = 0.6 }, HorizontalAlignment = Syncfusion.EJ2.Diagrams.HorizontalAlignment.Left });
            Node4.Add(new DiagramNodeAnnotation() { Content = "Middleware", Offset = new DiagramPoint() { X = 0.5, Y = 0.8 } });
            Nodes.Add(new DiagramNode()
            {
                Id = "datascience",
                OffsetX = 450,
                OffsetY = 232,
                Width = 400,
                Height = 400,
                MaxHeight = 400,
                MaxWidth = 400,
                Annotations = Node1,
                Shape = new DiagramBasicShape() { Type = Syncfusion.EJ2.Diagrams.Shapes.Basic, Shape = Syncfusion.EJ2.Diagrams.BasicShapes.Ellipse },
                Style = new DiagramShapeStyle() { Fill = "#f2f2f2", StrokeColor = "#acacac", StrokeWidth = 1 }
            });
            Nodes.Add(new VennDiagramNodes()
            {
                Id = "trignometry",
                OffsetX = 515,
                OffsetY = 205,
                Annotations = Annotations,
                Shape = new DiagramBasicShape() { Type = Syncfusion.EJ2.Diagrams.Shapes.Basic, Shape = Syncfusion.EJ2.Diagrams.BasicShapes.Ellipse },
                Style = new DiagramShapeStyle() { Fill = "#feb42f", StrokeColor = "#feb42f", Opacity = 0.2 }
            });
            Nodes.Add(new VennDiagramNodes()
            {
                Id = "expertise",
                OffsetX = 445,
                OffsetY = 290,
                Annotations = Node3,
                Shape = new DiagramBasicShape() { Type = Syncfusion.EJ2.Diagrams.Shapes.Basic, Shape = Syncfusion.EJ2.Diagrams.BasicShapes.Ellipse },
                Style = new DiagramShapeStyle() { Fill = "#6acbd4", StrokeColor = "#6acbd4", Opacity = 0.2 }
            });
            Nodes.Add(new VennDiagramNodes()
            {
                Id = "programming",
                OffsetX = 388,
                OffsetY = 205,
                Annotations = Node4,
                Shape = new DiagramBasicShape() { Type = Syncfusion.EJ2.Diagrams.Shapes.Basic, Shape = Syncfusion.EJ2.Diagrams.BasicShapes.Ellipse },
                Style = new DiagramShapeStyle() { Fill = "#ed1d79", StrokeColor = "#ed1d79", Opacity = 0.2 }
            });
            ViewBag.nodes = Nodes;
            return View();
        }
    }
    public class VennDiagramNodes : DiagramNode
    {
        public VennDiagramNodes()
        {
            this.Width = 200;
            this.Height = 200; 
        }
    }
}