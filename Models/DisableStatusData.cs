#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
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
    public class DisableStatusData
    {
        public string Status { get; set; }
        public bool State { get; set; }
        public List<DisableStatusData> StatusDataList()
        {
            List<DisableStatusData> status = new List<DisableStatusData>();
            status.Add(new DisableStatusData() { Status = "Open", State= false });
            status.Add(new DisableStatusData() { Status = "Waiting for Customer", State= false });
            status.Add(new DisableStatusData() { Status = "On Hold", State= true });
            status.Add(new DisableStatusData() { Status = "Follow-up", State= false });
            status.Add(new DisableStatusData() { Status = "Closed", State= true });
            status.Add(new DisableStatusData() { Status = "Solved", State= false });
            status.Add(new DisableStatusData() { Status = "Feature Request", State= false });

            return status;
        }
    }

}