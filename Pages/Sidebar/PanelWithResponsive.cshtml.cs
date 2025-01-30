#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Sidebar;

public class PanelWithResponsive : PageModel
{
    public Dictionary<string, object> HtmlAttribute = new Dictionary<string, object>()
        { { "class", "sidebar-treeview" } };

    public List<TreeDatas> treedata = new List<TreeDatas>();
    public void OnGet()
    {
        treedata.Add(new TreeDatas { nodeId = "01", nodeText = "Installation", iconCss = "icon-microchip icon" });
        treedata.Add(new TreeDatas { nodeId = "02", nodeText = "Deployment", iconCss = "icon-thumbs-up-alt icon" });
        treedata.Add(new TreeDatas { nodeId = "03", nodeText = "Quick Start", iconCss = "icon-docs icon" });
        treedata.Add(new TreeDatas { nodeId = "04", nodeText = "Components", iconCss = "icon-th icon", hasChild = true });
        treedata.Add(new TreeDatas { nodeId = "04-01", nodeText = "Calendar", iconCss = "icon-circle-thin icon", pid = "04" });
        treedata.Add(new TreeDatas { nodeId = "04-02", nodeText = "DatePicker", iconCss = "icon-circle-thin icon", pid = "04" });
        treedata.Add(new TreeDatas { nodeId = "04-03", nodeText = "DateTimePicker", iconCss = "icon-circle-thin icon", pid = "04" });
        treedata.Add(new TreeDatas { nodeId = "04-04", nodeText = "DateRangePicker", iconCss = "icon-circle-thin icon", pid = "04" });
        treedata.Add(new TreeDatas { nodeId = "04-05", nodeText = "TimePicker", iconCss = "icon-circle-thin icon", pid = "04" });
        treedata.Add(new TreeDatas { nodeId = "04-06", nodeText = "SideBar", iconCss = "icon-circle-thin icon", pid = "04" });
        treedata.Add(new TreeDatas { nodeId = "05", nodeText = "API Reference", iconCss = "icon-code icon", hasChild = true });
        treedata.Add(new TreeDatas { nodeId = "05-01", nodeText = "Calendar", iconCss = "icon-circle-thin icon", pid = "05" });
        treedata.Add(new TreeDatas { nodeId = "05-02", nodeText = "DatePicker", iconCss = "icon-circle-thin icon", pid = "05" });
        treedata.Add(new TreeDatas { nodeId = "05-03", nodeText = "DateTimePicker", iconCss = "icon-circle-thin icon", pid = "05" });
        treedata.Add(new TreeDatas { nodeId = "05-04", nodeText = "DateRangePicker", iconCss = "icon-circle-thin icon", pid = "05" });
        treedata.Add(new TreeDatas { nodeId = "05-05", nodeText = "TimePicker", iconCss = "icon-circle-thin icon", pid = "05" });
        treedata.Add(new TreeDatas { nodeId = "05-06", nodeText = "SideBar", iconCss = "icon-circle-thin icon", pid = "05" });
        treedata.Add(new TreeDatas { nodeId = "06", nodeText = "Browser Compatibility", iconCss = "icon-chrome icon" });
        treedata.Add(new TreeDatas { nodeId = "07", nodeText = "Upgrade Packages", iconCss = "icon-up-hand icon" });
        treedata.Add(new TreeDatas { nodeId = "08", nodeText = "Release Notes", iconCss = "icon-bookmark-empty icon" });
        treedata.Add(new TreeDatas { nodeId = "09", nodeText = "FAQ", iconCss = "icon-help-circled icon" });
        treedata.Add(new TreeDatas { nodeId = "10", nodeText = "License", iconCss = "icon-doc-text icon" });
    }
}
public class TreeDatas
{
    public string nodeId { get; set; }
    public string nodeText { get; set; }
    public string iconCss { get; set; }
    public bool hasChild { get; set; }
    public string pid { get; set; }
}