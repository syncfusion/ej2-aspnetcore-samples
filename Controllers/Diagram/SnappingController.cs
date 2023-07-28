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
        public IActionResult Snapping()
        {
            List<DiagramNodeAnnotation> Node1 = new List<DiagramNodeAnnotation>();
            Node1.Add(new DiagramNodeAnnotation() { 
            Content = "Shape 1", 
            Id = "annot1", 
            Offset = new DiagramPoint() {X=0.5,Y=1.2},  
            Style = new DiagramTextStyle() { Bold = true,}, 
            });
            List<DiagramNodeAnnotation> Node2 = new List<DiagramNodeAnnotation>();
            Node2.Add(new DiagramNodeAnnotation() { 
            Content = "Shape 2", 
            Id = "annot1", 
            Offset = new DiagramPoint() {X=0.5,Y=1.2},  
            Style = new DiagramTextStyle() { Bold = true,}, 
            });
            List<DiagramNodeAnnotation> Node3 = new List<DiagramNodeAnnotation>();
            Node3.Add(new DiagramNodeAnnotation() { 
            Content = "Shape 3", 
            Id = "annot1", 
            Offset = new DiagramPoint() {X=0.5,Y=1.2},  
            Style = new DiagramTextStyle() { Bold = true,}, 
            });
            List < DiagramPort > ports1 = new List < DiagramPort > ();
            ports1.Add(new CustomPort() {
                Id = "port1",
                Offset = new DiagramPoint() {X = 0.5, Y = 0.5},
                Style = new DiagramShapeStyle() { Fill = "Black"}, 
                Visibility = PortVisibility.Visible,
                Constraints = PortConstraints.Default | PortConstraints.Draw
            });
          
            List < DiagramPort > ports2 = new List < DiagramPort > ();
            ports2.Add(new CustomPort() {
                Id = "port1",
                Offset = new DiagramPoint() {X = 0.5, Y = 0.5},
                Style = new DiagramShapeStyle() { Fill = "Black"}, 
                Visibility = PortVisibility.Visible,
                Constraints = PortConstraints.Default | PortConstraints.Draw
            });
            ports1.Add(new CustomPort() {
                Id = "port2",
                Offset = new DiagramPoint() {X = 0, Y = 0.5},
                Style = new DiagramShapeStyle() { Fill = "Black"}, 
                Visibility = PortVisibility.Visible,
                Constraints = PortConstraints.Default | PortConstraints.Draw,
                Height = 100,
                Width = 7
            });

            List<DiagramNode> nodes = new List<DiagramNode>();
            nodes.Add(new Node()
            {
                Id = "node_1",
                Width = 100,
                Height = 100,
                OffsetX = 350,
                OffsetY = 250,
                Annotations = Node1,
                Ports = ports1
            });
            nodes.Add(new Node()
            {
                Id = "node_2",
                Width = 100,
                Height = 100,
                OffsetX = 650,
                OffsetY = 250,
                Annotations = Node2,
                 Ports = ports2
            });
            nodes.Add(new Node()
            {
                Id = "node_3",
                Width = 100,
                Height = 100,
                OffsetX = 500,
                OffsetY = 400,
                Annotations = Node3
            });

            List<DiagramConnector> Connectors = new List<DiagramConnector>();
            Connectors.Add(new DiagramConnector() 
            { Id = "connector_1", Type = Segments.Orthogonal,SourceID="node_1", TargetID="node_3"  });

            List<DiagramUserHandle> Userhandle = new List<DiagramUserHandle>();
            Userhandle.Add(new DiagramUserHandle()
            {
                Name = "clone",
                PathData = "M0,2.4879999 L0.986,2.4879999 0.986,9.0139999 6.9950027,9.0139999 6.9950027,10 0.986,10 C0.70400238,10 0.47000122,9.9060001 0.28100207,9.7180004 0.09400177,9.5300007 0,9.2959995 0,9.0139999 z M3.0050011,0 L9.0140038,0 C9.2960014,0 9.5300026,0.093999863 9.7190018,0.28199956 9.906002,0.47000027 10,0.70399952 10,0.986 L10,6.9949989 C10,7.2770004 9.906002,7.5160007 9.7190018,7.7110004 9.5300026,7.9069996 9.2960014,8.0049992 9.0140038,8.0049992 L3.0050011,8.0049992 C2.7070007,8.0049992 2.4650002,7.9069996 2.2770004,7.7110004 2.0890007,7.5160007 1.9950027,7.2770004 1.9950027,6.9949989 L1.9950027,0.986 C1.9950027,0.70399952 2.0890007,0.47000027 2.2770004,0.28199956 2.4650002,0.093999863 2.7070007,0 3.0050011,0 z",
                Visible = true,
                Offset = 1,
                Side = Side.Bottom,
                Margin = new DiagramMargin() { Left = 0, Right = 0, Top = 0, Bottom = 0 },
                // Tooltip = { Content = "Clone"}
            });
            Userhandle.Add(new DiagramUserHandle()
            {
                Name = "Delete",
                PathData = "M0.54700077,2.2130003 L7.2129992,2.2130003 7.2129992,8.8800011 C7.2129992,9.1920013 7.1049975,9.4570007 6.8879985,9.6739998 6.6709994,9.8910007 6.406,10 6.0939997,10 L1.6659999,10 C1.3539997,10 1.0890004,9.8910007 0.87200136,9.6739998 0.65500242,9.4570007 0.54700071,9.1920013 0.54700077,8.8800011 z M2.4999992,0 L5.2600006,0 5.8329986,0.54600048 7.7599996,0.54600048 7.7599996,1.6660004 0,1.6660004 0,0.54600048 1.9270014,0.54600048 z",
                Visible = true,
                Offset = 0,
                Side = Side.Bottom,
                Margin = new DiagramMargin() { Left = 0, Right = 0, Top = 0, Bottom = 0 },
               // Tooltip = { Content = "Delete"}
            });
            Userhandle.Add(new DiagramUserHandle()
            {
                Name = "Draw",
                PathData = "M3.9730001,0 L8.9730001,5.0000007 3.9730001,10.000001 3.9730001,7.0090005 0,7.0090005 0,2.9910006 3.9730001,2.9910006 z",
                Visible = true,
                Offset = 0.5,
                Side = Side.Right,
                Margin = new DiagramMargin() { Left = 0, Right = 0, Top = 0, Bottom = 0 },
                // Tooltip = { Content = "Draw"}
            });
            ViewBag.userhandle = Userhandle;
            ViewBag.getTool = "getTool";
            ViewBag.connectors = Connectors;
            ViewBag.nodes = nodes;
            ViewBag.getNodeDefaults = "getNodeDefaults";
            ViewBag.getConnectorDefaults = "getConnectorDefaults";
            return View();
        }
    }
}