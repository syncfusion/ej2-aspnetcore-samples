#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.EJ2.Diagrams;

namespace EJ2CoreSampleBrowser_NET8.Pages.Diagram;

public class AnnotationModel : PageModel
{
    public List<DiagramNode> nodes { get; set; }
    public List<DiagramConnector> Connectors { get; set; }
    public List<FontFamily> font { get; set; }
    public List<TemplateList> templateList { get; set; }

    public void OnGet()
    {
            nodes = new List<DiagramNode>();
            List<DiagramNodeAnnotation> Node1 = new List<DiagramNodeAnnotation>();
            Node1.Add(new DiagramNodeAnnotation() { Content = "Industry Competitors" });
            List<DiagramNodeAnnotation> Node2 = new List<DiagramNodeAnnotation>();
            Node2.Add(new DiagramNodeAnnotation() { Content = "Potential Entrants" });
            List<DiagramNodeAnnotation> Node3 = new List<DiagramNodeAnnotation>();
            Node3.Add(new DiagramNodeAnnotation() { Content = "Suppliers" });
            List<DiagramNodeAnnotation> Node4 = new List<DiagramNodeAnnotation>();
            Node4.Add(new DiagramNodeAnnotation() { Content = "Substitutes" });
            List<DiagramNodeAnnotation> Node5 = new List<DiagramNodeAnnotation>();
            Node5.Add(new DiagramNodeAnnotation() { Content = "Buyers" });

            nodes.Add(new DiagramNode() { Id = "industry", OffsetX = 280, OffsetY = 250, Annotations = Node1, MaxWidth = 150, MaxHeight = 50, Width=150, Height=50 });
            nodes.Add(new DiagramNode() { Id = "potential", OffsetX = 280, OffsetY = 110, Annotations = Node2, MaxWidth = 150, MaxHeight = 50 , Width = 150, Height = 50 });
            nodes.Add(new DiagramNode() { Id = "suplier", OffsetX = 90, OffsetY = 250, Annotations = Node3, MaxWidth = 150, MaxHeight = 50, Width = 150, Height = 50 });
            nodes.Add(new DiagramNode() { Id = "substitutes", OffsetX = 280, OffsetY = 390, Annotations = Node4, MaxWidth = 150, MaxHeight = 50, Width = 150, Height = 50 });
            nodes.Add(new DiagramNode() { Id = "buyers", OffsetX = 470, OffsetY = 250, Annotations = Node5, MaxWidth = 150, MaxHeight = 50, Width = 150, Height = 50 });

            Connectors = new List<DiagramConnector>();
            Connectors.Add(new DiagramConnector() { Id = "connector1", SourceID = "potential", TargetID = "industry", Type = Segments.Orthogonal });
            Connectors.Add(new DiagramConnector() { Id = "connector2", SourceID = "suplier", TargetID = "industry", Type = Segments.Orthogonal });
            Connectors.Add(new DiagramConnector() { Id = "connector3", SourceID = "substitutes", TargetID = "industry", Type = Segments.Orthogonal });
            Connectors.Add(new DiagramConnector() { Id = "connector4", SourceID = "buyers", TargetID = "industry", Type = Segments.Orthogonal });
            Connectors.Add(new DiagramConnector() { Id = "connector5", SourceID = "potential", TargetID = "buyers", Type = Segments.Orthogonal, TargetDecorator = new ConnectorTargetDecoratorConnectors() { Shape = DecoratorShapes.None } });
            Connectors.Add(new DiagramConnector() { Id = "connector6", SourceID = "buyers", TargetID = "substitutes", Type = Segments.Orthogonal, TargetDecorator = new ConnectorTargetDecoratorConnectors() { Shape = DecoratorShapes.None } });
            Connectors.Add(new DiagramConnector() { Id = "connector7", TargetID = "suplier", SourceID = "substitutes", Type = Segments.Orthogonal, TargetDecorator = new ConnectorTargetDecoratorConnectors() { Shape = DecoratorShapes.None } });
            Connectors.Add(new DiagramConnector() { Id = "connector8", SourceID = "suplier", TargetID = "potential", Type = Segments.Orthogonal, TargetDecorator = new ConnectorTargetDecoratorConnectors() { Shape = DecoratorShapes.None } });

             font = new List<FontFamily>();
            font.Add(new FontFamily() { Name = "Arial" });
            font.Add(new FontFamily() { Name = "Aharoni" });
            font.Add(new FontFamily() { Name = "Bell MT" });
            font.Add(new FontFamily() { Name = "Fantasy" });
            font.Add(new FontFamily() { Name = "Times New Roman" });
            font.Add(new FontFamily() { Name = "Segoe UI" });
            font.Add(new FontFamily() { Name = "Verdana" });

            templateList = new List<TemplateList>();
            templateList.Add(new TemplateList() { Value = "none", Text = "None" });
            templateList.Add(new TemplateList() { Value = "industry", Text = "Industry Competitors" });
            templateList.Add(new TemplateList() { Value = "suppliers", Text = "Suppliers" });
            templateList.Add(new TemplateList() { Value = "potential", Text = "Potential Entrants" });
            templateList.Add(new TemplateList() { Value = "buyers", Text = "Buyers" });
            templateList.Add(new TemplateList() { Value = "substitutes", Text = "Substitutes" });

    }
}
public class FontFamily
{
    public string Name;
}

public class TemplateList
{
    public string Value;
    public string Text;
}