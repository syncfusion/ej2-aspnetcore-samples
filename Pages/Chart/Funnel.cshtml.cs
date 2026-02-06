#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Chart
{
    public class FunnelModel : PageModel
    {
        public List<FunnelChartData> ChartPoints { get; set; }
        public void OnGet()
        {
            ChartPoints = new List<FunnelChartData>
            {
                new FunnelChartData { InterviewProcess = "Candidates Applied", Candidates = 170,  DataLabelMappingName = "Applications Received: 170" },
                new FunnelChartData { InterviewProcess = "Initial Validation", Candidates = 145,  DataLabelMappingName = "Initial Validation: 145" },
                new FunnelChartData { InterviewProcess = "Screening", Candidates = 105,  DataLabelMappingName = "Screening Completed: 105" },
                new FunnelChartData { InterviewProcess = "Telephonic Interview", Candidates = 85, DataLabelMappingName = "Phone Interview: 85" },
                new FunnelChartData { InterviewProcess = "Personal Interview", Candidates = 58, DataLabelMappingName = "Final Interview: 58" },
                new FunnelChartData { InterviewProcess = "Hired", Candidates = 30, DataLabelMappingName = "Final <br> Selections: 30" }
            };
        }
    }
    public class FunnelChartData
    {
        public string InterviewProcess;
        public double Candidates;
        public string DataLabelMappingName;
    }
}
