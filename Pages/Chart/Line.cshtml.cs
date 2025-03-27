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
    public class LineModel : PageModel
    {
        public List<LineChartData> ChartData { get; set; }
        public void OnGet()
        {
            ChartData = new List<LineChartData>
            {
                new LineChartData { Period = 2016, Can_Growth = 4.8 , Viet_Growth = 7.8 , Mal_Growth = 14.6, Egy_Growth = 8.9 , Ind_Growth = 19.0 },
                new LineChartData { Period = 2017, Can_Growth = 5.2 , Viet_Growth = 10.3, Mal_Growth = 15.5, Egy_Growth = 10.3, Ind_Growth = 20.0 },
                new LineChartData { Period = 2018, Can_Growth = 6.2 , Viet_Growth = 15.5, Mal_Growth = 15.4, Egy_Growth = 10.8, Ind_Growth = 20.2  },
                new LineChartData { Period = 2019, Can_Growth = 7.8 , Viet_Growth = 17.5, Mal_Growth = 14.4, Egy_Growth = 9.0 , Ind_Growth = 18.4 },
                new LineChartData { Period = 2020, Can_Growth = 9.3 , Viet_Growth = 19.5, Mal_Growth = 11.6, Egy_Growth = 7.9 , Ind_Growth = 16.8 },
                new LineChartData { Period = 2021, Can_Growth = 14.3, Viet_Growth = 23.0, Mal_Growth = 13.9, Egy_Growth = 8.5 , Ind_Growth = 18.5 },
                new LineChartData { Period = 2022, Can_Growth = 15.6, Viet_Growth = 20.0, Mal_Growth = 12.1, Egy_Growth = 7.4 , Ind_Growth = 18.4 },
                new LineChartData { Period = 2023, Can_Growth = 16.0, Viet_Growth = 19.0, Mal_Growth = 10.0, Egy_Growth = 6.4 , Ind_Growth = 16.3 },
                new LineChartData { Period = 2024, Can_Growth = 17.0, Viet_Growth = 22.1, Mal_Growth = 10.8, Egy_Growth = 7.1 , Ind_Growth = 13.7 }
            };
        }
        
    }
   
}
