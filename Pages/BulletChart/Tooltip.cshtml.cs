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
    public class TooltipModel : PageModel
    {
        public List<TooltipData> BulletData1 { get; set; }
        public void OnGet()
        {
            BulletData1 = new List<TooltipData>
            {
                new TooltipData { Value = 70, Target = 50}
            };
        }
        
    }
    public class TooltipData
    {
        public double Value;
        public double Target;
    }
}