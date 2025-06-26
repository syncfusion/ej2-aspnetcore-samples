#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.EJ2.Diagrams;

namespace EJ2CoreSampleBrowser.Pages.Diagram;

public class WorkFlowEditorModel : PageModel
{
    public static DiagramSelector Selector { get; set; }
    public List<DiagramUserHandle> Userhandle { get; set; }
    public List<DiagramConnector> connectors { get; set; }
    public List<DiagramNode> nodes { get; set; }
    public void OnGet()

    {
        Userhandle = new List<DiagramUserHandle>();
        Userhandle.Add(new DiagramUserHandle()
        {
            Name = "delete",
            PathData = "M0.97,3.04 L12.78,3.04 L12.78,12.21 C12.78,12.64,12.59,13,12.2,13.3 C11.82,13.6,11.35,13.75,10.8,13.75 L2.95,13.75 C2.4,13.75,1.93,13.6,1.55,13.3 C1.16,13,0.97,12.64,0.97,12.21 Z M4.43,0 L9.32,0 L10.34,0.75 L13.75,0.75 L13.75,2.29 L0,2.29 L0,0.75 L3.41,0.75 Z",
            Offset = 0.5,
            Side = Side.Bottom,
            DisableConnectors = true,
            Tooltip = new { Content = "Delete Node" },
            Margin = new DiagramMargin() { Bottom = 5 }
        });
        Userhandle.Add(new DiagramUserHandle()
        {
            Name = "drawConnector",
            PathData = "M6.09,0 L13.75,6.88 L6.09,13.75 L6.09,9.64 L0,9.64 L0,4.11 L6.09,4.11 Z",
            Offset = 0.5,
            Side = Side.Right,
            DisableConnectors = true,
            Tooltip = new { Content = "Draw Connector" },
            Margin = new DiagramMargin() { Right = 5 }
        });
        Userhandle.Add(new DiagramUserHandle()
        {
            Name = "stopAnimation",
            PathData = "M4.75,0.75 L9.25,0.75 L9.25,9.25 L4.75,9.25 Z",
            DisableNodes = true,
            Tooltip = new { Content = "Enable Animation" }
        });


        Selector = new DiagramSelector();
        Selector.Constraints = SelectorConstraints.UserHandle;
        Selector.UserHandles = Userhandle;



        nodes = new List<DiagramNode>();

        nodes.Add(new DiagramNode()
        {
            Id = "start",
            OffsetX = 100,
            OffsetY = 380,
            Shape = new BpmnShapes()
            {
                Type = "Bpmn",
                Shape = "Event",
                Event = new DiagramBpmnEvent()
                {
                    Event = BpmnEvents.Start,
                    Trigger = BpmnTriggers.None
                }
            },
            Annotations = new List<DiagramNodeAnnotation>() {
                    new DiagramNodeAnnotation() { Content = "Start" }
                }
        });

        nodes.Add(new DiagramNode()
        {
            Id = "liquidInput",
            OffsetX = 300,
            OffsetY = 280,
            Shape = new BpmnShapes()
            {
                Type = "Bpmn",
                Shape = "Activity",
                Activity = new DiagramBpmnActivity()
                {
                    Activity = BpmnActivities.Task,
                }
            },
            Annotations = new List<DiagramNodeAnnotation>() {
                    new DiagramNodeAnnotation() { Content = "Liquid Input" }
                }
        });

        nodes.Add(new DiagramNode()
        {
            Id = "dryInput",
            OffsetX = 300,
            OffsetY = 480,
            Shape = new BpmnShapes()
            {
                Shape = "Activity",
                Type = "Bpmn",
                Activity = new DiagramBpmnActivity()
                {
                    Activity = BpmnActivities.Task,
                }
            },
            Annotations = new List<DiagramNodeAnnotation>() {
                    new DiagramNodeAnnotation() { Content = "Dry Input" }
                }
        });
        nodes.Add(new DiagramNode()
        {
            Id = "condensed",
            OffsetX = 500,
            OffsetY = 180,
            Shape = new BpmnShapes()
            {
                Shape = "Activity",
                Type = "Bpmn",
                Activity = new DiagramBpmnActivity()
                {
                    Activity = BpmnActivities.Task,
                }
            },
            Annotations = new List<DiagramNodeAnnotation>() {
                    new DiagramNodeAnnotation() { Content = "Condensed" }
                }
        });
        nodes.Add(new DiagramNode()
        {
            Id = "cream",
            OffsetX = 500,
            OffsetY = 260,
            Shape = new BpmnShapes()
            {
                Shape = "Activity",
                Type = "Bpmn",
                Activity = new DiagramBpmnActivity()
                {
                    Activity = BpmnActivities.Task,
                }
            },
            Annotations = new List<DiagramNodeAnnotation>() {
                    new DiagramNodeAnnotation() { Content = "Cream" }
                }
        });
        nodes.Add(new DiagramNode()
        {
            Id = "caneSugar",
            OffsetX = 500,
            OffsetY = 340,
            Shape = new BpmnShapes()
            {
                Shape = "Activity",
                Type = "Bpmn",
                Activity = new DiagramBpmnActivity()
                {
                    Activity = BpmnActivities.Task,
                }
            },
            Annotations = new List<DiagramNodeAnnotation>() {
                    new DiagramNodeAnnotation() { Content = "Cane Sugar" }
                }
        });
        nodes.Add(new DiagramNode()
        {
            Id = "water",
            OffsetX = 500,
            OffsetY = 420,
            Shape = new BpmnShapes()
            {
                Shape = "Activity",
                Type = "Bpmn",
                Activity = new DiagramBpmnActivity()
                {
                    Activity = BpmnActivities.Task,
                }
            },
            Annotations = new List<DiagramNodeAnnotation>() {
                    new DiagramNodeAnnotation() { Content = "Water" }
                }
        });
        nodes.Add(new DiagramNode()
        {
            Id = "ingredients",
            OffsetX = 500,
            OffsetY = 500,
            Shape = new BpmnShapes()
            {
                Shape = "Activity",
                Type = "Bpmn",
                Activity = new DiagramBpmnActivity()
                {
                    Activity = BpmnActivities.Task,
                }
            },
            Annotations = new List<DiagramNodeAnnotation>() {
                    new DiagramNodeAnnotation() { Content = "Ingredients" }
                }
        });
        nodes.Add(new DiagramNode()
        {
            Id = "flavour",
            OffsetX = 500,
            OffsetY = 580,
            Shape = new BpmnShapes()
            {
                Shape = "Activity",
                Type = "Bpmn",
                Activity = new DiagramBpmnActivity()
                {
                    Activity = BpmnActivities.Task,
                }

            },
            Annotations = new List<DiagramNodeAnnotation>() {
                    new DiagramNodeAnnotation() { Content = "Flavour" }
                }
        });
        nodes.Add(new DiagramNode()
        {
            Id = "fruitsAndNuts",
            OffsetX = 500,
            OffsetY = 660,
            Shape = new BpmnShapes()
            {
                Shape = "Activity",
                Type = "Bpmn",
                Activity = new DiagramBpmnActivity()
                {
                    Activity = BpmnActivities.Task,
                }
            },
            Annotations = new List<DiagramNodeAnnotation>() {
                    new DiagramNodeAnnotation() { Content = "Fruits And Nuts" }
                }
        });
        nodes.Add(new DiagramNode()
        {
            Id = "blending",
            OffsetX = 700,
            OffsetY = 380,
            Shape = new BpmnShapes()
            {
                Shape = "Activity",
                Type = "Bpmn",
                Activity = new DiagramBpmnActivity()
                {
                    Activity = BpmnActivities.Task,
                }
            },
            Annotations = new List<DiagramNodeAnnotation>() {
                    new DiagramNodeAnnotation() { Content = "Blending" }
                }
        });
        nodes.Add(new DiagramNode()
        {
            Id = "coolingAging",
            OffsetX = 840,
            OffsetY = 380,
            Shape = new BpmnShapes()
            {
                Shape = "Activity",
                Type = "Bpmn",
                Activity = new DiagramBpmnActivity()
                {
                    Activity = BpmnActivities.Task,
                }
            },
            Annotations = new List<DiagramNodeAnnotation>() {
                    new DiagramNodeAnnotation() { Content = "Cooling/Aging" }
                }
        });
        nodes.Add(new DiagramNode()
        {
            Id = "packaging",
            OffsetX = 980,
            OffsetY = 380,
            Shape = new BpmnShapes()
            {
                Shape = "Activity",
                Type = "Bpmn",
                Activity = new DiagramBpmnActivity()
                {
                    Activity = BpmnActivities.Task,
                }
            },
            Annotations = new List<DiagramNodeAnnotation>() {
                    new DiagramNodeAnnotation() { Content = "Packaging" }
                }
        });
        nodes.Add(new DiagramNode()
        {
            Id = "storageDistribution",
            OffsetX = 1130,
            OffsetY = 380,
            Width = 140,
            Shape = new BpmnShapes()
            {
                Shape = "Activity",
                Type = "Bpmn",
                Activity = new DiagramBpmnActivity()
                {
                    Activity = BpmnActivities.Task,
                }
            },
            Annotations = new List<DiagramNodeAnnotation>() {
                    new DiagramNodeAnnotation() { Content = "Storage/Distribution" }
                }
        });
        nodes.Add(new DiagramNode()
        {
            Id = "end",
            OffsetX = 1260,
            OffsetY = 380,
            Shape = new BpmnShapes()
            {
                Shape = "Event",
                Type = "Bpmn",
                Event = new DiagramBpmnEvent()
                {
                    Event = BpmnEvents.End,
                    Trigger = BpmnTriggers.None
                }
            },
            Annotations = new List<DiagramNodeAnnotation>() {
                    new DiagramNodeAnnotation() { Content = "End" }
                }
        });


        connectors = new List<DiagramConnector>();
        connectors.Add(new DiagramConnector() { Id = "c1", SourceID = "start", TargetID = "liquidInput" });
        connectors.Add(new DiagramConnector() { Id = "c2", SourceID = "start", TargetID = "dryInput" });
        connectors.Add(new DiagramConnector() { Id = "c3", SourceID = "liquidInput", TargetID = "condensed" });
        connectors.Add(new DiagramConnector() { Id = "c4", SourceID = "liquidInput", TargetID = "cream" });
        connectors.Add(new DiagramConnector() { Id = "c5", SourceID = "liquidInput", TargetID = "caneSugar" });
        connectors.Add(new DiagramConnector() { Id = "c6", SourceID = "liquidInput", TargetID = "water" });
        connectors.Add(new DiagramConnector() { Id = "c7", SourceID = "liquidInput", TargetID = "ingredients" });

        connectors.Add(new DiagramConnector() { Id = "c8", SourceID = "dryInput", TargetID = "flavour" });
        connectors.Add(new DiagramConnector() { Id = "c9", SourceID = "dryInput", TargetID = "fruitsAndNuts" });
        connectors.Add(new DiagramConnector() { Id = "c10", SourceID = "condensed", TargetID = "blending", });
        connectors.Add(new DiagramConnector() { Id = "c11", SourceID = "cream", TargetID = "blending" });
        connectors.Add(new DiagramConnector() { Id = "c12", SourceID = "caneSugar", TargetID = "blending" });
        connectors.Add(new DiagramConnector() { Id = "c13", SourceID = "water", TargetID = "blending" });
        connectors.Add(new DiagramConnector() { Id = "c14", SourceID = "ingredients", TargetID = "blending" });
        connectors.Add(new DiagramConnector() { Id = "c15", SourceID = "flavour", TargetID = "blending", });
        connectors.Add(new DiagramConnector() { Id = "c16", SourceID = "fruitsAndNuts", TargetID = "blending" });
        connectors.Add(new DiagramConnector() { Id = "c17", SourceID = "blending", TargetID = "coolingAging" });
        connectors.Add(new DiagramConnector() { Id = "c18", SourceID = "coolingAging", TargetID = "packaging", });
        connectors.Add(new DiagramConnector() { Id = "c19", SourceID = "packaging", TargetID = "storageDistribution" });
        connectors.Add(new DiagramConnector() { Id = "c20", SourceID = "storageDistribution", TargetID = "end" });
    }
}