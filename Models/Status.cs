#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EJ2CoreSampleBrowser.Models
{
    public class Status
    {
        public string ID { get; set; }
        public string Text { get; set; }
        public bool State { get; set; }
        public List<Status> StatusDataList()
        {
            List<Status> status = new List<Status>();
            status.Add(new Status() { ID = "Item1", Text = "Open", State= false });
            status.Add(new Status() { ID = "Item2", Text = "Waiting for Customer", State= false });
            status.Add(new Status() { ID = "Item3", Text = "On Hold", State= true });
            status.Add(new Status() { ID = "Item4", Text = "Follow-up", State= false });
            status.Add(new Status() { ID = "Item5", Text = "Closed", State= true });
            status.Add(new Status() { ID = "Item6", Text = "Solved", State= false });
            status.Add(new Status() { ID = "Item7", Text = "Feature Request", State= false });

            return status;
        }
    }

}
