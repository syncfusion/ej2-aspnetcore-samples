#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Diagrams;
using System.Security.Cryptography.X509Certificates;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Syncfusion.EJ2;

namespace EJ2CoreSampleBrowser.Controllers.Diagram
{
    public partial class DiagramController : Controller
    {
        public IActionResult WorkFlowEditor()
        {
            List<DiagramNode> nodes = new List<DiagramNode>();
            List<DiagramPort> ports = new List<DiagramPort>();
            ports.Add(new DiagramPort() { Id = "port1", Offset = new DiagramPoint() { X = 0.5f, Y = 0 }, Visibility = PortVisibility.Hidden });

            nodes.Add(new DiagramNode()
            {
                Id = "newTravelRequestRecieved",
                OffsetX = 100,
                OffsetY = 245,
                Width = 60,
                Height = 60,
                Shape = new BpmnShapes()
                {
                    Type = "Bpmn",
                },
            });

            nodes.Add(new DiagramNode()
            {
                Id = "getTravelRequestDetails",
                OffsetX = 250,
                OffsetY = 245,
                Width = 100,
                Height = 80,

                Shape = new BpmnShapes()
                {
                    Shape = "Activity",
                    Type = "Bpmn",
                    Activity = new DiagramBpmnActivity()
                    {
                        Activity = BpmnActivities.Task,
                    }
                },
            });

            List<DiagramPort> ports1 = new List<DiagramPort>();
            ports1.Add(new CustomPort() { Id = "port1", Offset = new DiagramPoint() { X = 0, Y = 0.5f }, Visibility = PortVisibility.Hidden });


            nodes.Add(new DiagramNode()
            {
                Id = "getRequesterProfile",
                OffsetX = 400,
                OffsetY = 245,
                Width = 100,
                Height = 80,
                Shape = new BpmnShapes()
                {
                    Shape = "Activity",
                    Type = "Bpmn",
                    Activity = new DiagramBpmnActivity()
                    {
                        Activity = BpmnActivities.Task,
                    }
                },
            });
            nodes.Add(new DiagramNode()
            {
                Id = "getManagerDetails",
                OffsetX = 550,
                OffsetY = 245,
                Width = 100,
                Height = 80,
                Shape = new BpmnShapes()
                {
                    Shape = "Activity",
                    Type = "Bpmn",
                    Activity = new DiagramBpmnActivity()
                    {
                        Activity = BpmnActivities.Task,
                    }
                },
            });
            nodes.Add(new DiagramNode()
            {
                Id = "setStatusAsRejected",
                OffsetX = 700,
                OffsetY = 245,
                Width = 100,
                Height = 80,
                Shape = new BpmnShapes()
                {
                    Shape = "Activity",
                    Type = "Bpmn",
                    Activity = new DiagramBpmnActivity()
                    {
                        Activity = BpmnActivities.Task,
                    }
                },
            });
            nodes.Add(new DiagramNode()
            {
                Id = "setStatusAsAccepted",
                OffsetX = 850,
                OffsetY = 245,
                Width = 100,
                Height = 80,
                Shape = new BpmnShapes()
                {
                    Shape = "Activity",
                    Type = "Bpmn",
                    Activity = new DiagramBpmnActivity()
                    {
                        Activity = BpmnActivities.Task,
                    }
                },
            });
            nodes.Add(new DiagramNode()
            {
                Id = "setNextApprovalStatusAsRejected",
                OffsetX = 1100,
                OffsetY = 245,
                Width = 100,
                Height = 80,
                Shape = new BpmnShapes()
                {
                    Shape = "Activity",
                    Type = "Bpmn",
                    Activity = new DiagramBpmnActivity()
                    {
                        Activity = BpmnActivities.Task,
                    }
                },
            });
            nodes.Add(new DiagramNode()
            {
                Id = "setNextApprovalStatusAsAccepted",
                OffsetX = 1250,
                OffsetY = 245,
                Width = 100,
                Height = 80,
                Shape = new BpmnShapes()
                {
                    Shape = "Activity",
                    Type = "Bpmn",
                    Activity = new DiagramBpmnActivity()
                    {
                        Activity = BpmnActivities.Task,
                    }
                },
            });
            nodes.Add(new DiagramNode()
            {
                Id = "initiateApprovalWithManager",
                OffsetX = 550,
                OffsetY = 445,
                Width = 100,
                Height = 80,
                Shape = new BpmnShapes()
                {
                    Shape = "Activity",
                    Type = "Bpmn",
                    Activity = new DiagramBpmnActivity()
                    {
                        Activity = BpmnActivities.Task,
                    }
                },
            });
            nodes.Add(new DiagramNode()
            {
                Id = "checkApprovalStatus",
                OffsetX = 700,
                OffsetY = 445,
                Width = 100,
                Height = 80,
                Shape = new BpmnShapes()
                {
                    Shape = "Gateway",
                    Type = "Bpmn",

                    gateWay = new DiagramBpmnGateway()
                    {
                        Type = BpmnGateways.Exclusive,
                    }
                },
            });
            nodes.Add(new DiagramNode()
            {
                Id = "checkIfItIsAnInternaltionalTravel",
                OffsetX = 850,
                OffsetY = 445,
                Width = 100,
                Height = 80,
                Shape = new BpmnShapes()
                {
                    Shape = "Gateway",
                    Type = "Bpmn",

                    gateWay = new DiagramBpmnGateway()
                    {
                        Type = BpmnGateways.Exclusive,
                    }
                },
            });

            nodes.Add(new DiagramNode()
            {
                Id = "initialteApprovalWithNextLevelManager",
                OffsetX = 1000,
                OffsetY = 445,
                Width = 100,
                Height = 80,
                Shape = new BpmnShapes()
                {
                    Shape = "Activity",
                    Type = "Bpmn",
                    Activity = new DiagramBpmnActivity()
                    {
                        Activity = BpmnActivities.Task,
                    }
                },
            });
            nodes.Add(new DiagramNode()
            {
                Id = "checkLevel2-ApprovalStatus",
                OffsetX = 1130,
                OffsetY = 445,
                Width = 100,
                Height = 80,
                Shape = new BpmnShapes()
                {
                    Type = "Bpmn",
                    Shape = "Gateway",

                    gateWay = new DiagramBpmnGateway()
                    {
                        Type = BpmnGateways.Parallel
                    }
                },
            });



            List<DiagramConnector> connectors = new List<DiagramConnector>();
            connectors.Add(new DiagramConnector() { Id = "newTravelRequestRecieved-getTravelRequestDetails", SourceID = "newTravelRequestRecieved", TargetID = "getTravelRequestDetails", });
            connectors.Add(new DiagramConnector() { Id = "getTravelRequestDetails-getRequesterProfile", SourceID = "getTravelRequestDetails", TargetID = "getRequesterProfile", });
            connectors.Add(new DiagramConnector() { Id = "getRequesterProfile-getManagerDetails", SourceID = "getRequesterProfile", TargetID = "getManagerDetails", });
            connectors.Add(new DiagramConnector() { Id = "getManagerDetails-initiateApprovalWithManager", SourceID = "getManagerDetails", TargetID = "initiateApprovalWithManager", });
            connectors.Add(new DiagramConnector() { Id = "initiateApprovalWithManager-checkApprovalStatus", SourceID = "initiateApprovalWithManager", TargetID = "checkApprovalStatus", });
            connectors.Add(new DiagramConnector() { Id = "checkApprovalStatus-setStatusAsRejected", SourceID = "checkApprovalStatus", TargetID = "setStatusAsRejected", Annotations = new List<DiagramConnectorAnnotation>() { new DiagramConnectorAnnotation() { Content = "Rejected", Offset = 0.4, Style = new DiagramTextStyle { Fill = "white" } } } });
            connectors.Add(new DiagramConnector() { Id = "checkApprovalStatus-checkIfItIsAnInternaltionalTravel", SourceID = "checkApprovalStatus", TargetID = "checkIfItIsAnInternaltionalTravel", Annotations = new List<DiagramConnectorAnnotation>() { new DiagramConnectorAnnotation() { Content = "Accepted", Offset = 0.4, Style = new DiagramTextStyle { Fill = "white" } } } });
            connectors.Add(new DiagramConnector() { Id = "checkIfItIsAnInternaltionalTravel-setStatusAsAccepted", SourceID = "checkIfItIsAnInternaltionalTravel", TargetID = "setStatusAsAccepted", Annotations = new List<DiagramConnectorAnnotation>() { new DiagramConnectorAnnotation() { Content = "No", Offset = 0.4, Style = new DiagramTextStyle { Fill = "white" } } } });
            connectors.Add(new DiagramConnector() { Id = "checkIfItIsAnInternaltionalTravel-initialteApprovalWithNextLevelManager", SourceID = "checkIfItIsAnInternaltionalTravel", TargetID = "initialteApprovalWithNextLevelManager", Annotations = new List<DiagramConnectorAnnotation>() { new DiagramConnectorAnnotation() { Content = "Yes", Offset = 0.4, Style = new DiagramTextStyle { Fill = "white" } } } });
            connectors.Add(new DiagramConnector() { Id = "initialteApprovalWithNextLevelManager-checkLevel2-ApprovalStatus", SourceID = "initialteApprovalWithNextLevelManager", TargetID = "checkLevel2-ApprovalStatus", });
            connectors.Add(new DiagramConnector() { Id = "checkLevel2-ApprovalStatus-setNextApprovalStatusAsRejected", SourceID = "checkLevel2-ApprovalStatus", TargetID = "setNextApprovalStatusAsRejected", Annotations = new List<DiagramConnectorAnnotation>() { new DiagramConnectorAnnotation() { Content = "Rejected", Offset = 0.4, Style = new DiagramTextStyle { Fill = "white" } } } });
            connectors.Add(new DiagramConnector() { Id = "checkLevel2-ApprovalStatus-setNextApprovalStatusAsAccepted", SourceID = "checkLevel2-ApprovalStatus", TargetID = "setNextApprovalStatusAsAccepted", Annotations = new List<DiagramConnectorAnnotation>() { new DiagramConnectorAnnotation() { Content = "Accepted", Offset = 0.4, Style = new DiagramTextStyle { Fill = "white" } } } });


            ViewBag.nodes = nodes;
            ViewBag.connectors = connectors;
            ViewBag.getNodeDefaults = "getNodeDefaults";
            ViewBag.getConnectorDefaults = "getConnectorDefaults";

            return View();
        }
    }

}
