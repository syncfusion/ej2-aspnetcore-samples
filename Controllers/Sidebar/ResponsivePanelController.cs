using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Controllers.Sidebar
{
    public class Parentitem
    {
        public string nodeId;
        public string nodeText;
        public string icon;
        public bool expanded;
        public bool selected;
        public string iconCss;
        public List<childItems> child;

    }
    public class childItems
    {
        public string nodeId;
        public string nodeText;
        public string icon;
        public bool expanded;
        public bool selected;
        public string iconCss;
    }
    public partial class SidebarController : Controller
    {
        public IActionResult ResponsivePanel()
        {
            List<Parentitem> parentitem = new List<Parentitem>();
            List<childItems> childitem = new List<childItems>();

            parentitem.Add(new Parentitem
            {
                nodeId = "01",
                nodeText = "Installation",
                iconCss = "icon-microchip icon",


            });
            parentitem.Add(new Parentitem
            {
                nodeId = "02",
                nodeText = "Deployment",
                iconCss = "icon-thumbs-up-alt icon",

            });
            parentitem.Add(new Parentitem
            {
                nodeId = "03",
                nodeText = "Quick Start",
                iconCss = "icon-docs icon",

            });
            List<childItems> childitem4 = new List<childItems>();
            parentitem.Add(new Parentitem
            {
                nodeId = "04",
                nodeText = "Components",
                iconCss = "icon-th icon",
                child = childitem4,
            });
            childitem4.Add(new childItems { nodeId = "04-01", nodeText = "Calendar", iconCss = "icon-circle-thin icon" });
            childitem4.Add(new childItems { nodeId = "04-02", nodeText = "DatePicker", iconCss = "icon-circle-thin icon" });
            childitem4.Add(new childItems { nodeId = "04-03", nodeText = "DateTimePicker", iconCss = "icon-circle-thin icon" });
            childitem4.Add(new childItems { nodeId = "04-04", nodeText = "DateRangePicker", iconCss = "icon-circle-thin icon" });
            childitem4.Add(new childItems { nodeId = "04-05", nodeText = "TimePicker", iconCss = "icon-circle-thin icon" });
            childitem4.Add(new childItems { nodeId = "04-06", nodeText = "SideBar", iconCss = "icon-circle-thin icon" });
            List<childItems> childitem5 = new List<childItems>();
            parentitem.Add(new Parentitem
            {
                nodeId = "05",
                nodeText = "API Reference",
                iconCss = "icon-code icon",
                child = childitem4,
            });
            childitem5.Add(new childItems { nodeId = "05-01", nodeText = "Calendar", iconCss = "icon-circle-thin icon" });
            childitem5.Add(new childItems { nodeId = "05-02", nodeText = "DatePicker", iconCss = "icon-circle-thin icon" });
            childitem5.Add(new childItems { nodeId = "05-03", nodeText = "DateTimePicker", iconCss = "icon-circle-thin icon" });
            childitem5.Add(new childItems { nodeId = "05-04", nodeText = "DateRangePicker", iconCss = "icon-circle-thin icon" });
            childitem5.Add(new childItems { nodeId = "05-05", nodeText = "TimePicker", iconCss = "icon-circle-thin icon" });
            childitem5.Add(new childItems { nodeId = "05-06", nodeText = "SideBar", iconCss = "icon-circle-thin icon" });
            parentitem.Add(new Parentitem
            {
                nodeId = "06",
                nodeText = "Browser Compatibility",
                iconCss = "icon-chrome icon",

            });
            parentitem.Add(new Parentitem
            {
                nodeId = "07",
                nodeText = "Upgrade Packages",
                iconCss = "icon-up-hand icon",

            });
            parentitem.Add(new Parentitem
            {
                nodeId = "08",
                nodeText = "Release Notes",
                iconCss = "icon-bookmark-empty icon",

            });
            parentitem.Add(new Parentitem
            {
                nodeId = "09",
                nodeText = "FAQ",
                iconCss = "icon-help-circled icon",

            });
            parentitem.Add(new Parentitem
            {
                nodeId = "10",
                nodeText = "License",
                iconCss = "icon-doc-text icon",

            });
            ViewBag.dataSource = parentitem;
            return View();
        }
    }
}

