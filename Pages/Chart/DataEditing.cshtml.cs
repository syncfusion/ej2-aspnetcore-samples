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
    public class DataEditingModel : PageModel
    {
        public List<DataEditingData> ConsumerDetails { get; set; }
        public void OnGet()
        {
            ConsumerDetails = new List<DataEditingData>
            {
                new DataEditingData { Period = "2005", ProductA_Sales = 21, ProductB_Sales= 28},
                new DataEditingData { Period = "2006", ProductA_Sales = 24, ProductB_Sales= 44},
                new DataEditingData { Period = "2007", ProductA_Sales = 36, ProductB_Sales= 48},
                new DataEditingData { Period = "2008", ProductA_Sales = 38, ProductB_Sales= 50},
                new DataEditingData { Period = "2009", ProductA_Sales = 54, ProductB_Sales= 66},
                new DataEditingData { Period = "2010", ProductA_Sales = 57, ProductB_Sales= 78},
                new DataEditingData { Period = "2011", ProductA_Sales = 70, ProductB_Sales= 84}
            };
        }
    }
    public class DataEditingData
    {
        public string Period;
        public double ProductA_Sales;
        public double ProductB_Sales;
    }
}
