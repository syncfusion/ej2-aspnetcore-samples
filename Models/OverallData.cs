#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EJ2CoreSampleBrowser.Models
{
    public class OverallData
    {
        public OverallData()
        {

        }
        public OverallData(string Month, int Sales, int MarketingSpend, int NewCustomers, int ReturningCustomers, int WebTraffic)
        {
            this.Month = Month;
            this.Sales = Sales;
            this.MarketingSpend = MarketingSpend;
            this.NewCustomers = NewCustomers;
            this.ReturningCustomers = ReturningCustomers;
            this.WebTraffic = WebTraffic;
        }
        public string Month { get; set; }
        public int Sales { get; set; }
        public int MarketingSpend { get; set; }
        public int NewCustomers { get; set; }
        public int ReturningCustomers { get; set; }
        public int WebTraffic {get; set; }

        public static List<OverallData> GetAllRecords()
        {
            List<OverallData> OverallDataList = new List<Models.OverallData>();
            int previousYear = DateTime.Now.Year - 1;
            OverallDataList.Add(new OverallData("January " + previousYear, 51000, 9000, 180, 150, 200));
            OverallDataList.Add(new OverallData("February " + previousYear, 46000, 9200, 190, 160, 320));
            OverallDataList.Add(new OverallData("March " + previousYear, 45000, 9400, 200, 155, 190));
            OverallDataList.Add(new OverallData("April " + previousYear, 48000, 9600, 210, 165, 100));
            OverallDataList.Add(new OverallData("May " + previousYear, 49000, 9800, 220, 170, 230));
            OverallDataList.Add(new OverallData("June " + previousYear, 52000, 9600, 210, 160, 300));
            OverallDataList.Add(new OverallData("July " + previousYear, 48000, 9700, 215, 170, 175));
            OverallDataList.Add(new OverallData("August " + previousYear, 50000, 9800, 225, 180, 190));
            OverallDataList.Add(new OverallData("September " + previousYear, 45000, 9700, 220, 175, 120));
            OverallDataList.Add(new OverallData("October " + previousYear, 46000, 10000, 230, 190, 160));
            OverallDataList.Add(new OverallData("November " + previousYear, 50000, 9900, 225, 185, 230));
            OverallDataList.Add(new OverallData("December " + previousYear, 47000, 10200, 240, 200, 145));
            return OverallDataList;
        }
    }
}
