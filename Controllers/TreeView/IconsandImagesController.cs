#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
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

namespace EJ2CoreSampleBrowser.Controllers.TreeView
{
    public partial class TreeViewController : Controller
    {
        public IActionResult IconsandImages()
        {
           
            List<Parentitems> parentitem = new List<Parentitems>();
            List<Childitems> childitem = new List<Childitems>();
            parentitem.Add(new Parentitems
            {
                nodeId = "01",
                nodeText = "Music",
                icon="folder",
                child = childitem,
            });
            childitem.Add(new Childitems { nodeId = "01-01", nodeText = "Gouttes.mp3", icon= "audio" });
            
            List<Childitems> childitem2 = new List<Childitems>();
        parentitem.Add(new Parentitems
        {
            nodeId = "02",
            nodeText = "Videos",
            icon = "folder",
            child = childitem2,
        });
        childitem2.Add(new Childitems { nodeId = "02-01", nodeText = "Naturals.mp4", icon = "video" });
        childitem2.Add(new Childitems { nodeId = "02-02", nodeText = "Wild.mpeg", icon = "video" });
        List<Childitems> childitem3 = new List<Childitems>();
        parentitem.Add(new Parentitems
        {
            nodeId = "03",
            nodeText = "Documents",
            icon = "folder",
            child = childitem3,
        });
        childitem3.Add(new Childitems { nodeId = "03-01", nodeText = "Environment Pollution.docx", icon = "docx" });
        childitem3.Add(new Childitems { nodeId = "03-02", nodeText = "Global Water, Sanitation, & Hygiene.docx", icon = "docx" });
        childitem3.Add(new Childitems { nodeId = "03-03", nodeText = "Global Warming.ppt", icon = "ppt" });
        childitem3.Add(new Childitems { nodeId = "03-04", nodeText = "Social Network.pdf", icon = "pdf" });
        childitem3.Add(new Childitems { nodeId = "03-05", nodeText = "Youth Empowerment.pdf", icon = "pdf" });

        childitem2.Add(new Childitems { nodeId = "02-01", nodeText = "Naturals.mp4", icon = "video" });
        childitem2.Add(new Childitems { nodeId = "02-02", nodeText = "Wild.mpeg", icon = "video" });
        List<Childitems> childitem4 = new List<Childitems>();
        parentitem.Add(new Parentitems
        {
            nodeId = "04",
            nodeText = "Downloads",
            icon = "folder",
            child = childitem4,
        });
        childitem4.Add(new Childitems { nodeId = "04-01", nodeText = "UI-Guide.pdf", icon = "pdf" });
        childitem4.Add(new Childitems { nodeId = "04-02", nodeText = "Tutorials.zip", icon = "zip" });
        childitem4.Add(new Childitems { nodeId = "04-03", nodeText = "Game.exe", icon = "exe" });
        childitem4.Add(new Childitems { nodeId = "04-04", nodeText = "TypeScript.7z", icon = "zip" });
       ViewBag.dataSource = parentitem;
            char[] value = { 'c', 'h', 'i', 'l', 'd' };
            string Child = new string(value);
            ViewBag.child = Child;
            return View();
    }
}
}

  public class Parentitems
{
    public string nodeId;
    public string nodeText;
    public string icon;
    public bool expanded;
    public bool selected;
    public List<Childitems> child;

}
public class Childitems
{
    public string nodeId;
    public string nodeText;
    public string icon;
    public bool expanded;
    public bool selected;

}