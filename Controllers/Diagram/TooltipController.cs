using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Diagrams;


namespace EJ2CoreSampleBrowser.Controllers.Diagram
{
    public partial class DiagramController : Controller
    {
        public IActionResult Tooltip()
        {

            List<TooltipProperty> modeValue = new List<TooltipProperty>();
            modeValue.Add(new TooltipProperty() { Text = "Object", Type = "Object" });
            modeValue.Add(new TooltipProperty() { Text = "Mouse", Type = "Mouse" });

            List<TooltipProperty> positionValue = new List<TooltipProperty>();
            positionValue.Add(new TooltipProperty() { Text = "TopLeft", Type = "TopLeft" });
            positionValue.Add(new TooltipProperty() { Text = "TopCenter", Type = "TopCenter" });
            positionValue.Add(new TooltipProperty() { Text = "TopRight", Type = "TopRight" });
            positionValue.Add(new TooltipProperty() { Text = "BottomLeft", Type = "BottomLeft" });
            positionValue.Add(new TooltipProperty() { Text = "BottomCenter", Type = "BottomCenter" });
            positionValue.Add(new TooltipProperty() { Text = "BottomRight", Type = "BottomRight" });
            positionValue.Add(new TooltipProperty() { Text = "LeftTop", Type = "LeftTop" });
            positionValue.Add(new TooltipProperty() { Text = "LeftCenter", Type = "LeftCenter" });
            positionValue.Add(new TooltipProperty() { Text = "LeftBottom", Type = "LeftBottom" });
            positionValue.Add(new TooltipProperty() { Text = "RightTop", Type = "RightTop" });
            positionValue.Add(new TooltipProperty() { Text = "RightCenter", Type = "RightCenter" });
            positionValue.Add(new TooltipProperty() { Text = "RightBottom", Type = "RightBottom" });


            List<TooltipProperty> contentValue = new List<TooltipProperty>();
            contentValue.Add(new TooltipProperty() { Text = "HTML Element", Type = "HTML Element" });
            contentValue.Add(new TooltipProperty() { Text = "Text", Type = "Text" });

            List<TooltipProperty> effectValue = new List<TooltipProperty>();
            effectValue.Add(new TooltipProperty() { Text = "FadeIn", Type = "FadeIn" });
            effectValue.Add(new TooltipProperty() { Text = "FadeOut", Type = "FadeOut" });
            effectValue.Add(new TooltipProperty() { Text = "FadeZoomIn", Type = "FadeZoomIn" });
            effectValue.Add(new TooltipProperty() { Text = "FadeZoomOut", Type = "FadeZoomOut" });
            effectValue.Add(new TooltipProperty() { Text = "FlipXDownIn", Type = "FlipXDownIn" });
            effectValue.Add(new TooltipProperty() { Text = "FlipXDownOut", Type = "FlipXDownOut" });
            effectValue.Add(new TooltipProperty() { Text = "FlipXUpIn", Type = "FlipXUpIn" });
            effectValue.Add(new TooltipProperty() { Text = "FlipXUpOut", Type = "FlipXUpOut" });
            effectValue.Add(new TooltipProperty() { Text = "FlipYLeftIn", Type = "FlipYLeftIn" });
            effectValue.Add(new TooltipProperty() { Text = "FlipYLeftOut", Type = "FlipYLeftOut" });
            effectValue.Add(new TooltipProperty() { Text = "FlipYRightIn", Type = "FlipYRightIn" });
            effectValue.Add(new TooltipProperty() { Text = "FlipYRightOut", Type = "FlipYRightOut" });
            effectValue.Add(new TooltipProperty() { Text = "ZoomIn", Type = "ZoomIn" });
            effectValue.Add(new TooltipProperty() { Text = "ZoomOut", Type = "ZoomOut" });
            effectValue.Add(new TooltipProperty() { Text = "None", Type = "None" });


            Animation tooltipAnimation = new Animation()
            {
                open = new Open() { effect = "FadeZoomIn", delay = 0 },
                close = new Open() { effect = "FadeZoomOut", delay = 0 },
            };

            ViewBag.content = "Tooltip";
            ViewBag.position = "TopLeft";
            ViewBag.animation = tooltipAnimation;
            ViewBag.modeValue = modeValue;
            ViewBag.positionValue = positionValue;
            ViewBag.contentValue = contentValue;
            ViewBag.effectValue = effectValue;
            ViewBag.nodes = GetToolTipNodes();
            ViewBag.connectors = GetToolConnectors();
            ViewBag.getNodeDefaults = "getNodeDefaults";
            ViewBag.getConnectorDefaults = "getConnectorDefaults";
            return View();
        }
        private List<DiagramNode> GetToolTipNodes()
        {
            List<DiagramNode> nodes = new List<DiagramNode>();
            {
                nodes.Add(new DiagramNode()
                {
                    Id = "node1",
                    OffsetX = 35,
                    OffsetY = 120,
                    Width = 60,
                    Height = 60,
                    Constraints= NodeConstraints.Default | NodeConstraints.Tooltip,
                    Annotations = new List<DiagramNodeAnnotation>() { new DiagramNodeAnnotation()
                    { Id = "label1", Content = "Customer query",Offset=new PointsShape(){X=0.5,Y=1 },
                        Margin= new DiagramMargin(){ Top=15} } },
                    Shape = new BpmnShapes()
                    {
                        Type = "Bpmn",
                        Shape = "Event",
                        Event = new DiagramBpmnEvent() { Event = BpmnEvents.Start, Trigger = BpmnTriggers.Message },
                    },
                    Tooltip = new DiagramDiagramTooltip() { Content = "Queries from the customer" }
                });
                nodes.Add(new DiagramNode()
                {
                    Id = "node2",
                    OffsetX = 140,
                    OffsetY = 120,
                    Width = 75,
                    Height = 70,
                    Constraints = NodeConstraints.Default | NodeConstraints.Tooltip,
                    Annotations = new List<DiagramNodeAnnotation>() { new DiagramNodeAnnotation()
                    { Id = "label1", Content = "Enough details?",Offset=new PointsShape(){X=0.5,Y=0.5 } } },
                    Shape = new BpmnShapes()
                    {
                        Type = "Bpmn",
                        Shape = "Gateway",
                    },
                    Tooltip = new DiagramDiagramTooltip() { Content = "Whether the provided information is enough?" }
                });
                nodes.Add(new DiagramNode()
                {
                    Id = "node3",
                    OffsetX = 270,
                    OffsetY = 120,
                    Width = 60,
                    Height = 50,
                    Constraints = NodeConstraints.Default | NodeConstraints.Tooltip,
                    Annotations = new List<DiagramNodeAnnotation>() { new DiagramNodeAnnotation()
                    { Id = "label1", Content = "Analyse",Offset=new PointsShape(){X=0.5,Y=0.5 } } },
                    Shape = new BpmnShapes()
                    {
                        Type = "Bpmn",
                        Shape = "Activity",
                        Activity = new DiagramBpmnActivity() { Activity = BpmnActivities.Task }
                    },
                    Tooltip = new DiagramDiagramTooltip() { Content = "Analysing the query" }
                });
                nodes.Add(new DiagramNode()
                {
                    Id = "node4",
                    OffsetX = 385,
                    OffsetY = 120,
                    Width = 75,
                    Height = 70,
                    Constraints = NodeConstraints.Default | NodeConstraints.Tooltip,
                    Shape = new BpmnShapes()
                    {
                        Type = "Bpmn",
                        Shape = "Gateway",
                        gateWay = new DiagramBpmnGateway() { Type = BpmnGateways.Exclusive }
                    },
                    Tooltip = new DiagramDiagramTooltip() { Content = "proceed to validate?" }
                });
                nodes.Add(new DiagramNode()
                {
                    Id = "node5",
                    OffsetX = 570,
                    OffsetY = 120,
                    Width = 75,
                    Height = 70,
                    Constraints = NodeConstraints.Default | NodeConstraints.Tooltip,
                    Annotations = new List<DiagramNodeAnnotation>() { new DiagramNodeAnnotation()
                    { Id = "label1", Content = "Validate",Offset=new PointsShape(){X=0.5,Y=0.5 } } },
                    Shape = new BpmnShapes()
                    {
                        Type = "Bpmn",
                        Shape = "Gateway",
                        gateWay = new DiagramBpmnGateway() { Type = BpmnGateways.Exclusive }
                    },
                    Tooltip = new DiagramDiagramTooltip() { Content = "Whether the reported/requested bug/feature is valid?" }
                });
                nodes.Add(new DiagramNode()
                {
                    Id = "node6",
                    OffsetX = 720,
                    OffsetY = 120,
                    Width = 60,
                    Height = 60,
                    Constraints = NodeConstraints.Default | NodeConstraints.Tooltip,
                    Shape = new BpmnShapes()
                    {
                        Type = "Bpmn",
                        Shape = "Event",
                        Event = new DiagramBpmnEvent() { Event = BpmnEvents.End, Trigger = BpmnTriggers.Message }
                    },
                    Tooltip = new DiagramDiagramTooltip() { Content = "Send the invalid message to customer" }
                });
                nodes.Add(new DiagramNode()
                {
                    Id = "node7",
                    OffsetX = 140,
                    OffsetY = 280,
                    Width = 60,
                    Height = 50,
                    Constraints = NodeConstraints.Default | NodeConstraints.Tooltip,
                    Annotations = new List<DiagramNodeAnnotation>() { new DiagramNodeAnnotation()
                    { Id = "label1", Content = "Request",Offset=new PointsShape(){X=0.5,Y=0.5 } } },
                    Shape = new BpmnShapes()
                    {
                        Type = "Bpmn",
                        Shape = "Activity",
                        Activity = new DiagramBpmnActivity() { Activity = BpmnActivities.Task, Task = new DiagramBpmnTask() { Type = BpmnTasks.Send } }
                    },
                    Tooltip = new DiagramDiagramTooltip() { Content = "Requesting for more information" }
                });
                nodes.Add(new DiagramNode()
                {
                    Id = "node8",
                    OffsetX = 385,
                    OffsetY = 280,
                    Width = 60,
                    Height = 60,
                    Constraints = NodeConstraints.Default | NodeConstraints.Tooltip,
                    Shape = new BpmnShapes()
                    {
                        Type = "Bpmn",
                        Shape = "Event",
                        Event = new DiagramBpmnEvent() { Event = BpmnEvents.Start, Trigger = BpmnTriggers.Message }
                    },
                    Tooltip = new DiagramDiagramTooltip() { Content = "Share the User Guide/Knowledge Base link" }
                });
                nodes.Add(new DiagramNode()
                {
                    Id = "node9",
                    OffsetX = 570,
                    OffsetY = 280,
                    Width = 70,
                    Height = 50,
                    Constraints = NodeConstraints.Default | NodeConstraints.Tooltip,
                    Annotations = new List<DiagramNodeAnnotation>() { new DiagramNodeAnnotation()
                    { Id = "label1", Content = "Log bug/feature",Offset=new PointsShape(){X=0.5,Y=0.5 } } },
                    Shape = new BpmnShapes()
                    {
                        Type = "Bpmn",
                        Shape = "Activity",
                        Activity = new DiagramBpmnActivity() { Activity = BpmnActivities.Task }
                    },
                    Tooltip = new DiagramDiagramTooltip() { Content = "Log the bug/feature" }
                });
                nodes.Add(new DiagramNode()
                {
                    Id = "node10",
                    OffsetX = 390,
                    OffsetY = 430,
                    Width = 75,
                    Height = 55,
                    Constraints = NodeConstraints.Default | NodeConstraints.Tooltip,
                    Annotations = new List<DiagramNodeAnnotation>() { new DiagramNodeAnnotation()
                    { Id = "label1", Content = "Implement",Offset=new PointsShape(){X=0.5,Y=0.5 } } },
                    Shape = new BpmnShapes()
                    {
                        Type = "Bpmn",
                        Shape = "Activity",
                        Activity = new DiagramBpmnActivity()
                        {
                            Activity = BpmnActivities.SubProcess,
                            SubProcess = new DiagramBpmnSubProcess()
                            {
                                Collapsed = false,
                                Events = new List<DiagramBpmnSubEvent>()
                        {
                            new DiagramBpmnSubEvent(){Event=BpmnEvents.Intermediate,Trigger=BpmnTriggers.Timer,Offset=new PointsShape(){X=0.5,Y=1},Width=25,Height=25}
                        }
                            }
                        }
                    },
                    Tooltip = new DiagramDiagramTooltip() { Content = "Fix the bug/Add the feature" }
                });
                nodes.Add(new DiagramNode()
                {
                    Id = "node12",
                    OffsetX = 265,
                    OffsetY = 430,
                    Width = 60,
                    Constraints = NodeConstraints.Default | NodeConstraints.Tooltip,
                    Height = 60,
                    Shape = new BpmnShapes()
                    {
                        Type = "Bpmn",
                        Shape = "Event",
                        Event = new DiagramBpmnEvent() { Event = BpmnEvents.End, Trigger = BpmnTriggers.Message }
                    },
                    Tooltip = new DiagramDiagramTooltip() { Content = "Provide the solution" }
                });
                nodes.Add(new DiagramNode()
                {
                    Id = "node13",
                    OffsetX = 720,
                    OffsetY = 430,
                    Width = 60,
                    Height = 60,
                    Shape = new BpmnShapes()
                    {
                        Type = "Bpmn",
                        Shape = "Event",
                        Event = new DiagramBpmnEvent() { Event = BpmnEvents.End, Trigger = BpmnTriggers.Message }
                    },
                    Tooltip = new DiagramDiagramTooltip() { Content = "Share the task details" }
                });
                nodes.Add(new DiagramNode()
                {
                    Id = "node14",
                    OffsetX = 570,
                    OffsetY = 430,
                    Width = 60,
                    Height = 60,
                    Constraints = NodeConstraints.Default | NodeConstraints.Tooltip,
                    Shape = new BpmnShapes()
                    {
                        Type = "Bpmn",
                        Shape = "Gateway",
                        gateWay = new DiagramBpmnGateway() { Type = BpmnGateways.Parallel }
                    },
                    Tooltip = new DiagramDiagramTooltip() { Content = "can log?" }
                });
                return nodes;
            }
        }

        public List<DiagramConnector> GetToolConnectors()
        {
            List<DiagramConnector> connectors = new List<DiagramConnector>();
            connectors.Add(new DiagramConnector()
            {
                Id = "connector1",
                SourceID = "node1",
                TargetID = "node2"

            });
            connectors.Add(new DiagramConnector()
            {
                Id = "connector2",
                SourceID = "node2",
                TargetID = "node3"

            });
            connectors.Add(new DiagramConnector()
            {
                Id = "connector3",
                SourceID = "node3",
                TargetID = "node4"
            });
            connectors.Add(new DiagramConnector()
            {
                Id = "connector4",
                SourceID = "node4",
                TargetID = "node5",
                Annotations = new List<DiagramConnectorAnnotation>() { new DiagramConnectorAnnotation() {
                    Content ="Feature/Bug",Offset=0.5,Style= new DiagramTextStyle(){Fill="white",TextWrapping=TextWrap.Wrap} } }
            });
            connectors.Add(new DiagramConnector()
            {
                Id = "connector5",
                SourceID = "node5",
                TargetID = "node6",
                Annotations = new List<DiagramConnectorAnnotation>() { new DiagramConnectorAnnotation() { Content = "Invalid", Offset = 0.5, Style = new DiagramTextStyle { Fill = "white" } } }

            });
            connectors.Add(new DiagramConnector()
            {
                Id = "connector6",
                SourceID = "node2",
                TargetID = "node7"
            });
            connectors.Add(new DiagramConnector()
            {
                Id = "connector7",
                SourceID = "node4",
                TargetID = "node8",
                Annotations = new List<DiagramConnectorAnnotation>() { new DiagramConnectorAnnotation() { Content = "How to?", Offset = 0.5, Style = new DiagramTextStyle { Fill = "white" } } }

            });
            connectors.Add(new DiagramConnector()
            {
                Id = "connector8",
                SourceID = "node5",
                TargetID = "node9",
            });
            connectors.Add(new DiagramConnector()
            {
                Id = "connector9",
                SourceID = "node14",
                TargetID = "node13",
            });
            connectors.Add(new DiagramConnector()
            {
                Id = "connector10",
                SourceID = "node7",
                TargetID = "node3",
                Type = Segments.Orthogonal,
                Segments = new List<DiagramSegment>() { new DiagramSegment() { Type="Orthogonal",Length=100,Direction="Right"},
                 new DiagramSegment() { Type="Orthogonal",Length=100,Direction="Top"}}
            });
            connectors.Add(new DiagramConnector()
            {
                Id = "connector11",
                SourceID = "node14",
                TargetID = "node10",
            });
            connectors.Add(new DiagramConnector()
            {
                Id = "connector12",
                SourceID = "node10",
                TargetID = "node12",
            });
            connectors.Add(new DiagramConnector()
            {
                Id = "connector13",
                SourceID = "node9",
                TargetID = "node14",
            });
            return connectors;
        }
    }


    public class Animation
    {
        public object open { get; set; }
        public object close { get; set; }
    }

    public class Open
    {
        public string effect { get; set; }
        public int delay { get; set; }
    }

    public class TooltipProperty
    {
        public string Text { get; set; }

        public string Type { get; set; }
    }

}