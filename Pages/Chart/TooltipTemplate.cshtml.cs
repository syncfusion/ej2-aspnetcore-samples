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
    public class TooltipTemplateModel : PageModel
    {
        public List<TooltipTemplateData> ConsumerDetails { get; set; }

        public void OnGet()
        {
            ConsumerDetails = new List<TooltipTemplateData>
            {
                new TooltipTemplateData { Year = 2002, Productivity = 1.61 },
                new TooltipTemplateData { Year = 2003, Productivity = 2.34 },
                new TooltipTemplateData { Year = 2004, Productivity = 2.16 },
                new TooltipTemplateData { Year = 2005, Productivity = 2.10 },
                new TooltipTemplateData { Year = 2006, Productivity = 1.81 },
                new TooltipTemplateData { Year = 2007, Productivity = 2.05 },
                new TooltipTemplateData { Year = 2008, Productivity = 2.50 },
                new TooltipTemplateData { Year = 2009, Productivity = 2.22 },
                new TooltipTemplateData { Year = 2010, Productivity = 2.21 },
                new TooltipTemplateData { Year = 2011, Productivity = 2.00 },
                new TooltipTemplateData { Year = 2012, Productivity = 1.70 }
            };
        }
    }
    public class TooltipTemplateData
    {
        public double Year;
        public double Productivity;
    }
}