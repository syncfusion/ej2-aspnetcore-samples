#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser_NET6.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Newtonsoft.Json;
using Syncfusion.EJ2.Diagrams;
using System.ComponentModel;
using Shapes = Syncfusion.EJ2.Diagrams.Shapes;

namespace EJ2CoreSampleBrowser.Pages.Diagram;

public class VennDiagramModel : PageModel
{
    // Data source for Diagram Nodes
    public List<DiagramNode> Nodes { get; set; }

    // Data source for Diagram Connectors
    public List<DiagramConnector> Connectors { get; set; }

    #region Content and Path Data
    private const string TrigonometryContent = "Trigonometry is a branch \nof mathematics that studies \nthe relationship between \nthe sides and angles of triangles.";
    private const string AssemblyContent = "An assembly is a collection \n of types and resources \nbuilt to work together as \na logical and functional unit.";
    private const string MiddlewareContent = "Software that acts as \na bridge between an operating system\n or database and applications,\n especially over a network.";
    private const string ThesisContent = "A statement or theory\n put forward as a premise \nto be maintained or proved.";
    private const string ExpertiseContent = "Expert skill or knowledge \nin a particular field.";
    private const string ProgrammingContent = "Programming is the process \nof writing code that tells \na computer application or \nsoftware program what to do.";

    private const string AssemblyPath = "M24.3267 27.4281H1.99727C0.894207 27.4281 0 26.551 0 25.469V2.93873C0 1.31571 1.34131 0 2.9959 0H8.10891C8.78495 0.0022957 9.44005 0.230314 9.96637 0.646519L13.9609 3.70279C14.1374 3.83974 14.3551 3.91551 14.5801 3.9183H23.0485C24.7031 3.9183 26.0444 5.23401 26.0444 6.85703V9.79575H29.0003C30.0366 9.80121 30.9975 10.3282 31.5449 11.1913C32.0923 12.0545 32.1496 13.1328 31.6966 14.0471L26.1642 26.331C25.8219 27.0166 25.1048 27.4448 24.3267 27.4281ZM2.61621 25.469H24.3265L29.819 13.2243C30.0052 12.9162 30.0052 12.5331 29.819 12.2251C29.6396 11.9284 29.3118 11.7489 28.9602 11.7549H10.2458C9.86524 11.7587 9.51861 11.9703 9.347 12.3035L2.61621 25.469ZM2.99668 1.95911C2.44515 1.95911 1.99805 2.39768 1.99805 2.93868V22.4126L7.55045 11.5198C8.05333 10.5213 9.0915 9.89056 10.2268 9.89366H23.988V6.95494C23.9773 6.41831 23.5364 5.98579 22.9893 5.97536H14.5209C13.8475 5.97709 13.1932 5.75624 12.6635 5.34844L8.66892 2.27257C8.49247 2.13563 8.27475 2.05985 8.04977 2.05706L2.99668 1.95911Z";
    private const string MiddlewarePath = "M28 12.56V32H8V26H0V0H13.44L19.44 6H21.44L28 12.56ZM8 6H16.58L12.58 2H2V24H8V6ZM26.001 14H20.001V8H10.001V30H26.001V14ZM21.999 12H24.579L21.999 9.41998V12Z";
    private const string ThesisPath = "M22.7097 24.7742L24.7742 22.7097V28.9032H0V8.25806H2.06452V26.8387H22.7097V24.7742ZM20.6452 16.5161C19.2688 16.5161 17.9194 16.6559 16.5968 16.9355C15.2849 17.2043 14.0161 17.6075 12.7903 18.1452C11.5645 18.672 10.3925 19.3226 9.27419 20.0968C8.16667 20.8602 7.13978 21.7312 6.19355 22.7097V20.6452C6.19355 19.3118 6.36559 18.0323 6.70968 16.8065C7.05376 15.5699 7.53763 14.4194 8.16129 13.3548C8.7957 12.2796 9.54839 11.3065 10.4194 10.4355C11.3011 9.55376 12.2742 8.80107 13.3387 8.17742C14.414 7.54301 15.5645 7.05376 16.7903 6.70968C18.0269 6.36559 19.3118 6.19355 20.6452 6.19355V0L32 11.3548L20.6452 22.7097V16.5161ZM22.7097 8.25806C22.0538 8.25806 21.4409 8.26344 20.871 8.27419C20.3011 8.27419 19.7419 8.30107 19.1935 8.35484C18.6559 8.4086 18.1129 8.50538 17.5645 8.64516C17.0161 8.77419 16.4355 8.96774 15.8226 9.22581C14.8871 9.6129 14.0161 10.1075 13.2097 10.7097C12.414 11.3118 11.6989 12 11.0645 12.7742C10.4409 13.5376 9.9086 14.371 9.46774 15.2742C9.03763 16.1667 8.72043 17.1075 8.51613 18.0968C10.3226 16.8925 12.2527 15.9839 14.3065 15.371C16.3602 14.7581 18.4731 14.4516 20.6452 14.4516H22.7097V17.7258L29.0806 11.3548L22.7097 4.98387V8.25806Z";
    private const string CalendarPath = "M9.0833333,10.083334 L11,10.083334 11,12 9.0833333,12 z M1,5 L1,14 13,14 13,5 z M1,2 L1,4 13,4 13,2 12,2 12,2.5 C12,2.776 11.776,3 11.5,3 11.224,3 11,2.776 11,2.5 L11,2 3,2 3,2.5 C3,2.776 2.776,3 2.5,3 2.224,3 2,2.776 2,2.5 L2,2 z M2.5,0 C2.776,0 3,0.22399998 3,0.5 L3,1 11,1 11,0.5 C11,0.22399998 11.224,0 11.5,0 11.776,0 12,0.22399998 12,0.5 L12,1 14,1 14,4 14,5 14,15 0,15 0,5 0,4 0,1 2,1 2,0.5 C2,0.22399998 2.224,0 2.5,0 z";
    private const string NotesPath = "M11,4.7110004 L11,6 12.289001,6 z M5,4 L5,15 13,15 13,7 10,7 10,4 z M1,1 L1,12 4,12 4,3 8.2890015,3 6.2890015,1 z M0,0 L6.7109985,0 9.7109985,3 10.710999,3 14,6.2890015 14,16 4,16 4,13 0,13 z";
    private const string PastePath = "M24 32H0V3.99981H8C8.01001 3.469 8.12559 2.94549 8.34 2.4598C8.55076 1.99273 8.84184 1.56626 9.2 1.19979C9.56763 0.828696 10.0019 0.530157 10.48 0.319788C11.4554 -0.106596 12.5646 -0.106596 13.54 0.319788C14.4839 0.757643 15.2421 1.51586 15.68 2.4598C15.8875 2.9469 15.9963 3.47036 16 3.99981H24V32ZM22 11.9999V5.99983H20V9.99985H4V5.99983H2V30H22M6 5.99988V7.99989H18V5.99988H14V4.25987C13.9895 3.96985 13.9493 3.68167 13.88 3.39986C13.816 3.13337 13.7005 2.88198 13.54 2.65986C13.3845 2.4358 13.1791 2.25094 12.94 2.11986C12.6391 2.01205 12.3183 1.9711 12 1.99986C11.5422 1.94796 11.084 2.09343 10.74 2.39986C10.4674 2.68388 10.2623 3.02569 10.14 3.39986C10.0201 3.829 9.97282 4.27514 10 4.71987V5.99988H6Z";
    #endregion

    public void OnGet()
    {
        InitializeDiagram();
    }

    private void InitializeDiagram()
    {
        Nodes = new List<DiagramNode>();
        Connectors = new List<DiagramConnector>();

        // --- Create Ports ---
        var programmingPort1 = CreatePort("port1", 0.82, 0.35);
        var programmingPort2 = CreatePort("port2", 0.50, 0.8);
        var thesisPort = CreatePort("port1", -0.5, 0.5);
        var middlewarePort = CreatePort("port1", 1.5, 0.5);
        var assemblyPort = CreatePort("port1", -0.5, 0.5);
        var trigonometryPort = CreatePort("port1", 0.50, 0.8);

        // --- Create Annotations ---
        var trigonometryAnnotation = CreateAnnotations("Trigonometry", TrigonometryContent, new DiagramPoint() { X = 0.86, Y = 0.30 }, new DiagramPoint() { X = 0.46, Y = 0.44 }, HorizontalAlignment.Right, hAlign2: HorizontalAlignment.Left);
        var assemblyAnnotation = CreateAnnotations("Assembly", AssemblyContent, new DiagramPoint() { X = 1.3, Y = 0.2 }, new DiagramPoint() { X = 1.3, Y = 1.9 }, HorizontalAlignment.Left, hAlign2: HorizontalAlignment.Left, textAlign: TextAlign.Left, width: 240, height: 150);
        var middlewareAnnotation = CreateAnnotations("Middleware", MiddlewareContent, new DiagramPoint() { X = -0.4, Y = 0.1 }, new DiagramPoint() { X = -0.3, Y = 1.7 }, HorizontalAlignment.Right, hAlign2: HorizontalAlignment.Right, textAlign: TextAlign.Right, width: 240, height: 150);
        var thesisAnnotation = CreateAnnotations("Thesis", ThesisContent, new DiagramPoint() { X = 1.3, Y = 0.2 }, new DiagramPoint() { X = 1.3, Y = 2 }, HorizontalAlignment.Left, hAlign2: HorizontalAlignment.Left, textAlign: TextAlign.Left, width: 240, height: 150);
        var expertiseAnnotation = CreateAnnotations("Expertise", ExpertiseContent, new DiagramPoint() { X = 0.5, Y = 0.7 }, new DiagramPoint() { X = 0.5, Y = 0.80 });
        var programmingAnnotation = CreateAnnotations("Programming", ProgrammingContent, new DiagramPoint() { X = 0.24, Y = 0.3 }, new DiagramPoint() { X = 0.18, Y = 0.44 }, HorizontalAlignment.Left, hAlign2: HorizontalAlignment.Left);

        // --- Create Nodes ---
        Nodes.Add(CreateNode("trigonometry", 615, 255, 350, 350, "#4582F966", "#4582F966", "Basic", null, trigonometryAnnotation, new List<DiagramPort> { trigonometryPort }));
        Nodes.Add(CreateNode("expertise", 500, 465, 350, 350, "#E86F6D66", "#E86F6D66", "Basic", null, expertiseAnnotation));
        Nodes.Add(CreateNode("programming", 390, 255, 350, 350, "#2DC28666", "#2DC28666", "Basic", null, programmingAnnotation, new List<DiagramPort> { programmingPort1, programmingPort2 }));
        Nodes.Add(CreateNode("assemblyNode", 760, 35, 32, 28, "#1D747A", "#1D747A", "Path", AssemblyPath, assemblyAnnotation, new List<DiagramPort> { assemblyPort }));
        Nodes.Add(CreateNode("middlewareNode", 250, 500, 28, 32, "#1E7649", "#1E7649", "Path", MiddlewarePath, middlewareAnnotation, new List<DiagramPort> { middlewarePort }));
        Nodes.Add(CreateNode("thesisNode", 800, 500, 32, 28, "#3A2C7D", "#3A2C7D", "Path", ThesisPath, thesisAnnotation, new List<DiagramPort> { thesisPort }));
        Nodes.Add(CreateNode("calendarNode", 495, 500, 32, 32, "#952B2A", "#952B2A", "Path", CalendarPath));
        Nodes.Add(CreateNode("notesNode", 338, 150, 22, 28, "#187851", "#187851", "Path", NotesPath));
        Nodes.Add(CreateNode("pasteNode", 690, 150, 24, 32, "#213895", "#213895", "Path", PastePath));

        // --- Create Connectors ---
        Connectors.Add(CreateConnector("middlewareToProgramming", "", "middlewareNode", "programming", "#494949", 1, "port1", "port2"));
        Connectors.Add(CreateConnector("assemblyToProgramming", "", "assemblyNode", "programming", "#494949", 1, "port1", "port1"));
        Connectors.Add(CreateConnector("thesisToTrigonometryConnect", "", "thesisNode", "trigonometry", "#494949", 1, "port1", "port1"));
    }

    private DiagramConnector CreateConnector(string id, string lineDashArray, string source, string target, string lineColor, int lineWidth, string sourcePortId, string targetPortId)
    {
        var connector = new DiagramConnector
        {
            Id = id,
            SourceID = source,
            TargetID = target,
            Type = Segments.Bezier,
            BezierSettings = new { AllowSegmentsReset = false },
            Style = new DiagramStrokeStyle { StrokeColor = lineColor, StrokeWidth = lineWidth, StrokeDashArray = lineDashArray },
            TargetDecorator = new DiagramDecorator { Shape = DecoratorShapes.Circle, Width = 6, Height = 6, Style = new DiagramShapeStyle { StrokeColor = "#1D747A", Fill = "#1D747A" } },
            SourceDecorator = new DiagramDecorator { Shape = DecoratorShapes.Circle, Width = 6, Height = 6, Style = new DiagramShapeStyle { StrokeColor = "#1D747A", Fill = "#1D747A" } },
            SourcePortID = sourcePortId,
            TargetPortID = targetPortId
        };

        if (id == "assemblyToProgramming")
        {
            connector.Segments = new List<Object>
            {
                new
                {
                    type = "Bezier",
                    vector1 = new { angle = 190, distance = 100 },
                    vector2 = new { angle = 280, distance = 100 }
                }
            };
        }

        return connector;
    }

    private DiagramNode CreateNode(string id, double offsetX, double offsetY, double width, double height, string fill, string strokeColor, string shape, string pathData = null, List<DiagramNodeAnnotation> annotations = null, List<DiagramPort> ports = null)
    {
        var node = new DiagramNode
        {
            Id = id,
            OffsetX = offsetX,
            OffsetY = offsetY,
            Width = width,
            Height = height,
            Annotations = annotations ?? new List<DiagramNodeAnnotation>(),
            Ports = ports ?? new List<DiagramPort>(),
            Style = new DiagramShapeStyle { Fill = fill, StrokeColor = strokeColor }
        };

        if (shape == "Basic")
        {
            node.Shape = new DiagramBasicShape { Type = Shapes.Basic, Shape = BasicShapes.Ellipse };
        }
        else
        {
            node.Shape = new DiagramPath { Type = Shapes.Path, Data = pathData };
            (node.Style as DiagramShapeStyle).StrokeWidth = 0;
        }

        return node;
    }

    private List<DiagramNodeAnnotation> CreateAnnotations(string content1, string content2, DiagramPoint offset1, DiagramPoint offset2, HorizontalAlignment? hAlign1 = null, VerticalAlignment? vAlign1 = null, HorizontalAlignment? hAlign2 = null, VerticalAlignment? vAlign2 = null, TextAlign textAlign = TextAlign.Center, double width = 0, double height = 0)
    {
        var annotations = new List<DiagramNodeAnnotation>
        {
            new DiagramNodeAnnotation
            {
                Content = content1,
                Offset = offset1,
                Style = new DiagramTextStyle { Bold = true, FontFamily = "Roboto", FontSize = 16 },
                HorizontalAlignment = hAlign1 ?? HorizontalAlignment.Center,
                VerticalAlignment = vAlign1 ?? VerticalAlignment.Center
            },
            new DiagramNodeAnnotation
            {
                Content = content2,
                Offset = offset2,
                Style = new DiagramTextStyle { FontFamily = "Roboto", FontSize = 12, TextAlign = textAlign },
                HorizontalAlignment = hAlign2 ?? HorizontalAlignment.Center,
                VerticalAlignment = vAlign2 ?? VerticalAlignment.Center,
                Width = width,
                Height = height
            }
        };

        if (content1 == "Programming")
        {
            annotations.Add(new DiagramNodeAnnotation
            {
                Content = "Data\n Science",
                Offset = new DiagramPoint { X = 0.91, Y = 0.7 },
                HorizontalAlignment = HorizontalAlignment.Right,
                Style = new DiagramTextStyle { Bold = true, FontFamily = "Roboto", FontSize = 16 }
            });
        }

        return annotations;
    }

    private DiagramPort CreatePort(string id, double x, double y)
    {
        return new DiagramPort
        {
            Id = id,
            Offset = new DiagramPoint { X = x, Y = y },
            Visibility = PortVisibility.Hidden
        };
    }
}