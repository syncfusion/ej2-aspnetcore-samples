using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Controllers.DropDownTree
{
    public partial class DropDownTreeController : Controller
    {
        public IActionResult IconsAndImages()
        {
            List<ParentItem> Parent = new List<ParentItem>();
            List<ChildItem> Child1 = new List<ChildItem>();
            List<ChildItem> Child2 = new List<ChildItem>();
            List<ChildItem> Child3 = new List<ChildItem>();
            List<ChildItem> Child4 = new List<ChildItem>();
            List<ChildItem> Child5 = new List<ChildItem>();
            List<SubChild> SubChild = new List<SubChild>();

            Parent.Add(new ParentItem { nodeId = "01", nodeText = "Music", icon = "folder", child = Child1, });
            Child1.Add(new ChildItem { nodeId = "01-01", nodeText = "Gouttes.mp3", icon = "audio" });

            Parent.Add(new ParentItem { nodeId = "02", nodeText = "Videos", icon = "folder", child = Child2, });
            Child2.Add(new ChildItem { nodeId = "02-01", nodeText = "Naturals.mp4", icon = "video" });
            Child2.Add(new ChildItem { nodeId = "02-02", nodeText = "Wild.mpeg", icon = "video" });

            Parent.Add(new ParentItem { nodeId = "03", nodeText = "Documents", icon = "folder", child = Child3, });
            Child3.Add(new ChildItem { nodeId = "03-01", nodeText = "Environment Pollution.docx", icon = "docx" });
            Child3.Add(new ChildItem { nodeId = "03-02", nodeText = "Global Water, Sanitation, & Hygiene.docx", icon = "docx" });
            Child3.Add(new ChildItem { nodeId = "03-03", nodeText = "Global Warming.ppt", icon = "ppt" });
            Child3.Add(new ChildItem { nodeId = "03-04", nodeText = "Social Network.pdf", icon = "pdf" });
            Child3.Add(new ChildItem { nodeId = "03-05", nodeText = "Youth Empowerment.pdf", icon = "pdf" });

            Parent.Add(new ParentItem { nodeId = "04", nodeText = "Pictures", icon = "folder", child = Child4, expanded = true, });
            Child4.Add(new ChildItem { nodeId = "04-01", nodeText = "Camera Roll", icon = "folder", child = SubChild, expanded = true });
            SubChild.Add(new SubChild { nodeId = "04-01-01", nodeText = "WIN_20160726_094117.JPG", image = "../images/dropdown-tree/2.png" });
            SubChild.Add(new SubChild { nodeId = "04-01-02", nodeText = "WIN_20160726_094118.JPG", image = "../images/dropdown-tree/9.png" });
            Child4.Add(new ChildItem { nodeId = "04-02", nodeText = "Wind.jpg", icon = "images" });
            Child4.Add(new ChildItem { nodeId = "04-03", nodeText = "Stone.jpg", icon = "images" });

            Parent.Add(new ParentItem { nodeId = "05", nodeText = "Downloads", icon = "folder", child = Child5, });
            Child5.Add(new ChildItem { nodeId = "05-01", nodeText = "UI-Guide.pdf", icon = "pdf" });
            Child5.Add(new ChildItem { nodeId = "05-02", nodeText = "Tutorials.zip", icon = "zip" });
            Child5.Add(new ChildItem { nodeId = "05-03", nodeText = "Game.exe", icon = "exe" });
            Child5.Add(new ChildItem { nodeId = "05-04", nodeText = "TypeScript.7z", icon = "zip" });
            ViewBag.dataSource = Parent;
            string Child = "child";
            ViewBag.child = Child;
            return View();
        }
    }
}

public class ParentItem
{
    public string nodeId;
    public string nodeText;
    public string icon;
    public string image;
    public bool expanded;
    public List<ChildItem> child;
}
public class ChildItem
{
    public string nodeId;
    public string nodeText;
    public string icon;
    public string image;
    public bool expanded;
    public List<SubChild> child;
}
public class SubChild
{
    public string nodeId;
    public string nodeText;
    public string icon;
    public string image;
    public bool expanded;
}
