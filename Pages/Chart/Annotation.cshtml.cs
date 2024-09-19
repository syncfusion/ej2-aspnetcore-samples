#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser_NET8.Pages.Chart
{
    public class AnnotationModel : PageModel
    {
        public List<ChartData> DataSource { get; set; }
        public void OnGet()
        {
            DataSource = new List<ChartData>
            {
                new ChartData {X=  "2014", Y0= 51, Y1= 77, Y2= 66, Y3= 34 },
                new ChartData {  X= "2015", Y0= 67, Y1= 49, Y2= 19, Y3= 38 },
                new ChartData { X= "2016", Y0= 143, Y1= 121, Y2= 91, Y3= 44},
                new ChartData { X= "2017", Y0= 19, Y1= 28, Y2= 65, Y3= 51 },
                new ChartData { X= "2018", Y0= 30, Y1= 66, Y2= 32, Y3= 61},
                new ChartData { X= "2019", Y0= 189, Y1= 128, Y2= 122, Y3= 76},
                new ChartData { X= "2020", Y0= 72, Y1= 97, Y2= 65, Y3= 82 },
            };
        }
    }
    public class ChartData
    {
        public string X;
        public double Y0;
        public double Y1;
        public double Y2;
        public double Y3;
    }
}
