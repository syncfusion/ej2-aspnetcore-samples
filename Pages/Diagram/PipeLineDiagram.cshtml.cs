#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Newtonsoft.Json;
using Syncfusion.EJ2.Charts;
using System.ComponentModel;
using Syncfusion.EJ2.Diagrams;

namespace EJ2CoreSampleBrowser.Pages.Diagram
{
    public class PipeLineDiagramModel : PageModel
    {
        public List<DiagramNode> Nodes { get; set; }
        public List<DiagramConnector> Connectors { get; set; }
        public DiagramConstraints Constraints { get; set; } = DiagramConstraints.Default & ~DiagramConstraints.UndoRedo;

        public void OnGet()
        {
            InitializeNodes();
            InitializeConnectors();
        }

        private void InitializeNodes()
        {
            Nodes = new List<DiagramNode>();      

            // Create gradient styles for tanks
            RadialGradient tank1RadialGradient = new RadialGradient()
            {
                cx = 50,
                cy = 50,
                fx = 25,
                fy = 25,
                r = 50,
                Stops = new List<Stop>()
                {
                    new Stop(){ Color = "white", Offset = 0 },
                    new Stop(){ Color = "#e88a25", Offset = 100 }
                }
            };

            RadialGradient tank2RadialGradient = new RadialGradient()
            {
                cx = 50,
                cy = 50,
                fx = 25,
                fy = 25,
                r = 50,
                Stops = new List<Stop>()
                {
                    new Stop(){ Color = "white", Offset = 0 },
                    new Stop(){ Color = "purple", Offset = 100 }
                }
            };

            RadialGradient tankGradientColor = new RadialGradient()
            {
                cx = 50,
                cy = 50,
                fx = 25,
                fy = 25,
                r = 50,
                Stops = new List<Stop>()
                {
                    new Stop(){ Color = "white", Offset = 0 },
                    new Stop(){ Color = "#76b5c5", Offset = 100 }
                }
            };

            RadialGradient storageTankGradientColor = new RadialGradient()
            {
                cx = 50,
                cy = 50,
                fx = 50,
                fy = 50,
                r = 80,
                Stops = new List<Stop>()
                {
                    new Stop(){ Color = "white", Offset = 0 },
                    new Stop(){ Color = "#CECECE", Offset = 100 }
                }
            };

            // Title node
            DiagramNode chemicalNode = new DiagramNode
            {
                Id = "Chemical",
                OffsetX = 720,
                OffsetY = 20,
                Shape = new  { type = "text" },
                Style = new NodeStyleNodes()
                {
                    Fill  ="transparent",
                    StrokeColor = "transparent"
                },
                BorderColor = "transparent",
                Annotations = new List<DiagramNodeAnnotation>()
                {
                    new DiagramNodeAnnotation
                    {
                        Content =  "Chemical Reactor System P&ID",
                        Style = new DiagramTextStyle { FontSize = 18, Bold = true }
                    }
                },
                Constraints = NodeConstraints.Default & ~NodeConstraints.Select
            };
            Nodes.Add(chemicalNode);

            // Tank 1 components
            DiagramNode tank1Top = new DiagramNode
            {
                Id = "tank1Top",
                OffsetX = 200,
                OffsetY = 225,
                Width = 100,
                Height = 50,
                Shape = new { type = "Basic", shape = "Ellipse" },
                Style = new NodeStyleNodes()
                {
                    Gradient = tank1RadialGradient
                },
                Constraints = NodeConstraints.Default & ~NodeConstraints.Select
            };
            Nodes.Add(tank1Top);

            DiagramNode tank1Bottom = new DiagramNode
            {
                Id = "tank1Bottom",
                OffsetX = 200,
                OffsetY = 375,
                Width = 100,
                Height = 50,
                Shape = new { type = "Basic", shape = "Ellipse" },
                Style = new NodeStyleNodes { Gradient = tank1RadialGradient }
            };
            Nodes.Add(tank1Bottom);

            DiagramNode tank1Container = new DiagramNode
            {
                Id = "tank1container",
                OffsetX = 200,
                OffsetY = 300,
                Width = 100,
                Height = 150,
                Shape = new { type = "Basic", shape = "Rectangle" },
                Style = new NodeStyleNodes { Gradient = tank1RadialGradient },
                Annotations = new List<DiagramNodeAnnotation>()
                {
                    new DiagramNodeAnnotation
                    {
                        Content = "Tank1",
                        Style = new DiagramTextStyle { Color = "black" }
                    }
                },
                Ports = GetPorts("tank1container")
            };
            Nodes.Add(tank1Container);

            // Tank 1 Group
            DiagramNode tank1Group = new DiagramNode
            {
                Id = "Tank1Group",
                Children = new string[] { "tank1Top", "tank1Bottom", "tank1container" }
            };
            Nodes.Add(tank1Group as DiagramNode);

            // Tank 2 components
            DiagramNode tank2Top = new DiagramNode
            {
                Id = "tank2Top",
                OffsetX = 370,
                OffsetY = 225,
                Width = 100,
                Height = 50,
                Shape = new { type = "Basic", shape = "Ellipse" },
                Style = new NodeStyleNodes { Gradient = tank2RadialGradient }
            };
            Nodes.Add(tank2Top);

            DiagramNode tank2Bottom = new DiagramNode
            {
                Id = "tank2Bottom",
                OffsetX = 370,
                OffsetY = 375,
                Width = 100,
                Height = 50,
                Shape = new { type = "Basic", shape = "Ellipse" },
                Style = new NodeStyleNodes { Gradient = tank2RadialGradient }
            };
            Nodes.Add(tank2Bottom);

            DiagramNode tank2Container = new DiagramNode
            {
                Id = "tank2container",
                OffsetX = 370,
                OffsetY = 300,
                Width = 100,
                Height = 150,
                Shape = new { type = "Basic", shape = "Rectangle" },
                Style = new NodeStyleNodes { Gradient = tank2RadialGradient },
                Annotations = new List<DiagramNodeAnnotation>()
            {
                new DiagramNodeAnnotation
                {
                    Content = "Tank2",
                    Style = new DiagramTextStyle { Color = "black" }
                }
            },
                Ports = GetPorts("tank2container")
            };
            Nodes.Add(tank2Container);

            // Tank 2 Group
            DiagramNode tank2Group = new DiagramNode
            {
                Id = "Tank2Group",
                Children = new string[] { "tank2Top", "tank2Bottom", "tank2container" }
            };
            Nodes.Add(tank2Group as DiagramNode);

            // Tank 3 components
            DiagramNode tank3Top = new DiagramNode
            {
                Id = "tank3Top",
                OffsetX = 750,
                OffsetY = 325,
                Width = 170,
                Height = 70,
                Shape = new { type = "Basic", shape = "Ellipse" },
                Style = new NodeStyleNodes { Gradient = tankGradientColor }
            };
            Nodes.Add(tank3Top);

            DiagramNode tank3Bottom = new DiagramNode
            {
                Id = "tank3Bottom",
                OffsetX = 750,
                OffsetY = 575,
                Width = 170,
                Height = 70,
                Shape = new { type = "Basic", shape = "Ellipse" },
                Style = new NodeStyleNodes { Gradient = tankGradientColor }
            };
            Nodes.Add(tank3Bottom);

            DiagramNode reacterInletThread1 = new DiagramNode
            {
                Id = "reacterInletThread1",
                OffsetX = 810,
                OffsetY = 290,
                Width = 35,
                Height = 25,
                Shape = new { type = "Flow", shape = "Data" },
                RotateAngle = 10,
                Style = new NodeStyleNodes { Fill = "#469A22" }
            };
            Nodes.Add(reacterInletThread1);

            DiagramNode reacterInletThread2 = new DiagramNode
            {
                Id = "reacterInletThread2",
                OffsetX = 750,
                OffsetY = 278,
                Width = 15,
                Height = 25,
                Shape = new { type = "Basic", shape = "Rectangle" },
                Style = new NodeStyleNodes { Fill = "#656764" }
            };
            Nodes.Add(reacterInletThread2);

            DiagramNode reacterInletThread3 = new DiagramNode
            {
                Id = "reacterInletThread3",
                OffsetX = 750,
                OffsetY = 268,
                Width = 25,
                Height = 10,
                Shape = new { type = "Basic", shape = "Rectangle" },
                Style = new NodeStyleNodes { Fill = "#656764" }
            };
            Nodes.Add(reacterInletThread3);

            // Pressure Gauge Node using HTML Template
            DiagramNode pressureGaugeNode = new DiagramNode
            {
                Id = "pressureGuageNode",
                OffsetX = 600,
                OffsetY = 130,
                Width = 70,
                Height = 70,
                Shape = new { type = "HTML" ,
                    content= "<div class=\"pressure-container\" style=\"width:100%;height:100%\">" +
                  "<div class=\"pressure-indicator\">" +
                  "<div class=\"pressure-gauge\">" +
                  "<div class=\"needle\" id=\"needle\"></div>" +
                  "</div>" +
                  "<div class=\"pressure-value\" id=\"pressureValue\"> 0 PSI</div>" +
                  "</div>" +
                  "</div>"
                },
                Style = new NodeStyleNodes { Fill = "green" },
                Ports = GetPorts("pressureGuageNode")
            };
            Nodes.Add(pressureGaugeNode);

            // Pump components
            DiagramNode pumpBase = new DiagramNode
            {
                Id = "pumpBase",
                OffsetX = 750,
                OffsetY = 110,
                Width = 100,
                Height = 100,
                Shape = new { type = "Flow", shape = "SequentialAccessStorage" },
                RotateAngle = 90,
                Flip = Syncfusion.EJ2.Diagrams.FlipDirection.Vertical,
                Style = new NodeStyleNodes { Fill = "#E2EAF4" },
                Ports = GetPorts("pumpBase")
            };
            Nodes.Add(pumpBase);

            DiagramNode pumpBody = new DiagramNode
            {
                Id = "pumpBody",
                OffsetX = 750,
                OffsetY = 110,
                Width = 90,
                Height = 90,
                Shape = new { type = "Flow", shape = "SequentialAccessStorage" },
                RotateAngle = 90,
                Style = new NodeStyleNodes { Fill = "#E2EAF4" },
            };
            Nodes.Add(pumpBody);

            DiagramNode pumpRotator = new DiagramNode
            {
                Id = "pumpRotator",
                OffsetX = 750,
                OffsetY = 110,
                Width = 50,
                Height = 50,
                Shape = new { type = "HTML",
                    content = "<div style=\"display:flex;left: -25px;position: absolute;\">" +
                            "<div class=\"pump-container\">" +
                            "<div class=\"pump-body\"></div>" +
                            "<div class=\"fan-blades\" id=\"fan\">" +
                            "<div class=\"blade\"></div>" +
                            "<div class=\"blade\"></div>" +
                            "<div class=\"hub\"></div>" +
                            "</div>" +
                            "</div>" +
                            "<div id=\"pumpCheckBoxContainer\">" +
                            "<input id=\"pumpCheckBox\" type=\"checkbox\"/>" +
                            "</div>" +
                            "</div>"
                }
            };
            Nodes.Add(pumpRotator);

            // Pump Group
            DiagramNode pumpGroup = new DiagramNode
            {
                Id = "pumpGroup",
                Children = new string[] { "pumpBase", "pumpBody", "pumpRotator" }
            };
            Nodes.Add(pumpGroup as DiagramNode);

            // Tank 3 container
            DiagramNode tank3Container = new DiagramNode
            {
                Id = "tank3container",
                OffsetX = 750,
                OffsetY = 450,
                Width = 170,
                Height = 250,
                Shape = new { type = "Basic", shape = "Rectangle" },
                Style = new NodeStyleNodes { Gradient = tankGradientColor },
                Annotations = new List<DiagramNodeAnnotation>()
{
                new DiagramNodeAnnotation
                {
                    Content = "STIRRED TANK \nREACTOR (STR)",
                    Style = new DiagramTextStyle { Color = "black", FontSize = 20, Bold = true, Italic = true }
                }
            },
                Ports = GetPorts("tank3container")
            };
            Nodes.Add(tank3Container);

            // Tank 3 Cooler
            DiagramNode tank3Cooler = new DiagramNode
            {
                Id = "tank3cooler",
                OffsetX = 750,
                OffsetY = 490,
                Width = 185,
                Height = 250,
                Shape = new { type = "Basic", shape = "Rectangle", cornerRadius = 50 },
                Style = new NodeStyleNodes { Fill = "#3D58B0" },
                Ports = GetPorts("tank3cooler")
            };
            Nodes.Add(tank3Cooler);
            // Reactor outlet thread components
            DiagramNode reacterOutletThread1 = new DiagramNode
            {
                Id = "reacterOutletThread1",
                OffsetX = 855,
                OffsetY = 407.5,
                Width = 15,
                Height = 25,
                Shape = new { type = "Basic", shape = "Rectangle" },
                Style = new NodeStyleNodes { Fill = "#C9B100" },
                ZIndex = 100,
            };
            Nodes.Add(reacterOutletThread1);

            DiagramNode reacterOutletThread2 = new DiagramNode
            {
                Id = "reacterOutletThread2",
                OffsetX = 845,
                OffsetY = 407.5,
                Width = 25,
                Height = 35,
                Shape = new { type = "Basic", shape = "Rectangle" },
                Style = new NodeStyleNodes { Fill = "#C9B100" },
                ZIndex = 101,
            };
            Nodes.Add(reacterOutletThread2);
            // Level Transmitter
            DiagramNode levelTransmitter = new DiagramNode
            {
                Id = "leveltransmitter",
                OffsetX = 800,
                OffsetY = 350,
                Width = 50,
                Height = 30,
                Shape = new { type = "Flow", shape = "Process" },
                Style = new NodeStyleNodes { Fill = "#79247D" },
                Annotations = new List<DiagramNodeAnnotation>()
{
                new DiagramNodeAnnotation
                {
                    Content = "54 L",
                    Style = new DiagramTextStyle { Color = "gold", Bold = true }
                }
            },
                ZIndex = 103,
            };
            Nodes.Add(levelTransmitter);
            // Tank 3 Group
            DiagramNode tank3Group = new DiagramNode
            {
                Id = "Tank3Group",
                Children = new string[] { "tank3cooler", "tank3Top", "tank3Bottom", "tank3container" },
                Ports = GetPorts("Tank3Group"),
                ZIndex = 98
            };
            Nodes.Add(tank3Group as DiagramNode);

            // Coolant controller
            DiagramNode coolantController = new DiagramNode
            {
                Id = "coolantcontroller",
                OffsetX = 500,
                OffsetY = 650,
                Width = 150,
                Height = 70,
                Shape = new { type = "Flow", shape = "Card" },
                Style = new NodeStyleNodes { Fill = "#656874" },
                Annotations = new List<DiagramNodeAnnotation>()
{
                new DiagramNodeAnnotation
                {
                    Content = "Coolant Controller",
                    Style = new DiagramTextStyle { Color = "Orange", FontSize = 15, Italic = true, Bold = true },
                    Offset = new DiagramPoint { X = 0.5, Y = 0.8 }
                }
            },
                Ports = GetPorts("coolantcontroller")
            };
            Nodes.Add(coolantController);

            // Coolant Value
            DiagramNode coolantValue = new DiagramNode
            {
                Id = "coolantValue",
                OffsetX = 500,
                OffsetY = 650,
                Width = 100,
                Height = 60,
                Shape = new { type = "HTML" , 
                content = "<div><input id=\"numeric\" type=\"text\"/></div>"
                },
                Style = new NodeStyleNodes { Fill = "#656874" }
            };
            Nodes.Add(coolantValue);

            // Thermometer Node
            DiagramNode thermometerNode = new DiagramNode
            {
                Id = "thermometerNode",
                OffsetX = 920,
                OffsetY = 600,
                Width = 100,
                Height = 100,
                Shape = new { type = "HTML" , 
                     content = "<div style=\"width:100%;height:100%\"><div id=\"thermometer\"></div></div>"
                },
                Style = new NodeStyleNodes { Fill = "#656874" },
                Ports = GetPorts("thermometerNode")
            };
            Nodes.Add(thermometerNode);

            // Mixer
            DiagramNode mixer1 = new DiagramNode
            {
                Id = "mixer1",
                OffsetX = 550,
                OffsetY = 230,
                Width = 70,
                Height = 70,
                Shape = new { type = "Basic", shape = "Octagon" },
                Annotations = new List<DiagramNodeAnnotation>()
{
                new DiagramNodeAnnotation
                {
                    Content = "Mixer"
                }
            },
                Style = new NodeStyleNodes
                {
                    Gradient = new RadialGradient
                    {
                        cx = 50,
                        cy = 50,
                        fx = 25,
                        fy = 25,
                        r = 50,
                        Stops = new List<Stop>()
        {
                        new Stop(){ Color = "white", Offset = 0 },
                        new Stop(){ Color = "#415086", Offset = 100 }
                    }
                    }
                },
                Ports = GetPorts("mixer1")
            };
            Nodes.Add(mixer1);

            // Temperature Alarm
            DiagramNode temperatureAlarm = new DiagramNode
            {
                Id = "temperatureAlarm",
                OffsetX = 680,
                OffsetY = 292,
                Width = 30,
                Height = 30,
                Shape = new { type = "Flow", shape = "DirectData" },
                RotateAngle = 245,
                Annotations = new List<DiagramNodeAnnotation>()
{
                new DiagramNodeAnnotation
                {
                    Content = "TA",
                    Style = new DiagramTextStyle { Bold = true },
                }
            },
                Style = new NodeStyleNodes
                {
                    Gradient = new RadialGradient
                    {
                        cx = 50,
                        cy = 50,
                        fx = 25,
                        fy = 25,
                        r = 50,
                        Stops = new List<Stop>()
        {
                        new Stop(){ Color = "white", Offset = 0 },
                        new Stop(){ Color = "#EA8257", Offset = 100 }
                    }
                    }
                }
            };
            Nodes.Add(temperatureAlarm);



            // Product Inlet Thread
            DiagramNode productInletThread1 = new DiagramNode
            {
                Id = "productInletThread1",
                OffsetX = 1200,
                OffsetY = 500,
                Width = 30,
                Height = 10,
                Shape = new { type = "Basic", shape = "Rectangle" },
                Style = new NodeStyleNodes { Fill = "#D47A39" }
            };
            Nodes.Add(productInletThread1);

            // Product Tank
            DiagramNode productTank = new DiagramNode
            {
                Id = "ProductTank",
                OffsetX = 1200,
                OffsetY = 600,
                Width = 200,
                Height = 200,
                Shape = new { type = "Flow", shape = "PreDefinedProcess" },
                Style = new NodeStyleNodes { Gradient = storageTankGradientColor },
                Annotations = new List<DiagramNodeAnnotation>()
{
                new DiagramNodeAnnotation
                {
                    Content = "Storage",
                    Offset = new DiagramPoint { X = 0.5, Y = 0.1 }
                },
                new DiagramNodeAnnotation
                {
                    Content = "Tank",
                    Offset = new DiagramPoint { X = 0.5, Y = 0.9 }
                }
            },
                Ports = GetPorts("ProductTank")
            };
            Nodes.Add(productTank);

            // Product Tank Quantity
            DiagramNode productTankQuantity = new DiagramNode
            {
                Id = "ProductTankQuantity",
                OffsetX = 1200,
                OffsetY = 600,
                Width = 100,
                Height = 130,
                Shape = new { type = "HTML", content = "<div class=\"product-container\"><div class=\"product\" id=\"productStorage\"></div></div>" }
            };
            Nodes.Add(productTankQuantity);

            // Pressure Gauge
            DiagramNode pressureGauge = new DiagramNode
            {
                Id = "pressureguage",
                OffsetX = 1000,
                OffsetY = 115,
                Width = 10,
                Height = 10,
                Shape = new { type = "HTML", content = "<div style:\"height:50px;width:50px\"><div id=\"gauge1\"></div></div>" },
                Style = new NodeStyleNodes { Fill = "#65B091" }
            };
            Nodes.Add(pressureGauge);

            // Add control valve groups
            AddControlValveGroup("1", 270, 500, "#ffb734");
            AddControlValveGroup("2", 450, 130, "#7C099C");
            AddControlValveGroup("3", 970, 400, "red");

        }

        private void AddControlValveGroup(string id, double offsetX, double offsetY, string color)
        {
            // Control Valve components
            DiagramNode controlValve1 = new DiagramNode
            {
                Id = $"controlvalve{(int.Parse(id) - 1) * 5 + 1}",
                OffsetX = 450,
                OffsetY = 100,
                Width = 10,
                Height = 20,
                Shape = new { type = "Flow", shape = "Process" },
                Style = new NodeStyleNodes { Fill = "#65B091" },
                Ports = GetPorts($"controlvalve{(int.Parse(id) - 1) * 5 + 1}")
            };
            Nodes.Add(controlValve1);

            DiagramNode controlValve2 = new DiagramNode
            {
                Id = $"controlvalve{(int.Parse(id) - 1) * 5 + 2}",
                OffsetX = 420,
                OffsetY = 115,
                Width = 10,
                Height = 25,
                Shape = new { type = "Flow", shape = "Process" },
                Style = new NodeStyleNodes { Fill = "#65B091" },
                Ports = GetPorts($"controlvalve{(int.Parse(id) - 1) * 5 + 2}")
            };
            Nodes.Add(controlValve2);

            DiagramNode controlValve3 = new DiagramNode
            {
                Id = $"controlvalve{(int.Parse(id) - 1) * 5 + 3}",
                OffsetX = 450,
                OffsetY = 115,
                Width = 50,
                Height = 20,
                Shape = new { type = "Flow", shape = "Process" },
                Style = new NodeStyleNodes { Fill = "#65B091" },
                Ports = GetPorts($"controlvalve{(int.Parse(id) - 1) * 5 + 3}")
            };
            Nodes.Add(controlValve3);

            DiagramNode controlValve4 = new DiagramNode
            {
                Id = $"controlvalve{(int.Parse(id) - 1) * 5 + 4}",
                OffsetX = 480,
                OffsetY = 115,
                Width = 10,
                Height = 25,
                Shape = new { type = "Flow", shape = "Process" },
                Style = new NodeStyleNodes { Fill = "#65B091" },
                Ports = GetPorts($"controlvalve{(int.Parse(id) - 1) * 5 + 4}")
            };
            Nodes.Add(controlValve4);

            DiagramNode controlValve5 = new DiagramNode
            {
                Id = $"controlvalve{(int.Parse(id) - 1) * 5 + 5}",
                OffsetX = 450,
                OffsetY = 90,
                Width = 35,
                Height = 5,
                Shape = new { type = "Basic", shape = "Ellipse" },
                Style = new NodeStyleNodes { Fill = "#65B091" },
                Ports = GetPorts($"controlvalve{(int.Parse(id) - 1) * 5 + 5}")
            };
            Nodes.Add(controlValve5);

            // Control Valve Box with HTML Template
            DiagramNode controlValveBox = new DiagramNode
            {
                Id = $"controlvalveBox{id}",
                OffsetX = 450,
                OffsetY = 115,
                Width = 35,
                Height = 15,
                Style = new NodeStyleNodes { Fill = "#65B091" },
                Ports = GetPorts($"controlvalveBox{id}")
            };

            if(id == "1")
            {
                controlValveBox.Shape = new
                {
                    type = "HTML",
                    content = "<div style=\"height:100%;width:100%\">" +
"<div id=\"showFlowContainer1\" style=\"background:#ffb734;height:100%;width:100%;border-radius: 3px;border:1px solid\">" +
"</div>" +
"<div class=\"switch-container\">" +
"<div id=\"switch-buttons1\">" +
"</div>" +
"</div>" +
"</div>"
                }; // Set specific template for control valve box 1
            }
            else if(id == "2")
            {
                controlValveBox.Shape = new
                {
                    type = "HTML",
                    content = "<div style=\"height:100%;width:100%\">" +
"<div id=\"showFlowContainer2\" style=\"background:#7C099C;height:100%;width:100%;border-radius: 3px;border:1px solid\">" +
"</div>" +
"<div class=\"switch-container\">" +
"<div id=\"switch-buttons2\"></div>" +
"</div>" +
"</div>"
                }; // Set specific template for control valve box 2
            }
            else if(id == "3")
            {
                controlValveBox.Shape = new
                {
                    type = "HTML",
                    content = "<div style=\"height:100%;width:100%\">" +
"<div id=\"showFlowContainer3\" style=\"background:red;height:100%;width:100%;border-radius: 3px;border:1px solid\">" +
"</div>" +
"<div class=\"switch-container\">" +
"<div id=\"switch-buttons3\">" +
"</div>" +
"</div>" +
"</div>"
                }; // Set specific template for control valve box 3
            }
            Nodes.Add(controlValveBox);

            // Create group for control valve
            string[] children = new string[]
            {
            $"controlvalve{(int.Parse(id) - 1) * 5 + 1}",
            $"controlvalve{(int.Parse(id) - 1) * 5 + 2}",
            $"controlvalve{(int.Parse(id) - 1) * 5 + 3}",
            $"controlvalve{(int.Parse(id) - 1) * 5 + 4}",
            $"controlvalve{(int.Parse(id) - 1) * 5 + 5}",
            $"controlvalveBox{id}"
                        };

            DiagramNode controlValveGroup = new DiagramNode
            {
                Id = $"controlValveGroup{id}",
                Children = children,
                OffsetX = offsetX,
                OffsetY = offsetY,
                Ports = GetPorts($"controlValveGroup{id}")
            };
            Nodes.Add(controlValveGroup as DiagramNode);
        }


        private void InitializeConnectors()
        {
            Connectors = new List<DiagramConnector>();

            // DiagramConnector 1: Tank1 to Control Valve
            DiagramConnector connector1 = new DiagramConnector 
            {
                Id = "Connector1",
                SourceID = "Tank1Group",
                TargetID = "controlvalve2",
                SourcePortID  = "bottomPort",
                TargetPortID  = "inletLeftPort",
                Type = Segments.Orthogonal,
                Style = new DiagramStrokeStyle
                {
                    StrokeColor = "orange",
                    StrokeDashArray = "5,5",
                    StrokeWidth = 10
                },
                TargetDecorator = new DiagramDecorator { Shape = DecoratorShapes.None },
                AddInfo = new Dictionary<string, object> { { "animate", true } }
            };
            Connectors.Add(connector1);

            // DiagramConnector 2: Tank2 to Control Valve
            DiagramConnector connector2 = new DiagramConnector 
            {
                Id = "Connector2",
                SourceID = "Tank2Group",
                TargetID = "controlvalve7",
                SourcePortID  = "topPort",
                TargetPortID  = "inletLeftPort",
                Type = Segments.Orthogonal,
                Style = new DiagramStrokeStyle
                {
                    StrokeColor = "#7C099C",
                    StrokeWidth = 10
                },
                TargetDecorator = new DiagramDecorator { Shape = DecoratorShapes.None },
                AddInfo = new Dictionary<string, object> { { "animate", true } }
            };
            Connectors.Add(connector2);

            // DiagramConnector 3: Control Valve to Mixer
            DiagramConnector connector3 = new DiagramConnector 
            {
                Id = "Connector3",
                SourceID = "controlvalve4",
                TargetID = "mixer1",
                SourcePortID  = "outletRightPort",
                TargetPortID  = "bottomPort",
                Type = Segments.Orthogonal,
                Style = new DiagramStrokeStyle
                {
                    StrokeColor = "orange",
                    StrokeWidth = 10
                },
                TargetDecorator = new DiagramDecorator { Shape = DecoratorShapes.None },
                AddInfo = new Dictionary<string, object> { { "animate", true } }
            };
            Connectors.Add(connector3);

            // DiagramConnector 4: Control Valve to Mixer
            DiagramConnector connector4 = new DiagramConnector 
            {
                Id = "Connector4",
                SourceID = "controlvalve9",
                TargetID = "mixer1",
                SourcePortID  = "outletRightPort",
                TargetPortID  = "topPort",
                Type = Segments.Orthogonal,
                Style = new DiagramStrokeStyle
                {
                    StrokeColor = "#7C099C",
                    StrokeWidth = 10
                },
                TargetDecorator = new DiagramDecorator { Shape = DecoratorShapes.None },
                AddInfo = new Dictionary<string, object> { { "animate", true } }
            };
            Connectors.Add(connector4);

            // DiagramConnector 5: Coolant Controller to Tank3 Cooler
            DiagramConnector connector5 = new DiagramConnector 
            {
                Id = "Connector5",
                SourceID = "coolantcontroller",
                TargetID = "tank3cooler",
                SourcePortID  = "outletRightPort",
                TargetPortID  = "inletLeftPort",
                Type = Segments.Orthogonal,
                Style = new DiagramStrokeStyle
                {
                    StrokeColor = "blue",
                    StrokeWidth = 5,
                    StrokeDashArray = "10,1"
                },
                TargetDecorator = new DiagramDecorator { Shape = DecoratorShapes.None }
            };
            Connectors.Add(connector5);

            // DiagramConnector 6: Coolant Controller to Tank3 Cooler
            DiagramConnector connector6 = new DiagramConnector 
            {
                Id = "Connector6",
                SourceID = "coolantcontroller",
                TargetID = "tank3cooler",
                SourcePortID  = "inletLeftPort",
                TargetPortID  = "bottomPort",
                Type = Segments.Orthogonal,
                Style = new DiagramStrokeStyle
                {
                    StrokeColor = "#d6185bff",
                    StrokeWidth = 5,
                    StrokeDashArray = "10,1"
                },
                TargetDecorator = new DiagramDecorator { Shape = DecoratorShapes.None }
            };
            Connectors.Add(connector6);

            // DiagramConnector 9: Reactor Outlet to Control Valve
            DiagramConnector connector9 = new DiagramConnector 
            {
                Id = "Connector9",
                SourceID = "reacterOutletThread1",
                TargetID = "controlvalve12",
                SourcePortID  = "outletRightPort",
                TargetPortID  = "inletLeftPort",
                Type = Segments.Orthogonal,
                Style = new DiagramStrokeStyle
                {
                    StrokeColor = "red",
                    StrokeWidth = 10
                },
                TargetDecorator = new DiagramDecorator { Shape = DecoratorShapes.None },
                AddInfo = new Dictionary<string, object> { { "animate", true } }
            };
            Connectors.Add(connector9);

            // DiagramConnector 10: Control Valve to Product Inlet
            DiagramConnector connector10 = new DiagramConnector 
            {
                Id = "Connector10",
                SourceID = "controlvalve14",
                TargetID = "productInletThread1",
                SourcePortID  = "outletRightPort",
                TargetPortID  = "topPort",
                Type = Segments.Orthogonal,
                Style = new DiagramStrokeStyle
                {
                    StrokeColor = "red",
                    StrokeWidth = 10
                },
                TargetDecorator = new DiagramDecorator { Shape = DecoratorShapes.None },
                AddInfo = new Dictionary<string, object> { { "animate", true } }
            };
            Connectors.Add(connector10);

            // DiagramConnector 11: Mixer to Pump
            DiagramConnector connector11 = new DiagramConnector 
            {
                Id = "Connector11",
                SourceID = "mixer1",
                TargetID = "pumpBase",
                SourcePortID  = "outletRightPort",
                TargetPortID  = "pumpPort2",
                Type = Segments.Orthogonal,
                Style = new DiagramStrokeStyle
                {
                    StrokeColor = "#8DC276",
                    StrokeWidth = 10
                },
                TargetDecorator = new DiagramDecorator { Shape = DecoratorShapes.None },
                AddInfo = new Dictionary<string, object> { { "animate", true } }
            };
            Connectors.Add(connector11);

            // DiagramConnector 12: Pump to Reactor Inlet
            DiagramConnector connector12 = new DiagramConnector 
            {
                Id = "Connector12",
                SourceID = "pumpBase",
                TargetID = "reacterInletThread1",
                SourcePortID  = "pumpPort1",
                TargetPortID  = "topPort",
                Type = Segments.Orthogonal,
                Style = new DiagramStrokeStyle
                {
                    StrokeColor = "#8DC276",
                    StrokeWidth = 10
                },
                TargetDecorator = new DiagramDecorator { Shape = DecoratorShapes.None },
                AddInfo = new Dictionary<string, object> { { "animate", true } }
            };
            Connectors.Add(connector12);

            // DiagramConnector 13: Mixer to Pressure Gauge
            DiagramConnector connector13 = new DiagramConnector 
            {
                Id = "Connector13",
                SourceID = "mixer1",
                TargetID = "pressureGuageNode",
                SourcePortID  = "mixertopressureport",
                TargetPortID  = "pressuretomixerport",
                Type = Segments.Straight,
                Style = new DiagramStrokeStyle
                {
                    StrokeColor = "black",
                    StrokeWidth = 2,
                    StrokeDashArray = "10,1"
                },
                TargetDecorator = new DiagramDecorator { Shape = DecoratorShapes.None }
            };
            Connectors.Add(connector13);

            // DiagramConnector 14: Tank3 to Thermometer
            DiagramConnector connector14 = new DiagramConnector 
            {
                Id = "Connector14",
                SourceID = "Tank3Group",
                TargetID = "thermometerNode",
                SourcePortID  = "tankport10",
                TargetPortID  = "thermoPort",
                Type = Segments.Straight,
                Style = new DiagramStrokeStyle
                {
                    StrokeColor = "black",
                    StrokeWidth = 2,
                    StrokeDashArray = "10,1"
                },
                TargetDecorator = new DiagramDecorator { Shape = DecoratorShapes.None }
            };
            Connectors.Add(connector14);
        }

        private List<DiagramPort > GetPorts(string nodeId)
        {
            List<DiagramPort > ports = new List<DiagramPort >();

            // Define standard ports common to many shapes
            if (nodeId != "controlvalveBox1" && nodeId != "controlvalveBox2" && nodeId != "controlvalveBox3")
            {
                ports.Add(new DiagramPort 
                {
                    Id = "inletLeftPort",
                    Offset = new DiagramPoint { X = 0, Y = 0.5 },
                    Visibility = PortVisibility.Hidden
                });

                ports.Add(new DiagramPort 
                {
                    Id = "outletRightPort",
                    Offset = new DiagramPoint { X = 1, Y = 0.5 },
                    Visibility = PortVisibility.Hidden
                });

                ports.Add(new DiagramPort 
                {
                    Id = "topPort",
                    Offset = new DiagramPoint { X = 0.5, Y = 0 },
                    Visibility = PortVisibility.Hidden
                });

                ports.Add(new DiagramPort 
                {
                    Id = "bottomPort",
                    Offset = new DiagramPoint { X = 0.5, Y = 1 },
                    Visibility = PortVisibility.Hidden
                });
            }

            // Add specific ports for specific Nodes
            if (nodeId == "tank1")
            {
                ports.Add(new DiagramPort 
                {
                    Id = "tankPort1",
                    Offset = new DiagramPoint { X = 1, Y = 0.2 },
                    Visibility = PortVisibility.Visible
                });

                ports.Add(new DiagramPort 
                {
                    Id = "tankPort2",
                    Offset = new DiagramPoint { X = 1, Y = 0.8 },
                    Visibility = PortVisibility.Visible
                });
            }
            else if (nodeId == "mixer1")
            {
                ports.Add(new DiagramPort 
                {
                    Id = "mixertopressureport",
                    Offset = new DiagramPoint { X = 0.94, Y = 0.1 },
                    Visibility = PortVisibility.Hidden
                });
            }
            else if (nodeId == "pressureGuageNode")
            {
                ports.Add(new DiagramPort 
                {
                    Id = "pressuretomixerport",
                    Offset = new DiagramPoint { X = 0.7, Y = 0.5 },
                    Visibility = PortVisibility.Hidden
                });
            }
            else if (nodeId == "thermometerNode")
            {
                ports.Add(new DiagramPort 
                {
                    Id = "thermoPort",
                    Offset = new DiagramPoint { X = 0.2, Y = 0.3 },
                    Visibility = PortVisibility.Hidden
                });
            }
            else if (nodeId == "Tank3Group")
            {
                ports.Add(new DiagramPort 
                {
                    Id = "tankport10",
                    Offset = new DiagramPoint { X = 0.97, Y = 0.8 },
                    Visibility = PortVisibility.Hidden
                });
            }
            else if (nodeId == "pumpBase")
            {
                ports.Add(new DiagramPort 
                {
                    Id = "pumpPort1",
                    Offset = new DiagramPoint { X = 0.94, Y = 0.1 },
                    Visibility = PortVisibility.Hidden
                });

                ports.Add(new DiagramPort 
                {
                    Id = "pumpPort2",
                    Offset = new DiagramPoint { X = 0.97, Y = 0.95 },
                    Visibility = PortVisibility.Hidden
                });
            }

            return ports;
        }
        public class RadialGradient
        {
            [DefaultValue(null)]
            [HtmlAttributeName("cx")]
            [JsonProperty("cx")]
            public double cx
            {
                get;
                set;
            }
            [DefaultValue(null)]
            [HtmlAttributeName("fx")]
            [JsonProperty("fx")]
            public double fx
            {
                get;
                set;
            }
            [DefaultValue(null)]
            [HtmlAttributeName("fy")]
            [JsonProperty("fy")]
            public double fy
            {
                get;
                set;
            }
            [DefaultValue(null)]
            [HtmlAttributeName("cy")]
            [JsonProperty("cy")]
            public double cy
            {
                get;
                set;
            }
            [DefaultValue(null)]
            [HtmlAttributeName("type")]
            [JsonProperty("type")]
            public GradientType type
            {
                get;
                set;
            }
            [DefaultValue(null)]
            [HtmlAttributeName("r")]
            [JsonProperty("r")]
            public double r
            {
                get;
                set;
            }
            [DefaultValue(null)]
            [HtmlAttributeName("stops")]
            [JsonProperty("stops")]
            public List<Stop> Stops
            {
                get;
                set;
            }
        }

        public class Stop
        {
            [DefaultValue(null)]
            [HtmlAttributeName("color")]
            [JsonProperty("color")]
            public string Color
            {
                get;
                set;
            }
            [DefaultValue(null)]
            [HtmlAttributeName("offset")]
            [JsonProperty("offset")]
            public double Offset
            {
                get;
                set;
            }
        }
    }
}
