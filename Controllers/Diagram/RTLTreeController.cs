#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
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

namespace EJ2CoreSampleBrowser.Controllers.Diagram
{
    public partial class DiagramController : Controller
    {
        public IActionResult RTLTree()
        {
            ViewBag.Nodes = RTLData.GetAllRecords();
            ViewBag.getConnectorDefaults = "getConnectorDefaults";
            ViewBag.getNodeDefaults = "getNodeDefaults";
            return View();
        }
    }
    public class RTLData
    {
        public string Name { get; set; }
        public string Branch { get; set; }
        public string Category { get; set; }

        public RTLData(string Name, string Branch, string Category)
        {
            this.Name = Name;
            this.Branch = Branch;
            this.Category = Category;
        }
        public static List<RTLData> GetAllRecords()
        {
            List<RTLData> data = new List<RTLData>();
            data.Add(new RTLData("Artificial Intelligence", "root", ""));
            data.Add(new RTLData("Machine Learning", "", "Artificial Intelligence"));
            data.Add(new RTLData("Natural Language Processing (NLP)", "", "Artificial Intelligence"));
            data.Add(new RTLData("Speech", "", "Artificial Intelligence"));
            data.Add(new RTLData("Planning, Scheduling and Optimization", "", "Artificial Intelligence"));
            data.Add(new RTLData("Robotics", "", "Artificial Intelligence"));
            data.Add(new RTLData("Vision", "", "Artificial Intelligence"));
            data.Add(new RTLData(" Deep Learning ", "", "Machine Learning"));
            data.Add(new RTLData("Predictive Analytics ", "", "Machine Learning"));
            data.Add(new RTLData("Translation ", "", "Natural Language Processing (NLP)"));
            data.Add(new RTLData("Classification", "", "Natural Language Processing (NLP)"));
            data.Add(new RTLData("Information Extraction", "", "Natural Language Processing (NLP)"));
            data.Add(new RTLData("Speech to Text", "", "Speech"));
            data.Add(new RTLData("Image Recognition ", "", "Vision"));
            data.Add(new RTLData("Machine Vision", "", "Vision"));

            return data;
        }
    }
}