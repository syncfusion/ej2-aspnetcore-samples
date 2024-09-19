#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser_NET8.Pages.TreeView
{
    public class IconsandImagesModel : PageModel
    {
        public List<Parentitems> ParentItem = new List<Parentitems>();
        public void OnGet()
        {
            List<Childitems> childitem = new List<Childitems>();
            ParentItem.Add(new Parentitems
            {
                NodeId = "01",
                NodeText = "Music",
                Icon = "folder",
                Child = childitem,
            });
            childitem.Add(new Childitems { NodeId = "01-01", NodeText = "Gouttes.mp3", Icon = "audio" });

            List<Childitems> childitem2 = new List<Childitems>();
            ParentItem.Add(new Parentitems
            {
                NodeId = "02",
                NodeText = "Videos",
                Icon = "folder",
                Child = childitem2,
            });
            childitem2.Add(new Childitems { NodeId = "02-01", NodeText = "Naturals.mp4", Icon = "video" });
            childitem2.Add(new Childitems { NodeId = "02-02", NodeText = "Wild.mpeg", Icon = "video" });
            List<Childitems> childitem3 = new List<Childitems>();
            ParentItem.Add(new Parentitems
            {
                NodeId = "03",
                NodeText = "Documents",
                Icon = "folder",
                Child = childitem3,
            });
            childitem3.Add(new Childitems { NodeId = "03-01", NodeText = "Environment Pollution.docx", Icon = "docx" });
            childitem3.Add(new Childitems { NodeId = "03-02", NodeText = "Global Water, Sanitation, & Hygiene.docx", Icon = "docx" });
            childitem3.Add(new Childitems { NodeId = "03-03", NodeText = "Global Warming.ppt", Icon = "ppt" });
            childitem3.Add(new Childitems { NodeId = "03-04", NodeText = "Social Network.pdf", Icon = "pdf" });
            childitem3.Add(new Childitems { NodeId = "03-05", NodeText = "Youth Empowerment.pdf", Icon = "pdf" });

            childitem2.Add(new Childitems { NodeId = "02-01", NodeText = "Naturals.mp4", Icon = "video" });
            childitem2.Add(new Childitems { NodeId = "02-02", NodeText = "Wild.mpeg", Icon = "video" });
            List<Childitems> childitem4 = new List<Childitems>();
            ParentItem.Add(new Parentitems
            {
                NodeId = "04",
                NodeText = "Downloads",
                Icon = "folder",
                Child = childitem4,
            });
            childitem4.Add(new Childitems { NodeId = "04-01", NodeText = "UI-Guide.pdf", Icon = "pdf" });
            childitem4.Add(new Childitems { NodeId = "04-02", NodeText = "Tutorials.zip", Icon = "zip" });
            childitem4.Add(new Childitems { NodeId = "04-03", NodeText = "Game.exe", Icon = "exe" });
            childitem4.Add(new Childitems { NodeId = "04-04", NodeText = "TypeScript.7z", Icon = "zip" });
        }
    }
    public class Parentitems
    {
        public string NodeId;
        public string NodeText;
        public string Icon;
        public bool Expanded;
        public bool Selected;
        public List<Childitems> Child;

    }
    public class Childitems
    {
        public string NodeId;
        public string NodeText;
        public string Icon;
        public bool Expanded;
        public bool Selected;

    }
}
