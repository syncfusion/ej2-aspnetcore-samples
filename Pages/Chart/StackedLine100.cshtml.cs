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
    public class StackedLine100Model : PageModel
    {
        public List<StackedLineChartData100> ChartPoints { get; set; }

        public void OnGet()
        {
            ChartPoints = new List<StackedLineChartData100>
            {
                new StackedLineChartData100 { ExpensesCategory= "Jan", JohnExpenses= 90, PeterExpenses= 40, SteveExpenses= 70,  CharleExpenses= 120 },
                new StackedLineChartData100 { ExpensesCategory= "Feb", JohnExpenses= 80, PeterExpenses= 90, SteveExpenses= 110, CharleExpenses= 70  },
                new StackedLineChartData100 { ExpensesCategory= "Mar", JohnExpenses= 50, PeterExpenses= 80, SteveExpenses= 120, CharleExpenses= 50  },
                new StackedLineChartData100 { ExpensesCategory= "Apr", JohnExpenses= 70, PeterExpenses= 30, SteveExpenses= 60,  CharleExpenses= 180 },
                new StackedLineChartData100 { ExpensesCategory= "May", JohnExpenses= 30, PeterExpenses= 80, SteveExpenses= 80,  CharleExpenses= 30  },
                new StackedLineChartData100 { ExpensesCategory= "Jun", JohnExpenses= 10, PeterExpenses= 110,SteveExpenses= 100, CharleExpenses= 270 },
                new StackedLineChartData100 { ExpensesCategory= "Jul", JohnExpenses= 100,PeterExpenses= 30, SteveExpenses= 70,  CharleExpenses= 40  },
                new StackedLineChartData100 { ExpensesCategory= "Aug", JohnExpenses= 55, PeterExpenses= 95, SteveExpenses= 55,  CharleExpenses= 75  },
                new StackedLineChartData100 { ExpensesCategory= "Sep", JohnExpenses= 20, PeterExpenses= 50, SteveExpenses= 40,  CharleExpenses= 65  },
                new StackedLineChartData100 { ExpensesCategory= "Oct", JohnExpenses= 40, PeterExpenses= 20, SteveExpenses= 80,  CharleExpenses= 95  },
                new StackedLineChartData100 { ExpensesCategory= "Nov", JohnExpenses= 45, PeterExpenses= 15, SteveExpenses= 45,  CharleExpenses= 195 },
                new StackedLineChartData100 { ExpensesCategory= "Dec", JohnExpenses= 75, PeterExpenses= 45, SteveExpenses= 65,  CharleExpenses= 115 }
            };
        }
    }
    public class StackedLineChartData100
    {
        public string ExpensesCategory;
        public double JohnExpenses;
        public double PeterExpenses;
        public double SteveExpenses;
        public double CharleExpenses;
    }
}