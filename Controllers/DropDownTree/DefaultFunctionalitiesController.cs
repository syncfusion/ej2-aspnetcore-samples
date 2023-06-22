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

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EJ2CoreSampleBrowser.Controllers.DropDownTree
{
    public partial class DropDownTreeController : Controller
    {
        public IActionResult DefaultFunctionalities()
        {
            return View();
        }
    }
}

public class Parent
{
    public string nodeId;
    public string nodeText;
    public string icon;
    public bool expanded;
    public bool selected;
    public List<Child> child;

}
public class Child
{
    public string nodeId;
    public string nodeText;
    public string icon;
    public bool expanded;
    public bool selected;
    public List<SubChildren> child;

}
public class SubChildren
{
    public string nodeId;
    public string nodeText;
    public string icon;
    public bool expanded;
    public bool selected;

}