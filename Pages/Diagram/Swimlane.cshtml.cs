#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.EJ2.Diagrams;
using Syncfusion.EJ2.Navigations;
using System.ComponentModel;
using Newtonsoft.Json;
namespace EJ2CoreSampleBrowser.Pages.Diagram;

public class SwimlaneModel : PageModel
{
    string pathData = "M 120 24.9999 C 120 38.8072 109.642 50 96.8653 50 L 23.135 50 C 10.3578 50 0 38.8072 0 24.9999 L 0 24.9999 C 0 11.1928 10.3578 0 23.135 0 L 96.8653 0 C 109.642 0 120 11.1928 120 24.9999 Z";
    public List<DiagramNode> Nodes { get; set; }
    public List<DiagramConnector> Connectors { get; set; }
    public List<MenuItems> items { get; set; }
    public  List<SymbolPalettePalette> Palette { get; set; }
    public Enum Multiple { get; set; }
    public void OnGet()
    
        {
            Nodes = new List<DiagramNode>();
            GenerateDiagramNodes(Nodes);

             Connectors = new List<DiagramConnector>();
            GenerateDiagramConnectors(Connectors);

            
            List<DiagramPort> ports = new List<DiagramPort>();
            ports.Add(new DiagramPort() { Id="Port1", Offset = new DiagramPoint() { X = 0, Y = 0.5 }, Visibility = PortVisibility.Connect | PortVisibility.Hover, Constraints = PortConstraints.Default |  PortConstraints.Draw });
            ports.Add(new DiagramPort() { Id = "Port2", Offset = new DiagramPoint() { X = 0.5, Y = 0 }, Visibility = PortVisibility.Connect | PortVisibility.Hover, Constraints = PortConstraints.Default |  PortConstraints.Draw });
            ports.Add(new DiagramPort() { Id = "Port3", Offset = new DiagramPoint() { X = 1, Y = 0.5 }, Visibility = PortVisibility.Connect | PortVisibility.Hover, Constraints = PortConstraints.Default |  PortConstraints.Draw });
            ports.Add(new DiagramPort() { Id = "Port4", Offset = new DiagramPoint() { X = 0.5, Y = 1 }, Visibility = PortVisibility.Connect | PortVisibility.Hover, Constraints = PortConstraints.Default |  PortConstraints.Draw });

            List<DiagramNode> SymbolPaletee = new List<DiagramNode>();
            Dictionary<string, object> addInfo = new Dictionary<string, object>();
            addInfo.Add("tooltip", "Terminator");
            SymbolPaletee.Add(new DiagramNode() { Id = "Terminator", AddInfo= addInfo, Ports = ports, Width = 50, Height = 50, Shape = new { type = "Flow", shape = "Terminator" } });
            Dictionary<string, object> addInfo1 = new Dictionary<string, object>();
            addInfo1.Add("tooltip", "Process");
            SymbolPaletee.Add(new DiagramNode() { Id = "Process", AddInfo = addInfo1, Ports = ports, Width = 50, Height = 50, Shape = new { type = "Flow", shape = "Process" } });
            Dictionary<string, object> addInfo2 = new Dictionary<string, object>();
            addInfo2.Add("tooltip", "Document");
            SymbolPaletee.Add(new DiagramNode() { Id = "Document", AddInfo=addInfo2, Ports = ports, Width = 50, Height = 50, Shape = new { type = "Flow", shape = "Document" } });
            Dictionary<string, object> addInfo3 = new Dictionary<string, object>();
            addInfo3.Add("tooltip", "Predefined process");
            SymbolPaletee.Add(new DiagramNode() { Id = "PreDefinedProcess", AddInfo=addInfo3, Ports = ports, Width = 50, Height = 50, Shape = new { type = "Flow", shape = "PreDefinedProcess" }, Style = new DiagramTextStyle() { StrokeColor = "#757575", StrokeWidth = 1 } });
            Dictionary<string, object> addInfo4 = new Dictionary<string, object>();
            addInfo4.Add("tooltip", "Data");
            SymbolPaletee.Add(new DiagramNode() { Id = "data", AddInfo=addInfo4, Ports = ports, Width=50, Height= 50, Shape = new { type = "Flow", shape = "Data" }, Style = new DiagramTextStyle() { StrokeColor = "#757575", StrokeWidth = 1 } });
            List<Lane> lanes = new List<Lane>();
            Lane lane1 = new Lane();
            lane1.Id = "lane1";
            lane1.Height = 60;
            lane1.Width = 150;
            lane1.Header = new Header() { Width = 50, Height = 50, Style = new DiagramTextStyle() { StrokeColor="#757575", FontSize = 11 } };
            lanes.Add(lane1);

            List<Lane> lanes1 = new List<Lane>();
            Lane lane2 = new Lane();
            lane2.Id = "lane2";
            lane2.Height = 150;
            lane2.Width = 60;
            lane2.Header = new Header() { Width = 50, Height = 50, Style = new DiagramTextStyle() { StrokeColor = "#757575", FontSize = 11 } };
            lanes1.Add(lane2);

            List<Phase> phases1 = new List<Phase>();
            Phase phase1 = new Phase();
            phase1.Header = new Header() { Style = new DiagramTextStyle() { StrokeColor = "#757575"} };
            phases1.Add(phase1);

            List<Phase> phases2 = new List<Phase>();
            Phase phase2 = new Phase();
            phase2.Header = new Header() { Style = new DiagramTextStyle() { StrokeColor = "#757575" } };
            phases2.Add(phase1);

            List<DiagramNode> swimlanePalette = new List<DiagramNode>();
            Dictionary<string, object> addInfo5 = new Dictionary<string, object>();
            addInfo5.Add("tooltip", "Horizontal swimlane");
            swimlanePalette.Add(new DiagramNode()
            {
                Id= "stackCanvas1",
                Height=60,
                Width=140,
                AddInfo= addInfo5,
                Shape = new SwimLaneModel()
                {
                    Type = "SwimLane",
                    Lanes = lanes,
                    Orientation = "Horizontal",
                    IsLane =  true
                },
                OffsetX=70,
                OffsetY=30
            });
            Dictionary<string, object> addInfo6 = new Dictionary<string, object>();
            addInfo6.Add("tooltip", "Vertical swimlane");
            swimlanePalette.Add(new DiagramNode()
            {
                Id = "stackCanvas2",
                Height = 140,
                Width = 60,
                AddInfo=addInfo6,
                Shape = new SwimLaneModel()
                {
                    Type = "SwimLane",
                    Lanes = lanes1,
                    Orientation = "Vertical",
                    IsLane = true
                },
                OffsetX = 70,
                OffsetY = 30
            });
            Dictionary<string, object> addInfo7 = new Dictionary<string, object>();
            addInfo7.Add("tooltip", "Vertical phase");
            swimlanePalette.Add(new DiagramNode()
            {
                Id = "verticalPhase",
                Height = 60,
                Width = 140,
                AddInfo= addInfo7,
                Shape = new SwimLaneModel()
                {
                    Type = "SwimLane",
                    Orientation = "Vertical",
                    IsPhase = true,
                    Phases = phases1
                }
            });
            Dictionary<string, object> addInfo8 = new Dictionary<string, object>();
            addInfo8.Add("tooltip", "Horizontal phase");
            swimlanePalette.Add(new DiagramNode()
            {
                Id = "horizontalPhase",
                Height = 60,
                Width = 140,
                AddInfo = addInfo8,
                Shape = new SwimLaneModel()
                {
                    Type = "SwimLane",
                    Orientation = "Horizontal",
                    IsPhase = true,
                    Phases = phases2
                }
            });

            List<DiagramConnector> SymbolPaletteConnectors = new List<DiagramConnector>();
            SymbolPaletteConnectors.Add(new DiagramConnector()
            {
                Id = "Link1",
                Type = Segments.Orthogonal,
                SourcePoint = new DiagramPoint() { X = 0, Y = 0 },
                TargetPoint = new DiagramPoint() { X = 27, Y = 27 },
                TargetDecorator = new ConnectorTargetDecoratorConnectors() { Shape = DecoratorShapes.Arrow, Style = new DiagramShapeStyle() { StrokeColor = "#757575", Fill = "#757575" } },
                Style = new DiagramStrokeStyle() { StrokeWidth = 1, StrokeColor = "#757575" }
            });
            SymbolPaletteConnectors.Add(new DiagramConnector()
            {
                Id = "Link2",
                Type = Segments.Orthogonal,
                SourcePoint = new DiagramPoint() { X = 0, Y = 0 },
                TargetPoint = new DiagramPoint() { X = 27, Y = 27 },
                TargetDecorator = new ConnectorTargetDecoratorConnectors() { Shape = DecoratorShapes.None },
                Style = new DiagramStrokeStyle() { StrokeWidth = 1, StrokeDashArray= "4,4", StrokeColor = "#757575" }
            });

            SymbolPaletteConnectors.Add(new DiagramConnector()
            {
                Id = "Link4",
                Type = Segments.Straight,
                SourcePoint = new DiagramPoint() { X = 0, Y = 0 },
                TargetPoint = new DiagramPoint() { X = 40, Y = 40 },
                TargetDecorator = new ConnectorTargetDecoratorConnectors() { Shape = DecoratorShapes.None },
                Style = new DiagramStrokeStyle() { StrokeWidth = 1, StrokeColor = "#757575" }
            });

            SymbolPaletteConnectors.Add(new DiagramConnector()
            {
                Id = "Link5",
                Type = Segments.Straight,
                SourcePoint = new DiagramPoint() { X = 0, Y = 0 },
                TargetPoint = new DiagramPoint() { X = 40, Y = 40 },
                TargetDecorator = new ConnectorTargetDecoratorConnectors() { Shape = DecoratorShapes.Arrow, Style = new DiagramShapeStyle() { StrokeColor = "#757575", Fill = "#757575" } },
                Style = new DiagramStrokeStyle() { StrokeWidth = 1, StrokeDashArray= "4,4", StrokeColor = "#757575" }
            });


            Palette = new List<SymbolPalettePalette>
            {
                new SymbolPalettePalette() { Id = "basic", Expanded = true, Symbols = SymbolPaletee, IconCss = "e-ddb-icons e-flow", Title = "Basic Shapes" },
                new SymbolPalettePalette() { Id = "swimlane", Expanded = true, Symbols = swimlanePalette, IconCss = "e-ddb-icons e-basic", Title = "Swimlane" },
                new SymbolPalettePalette() { Id = "connectors", Expanded = true, Symbols = SymbolPaletteConnectors, IconCss = "e-ddb-icons e-connector", Title = "Connectors" }
            };

            items = new List<MenuItems>();
            items.Add(new MenuItems() { Id = "Clone", Text = "Clone", Target = ".e-diagramcontent" });
            items.Add(new MenuItems() { Id = "Cut", Text = "Cut", Target = ".e-diagramcontent" });
            items.Add(new MenuItems() { Id = "InsertLaneBefore", Text = "InsertLaneBefore", Target = ".e-diagramcontent" });
            items.Add(new MenuItems() { Id = "InsertLaneAfter", Text = "InsertLaneAfter", Target = ".e-diagramcontent" });
            Multiple = ExpandMode.Multiple;
        }
    public void GenerateDiagramNodes(List<DiagramNode> Nodes)
        {
            List<DiagramPort> ports = new List<DiagramPort>();
            ports.Add(new DiagramPort() { Id = "Port1", Offset = new DiagramPoint() { X = 0, Y = 0.5 }, Visibility = PortVisibility.Connect | PortVisibility.Hover, Constraints = PortConstraints.Default |  PortConstraints.Draw });
            ports.Add(new DiagramPort() { Id = "Port2", Offset = new DiagramPoint() { X = 0.5, Y = 0 }, Visibility = PortVisibility.Connect | PortVisibility.Hover, Constraints = PortConstraints.Default |  PortConstraints.Draw });
            ports.Add(new DiagramPort() { Id = "Port3", Offset = new DiagramPoint() { X = 1, Y = 0.5 }, Visibility = PortVisibility.Connect | PortVisibility.Hover, Constraints = PortConstraints.Default |  PortConstraints.Draw });
            ports.Add(new DiagramPort() { Id = "Port4", Offset = new DiagramPoint() { X = 0.5, Y = 1 }, Visibility = PortVisibility.Connect | PortVisibility.Hover, Constraints = PortConstraints.Default |  PortConstraints.Draw });


            //Add lanes children
            List<DiagramNode> firstLaneChildren = new List<DiagramNode>();
            List<DiagramNodeAnnotation> node1Annotation = new List<DiagramNodeAnnotation>();
            node1Annotation.Add(new DiagramNodeAnnotation() { Content = "Consumer learns \n of product", Style = new DiagramTextStyle() { FontSize = 11 } });
            DiagramNode node1 = new DiagramNode() { Id = "node1", Annotations = node1Annotation, Margin = new DiagramMargin() { Left = 60, Top = 30 }, Height = 40, Width = 100, Ports = ports };
            firstLaneChildren.Add(node1);

            List<DiagramNodeAnnotation> node2Annotation = new List<DiagramNodeAnnotation>();
            node2Annotation.Add(new DiagramNodeAnnotation() { Content = "Does \n Consumer want \n the product", Style = new DiagramTextStyle() { FontSize = 11 } });
            DiagramNode node2 = new DiagramNode() { Id = "node2", Annotations = node2Annotation, Margin = new DiagramMargin() { Left = 200, Top = 20 }, Height = 60, Width = 120, Shape = new { type = "Flow", shape = "Decision" }, Ports = ports };
            firstLaneChildren.Add(node2);

            List<DiagramNodeAnnotation> node3Annotation = new List<DiagramNodeAnnotation>();
            node3Annotation.Add(new DiagramNodeAnnotation() { Content = "No sales lead", Style = new DiagramTextStyle() { FontSize = 11 } });
            DiagramNode node3 = new DiagramNode() { Id = "node3", Shape = new { type = "Path", data = pathData }, Annotations = node3Annotation, Margin = new DiagramMargin() { Left = 370, Top = 30 }, Height = 40, Width = 100, Ports = ports };
            firstLaneChildren.Add(node3);

            List<DiagramNodeAnnotation> node4Annotation = new List<DiagramNodeAnnotation>();
            node4Annotation.Add(new DiagramNodeAnnotation() { Content = "Sell to consumer", Style = new DiagramTextStyle() { FontSize = 11 } });
            DiagramNode node4 = new DiagramNode() { Id = "node4", Shape = new { type = "Path", data = pathData }, Annotations = node4Annotation, Margin = new DiagramMargin() { Left = 510, Top = 30 }, Height = 40, Width = 100, Ports = ports };
            firstLaneChildren.Add(node4);


            List<DiagramNode> secondLaneChildren = new List<DiagramNode>();
            List<DiagramNodeAnnotation> node5Annotation = new List<DiagramNodeAnnotation>();
            node5Annotation.Add(new DiagramNodeAnnotation() { Content = "Create marketing campaigns", Style = new DiagramTextStyle() { FontSize = 11 } });
            DiagramNode node5 = new DiagramNode() { Id = "node5", Annotations = node5Annotation, Margin = new DiagramMargin() { Left = 60, Top = 20 }, Height = 40, Width = 100, Ports = ports };
            secondLaneChildren.Add(node5);

            List<DiagramNodeAnnotation> node6Annotation = new List<DiagramNodeAnnotation>();
            node6Annotation.Add(new DiagramNodeAnnotation() { Content = "Marketing finds sales leads", Style = new DiagramTextStyle() { FontSize = 11 } });
            DiagramNode node6 = new DiagramNode() { Id = "node6", Annotations = node6Annotation, Margin = new DiagramMargin() { Left = 210, Top = 20 }, Height = 40, Width = 100, Ports = ports };
            secondLaneChildren.Add(node6);

            List<DiagramNode> thirdLaneChildren = new List<DiagramNode>();
            List<DiagramNodeAnnotation> node7Annotation = new List<DiagramNodeAnnotation>();
            node7Annotation.Add(new DiagramNodeAnnotation() { Content = "Sales receives lead", Style = new DiagramTextStyle() { FontSize = 11 } });
            DiagramNode node7 = new DiagramNode() { Id = "node7", Annotations = node7Annotation, Margin = new DiagramMargin() { Left = 210, Top = 30 }, Height = 40, Width = 100, Ports = ports };
            thirdLaneChildren.Add(node7);

            List<DiagramNode> fourthLaneChildren = new List<DiagramNode>();
            List<DiagramNodeAnnotation> node8Annotation = new List<DiagramNodeAnnotation>();
            node8Annotation.Add(new DiagramNodeAnnotation() { Content = "Success helps \n retain consumer \n as a customer", Style = new DiagramTextStyle() { FontSize = 11 } });
            DiagramNode node8 = new DiagramNode() { Id = "node8", Annotations = node8Annotation, Margin = new DiagramMargin() { Left = 510, Top = 20 }, Height = 50, Width = 100, Ports = ports };
            fourthLaneChildren.Add(node8);

            //Create swimlane
            DiagramNode swimlane = new DiagramNode();
            swimlane.Id = "swimlane";
            swimlane.Width = 650;
            swimlane.Height = 100;
            swimlane.OffsetX = 440;
            swimlane.OffsetY = 320;
            //Create lanes
            List<Lane> Lanes = new List<Lane>();
            Lanes.Add(new Lane()
            {
                Id = "stackCanvas1",
                Height = 100,
                Header = new Header()
                {
                    Annotation = new DiagramNodeAnnotation() { Content = "Consumer" },
                    Width = 50,
                },
                Children = firstLaneChildren
            });

            Lanes.Add(new Lane()
            {
                Id = "stackCanvas2",
                Height = 100,
                Header = new Header()
                {
                    Annotation = new DiagramNodeAnnotation() { Content = "Marketing" },
                    Width = 50,
                },
                Children = secondLaneChildren
            });

            Lanes.Add(new Lane()
            {
                Id = "stackCanvas3",
                Height = 100,
                Header = new Header()
                {
                    Annotation = new DiagramNodeAnnotation() { Content = "Sales" },
                    Width = 50,
                },
                Children = thirdLaneChildren
            });

            Lanes.Add(new Lane()
            {
                Id = "stackCanvas4",
                Height = 100,
                Header = new Header()
                {
                    Annotation = new DiagramNodeAnnotation() { Content = "Success" },
                    Width = 50,
                },
                Children = fourthLaneChildren
            });

            //Create phases
            List<Phase> Phases = new List<Phase>();
            Phases.Add(new Phase()
            {
                Id = "phase1",
                Offset = 170,
                Header = new Header()
                {
                    Annotation = new DiagramNodeAnnotation() { Content = "Phase" },
                },
            });

            swimlane.Shape = new SwimLane()
            {
                Type = "SwimLane",
                PhaseSize = 20,
                Header = new Header()
                {
                    Annotation = new DiagramNodeAnnotation() { Content = "SALES PROCESS FLOW CHART" },
                    Height = 50,
                    Orientation = "Horizontal",
                    Style = new DiagramTextStyle() { FontSize = 11 }
                },
                Lanes = Lanes,
                Phases = Phases
            };
            Nodes.Add(swimlane);
        }

        //Create connectors
        public void GenerateDiagramConnectors(List<DiagramConnector> Connectors)
        {
            Connectors.Add(CreateSwimlaneConnector("connector1", "node1", "node2",""));
            Connectors.Add(CreateSwimlaneConnector("connector2", "node2", "node3", "No"));
            Connectors.Add(CreateSwimlaneConnector("connector3", "node4", "node8",""));
            Connectors.Add(CreateSwimlaneConnector("connector4", "node2", "node6", "Yes"));
            Connectors.Add(CreateSwimlaneConnector("connector5", "node5", "node1",""));
            Connectors.Add(CreateSwimlaneConnector("connector6", "node6", "node7",""));
            Connectors.Add(CreateSwimlaneConnector("connector7", "node4", "node7",""));
        }
        public DiagramConnector CreateSwimlaneConnector(string id, string sourceID, string targetID, string label)
        {
            DiagramConnector connector = new DiagramConnector();
            connector.Id = id;
            connector.Type = Segments.Orthogonal;
            connector.SourceID = sourceID;
            connector.TargetID = targetID;
            if (sourceID == "node4" && targetID == "node7")
            {
                connector.SourcePortID = "Port1";
                connector.TargetPortID = "Port3";
            }
            if(label != "")
            {
                connector.Annotations = new List<DiagramConnectorAnnotation>()
                {
                    new DiagramConnectorAnnotation()
                    {
                        Content = label,
                        Style = new DiagramTextStyle()
                        {
                            Fill = "white"
                        }
                    }
                };
            }
            return connector;
        }
}
internal class SwimLaneModel
    {
        [DefaultValue(null)]
        [Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeName("type")]
        [JsonProperty("type")]
        public string Type { get; set; }

        [DefaultValue(null)]
        [Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeName("lanes")]
        [JsonProperty("lanes")]
        public List<Lane> Lanes { get; set; }

        [DefaultValue(null)]
        [Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeName("orientation")]
        [JsonProperty("orientation")]
        public string Orientation { get; set; }

        [DefaultValue(null)]
        [Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeName("isLane")]
        [JsonProperty("isLane")]
        public bool IsLane { get; set; }

        [DefaultValue(null)]
        [Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeName("isPhase")]
        [JsonProperty("isPhase")]
        public bool IsPhase { get; set; }

        [DefaultValue(null)]
        [Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeName("phases")]
        [JsonProperty("phases")]
        public List<Phase> Phases { get; set; }
    }

    public class SwimLane
    {
        [DefaultValue(null)]
        [Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeName("type")]
        [JsonProperty("type")]
        public string Type
        {
            get;
            set;
        }
        [DefaultValue(null)]
        [Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeName("header")]
        [JsonProperty("header")]
        public Header Header
        {
            get;
            set;
        }
        [DefaultValue(null)]
        [Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeName("lanes")]
        [JsonProperty("lanes")]
        public List<Lane> Lanes
        {
            get;
            set;
        }
        [DefaultValue(null)]
        [Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeName("phases")]
        [JsonProperty("phases")]
        public List<Phase> Phases
        {
            get;
            set;
        }
        [DefaultValue(null)]
        [Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeName("phaseSize")]
        [JsonProperty("phaseSize")]
        public double PhaseSize
        {
            get;
            set;
        }
    }

    public class Header
    {
        [DefaultValue(null)]
        [Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeName("annotation")]
        [JsonProperty("annotation")]
        public object Annotation
        {
            get;
            set;
        }
        [DefaultValue(null)]
        [Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeName("height")]
        [JsonProperty("height")]
        public double Height
        {
            get;
            set;
        }
        [DefaultValue(null)]
        [Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeName("width")]
        [JsonProperty("width")]
        public double Width
        {
            get;
            set;
        }
        [DefaultValue(null)]
        [Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeName("orientation")]
        [JsonProperty("orientation")]
        public string Orientation
        {
            get;
            set;
        }
        [DefaultValue(null)]
        [Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeName("style")]
        [JsonProperty("style")]
        public DiagramTextStyle Style
        {
            get;
            set;
        }
    }

    public class Lane
    {
        [DefaultValue(null)]
        [Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeName("id")]
        [JsonProperty("id")]
        public string Id
        {
            get;
            set;
        }
        [DefaultValue(null)]
        [Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeName("header")]
        [JsonProperty("header")]
        public Header Header
        {
            get;
            set;
        }
        [DefaultValue(null)]
        [Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeName("style")]
        [JsonProperty("style")]
        public DiagramTextStyle Style
        {
            get;
            set;
        }
        [DefaultValue(null)]
        [Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeName("height")]
        [JsonProperty("height")]
        public double Height
        {
            get;
            set;
        }
        [DefaultValue(null)]
        [Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeName("width")]
        [JsonProperty("width")]
        public double Width
        {
            get;
            set;
        }
        [DefaultValue(null)]
        [Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeName("children")]
        [JsonProperty("children")]
        public List<DiagramNode> Children
        {
            get;
            set;
        }
    }

    public class Phase
    {
        [DefaultValue(null)]
        [Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeName("id")]
        [JsonProperty("id")]
        public string Id
        {
            get;
            set;
        }
        [DefaultValue(null)]
        [Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeName("offset")]
        [JsonProperty("offset")]
        public double Offset
        {
            get;
            set;
        }
        [DefaultValue(null)]
        [Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeName("style")]
        [JsonProperty("style")]
        public DiagramTextStyle Style
        {
            get;
            set;
        }
        [DefaultValue(null)]
        [Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeName("header")]
        [JsonProperty("header")]
        public Header Header
        {
            get;
            set;
        }
    }

    