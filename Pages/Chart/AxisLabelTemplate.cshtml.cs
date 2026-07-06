using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace EJ2CoreSampleBrowser.Pages.Chart
{
    public class AxisLabelTemplateModel : PageModel
    {
        public List<CountryGame> OlympicsGoldData { get; set; }
        public List<CountryGame> OlympicsSilverData { get; set; }
        public List<CountryGame> OlympicsBronzeData { get; set; }

        public void OnGet()
        {
            // Build C# lists matching your CountryGame model
            OlympicsGoldData = new List<CountryGame>
            {
                new CountryGame { Country = "USA",            Count = 40 },
                new CountryGame { Country = "China",          Count = 40 },
                new CountryGame { Country = "Great Britain",  Count = 14 },
                new CountryGame { Country = "France",         Count = 16 },
                new CountryGame { Country = "Australia",      Count = 18 },
                new CountryGame { Country = "Japan",          Count = 20 },
                new CountryGame { Country = "Italy",          Count = 12 },
                new CountryGame { Country = "Netherlands",    Count = 15 },
                new CountryGame { Country = "Germany",        Count = 12 },
                new CountryGame { Country = "South Korea",    Count = 13 }
            };

            OlympicsSilverData = new List<CountryGame>
            {
                new CountryGame { Country = "USA",            Count = 44 },
                new CountryGame { Country = "China",          Count = 27 },
                new CountryGame { Country = "Great Britain",  Count = 22 },
                new CountryGame { Country = "France",         Count = 26 },
                new CountryGame { Country = "Australia",      Count = 19 },
                new CountryGame { Country = "Japan",          Count = 12 },
                new CountryGame { Country = "Italy",          Count = 13 },
                new CountryGame { Country = "Netherlands",    Count = 7 },
                new CountryGame { Country = "Germany",        Count = 13 },
                new CountryGame { Country = "South Korea",    Count = 9 }
            };

            OlympicsBronzeData = new List<CountryGame>
            {
                new CountryGame { Country = "USA",            Count = 42 },
                new CountryGame { Country = "China",          Count = 24 },
                new CountryGame { Country = "Great Britain",  Count = 29 },
                new CountryGame { Country = "France",         Count = 22 },
                new CountryGame { Country = "Australia",      Count = 16 },
                new CountryGame { Country = "Japan",          Count = 13 },
                new CountryGame { Country = "Italy",          Count = 15 },
                new CountryGame { Country = "Netherlands",    Count = 12 },
                new CountryGame { Country = "Germany",        Count = 8 },
                new CountryGame { Country = "South Korea",    Count = 10 }
            };
        }
    }

    public class CountryGame
    {
        public string Country { get; set; }
        public double Count { get; set; }
    }
}