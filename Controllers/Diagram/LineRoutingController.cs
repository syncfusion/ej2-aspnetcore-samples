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
        public IActionResult LineRouting()
        {
            List<DiagramNode> nodes = new List<DiagramNode>();
            List<DiagramPort> ports = new List<DiagramPort>();
            ports.Add(new DiagramPort() { Id = "port1", Offset = new DiagramPoint(){ X = 0.5f, Y = 0 }, Visibility = PortVisibility.Hidden });

            nodes.Add(new DiagramNode()
            {
                Id = "start",
                Annotations = new List<DiagramNodeAnnotation>() {
                    new DiagramNodeAnnotation() { Content = "Start", Style=new DiagramTextStyle() { Color = "white"} }
                },
                Style = new DiagramStrokeStyle() { Fill = "#D5535D" },
                OffsetX = 25,
                OffsetY = 110,
                Shape = new { type = "Flow", shape = "Terminator" },
                Ports = ports
            });

            nodes.Add(new DiagramNode()
            {
                Id = "process",
                Annotations = new List<DiagramNodeAnnotation>() {
                    new DiagramNodeAnnotation() { Content = "Process", Style=new DiagramTextStyle() { Color = "white"} }
                },
                Style = new DiagramStrokeStyle() { Fill = "#65B091" },
                OffsetX = 25,
                OffsetY = 255,
                Shape = new { type = "Flow", shape = "Process" },
            });

            List<DiagramPort> ports1 = new List<DiagramPort>();
            ports1.Add(new CustomPort() { Id = "port1", Offset = new DiagramPoint() { X = 0, Y = 0.5f }, Visibility = PortVisibility.Hidden });


            nodes.Add(new DiagramNode()
            {
                Id = "document",
                Annotations = new List<DiagramNodeAnnotation>() {
                    new DiagramNodeAnnotation() { Content = "Document", Style=new DiagramTextStyle() { Color = "white"} }
                },
                Style = new DiagramStrokeStyle() { Fill = "#5BA5F0" },
                OffsetX = 25,
                OffsetY = 400,
                Shape = new { type = "Flow", shape = "Document" },
                Ports = ports1
            });

            nodes.Add(new DiagramNode()
            {
                Id = "decision",
                Annotations = new List<DiagramNodeAnnotation>() {
                    new DiagramNodeAnnotation() { Content = "Decision", Style=new DiagramTextStyle() { Color = "white"} }
                },
                Style = new DiagramStrokeStyle() { Fill = "#9A8AF7" },
                OffsetX = 275,
                OffsetY = 110,
                Shape = new { type = "Flow", shape = "Decision" },
            });

            nodes.Add(new DiagramNode()
            {
                Id = "document2",
                Annotations = new List<DiagramNodeAnnotation>() {
                    new DiagramNodeAnnotation() { Content = "Document", Style=new DiagramTextStyle() { Color = "white"} }
                },
                Style = new DiagramStrokeStyle() { Fill = "#5BA5F0" },
                OffsetX = 275,
                OffsetY = 255,
                Shape = new { type = "Flow", shape = "Document" },
            });

            nodes.Add(new DiagramNode()
            {
                Id = "end",
                Annotations = new List<DiagramNodeAnnotation>() {
                    new DiagramNodeAnnotation() { Content = "End", Style=new DiagramTextStyle() { Color = "white"} }
                },
                Style = new DiagramStrokeStyle() { Fill = "#D5535D" },
                OffsetX = 275,
                OffsetY = 400,
                Shape = new { type = "Flow", shape = "Terminator" },
            });

            nodes.Add(new DiagramNode()
            {
                Id = "process2",
                Annotations = new List<DiagramNodeAnnotation>() {
                    new DiagramNodeAnnotation() { Content = "Process", Style=new DiagramTextStyle() { Color = "white"} }
                },
                Style = new DiagramStrokeStyle() { Fill = "#65B091" },
                OffsetX = 525,
                OffsetY = 110,
                Shape = new { type = "Flow", shape = "Process" },
            });

            List<DiagramPort> ports2 = new List<DiagramPort>();
            ports2.Add(new CustomPort() { Id = "port1", Offset = new DiagramPoint() { X = 1, Y = 0.5f }, Visibility = PortVisibility.Hidden });
            ports2.Add(new CustomPort() { Id = "port2", Offset = new DiagramPoint() { X = 0.5f, Y = 1 }, Visibility = PortVisibility.Hidden });

            nodes.Add(new DiagramNode()
            {
                Id = "card",
                Annotations = new List<DiagramNodeAnnotation>() {
                    new DiagramNodeAnnotation() { Content = "Card", Style=new DiagramTextStyle() { Color = "white"} }
                },
                Style = new DiagramStrokeStyle() { Fill = "#76C3F0" },
                OffsetX = 525,
                OffsetY = 255,
                Shape = new { type = "Flow", shape = "Card" },
                Ports= ports2 
            });

            List<DiagramConnector> connectors = new List<DiagramConnector>();
            connectors.Add(new DiagramConnector() { Id = "connector1", SourceID = "start", TargetID = "process", });
            connectors.Add(new DiagramConnector() { Id = "connector2", SourceID = "process", TargetID = "document", });
            connectors.Add(new DiagramConnector() { Id = "connector3", SourceID = "document", TargetID = "end", });
            connectors.Add(new DiagramConnector() { Id = "connector4", SourceID = "start", TargetID = "decision", });
            connectors.Add(new DiagramConnector() { Id = "connector5", SourceID = "decision", TargetID = "process2", });
            connectors.Add(new DiagramConnector() { Id = "connector6", SourceID = "process2", TargetID = "card", });
            connectors.Add(new DiagramConnector() { Id = "connector7", SourceID = "process", TargetID = "document2", });
            connectors.Add(new DiagramConnector() { Id = "connector8", SourceID = "document2", TargetID = "card", });
            connectors.Add(new DiagramConnector() { Id = "connector9", SourceID = "start", TargetID = "card", SourcePortID = "port1", TargetPortID = "port1" });
            connectors.Add(new DiagramConnector() { Id = "connector10", SourceID = "card", TargetID = "document", SourcePortID= "port2", TargetPortID= "port1" });


            ViewBag.nodes = nodes;
            ViewBag.connectors = connectors;
            ViewBag.getNodeDefaults = "getNodeDefaults";
            ViewBag.getConnectorDefaults = "getConnectorDefaults"; 
             
            return View();
        }
    }

    
}