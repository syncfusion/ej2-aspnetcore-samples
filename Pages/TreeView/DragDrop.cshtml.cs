#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.TreeView
{
    public class DragDropModel : PageModel
    {
        public List<object> ProductTeam1 = new List<object>();
        public List<object> ProductTeam2 = new List<object>();
        public void OnGet()
        {
            
            ProductTeam1.Add(new
            {
                id = "t1",
                name = "ASP.NET MVC Team",
                hasChild = true,
                expanded = true
            });
            ProductTeam1.Add(new
            {
                id = "t2",
                pid = "t1",
                name = "Smith",
            });
            ProductTeam1.Add(new
            {
                id = "t3",
                pid = "t1",
                name = "Johnson"
            });

            ProductTeam1.Add(new
            {
                id = "t4",
                pid = "t1",
                name = "Anderson",
            });
            ProductTeam1.Add(new
            {
                id = "t6",
                hasChild = true,
                name = "Windows Team",
                expanded = true

            });
            ProductTeam1.Add(new
            {
                id = "t7",
                pid = "t6",
                name = "Clark"

            });
            ProductTeam1.Add(new
            {
                id = "t8",
                pid = "t6",
                name = "Wright"
            });
            ProductTeam1.Add(new
            {
                id = "t9",
                pid = "t6",
                name = "Lopez",
            });

            
            ProductTeam2.Add(new
            {
                id = "t10",
                hasChild = true,
                name = "Web Team",
                expanded = true

            });
            ProductTeam2.Add(new
            {
                id = "t11",
                pid = "t10",
                name = "Joshua",

            });
            ProductTeam2.Add(new
            {
                id = "t12",
                pid = "t10",
                name = "Matthew"
            });
            ProductTeam2.Add(new
            {
                id = "t13",
                pid = "t10",
                name = "David"
            });
            ProductTeam2.Add(new
            {
                id = "t14",
                hasChild = true,
                name = "Build Team",
                expanded = true
            });
            ProductTeam2.Add(new
            {
                id = "t15",
                pid = "t14",
                name = "Ryan"
            });
            ProductTeam2.Add(new
            {
                id = "t16",
                pid = "t14",
                name = "Justin",
            });
            ProductTeam2.Add(new
            {
                id = "t17",
                pid = "t14",
                name = "Robert"
            });
        }
    }
}
