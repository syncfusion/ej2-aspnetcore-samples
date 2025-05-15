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
    public class StackedLine100Model : PageModel
    {
        public List<StackedLineChartData100> ChartPoints { get; set; }

        public void OnGet()
        {
            ChartPoints = new List<StackedLineChartData100>
            {
                new StackedLineChartData100 { X= "O+ve",  Y= 39.0, Y1= 40.0, Y2= 47.0, Y3= 29.0 },
                new StackedLineChartData100 { X= "A+ve",  Y= 36.0, Y1= 30.0, Y2= 26.0, Y3= 46.3 },
                new StackedLineChartData100 { X= "B+ve",  Y= 7.6 , Y1= 15.0, Y2= 9.0 , Y3= 12.0 },
                new StackedLineChartData100 { X= "AB+ve", Y= 2.5 , Y1= 4.25, Y2= 2.0 , Y3= 5.6  },
                new StackedLineChartData100 { X= "O-ve",  Y= 7.0 , Y1= 6.6 , Y2= 8.0 , Y3= 2.0  },
                new StackedLineChartData100 { X= "A-ve",  Y= 6.0 , Y1= 2.3 , Y2= 5.0 , Y3= 3.7  },
                new StackedLineChartData100 { X= "B-ve",  Y= 1.4 , Y1= 1.1 , Y2= 2.0 , Y3= 1.0  },
                new StackedLineChartData100 { X= "AB-ve", Y= 0.5 , Y1= 0.75, Y2= 1.0 , Y3= 0.4  },
            };
        }
    }
    public class StackedLineChartData100
    {
        public string X;
        public double Y;
        public double Y1;
        public double Y2;
        public double Y3;
    }
}