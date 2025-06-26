#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.TreeView
{
    public class DefaultFunctionalitiesModel : PageModel
    {
        public List<Parentitem> ParentItems = new List<Parentitem>();
        public List<Childitem> ChildItem1 = new List<Childitem>();
        public List<SubChilditem> SubChildItem1 = new List<SubChilditem>();
        public void OnGet()
        {
            ParentItems.Add(new Parentitem
            {
                NodeId = "01",
                NodeText = "Local Disk (C:)",
                Expanded = true,
                Child = ChildItem1,
            });
            ChildItem1.Add(new Childitem { NodeId = "01-01", NodeText = "Program Files", Child = SubChildItem1 });
            SubChildItem1.Add(new SubChilditem { NodeId = "01-01-01", NodeText = "Windows NT" });
            SubChildItem1.Add(new SubChilditem { NodeId = "01-01-02", NodeText = "Windows Mail" });
            SubChildItem1.Add(new SubChilditem { NodeId = "01-01-03", NodeText = "Windows Photo Viewer" });
            List<SubChilditem> subchilditem2 = new List<SubChilditem>();
            ChildItem1.Add(new Childitem { NodeId = "01-02", NodeText = "Users", Expanded = true, Child = subchilditem2 });
            subchilditem2.Add(new SubChilditem { NodeId = "01-02-01", NodeText = "Smith" });
            subchilditem2.Add(new SubChilditem { NodeId = "01-02-02", NodeText = "Public" });
            subchilditem2.Add(new SubChilditem { NodeId = "01-02-03", NodeText = "Admin" });
            List<SubChilditem> subchilditem3 = new List<SubChilditem>();
            ChildItem1.Add(new Childitem { NodeId = "01-03", NodeText = "Windows", Child = subchilditem3 });
            subchilditem3.Add(new SubChilditem { NodeId = "01-03-01", NodeText = "Boot" });
            subchilditem3.Add(new SubChilditem { NodeId = "01-03-02", NodeText = "FileManager" });
            subchilditem3.Add(new SubChilditem { NodeId = "01-03-03", NodeText = "System32" });
            List<Childitem> childitem2 = new List<Childitem>();
            ParentItems.Add(new Parentitem
            {
                NodeId = "02",
                NodeText = "Local Disk (D:)",
                Child = childitem2,
            });
            List<SubChilditem> subchilditem4 = new List<SubChilditem>();
            childitem2.Add(new Childitem { NodeId = "02-01", NodeText = "Personals", Child = subchilditem4 });
            subchilditem4.Add(new SubChilditem { NodeId = "02-01-01", NodeText = "My photo.png" });
            subchilditem4.Add(new SubChilditem { NodeId = "02-01-02", NodeText = "Rental document.docx" });
            subchilditem4.Add(new SubChilditem { NodeId = "02-01-03", NodeText = "Payslip.pdf" });
            List<SubChilditem> subchilditem5 = new List<SubChilditem>();
            childitem2.Add(new Childitem { NodeId = "02-02", NodeText = "Projects", Child = subchilditem5 });
            subchilditem5.Add(new SubChilditem { NodeId = "02-02-01", NodeText = "Blazor Application" });
            subchilditem5.Add(new SubChilditem { NodeId = "02-02-02", NodeText = "TypeScript Application" });
            subchilditem5.Add(new SubChilditem { NodeId = "02-02-03", NodeText = "React Application" });

            List<SubChilditem> subchilditem6 = new List<SubChilditem>();
            childitem2.Add(new Childitem { NodeId = "02-02", NodeText = "Office", Child = subchilditem6 });
            subchilditem6.Add(new SubChilditem { NodeId = "02-03-01", NodeText = "Work details.docx " });
            subchilditem6.Add(new SubChilditem { NodeId = "02-03-02", NodeText = "Weekly report.docx" });
            subchilditem6.Add(new SubChilditem { NodeId = "02-03-03", NodeText = "Wishlist.csv" });
            List<Childitem> childitem3 = new List<Childitem>();
            ParentItems.Add(new Parentitem
            {
                NodeId = "03",
                NodeText = "Local Disk (E:)",
                Child = childitem3,
            });

            List<SubChilditem> subchilditem7 = new List<SubChilditem>();
            childitem3.Add(new Childitem { NodeId = "03-01", NodeText = "Pictures", Child = subchilditem7 });
            subchilditem7.Add(new SubChilditem { NodeId = "03-01-01", NodeText = "Wind.jpg " });
            subchilditem7.Add(new SubChilditem { NodeId = "03-01-02", NodeText = "Stone.jpg" });
            subchilditem7.Add(new SubChilditem { NodeId = "03-01-03", NodeText = "Home.jpg" });

            List<SubChilditem> subchilditem8 = new List<SubChilditem>();
            childitem3.Add(new Childitem { NodeId = "03-02", NodeText = "Documents", Icon = "docx", Child = subchilditem8 });
            subchilditem8.Add(new SubChilditem { NodeId = "03-02-01", NodeText = "Environment Pollution.docx " });
            subchilditem8.Add(new SubChilditem { NodeId = "03-02-02", NodeText = "Global Warming.ppt" });
            subchilditem8.Add(new SubChilditem { NodeId = "03-02-03", NodeText = "Social Network.pdf" });

            List<SubChilditem> subchilditem9 = new List<SubChilditem>();
            childitem3.Add(new Childitem { NodeId = "03-03", NodeText = "Study Materials", Child = subchilditem9 });
            subchilditem9.Add(new SubChilditem { NodeId = "03-03-01", NodeText = "UI-Guide.pdf" });
            subchilditem9.Add(new SubChilditem { NodeId = "03-03-02", NodeText = "Tutorials.zip" });
            subchilditem9.Add(new SubChilditem { NodeId = "03-03-03", NodeText = "TypeScript.7z" });

        }
    }
    public class Parentitem
    {
        public string NodeId;
        public string NodeText;
        public string Icon;
        public bool Expanded;
        public bool Selected;
        public List<Childitem> Child;

    }
    public class Childitem
    {
        public string NodeId;
        public string NodeText;
        public string Icon;
        public bool Expanded;
        public bool Selected;
        public List<SubChilditem> Child;

    }
    public class SubChilditem
    {
        public string NodeId;
        public string NodeText;
        public string Icon;
        public bool Expanded;
        public bool Selected;

    }
}
