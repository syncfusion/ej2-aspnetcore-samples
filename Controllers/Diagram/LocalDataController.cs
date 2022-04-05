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

namespace EJ2CoreSampleBrowser.Controllers.Diagram
{
    public partial class DiagramController : Controller
    {
        // GET: LocalData
        public IActionResult LocalData()
        {
            List<LocalDataDetails> localData = new List<LocalDataDetails>();
            localData.Add(new LocalDataDetails("Species", ""));
            localData.Add(new LocalDataDetails("Plants", "Species"));
            localData.Add(new LocalDataDetails("Fungi", "Species"));
            localData.Add(new LocalDataDetails("Lichens", "Species"));
            localData.Add(new LocalDataDetails("Animals", "Species"));
            localData.Add(new LocalDataDetails("Mosses", "Plants"));
            localData.Add(new LocalDataDetails("Ferns", "Plants"));
            localData.Add(new LocalDataDetails("Gymnosperms", "Plants"));
            localData.Add(new LocalDataDetails("Dicotyledens", "Plants"));
            localData.Add(new LocalDataDetails("Monocotyledens", "Plants"));
            localData.Add(new LocalDataDetails("Invertebrates", "Animals"));
            localData.Add(new LocalDataDetails("Vertebrates", "Animals"));
            localData.Add(new LocalDataDetails("Insects", "Invertebrates"));
            localData.Add(new LocalDataDetails("Molluscs", "Invertebrates"));
            localData.Add(new LocalDataDetails("Crustaceans", "Invertebrates"));
            localData.Add(new LocalDataDetails("Others", "Invertebrates"));
            localData.Add(new LocalDataDetails("Fish", "Vertebrates"));
            localData.Add(new LocalDataDetails("Amphibians", "Vertebrates"));
            localData.Add(new LocalDataDetails("Reptiles", "Vertebrates"));
            localData.Add(new LocalDataDetails("Birds", "Vertebrates"));
            localData.Add(new LocalDataDetails("Mammals", "Vertebrates"));

            ViewBag.Nodes = localData;

            ViewBag.getNodeDefaults = "getNodeDefaults";
            ViewBag.getConnectorDefaults = "getConnectorDefaults";
            return View();
        }
    }
    public class LocalDataDetails
    {
        public string Name { get; set; }
        public string Category { get; set; }
        

        public LocalDataDetails(string id, string category)
        {
            this.Name = id;
            this.Category = category;            
        }
    }
}