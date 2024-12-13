#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.EJ2.Diagrams;

namespace EJ2CoreSampleBrowser.Pages.Diagram;

public class UmlSequenceDiagramModel : PageModel
{
    public List<DiagramConnector> Connectors { get; set; }
    public List<DiagramNode> nodes { get; set; }
    public void OnGet()
    
        {
            List<DiagramPort> ports1 = new List<DiagramPort>();
            ports1.Add(new CustomPort() { Id = "port1", Offset = new DiagramPoint() { X = 1, Y = 0.05 }, Visibility = PortVisibility.Hidden });
            ports1.Add(new CustomPort() { Id = "port2", Offset = new DiagramPoint() { X = 1, Y = 0.97 }, Visibility = PortVisibility.Hidden });
            List<DiagramPort> ports2 = new List<DiagramPort>();
            ports2.Add(new CustomPort() { Id = "port1", Offset = new DiagramPoint() { X = 0, Y = 0.07 }, Visibility = PortVisibility.Hidden });
            ports2.Add(new CustomPort() { Id = "port2", Offset = new DiagramPoint() { X = 1, Y = 0.92 }, Visibility = PortVisibility.Hidden });
            ports2.Add(new CustomPort() { Id = "port3", Offset = new DiagramPoint() { X = 1, Y = 0.5 }, Visibility = PortVisibility.Hidden });
            List<DiagramPort> ports3 = new List<DiagramPort>();
            ports3.Add(new CustomPort() { Id = "port1", Offset = new DiagramPoint() { X = 0, Y = 0.5 }, Visibility = PortVisibility.Hidden });
            List<DiagramPort> ports4 = new List<DiagramPort>();
            ports4.Add(new CustomPort() { Id = "port1", Offset = new DiagramPoint() { X = 0, Y = 0.1 }, Visibility = PortVisibility.Hidden });
            ports4.Add(new CustomPort() { Id = "port2", Offset = new DiagramPoint() { X = 0, Y = 0.9 }, Visibility = PortVisibility.Hidden });
            nodes = new List<DiagramNode>();
            nodes.Add(new Node()
            {
                Id = "employee",
                Width = 100,
                Height = 60,
                Style = new NodeStyleNodes()
                {
                    Fill = "transparent",
                    Bold =true
                },
                OffsetX = 100,
                OffsetY = 100,
                Shape = new { type = "Text", content = "Employee" },
            });
            nodes.Add(new Node()
            {
                Id = "teamLead",
                Width = 100,
                Height = 60,
                Style = new NodeStyleNodes()
                {
                    Fill = "transparent",
                    Bold = true
                },
                OffsetX = 350,
                OffsetY = 100,
                Shape = new { type = "Text", content = "Team Lead" },
            });
            nodes.Add(new Node()
            {
                Id = "dashboard",
                Width = 100,
                Height = 60,
                Style = new NodeStyleNodes()
                {
                    Fill = "transparent",
                    Bold = true
                },
                OffsetX = 600,
                OffsetY = 100,
                Shape = new { type = "Text", content = "Dashboard" },
            });
            nodes.Add(new Node()
            {
                Id = "manager",
                Width = 100,
                Height = 60,
                Style = new NodeStyleNodes()
                {
                    Fill = "transparent",
                    Bold = true
                },
                OffsetX = 850,
                OffsetY = 100,
                Shape = new { type = "Text", content = "Manager" },
            });
            nodes.Add(new Node()
            {
                Id = "leaveRequest",
                Width = 100,
                Height = 60,
                Style = new NodeStyleNodes()
                {
                    Fill = "transparent",
                },
                OffsetX = 225,
                OffsetY = 250,
                Shape = new { type = "Text", content = "Leave Request" },
            });
            nodes.Add(new Node()
            {
                Id = "leaveApproval",
                Width = 100,
                Height = 60,
                Style = new NodeStyleNodes()
                {
                    Fill = "transparent",
                },
                OffsetX = 225,
                OffsetY = 484,
                Shape = new { type = "Text", content = "Leave Approval" },
            });
            nodes.Add(new Node()
            {
                Id = "checkEmplyeeAvail",
                Width = 175,
                Height = 30,
                Style = new NodeStyleNodes()
                {
                    Fill = "transparent",
                },
                OffsetX = 470,
                OffsetY = 345,
                Shape = new { type = "Text", content = "Check Employee availability and task status" },
            });
            nodes.Add(new Node()
            {
                Id = "forwardLeaveMssg",
                Width = 150,
                Height = 30,
                Style = new NodeStyleNodes()
                {
                    Fill = "transparent",
                },
                OffsetX = 600,
                OffsetY = 420,
                Shape = new { type = "Text", content = "Forward Leave Request" },
            });
            nodes.Add(new Node()
            {
                Id = "noObjection",
                Width = 150,
                Height = 30,
                Style = new NodeStyleNodes()
                {
                    Fill = "transparent",
                },
                OffsetX = 600,
                OffsetY = 460,
                Shape = new { type = "Text", content = "No Objection" },
            });
            nodes.Add(new Node()
            {
                Id = "employeeNode",
                Width = 10,
                Height = 250,
                Style = new NodeStyleNodes()
                {
                    Fill = "orange",
                    StrokeColor = "orange"
                },
                OffsetX = 100,
                OffsetY = 350,
                Ports = ports1,
                Shape = new { type = "Basic", shape = "Rectangle" },
            });
            nodes.Add(new Node()
            {
                Id = "teamLeadNode",
                Width = 10,
                Height = 190,
                Style = new NodeStyleNodes()
                {
                    Fill = "orange",
                    StrokeColor = "orange"
                },
                OffsetX = 350,
                OffsetY = 320,
                Ports = ports2,
                Shape = new { type = "Basic", shape = "Rectangle" },
            });
            nodes.Add(new Node()
            {
                Id = "dashboardNode",
                Width = 10,
                Height = 25,
                Style = new NodeStyleNodes()
                {
                    Fill = "orange",
                    StrokeColor = "orange"
                },
                OffsetX = 600,
                OffsetY = 320,
                Ports = ports3,
                Shape = new { type = "Basic", shape = "Rectangle" },
            });
            nodes.Add(new Node()
            {
                Id = "managerNode",
                Width = 10,
                Height = 50,
                Style = new NodeStyleNodes()
                {
                    Fill = "orange",
                    StrokeColor = "orange"
                },
                OffsetX = 850,
                OffsetY = 420,
                Ports = ports4,
                Shape = new { type = "Basic", shape = "Rectangle" },
            });
            Connectors = new List<DiagramConnector>();
            Connectors.Add(new DiagramConnector() { Id = "employeeCon1", 
                SourcePoint = new DiagramPoint() { X = 100, Y = 120 }, 
                TargetPoint = new DiagramPoint() { X = 100, Y = 225 }, 
                Type = Segments.Straight,
                TargetDecorator = new DiagramDecorator()
                {
                    Shape = DecoratorShapes.None,
                },
                Style = new DiagramStrokeStyle() { StrokeColor = "#A5A6A7" }

            });
            Connectors.Add(new DiagramConnector()
            {
                Id = "employeeCon2",
                SourcePoint = new DiagramPoint() { X = 100, Y = 475 },
                TargetPoint = new DiagramPoint() { X = 100, Y = 600 },
                Type = Segments.Straight,
                TargetDecorator = new DiagramDecorator()
                {
                    Shape = DecoratorShapes.None,

                },
                Style = new DiagramStrokeStyle() { StrokeColor = "#A5A6A7" }

            });
            Connectors.Add(new DiagramConnector()
            {
                Id = "teamLeanCon1",
                SourcePoint = new DiagramPoint() { X = 350, Y = 120 },
                TargetPoint = new DiagramPoint() { X = 350, Y = 225 },
                Type = Segments.Straight,
                TargetDecorator = new DiagramDecorator()
                {
                    Shape = DecoratorShapes.None,

                },
                Style = new DiagramStrokeStyle() { StrokeColor = "#A5A6A7" }

            });
            Connectors.Add(new DiagramConnector()
            {
                Id = "teamLeanCon2",
                SourcePoint = new DiagramPoint() { X = 350, Y = 415 },
                TargetPoint = new DiagramPoint() { X = 350, Y = 600 },
                Type = Segments.Straight,
                TargetDecorator = new DiagramDecorator()
                {
                    Shape = DecoratorShapes.None,

                },
                Style = new DiagramStrokeStyle() { StrokeColor = "#A5A6A7" }

            });
            Connectors.Add(new DiagramConnector()
            {
                Id = "dashboardCon1",
                SourcePoint = new DiagramPoint() { X = 600, Y = 120 },
                TargetPoint = new DiagramPoint() { X = 600, Y = 307 },
                Type = Segments.Straight,
                TargetDecorator = new DiagramDecorator()
                {
                    Shape = DecoratorShapes.None,

                },
                Style = new DiagramStrokeStyle() { StrokeColor = "#A5A6A7" }

            });
            Connectors.Add(new DiagramConnector()
            {
                Id = "dashboardCon2",
                SourcePoint = new DiagramPoint() { X = 600, Y = 333 },
                TargetPoint = new DiagramPoint() { X = 600, Y = 600 },
                Type = Segments.Straight,
                TargetDecorator = new DiagramDecorator()
                {
                    Shape = DecoratorShapes.None,

                },
                Style = new DiagramStrokeStyle() { StrokeColor = "#A5A6A7" }

            });
            Connectors.Add(new DiagramConnector()
            {
                Id = "managerCon1",
                SourcePoint = new DiagramPoint() { X = 850, Y = 120 },
                TargetPoint = new DiagramPoint() { X = 850, Y = 395 },
                Type = Segments.Straight,
                TargetDecorator = new DiagramDecorator()
                {
                    Shape = DecoratorShapes.None,

                },
                Style = new DiagramStrokeStyle() { StrokeColor = "#A5A6A7" }

            });
            Connectors.Add(new DiagramConnector()
            {
                Id = "managerCon2",
                SourcePoint = new DiagramPoint() { X = 850, Y = 445 },
                TargetPoint = new DiagramPoint() { X = 850, Y = 600 },
                Type = Segments.Straight,
                TargetDecorator = new DiagramDecorator()
                {
                    Shape = DecoratorShapes.None,

                },
                Style = new DiagramStrokeStyle() { StrokeColor = "#A5A6A7" }

            });
            Connectors.Add(new DiagramConnector()
            {
                Id = "empToTeamLead",
                Type = Segments.Straight,
                SourceID = "employeeNode",
                TargetID = "teamLeadNode",
                SourcePortID = "port1",
                TargetPortID = "port1"

            });
            Connectors.Add(new DiagramConnector()
            {
                Id = "teamLeadToEmp",
                Type = Segments.Straight,
                SourcePoint = new DiagramPoint() { X = 350, Y = 465 },
                TargetID = "employeeNode",
                TargetPortID = "port2",
                Style = new DiagramStrokeStyle() { StrokeDashArray= "4 4" }
            });
            Connectors.Add(new DiagramConnector()
            {
                Id = "teamLeadToDash",
                Type = Segments.Straight,
                SourceID = "teamLeadNode",
                TargetID = "dashboardNode",
                SourcePortID = "port3",
                TargetPortID = "port1"

            });
            Connectors.Add(new DiagramConnector()
            {
                Id = "teamLeadToManager",
                Type = Segments.Straight,
                SourceID = "teamLeadNode",
                TargetID = "managerNode",
                SourcePortID = "port2",
                TargetPortID = "port1"

            });
            Connectors.Add(new DiagramConnector()
            {
                Id = "managerToTeamLead",
                Type = Segments.Straight,
                SourceID = "managerNode",
                SourcePortID = "port2",
                TargetPoint = new DiagramPoint() { X = 350, Y = 440 },
                Style = new DiagramStrokeStyle() { StrokeDashArray = "4 4" }

            });
        }
}