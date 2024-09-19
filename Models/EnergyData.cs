#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
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
    public class EnergyData
    {
        public EnergyData()
        {

        }
        public EnergyData(int ID, DateTime Month, int EnergyProduced, int EnergyConsumed, string ConsumptionCategory, string WeatherCondition, int EnergyPrice)
        {
            this.ID = ID;
            this.Month = Month;
            this.EnergyProduced = EnergyProduced;
            this.EnergyConsumed = EnergyConsumed;
            this.ConsumptionCategory = ConsumptionCategory;
            this.WeatherCondition = WeatherCondition;
            this.EnergyPrice = EnergyPrice;
        }
        public int ID { get; set; }
        public DateTime Month { get; set; }
        public int EnergyProduced { get; set; }
        public int EnergyConsumed { get; set; }
        public string ConsumptionCategory { get; set; }
        public int EnergyPrice { get; set; }
        public string WeatherCondition {get; set; }

        public static List<EnergyData> GetAllRecords()
        {
            List<EnergyData> EnergyDataList = new List<Models.EnergyData>();
            EnergyDataList.Add(new EnergyData(1, new DateTime(1704067200000), 3900, 3400, "Residential", "Snowy", 52)); 
            EnergyDataList.Add(new EnergyData(2, new DateTime(1704067200000), 7400, 6800, "Commercial", "Snowy", 57)); 
            EnergyDataList.Add(new EnergyData(3, new DateTime(1704067200000), 11400, 10200, "Industrial", "Snowy", 62)); 
            EnergyDataList.Add(new EnergyData(4, new DateTime(1706745600000), 3700, 3200, "Residential", "Cloudy", 54)); 
            EnergyDataList.Add(new EnergyData(5, new DateTime(1706745600000), 7000, 7400, "Commercial", "Cloudy", 59)); 
            EnergyDataList.Add(new EnergyData(6, new DateTime(1706745600000), 10600, 10000, "Industrial", "Cloudy", 64)); 
            EnergyDataList.Add(new EnergyData(7, new DateTime(1709232000000), 4000, 3500, "Residential", "Sunny", 56)); 
            EnergyDataList.Add(new EnergyData(8, new DateTime(1709232000000), 7600, 8000, "Commercial", "Sunny", 60)); 
            EnergyDataList.Add(new EnergyData(9, new DateTime(1709232000000), 11500, 10500, "Industrial", "Sunny", 65)); 
            EnergyDataList.Add(new EnergyData(10, new DateTime(1711910400000), 4100, 4200, "Residential", "Rainy", 57)); 
            EnergyDataList.Add(new EnergyData(11, new DateTime(1711910400000), 7800, 7200, "Commercial", "Rainy", 62)); 
            EnergyDataList.Add(new EnergyData(12, new DateTime(1711910400000), 11900, 11800, "Industrial", "Rainy", 67)); 
            EnergyDataList.Add(new EnergyData(13, new DateTime(1714588800000), 4200, 3700, "Residential", "Sunny", 58)); 
            EnergyDataList.Add(new EnergyData(14, new DateTime(1714588800000), 8000, 8500, "Commercial", "Sunny", 63)); 
            EnergyDataList.Add(new EnergyData(15, new DateTime(1714588800000), 12200, 11000, "Industrial", "Sunny", 69)); 
            EnergyDataList.Add(new EnergyData(16, new DateTime(1717267200000), 4300, 3800, "Residential", "Cloudy", 59)); 
            EnergyDataList.Add(new EnergyData(17, new DateTime(1717267200000), 8200, 7600, "Commercial", "Cloudy", 64)); 
            EnergyDataList.Add(new EnergyData(18, new DateTime(1717267200000), 12700, 11500, "Industrial", "Cloudy", 70)); 
            EnergyDataList.Add(new EnergyData(19, new DateTime(1719849600000), 4400, 3900, "Residential", "Hot", 61)); 
            EnergyDataList.Add(new EnergyData(20, new DateTime(1719849600000), 8400, 7800, "Commercial", "Hot", 66)); 
            EnergyDataList.Add(new EnergyData(21, new DateTime(1719849600000), 13300, 12000, "Industrial", "Hot", 73)); 
            EnergyDataList.Add(new EnergyData(22, new DateTime(1722528000000), 4500, 5000, "Residential", "Snowy", 63)); 
            EnergyDataList.Add(new EnergyData(23, new DateTime(1722528000000), 8600, 8000, "Commercial", "Snowy", 68)); 
            EnergyDataList.Add(new EnergyData(24, new DateTime(1722528000000), 13900, 12500, "Industrial", "Snowy", 76)); 
            EnergyDataList.Add(new EnergyData(25, new DateTime(1725206400000), 4600, 5000, "Residential", "Hot", 64)); 
            EnergyDataList.Add(new EnergyData(26, new DateTime(1725206400000), 8800, 8200, "Commercial", "Hot", 69)); 
            EnergyDataList.Add(new EnergyData(27, new DateTime(1725206400000), 14400, 13000, "Industrial", "Hot", 79)); 
            EnergyDataList.Add(new EnergyData(28, new DateTime(1727788800000), 4700, 5000, "Residential", "Rainy", 65)); 
            EnergyDataList.Add(new EnergyData(29, new DateTime(1727788800000), 9000, 8400, "Commercial", "Rainy", 70)); 
            EnergyDataList.Add(new EnergyData(30, new DateTime(1727788800000), 14900, 13500, "Industrial", "Rainy", 82)); 
            EnergyDataList.Add(new EnergyData(31, new DateTime(1730467200000), 4800, 4300, "Residential", "Cloudy", 66)); 
            EnergyDataList.Add(new EnergyData(32, new DateTime(1730467200000), 9200, 8600, "Commercial", "Cloudy", 72)); 
            EnergyDataList.Add(new EnergyData(33, new DateTime(1730467200000), 15400, 14000, "Industrial", "Cloudy", 85)); 
            EnergyDataList.Add(new EnergyData(34, new DateTime(1733145600000), 4900, 5000, "Residential", "Hot", 67)); 
            EnergyDataList.Add(new EnergyData(35, new DateTime(1733145600000), 9400, 8800, "Commercial", "Hot", 74)); 
            EnergyDataList.Add(new EnergyData(36, new DateTime(1733145600000), 15900, 14500, "Industrial", "Hot", 88));
            return EnergyDataList;
        }
    }
}
