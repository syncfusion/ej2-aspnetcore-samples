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