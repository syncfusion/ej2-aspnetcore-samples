using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Chart
{
    public class CylindricalColumnModel : PageModel
    {
        public List<CylindricalColumnChartData> ChartPoints { get; set; }
        public void OnGet()
        {
            ChartPoints = new List<CylindricalColumnChartData>
            {
                new CylindricalColumnChartData { Year = "2017 - 18", Energy = 228.0 },
                new CylindricalColumnChartData { Year = "2018 - 19", Energy = 261.8 },
                new CylindricalColumnChartData { Year = "2019 - 20", Energy = 294.3 },
                new CylindricalColumnChartData { Year = "2020 - 21", Energy = 297.5 },
                new CylindricalColumnChartData { Year = "2021 - 22", Energy = 322.6 },
                new CylindricalColumnChartData { Year = "2022 - 23", Energy = 365.59 },
            };
        }
    }
    public class CylindricalColumnChartData
    {
        public string Year;
        public double Energy;
    }
}
