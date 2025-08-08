#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Chart
{
    public class RangeColorMappingModel : PageModel
    {
        public List<RangeColorMappingData> ChartData { get; set; }
        public  string[] Color1 { get; set; }
        public  string[] Color2 { get; set; }
        public  string[] Color3 { get; set; }

        public void OnGet()
        {
            ChartData = new List<RangeColorMappingData>
            {
                new RangeColorMappingData { x= "Jan", y= 6.96},
                new RangeColorMappingData { x= "Feb", y= 8.9},
                new RangeColorMappingData { x= "Mar", y= 12},
                new RangeColorMappingData { x= "Apr", y= 17.5},
                new RangeColorMappingData { x= "May", y= 22.1},
                new RangeColorMappingData { x= "June", y= 25},
                new RangeColorMappingData { x= "July", y= 29.4},
                new RangeColorMappingData { x= "Aug", y= 29.6},
                new RangeColorMappingData { x= "Sep", y= 25.8},
                new RangeColorMappingData { x= "Oct", y= 21.1},
                new RangeColorMappingData { x= "Nov", y= 15.5},
                new RangeColorMappingData { x= "Dec", y= 9.9}
            };
            Color1 = new string[] { "#F9D422" };
            Color2 = new string[]{ "#F28F3F" };
            Color3 = new string[]{ "#E94F53" };
        }
    }
    public class RangeColorMappingData
    {
        public string x;
        public double y;
    }
}