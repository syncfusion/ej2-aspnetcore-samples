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
    public class UpdateDataModel : PageModel
    {
        public List<UpdateDataChartData> ChartPoints { get; set; }
        public List<UpdateDataChartData> ChartPoints2 { get; set; }
        public List<UpdateDataChartData> ChartPoints3 { get; set; }
        public List<UpdateDataChartData> ChartPoints4 { get; set; }
        public List<UpdateDataChartData> ChartPoints5 { get; set; }
        public List<UpdateDataChartData> ChartPoints6 { get; set; }
        public List<UpdateDataChartData> ChartPoints7 { get; set; }
        public List<UpdateDataChartData> ChartPoints8 { get; set; }
        public List<UpdateDataChartData> ChartPoints9 { get; set; }
        public List<UpdateDataChartData> ChartPoints10 { get; set; }
        public void OnGet()
        {
            ChartPoints = new List<UpdateDataChartData>
            {
                new UpdateDataChartData { X = "Apple",      Y = 7.8451  },
                new UpdateDataChartData { X = "Google",     Y = 13.4167 },
                new UpdateDataChartData { X = "Amazon",     Y = 6.9403  },
                new UpdateDataChartData { X = "Microsoft",  Y = 20.7127 },
                new UpdateDataChartData { X = "IBM",        Y = 76.2822 },
                new UpdateDataChartData { X = "Oracle",     Y = 21.0090 },
                new UpdateDataChartData { X = "Netflix",    Y = 16.8242 }
            };
            ChartPoints2 = new List<UpdateDataChartData>
            {
                new UpdateDataChartData { X = "Apple",      Y = 10.9899  },
                new UpdateDataChartData { X = "Google",     Y = 14.2521  },
                new UpdateDataChartData { X = "Amazon",     Y = 9.8100   },
                new UpdateDataChartData { X = "Microsoft",  Y = 20.4205  },
                new UpdateDataChartData { X = "IBM",        Y = 100.6536 },
                new UpdateDataChartData { X = "Oracle",     Y = 26.0708  },
                new UpdateDataChartData { X = "Netflix",    Y = 27.4937  }
            };
            ChartPoints3 = new List<UpdateDataChartData>
            {
                new UpdateDataChartData { X = "Apple",      Y = 17.4344   },
                new UpdateDataChartData { X = "Google",     Y = 16.1018   },
                new UpdateDataChartData { X = "Amazon",     Y = 10.9887   },
                new UpdateDataChartData { X = "Microsoft",  Y = 24.0142   },
                new UpdateDataChartData { X = "IBM",        Y = 117.6709  },
                new UpdateDataChartData { X = "Oracle",     Y = 24.9828   },
                new UpdateDataChartData { X = "Netflix",    Y = 11.8551   }
            };
            ChartPoints4 = new List<UpdateDataChartData>
            {
                new UpdateDataChartData { X = "Apple",      Y = 14.5929  },
                new UpdateDataChartData { X = "Google",     Y = 22.1492 },
                new UpdateDataChartData { X = "Amazon",     Y = 14.8658  },
                new UpdateDataChartData { X = "Microsoft",  Y = 26.9842  },
                new UpdateDataChartData { X = "IBM",        Y = 118.2763 },
                new UpdateDataChartData { X = "Oracle",     Y = 28.5474  },
                new UpdateDataChartData { X = "Netflix",    Y = 35.2718  }
            };
            ChartPoints5 = new List<UpdateDataChartData>
            {
                new UpdateDataChartData { X = "Apple",      Y = 20.4231  },
                new UpdateDataChartData { X = "Google",     Y = 28.3890  },
                new UpdateDataChartData { X = "Amazon",     Y = 16.5876  },
                new UpdateDataChartData { X = "Microsoft",  Y = 36.2762  },
                new UpdateDataChartData { X = "IBM",        Y = 113.4907 },
                new UpdateDataChartData { X = "Oracle",     Y = 34.4296  },
                new UpdateDataChartData { X = "Netflix",    Y = 57.4951  }
            };
            ChartPoints6 = new List<UpdateDataChartData>
            {
                new UpdateDataChartData { X = "Apple",      Y = 27.0239 },
                new UpdateDataChartData { X = "Google",     Y = 30.9638 },
                new UpdateDataChartData { X = "Amazon",     Y = 23.8494 },
                new UpdateDataChartData { X = "Microsoft",  Y = 40.9778 },
                new UpdateDataChartData { X = "IBM",        Y = 99.4267 },
                new UpdateDataChartData { X = "Oracle",     Y = 35.4508 },
                new UpdateDataChartData { X = "Netflix",    Y = 91.8956 }
            };
            ChartPoints7 = new List<UpdateDataChartData>
            {
                new UpdateDataChartData { X = "Apple",      Y = 24.0368   },
                new UpdateDataChartData { X = "Google",     Y = 38.1172   },
                new UpdateDataChartData { X = "Amazon",     Y = 34.8921   },
                new UpdateDataChartData { X = "Microsoft",  Y = 49.8084   },
                new UpdateDataChartData { X = "IBM",        Y = 100.0202  },
                new UpdateDataChartData { X = "Oracle",     Y = 34.6261   },
                new UpdateDataChartData { X = "Netflix",    Y = 102.0304  }
            };
            ChartPoints8 = new List<UpdateDataChartData>
            {
                new UpdateDataChartData { X = "Apple",      Y = 35.2487  },
                new UpdateDataChartData { X = "Google",     Y = 46.9350  },
                new UpdateDataChartData { X = "Amazon",     Y = 48.2920  },
                new UpdateDataChartData { X = "Microsoft",  Y = 66.5079  },
                new UpdateDataChartData { X = "IBM",        Y = 108.4717 },
                new UpdateDataChartData { X = "Oracle",     Y = 41.7164  },
                new UpdateDataChartData { X = "Netflix",    Y = 165.3743 }
            };
            ChartPoints9 = new List<UpdateDataChartData>
            {
                new UpdateDataChartData { X = "Apple",      Y = 44.9396  },
                new UpdateDataChartData { X = "Google",     Y = 56.0381  },
                new UpdateDataChartData { X = "Amazon",     Y = 81.8891  },
                new UpdateDataChartData { X = "Microsoft",  Y = 95.1360  },
                new UpdateDataChartData { X = "IBM",        Y = 103.0934 },
                new UpdateDataChartData { X = "Oracle",     Y = 43.7122  },
                new UpdateDataChartData { X = "Netflix",    Y = 319.2903 }
            };
            ChartPoints10 = new List<UpdateDataChartData>
            {
                new UpdateDataChartData { X = "Apple",      Y = 50.2883  },
                new UpdateDataChartData { X = "Google",     Y = 59.4929  },
                new UpdateDataChartData { X = "Amazon",     Y = 89.2447  },
                new UpdateDataChartData { X = "Microsoft",  Y = 124.6044 },
                new UpdateDataChartData { X = "IBM",        Y = 103.0097 },
                new UpdateDataChartData { X = "Oracle",     Y = 49.6689  },
                new UpdateDataChartData { X = "Netflix",    Y = 328.8713 }
            };
        }
    }
    public class UpdateDataChartData
    {
        public string X;
        public double Y;
    }
}
