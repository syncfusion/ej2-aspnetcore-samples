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
	public class AccumulationLegendTemplateModel : PageModel
	{
		public string Title { get; set; } = "Top 5 Oil Producing Countries (2023)";
		public string SubTitle { get; set; } = "Source: Wikipedia.org";
		public List<PieDataPointss> ChartPoints { get; set; }
		public void OnGet()
		{
			ChartPoints = new List<PieDataPointss>
			{
				new PieDataPointss { X = "United States", Y = 29.55, Text = "United States: 29.55%", Description = "13.4M barrels per day", Tooltip = "13.4M" },
				new PieDataPointss { X = "Saudi Arabia",  Y = 23.83, Text = "Saudi Arabia: 23.83%",  Description = "10.8M barrels per day", Tooltip = "10.8M" },
				new PieDataPointss { X = "Russia",        Y = 23.69, Text = "Russia: 23.69%",        Description = "10.8M barrels per day", Tooltip = "10.8M" },
				new PieDataPointss { X = "Canada",        Y = 12.12, Text = "Canada: 12.12%",        Description = "5.5M barrels per day",  Tooltip = "5.5M" },
				new PieDataPointss { X = "China",         Y = 10.83, Text = "China: 10.83%",         Description = "4.9M barrels per day",  Tooltip = "4.9M" }
			};
		}
	}
	public class PieDataPointss
	{
		public string X { get; set; }
		public double Y { get; set; }
		public string Text { get; set; }
		public string Description { get; set; }
		public string Tooltip { get; set; }
	}
}
