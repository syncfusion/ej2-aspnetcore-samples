#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using EJ2CoreSampleBrowser_NET6.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.EJ2.Buttons;
using Syncfusion.EJ2.Diagrams;

namespace EJ2CoreSampleBrowser.Pages.Diagram;

public class SpiralDiagramModel : PageModel
{
    public List<DiagramNode> Nodes { get; set; }
    public List<DiagramConnector> Connectors { get; set; }
    public List<FontFamily> Font { get; set; }
    public List<TemplateList> TemplateList { get; set; }
    public DiagramConstraints Constraints { get; set; } = DiagramConstraints.Default & ~DiagramConstraints.UndoRedo;

    public class LifecycleStep
    {
        public string Title { get; set; }
        public string Color { get; set; }
        public string Icon { get; set; }
    }

    const int centerX = 500;
    const int centerY = 500;
    const int angle = 180;
    const int angleStep = 30;
    const int radius = 200;
    const int radiusStep = 65;


    public List<LifecycleStep> lifecycleSteps = new List<LifecycleStep>
{
    new LifecycleStep { Title = "Lifecycle \nof \nSoftware ", Color = "hsl(0, 0%, 20%)" },
    new LifecycleStep { Title = "Ideation", Color = "hsl(10, 80%, 60%)", Icon = "sf-icon-ideation" },
    new LifecycleStep { Title = "Planning", Color = "hsl(20, 80%, 60%)", Icon = "sf-icon-planning" },
    new LifecycleStep { Title = "Requirement Analysis", Color = "hsl(30, 80%, 60%)", Icon = "sf-icon-requirement-analysis" },
    new LifecycleStep { Title = "Research", Color = "hsl(40, 80%, 60%)", Icon = "sf-icon-research" },
    new LifecycleStep { Title = "Design", Color = "hsl(50, 75%, 62%)", Icon = "sf-icon-design" },
    new LifecycleStep { Title = "Prototyping", Color = "hsl(60, 75%, 62%)", Icon = "sf-icon-prototyping" },
    new LifecycleStep { Title = "Frontend Development", Color = "hsl(140, 70%, 55%)", Icon = "sf-icon-front-end-development" },
    new LifecycleStep { Title = "Backend Development", Color = "hsl(150, 70%, 55%)", Icon = "sf-icon-backend-development" },
    new LifecycleStep { Title = "Integration", Color = "hsl(160, 70%, 55%)", Icon = "sf-icon-integration" },
    new LifecycleStep { Title = "Testing", Color = "hsl(180, 65%, 60%)", Icon = "sf-icon-testing" },
    new LifecycleStep { Title = "Bug Fixing", Color = "hsl(190, 65%, 60%)", Icon = "sf-icon-bug-fixing" },
    new LifecycleStep { Title = "Deployment", Color = "hsl(210, 70%, 60%)", Icon = "sf-icon-deployment" },
    new LifecycleStep { Title = "User Training", Color = "hsl(220, 70%, 60%)", Icon = "sf-icon-user-training" },
    new LifecycleStep { Title = "Monitoring", Color = "hsl(240, 70%, 65%)", Icon = "sf-icon-monitoring" },
    new LifecycleStep { Title = "Feedback Collection", Color = "hsl(250, 70%, 65%)", Icon = "sf-icon-feedback" },
    new LifecycleStep { Title = "Iteration", Color = "hsl(260, 70%, 65%)", Icon = "sf-icon-iteration" },
    new LifecycleStep { Title = "Scalability Improvements", Color = "hsl(280, 70%, 60%)", Icon = "sf-icon-scalability-improvements" },
    new LifecycleStep { Title = "Security Audit", Color = "hsl(290, 70%, 60%)", Icon = "sf-icon-security-audit" },
    new LifecycleStep { Title = "Performance Tuning", Color = "hsl(300, 70%, 60%)", Icon = "sf-icon-performance-tuning" },
    new LifecycleStep { Title = "Documentation", Color = "hsl(320, 60%, 65%)", Icon = "sf-icon-documentation" },
    new LifecycleStep { Title = "Customer Support", Color = "hsl(330, 60%, 65%)", Icon = "sf-icon-customer-support" },
    new LifecycleStep { Title = "Feature Expansion", Color = "hsl(345, 60%, 60%)", Icon = "sf-icon-feature-expansion" },
    new LifecycleStep { Title = "Sales & Marketing", Color = "hsl(355, 60%, 60%)", Icon = "sf-icon-sales-marketing" },
    new LifecycleStep { Title = "Partnerships", Color = "hsl(5, 60%, 60%)", Icon = "sf-icon-partnership" },
    new LifecycleStep { Title = "End-of-Life Plan", Color = "hsl(15, 60%, 60%)", Icon = "sf-icon-end-plan" }
};

    public DiagramPoint PolarToCartesian(double cx, double cy, double r, double angleDeg)
    {
        double rad = (angleDeg - 90) * Math.PI / 180;
        return new DiagramPoint
        {
            X = cx + r * Math.Cos(rad),
            Y = cy + r * Math.Sin(rad)
        };
    }
    void CreateSpiralDiagram()
    {
        // Center node
        Nodes?.Add(new Node
        {
            Id = "node0",
            OffsetX = centerX + 30,
            OffsetY = centerY,
            Width = 150,
            Height = 150,
            Shape = new { type = "Basic", shape = "Ellipse" },
            Constraints = NodeConstraints.Default | NodeConstraints.Shadow,
            Annotations = new List<DiagramNodeAnnotation>()
            {
                new DiagramNodeAnnotation
                {
                    Content = lifecycleSteps[0].Title,
                    Width=100,
                    Style = new DiagramTextStyle { Color = "#FFFFFF", FontSize = 18, Bold = true }
                },
            },
            Style = new NodeStyleNodes
            {
                Fill = lifecycleSteps[0].Color,
                StrokeColor = "white",
                StrokeWidth = 2,
            },
        });

        for (int i = 1; i < lifecycleSteps.Count; i++)
        {
            var step = lifecycleSteps[i];
            var point = PolarToCartesian(centerX, centerY, radius + (i * radiusStep / (2 * Math.PI)), angle + (i * angleStep));

            Nodes?.Add(new Node
            {
                Id = $"node{i}",
                OffsetX = point.X,
                OffsetY = point.Y,
                Width = 85,
                Height = 85,
                Shape = new { type = "Basic", shape = "Ellipse" },
                Constraints = NodeConstraints.Default | NodeConstraints.Shadow | NodeConstraints.Tooltip,
                Tooltip = new DiagramDiagramTooltip() { Content = step.Title, RelativeMode = TooltipRelativeMode.Object },
                Annotations = new List<DiagramNodeAnnotation>()
                {
                    new DiagramNodeAnnotation
                    {
                        Template= $"<div class=\"{step.Icon}\" style=\"text-align: center;\"></div>",
                        Width=50,
                        Height=50,
                    }
                },
                Style = new NodeStyleNodes
                {
                    Fill = step.Color,
                    StrokeColor = "#FFFFFF",
                    StrokeWidth = 2,

                },
            });

            if (i != 1)
            {
                Connectors?.Add(new DiagramConnector
                {
                    Id = $"connector{i}",
                    SourceID = $"node{i - 1}",
                    TargetID = $"node{i}",
                    Type = Segments.Straight,
                    Style = new DiagramStrokeStyle
                    {
                        StrokeColor = "#9CA3AF",
                        StrokeWidth = 2,
                        StrokeDashArray = "0"
                    },
                    TargetDecorator = new DiagramDecorator
                    {
                        Shape = DecoratorShapes.Arrow,
                        Style = new DiagramShapeStyle
                        {
                            Fill = "#9CA3AF",
                            StrokeColor = "#9CA3AF"
                        }
                    }
                });
            }
        }
    }


    public void OnGet()
    {
        Nodes = new List<DiagramNode>();
        Connectors = new List<DiagramConnector>();
        CreateSpiralDiagram();

    }
}
