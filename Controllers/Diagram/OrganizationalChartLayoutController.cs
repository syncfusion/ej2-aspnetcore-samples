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

namespace EJ2CoreSampleBrowser.Controllers.Diagram
{
    public partial class DiagramController : Controller
    {
        public IActionResult OrganizationalChartLayout()
        {
            ViewBag.Nodes = OrganizationalDetails.GetAllRecords();
            ViewBag.nodeDefaults = "nodeDefaults";
            ViewBag.ConnectorDefaults = "connectorDefaults";
            ViewBag.GetLayoutInfo = "getLayoutInfo";
            return View();
        }
    }
    public class OrganizationalDetails
    {
        public string Id { get; set; }
        public string Role { get; set; }
        public string Color { get; set; }
        public string Manager { get; set; }
        public string ChartType { get; set; }

        public OrganizationalDetails(string id, string role, string color, string manager, string chartType)
        {
            this.Id = id;
            this.Role = role;
            this.Color = color;
            this.Manager = manager;
            this.ChartType = chartType;
        }

        public static List<OrganizationalDetails> GetAllRecords()
        {
            List<OrganizationalDetails> organizationaldetails = new List<OrganizationalDetails>();
            organizationaldetails.Add(new OrganizationalDetails("parent", "Board", "#71AF17", "", ""));
            organizationaldetails.Add(new OrganizationalDetails("1", "General Manager", "#71AF17", "parent", "right"));
            organizationaldetails.Add(new OrganizationalDetails("11", "Assistant General Manager", "#71AF17", "1", ""));
            organizationaldetails.Add(new OrganizationalDetails("2", "Human Resource Manager", "#1859B7", "1", "right"));
            organizationaldetails.Add(new OrganizationalDetails("3", "Trainers", "#2E95D8", "2", ""));
            organizationaldetails.Add(new OrganizationalDetails("4", "Recruiting Team", "#2E95D8", "2", ""));
            organizationaldetails.Add(new OrganizationalDetails("5", "Finance Asst. Manager", "#2E95D8", "2", ""));
            organizationaldetails.Add(new OrganizationalDetails("6", "Design Manager", "#1859B7", "1", "right"));
            organizationaldetails.Add(new OrganizationalDetails("7", "Design Supervisor", "#2E95D8", "6", ""));
            organizationaldetails.Add(new OrganizationalDetails("8", "Development Supervisor", "#2E95D8", "6", ""));
            organizationaldetails.Add(new OrganizationalDetails("9", "Drafting Supervisor", "#2E95D8", "6", ""));
            organizationaldetails.Add(new OrganizationalDetails("10", "Operations Manager", "#1859B7", "1", "right"));
            organizationaldetails.Add(new OrganizationalDetails("11", "Statistics Department", "#2E95D8", "10", ""));
            organizationaldetails.Add(new OrganizationalDetails("12", "Logistics Department", "#2E95D8", "10", ""));
            organizationaldetails.Add(new OrganizationalDetails("16", "Marketing Manager", "#1859B7", "1", "right"));
            organizationaldetails.Add(new OrganizationalDetails("17", "Overseas sales Manager", "#2E95D8", "16", ""));
            organizationaldetails.Add(new OrganizationalDetails("18", "Petroleum Manager", "#2E95D8", "16", ""));
            organizationaldetails.Add(new OrganizationalDetails("20", "Service Department Manager", "#2E95D8", "16", ""));
            organizationaldetails.Add(new OrganizationalDetails("21", "Quality control Department", "#2E95D8", "16", ""));

            return organizationaldetails;
        }
    }
}