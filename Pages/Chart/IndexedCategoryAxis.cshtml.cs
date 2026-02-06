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
    public class IndexedCategoryAxisModel : PageModel
    {
        public void OnGet()
        {
        }
        public List<IndexedCategoryAxisData> GDP_2015 = new List<IndexedCategoryAxisData>
        {
                new IndexedCategoryAxisData { Country = "India", GDPGrowthRate = 7.9 },
                new IndexedCategoryAxisData { Country = "Myanmar", GDPGrowthRate = 7.3 },
                new IndexedCategoryAxisData { Country = "Bangladesh", GDPGrowthRate = 6.0 },
                new IndexedCategoryAxisData { Country = "Cambodia", GDPGrowthRate = 7.0 },
                new IndexedCategoryAxisData { Country = "China", GDPGrowthRate = 6.9 }
        };

        public List<IndexedCategoryAxisData> GDP_2016 = new List<IndexedCategoryAxisData>
        {
                new IndexedCategoryAxisData { Country = "Australia", GDPGrowthRate = 2.5 },
                new IndexedCategoryAxisData { Country = "Poland", GDPGrowthRate = 2.7 },
                new IndexedCategoryAxisData { Country = "Singapore", GDPGrowthRate = 2.0 },
                new IndexedCategoryAxisData { Country = "Canada", GDPGrowthRate = 1.4 },
                new IndexedCategoryAxisData { Country = "Germany", GDPGrowthRate = 1.8 },
        };

    }
    public class IndexedCategoryAxisData
    {
        public string Country;
        public double GDPGrowthRate;
    }
}
