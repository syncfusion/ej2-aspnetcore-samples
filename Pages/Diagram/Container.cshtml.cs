#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.EJ2.Diagrams;
using Syncfusion.EJ2.DropDowns;
using System.Collections.Generic;

namespace EJ2CoreSampleBrowser.Pages.Diagram
{
    public class ContainerModel : PageModel
    {
        public List<DiagramNode> nodes { get; set; }
        public List<DiagramConnector> connectors { get; set; }
        public List<DropDownListFieldSettings> fontFamilyItems { get; set; }
        
        public void OnGet()
        {
            nodes = new List<DiagramNode>();
            connectors = new List<DiagramConnector>();

            // Helper for annotations
            DiagramNodeAnnotation CreateAnnotation(string content) => new DiagramNodeAnnotation { Content = content, Style = new DiagramTextStyle { Color = "#343434" }, HorizontalAlignment = HorizontalAlignment.Center };

            // Helper for ports
            List<DiagramPort> GetPorts(string nodeId)
            {
                var ports = new List<DiagramPort>();
                switch (nodeId)
                {
                    case "node5":
                    case "node6":
                        ports.Add(new DiagramPort { Id = "port1", Offset = new DiagramPoint { X = 0.9, Y = 0 } });
                        break;
                    case "node13":
                    case "node15":
                        ports.Add(new DiagramPort { Id = "port2", Offset = new DiagramPoint { X = 1, Y = 0.5 } });
                        break;
                    case "node3":
                        ports.Add(new DiagramPort { Id = "port3", Offset = new DiagramPoint { X = 0.25, Y = 1 } });
                        ports.Add(new DiagramPort { Id = "port4", Offset = new DiagramPoint { X = 0.5, Y = 1 } });
                        ports.Add(new DiagramPort { Id = "port5", Offset = new DiagramPoint { X = 0.75, Y = 1 } });
                        break;
                    case "node7":
                        ports.Add(new DiagramPort { Id = "port1", Offset = new DiagramPoint { X = 0, Y = 0.5 } });
                        ports.Add(new DiagramPort { Id = "port2", Offset = new DiagramPoint { X = 1, Y = 0.5 } });
                        break;
                    case "node8":
                        ports.Add(new DiagramPort { Id = "port3", Offset = new DiagramPoint { X = 0.25, Y = 1 } });
                        ports.Add(new DiagramPort { Id = "port5", Offset = new DiagramPoint { X = 0.75, Y = 1 } });
                        break;
                }
                return ports;
            }

            // Helper for node
            DiagramNode CreateNode(string id, double x, double y, double h, double w, string content, double marginX = 0, double marginY = 0)
            {
                return new DiagramNode
                {
                    Id = id,
                    OffsetX = x,
                    OffsetY = y,
                    Width = w,
                    Height = h,
                    Style = new { fill = "white", strokeColor = "#2546BB", strokeWidth = 1 },
                    Shape = new { type = "Basic", shape = "Rectangle", cornerRadius = 4 },
                    Annotations = new List<DiagramNodeAnnotation> { CreateAnnotation(content) },
                    Margin = new DiagramMargin { Left = marginX, Top = marginY },
                    Ports = GetPorts(id)
                };
            }

            // Add all regular nodes
            nodes.Add(CreateNode("node1", 300, 300, 60, 100, "HTTP Traffic"));
            nodes.Add(CreateNode("node2", 500, 300, 60, 100, "Ingestion service", 50, 30));
            nodes.Add(CreateNode("node3", 650, 300, 60, 100, "Workflow service", 200, 30));
            nodes.Add(CreateNode("node4", 500, 415, 60, 100, "Package service", 50, 150));
            nodes.Add(CreateNode("node5", 650, 415, 60, 150, "Drone Scheduler service", 175, 150));
            nodes.Add(CreateNode("node6", 800, 415, 60, 100, "Delivery service", 350, 150));
            nodes.Add(CreateNode("node7", 580, 130, 60, 90, "Azure Service Bus"));
            nodes.Add(CreateNode("node8", 815, 130, 60, 100, "Managed Identities"));
            nodes.Add(CreateNode("node9", 1000, 130, 60, 100, "Azure Key Vault"));
            nodes.Add(CreateNode("node10", 500, 550, 60, 100, "Azure Cosmos DB for MongoDB API"));
            nodes.Add(CreateNode("node11", 650, 550, 60, 100, "Azure Cosmos DB"));
            nodes.Add(CreateNode("node12", 800, 550, 60, 100, "Azure Cache for Redis"));
            nodes.Add(CreateNode("node13", 1040, 255, 60, 100, "Azure Application Insights"));
            nodes.Add(CreateNode("node14", 1140, 350, 60, 100, "Azure Monitor"));
            nodes.Add(CreateNode("node15", 1040, 445, 60, 100, "Azure Log Analytics workspace"));

            // Add container node
            nodes.Add(new DiagramNode
            {
                Id = "container",
                OffsetX = 660,
                OffsetY = 350,
                Width = 520,
                Height = 300,
                Style = new { fill = "#E9EEFF", strokeColor = "#2546BB", strokeWidth = 1 },
                Shape = new
                {
                    type = "Container",
                    children = new List<string> { "node2", "node3", "node4", "node5", "node6" },
                    header = new
                    {
                        annotation = new
                        {
                            content = "Azure Container Apps Environment",
                            style = new { fontSize = 18, bold = true, fill = "transparent", strokeColor = "transparent" }
                        },
                        height = 40,
                        style = new { fontSize = 18, bold = true, fill = "transparent", strokeColor = "transparent" }
                    }
                }
            });

            // Decorator style
            var sourceDecorator = new DiagramDecorator()
            {
                Shape = DecoratorShapes.Arrow,
                Style = new DiagramShapeStyle { Fill = "#5E5E5E", StrokeColor = "#5E5E5E", StrokeWidth = 1 }
            };

            // Helper for connector
            DiagramConnector CreateConnector(string id, string sourceID, string targetID, string sourcePortID = null, string targetPortID = null, DiagramDecorator sourceDec = null)
            {
                return new DiagramConnector
                {
                    Id = id,
                    Type = Segments.Orthogonal,
                    SourceID = sourceID,
                    TargetID = targetID,
                    SourcePortID = sourcePortID,
                    TargetPortID = targetPortID,
                    SourceDecorator = sourceDec,
                    TargetDecorator = new DiagramDecorator()
                    {
                        Style = new DiagramShapeStyle { Fill = "#5E5E5E", StrokeColor = "#5E5E5E", StrokeWidth = 1 }
                    },
                    Style = new DiagramStrokeStyle() { StrokeColor = "#5E5E5E", StrokeWidth = 1 }
                };
            }

            // Add connectors
            connectors.Add(CreateConnector("connector1", "node1", "node2"));
            connectors.Add(CreateConnector("connector2", "node4", "node10"));
            connectors.Add(CreateConnector("connector3", "node5", "node11"));
            connectors.Add(CreateConnector("connector4", "node6", "node12"));
            connectors.Add(CreateConnector("connector5", "node8", "node9"));
            connectors.Add(CreateConnector("connector6", "container", "node13"));
            connectors.Add(CreateConnector("connector7", "container", "node15"));
            connectors.Add(CreateConnector("connector8", "node3", "node4", "port3"));
            connectors.Add(CreateConnector("connector9", "node3", "node5", "port4"));
            connectors.Add(CreateConnector("connector10", "node3", "node6", "port5"));
            connectors.Add(CreateConnector("connector11", "node2", "node7", null, "port1"));
            connectors.Add(CreateConnector("connector12", "node7", "node3", "port2"));
            connectors.Add(CreateConnector("connector13", "node13", "node14", "port2"));
            connectors.Add(CreateConnector("connector14", "node15", "node14", "port2"));
            connectors.Add(CreateConnector("connector16", "node8", "node5", "port3", "port1", sourceDecorator));
            connectors.Add(CreateConnector("connector17", "node8", "node6", "port5", "port1", sourceDecorator));


            fontFamilyItems = new List<DropDownListFieldSettings>();
            {
                fontFamilyItems.Add(new DropDownListFieldSettings { Text = "Arial", Value = "Arial", });
                fontFamilyItems.Add(new DropDownListFieldSettings { Text = "Aharoni", Value = "Aharoni" });
                fontFamilyItems.Add(new DropDownListFieldSettings { Text = "Bell MT", Value = "Bell MT" });
                fontFamilyItems.Add(new DropDownListFieldSettings { Text = "Fantasy", Value = "Fantasy" });
                fontFamilyItems.Add(new DropDownListFieldSettings { Text = "Segoe UI", Value = "Segoe UI" });
                fontFamilyItems.Add(new DropDownListFieldSettings { Text = "Times New Roman", Value = "Times New Roman" });
                fontFamilyItems.Add(new DropDownListFieldSettings { Text = "Verdana", Value = "Verdana" });

            }
        }
    }
}
