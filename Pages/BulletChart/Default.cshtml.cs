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
    public class DefaultModel : PageModel
    {
        public List<DefaultBulletData> BulletData1 { get; set; }
        public List<DefaultBulletData> BulletData2 { get; set; }
        public List<DefaultBulletData> BulletData3 { get; set; }
        public List<DefaultBulletData> BulletData4 { get; set; }
        public List<DefaultBulletData> BulletData5 { get; set; }
        
        public void OnGet()
        {
            BulletData1 = new List<DefaultBulletData>
            {
                new DefaultBulletData { Value = 270, Target = 250}
            };
            BulletData2 = new List<DefaultBulletData>
            {
                new DefaultBulletData { Value = 23, Target = 27}
            };
            BulletData3 = new List<DefaultBulletData>
            {
                new DefaultBulletData { Value = 350, Target = 550}
            };
            BulletData4 = new List<DefaultBulletData>
            {
                new DefaultBulletData { Value = 1600, Target = 2100}
            };
            BulletData5 = new List<DefaultBulletData>
            {
                new DefaultBulletData { Value = 4.9, Target = 4}
            };
        }
        
    }
    public class DefaultBulletData
    {
        public double Value;
        public double Target;
    }
}
