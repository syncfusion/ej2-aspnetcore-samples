#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
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
        public IActionResult HierarchicalTree()
        {
            ViewBag.Nodes = HierarchicalDetails.GetAllRecords();
            ViewBag.getConnectorDefaults = "ConnectorDefaults";
            ViewBag.getNodeDefaults = "nodeDefaults";
            return View();
        }
    }
    public class HierarchicalDetails
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string FillColor { get; set; }

        public HierarchicalDetails(string name, string category, string fillcolor)
        {
            this.Name = name;
            this.Category = category;
            this.FillColor = fillcolor;
        }

        public static List<HierarchicalDetails> GetAllRecords()
        {
            List<HierarchicalDetails> hierarchicaldetails = new List<HierarchicalDetails>();

            hierarchicaldetails.Add(new HierarchicalDetails("Diagram", "", "#916DAF"));
            hierarchicaldetails.Add(new HierarchicalDetails("Layout", "Diagram", "#916DAF"));
            hierarchicaldetails.Add(new HierarchicalDetails("Tree Layout", "Layout", "#916DAF"));
            hierarchicaldetails.Add(new HierarchicalDetails("Organizational Chart", "Layout", "#916DAF"));
            hierarchicaldetails.Add(new HierarchicalDetails("Hierarchical Tree", "Tree Layout", "#916DAF"));
            hierarchicaldetails.Add(new HierarchicalDetails("Radial Tree", "Tree Layout", "#916DAF"));
            hierarchicaldetails.Add(new HierarchicalDetails("Mind Map", "Hierarchical Tree", "#916DAF"));
            hierarchicaldetails.Add(new HierarchicalDetails("Family Tree", "Hierarchical Tree", "#916DAF"));
            hierarchicaldetails.Add(new HierarchicalDetails("Management", "Organizational Chart", "#916DAF"));
            hierarchicaldetails.Add(new HierarchicalDetails("Human Resource", "Management", "#916DAF"));
            hierarchicaldetails.Add(new HierarchicalDetails("University", "Management", "#916DAF"));
            hierarchicaldetails.Add(new HierarchicalDetails("Business", "Management", "#916DAF"));

            return hierarchicaldetails;
        }
    }
}