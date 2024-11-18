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
    public class AreaModel : PageModel
    {
        public List<AreaChartData> Other { get; set; }
        public List<AreaChartData> Track { get; set; }
        public List<AreaChartData> Streaming { get; set; }
        public List<AreaChartData> Download { get; set; }
        public List<AreaChartData> Compact { get; set; }
        public List<AreaChartData> Casette { get; set; }
        public List<AreaChartData> Vinyl { get; set; }

        public void OnGet()
        {
            Other = new List<AreaChartData>
            {
                new AreaChartData { Period = new DateTime(1988, 01, 01), USD = -0.16 },
                new AreaChartData { Period = new DateTime(1989, 01, 01), USD = -0.17 },
                new AreaChartData { Period = new DateTime(1990, 01, 01), USD = -0.08 },
                new AreaChartData { Period = new DateTime(1992, 01, 01), USD = 0.08 },
                new AreaChartData { Period = new DateTime(1996, 01, 01), USD = 0.161 },
                new AreaChartData { Period = new DateTime(1998, 01, 01), USD = 0.48 },
                new AreaChartData { Period = new DateTime(1999, 01, 01), USD = 1.16 },
                new AreaChartData { Period = new DateTime(2001, 01, 01), USD = 0.40 },
                new AreaChartData { Period = new DateTime(2002, 01, 01), USD = 0.32 },
                new AreaChartData { Period = new DateTime(2003, 01, 01), USD = 0.807 },
                new AreaChartData { Period = new DateTime(2005, 01, 01), USD = 1.12 },
                new AreaChartData { Period = new DateTime(2006, 01, 01), USD = 1.614 },
                new AreaChartData { Period = new DateTime(2008, 01, 01), USD = 1.210 },
                new AreaChartData { Period = new DateTime(2009, 01, 01), USD = 1.12 },
                new AreaChartData { Period = new DateTime(2011, 01, 01), USD = 0.64 },
                new AreaChartData { Period = new DateTime(2013, 01, 01), USD = 0.161 },
                new AreaChartData { Period = new DateTime(2018, 01, 01), USD = 0.080 }
            };
            Track = new List<AreaChartData>
            {
                new AreaChartData { Period = new DateTime(1973, 01, 01), USD = 2.58 },
                new AreaChartData { Period = new DateTime(1975, 01, 01), USD = 2.25 },
                new AreaChartData { Period = new DateTime(1977, 01, 01), USD = 3.55 },
                new AreaChartData { Period = new DateTime(1978, 01, 01), USD = 2.42 },
                new AreaChartData { Period = new DateTime(1981, 01, 01), USD = -0.24 },
                new AreaChartData { Period = new DateTime(1982, 01, 01), USD = -0 }
            };
            Streaming = new List<AreaChartData>
            {
                new AreaChartData { Period = new DateTime(2011, 01, 01), USD = 0.48 },
                new AreaChartData { Period = new DateTime(2013, 01, 01), USD = 1.61 },
                new AreaChartData { Period = new DateTime(2015, 01, 01), USD = 2.17 },
                new AreaChartData { Period = new DateTime(2017, 01, 01), USD = 7.18 }
            };
            Download = new List<AreaChartData>
            {
                new AreaChartData { Period = new DateTime(2004, 01, 01), USD = 0.48 },
                new AreaChartData { Period = new DateTime(2007, 01, 01), USD = 1.45 },
                new AreaChartData { Period = new DateTime(2012, 01, 01), USD = 2.82 },
                new AreaChartData { Period = new DateTime(2013, 01, 01), USD = 2.58 },
                new AreaChartData { Period = new DateTime(2015, 01, 01), USD = 2.01 },
                new AreaChartData { Period = new DateTime(2016, 01, 01), USD = 1.61 },
                new AreaChartData { Period = new DateTime(2017, 01, 01), USD = 0.80 }
            };
           Compact = new List<AreaChartData>
            {
                new AreaChartData { Period = new DateTime(1990, 01, 01), USD = 0.69 },
                new AreaChartData { Period = new DateTime(1992, 01, 01), USD = 2.86 },
                new AreaChartData { Period = new DateTime(1995, 01, 01), USD = 10.2 },
                new AreaChartData { Period = new DateTime(1996, 01, 01), USD = 13.0 },
                new AreaChartData { Period = new DateTime(1997, 01, 01), USD = 14.35 },
                new AreaChartData { Period = new DateTime(1998, 01, 01), USD = 15.17 },
                new AreaChartData { Period = new DateTime(1999, 01, 01), USD = 14.89 },
                new AreaChartData { Period = new DateTime(2000, 01, 01), USD = 18.96 },
                new AreaChartData { Period = new DateTime(2001, 01, 01), USD = 18.78 },
                new AreaChartData { Period = new DateTime(2004, 01, 01), USD = 14.25 },
                new AreaChartData { Period = new DateTime(2005, 01, 01), USD = 14.24 },
                new AreaChartData { Period = new DateTime(2006, 01, 01), USD = 12.34 },
                new AreaChartData { Period = new DateTime(2007, 01, 01), USD = 9.34 },
                new AreaChartData { Period = new DateTime(2008, 01, 01), USD = 4.45 },
                new AreaChartData { Period = new DateTime(2010, 01, 01), USD = 1.46 },
                new AreaChartData { Period = new DateTime(2011, 01, 01), USD = 0.64 }
            };
            Casette = new List<AreaChartData>
            {
                new AreaChartData { Period = new DateTime(1976, 01, 01), USD = 0.08 },
                new AreaChartData { Period = new DateTime(1979, 01, 01), USD = 1.85 },
                new AreaChartData { Period = new DateTime(1980, 01, 01), USD = 2.0 },
                new AreaChartData { Period = new DateTime(1982, 01, 01), USD = 3.55 },
                new AreaChartData { Period = new DateTime(1984, 01, 01), USD = 5.40 },
                new AreaChartData { Period = new DateTime(1985, 01, 01), USD = 5.24 },
                new AreaChartData { Period = new DateTime(1988, 01, 01), USD = 6.94 },
                new AreaChartData { Period = new DateTime(1989, 01, 01), USD = 6.85 },
                new AreaChartData { Period = new DateTime(1990, 01, 01), USD = 7.02 },
                new AreaChartData { Period = new DateTime(1992, 01, 01), USD = 5.81 },
                new AreaChartData { Period = new DateTime(1993, 01, 01), USD = 5.32 },
                new AreaChartData { Period = new DateTime(1994, 01, 01), USD = 4.03 },
                new AreaChartData { Period = new DateTime(1997, 01, 01), USD = 2.25 },
                new AreaChartData { Period = new DateTime(1998, 01, 01), USD = 2.01 },
                new AreaChartData { Period = new DateTime(1999, 01, 01), USD = 0.80 },
                new AreaChartData { Period = new DateTime(2001, 01, 01), USD = 0.40 }
            };
            Vinyl = new List<AreaChartData>
            {
                new AreaChartData { Period = new DateTime(1973, 01, 01), USD = 7.74 },
                new AreaChartData { Period = new DateTime(1974, 01, 01), USD = 7.58 },
                new AreaChartData { Period = new DateTime(1976, 01, 01), USD = 8.23 },
                new AreaChartData { Period = new DateTime(1977, 01, 01), USD = 9.68 },
                new AreaChartData { Period = new DateTime(1978, 01, 01), USD = 10.16 },
                new AreaChartData { Period = new DateTime(1979, 01, 01), USD = 8.15 },
                new AreaChartData { Period = new DateTime(1981, 01, 01), USD = 6.77 },
                new AreaChartData { Period = new DateTime(1982, 01, 01), USD = 5.64 },
                new AreaChartData { Period = new DateTime(1984, 01, 01), USD = 4.35 },
                new AreaChartData { Period = new DateTime(1985, 01, 01), USD = 2.50 },
                new AreaChartData { Period = new DateTime(1989, 01, 01), USD = 0.64 },
                new AreaChartData { Period = new DateTime(1990, 01, 01), USD = 0 }
            };
        }
    }
    public class AreaChartData
    {
        public DateTime Period;
        public double USD;
    }
}
