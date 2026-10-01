using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace EJ2CoreSampleBrowser.Pages.Chart
{
    public class NestedDonutModel : PageModel
    {
        public List<RegionData>? RegionPoints { get; set; }
        public List<CountryData>? CountryPoints { get; set; }

        public void OnGet()
        {
            var regionColors = new Dictionary<string, string>
            {
                { "South Asia", "#1f4e8c" },
                { "Middle East", "#7a3b8f" },
                { "S.E. Asia", "#e91e63" },
                { "Africa", "#f4c20d" },
                { "Others", "#66a99c" }
            };

            RegionPoints = new List<RegionData>
            {
                new RegionData { X = "South Asia", Y = 55.85, Color = regionColors["South Asia"], Text = "South Asia" },
                new RegionData { X = "Middle East", Y = 16.15, Color = regionColors["Middle East"], Text = "Middle East" },
                new RegionData { X = "S.E. Asia", Y = 7.36, Color = regionColors["S.E. Asia"], Text = "S.E. Asia" },
                new RegionData { X = "Africa", Y = 11.25, Color = regionColors["Africa"], Text = "Africa" },
                new RegionData { X = "Others", Y = 9.39, Color = regionColors["Others"], Text = "Others" }
            };

            CountryPoints = new List<CountryData>
            {
                new CountryData { X = "India", Y = 21.8, Color = regionColors["South Asia"], Text = "India" },
                new CountryData { X = "Bangladesh", Y = 12.5, Color = regionColors["South Asia"], Text = "Bangladesh" },
                new CountryData { X = "Nepal", Y = 12.5, Color = regionColors["South Asia"], Text = "Nepal" },
                new CountryData { X = "Pakistan", Y = 4.7, Color = regionColors["South Asia"], Text = "Pakistan" },
                new CountryData { X = "Sri Lanka", Y = 4.35, Color = regionColors["South Asia"], Text = "Sri Lanka" },
                new CountryData { X = "Qatar", Y = 10.5, Color = regionColors["Middle East"], Text = "Qatar" },
                new CountryData { X = "Iran", Y = 1.0, Color = regionColors["Middle East"], Text = "Iran" },
                new CountryData { X = "Jordan", Y = 1.6, Color = regionColors["Middle East"], Text = "Jordan" },
                new CountryData { X = "Syria", Y = 1.8, Color = regionColors["Middle East"], Text = "Syria" },
                new CountryData { X = "Lebanon", Y = 1.25, Color = regionColors["Middle East"], Text = "Lebanon" },
                new CountryData { X = "Philippines", Y = 7.36, Color = regionColors["S.E. Asia"], Text = "Philippines" },
                new CountryData { X = "Sudan", Y = 1.9, Color = regionColors["Africa"], Text = "Sudan" },
                new CountryData { X = "Egypt", Y = 9.35, Color = regionColors["Africa"], Text = "Egypt" },
                new CountryData { X = "Others", Y = 9.39, Color = regionColors["Others"], Text = "Others" }
            };
        }
    }

    // ✅ Region Model
    public class RegionData
    {
        public string? X { get; set; }
        public double Y { get; set; }
        public string? Color { get; set; }
        public string? Text { get; set; }
    }

    // ✅ Country Model
    public class CountryData
    {
        public string? X { get; set; }
        public double Y { get; set; }
        public string? Color { get; set; }
        public string? Text { get; set; }
    }
}