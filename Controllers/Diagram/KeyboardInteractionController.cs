#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
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
using Syncfusion.EJ2.Diagrams;

namespace EJ2CoreSampleBrowser.Controllers.Diagram
{
    public partial class DiagramController : Controller
    {
        public IActionResult KeyboardInteraction()
        {
            List<KeyboardInformation> data = new List<KeyboardInformation>();
            data.Add(new KeyboardInformation() { id = "A", ancestor = "", fillcolor = "#3498DB" });
            data.Add(new KeyboardInformation() { id = "B", ancestor = "A", fillcolor = "#E74C3C" });
            data.Add(new KeyboardInformation() { id = "C", ancestor = "A", fillcolor = "#E74C3C" });
            data.Add(new KeyboardInformation() { id = "D", ancestor = "A", fillcolor = "#E74C3C" });
            data.Add(new KeyboardInformation() { id = "E", ancestor = "B", fillcolor = "#F39C12" });
            data.Add(new KeyboardInformation() { id = "F", ancestor = "B", fillcolor = "#F39C12" });
            data.Add(new KeyboardInformation() { id = "G", ancestor = "F", fillcolor = "#8E44AD" });
            data.Add(new KeyboardInformation() { id = "H", ancestor = "F", fillcolor = "#8E44AD" });
            data.Add(new KeyboardInformation() { id = "I", ancestor = "G", fillcolor = "#1E8449" });
            data.Add(new KeyboardInformation() { id = "J", ancestor = "G", fillcolor = "#1E8449" });

            List<DiagramCommand> commands = new List<DiagramCommand>();
            commands.Add(new DiagramCommand() { Name = "customGroup", CanExecute = "canExecuteGrouping", Execute = "executeGrouping", Gesture = new DiagramKeyGesture() { Key = Keys.G, KeyModifiers = KeyModifiers.Control } });
            commands.Add(new DiagramCommand() { Name = "customUnGroup", CanExecute = "canExecuteUngrouping", Execute = "executeUngrouping", Gesture = new DiagramKeyGesture() { Key = Keys.U, KeyModifiers = KeyModifiers.Control } });
            commands.Add(new DiagramCommand() { Name = "navigationDown", CanExecute = "canExecuteNavigation", Execute = "executeNavigationDown", Gesture = new DiagramKeyGesture() { Key = Keys.Down } });
            commands.Add(new DiagramCommand() { Name = "navigationUp", CanExecute = "canExecuteNavigation", Execute = "executeNavigationUp", Gesture = new DiagramKeyGesture() { Key = Keys.Up } });
            commands.Add(new DiagramCommand() { Name = "navigationLeft", CanExecute = "canExecuteNavigation", Execute = "executeNavigationLeft", Gesture = new DiagramKeyGesture() { Key = Keys.Left } });
            commands.Add(new DiagramCommand() { Name = "navigationRight", CanExecute = "canExecuteNavigation", Execute = "executeNavigationRight", Gesture = new DiagramKeyGesture() { Key = Keys.Right } });
            ViewBag.commands = commands;

            ViewBag.Nodes = data;
            ViewBag.getNodeDefaults = "getNodeDefaults";
            return View();
        }       
    }

    public class KeyboardInformation
    {
        public string id { get; set; }
        public string ancestor { get; set; }
        public string fillcolor { get; set; }

    }
}