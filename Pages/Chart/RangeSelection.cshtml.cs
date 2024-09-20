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
    public class RangeSelectionModel : PageModel
    {
        public List<RangeSelectionData> ChartPoints { get; set; }
        public string[] Data { get; set; }

        public void OnGet()
        {
            ChartPoints = new List<RangeSelectionData>
            {
               new RangeSelectionData { Period = 1971, ProductA_Sales = 50, ProductB_Sales = 23},
                new RangeSelectionData { Period = 1972, ProductA_Sales = 20, ProductB_Sales = 63},
                new RangeSelectionData { Period = 1973, ProductA_Sales = 63, ProductB_Sales = 83},
                new RangeSelectionData { Period = 1974, ProductA_Sales = 81, ProductB_Sales = 43},
                new RangeSelectionData { Period = 1975, ProductA_Sales = 64, ProductB_Sales = 8},
                new RangeSelectionData { Period = 1976, ProductA_Sales = 36, ProductB_Sales = 41},
                new RangeSelectionData { Period = 1977, ProductA_Sales = 22, ProductB_Sales = 56},
                new RangeSelectionData { Period = 1978, ProductA_Sales = 78, ProductB_Sales = 31},
                new RangeSelectionData { Period = 1979, ProductA_Sales = 60, ProductB_Sales = 29},
                new RangeSelectionData { Period = 1980, ProductA_Sales = 41, ProductB_Sales = 87},
                new RangeSelectionData { Period = 1981, ProductA_Sales = 12, ProductB_Sales = 43},
                new RangeSelectionData { Period = 1982, ProductA_Sales = 56, ProductB_Sales = 12},
                new RangeSelectionData { Period = 1983, ProductA_Sales = 96, ProductB_Sales = 38},
                new RangeSelectionData { Period = 1984, ProductA_Sales = 48, ProductB_Sales = 67},
                new RangeSelectionData { Period = 1985, ProductA_Sales = 23, ProductB_Sales = 49},
                new RangeSelectionData { Period = 1986, ProductA_Sales = 54, ProductB_Sales = 67},
                new RangeSelectionData { Period = 1987, ProductA_Sales = 73, ProductB_Sales = 83},
                new RangeSelectionData { Period = 1988, ProductA_Sales = 56, ProductB_Sales = 16},
                new RangeSelectionData { Period = 1989, ProductA_Sales = 69, ProductB_Sales = 89},
                new RangeSelectionData { Period = 1990, ProductA_Sales = 79, ProductB_Sales = 18 },
                new RangeSelectionData { Period = 1991, ProductA_Sales = 18, ProductB_Sales = 46 },
                new RangeSelectionData { Period = 1992, ProductA_Sales = 78, ProductB_Sales = 39 },
                new RangeSelectionData { Period = 1993, ProductA_Sales = 92, ProductB_Sales = 18 },
                new RangeSelectionData { Period = 1994, ProductA_Sales = 93, ProductB_Sales = 87 },
                new RangeSelectionData { Period = 1995, ProductA_Sales = 29, ProductB_Sales = 45 },
                new RangeSelectionData { Period = 1996, ProductA_Sales = 14, ProductB_Sales = 42 },
                new RangeSelectionData { Period = 1997, ProductA_Sales = 85, ProductB_Sales = 28 },
                new RangeSelectionData { Period = 1998, ProductA_Sales = 24, ProductB_Sales = 82 },
                new RangeSelectionData { Period = 1999, ProductA_Sales = 11, ProductB_Sales = 13 },
                new RangeSelectionData { Period = 2000, ProductA_Sales = 80, ProductB_Sales = 83 },
                new RangeSelectionData { Period = 2001, ProductA_Sales = 14, ProductB_Sales = 26 },
                new RangeSelectionData { Period = 2002, ProductA_Sales = 34, ProductB_Sales = 57 },
                new RangeSelectionData { Period = 2003, ProductA_Sales = 81, ProductB_Sales = 48 },
                new RangeSelectionData { Period = 2004, ProductA_Sales = 70, ProductB_Sales = 84 },
                new RangeSelectionData { Period = 2005, ProductA_Sales = 80, ProductB_Sales = 64 },
                new RangeSelectionData { Period = 2006, ProductA_Sales = 70, ProductB_Sales = 24 },
                new RangeSelectionData { Period = 2007, ProductA_Sales = 32, ProductB_Sales = 82 },
                new RangeSelectionData { Period = 2008, ProductA_Sales = 43, ProductB_Sales = 37 },
                new RangeSelectionData { Period = 2009, ProductA_Sales = 21, ProductB_Sales = 68 },
                new RangeSelectionData { Period = 2010, ProductA_Sales = 63, ProductB_Sales = 37 },
                new RangeSelectionData { Period = 2011, ProductA_Sales = 9,  ProductB_Sales = 35 },
                new RangeSelectionData { Period = 2012, ProductA_Sales = 51, ProductB_Sales = 81 },
                new RangeSelectionData { Period = 2013, ProductA_Sales = 25, ProductB_Sales = 38 },
                new RangeSelectionData { Period = 2014, ProductA_Sales = 96, ProductB_Sales = 51 },
                new RangeSelectionData { Period = 2015, ProductA_Sales = 32, ProductB_Sales = 58 }

            };
            Data = new string[] { "DragXY", "DragX", "DragY", "Lasso" };
        }
    }
    public class RangeSelectionData
    {            
        public double Period;
        public double ProductA_Sales;
        public double ProductB_Sales;
    }
}