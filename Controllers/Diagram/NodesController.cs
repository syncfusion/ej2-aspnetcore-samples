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
        public IActionResult Nodes()
        {
            List<DiagramNode> nodes = new List<DiagramNode>();
            List<DiagramNodeAnnotation> Node1 = new List<DiagramNodeAnnotation>();
            Node1.Add(new DiagramNodeAnnotation() { Content = "SDLC", Style = new DiagramTextStyle() { Color = "White", Fill = "None", StrokeColor = "None" } });
            List<DiagramNodeAnnotation> Node2 = new List<DiagramNodeAnnotation>();
            Node2.Add(new DiagramNodeAnnotation() { Content = "Analysis", Style = new DiagramTextStyle() { Color = "White", Fill = "None", StrokeColor = "None" } });
            List<DiagramNodeAnnotation> Node3 = new List<DiagramNodeAnnotation>();
            Node3.Add(new DiagramNodeAnnotation() { Content = "Design", Style = new DiagramTextStyle() { Color = "White", Fill = "None", StrokeColor = "None" } });
            List<DiagramNodeAnnotation> Node4 = new List<DiagramNodeAnnotation>();
            Node4.Add(new DiagramNodeAnnotation() { Content = "Implement", Style = new DiagramTextStyle() { Color = "White", Fill = "None", StrokeColor = "None" } });
            List<DiagramNodeAnnotation> Node5 = new List<DiagramNodeAnnotation>();
            Node5.Add(new DiagramNodeAnnotation() { Content = "Deploy", Style = new DiagramTextStyle() { Color = "White", Fill = "None", StrokeColor = "None" } });
            List<DiagramNodeAnnotation> Node6 = new List<DiagramNodeAnnotation>();
            Node6.Add(new DiagramNodeAnnotation() { Content = "Support", Style = new DiagramTextStyle() { Color = "White", Fill = "None", StrokeColor = "None" } });

            nodes.Add(new Node() { Id = "sdlc", text = "SDLC", OffsetX = 270, OffsetY = 250, Annotations = Node1 });
            nodes.Add(new Node() { Id = "analysis", text = "Analysis", OffsetX = 270, OffsetY = 110, Annotations = Node2 });
            nodes.Add(new Node() { Id = "design", text = "Design", OffsetX = 405, OffsetY = 205, Annotations = Node3 });
            nodes.Add(new Node() { Id = "implement", text = "Implement", OffsetX = 352, OffsetY = 370, Annotations = Node4 });
            nodes.Add(new Node() { Id = "deploy", text = "Deploy", OffsetX = 184, OffsetY = 370, Annotations = Node5 });
            nodes.Add(new Node() { Id = "support", text = "Support", OffsetX = 130, OffsetY = 205, Annotations = Node6 });
            ViewBag.nodes = nodes;

            List<DiagramConnector> Connectors = new List<DiagramConnector>();
            for (int i = 1; i < nodes.Count; i++)
            {
                Connectors.Add(new DiagramConnector() { SourceID = nodes[i].Id, TargetID = nodes[(i % 5) + 1].Id });
            }
            ViewBag.connectors = Connectors;
            ViewBag.getNodeDefaults = "getNodeDefaults";
            ViewBag.getConnectorDefaults = "getConnectorDefaults";
            return View();
        }
    }
    public class Node : DiagramNode
    {
        public Node()
        {
            this.Width = 100;
            this.Height = 100;
        }
        public string text;
    }
}