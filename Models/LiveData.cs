#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace EJ2CoreSampleBrowser_NET6.Models
{
    public class LiveData
    {
        public static List<LiveData> tradeData = new List<LiveData>();

        public long id { get; set; }
        public string CountryCode { get; set; }
        public decimal Change { get; set; }
        public decimal Net { get; set; }
        public string Rating { get; set; }
        public string Sector { get; set; }
        public string EmployeeCount { get; set; }
        public decimal NetIncome { get; set; }

        public LiveData(long Id, string CountryCode, decimal Change, decimal Net, string Rating, string Sector, string EmployeeCount, decimal NetIncome)
        {
            this.id = Id;
            this.CountryCode = CountryCode;
            this.Net = Net;
            this.Rating = Rating;
            this.Sector = Sector;
            this.EmployeeCount = EmployeeCount;
            this.NetIncome = NetIncome;
        }

        public static List<LiveData> GetLiveDatas(long dataCount)
        {
            string[] ContryNames = { "ALA", "ALB", "DZA", "ASM", "AND", "AGO", "AIA", "ATA", "ATG",
            "ARG", "ARM", "ABW", "AUS", "AUT", "AZE", "BHS", "BHR", "BGD", "BRB", "BLR", "BEL", "BLZ",
            "BEN", "AFG", "BMU", "BTN", "BOL", "BES", "BIH", "BWA", "BVT", "BRA", "IOT", "BRN", "BGR",
            "BFA", "BDI", "CPV", "KHM", "CMR", "CAN", "CYM", "CAF", "TCD", "CHL", "CHN", "CXR", "CCK",
            "COL", "COM", "COG", "COD", "COK", "CRI", "CIV", "HRV", "CUB", "CUW", "CYP", "CZE", "DNK", "DJI",
            "DMA" };
            string[] Category = { "Energy", "Financial", "Technology", "Healthcare", "Retail",
            "Manufacturing", "Consumer Goods", "Telecommunications", "Transportation", "Utilities",
            "Real Estate", "Industrial Goods", "Oil and Gas", "Entertainment", "Media", "Banking",
            "Sports", "Mining", "Automotive", };
            string[] Rating = { "Buy", "Sell" };
            Random random = new Random();
            for (long i = 1; i <= dataCount; i++)
            {
                string countryCode = ContryNames[random.Next(ContryNames.Length)] + ContryNames[random.Next(ContryNames.Length)];
                decimal change = Decimal.Floor(Convert.ToDecimal(random.Next(201) - 90 * 0.96));
                decimal net = Decimal.Floor(Convert.ToDecimal(random.Next(201) - 90 * 2.95));
                string rating = Rating[random.Next(Rating.Length)];
                string sector = Category[random.Next(Category.Length)];
                string employeeCount = random.Next(10000) + 100 + "K";
                decimal netIncome = Decimal.Floor(Convert.ToDecimal(random.Next(201) - 90 * 0.45));
                tradeData.Add(new LiveData(i, countryCode, change, net, rating, sector, employeeCount, netIncome) { });
            }
            return tradeData;
        }
    }
}
