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
        public IActionResult DefaultFunctionalities()
        {

            List<Parentitem> parentitem = new List<Parentitem>();
            List<Childitem> childitem1 = new List<Childitem>();
            List<SubChilditem> subchilditem1 = new List<SubChilditem>();
            parentitem.Add(new Parentitem
            {
                nodeId = "01",
                nodeText = "Local Disk (C:)",
                expanded=true,
                child = childitem1,
            });
            childitem1.Add(new Childitem { nodeId = "01-01", nodeText = "Program Files", child=subchilditem1 });
            subchilditem1.Add(new SubChilditem { nodeId = "01-01-01", nodeText = "Windows NT" });
            subchilditem1.Add(new SubChilditem { nodeId = "01-01-02", nodeText = "Windows Mail" });
            subchilditem1.Add(new SubChilditem { nodeId = "01-01-03", nodeText = "Windows Photo Viewer" });
            List<SubChilditem> subchilditem2 = new List<SubChilditem>();
            childitem1.Add(new Childitem { nodeId = "01-02", nodeText = "Users", expanded=true, child = subchilditem2 });
            subchilditem2.Add(new SubChilditem { nodeId = "01-02-01", nodeText = "Smith" });
            subchilditem2.Add(new SubChilditem { nodeId = "01-02-02", nodeText = "Public" });
            subchilditem2.Add(new SubChilditem { nodeId = "01-02-03", nodeText = "Admin" });
            List<SubChilditem> subchilditem3 = new List<SubChilditem>();
            childitem1.Add(new Childitem { nodeId = "01-03", nodeText = "Windows", child = subchilditem3 });
            subchilditem3.Add(new SubChilditem { nodeId = "01-03-01", nodeText = "Boot" });
            subchilditem3.Add(new SubChilditem { nodeId = "01-03-02", nodeText = "FileManager" });
            subchilditem3.Add(new SubChilditem { nodeId = "01-03-03", nodeText = "System32" });
            List<Childitem> childitem2 = new List<Childitem>();
            parentitem.Add(new Parentitem
            {
                nodeId = "02",
                nodeText = "Local Disk (D:)",
                child = childitem2,
            });
            List<SubChilditem> subchilditem4 = new List<SubChilditem>();
            childitem2.Add(new Childitem { nodeId = "02-01", nodeText = "Personals", child=subchilditem4});
            subchilditem4.Add(new SubChilditem { nodeId = "02-01-01", nodeText = "My photo.png" });
            subchilditem4.Add(new SubChilditem { nodeId = "02-01-02", nodeText = "Rental document.docx" });
            subchilditem4.Add(new SubChilditem { nodeId = "02-01-03", nodeText = "Pay slip.pdf" });
            List<SubChilditem> subchilditem5 = new List<SubChilditem>();
            childitem2.Add(new Childitem { nodeId = "02-02", nodeText = "Projects",child=subchilditem5 });
            subchilditem5.Add(new SubChilditem { nodeId = "02-02-01", nodeText = "ASP Application " });
            subchilditem5.Add(new SubChilditem { nodeId = "02-02-02", nodeText = "TypeScript Application" });
            subchilditem5.Add(new SubChilditem { nodeId = "02-02-03", nodeText = "React Application" });
           
            List<SubChilditem> subchilditem6 = new List<SubChilditem>();
            childitem2.Add(new Childitem { nodeId = "02-02", nodeText = "Office", child = subchilditem6 });
            subchilditem6.Add(new SubChilditem { nodeId = "02-03-01", nodeText = "Work details.docx " });
            subchilditem6.Add(new SubChilditem { nodeId = "02-03-02", nodeText = "Weekly report.docx" });
            subchilditem6.Add(new SubChilditem { nodeId = "02-03-03", nodeText = "Wish list.csv" });
            List <Childitem> childitem3 = new List<Childitem>();
            parentitem.Add(new Parentitem
            {
                nodeId = "03",
                nodeText = "Local Disk (E:)",
                child = childitem3,
            });
            
            List<SubChilditem> subchilditem7 = new List<SubChilditem>();
            childitem3.Add(new Childitem { nodeId = "03-01", nodeText = "Pictures" , child=subchilditem7});
            subchilditem7.Add(new SubChilditem { nodeId = "03-01-01", nodeText = "Wind.jpg " });
            subchilditem7.Add(new SubChilditem { nodeId = "03-01-02", nodeText = "Stone.jpg" });
            subchilditem7.Add(new SubChilditem { nodeId = "03-01-03", nodeText = "Home.jpg" });
            
            List<SubChilditem> subchilditem8 = new List<SubChilditem>();
            childitem3.Add(new Childitem { nodeId = "03-02", nodeText = "Documents", icon = "docx" , child=subchilditem8});
            subchilditem8.Add(new SubChilditem { nodeId = "03-02-01", nodeText = "Environment Pollution.docx " });
            subchilditem8.Add(new SubChilditem { nodeId = "03-02-02", nodeText = "Global Warming.ppt" });
            subchilditem8.Add(new SubChilditem { nodeId = "03-02-03", nodeText = "Social Network.pdf" });
           
            List<SubChilditem> subchilditem9 = new List<SubChilditem>();
            childitem3.Add(new Childitem { nodeId = "03-03", nodeText = "Study Materials",child=subchilditem9 });
            subchilditem9.Add(new SubChilditem { nodeId = "03-03-01", nodeText = "UI-Guide.pdf" });
            subchilditem9.Add(new SubChilditem { nodeId = "03-03-02", nodeText = "Tutorials.zip" });
            subchilditem9.Add(new SubChilditem { nodeId = "03-03-03", nodeText = "TypeScript.7z" });

            ViewBag.dataSource = parentitem;
            char[] value = { 'c', 'h', 'i','l','d' }; 
            string Child = new string(value);
            ViewBag.child = Child;
            return View();
        }
    }
}

public class Parentitem
{
    public string nodeId;
    public string nodeText;
    public string icon;
    public bool expanded;
    public bool selected;
    public List<Childitem> child;

}
public class Childitem
{
    public string nodeId;
    public string nodeText;
    public string icon;
    public bool expanded;
    public bool selected;
    public List<SubChilditem> child;

}
public class SubChilditem
{
    public string nodeId;
    public string nodeText;
    public string icon;
    public bool expanded;
    public bool selected;

}