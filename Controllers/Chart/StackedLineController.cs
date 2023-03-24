#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Charts;

namespace EJ2CoreSampleBrowser.Controllers.Chart
{
    public partial class ChartController : Controller
    {
        public IActionResult StackedLine()
        {
            List<StackedLineChartData> ChartPoints = new List<StackedLineChartData>
            {
                new StackedLineChartData { ExpensesCategory= "Jan", JohnExpenses= 90, PeterExpenses= 40, SteveExpenses= 70,  CharleExpenses= 120 },
                new StackedLineChartData { ExpensesCategory= "Feb", JohnExpenses= 80, PeterExpenses= 90, SteveExpenses= 110, CharleExpenses= 70  },
                new StackedLineChartData { ExpensesCategory= "Mar", JohnExpenses= 50, PeterExpenses= 80, SteveExpenses= 120, CharleExpenses= 50  },
                new StackedLineChartData { ExpensesCategory= "Apr", JohnExpenses= 70, PeterExpenses= 30, SteveExpenses= 60,  CharleExpenses= 180 },
                new StackedLineChartData { ExpensesCategory= "May", JohnExpenses= 30, PeterExpenses= 80, SteveExpenses= 80,  CharleExpenses= 30  },
                new StackedLineChartData { ExpensesCategory= "Jun", JohnExpenses= 10, PeterExpenses= 40, SteveExpenses= 30,  CharleExpenses= 270 },
                new StackedLineChartData { ExpensesCategory= "Jul", JohnExpenses= 100,PeterExpenses= 30, SteveExpenses= 70,  CharleExpenses= 40  },
                new StackedLineChartData { ExpensesCategory= "Aug", JohnExpenses= 55, PeterExpenses= 95, SteveExpenses= 55,  CharleExpenses= 75  },
                new StackedLineChartData { ExpensesCategory= "Sep", JohnExpenses= 20, PeterExpenses= 50, SteveExpenses= 40,  CharleExpenses= 65  },
                new StackedLineChartData { ExpensesCategory= "Oct", JohnExpenses= 40, PeterExpenses= 20, SteveExpenses= 80,  CharleExpenses= 95  },
                new StackedLineChartData { ExpensesCategory= "Nov", JohnExpenses= 45, PeterExpenses= 15, SteveExpenses= 45,  CharleExpenses= 195 },
                new StackedLineChartData { ExpensesCategory= "Dec", JohnExpenses= 75, PeterExpenses= 45, SteveExpenses= 65,  CharleExpenses= 115 }
            };
            ViewBag.ChartPoints = ChartPoints;
            return View();
        }

        public class StackedLineChartData
        {
            public string ExpensesCategory;
            public double JohnExpenses;
            public double PeterExpenses;
            public double SteveExpenses;
            public double CharleExpenses;
        }
    }
}
