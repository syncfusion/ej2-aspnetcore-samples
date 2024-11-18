#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.BulletChart
{
    public class RtlModel : PageModel
    {
        public List<RtlData> BulletData1 { get; set; }
        public void OnGet()
        {
            BulletData1 = new List<RtlData>
            {
                new RtlData { Value = 270, Target = 250}
            };
        }
        
    }
    public class RtlData
    {
        public double Value;
        public double Target;
    }
}
