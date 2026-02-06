#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.BulletChart
{
    public class LegendModel : PageModel
    {
        public List<LegendData> BulletData1 { get; set; }
        public void OnGet()
        {
            BulletData1 = new List<LegendData>
            {
                new LegendData { Value = 25, Target = new double[]{ 20, 26, 28 } }
            };
        }
        
    }
    public class LegendData
    {
        public double Value;
        public double[] Target;
    }
}
