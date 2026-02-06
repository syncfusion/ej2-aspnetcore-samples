#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.EJ2.Diagrams;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Diagnostics;

namespace EJ2CoreSampleBrowser.Pages.Diagram;
public class AvoidConnectorOverlapDiagramModel : PageModel
{
    public List<DiagramNode> Nodes { get; set; }
    public List<DiagramConnector> Connectors { get; set; }

    public void OnGet()
    {
        Nodes = new List<DiagramNode>();
        Connectors = new List<DiagramConnector>();
        InitDiagramModel();
    }

    private void InitDiagramModel()
    {
        Create1To16Node("node1", 205, 180, 80, 240);
        Create1To16Node("node2", 205, 427.5, 80, 240);
        Create9To5Node("node3", 415, 127.5, 100, 135);
        Create9To5Node("node4", 415, 367.5, 100, 135);
        Create9To5Node("node5", 615, 127.5, 100, 135);
        Create9To5Node("node6", 615, 367.5, 100, 135);
        Create16To1Node("node7", 820, 240, 80, 240);
        CreateInputNode("node8", 70, 40, 80, 30, "Cin");
        CreateInputNode("node9", 70, 180, 80, 30, "A");
        CreateInputNode("node10", 70, 427.5, 80, 30, "B");
        CreateOutputNode("node11", 950, 240, 80, 30, "S");
        CreateOutputNode("node12", 950, 367.5, 80, 30, "Cout");

        // Adding connectors
        CreateConnector("connector01", "node8", "node3", 0, 8, "lightGreen");
        CreateConnector("connector02", "node9", "node1", 0, 0, "orange");
        CreateConnector("connector03", "node10", "node2", 0, 0, "orange");
        CreateConnector("connector04", "node7", "node11", 0, 0, "orange");
        CreateConnector("connector05", "node6", "node12", 4, 0);
        CreateConnector("connector06", "node3", "node5", 4, 8);
        CreateConnector("connector07", "node5", "node4", 4, 8, "lightGreen");
        CreateConnector("connector08", "node4", "node6", 4, 8);

        CreateConnector("connector1", "node1", "node3", 0, 0);
        CreateConnector("connector2", "node1", "node3", 1, 1);
        CreateConnector("connector3", "node1", "node3", 2, 2);
        CreateConnector("connector4", "node1", "node3", 3, 3);
        CreateConnector("connector5", "node1", "node5", 4, 0, "lightGreen");
        CreateConnector("connector6", "node1", "node5", 5, 1);
        CreateConnector("connector7", "node1", "node5", 6, 2);
        CreateConnector("connector8", "node1", "node5", 7, 3, "lightGreen");
        CreateConnector("connector9", "node1", "node4", 8, 0, "lightGreen");
        CreateConnector("connector10", "node1", "node4", 9, 1, "lightGreen");
        CreateConnector("connector11", "node1", "node4", 10, 2);
        CreateConnector("connector12", "node1", "node4", 11, 3, "lightGreen");
        CreateConnector("connector13", "node1", "node6", 12, 0);
        CreateConnector("connector14", "node1", "node6", 13, 1, "lightGreen");
        CreateConnector("connector15", "node1", "node6", 14, 2, "lightGreen");
        CreateConnector("connector16", "node1", "node6", 15, 3);
        CreateConnector("connector17", "node2", "node3", 0, 4, "lightGreen");
        CreateConnector("connector18", "node2", "node3", 1, 5, "lightGreen");
        CreateConnector("connector19", "node2", "node3", 2, 6);
        CreateConnector("connector20", "node2", "node3", 3, 7);
        CreateConnector("connector21", "node2", "node5", 4, 4, "lightGreen");
        CreateConnector("connector22", "node2", "node5", 5, 5, "lightGreen");
        CreateConnector("connector23", "node2", "node5", 6, 6, "lightGreen");
        CreateConnector("connector24", "node2", "node5", 7, 7, "lightGreen");
        CreateConnector("connector25", "node2", "node4", 8, 4);
        CreateConnector("connector26", "node2", "node4", 9, 5, "lightGreen");
        CreateConnector("connector27", "node2", "node4", 10, 6);
        CreateConnector("connector28", "node2", "node4", 11, 7);

        CreateConnector("connector29", "node2", "node6", 12, 4, "lightGreen");
        CreateConnector("connector30", "node2", "node6", 13, 5);
        CreateConnector("connector31", "node2", "node6", 14, 6);
        CreateConnector("connector32", "node2", "node6", 15, 7);
        CreateConnector("connector33", "node3", "node7", 0, 0);
        CreateConnector("connector34", "node3", "node7", 1, 1);
        CreateConnector("connector35", "node3", "node7", 2, 2, "lightGreen");
        CreateConnector("connector36", "node3", "node7", 3, 3);

        CreateConnector("connector37", "node5", "node7", 0, 4);
        CreateConnector("connector38", "node5", "node7", 1, 5);
        CreateConnector("connector39", "node5", "node7", 2, 6);
        CreateConnector("connector40", "node5", "node7", 3, 7, "lightGreen");

        CreateConnector("connector41", "node4", "node7", 0, 8);
        CreateConnector("connector42", "node4", "node7", 1, 9);
        CreateConnector("connector43", "node4", "node7", 2, 10, "lightGreen");
        CreateConnector("connector44", "node4", "node7", 3, 11);

        CreateConnector("connector45", "node6", "node7", 0, 12);
        CreateConnector("connector46", "node6", "node7", 1, 13);
        CreateConnector("connector47", "node6", "node7", 2, 14);
        CreateConnector("connector48", "node6", "node7", 3, 15, "lightGreen");
    }

    private void Create1To16Node(string id, double x, double y, double width, double height)
    {
        var node = CreateNode(id, x, y, width, height);
        AddPorts(node, 1, "in");
        AddPorts(node, 16, "out");
        AddPortsLabels(node, 16, "out");
    }

    private void Create16To1Node(string id, double x, double y, double width, double height)
    {
        var node = CreateNode(id, x, y, width, height);
        AddPorts(node, 16, "in");
        AddPorts(node, 1, "out");
        AddPortsLabels(node, 16, "in");
    }

    private void Create9To5Node(string id, double x, double y, double width, double height)
    {
        var leftLabels = new[] { "A_0", "A_1", "A_2", "A_3", "B_0", "B_1", "B_2", "B_3", "Cin" };
        var rightLabels = new[] { "S_0", "S_1", "S_2", "S_3", "Cout" };
        var node = CreateNode(id, x, y, width, height, "4 Bit\nRCA");
        AddPorts(node, 9, "in");
        AddPorts(node, 5, "out", 9);
        AddPortsLabels(node, 9, "in", leftLabels);
        AddPortsLabels(node, 5, "out", rightLabels, 9);
    }

    private void CreateInputNode(string id, double x, double y, double width, double height, string label)
    {
        var node = CreateNode(id, x, y, width, height, label);
        AddPorts(node, 1, "out");
        var Annotation = node.Annotations[0];
        Annotation.Offset = new DiagramPoint() { X = (width - 25) / (2 * width), Y = 0.5 };
    }

    private void CreateOutputNode(string id, double x, double y, double width, double height, string label)
    {
        var node = CreateNode(id, x, y, width, height, label);
        AddPorts(node, 1, "in");
        var Annotation = node.Annotations[0];
        Annotation.Offset = new DiagramPoint() { X = 1 - ((width - 25) / (2 * width)), Y = 0.5 };
    }



    private void AddShape(DiagramNode node, int inCount, int outCount)
    {
        var PathData1 = "M 55 0 L 55 7.5 L 80 7.5 L 55 7.5 L 55 22.5 L 80 22.5 L 55 22.5 L 55 37.5 L 80 37.5 L 55 37.5 L 55 52.5 L 80 52.5 L 55 52.5 L 55 67.5 L 80 67.5 L 55 67.5 L 55 82.5 L 80 82.5 L 55 82.5 L 55 97.5 L 80 97.5 L 55 97.5 L 55 112.5 L 80 112.5 L 55 112.5 L 55 127.5 L 80 127.5 L 55 127.5 L 55 142.5 L 80 142.5 L 55 142.5 L 55 157.5 L 80 157.5 L 55 157.5 L 55 172.5 L 80 172.5 L 55 172.5 L 55 187.5 L 80 187.5 L 55 187.5 L 55 202.5 L 80 202.5 L 55 202.5 L 55 217.5 L 80 217.5 L 55 217.5 L 55 232.5 L 80 232.5 L 55 232.5 L 55 240 L 25 240 L 25 120 L 0 120 L 25 120 L 25 0 Z";

        var PathData2 = "M 75 0 L 75 7.5 L 100 7.5 L 75 7.5 L 75 22.5 L 100 22.5 L 75 22.5 L 75 37.5 L 100 37.5 L 75 37.5 L 75 52.49999999999999 L 100 52.49999999999999 L 75 52.49999999999999 L 75 67.5 L 100 67.5 L 75 67.5 L 75 135 L 25 135 L 25 127.5 L 0 127.5 L 25 127.5 L 25 112.49999999999999 L 0 112.49999999999999 L 25 112.49999999999999 L 25 97.5 L 0 97.5 L 25 97.5 L 25 82.49999999999999 L 0 82.49999999999999 L 25 82.49999999999999 L 25 67.5 L 0 67.5 L 25 67.5 L 25 52.49999999999999 L 0 52.49999999999999 L 25 52.49999999999999 L 25 37.5 L 0 37.5 L 25 37.5 L 25 22.5 L 0 22.5 L 25 22.5 L 25 7.5 L 0 7.5 L 25 7.5 L 25 0 Z";

        var PathData3 = "M 55 0 L 55 120 L 80 120 L 55 120 L 55 240 L 25 240 L 25 232.5 L 0 232.5 L 25 232.5 L 25 217.5 L 0 217.5 L 25 217.5 L 25 202.5 L 0 202.5 L 25 202.5 L 25 187.5 L 0 187.5 L 25 187.5 L 25 172.5 L 0 172.5 L 25 172.5 L 25 157.5 L 0 157.5 L 25 157.5 L 25 142.5 L 0 142.5 L 25 142.5 L 25 127.5 L 0 127.5 L 25 127.5 L 25 112.5 L 0 112.5 L 25 112.5 L 25 97.5 L 0 97.5 L 25 97.5 L 25 82.5 L 0 82.5 L 25 82.5 L 25 67.5 L 0 67.5 L 25 67.5 L 25 52.5 L 0 52.5 L 25 52.5 L 25 37.5 L 0 37.5 L 25 37.5 L 25 22.5 L 0 22.5 L 25 22.5 L 25 7.5 L 0 7.5 L 25 7.5 L 25 0 Z";

        var PathData4 = "M 35 0 L 35 15 L 60 15 L 35 15 L 35 30 L 0 30 L 0 0 Z";

        var PathData5 = "M 60 0 L 60 30 L 25 30 L 25 15 L 0 15 L 25 15 L 25 0 Z";

        if (node.Id == "node1" || node.Id == "node2")
        {
            node.Shape = new { Type = Shapes.Path, Data = PathData1 };
        }
        else if (node.Id == "node3" || node.Id == "node4" || node.Id == "node5" || node.Id == "node6")
        {
            node.Shape = new { Type = Shapes.Path, Data = PathData2 };
        }
        else if (node.Id == "node7")
        {
            node.Shape = new { Type = Shapes.Path, Data = PathData3 };
        }
        else if (node.Id == "node8" || node.Id == "node9" || node.Id == "node10")
        {
            node.Shape = new { Type = Shapes.Path, Data = PathData4 };
        }
        else if (node.Id == "node11" || node.Id == "node12")
        {
            node.Shape = new { Type = Shapes.Path, Data = PathData5 };
        }

    }

    private void AddPorts(DiagramNode node, int count, string side, int? factor = null)
    {
        if (!factor.HasValue)
        {
            factor = count;
        }
        if (count > 1)
        {
            for (var i = 1; i <= count; i++)
            {
                var port = new DiagramPort
                {
                    Id = $"{node.Id}_{side}_{i - 1}",
                    Offset = new DiagramPoint { X = side == "out" ? 1 : 0, Y = (double)((i / (double)factor) - (1 / (2.0 * factor))) },
                    Visibility = PortVisibility.Visible,
                    Shape = PortShapes.Circle,
                    Style = new DiagramShapeStyle { Fill = "black" },
                    Width = 8,
                    Height = 8
                };
                node.Ports.Add(port);
            }
        }
        else
        {
            var port = new DiagramPort
            {
                Id = $"{node.Id}_{side}_0",
                Offset = new DiagramPoint { X = side == "out" ? 1 : 0, Y = 0.5 },
                Visibility = PortVisibility.Visible,
                Shape = PortShapes.Circle,
                Style = new DiagramShapeStyle { Fill = "black" },
                Width = 8,
                Height = 8
            };
            node.Ports.Add(port);
        }
    }

    private static void AddPortsLabels(DiagramNode node, int count, string side, string[]? labels = null, int? factor = null)
    {
        if (!factor.HasValue)
        {
            factor = count;
        }
        var x = side == "out" ? (node.Width - 25 * 0.5) / node.Width : ((25 * 0.5) / node.Width);

        for (var i = 1; i <= count; i++)
        {
            var label = new DiagramNodeAnnotation
            {
                Content = labels != null ? labels[i - 1] : "" + (i - 1).ToString(),
                Offset = new DiagramPoint { X = x, Y = (i / (double)factor) - (1 / (double)(2 * factor)) },
                Style = new DiagramTextStyle { FontSize = 7 },
                VerticalAlignment = VerticalAlignment.Bottom,
                Margin = new DiagramMargin { Bottom = 2 }
            };
            node.Annotations.Add(label);
        }
    }
    private DiagramNode CreateNode(string id, double x, double y, double width, double height, string? label = null)
    {
        var PathData1 = "M 55 0 L 55 7.5 L 80 7.5 L 55 7.5 L 55 22.5 L 80 22.5 L 55 22.5 L 55 37.5 L 80 37.5 L 55 37.5 L 55 52.5 L 80 52.5 L 55 52.5 L 55 67.5 L 80 67.5 L 55 67.5 L 55 82.5 L 80 82.5 L 55 82.5 L 55 97.5 L 80 97.5 L 55 97.5 L 55 112.5 L 80 112.5 L 55 112.5 L 55 127.5 L 80 127.5 L 55 127.5 L 55 142.5 L 80 142.5 L 55 142.5 L 55 157.5 L 80 157.5 L 55 157.5 L 55 172.5 L 80 172.5 L 55 172.5 L 55 187.5 L 80 187.5 L 55 187.5 L 55 202.5 L 80 202.5 L 55 202.5 L 55 217.5 L 80 217.5 L 55 217.5 L 55 232.5 L 80 232.5 L 55 232.5 L 55 240 L 25 240 L 25 120 L 0 120 L 25 120 L 25 0 Z";
        var PathData2 = "M 75 0 L 75 7.5 L 100 7.5 L 75 7.5 L 75 22.5 L 100 22.5 L 75 22.5 L 75 37.5 L 100 37.5 L 75 37.5 L 75 52.49999999999999 L 100 52.49999999999999 L 75 52.49999999999999 L 75 67.5 L 100 67.5 L 75 67.5 L 75 135 L 25 135 L 25 127.5 L 0 127.5 L 25 127.5 L 25 112.49999999999999 L 0 112.49999999999999 L 25 112.49999999999999 L 25 97.5 L 0 97.5 L 25 97.5 L 25 82.49999999999999 L 0 82.49999999999999 L 25 82.49999999999999 L 25 67.5 L 0 67.5 L 25 67.5 L 25 52.49999999999999 L 0 52.49999999999999 L 25 52.49999999999999 L 25 37.5 L 0 37.5 L 25 37.5 L 25 22.5 L 0 22.5 L 25 22.5 L 25 7.5 L 0 7.5 L 25 7.5 L 25 0 Z";
        var PathData3 = "M 55 0 L 55 120 L 80 120 L 55 120 L 55 240 L 25 240 L 25 232.5 L 0 232.5 L 25 232.5 L 25 217.5 L 0 217.5 L 25 217.5 L 25 202.5 L 0 202.5 L 25 202.5 L 25 187.5 L 0 187.5 L 25 187.5 L 25 172.5 L 0 172.5 L 25 172.5 L 25 157.5 L 0 157.5 L 25 157.5 L 25 142.5 L 0 142.5 L 25 142.5 L 25 127.5 L 0 127.5 L 25 127.5 L 25 112.5 L 0 112.5 L 25 112.5 L 25 97.5 L 0 97.5 L 25 97.5 L 25 82.5 L 0 82.5 L 25 82.5 L 25 67.5 L 0 67.5 L 25 67.5 L 25 52.5 L 0 52.5 L 25 52.5 L 25 37.5 L 0 37.5 L 25 37.5 L 25 22.5 L 0 22.5 L 25 22.5 L 25 7.5 L 0 7.5 L 25 7.5 L 25 0 Z";
        var PathData4 = "M 35 0 L 35 15 L 60 15 L 35 15 L 35 30 L 0 30 L 0 0 Z";
        var PathData5 = "M 60 0 L 60 30 L 25 30 L 25 15 L 0 15 L 25 15 L 25 0 Z";
        var ShapeData = "";
        if (id == "node1" || id == "node2")
        {
            ShapeData = PathData1;
        }
        else if (id == "node3" || id == "node4" || id == "node5" || id == "node6")
        {
            ShapeData = PathData2;
        }
        else if (id == "node7")
        {
            ShapeData = PathData3;
        }
        else if (id == "node8" || id == "node9" || id == "node10")
        {
            ShapeData = PathData4;
        }
        else if (id == "node11" || id == "node12")
        {
            ShapeData = PathData5;
        }
        var node = new DiagramNode
        {
            Id = id,
            OffsetX = x,
            OffsetY = y,
            Width = width,
            Height = height,
            Style = new DiagramShapeStyle { StrokeColor = "black", StrokeWidth = 2 },
            Shape = new { Type = Shapes.Path, Data = ShapeData },
            Ports = new List<DiagramPort>(),
            Annotations = new List<DiagramNodeAnnotation>()
        };

        if (!string.IsNullOrEmpty(label))
        {
            node.Annotations.Add(new DiagramNodeAnnotation { Content = label, Style = new DiagramTextStyle { FontSize = 14 } });
        }

        Nodes.Add(node);
        return node;
    }
    private void CreateConnector(string id, string sourceId, string targetId, int sourcePortIndex, int targetPortIndex, string strokeColor = "green")
    {
        var color = !string.IsNullOrEmpty(strokeColor) ? strokeColor : "green";
        if (color == "lightGreen")
        {
            color = "#1AD81A";
        }
        else if (color == "green")
        {
            color = "#005100";
        }
        var connector = new DiagramConnector
        {
            Id = id,
            SourceID = sourceId,
            TargetID = targetId,
            CornerRadius = 5,
            SourcePortID = $"{sourceId}_out_{sourcePortIndex}",
            TargetPortID = $"{targetId}_in_{targetPortIndex}",
            Type = Segments.Orthogonal,
            Style = new DiagramStrokeStyle { StrokeColor = color, StrokeWidth = 2 },
            TargetDecorator = new DiagramDecorator { Shape = DecoratorShapes.None }
        };

        Connectors.Add(connector);
    }
}