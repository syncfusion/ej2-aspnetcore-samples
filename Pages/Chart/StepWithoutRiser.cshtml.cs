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
    public class StepWithoutRiserModel : PageModel
    {
        public List<StepWithoutRiserChartData> ChartPoints { get; set; }
        public void OnGet()
        {
            ChartPoints = new List<StepWithoutRiserChartData>
            {
                new StepWithoutRiserChartData { X = new DateTime(1980, 01, 01), Y = 23 },
                new StepWithoutRiserChartData { X = new DateTime(1981, 01, 01), Y = 89 },
                new StepWithoutRiserChartData { X = new DateTime(1982, 01, 01), Y = 45 },
                new StepWithoutRiserChartData { X = new DateTime(1983, 01, 01), Y = 67 },
                new StepWithoutRiserChartData { X = new DateTime(1984, 01, 01), Y = 76 },
                new StepWithoutRiserChartData { X = new DateTime(1985, 01, 01), Y = 34 },
                new StepWithoutRiserChartData { X = new DateTime(1986, 01, 01), Y = 90 },
                new StepWithoutRiserChartData { X = new DateTime(1987, 01, 01), Y = 65 },
                new StepWithoutRiserChartData { X = new DateTime(1988, 01, 01), Y = 77 },
                new StepWithoutRiserChartData { X = new DateTime(1989, 01, 01), Y = 43 },
                new StepWithoutRiserChartData { X = new DateTime(1990, 01, 01), Y = 92 },
                new StepWithoutRiserChartData { X = new DateTime(1991, 01, 01), Y = 81 },
                new StepWithoutRiserChartData { X = new DateTime(1992, 01, 01), Y = 65 },
                new StepWithoutRiserChartData { X = new DateTime(1993, 01, 01), Y = 87 },
                new StepWithoutRiserChartData { X = new DateTime(1994, 01, 01), Y = 50 },
                new StepWithoutRiserChartData { X = new DateTime(1995, 01, 01), Y = 98 },
                new StepWithoutRiserChartData { X = new DateTime(1996, 01, 01), Y = 62 },
                new StepWithoutRiserChartData { X = new DateTime(1997, 01, 01), Y = 75 },
                new StepWithoutRiserChartData { X = new DateTime(1998, 01, 01), Y = 64 },
                new StepWithoutRiserChartData { X = new DateTime(1999, 01, 01), Y = 88 },
                new StepWithoutRiserChartData { X = new DateTime(2000, 01, 01), Y = 99 },
                new StepWithoutRiserChartData { X = new DateTime(2001, 01, 01), Y = 77 },
                new StepWithoutRiserChartData { X = new DateTime(2002, 01, 01), Y = 65 },
                new StepWithoutRiserChartData { X = new DateTime(2003, 01, 01), Y = 89 },
                new StepWithoutRiserChartData { X = new DateTime(2004, 01, 01), Y = 45 },
                new StepWithoutRiserChartData { X = new DateTime(2005, 01, 01), Y = 67 },
                new StepWithoutRiserChartData { X = new DateTime(2006, 01, 01), Y = 56 },
                new StepWithoutRiserChartData { X = new DateTime(2007, 01, 01), Y = 78 },
                new StepWithoutRiserChartData { X = new DateTime(2008, 01, 01), Y = 82 },
                new StepWithoutRiserChartData { X = new DateTime(2009, 01, 01), Y = 90 },
                new StepWithoutRiserChartData { X = new DateTime(2010, 01, 01), Y = 55 },
                new StepWithoutRiserChartData { X = new DateTime(2011, 01, 01), Y = 65 },
                new StepWithoutRiserChartData { X = new DateTime(2012, 01, 01), Y = 87 },
                new StepWithoutRiserChartData { X = new DateTime(2013, 01, 01), Y = 76 },
                new StepWithoutRiserChartData { X = new DateTime(2014, 01, 01), Y = 45 },
                new StepWithoutRiserChartData { X = new DateTime(2015, 01, 01), Y = 67 },
                new StepWithoutRiserChartData { X = new DateTime(2016, 01, 01), Y = 89 },
                new StepWithoutRiserChartData { X = new DateTime(2017, 01, 01), Y = 76 },
                new StepWithoutRiserChartData { X = new DateTime(2018, 01, 01), Y = 45 },
                new StepWithoutRiserChartData { X = new DateTime(2019, 01, 01), Y = 67 },
                new StepWithoutRiserChartData { X = new DateTime(2020, 01, 01), Y = 89 }
            };
        }
    }
    public class StepWithoutRiserChartData
    {
        public DateTime X;
        public double Y;
    }
}
