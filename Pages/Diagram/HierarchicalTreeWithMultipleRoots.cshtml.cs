#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Diagram;

public class HierarchicalTreeWithMultipleRootsModel : PageModel
{
    public List<HierarchicalTreeWithMultipleRootDetails> Nodes { get; set; }
    public void OnGet()
    {
        Nodes = HierarchicalTreeWithMultipleRootDetails.GetAllRecords();
    }
}
public class HierarchicalTreeWithMultipleRootDetails
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public string ParentId { get; set; }

        public HierarchicalTreeWithMultipleRootDetails(string id, string content, string parentId)
        {
            this.Id = id;
            this.Content = content;
            this.ParentId = parentId;
        }

        public static List<HierarchicalTreeWithMultipleRootDetails> GetAllRecords()
        {
            List<HierarchicalTreeWithMultipleRootDetails> hierarchicaldetails = new List<HierarchicalTreeWithMultipleRootDetails>();

            hierarchicaldetails.Add(new HierarchicalTreeWithMultipleRootDetails("1", "Production Manager", ""));
            hierarchicaldetails.Add(new HierarchicalTreeWithMultipleRootDetails("2", "Control Room", "1"));
            hierarchicaldetails.Add(new HierarchicalTreeWithMultipleRootDetails("3", "Plant Operator", "1"));
            hierarchicaldetails.Add(new HierarchicalTreeWithMultipleRootDetails("4", "Foreman", "2"));
            hierarchicaldetails.Add(new HierarchicalTreeWithMultipleRootDetails("5", "Foreman", "3"));
            hierarchicaldetails.Add(new HierarchicalTreeWithMultipleRootDetails("6", "Craft Personnel", "4"));
            hierarchicaldetails.Add(new HierarchicalTreeWithMultipleRootDetails("7", "Craft Personnel", "4"));
            hierarchicaldetails.Add(new HierarchicalTreeWithMultipleRootDetails("8", "Craft Personnel", "5"));
            hierarchicaldetails.Add(new HierarchicalTreeWithMultipleRootDetails("9", "Craft Personnel", "5"));
            hierarchicaldetails.Add(new HierarchicalTreeWithMultipleRootDetails("10", "Administrative Officer",""));
            hierarchicaldetails.Add(new HierarchicalTreeWithMultipleRootDetails("11", "Security Supervisor", "10"));
            hierarchicaldetails.Add(new HierarchicalTreeWithMultipleRootDetails("12", "HR Supervisor", "10"));
            hierarchicaldetails.Add(new HierarchicalTreeWithMultipleRootDetails("13", "Reception Supervisor", "10"));
            hierarchicaldetails.Add(new HierarchicalTreeWithMultipleRootDetails("14", "Securities", "11"));
            hierarchicaldetails.Add(new HierarchicalTreeWithMultipleRootDetails("15", "HR Officer", "12"));
            hierarchicaldetails.Add(new HierarchicalTreeWithMultipleRootDetails("16", "Receptionist", "13"));
            hierarchicaldetails.Add(new HierarchicalTreeWithMultipleRootDetails("17", "Maintainence Manager", ""));
            hierarchicaldetails.Add(new HierarchicalTreeWithMultipleRootDetails("18", "Electrical Supervisor", "17"));
            hierarchicaldetails.Add(new HierarchicalTreeWithMultipleRootDetails("19", "Mechanical Supervisor", "17"));
            hierarchicaldetails.Add(new HierarchicalTreeWithMultipleRootDetails("20", "Craft Personnel", "18"));
            hierarchicaldetails.Add(new HierarchicalTreeWithMultipleRootDetails("21", "Craft Personnel", "19"));
            return hierarchicaldetails;
        }
    }