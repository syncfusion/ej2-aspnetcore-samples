#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.EJ2.Diagrams;
using System.ComponentModel;
using Newtonsoft.Json;

namespace EJ2CoreSampleBrowser.Pages.Diagram;

public class BpmnEditorModel : PageModel
{
    public List<SymbolPalettePalette> palettes { get; set; }
    public List<DiagramNode> Nodes { get; set; }
    public List<DiagramConnector> Connectors { get; set; }
    public List<ContextMenuItem> ContextMenuItems { get; set; }
    public void OnGet()
    {
        palettes = new List<SymbolPalettePalette>();
        palettes.Add(new SymbolPalettePalette() { Id = "BPMN", Expanded = true, Symbols = GetBPMNShapes(), IconCss = "e-ddb-icons e-basic", Title = "BPMN Shapes" });
        palettes.Add(new SymbolPalettePalette() { Id = "Connector", Expanded = true, Symbols = GetBPMNConnectors(), IconCss = "e-ddb-icons e-basic", Title = "connectors" });

        Nodes = GetBPMNDiagramNodes();
        Connectors = GetBPMNDiagramConnectors();
        ContextMenuItems = GetContextMenuItems();
    }
    public ContextMenuItem AddItems(string text, string id, string iconCss, string target, List<ContextMenuItem> content)
        {
            ContextMenuItem item = new ContextMenuItem()
            {
                Id = id,
                Text = text,
                Target = target,
                IconCss = iconCss,
                Items = content
            };
            return item;
        }

        public DiagramNode AddBpmnEvent(string Id, double width, double height, double offSetX, double offsetY, BpmnEvents events, DiagramMargin margin, List<DiagramNodeAnnotation> annotation, BpmnTriggers trigger = BpmnTriggers.None)
        {
            DiagramNode node = new DiagramNode();
            node.Id = Id;
            node.Width = width;
            node.Height = height;
            node.OffsetX = offSetX;
            node.OffsetY = offsetY;
            node.Margin = margin;
            node.Annotations = annotation;
            node.Shape = new BpmnShapes()
            {
                Type = "Bpmn",
                Shape = "Event",
                Event = new DiagramBpmnEvent() { Event = events, Trigger = trigger },
            };
            return node;
        }

        public DiagramConnector AddConnector(string Id, string SourceID, string SourcePortID, string TargetID, Segments type, List<DiagramConnectorAnnotation> annotation, DiagramMargin margin, DiagramStrokeStyle style)
        {
            DiagramConnector connector = new DiagramConnector();
            connector.Id = Id;
            connector.SourceID = SourceID;
            if (SourcePortID != "")
            {
                connector.SourcePortID = SourcePortID;
            }
            connector.TargetID = TargetID;
            connector.Type = type;
            connector.Annotations = annotation;
            connector.Style = style;
            connector.Margin = margin;
            return connector;
        }

        public List<DiagramNode> GetBPMNDiagramNodes()
        {
            List<DiagramNode> nodes = new List<DiagramNode>();
            List<DiagramNodeAnnotation> annotation = new List<DiagramNodeAnnotation>();

            nodes.Add(AddBpmnEvent("start", 40, 40, 35, 180, BpmnEvents.Start, new DiagramMargin() { }, annotation));
            nodes.Add(new DiagramNode()
            {
                Id = "subProcess",
                Width = 520,
                Height = 250,
                OffsetX = 355,
                OffsetY = 180,
                Constraints = NodeConstraints.Default | NodeConstraints.AllowDrop,
                Shape = new BpmnShapes()
                {
                    Shape = "Activity",
                    Type = "Bpmn",
                    Activity = new DiagramBpmnActivity()
                    {
                        Activity = BpmnActivities.SubProcess,
                        SubProcess = new DiagramBpmnSubProcess()
                        {
                            Type = BpmnSubProcessTypes.Transaction,
                            Collapsed = false,
                            Processes = new string[] {"processesStart", "service", "compensation", "processesTask",
                           "error", "processesEnd", "user", "subProcessesEnd"}
                        }
                    }
                }
            });
            List<DiagramNodeAnnotation> nodeAnnotation1 = new List<DiagramNodeAnnotation>();
            nodeAnnotation1.Add(new DiagramNodeAnnotation()
            {
                Id = "label1",
                Content = "Hazard",
                Style = new DiagramTextStyle() { Fill = "white", Color = "balck" },
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new DiagramMargin() { Top = 20 }
            });
            nodes.Add(AddBpmnEvent("hazardEnd", 40, 40, 305, 370, BpmnEvents.End, new DiagramMargin() { }, nodeAnnotation1));
            List<DiagramNodeAnnotation> nodeAnnotation2 = new List<DiagramNodeAnnotation>();
            nodeAnnotation2.Add(new DiagramNodeAnnotation()
            {
                Id = "cancelledEndLabel2",
                Content = "Hazard",
                Style = new DiagramTextStyle() { Fill = "white", Color = "balck" },
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new DiagramMargin() { Top = 20 }
            });

            nodes.Add(AddBpmnEvent("cancelledEnd", 40, 40, 545, 370, BpmnEvents.End, new DiagramMargin() { }, nodeAnnotation2));
            nodes.Add(AddBpmnEvent("end", 40, 40, 665, 180, BpmnEvents.End, new DiagramMargin() { }, annotation));

            nodes.Add(AddBpmnEvent("processesStart", 30, 30, 0, 0, BpmnEvents.Start, new DiagramMargin() { Left = 40, Top = 80 }, annotation));

            List<DiagramNodeAnnotation> nodeAnnotation3 = new List<DiagramNodeAnnotation>();
            nodeAnnotation3.Add(new DiagramNodeAnnotation()
            {
                Id = "serviceLabel2",
                Content = "Book hotel",
                Style = new DiagramTextStyle() { Color = "white" }
                        ,
                Margin = new DiagramMargin() { Top = 20, Left = 110 }
            });
            nodes.Add(new DiagramNode()
            {
                Id = "service",
                Width = 95,
                Height = 70,
                Shape = new BpmnShapes()
                {
                    Shape = "Activity",
                    Type = "Bpmn",
                    Activity = new DiagramBpmnActivity()
                    {
                        Activity = BpmnActivities.Task,
                        Task = new DiagramBpmnTask()
                        {
                            Type = BpmnTasks.Service,
                            Loop = BpmnLoops.ParallelMultiInstance
                        }
                    }
                },
                Margin = new DiagramMargin() { Left = 110, Top = 20 },
                Style = new DiagramTextStyle { Fill = "#6FAAB0" },
                Annotations = nodeAnnotation3
            });
            nodes.Add(AddBpmnEvent("compensation", 30, 30, 0, 0, BpmnEvents.Intermediate, new DiagramMargin() { Top = 100, Left = 170 }, annotation, BpmnTriggers.Compensation));

            List<DiagramNodeAnnotation> nodeAnnotation5 = new List<DiagramNodeAnnotation>();
            nodeAnnotation5.Add(new DiagramNodeAnnotation()
            {
                Id = "serviceLabel2",
                Content = "Charge credit card",
                Style = new DiagramTextStyle() { Color = "white" },
                Offset = new DiagramPoint() { X = 0.5, Y = 0.6 },
                Margin = new DiagramMargin() { Top = 20, Left = 110 }
            });
            nodes.Add(new DiagramNode()
            {
                Id = "processesTask",
                Width = 95,
                Height = 70,
                Shape = new BpmnShapes()
                {
                    Shape = "Activity",
                    Type = "Bpmn",
                    Activity = new DiagramBpmnActivity()
                    {
                        Activity = BpmnActivities.Task,
                        Task = new DiagramBpmnTask()
                        {
                            Type = BpmnTasks.Service
                        }
                    }
                },
                Margin = new DiagramMargin() { Left = 290, Top = 20 },
                Style = new DiagramTextStyle { Fill = "#F6B53F" },
                Annotations = nodeAnnotation5
            });
            nodes.Add(AddBpmnEvent("error", 30, 30, 0, 0, BpmnEvents.Intermediate, new DiagramMargin() { Top = 100, Left = 350 }, annotation, BpmnTriggers.Error));
            nodes.Add(AddBpmnEvent("processesEnd", 30, 30, 0, 0, BpmnEvents.End, new DiagramMargin() { Top = 80, Left = 440 }, annotation));

            List<DiagramNodeAnnotation> nodeAnnotation4 = new List<DiagramNodeAnnotation>();
            nodeAnnotation4.Add(new DiagramNodeAnnotation()
            {
                Id = "serviceLabel2",
                Content = "Cancel hotel reservation",
                Style = new DiagramTextStyle() { Color = "white" },
                Offset = new DiagramPoint() { X = 0.5, Y = 0.6 },
                Margin = new DiagramMargin() { Top = 240, Left = 160 }
            });
            nodes.Add(new DiagramNode()
            {
                Id = "user",
                Width = 90,
                Height = 80,

                Shape = new BpmnShapes()
                {
                    Shape = "Activity",
                    Type = "Bpmn",
                    Activity = new DiagramBpmnActivity()
                    {
                        Activity = BpmnActivities.Task,
                        Task = new DiagramBpmnTask()
                        {
                            Type = BpmnTasks.User,
                            Compensation = true
                        }
                    }
                },
                Margin = new DiagramMargin() { Left = 240, Top = 160 },
                Style = new DiagramTextStyle { Fill = "#E94649" },
                Annotations = nodeAnnotation4
            });
            nodes.Add(AddBpmnEvent("subProcessesEnd", 30, 30, 0, 0, BpmnEvents.End, new DiagramMargin() { Top = 210, Left = 440 }, annotation));
            return nodes;
        }

        public List<DiagramConnector> GetBPMNDiagramConnectors()
        {
            List<DiagramConnector> connectors = new List<DiagramConnector>();
            List<DiagramConnectorAnnotation> cAnnotation = new List<DiagramConnectorAnnotation>();
            connectors.Add(AddConnector("connector1", "start", "", "subProcess", Segments.Orthogonal, cAnnotation, new DiagramMargin() { }, new DiagramStrokeStyle() { }));
            connectors.Add(AddConnector("connector2", "subProcess", "success", "end", Segments.Orthogonal, cAnnotation, new DiagramMargin() { }, new DiagramStrokeStyle() { }));
            List<DiagramConnectorAnnotation> annotation1 = new List<DiagramConnectorAnnotation>();
            annotation1.Add(new DiagramConnectorAnnotation()
            {
                Id = "connector3Label2",
                Content = "Booking system failure",
                Offset = 0.5,
                Style = new DiagramTextStyle() { Fill = "white" }
            });
            connectors.Add(AddConnector("connector3", "subProcess", "failure", "hazardEnd", Segments.Orthogonal, annotation1, new DiagramMargin() { }, new DiagramStrokeStyle() { }));

            connectors.Add(AddConnector("connector4", "subProcess", "cancel", "cancelledEnd", Segments.Orthogonal, annotation1, new DiagramMargin() { }, new DiagramStrokeStyle() { }));
            connectors.Add(AddConnector("connector5", "processesStart", "", "service", Segments.Orthogonal, cAnnotation, new DiagramMargin() { }, new DiagramStrokeStyle() { }));
            connectors.Add(AddConnector("connector6", "service", "", "processesTask", Segments.Orthogonal, cAnnotation, new DiagramMargin() { }, new DiagramStrokeStyle() { }));
            connectors.Add(AddConnector("connector7", "processesTask", "", "processesEnd", Segments.Orthogonal, cAnnotation, new DiagramMargin() { }, new DiagramStrokeStyle() { }));
            connectors.Add(AddConnector("connector8", "compensation", "", "user", Segments.Orthogonal, cAnnotation, new DiagramMargin() { }, new DiagramStrokeStyle() { StrokeDashArray = "2,2" }));
            List<DiagramConnectorAnnotation> annotation2 = new List<DiagramConnectorAnnotation>();
            annotation2.Add(new DiagramConnectorAnnotation()
            {
                Id = "connector9Label2",
                Content = "Cannot charge card",
                Offset = 0.5,
                Style = new DiagramTextStyle() { Fill = "white", Color = "black" }
            });
            connectors.Add(AddConnector("connector9", "error", "", "subProcessesEnd", Segments.Orthogonal, cAnnotation, new DiagramMargin() { }, new DiagramStrokeStyle() { }));
            return connectors;
        }

        public List<DiagramNode> GetBPMNShapes()
        {
            List<DiagramNodeAnnotation> annotation = new List<DiagramNodeAnnotation>();
            List<DiagramNode> bpmnNodes = new List<DiagramNode>();
            bpmnNodes.Add(AddBpmnEvent("start", 35, 35, 0, 0, BpmnEvents.Start, new DiagramMargin() { }, annotation));
            bpmnNodes.Add(AddBpmnEvent("nonInterruptingIntermediate", 35, 35, 0, 0, BpmnEvents.NonInterruptingIntermediate, new DiagramMargin() { }, annotation));
            bpmnNodes.Add(AddBpmnEvent("end", 35, 35, 0, 0, BpmnEvents.End, new DiagramMargin() { }, annotation));
            bpmnNodes.Add(new DiagramNode()
            {
                Id = "Task",
                Width = 35,
                Height = 35,
                OffsetX = 700,
                OffsetY = 700,
                Shape = new BpmnShapes() { Type = "Bpmn", Shape = "Activity", Activity = new DiagramBpmnActivity() { Activity = BpmnActivities.Task } }
            });
            bpmnNodes.Add(new DiagramNode()
            {
                Id = "Transaction",
                Width = 35,
                Height = 35,
                OffsetX = 300,
                OffsetY = 100,
                Constraints = NodeConstraints.Default | NodeConstraints.AllowDrop,
                Shape = new BpmnShapes()
                {
                    Type = "Bpmn",
                    Shape = "Activity",
                    Activity = new DiagramBpmnActivity()
                    {
                        Activity = BpmnActivities.SubProcess,
                        SubProcess = new DiagramBpmnSubProcess()
                        {
                            Type = BpmnSubProcessTypes.Transaction,
                            Transaction = new DiagramBpmnTransactionSubProcess()
                            {
                                Cancel = new BpmnTransactionSubProcessCancelTransaction() { Visible = false },
                                Failure = new BpmnTransactionSubProcessFailureTransaction() { Visible = false },
                                Success = new BpmnTransactionSubProcessFailureTransaction() { Visible = false }
                            }
                        }
                    }
                }
            });
            bpmnNodes.Add(new DiagramNode()
            {
                Id = "Task_Service",
                Width = 35,
                Height = 35,
                OffsetX = 700,
                OffsetY = 700,
                Shape = new BpmnShapes() { Type = "Bpmn", Shape = "Activity", Activity = new DiagramBpmnActivity() { Activity = BpmnActivities.Task, Task = new DiagramBpmnTask() { Type = BpmnTasks.Service } } }
            });
            bpmnNodes.Add(new DiagramNode()
            {
                Id = "Gateway",
                Width = 35,
                Height = 35,
                OffsetX = 100,
                OffsetY = 100,
                Shape = new BpmnShapes()
                {
                    Type = "Bpmn",
                    Shape = "Gateway",
                    Gateway = new DiagramBpmnGateway()
                    {
                        Type = BpmnGateways.Exclusive
                    }
                }
            });
            bpmnNodes.Add(new DiagramNode()
            {
                Id = "DataObject",
                Width = 35,
                Height = 35,
                OffsetX = 500,
                OffsetY = 100,
                Shape = new BpmnShapes()
                {
                    Type = "Bpmn",
                    Shape = "DataObject",
                    dataObject = new DiagramBpmnDataObject()
                    {
                        Collection = false,
                        Type = BpmnDataObjects.None
                    }
                }
            });
            bpmnNodes.Add(new DiagramNode()
            {
                Id = "subProcess",
                Width = 520,
                Height = 259,
                OffsetX = 300,
                OffsetY = 100,
                Constraints = NodeConstraints.Default | NodeConstraints.AllowDrop,
                Shape = new BpmnShapes()
                {
                    Type = "Bpmn",
                    Shape = "Activity",
                    Activity = new DiagramBpmnActivity()
                    {
                        Activity = BpmnActivities.SubProcess,
                        SubProcess = new DiagramBpmnSubProcess()
                        {
                            Type = BpmnSubProcessTypes.Transaction,
                            Collapsed = false,
                            Processes = new string[] { },
                            Transaction = new DiagramBpmnTransactionSubProcess()
                            {
                                Cancel = new BpmnTransactionSubProcessCancelTransaction() { Visible = false },
                                Failure = new BpmnTransactionSubProcessFailureTransaction() { Visible = false },
                                Success = new BpmnTransactionSubProcessFailureTransaction() { Visible = false }
                            }
                        }
                    }
                }
            });

            return bpmnNodes;
        }

        public List<DiagramConnector> GetBPMNConnectors()
        {
            List<DiagramConnector> connectors = new List<DiagramConnector>();
            connectors.Add(new DiagramConnector()
            {
                Id = "Link1",
                Type = Segments.Orthogonal,
                SourcePoint = new DiagramPoint() { X = 0, Y = 0 },
                TargetPoint = new DiagramPoint() { X = 40, Y = 40 },
                TargetDecorator = new DiagramDecorator() { Shape = DecoratorShapes.Arrow, Style = new DiagramShapeStyle() { StrokeColor = "#757575", Fill = "#757575" } },
                Style = new DiagramStrokeStyle() { StrokeWidth = 2, StrokeColor = "#757575" }
            });
            connectors.Add(new DiagramConnector()
            {
                Id = "Link2",
                Type = Segments.Orthogonal,
                SourcePoint = new DiagramPoint() { X = 0, Y = 0 },
                TargetPoint = new DiagramPoint() { X = 40, Y = 40 },
                TargetDecorator = new DiagramDecorator() { Shape = DecoratorShapes.Arrow, Style = new DiagramShapeStyle() { StrokeColor = "#757575", Fill = "#757575" } },
                Style = new DiagramStrokeStyle() { StrokeWidth = 2, StrokeDashArray = "4 4", StrokeColor = "#757575" }
            });
            connectors.Add(new DiagramConnector()
            {
                Id = "Link3",
                Type = Segments.Straight,
                SourcePoint = new DiagramPoint() { X = 0, Y = 0 },
                TargetPoint = new DiagramPoint() { X = 40, Y = 40 },
                TargetDecorator = new DiagramDecorator() { Shape = DecoratorShapes.Arrow, Style = new DiagramShapeStyle() { StrokeColor = "#757575", Fill = "#757575" } },
                Style = new DiagramStrokeStyle() { StrokeWidth = 2, StrokeColor = "#757575" }
            });
            connectors.Add(new DiagramConnector()
            {
                Id = "link4",
                Type = Segments.Orthogonal,
                SourcePoint = new DiagramPoint() { X = 0, Y = 0 },
                TargetPoint = new DiagramPoint() { X = 40, Y = 40 },
                TargetDecorator = new DiagramDecorator() { Style = new DiagramShapeStyle() { StrokeColor = "#757575", Fill = "#757575" } },
                Shape = new BpmnConnectors() { Type = "Bpmn", Flow = "Association", Association = "Directional" },
                Style = new DiagramStrokeStyle() { StrokeDashArray = "2,2", StrokeColor = "#757575" }
            });

            return connectors;
        }

        public List<ContextMenuItem> GetContextMenuItems()
        {
            List<ContextMenuItem> item = new List<ContextMenuItem>();
            List<ContextMenuItem> adHocItem = new List<ContextMenuItem>();
            adHocItem.Add(AddItems("None", "AdhocNone", "e-adhocs e-bpmn-icons e-None", "", new List<ContextMenuItem>() { }));
            adHocItem.Add(AddItems("Ad-Hoc", "AdhocAdhoc", "e-adhocs e-bpmn-icons e-adhoc", "", new List<ContextMenuItem>() { }));
            item.Add(AddItems("Ad-Hoc", "Adhoc", "", "", adHocItem));
            List<ContextMenuItem> loopItem = new List<ContextMenuItem>();
            loopItem.Add(AddItems("None", "LoopNone", "e-loop e-bpmn-icons e-None", "", new List<ContextMenuItem>() { }));
            loopItem.Add(AddItems("Standard", "Standard", "e-loop e-bpmn-icons e-Loop", "", new List<ContextMenuItem>() { }));
            loopItem.Add(AddItems("Parallel Multi-Instance", "ParallelMultiInstance", "e-loop e-bpmn-icons e-ParallelMI", "", new List<ContextMenuItem>() { }));
            loopItem.Add(AddItems("Sequence Multi-Instance", "SequenceMultiInstance", "e-loop e-bpmn-icons e-SequentialMI", "", new List<ContextMenuItem>() { }));
            item.Add(AddItems("Loop", "Loop", "", ".e-diagramcontent", loopItem));
            List<ContextMenuItem> compensationItem = new List<ContextMenuItem>();
            compensationItem.Add(AddItems("None", "CompensationNone", "e-compensation e-bpmn-icons e-None", "", new List<ContextMenuItem>() { }));
            compensationItem.Add(AddItems("Compensation", "CompensationCompensation", "e-compensation e-bpmn-icons e-Compensation", "", new List<ContextMenuItem>() { }));
            item.Add(AddItems("Compensation", "taskCompensation", "", "", compensationItem));
            List<ContextMenuItem> activityItem = new List<ContextMenuItem>();
            activityItem.Add(AddItems("Expanded sub - process", "ExpandedSubProcess", "e-bpmn-icons e-SubProcess", "", new List<ContextMenuItem>() { }));
            activityItem.Add(AddItems("Collapsed sub-process", "CollapsedSubProcess", "e-bpmn-icons e-Task", "", new List<ContextMenuItem>() { }));
            item.Add(AddItems("Activity-Type", "Activity-Type", "", "", activityItem));
            List<ContextMenuItem> DataItem = new List<ContextMenuItem>();
            DataItem.Add(AddItems("None", "DataObjectNone", "e-data e-icons e-dataobject", "", new List<ContextMenuItem>() { }));
            DataItem.Add(AddItems("Input", "Input", "e-data e-icons e-datainput", "", new List<ContextMenuItem>() { }));
            DataItem.Add(AddItems("Output", "Output", "e-data e-icons e-dataoutput", "", new List<ContextMenuItem>() { }));
            item.Add(AddItems("Data Object", "DataObject", "", "", DataItem));
            List<ContextMenuItem> boundryItem = new List<ContextMenuItem>();
            boundryItem.Add(AddItems("Default", "Default", "e-boundry e-bpmn-icons e-Default", "", new List<ContextMenuItem>() { }));
            boundryItem.Add(AddItems("Call", "BoundryCall", "e-boundry e-bpmn-icons e-Call", "", new List<ContextMenuItem>() { }));
            boundryItem.Add(AddItems("Event", "BoundryEvent", "e-boundry e-bpmn-icons e-Event", "", new List<ContextMenuItem>() { }));
            item.Add(AddItems("Boundry", "Boundry", "", "", boundryItem));
            List<ContextMenuItem> collectionItem = new List<ContextMenuItem>();
            collectionItem.Add(AddItems("None", "collectionNone", "e-collection e-bpmn-icons e-None", "", new List<ContextMenuItem>() { }));
            collectionItem.Add(AddItems("Collection", "Collectioncollection", "e-collection e-bpmn-icons e-ParallelMI", "", new List<ContextMenuItem>() { }));
            item.Add(AddItems("Collection", "collection", "", "", collectionItem));
            List<ContextMenuItem> callItem = new List<ContextMenuItem>();
            callItem.Add(AddItems("None", "CallNone", "e-call e-bpmn-icons e-None", "", new List<ContextMenuItem>() { }));
            callItem.Add(AddItems("Call", "CallCall", "e-call e-bpmn-icons e-CallActivity", "", new List<ContextMenuItem>() { }));
            item.Add(AddItems("Call", "DeftCall", "", "", callItem));
            List<ContextMenuItem> TriggerItem = new List<ContextMenuItem>();
            TriggerItem.Add(AddItems("None", "TriggerNone", "e-trigger e-bpmn-icons e-None", "", new List<ContextMenuItem>() { }));
            TriggerItem.Add(AddItems("Message", "Message", "e-trigger e-bpmn-icons e-InMessage", "", new List<ContextMenuItem>() { }));
            TriggerItem.Add(AddItems("Parallel", "Parallel", "e-trigger e-bpmn-icons e-InParallelMultiple", "", new List<ContextMenuItem>() { }));
            TriggerItem.Add(AddItems("Multiple", "Multiple", "e-trigger e-bpmn-icons e-InMultiple", "", new List<ContextMenuItem>() { }));
            TriggerItem.Add(AddItems("Signal", "Signal", "e-trigger e-bpmn-icons e-InSignal", "", new List<ContextMenuItem>() { }));
            TriggerItem.Add(AddItems("Timer", "Timer", "e-trigger e-bpmn-icons e-InTimer", "", new List<ContextMenuItem>() { }));
            TriggerItem.Add(AddItems("Escalation", "Escalation", "e-trigger e-bpmn-icons e-InEscalation", "", new List<ContextMenuItem>() { }));
            TriggerItem.Add(AddItems("Error", "Error", "e-trigger e-bpmn-icons e-InError", "", new List<ContextMenuItem>() { }));
            TriggerItem.Add(AddItems("Compensation", "triggerCompensation", "e-trigger e-bpmn-icons e-InCompensation", "", new List<ContextMenuItem>() { }));
            TriggerItem.Add(AddItems("Terminate", "Terminate", "e-trigger e-bpmn-icons e-TerminateEnd", "", new List<ContextMenuItem>() { }));
            TriggerItem.Add(AddItems("Cancel", "Cancel", "e-trigger e-bpmn-icons e-CancelEnd", "", new List<ContextMenuItem>() { }));
            TriggerItem.Add(AddItems("Conditional", "Conditional", "e-trigger e-bpmn-icons e-InConditional", "", new List<ContextMenuItem>() { }));
            TriggerItem.Add(AddItems("Link", "Link", "e-trigger e-bpmn-icons e-ThrowLinkin", "", new List<ContextMenuItem>() { }));
            item.Add(AddItems("Trigger Result", "TriggerResult", "", "", TriggerItem));
            List<ContextMenuItem> EventItem = new List<ContextMenuItem>();
            EventItem.Add(AddItems("Start", "Start", "e-event e-bpmn-icons e-NoneStart", "", new List<ContextMenuItem>() { }));
            EventItem.Add(AddItems("Intermediate", "NonInterruptingStart", "e-event e-bpmn-icons e-InterruptingNone", "", new List<ContextMenuItem>() { }));
            EventItem.Add(AddItems("NonInterruptingStart", "NonInterruptingStart", "e-event e-bpmn-icons e-Noninterruptingstart", "", new List<ContextMenuItem>() { }));
            EventItem.Add(AddItems("ThrowingIntermediate", "ThrowingIntermediate", "e-event e-bpmn-icons e-ThrowingIntermediate", "", new List<ContextMenuItem>() { }));
            EventItem.Add(AddItems("NonInterruptingIntermediate", "NonInterruptingIntermediate", "e-event e-bpmn-icons e-NoninterruptingIntermediate", "", new List<ContextMenuItem>() { }));
            EventItem.Add(AddItems("End", "End", "e-event e-bpmn-icons e-NoneEnd", "", new List<ContextMenuItem>() { }));
            item.Add(AddItems("Event Type", "EventType", "", "", EventItem));
            List<ContextMenuItem> taskItem = new List<ContextMenuItem>();
            taskItem.Add(AddItems("None", "TaskNone", "e-task e-bpmn-icons e-None", "", new List<ContextMenuItem>() { }));
            taskItem.Add(AddItems("Service", "Service", "e-task e-bpmn-icons e-ServiceTask", "", new List<ContextMenuItem>() { }));
            taskItem.Add(AddItems("BusinessRule", "BusinessRule", "e-task e-bpmn-icons e-BusinessRule", "", new List<ContextMenuItem>() { }));
            taskItem.Add(AddItems("InstantiatingReceive", "InstantiatingReceive", "e-task e-bpmn-icons e-InstantiatingReceive", "", new List<ContextMenuItem>() { }));
            taskItem.Add(AddItems("Manual", "Manual", "e-task e-bpmn-icons e-ManualCall", "", new List<ContextMenuItem>() { }));
            taskItem.Add(AddItems("Receive", "Receive", "e-task e-bpmn-icons e-InMessage", "", new List<ContextMenuItem>() { }));
            taskItem.Add(AddItems("Script", "Script", "e-bpmn-icons e-ScriptCall", "", new List<ContextMenuItem>() { }));
            taskItem.Add(AddItems("Send", "Send", "e-task e-bpmn-icons e-OutMessage", "", new List<ContextMenuItem>() { }));
            taskItem.Add(AddItems("User", "User", "e-task e-bpmn-icons e-UserCall", "", new List<ContextMenuItem>() { }));
            item.Add(AddItems("Task Type", "TaskType", "", "", taskItem));
            List<ContextMenuItem> gateWayItem = new List<ContextMenuItem>();
            gateWayItem.Add(AddItems("None", "GateWayNone", "e-gate e-bpmn-icons e-Gateway", "", new List<ContextMenuItem>() { }));
            gateWayItem.Add(AddItems("Inclusive", "Inclusive", "e-gate e-bpmn-icons e-InclusiveGateway", "", new List<ContextMenuItem>() { }));
            gateWayItem.Add(AddItems("Complex", "Complex", "e-gate e-bpmn-icons e-ComplexGateway", "", new List<ContextMenuItem>() { }));
            gateWayItem.Add(AddItems("ExclusiveEventBased", "e-gate e-bpmn-icons e-ExclusiveEventBased", "", "", new List<ContextMenuItem>() { }));
            gateWayItem.Add(AddItems("Exclusive", "Exclusive", "e-gate e-bpmn-icons e-ExclusiveGatewayWithMarker", "", new List<ContextMenuItem>() { }));
            gateWayItem.Add(AddItems("Parallel", "GatewayParallel", "e-gate e-bpmn-icons e-ParallelGateway", "", new List<ContextMenuItem>() { }));
            gateWayItem.Add(AddItems("EventBased", "EventBased", "e-gate e-bpmn-icons e-EventBasedGateway", "", new List<ContextMenuItem>() { }));
            gateWayItem.Add(AddItems("ParallelEventBased", "ParallelEventBased", "e-gate e-bpmn-icons e-ParallelEventBasedGatewayToStart", "", new List<ContextMenuItem>() { }));
            item.Add(AddItems("GateWay", "GateWay", "", "", gateWayItem));
            return item;
        }
}

public class ContextMenuItem
    {
        [DefaultValue(null)]
        [Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeName("text")]
        [JsonProperty("text")]
        public string Text
        {
            get;
            set;
        }
        [DefaultValue(null)]
        [Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeName("id")]
        [JsonProperty("id")]
        public string Id
        {
            get;
            set;
        }
        [DefaultValue(null)]
        [Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeName("target")]
        [JsonProperty("target")]
        public string Target
        {
            get;
            set;
        }
        [DefaultValue(null)]
        [Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeName("iconCss")]
        [JsonProperty("iconCss")]
        public string IconCss
        {
            get;
            set;
        }
        [DefaultValue(null)]
        [Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeName("items")]
        [JsonProperty("items")]
        public List<ContextMenuItem> Items
        {
            get;
            set;
        }
    }

    public class BpmnShapes
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
        [Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeName("shape")]
        [JsonProperty("shape")]
        public string Shape
        {
            get;
            set;
        }
        [DefaultValue(null)]
        [Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeName("activity")]
        [JsonProperty("activity")]
        public DiagramBpmnActivity Activity
        {
            get;
            set;
        }
        [DefaultValue(null)]
        [Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeName("event")]
        [JsonProperty("event")]
        public DiagramBpmnEvent Event
        {
            get;
            set;
        }
        [DefaultValue(null)]
        [Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeName("gateway")]
        [JsonProperty("gateway")]
        public DiagramBpmnGateway Gateway
        {
            get;
            set;
        }
        [DefaultValue(null)]
        [Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeName("dataObject")]
        [JsonProperty("dataObject")]
        public DiagramBpmnDataObject dataObject
        {
            get;
            set;
        }
    }
    public class BpmnConnectors
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
        [Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeName("flow")]
        [JsonProperty("flow")]
        public string Flow
        {
            get;
            set;
        }
        [DefaultValue(null)]
        [Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeName("association")]
        [JsonProperty("association")]
        public string Association
        {
            get;
            set;
        }
    }
    public class Segment
    {
        [DefaultValue(null)]
        [Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeName("type")]
        [JsonProperty("type")]
        public Segments Type
        {
            get;
            set;
        }
        [DefaultValue(null)]
        [Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeName("length")]
        [JsonProperty("length")]
        public double Length
        {
            get;
            set;
        }
        [DefaultValue(null)]
        [Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeName("direction")]
        [JsonProperty("direction")]
        public string Direction
        {
            get;
            set;
        }
    }