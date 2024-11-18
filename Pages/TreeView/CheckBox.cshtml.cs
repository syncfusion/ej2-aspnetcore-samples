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
    public class CheckBoxModel : PageModel
    {
        public List<object> TreeData = new List<object>();
        public void OnGet()
        {
            TreeData.Add(new { id = 1, name = "Australia", hasChild = true, expanded = true });
            TreeData.Add(new
            {
                id = 2,
                pid = 1,
                name = "New South Wales",

            });
            TreeData.Add(new
            {
                id = 3,
                pid = 1,
                name = "Victoria"
            });

            TreeData.Add(new
            {
                id = 4,
                pid = 1,
                name = "South Australia"
            });
            TreeData.Add(new
            {
                id = 6,
                pid = 1,
                name = "Western Australia",

            });
            TreeData.Add(new
            {
                id = 7,
                name = "Brazil",
                hasChild = true
            });
            TreeData.Add(new
            {
                id = 8,
                pid = 7,
                name = "Paran�"
            });
            TreeData.Add(new
            {
                id = 9,
                pid = 7,
                name = "Cear�"
            });
            TreeData.Add(new
            {
                id = 10,
                pid = 7,
                name = "Acre"
            });
            TreeData.Add(new
            {
                id = 11,
                name = "China",
                hasChild = true
            });
            TreeData.Add(new
            {
                id = 12,
                pid = 11,
                name = "Guangzhou"
            });
            TreeData.Add(new
            {
                id = 13,
                pid = 11,
                name = "Shanghai"
            });
            TreeData.Add(new
            {
                id = 14,
                pid = 11,
                name = "Beijing"
            });
            TreeData.Add(new
            {
                id = 15,
                pid = 11,
                name = "Shantou"

            });
            TreeData.Add(new
            {
                id = 16,
                name = "France",
                hasChild = true

            });
            TreeData.Add(new
            {
                id = 17,
                pid = 16,
                name = "Pays de la Loire"

            });
            TreeData.Add(new
            {
                id = 18,
                pid = 16,
                name = "Aquitaine"

            });
            TreeData.Add(new
            {
                id = 19,
                pid = 16,
                name = "Brittany"

            });
            TreeData.Add(new
            {
                id = 20,
                pid = 16,
                name = "Lorraine"
            });
            TreeData.Add(new
            {
                id = 21,
                name = "India",
                hasChild = true

            });
            TreeData.Add(new
            {
                id = 22,
                pid = 21,
                name = "Assam"

            });
            TreeData.Add(new
            {
                id = 23,
                pid = 21,
                name = "Bihar"
            });
            TreeData.Add(new
            {
                id = 24,
                pid = 21,
                name = "Tamil Nadu"

            });
        }
    }
}
