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
            List<Parent> Parent = new List<Parent>();
            List<Child> Child1 = new List<Child>();
            List<SubChildren> SubChildren1 = new List<SubChildren>();
            Parent.Add(new Parent
            {
                nodeId = "01",
                nodeText = "Local Disk (C:)",
                expanded = true,
                child = Child1,
            });
            Child1.Add(new Child { nodeId = "01-01", nodeText = "Program Files", child = SubChildren1 });
            SubChildren1.Add(new SubChildren { nodeId = "01-01-01", nodeText = "Windows NT" });
            SubChildren1.Add(new SubChildren { nodeId = "01-01-02", nodeText = "Windows Mail" });
            SubChildren1.Add(new SubChildren { nodeId = "01-01-03", nodeText = "Windows Photo Viewer" });
            List<SubChildren> SubChildren2 = new List<SubChildren>();
            Child1.Add(new Child { nodeId = "01-02", nodeText = "Users", expanded = true, child = SubChildren2 });
            SubChildren2.Add(new SubChildren { nodeId = "01-02-01", nodeText = "Smith" });
            SubChildren2.Add(new SubChildren { nodeId = "01-02-02", nodeText = "Public" });
            SubChildren2.Add(new SubChildren { nodeId = "01-02-03", nodeText = "Admin" });
            List<SubChildren> SubChildren3 = new List<SubChildren>();
            Child1.Add(new Child { nodeId = "01-03", nodeText = "Windows", child = SubChildren3 });
            SubChildren3.Add(new SubChildren { nodeId = "01-03-01", nodeText = "Boot" });
            SubChildren3.Add(new SubChildren { nodeId = "01-03-02", nodeText = "FileManager" });
            SubChildren3.Add(new SubChildren { nodeId = "01-03-03", nodeText = "System32" });
            List<Child> Child2 = new List<Child>();
            Parent.Add(new Parent
            {
                nodeId = "02",
                nodeText = "Local Disk (D:)",
                child = Child2,
            });
            List<SubChildren> SubChildren4 = new List<SubChildren>();
            Child2.Add(new Child { nodeId = "02-01", nodeText = "Personals", child = SubChildren4 });
            SubChildren4.Add(new SubChildren { nodeId = "02-01-01", nodeText = "My photo.png" });
            SubChildren4.Add(new SubChildren { nodeId = "02-01-02", nodeText = "Rental document.docx" });
            SubChildren4.Add(new SubChildren { nodeId = "02-01-03", nodeText = "Pay slip.pdf" });
            List<SubChildren> SubChildren5 = new List<SubChildren>();
            Child2.Add(new Child { nodeId = "02-02", nodeText = "Projects", child = SubChildren5 });
            SubChildren5.Add(new SubChildren { nodeId = "02-02-01", nodeText = "ASP Application " });
            SubChildren5.Add(new SubChildren { nodeId = "02-02-02", nodeText = "TypeScript Application" });
            SubChildren5.Add(new SubChildren { nodeId = "02-02-03", nodeText = "React Application" });

            List<SubChildren> SubChildren6 = new List<SubChildren>();
            Child2.Add(new Child { nodeId = "02-02", nodeText = "Office", child = SubChildren6 });
            SubChildren6.Add(new SubChildren { nodeId = "02-03-01", nodeText = "Work details.docx " });
            SubChildren6.Add(new SubChildren { nodeId = "02-03-02", nodeText = "Weekly report.docx" });
            SubChildren6.Add(new SubChildren { nodeId = "02-03-03", nodeText = "Wish list.csv" });
            List<Child> Child3 = new List<Child>();
            Parent.Add(new Parent
            {
                nodeId = "03",
                nodeText = "Local Disk (E:)",
                child = Child3,
            });

            List<SubChildren> SubChildren7 = new List<SubChildren>();
            Child3.Add(new Child { nodeId = "03-01", nodeText = "Pictures", child = SubChildren7 });
            SubChildren7.Add(new SubChildren { nodeId = "03-01-01", nodeText = "Wind.jpg " });
            SubChildren7.Add(new SubChildren { nodeId = "03-01-02", nodeText = "Stone.jpg" });
            SubChildren7.Add(new SubChildren { nodeId = "03-01-03", nodeText = "Home.jpg" });

            List<SubChildren> SubChildren8 = new List<SubChildren>();
            Child3.Add(new Child { nodeId = "03-02", nodeText = "Documents", icon = "docx", child = SubChildren8 });
            SubChildren8.Add(new SubChildren { nodeId = "03-02-01", nodeText = "Environment Pollution.docx " });
            SubChildren8.Add(new SubChildren { nodeId = "03-02-02", nodeText = "Global Warming.ppt" });
            SubChildren8.Add(new SubChildren { nodeId = "03-02-03", nodeText = "Social Network.pdf" });

            List<SubChildren> SubChildren9 = new List<SubChildren>();
            Child3.Add(new Child { nodeId = "03-03", nodeText = "Study Materials", child = SubChildren9 });
            SubChildren9.Add(new SubChildren { nodeId = "03-03-01", nodeText = "UI-Guide.pdf" });
            SubChildren9.Add(new SubChildren { nodeId = "03-03-02", nodeText = "Tutorials.zip" });
            SubChildren9.Add(new SubChildren { nodeId = "03-03-03", nodeText = "TypeScript.7z" });

            ViewBag.dataSource = Parent;
            char[] value = { 'c', 'h', 'i', 'l', 'd' };
            string Child = new string(value);
            ViewBag.child = Child;
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