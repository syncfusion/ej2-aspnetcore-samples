#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Diagrams;
using System.ComponentModel;
using Newtonsoft.Json;

namespace EJ2CoreSampleBrowser.Controllers.Diagram
{
    public partial class DiagramController : Controller
    {
        public IActionResult UmlClassDiagram()
        {
            ViewBag.Nodes = GetClassNodeDiagram();
            ViewBag.Connectors = GetClassConnectorDiagram();
            ViewBag.getNodeDefaults = "getNodeDefaults";
            ViewBag.getConnectorDefaults = "getConnectorDefaults";
            ViewBag.setNodeTemplate = "setNodeTemplate";
            return View();
        }
        
        //create class Nodes
        public List<DiagramNode> GetClassNodeDiagram()
        {
            List<DiagramNode> nodes = new List<DiagramNode>();

            List<UMLProperty> patientProperty = new List<UMLProperty>();
            patientProperty.Add(CreateUMLProperty("accepted", "Date"));
            patientProperty.Add(CreateUMLProperty("sickness", "History"));
            patientProperty.Add(CreateUMLProperty("prescription", "String[*]"));
            patientProperty.Add(CreateUMLProperty("allergies", "String[*]"));

            List<UMLProperty> doctorProperty = new List<UMLProperty>();
            doctorProperty.Add(CreateUMLProperty("specialist", "String[*]"));
            doctorProperty.Add(CreateUMLProperty("locations", "String[*]"));

            List<UMLProperty> personProperty = new List<UMLProperty>();
            personProperty.Add(CreateUMLProperty("name", "Name"));
            personProperty.Add(CreateUMLProperty("title", "String[*]"));
            personProperty.Add(CreateUMLProperty("gender", "Gender"));

            List<UMLProperty> hospitalProperty = new List<UMLProperty>();
            hospitalProperty.Add(CreateUMLProperty("name", "Name"));
            hospitalProperty.Add(CreateUMLProperty("address", "Address"));
            hospitalProperty.Add(CreateUMLProperty("phone", "Phone"));

            List<UMLProperty> staffProperty = new List<UMLProperty>();
            staffProperty.Add(CreateUMLProperty("joined", "Date"));
            staffProperty.Add(CreateUMLProperty("education", "String[*]"));
            staffProperty.Add(CreateUMLProperty("certification", "String[*]"));
            staffProperty.Add(CreateUMLProperty("languages", "String[*]"));

            List<UMLMethods> patientMethods = new List<UMLMethods>();
            patientMethods.Add(CreateUMLMethod("getHistory", "History"));

            List<UMLMethods> hospitalMethods = new List<UMLMethods>();
            hospitalMethods.Add(CreateUMLMethod("getDepartment", "String"));

            List<UMLMethods> departmentMethods = new List<UMLMethods>();
            departmentMethods.Add(CreateUMLMethod("getStaffCount", "Int"));

            List<UMLMethods> staffMethods = new List<UMLMethods>();
            staffMethods.Add(CreateUMLMethod("isDoctor", "bool"));
            staffMethods.Add(CreateUMLMethod("getHistory", "bool"));

            nodes.Add(
                new DiagramNode()
                {
                    Id = "Patient",
                    OffsetX = 200,
                    OffsetY = 250,
                    Shape = new UmlClassifierShapeModel()
                    {
                        Type = "UmlClassifier",
                        ClassShapes = new ClassShapes()
                        {
                            Name = "Patient",
                            Attributes = patientProperty,
                            Methods = patientMethods
                        },
                    },
                }
            );
            nodes.Add(
                new DiagramNode()
                {
                    Id = "Doctor",
                    OffsetX = 240,
                    OffsetY = 545,
                    Shape = new UmlClassifierShapeModel()
                    {
                        Type = "UmlClassifier",
                        ClassShapes = new ClassShapes()
                        {
                            Name = "Doctor",
                            Attributes = doctorProperty
                        },
                    },
                }
            );
            nodes.Add(
               new DiagramNode()
               {
                   Id = "Person",
                   OffsetX = 405,
                   OffsetY = 105,
                   Shape = new UmlClassifierShapeModel()
                   {
                       Type = "UmlClassifier",
                       ClassShapes = new ClassShapes()
                       {
                           Name = "Person",
                           Attributes = personProperty
                       },
                   },
               }
           );
            nodes.Add(
              new DiagramNode()
              {
                  Id = "Hospital",
                  OffsetX = 638,
                  OffsetY = 100,
                  Shape = new UmlClassifierShapeModel()
                  {
                      Type = "UmlClassifier",
                      ClassShapes = new ClassShapes()
                      {
                          Name = "Hospital",
                          Attributes = hospitalProperty,
                          Methods = hospitalMethods
                      },
                  },
              }
          );
            nodes.Add(
             new DiagramNode()
             {
                 Id = "Department",
                 OffsetX = 638,
                 OffsetY = 280,
                 Shape = new UmlClassifierShapeModel()
                 {
                     Type = "UmlClassifier",
                     ClassShapes = new ClassShapes()
                     {
                         Name = "Department",
                         Methods = departmentMethods
                     },
                 },
             }
         );
          nodes.Add(
            new DiagramNode()
            {
                Id = "Staff",
                OffsetX = 635,
                OffsetY = 455,
                Shape = new UmlClassifierShapeModel()
                {
                    Type = "UmlClassifier",
                    ClassShapes = new ClassShapes()
                    {
                        Name = "Staff",
                        Attributes = staffProperty,
                        Methods = staffMethods
                    },
                },
            }
        );
            nodes.Add(CreateNode("OperationStaff", 410, 455, "OperationStaff"));
            nodes.Add(CreateNode("Nurse", 410, 545, "Nurse"));
            nodes.Add(CreateNode("Surgeon", 240, 665, "Surgeon"));
            nodes.Add(CreateNode("AdministrativeStaff", 632, 605, "AdministrativeStaff"));
            nodes.Add(CreateNode("FrontDeskStaff", 630, 695, "FrontDeskStaff"));
            nodes.Add(CreateNode("TechnicalStaff", 928, 445, "TechnicalStaff"));
            nodes.Add(CreateNode("Technician", 815, 535, "Technician"));
            nodes.Add(CreateNode("Technologist", 1015, 535, "Technologist"));
            nodes.Add(CreateNode("SurgicalTechnologist", 1015, 630, "SurgicalTechnologist"));
            return nodes;
        }

        //create Connectors
        public List<DiagramConnector> GetClassConnectorDiagram()
        {
            List<DiagramConnector> connectors = new List<DiagramConnector>();
            connectors.Add(CreateConnector("connect1", "Patient", "Person"));
            connectors.Add(CreateConnector("connect2", "Person", "Hospital"));
            connectors.Add(CreateConnector("connect3", "Department", "Hospital"));
            connectors.Add(CreateConnector("connect4", "OperationStaff", "Patient"));
            connectors.Add(CreateConnector("connect5", "Doctor", "OperationStaff"));
            connectors.Add(CreateConnector("connect6", "Nurse", "OperationStaff"));
            connectors.Add(CreateConnector("connect7", "Surgeon", "Doctor"));
            connectors.Add(CreateConnector("connect8", "FrontDeskStaff", "AdministrativeStaff"));
            connectors.Add(CreateConnector("connect9", "Technician", "TechnicalStaff"));
            connectors.Add(CreateConnector("connect10", "Technologist", "TechnicalStaff"));
            connectors.Add(CreateConnector("connect11", "SurgicalTechnologist", "Technologist"));
            connectors.Add(CreateConnector("connect12", "Staff", "Department"));
            connectors.Add(CreateConnector("connect13", "Staff", "Person"));
            connectors.Add(CreateConnector("connect14", "OperationStaff", "Staff"));
            connectors.Add(CreateConnector("connect15", "AdministrativeStaff", "Staff"));
            connectors.Add(CreateConnector("connect16", "TechnicalStaff", "Staff"));
            return connectors;
        }

        public DiagramNode CreateNode(string id, double offsetX, double offsetY, string className)
        {
            DiagramNode node = new DiagramNode();
            node.Id = id;
            node.OffsetX = offsetX;
            node.OffsetY = offsetY;
            node.Shape = new UmlClassifierShapeModel {
                Type = "UmlClassifier",
                ClassShapes = new ClassShapes()
                {
                    Name = className
                },
            };
            return node;
        }

        public DiagramConnector CreateConnector(string id, string sourceID, string targetID)
        {
            DiagramConnector connector = new DiagramConnector();
            connector.Id = id;
            connector.SourceID = sourceID;
            connector.TargetID = targetID;
            return connector;
        }

        public UMLProperty CreateUMLProperty(string name, string type)
        {
            UMLProperty property = new UMLProperty();
            property.Name = name;
            property.Type = type;
            return property;
        }
        public UMLMethods CreateUMLMethod(string name, string type)
        {
            UMLMethods method = new UMLMethods();
            method.Name = name;
            method.Type = type;
            return method;
        }
    }

    public class UmlClassifierShapeModel
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
        [Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeName("ClassShapes")]
        [JsonProperty("classShape")]
        public ClassShapes ClassShapes
        {
            get;
            set;
        }
    }

    public class ClassShapes
    {
        [DefaultValue(null)]
        [Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeName("name")]
        [JsonProperty("name")]
        public string Name
        {
            get;
            set;
        }

        [DefaultValue(null)]
        [Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeName("attributes")]
        [JsonProperty("attributes")]
        public List<UMLProperty> Attributes
        {
            get;
            set;
        }

        [DefaultValue(null)]
        [Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeName("methods")]
        [JsonProperty("methods")]
        public List<UMLMethods> Methods
        {
            get;
            set;
        }
    }

    public class UMLProperty
    {
        [DefaultValue(null)]
        [Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeName("name")]
        [JsonProperty("name")]
        public string Name
        {
            get;
            set;
        }
        [DefaultValue(null)]
        [Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeName("type")]
        [JsonProperty("type")]
        public string Type
        {
            get;
            set;
        }
    }
    public class UMLMethods
    {
        [DefaultValue(null)]
        [Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeName("name")]
        [JsonProperty("name")]
        public string Name
        {
            get;
            set;
        }
        [DefaultValue(null)]
        [Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeName("type")]
        [JsonProperty("type")]
        public string Type
        {
            get;
            set;
        }
    }
}