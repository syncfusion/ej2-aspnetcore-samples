#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Chart
{
    public class LineModel : PageModel
    {
        public List<LineChartData> ChartData { get; set; }
        public void OnGet()
        {
            ChartData = new List<LineChartData>
            {
                new LineChartData { Period = new DateTime(2012, 07, 11), Can_Growth = 13.5, Viet_Growth = 5.3,  Mal_Growth = 5.6, Egy_Growth = 6.6, Ind_Growth = 2.3 },
                new LineChartData { Period = new DateTime(2013, 07, 11), Can_Growth = 12.4, Viet_Growth = 5.6,  Mal_Growth = 4.7, Egy_Growth = 6.8, Ind_Growth = 2.6 },
                new LineChartData { Period = new DateTime(2014, 07, 11), Can_Growth = 12.7, Viet_Growth = 5.9,  Mal_Growth = 4.3, Egy_Growth = 6.5, Ind_Growth = 4.4  },
                new LineChartData { Period = new DateTime(2015, 07, 11), Can_Growth = 12.5, Viet_Growth = 5.7,  Mal_Growth = 3.8, Egy_Growth = 5.5, Ind_Growth = 4.9 },
                new LineChartData { Period = new DateTime(2016, 07, 11), Can_Growth = 12.7, Viet_Growth = 7.8,  Mal_Growth = 2.8, Egy_Growth = 5.0, Ind_Growth = 4.8 },
                new LineChartData { Period = new DateTime(2017, 07, 11), Can_Growth = 13.7, Viet_Growth = 10.3, Mal_Growth = 2.8, Egy_Growth = 6.8, Ind_Growth = 5.3 },
                new LineChartData { Period = new DateTime(2018, 07, 11), Can_Growth = 13.4, Viet_Growth = 15.5, Mal_Growth = 4.1, Egy_Growth = 7.8, Ind_Growth = 6.2 },
                new LineChartData { Period = new DateTime(2019, 07, 11), Can_Growth = 12.9, Viet_Growth = 17.5, Mal_Growth = 6.8, Egy_Growth = 7.3, Ind_Growth = 7.8 },
                new LineChartData { Period = new DateTime(2020, 07, 11), Can_Growth = 11.0, Viet_Growth = 19.5, Mal_Growth = 7.1, Egy_Growth = 8.2, Ind_Growth = 9.3 }
            };
        }
        
    }
   
}
