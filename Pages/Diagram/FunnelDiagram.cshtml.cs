#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using EJ2CoreSampleBrowser_NET6.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Newtonsoft.Json;
using Syncfusion.EJ2.Diagrams;
using System.ComponentModel;
using Position = Syncfusion.EJ2.Popups.Position;


namespace EJ2CoreSampleBrowser.Pages.Diagram;

public class FunnelDiagramModel : PageModel
{
    public List<DiagramNode> Nodes { get; set; }
    public List<DiagramConnector> Connectors { get; set; }
    private static class LevelColors
    {
        public const string Level1 = "#C2272D";
        public const string Level2 = "#F16C0D";
        public const string Level3 = "#FFC107";
        public const string Level4 = "#4CB443";
        public const string Level5 = "#008AE0";
        public const string Level6 = "#8715BC";
    }

    // Tooltip Template
    public static string GetToolTemplate(string iconClass, string iconFill, string description, double cumulativeRate, double? conversionRate = null)
    {
        // Conditionally generate the HTML block for the conversion rate if it has a value.
        string conversionRateHtml = conversionRate.HasValue
            ? $@"
        <div style=""display: flex; justify-content: space-between; align-items: center;"">
            <span style=""font-weight: 500; opacity:0.7;"">Conversion</span>
            <span style=""font-weight: 600;"">{conversionRate.Value}%</span>
        </div>"
            : string.Empty;

        return $@" 
<div style=""border-radius: 8px; max-width: 240px; min-width: 180px; padding: 12px; font-family: 'Segoe UI', Arial, sans-serif; font-size: 14px;"">
    <!-- Container for icon and description -->
    <div style=""display: flex; align-items: center; padding: 5px 0px;"">
        <div class=""{iconClass} annotation-icon"" style=""display: flex; align-items: center; justify-content: center;
        width: 34px; height: 34px; background: {iconFill}; color: #FFFFFF; border-radius: 50%; margin-right: 10px;""></div>
        <div style=""font-weight: 600; font-size: 16px;"">
            {description}
        </div>
    </div>
    <hr style=""margin: 3px; border-top: 1px solid #9CA3AF;"">

    <div style=""display: grid; row-gap: 8px;"">
        {conversionRateHtml}
        <div style=""display: flex; justify-content: space-between; align-items: center;"">
            <span style=""font-weight: 500; opacity:0.7;"">Cumulative</span>
            <span style=""font-weight: 600;"">{cumulativeRate}%</span>
        </div>
    </div>
</div>";
    }

    // Title Icon Annotation Template
    public static string GetIconTemplate(string iconClass)
    {
        return $@"<div class=""{iconClass}"" style=""width: 60px; height: 60px; display: flex;align-items: center; justify-content: center; font-size: 34px; color: #FFFFFF !important;"">
            </div>";
    }

    private DiagramNodeAnnotation GetStageLabel(string content)
    {
        return new DiagramNodeAnnotation()
        {
            Content = content,
            Offset = new DiagramPoint() { X = 0, Y = 0.5 },
            HorizontalAlignment = HorizontalAlignment.Right,
            VerticalAlignment = VerticalAlignment.Bottom,
            Margin = new DiagramMargin() { Right = 6, Bottom = 4 },
            Style = new DiagramTextStyle() { FontSize = 16, TextWrapping = TextWrap.NoWrap, FontFamily = "Segoe UI" }
        };
    }

    // Helper factory methods to build nodes and connectors
    private DiagramNode CreateTitleNode()
    {
        return new DiagramNode()
        {
            Id = "title",
            OffsetX = 150,
            OffsetY = -40,
            Width = 250,
            Height = 50,
            Annotations = new List<DiagramNodeAnnotation>()
            {
                new DiagramNodeAnnotation()
                {
                    Content = "Marketing Funnel",
                    Offset = new DiagramPoint() { X = 0.5, Y = 0.2 },
                    Style = new DiagramTextStyle() { Color = "#111827", FontSize = 24, FontFamily = "Segoe UI" }
                },
                new DiagramNodeAnnotation()
                {
                    Content = "Measuring Campaign Effectiveness",
                    Offset = new DiagramPoint() { X = 0.5, Y = 0.7 },
                    Style = new DiagramTextStyle() { Color = "#6B7280", FontSize = 16, FontFamily = "Segoe UI" }
                }
            },
            Constraints = NodeConstraints.PointerEvents | NodeConstraints.Tooltip | NodeConstraints.ReadOnly,
            Style = new DiagramShapeStyle() { StrokeColor = "transparent" }
        };
    }

    private DiagramNode CreateNode(
        string id,
        double width,
        double height,
        string fill,
        double offsetX,
        double offsetY,
        string pathData,
        string valueText,
        string iconClass,
        string description,
        double cumulativeRate,
        double? conversionRate = null,
        double portX = 0.9)
    {
        return new DiagramNode()
        {
            Id = id,
            OffsetX = offsetX,
            OffsetY = offsetY,
            Width = width,
            Height = height,
            Annotations = new List<DiagramNodeAnnotation>()
            {
                new DiagramNodeAnnotation() { Content = valueText, Style = new DiagramTextStyle() { Color = "#FFFFFF", FontSize = 18, FontFamily = "Segoe UI", Bold = true } }
            },
            Shape = new { type = "Path", data = pathData },
            Style = new DiagramShapeStyle() { Fill = fill, StrokeColor = "transparent" },
            Constraints = NodeConstraints.PointerEvents | NodeConstraints.Tooltip | NodeConstraints.ReadOnly,
            Tooltip = new DiagramDiagramTooltip()
            {
                RelativeMode = TooltipRelativeMode.Mouse,
                Position = Position.TopCenter,
                Content = GetToolTemplate(iconClass, fill, description, cumulativeRate, conversionRate)
            },
            Ports = new List<DiagramPort>() { new DiagramPort() { Id = "port", Offset = new DiagramPoint() { X = portX, Y = 0.8 } } }
        };
    }

    private DiagramNode CreateLabelNode(
        string id,
        double width,
        double height,
        string fill,
        double offsetX,
        double offsetY,
        string iconClass,
        string description)
    {
        return new DiagramNode()
        {
            Id = id,
            OffsetX = offsetX,
            OffsetY = offsetY,
            Width = width,
            Height = height,
            Constraints = NodeConstraints.InConnect,
            Annotations = new List<DiagramNodeAnnotation>()
            {
                new DiagramNodeAnnotation() { Template = GetIconTemplate(iconClass) },
                GetStageLabel(description)
            },
            Shape = new { type = "Basic", shape = "Ellipse" },
            Style = new DiagramShapeStyle() { Fill = fill, StrokeColor = fill }
        };
    }

    private DiagramConnector CreateConnector(
        string sourceId,
        string targetId,
        string strokeColor,
        double p1x, double p1y,
        double p2x, double p2y,
        string sourcePortId = "port")
    {
        return new DiagramConnector()
        {
            SourceID = sourceId,
            SourcePortID = sourcePortId,
            TargetID = targetId,
            Constraints = ConnectorConstraints.None,
            TargetDecorator = new DiagramDecorator() { Shape = DecoratorShapes.None },
            Style = new DiagramStrokeStyle() { StrokeColor = strokeColor },
            Segments = new List<DiagramStraightSegment>()
            {
                new DiagramStraightSegment() { Type = Segments.Straight, Point = new DiagramPoint() { X = p1x, Y = p1y } },
                new DiagramStraightSegment() { Type = Segments.Straight, Point = new DiagramPoint() { X = p2x, Y = p2y } }
            }
        };
    }

    public void OnGet()
    {
        InitializeNodes();
        InitializeConnectors();
    }

    private void InitializeNodes()
    {
        Nodes = new List<DiagramNode>()
        {
            // Title Node
            CreateTitleNode(),
            // Funnel Stages
            CreateNode("awareness", 560, 80, LevelColors.Level1, 150, 100, "M560 0H0L56.7194 80H503.281L560 0Z", "10,000", "sf-icon-ads-exposure", "Ad Exposure", 100, null, 0.9),
            CreateNode("interest", 446, 80, LevelColors.Level2, 150, 180, "M503 80H57L113.648 160H446.352L503 80Z", "6,500", "sf-icon-page-visits", "Page Visits", 65, 65.00, 0.89),
            CreateNode("consideration", 334, 80, LevelColors.Level3, 150, 260, "M447 160H113L169.869 240H390.131L447 160Z", "3,800", "sf-icon-sign-up", "Sign Ups", 38, 58.46, 0.85),
            CreateNode("intent", 220, 80, LevelColors.Level4, 150, 340, "M170 240L226.801 320H333.199L390 240H170Z", "2,000", "sf-icon-demo-request", "Demo Requests", 20, 52.63, 0.8),
            CreateNode("purchase", 106, 80, LevelColors.Level5, 150, 420, "M333 320H227V400H333V320Z", "1,200", "sf-icon-orders", "Orders", 12, 60.00, 0.9),
            CreateNode("retention", 106, 80, LevelColors.Level6, 150, 500, "M227 480H333V400H227V480Z", "800", "sf-icon-engagement", "Subscribed Users", 8, 66.67, 0.9),
            // Label Nodes
            CreateLabelNode("awareness_label", 60, 60, LevelColors.Level1, 620, 100, "sf-icon-ads-exposure", "Ad Exposure"),
            CreateLabelNode("interest_label", 60, 60, LevelColors.Level2, 620, 180, "sf-icon-page-visits", "Page Visits"),
            CreateLabelNode("consideration_label", 60, 60, LevelColors.Level3, 620, 260, "sf-icon-sign-up", "Sign Ups"),
            CreateLabelNode("intent_label", 60, 60, LevelColors.Level4, 620, 340, "sf-icon-demo-request", "Demo Requests"),
            CreateLabelNode("purchase_label", 60, 60, LevelColors.Level5, 620, 420, "sf-icon-orders", "Orders"),
            CreateLabelNode("retention_label", 60, 60, LevelColors.Level6, 620, 500, "sf-icon-engagement", "Subscribed Users")
        };
    }


    private void InitializeConnectors()
    {
        Connectors = new List<DiagramConnector>()
        {
            CreateConnector("awareness", "awareness_label", LevelColors.Level1, 430, 124, 455, 98),
            CreateConnector("interest", "interest_label", LevelColors.Level2, 430, 204, 455, 178),
            CreateConnector("consideration", "consideration_label", LevelColors.Level3, 430, 284, 455, 258),
            CreateConnector("intent", "intent_label", LevelColors.Level4, 430, 364, 455, 338),
            CreateConnector("purchase", "purchase_label", LevelColors.Level5, 430, 444, 455, 418),
            CreateConnector("retention", "retention_label", LevelColors.Level6, 430, 524, 455, 498)
        };
    }
}
public class DiagramStraightSegment
{
    [DefaultValue(true)]
    [HtmlAttributeName("allowDrag")]
    [JsonProperty("allowDrag")]
    public bool AllowDrag { get; set; }

    [DefaultValue(null)]
    [HtmlAttributeName("point")]
    [JsonProperty("point")]
    public DiagramPoint Point { get; set; }

    [DefaultValue(Segments.Straight)]
    [HtmlAttributeName("type")]
    [JsonProperty("type")]
    public Segments Type { get; set; }
}