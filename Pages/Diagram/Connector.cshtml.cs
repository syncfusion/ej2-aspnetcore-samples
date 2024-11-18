#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.EJ2.Diagrams;
using EJ2CoreSampleBrowser_NET6.Models;
namespace EJ2CoreSampleBrowser.Pages.Diagram;

public class ConnectorModel : PageModel
{
    public List<DiagramNode> nodes { get; set; }
    public List<DiagramConnector> connectors { get; set; }
    public object decoratorShape { get; set; }
    public DiagramSelector selectedItems { get; set; }
    
    public void OnGet()
    {
        nodes = new List<DiagramNode>();

            nodes.Add(new DiagramNode()
            {
                Id = "node1",
                Annotations = new List<DiagramNodeAnnotation>() {
                    new DiagramNodeAnnotation() { Content = "Promotion"}
                },
                Style = new DiagramStrokeStyle() { StrokeColor = "#6f409f", StrokeWidth = 2 },
                Height = 35,
                Width = 80
            });
            nodes.Add(new DiagramNode()
            {
                Id = "node2",
                Annotations = new List<DiagramNodeAnnotation>() {
                    new DiagramNodeAnnotation() { Content = "Lead"}
                },
                Style = new DiagramStrokeStyle() { StrokeColor = "#6f409f", StrokeWidth = 2 },
                Height = 35,
                Width = 80
            });
            nodes.Add(new DiagramNode()
            {
                Id = "node3",
                Annotations = new List<DiagramNodeAnnotation>() {
                    new DiagramNodeAnnotation() { Content = "Account"}
                },
                Style = new DiagramStrokeStyle() { StrokeColor = "#6f409f", StrokeWidth = 2 },
                Height = 35,
                Width = 80
            });
            nodes.Add(new DiagramNode()
            {
                Id = "node4",
                Annotations = new List<DiagramNodeAnnotation>() {
                    new DiagramNodeAnnotation() { Content = "Information"}
                },
                Style = new DiagramStrokeStyle() { StrokeColor = "#6f409f", StrokeWidth = 2 },
                Height = 35,
                Width = 80
            });
            nodes.Add(new DiagramNode()
            {
                Id = "node5",
                Annotations = new List<DiagramNodeAnnotation>() {
                    new DiagramNodeAnnotation() { Content = "Security"}
                },
                Style = new DiagramStrokeStyle() { StrokeColor = "#6f409f", StrokeWidth = 2 },
                Height = 35,
                Width = 80
            });
            nodes.Add(new DiagramNode()
            {
                Id = "node6",
                ExcludeFromLayout = true,
                MaxWidth = 100,
                MaxHeight= 220,
            });

            connectors = new List<DiagramConnector>();
            connectors.Add(new DiagramConnector() { Id = "connector", SourceID = "node1", TargetID = "node2", });
            connectors.Add(new DiagramConnector() { Id = "connector1", SourceID = "node2", TargetID = "node3", SourcePortID = "port1", TargetPortID = "portin" });
            connectors.Add(new DiagramConnector() { Id = "connector2", SourceID = "node2", TargetID = "node4", SourcePortID = "port2", TargetPortID = "portin" });
            connectors.Add(new DiagramConnector() { Id = "connector3", SourceID = "node2", TargetID = "node5", SourcePortID = "port3", TargetPortID = "portin" });
            connectors.Add(new DiagramConnector() { Id = "connector4", SourceID = "node6", TargetID = "node3", SourcePortID = "port4", TargetPortID = "portOut" });
            connectors.Add(new DiagramConnector() { Id = "connector5", SourceID = "node6", TargetID = "node4", SourcePortID = "port5", TargetPortID = "portOut" });
            connectors.Add(new DiagramConnector() { Id = "connector6", SourceID = "node6", TargetID = "node5", SourcePortID = "port6", TargetPortID = "portOut" });

            List<DecoratorShapeList> decoratorshape = new List<DecoratorShapeList>();
            decoratorshape.Add(new DecoratorShapeList() { Name = "None" });
            decoratorshape.Add(new DecoratorShapeList() { Name = "Circle" });
            decoratorshape.Add(new DecoratorShapeList() { Name = "Square" });
            decoratorshape.Add(new DecoratorShapeList() { Name = "Diamond" });
            decoratorshape.Add(new DecoratorShapeList() { Name = "Arrow" });
            decoratorshape.Add(new DecoratorShapeList() { Name = "OpenArrow" });
            decoratorshape.Add(new DecoratorShapeList() { Name = "Fletch" });
            decoratorshape.Add(new DecoratorShapeList() { Name = "OpenFetch" });
            decoratorshape.Add(new DecoratorShapeList() { Name = "IndentedArrow" });
            decoratorshape.Add(new DecoratorShapeList() { Name = "OutdentedArrow" });
            decoratorshape.Add(new DecoratorShapeList() { Name = "DoubleArrow" });
            
            DecoratorShape decoratorShapes = new DecoratorShape();
            decoratorShape = decoratorShapes.decoratorShape();
            selectedItems =new DiagramSelector ();
            selectedItems.Constraints = (SelectorConstraints.ConnectorSourceThumb
                                         | SelectorConstraints.ConnectorTargetThumb);
    }

   
    
}
public class DecoratorShapeList
{
    public string Name;
}
