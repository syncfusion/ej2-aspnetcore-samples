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
        public IActionResult DataBindingWithTreeView()
        {
            ViewBag.Nodes = DataBindingDetails.GetAllRecords();
            ViewBag.getConnectorDefaults = "ConnectorDefaults";
            ViewBag.getNodeDefaults = "nodeDefaults";
            return View();
        }
    }
    public class DataBindingDetails
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string ParentId { get; set; }
        public bool hasChild {get; set;}
        public bool expanded {get; set;}
        public DataBindingDetails(string name, string id,  string parentId, bool haschild, bool expand)
        {
            this.Name = name;
            this.Id = id;
            this.ParentId = parentId;
            this.hasChild = haschild;
            this.expanded = expand;
        }

        public static List<DataBindingDetails> GetAllRecords()
        {
            List<DataBindingDetails> hierarchicaldetails = new List<DataBindingDetails>();
            hierarchicaldetails.Add(new DataBindingDetails( "Plant Manager", "1", "", true, true));
            hierarchicaldetails.Add(new DataBindingDetails("Production Manager", "2", "1", true, true));
            hierarchicaldetails.Add(new DataBindingDetails( "Control Room", "3", "2", true, true));
            hierarchicaldetails.Add(new DataBindingDetails("Foreman1", "4", "3", true, true ));
            hierarchicaldetails.Add(new DataBindingDetails("Craft Personnel5", "5", "4", false, false));
            hierarchicaldetails.Add(new DataBindingDetails("Craft Personnel6", "6", "4", false, false));
            hierarchicaldetails.Add(new DataBindingDetails("Plant Operator", "7", "2", true, true));
            hierarchicaldetails.Add(new DataBindingDetails("Foreman2", "8", "7", true, true));
            hierarchicaldetails.Add(new DataBindingDetails("Craft Personnel7", "9", "8", false, false));
            hierarchicaldetails.Add(new DataBindingDetails("Administrative Officer", "10", "1", false, false));
            hierarchicaldetails.Add(new DataBindingDetails("Maintenance Manager", "11", "1", true, true));
            hierarchicaldetails.Add(new DataBindingDetails( "Electrical Supervisor", "12", "11", true, true));
            hierarchicaldetails.Add(new DataBindingDetails( "Craft Personnel1", "13", "12", false, false));
            hierarchicaldetails.Add(new DataBindingDetails( "Craft Personnel2", "14", "12", false, false));
            hierarchicaldetails.Add(new DataBindingDetails("Mechanical Supervisor", "15", "11", true, true));
            hierarchicaldetails.Add(new DataBindingDetails("Craft Personnel3", "16", "15", false, false));
            hierarchicaldetails.Add(new DataBindingDetails("Craft Personnel4", "17", "15", false, false));
            return hierarchicaldetails;
        }
    }
    public class Parentitem
{
    public string nodeId;
    public string nodeText;
    public string icon;
    public bool expanded;
    public bool selected;
    public List<Childitem> child;

}
public class Childitem
{
    public string nodeId;
    public string nodeText;
    public string icon;
    public bool expanded;
    public bool selected;
    public List<SubChilditem> child;

}
public class SubChilditem
{
    public string nodeId;
    public string nodeText;
    public string icon;
    public bool expanded;
    public bool selected;

}
}
