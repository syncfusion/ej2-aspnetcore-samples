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
using System.Web;
using System.ComponentModel;
using Syncfusion.EJ2;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Diagrams;

namespace EJ2CoreSampleBrowser.Controllers.Diagram
{
    public partial class DiagramController : Controller
    {
        public ActionResult Fishbone()
        {
            ViewBag.nodes = GetFishboneNodes();
            ViewBag.connectors = GetFishboneConnectors();
            return View();
        }

        private List<DiagramConnector> GetFishboneConnectors()
        {
            List<DiagramConnector> connectors = new List<DiagramConnector>();
            connectors.Add(CreateConnector("equipellise", "5,5", "Equipment", "ellipse1", "#A52A2A", 2));
            connectors.Add(CreateConnector("connect12", "5,5", "ellipse1", "ellipse2", "#A52A2A", 2));
            connectors.Add(CreateConnector("connect13", "5,5", "ellipse2", "ellipse3", "#A52A2A", 2));
            connectors.Add(CreateConnector("connect14", "5,5", "ellipse3", "Colorellipse3", "#A52A2A", 2));
            connectors.Add(CreateConnector("connect15", "5,5", "Environment", "ellipse4", "#A52A2A", 2));
            connectors.Add(CreateConnector("connect16", "5,5", "ellipse4", "ellipse5", "#A52A2A", 2));
            connectors.Add(CreateConnector("connect17", "5,5", "ellipse4", "ellipse5", "#A52A2A", 2));
            connectors.Add(CreateConnector("connect18", "5,5", "ellipse5", "Colorellipse2", "#A52A2A", 2));
            connectors.Add(CreateConnector("connect19", "5,5", "Person", "ellipse6", "#A52A2A", 2));
            connectors.Add(CreateConnector("connect20", "5,5", "ellipse6", "ellipse7", "#A52A2A", 2));
            connectors.Add(CreateConnector("connect21", "5,5", "ellipse7", "ellipse8", "#A52A2A", 2));
            connectors.Add(CreateConnector("connect22", "5,5", "ellipse8", "ellipse9", "#A52A2A", 2));
            connectors.Add(CreateConnector("connect23", "5,5", "ellipse9", "Colorellipse1", "#A52A2A", 2));
            connectors.Add(CreateConnector("connect24", "5,5", "Materials", "ellipse15", "#A52A2A", 2));
            connectors.Add(CreateConnector("connect25", "5,5", "ellipse15", "ellipse10", "#A52A2A", 2));
            connectors.Add(CreateConnector("connect26", "5,5", "ellipse10", "Colorellipse3", "#A52A2A", 2));
            connectors.Add(CreateConnector("connect27", "5,5", "Machine", "ellipse13", "#A52A2A", 2));
            connectors.Add(CreateConnector("connect28", "5,5", "ellipse13", "ellipse14", "#A52A2A", 2));
            connectors.Add(CreateConnector("connect29", "5,5", "ellipse14", "Colorellipse2", "#A52A2A", 2));
            connectors.Add(CreateConnector("connect30", "5,5", "Methods", "ellipse11", "#A52A2A", 2));
            connectors.Add(CreateConnector("connect31", "5,5", "ellipse11", "ellipse12", "#A52A2A", 2));
            connectors.Add(CreateConnector("connect32", "5,5", "ellipse12", "Colorellipse1", "#A52A2A", 2));
            connectors.Add(CreateConnector("connect33", "", "Colorellipse4", "Colorellipse3", "#000000", 2));
            connectors.Add(CreateConnector("connect34", "", "Colorellipse3", "Colorellipse2", "#000000", 2));
            connectors.Add(CreateConnector("connect35", "", "Colorellipse2", "Colorellipse1", "#000000", 2));
            connectors.Add(CreateConnector("connect36", "", "Colorellipse1", "Colorellipse5", "#000000", 2));
            connectors.Add(CreateConnector("connect37", "5,5", "TextPrograms", "ellipse1", "#A52A2A", 2));
            connectors.Add(CreateConnector("connect38", "5,5", "DataBooks", "ellipse2", "#A52A2A", 2));
            connectors.Add(CreateConnector("connect39", "5,5", "Fixtures", "ellipse3", "#A52A2A", 2));
            connectors.Add(CreateConnector("connect40", "5,5", "Ventilatorssound", "ellipse4", "#A52A2A", 2));
            connectors.Add(CreateConnector("connect41", "5,5", "Noise", "ellipse5", "#A52A2A", 2));
            connectors.Add(CreateConnector("connect42", "5,5", "Education", "ellipse6", "#A52A2A", 2));
            connectors.Add(CreateConnector("connect43", "5,5", "Motivation", "ellipse7", "#A52A2A", 2));
            connectors.Add(CreateConnector("connect44", "5,5", "Tiredness", "ellipse8", "#A52A2A", 2));
            connectors.Add(CreateConnector("connect45", "5,5", "Storer", "ellipse9", "#A52A2A", 2));
            connectors.Add(CreateConnector("connect46", "5,5", "Software", "ellipse15", "#A52A2A", 2));
            connectors.Add(CreateConnector("connect47", "5,5", "Computer", "ellipse10", "#A52A2A", 2));
            connectors.Add(CreateConnector("connect48", "5,5", "Procurement", "ellipse13", "#A52A2A", 2));
            connectors.Add(CreateConnector("connect49", "5,5", "Quality", "ellipse14", "#A52A2A", 2));
            connectors.Add(CreateConnector("connect50", "5,5", "Order", "ellipse12", "#A52A2A", 2));
            connectors.Add(CreateConnector("connect51", "5,5", "Standardization", "ellipse11", "#A52A2A", 2));
            return connectors;
        }

        private List<DiagramNode> GetFishboneNodes()
        {
            List<DiagramNode> nodes = new List<DiagramNode>();
            List<DiagramNodeAnnotation> labeld = new List<DiagramNodeAnnotation>();
            List<DiagramNodeAnnotation> label = new List<DiagramNodeAnnotation>();
            label.Add(new DiagramNodeAnnotation() { Content = "Equipment", Style = new DiagramTextStyle() { Color = "white" } });
            nodes.Add(new DiagramNode()
            {
                Id = "Equipment",
                Width = 120,
                Height = 40,
                OffsetX = 300,
                OffsetY = 80,
                Annotations = label,
                Style = new DiagramShapeStyle() { Fill = "#39AFA9" },
                BorderColor = "#05776C",
                Shape = new { type = "Path", data = "M 10 0 L 166 0 L 156 44 L 0 44 z" }
            });
            List<DiagramNodeAnnotation> label1 = new List<DiagramNodeAnnotation>();
            label1.Add(new DiagramNodeAnnotation() { Content = "Equipment", Style = new DiagramTextStyle() { Color = "white" } });

            nodes.Add(new DiagramNode()
            {
                Id = "Environment",
                Width = 120,
                Height = 40,
                OffsetX = 450,
                OffsetY = 80,
                Annotations = label1,
                Style = new DiagramShapeStyle() { Fill = "#39AFA9" },
                BorderColor = "#05776C",
                Shape = new { type = "Path", data = "M 10 0 L 166 0 L 156 44 L 0 44 z" }
            });

            nodes.Add(getShape("Environment", 120, 40, 450, 80, label1, new DiagramShapeStyle() { Fill = "#39AFA9" }, new { type = "Path", data = "M 10 0 L 166 0 L 156 44 L 0 44 z" }, "#05776C"));
            List<DiagramNodeAnnotation> label2 = new List<DiagramNodeAnnotation>();
            label2.Add(new DiagramNodeAnnotation() { Content = "Person", Style = new DiagramTextStyle() { Color = "white" } });
            nodes.Add(getShape("Person", 120, 40, 600, 80, label2, new DiagramShapeStyle() { Fill = "#39AFA9" }, new { type = "Path", data = "M 10 0 L 166 0 L 156 44 L 0 44 z" }, "#05776C"));
            List<DiagramNodeAnnotation> label3 = new List<DiagramNodeAnnotation>();
            label3.Add(new DiagramNodeAnnotation() { Content = "Materials", Style = new DiagramTextStyle() { Color = "white" } });
            nodes.Add(getShape("Materials", 120, 40, 300, 600, label3, new DiagramShapeStyle() { Fill = "#39AFA9" }, new { type = "Path", data = "M 10 0 L 166 0 L 156 44 L 0 44 z" }, "#05776C"));
            List<DiagramNodeAnnotation> label4 = new List<DiagramNodeAnnotation>();
            label4.Add(new DiagramNodeAnnotation() { Content = "Machine", Style = new DiagramTextStyle() { Color = "white" } });
            nodes.Add(getShape("Machine", 120, 40, 450, 600, label4, new DiagramShapeStyle() { Fill = "#39AFA9" }, new { type = "Path", data = "M 10 0 L 166 0 L 156 44 L 0 44 z" }, "#05776C"));
            List<DiagramNodeAnnotation> label5 = new List<DiagramNodeAnnotation>();
            label5.Add(new DiagramNodeAnnotation() { Content = "Methods", Style = new DiagramTextStyle() { Color = "white" } });
            nodes.Add(getShape("Methods", 120, 40, 600, 600, label5, new DiagramShapeStyle() { Fill = "#39AFA9" }, new { type = "Path", data = "M 10 0 L 166 0 L 156 44 L 0 44 z" }, "#05776C"));
            nodes.Add(getShape("ellipse1", 20, 20, 290, 130, labeld, new DiagramShapeStyle() { }, new { type = "Basic", shape = "Ellipse" }));
            nodes.Add(getShape("ellipse2", 20, 20, 323, 183, labeld, new DiagramShapeStyle() { }, new { type = "Basic", shape = "Ellipse" }));
            nodes.Add(getShape("ellipse3", 20, 20, 354, 237, labeld, new DiagramShapeStyle() { }, new { type = "Basic", shape = "Ellipse" }));
            nodes.Add(getShape("ellipse4", 20, 20, 440, 130, labeld, new DiagramShapeStyle() { }, new { type = "Basic", shape = "Ellipse" }));
            nodes.Add(getShape("ellipse5", 20, 20, 470, 182, labeld, new DiagramShapeStyle() { }, new { type = "Basic", shape = "Ellipse" }));
            nodes.Add(getShape("ellipse6", 20, 20, 590, 130, labeld, new DiagramShapeStyle() { }, new { type = "Basic", shape = "Ellipse" }));
            nodes.Add(getShape("ellipse7", 20, 20, 622, 179, labeld, new DiagramShapeStyle() { }, new { type = "Basic", shape = "Ellipse" }));
            nodes.Add(getShape("ellipse8", 20, 20, 660, 221, labeld, new DiagramShapeStyle() { }, new { type = "Basic", shape = "Ellipse" }));
            nodes.Add(getShape("ellipse9", 20, 20, 694, 264, labeld, new DiagramShapeStyle() { }, new { type = "Basic", shape = "Ellipse" }));
            nodes.Add(getShape("ellipse10", 20, 20, 354, 460, labeld, new DiagramShapeStyle() { }, new { type = "Basic", shape = "Ellipse" }));
            nodes.Add(getShape("ellipse11", 20, 20, 590, 530, labeld, new DiagramShapeStyle() { }, new { type = "Basic", shape = "Ellipse" }));
            nodes.Add(getShape("ellipse12", 20, 20, 660, 460, labeld, new DiagramShapeStyle() { }, new { type = "Basic", shape = "Ellipse" }));
            nodes.Add(getShape("ellipse13", 20, 20, 440, 530, labeld, new DiagramShapeStyle() { }, new { type = "Basic", shape = "Ellipse" }));
            nodes.Add(getShape("ellipse14", 20, 20, 510, 460, labeld, new DiagramShapeStyle() { }, new { type = "Basic", shape = "Ellipse" }));
            nodes.Add(getShape("ellipse15", 20, 20, 290, 530, labeld, new DiagramShapeStyle() { }, new { type = "Basic", shape = "Ellipse" }));
            nodes.Add(getShape("Colorellipse1", 50, 50, 717, 310, labeld, new DiagramShapeStyle() { }, new { type = "Basic", shape = "Ellipse" }));
            nodes.Add(getShape("Colorellipse2", 50, 50, 560, 310, labeld, new DiagramShapeStyle() { }, new { type = "Basic", shape = "Ellipse" }));
            nodes.Add(getShape("Colorellipse2", 50, 50, 560, 310, labeld, new DiagramShapeStyle() { }, new { type = "Basic", shape = "Ellipse" }));
            nodes.Add(getShape("Colorellipse3", 50, 50, 390, 310, labeld, new DiagramShapeStyle() { }, new { type = "Basic", shape = "Ellipse" }));
            nodes.Add(getShape("Colorellipse4", 50, 50, 220, 310, labeld, new DiagramShapeStyle() { }, new { type = "Basic", shape = "Ellipse" }));
            List<DiagramNodeAnnotation> label6 = new List<DiagramNodeAnnotation>();
            label6.Add(new DiagramNodeAnnotation() { Content = "Productivity Increase", Style = new DiagramTextStyle() { Color = "white" } });
            nodes.Add(getShape("Colorellipse5", 140, 90, 900, 310, label6, new DiagramShapeStyle() { Fill = "#39AFA9" }, new { type = "Basic", shape = "Ellipse" }, "#05776C"));
            nodes.Add(getShape("TextPrograms", 90, 20, 189, 130, labeld, new DiagramShapeStyle() { Fill = "transparent", StrokeWidth = 0 }, new { type = "Text", content = "Text Programs" }));
            nodes.Add(getShape("Ventilatorssound", 120, 20, 359, 130, labeld, new DiagramShapeStyle() { Fill = "transparent", StrokeWidth = 0 }, new { type = "Text", content = "Ventilators Sound" }));
            nodes.Add(getShape("Education", 70, 20, 500, 130, labeld, new DiagramShapeStyle() { Fill = "transparent", StrokeWidth = 0 }, new { type = "Text", content = "Education" }));
            nodes.Add(getShape("Ventilatorssound", 120, 20, 359, 130, labeld, new DiagramShapeStyle() { Fill = "transparent", StrokeWidth = 0 }, new { type = "Text", content = "Ventilators Sound" }));
            nodes.Add(getShape("DataBooks", 70, 20, 213, 183, labeld, new DiagramShapeStyle() { Fill = "transparent", StrokeWidth = 0 }, new { type = "Text", content = "DataBooks" }));
            nodes.Add(getShape("Fixtures", 70, 20, 240, 237, labeld, new DiagramShapeStyle() { Fill = "transparent", StrokeWidth = 0 }, new { type = "Text", content = "Fixtures" }));
            nodes.Add(getShape("Noise", 70, 20, 390, 182, labeld, new DiagramShapeStyle() { Fill = "transparent", StrokeWidth = 0 }, new { type = "Text", content = "Noise" }));
            nodes.Add(getShape("Motivation", 70, 20, 535, 182, labeld, new DiagramShapeStyle() { Fill = "transparent", StrokeWidth = 0 }, new { type = "Text", content = "Motivation" }));
            nodes.Add(getShape("Tiredness", 70, 20, 565, 224, labeld, new DiagramShapeStyle() { Fill = "transparent", StrokeWidth = 0 }, new { type = "Text", content = "Tiredness" }));
            nodes.Add(getShape("Storer", 70, 20, 606, 264, labeld, new DiagramShapeStyle() { Fill = "transparent", StrokeWidth = 0 }, new { type = "Text", content = "Storer" }));
            nodes.Add(getShape("Computer", 70, 20, 260, 460, labeld, new DiagramShapeStyle() { Fill = "transparent", StrokeWidth = 0 }, new { type = "Text", content = "Computer" }));
            nodes.Add(getShape("Quality", 120, 20, 417, 460, labeld, new DiagramShapeStyle() { Fill = "transparent", StrokeWidth = 0 }, new { type = "Text", content = "Quality of Element" }));
            nodes.Add(getShape("Order", 70, 20, 562, 460, labeld, new DiagramShapeStyle() { Fill = "transparent", StrokeWidth = 0 }, new { type = "Text", content = "Order" }));
            nodes.Add(getShape("Software", 70, 20, 225, 530, labeld, new DiagramShapeStyle() { Fill = "transparent", StrokeWidth = 0 }, new { type = "Text", content = "Software" }));
            nodes.Add(getShape("Procurement", 70, 20, 358, 530, labeld, new DiagramShapeStyle() { Fill = "transparent", StrokeWidth = 0 }, new { type = "Text", content = "Procurement" }));
            nodes.Add(getShape("Standardization", 90, 20, 501, 530, labeld, new DiagramShapeStyle() { Fill = "transparent", StrokeWidth = 0 }, new { type = "Text", content = "Standardization" }));
            return nodes;
        }

        public DiagramNode getShape(string id, double width, double height, double x, double y, List<DiagramNodeAnnotation> annotation, DiagramShapeStyle style, object shape, string borderColor = "")
        {
            DiagramNode node = new DiagramNode();
            node.Id = id;
            node.Width = width;
            node.Height = height;
            node.OffsetX = x;
            node.OffsetY = y;
            node.Annotations = annotation;
            node.Style = style;
            node.Shape = shape;
            node.BorderColor = borderColor;
            if ((id.IndexOf("ellipse") > -1 || id.IndexOf("Colorellipse") > -1) && id != "Colorellipse5")
            {
                node.Style = new NodeStyleNodes() { StrokeColor = "#A52A2A" };
            }
            return node;
        }
        public DiagramConnector CreateConnector(string name, string lineDashArray, string source, string target, string lineColor, double lineWidth)
        {
            DiagramConnector connector = new DiagramConnector();
            connector.Id = name;
            connector.SourceID = source;
            connector.TargetID = target;
            connector.Annotations = new List<DiagramConnectorAnnotation>() { new DiagramConnectorAnnotation() {
            } };
            connector.TargetDecorator = new DiagramDecorator() { Shape = DecoratorShapes.Arrow, Width = 5, Height = 5 };
            connector.Style = new DiagramStrokeStyle()
            {
                StrokeWidth = lineWidth,
                StrokeColor = lineColor,
                StrokeDashArray = lineDashArray,
            };
            if (connector.Id != "connect33" && connector.Id != "connect34" && connector.Id != "connect35" && connector.Id != "connect36")
            {
                connector.TargetDecorator.Style = new DiagramShapeStyle() { StrokeColor = "#A52A2A", Fill = "#A52A2A" };
            }
            return connector;
        }
    }

}
