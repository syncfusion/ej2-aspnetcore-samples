#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Diagram;

public class DataBindingWithTreeViewModel : PageModel
{
    public List<object> treedata { get; set; }
    public List<DataBindingDetails> Nodes { get; set; }
    
    public void OnGet()
    {
        treedata = new List<object>();
            treedata.Add(new
            {
                id = 1,
                name = "Plant Manager",
                hasChild = true,
                expanded = true
            });
            treedata.Add(new
            {
                id = 2,
                pid = 1,
                name = "Production Manager",
                hasChild = true,
                expanded = true
            });
            treedata.Add(new
            {
                id = 3,
                pid = 2,
                name = "Control Room",
                hasChild = true,
                expanded = true
            });

            treedata.Add(new
            {
                id = 4,
                pid = 3,
                name = "Foreman1",
                hasChild = true,
                expanded = true
            });
            treedata.Add(new
            {
                id = 5,
                pid = 4,
                name = "Craft Personnel5",

            });
            treedata.Add(new
            {
                id = 6,
                pid = 4,
                name = "Craft Personnel6",
            });
            treedata.Add(new
            {
                id = 7,
                pid = 2,
                name = "Plant Operator",
                hasChild = true,
                expanded = true
            });
            treedata.Add(new
            {
                id = 8,
                pid = 7,
                name = "Foreman2",
                hasChild = true,
                expanded = true
            });
            treedata.Add(new
            {
                id = 9,
                pid = 8,
                name = "Craft Personnel7"
            });
            treedata.Add(new
            {
                id = 10,
                pid = 1,
                name = "Administrative Officer",


            });
            treedata.Add(new
            {
                id = 11,
                pid = 1,
                name = "Maintenance Manager",
                hasChild = true,
                expanded = true
            });
            treedata.Add(new
            {
                id = 12,
                pid = 11,
                name = "Electrical Supervisor",
                hasChild = true,
                expanded = true

            });
            treedata.Add(new
            {
                id = 13,
                pid = 12,
                hasChild = true,
                name = "Craft Personnel1"
            });
            treedata.Add(new
            {
                id = 14,
                pid = 12,

                name = "Craft Personnel2"

            });
            treedata.Add(new
            {
                id = 15,
                name = "Mechanical Supervisor",
                pid = 11,
                hasChild = true,
                expanded = true

            });
            treedata.Add(new
            {
                id = 16,
                pid = 15,
                name = "Craft Personnel3"

            });
            treedata.Add(new
            {
                id = 17,
                pid = 15,
                name = "Craft Personnel4"

            });
            Nodes= DataBindingDetails.GetAllRecords();
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