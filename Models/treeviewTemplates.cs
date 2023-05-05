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

namespace EJ2CoreSampleBrowser.Models
{
    public class treeviewTemplates
    {
        public string name { get; set; }
        public string count { get; set; }
        public int id { get; set; }
        public int pid { get; set; }
        public bool hasChild { get; set; }
        public bool expanded { get; set; }
        public bool selected { get; set; }
        public List<treeviewTemplates> employeesData()
        {
            List<treeviewTemplates> emp = new List<treeviewTemplates>();
            emp.Add(new treeviewTemplates { id= 1, name= "Favorites", hasChild= true});
            emp.Add(new treeviewTemplates { id= 2, pid= 1, name= "Sales Reports", count="4" });
            emp.Add(new treeviewTemplates { id= 3, pid= 1, name= "Sent Items" });
            emp.Add(new treeviewTemplates { id= 4, pid= 1, name= "Marketing Reports ", count= "6" });
            emp.Add(new treeviewTemplates { id= 5, name= "My Folder", hasChild= true, expanded = true });
            emp.Add(new treeviewTemplates { id= 6, pid= 5, name= "Inbox", selected= true, count= "20" });
            emp.Add(new treeviewTemplates { id= 7, pid= 5, name= "Drafts", count= "5" });
            emp.Add(new treeviewTemplates { id= 8, pid= 5, name= "Deleted Items"});
            emp.Add(new treeviewTemplates { id = 9, pid = 5, name = "Sent Items" });
            emp.Add(new treeviewTemplates { id= 11, pid= 5, name= "Sales Reports", count= "4" });
            emp.Add(new treeviewTemplates { id= 12, pid= 5, name= "Marketing Reports", count= "6" });
            emp.Add(new treeviewTemplates { id= 13, pid= 5, name= "Outbox" });
           
            return emp;
        }
    }
}



