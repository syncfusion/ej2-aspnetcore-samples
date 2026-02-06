#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Chart
{
    public class StepLineModel : PageModel
    {
        public List<StepLineChartData> StepLineData { get; set; }

        public void OnGet()
        {
            StepLineData = new List<StepLineChartData>
            {
                new StepLineChartData { X = 2007, Y = 6.0, Album = "High School Musical 2", Artist = "Various Artists" },
                new StepLineChartData { X = 2007, Y = 6.0, Album = "High School Musical 2", Artist = "Various Artists" },
                new StepLineChartData { X = 2008, Y = 6.8, Album = "Viva la Vida or Death and All His Friends", Artist = "Coldplay" },
                new StepLineChartData { X = 2009, Y = 8.3, Album = "I Dreamed a Dream", Artist = "Susan Boyle" },
                new StepLineChartData { X = 2010, Y = 5.7, Album = "Recovery", Artist = "Eminem" },
                new StepLineChartData { X = 2011, Y = 18.1, Album = "21", Artist = "Adele" },
                new StepLineChartData { X = 2012, Y = 8.3, Album = "21", Artist = "Adele" },
                new StepLineChartData { X = 2013, Y = 4.0, Album = "Midnight Memories", Artist = "One Direction" },
                new StepLineChartData { X = 2014, Y = 10.0, Album = "Frozen", Artist = "Various Artists" },
                new StepLineChartData { X = 2015, Y = 17.4, Album = "25", Artist = "Adele" },
                new StepLineChartData { X = 2016, Y = 2.5, Album = "Lemonade", Artist = "Beyoncé" },
                new StepLineChartData { X = 2017, Y = 6.1, Album = "÷", Artist = "Ed Sheeran" },
                new StepLineChartData { X = 2018, Y = 3.5, Album = "The Greatest Showman", Artist = "Hugh Jackman & Various Artists" },
                new StepLineChartData { X = 2019, Y = 3.3, Album = "5x20 All the Best!! 1999–2019", Artist = "Arashi" },
                new StepLineChartData { X = 2020, Y = 4.8, Album = "Map of the Soul: 7", Artist = "BTS" },
                new StepLineChartData { X = 2021, Y = 4.68, Album = "30", Artist = "Adele" },
                new StepLineChartData { X = 2022, Y = 7.2, Album = "Greatest Works of Art", Artist = "Jay Chou" },
                new StepLineChartData { X = 2023, Y = 6.4, Album = "FML", Artist = "Seventeen" },
                new StepLineChartData { X = 2024, Y = 5.6, Album = "The Tortured Poets Department", Artist = "Taylor Swift" }
            };   
        }
    }
    public class StepLineChartData
    {
        public double X;
        public double Y;
        public string Artist;
        public string Album;
    }
}