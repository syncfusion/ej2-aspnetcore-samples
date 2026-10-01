using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Chart
{
    public class MultiAxisCombinationModel : PageModel
    {
        public List<ClimateDataPoint>? ChartPoints { get; set; }

        public DateTime January2025 { get; } =
            new DateTime(2025, 1, 1);

        public DateTime May2025 { get; } =
            new DateTime(2025, 5, 1);

        public DateTime September2025 { get; } =
            new DateTime(2025, 9, 1);

        public void OnGet()
        {
            ChartPoints = new List<ClimateDataPoint>
            {
                new ClimateDataPoint
                {
                    Month = new DateTime(2025, 1, 1),
                    TemperatureAnomaly = 1.75,
                    AtmosphericCO2 = 426.65,
                    SeaIceExtent = 13.11
                },
                new ClimateDataPoint
                {
                    Month = new DateTime(2025, 2, 1),
                    TemperatureAnomaly = 1.59,
                    AtmosphericCO2 = 427.09,
                    SeaIceExtent = 14.26
                },
                new ClimateDataPoint
                {
                    Month = new DateTime(2025, 3, 1),
                    TemperatureAnomaly = 1.60,
                    AtmosphericCO2 = 428.15,
                    SeaIceExtent = 14.33
                },
                new ClimateDataPoint
                {
                    Month = new DateTime(2025, 4, 1),
                    TemperatureAnomaly = 1.51,
                    AtmosphericCO2 = 429.35,
                    SeaIceExtent = 13.73
                },
                new ClimateDataPoint
                {
                    Month = new DateTime(2025, 5, 1),
                    TemperatureAnomaly = 1.40,
                    AtmosphericCO2 = 430.51,
                    SeaIceExtent = 12.68
                },
                new ClimateDataPoint
                {
                    Month = new DateTime(2025, 6, 1),
                    TemperatureAnomaly = 1.42,
                    AtmosphericCO2 = 429.95,
                    SeaIceExtent = 10.82
                },
                new ClimateDataPoint
                {
                    Month = new DateTime(2025, 7, 1),
                    TemperatureAnomaly = 1.37,
                    AtmosphericCO2 = 427.87,
                    SeaIceExtent = 8.02
                },
                new ClimateDataPoint
                {
                    Month = new DateTime(2025, 8, 1),
                    TemperatureAnomaly = 1.39,
                    AtmosphericCO2 = 425.71,
                    SeaIceExtent = 5.92
                },
                new ClimateDataPoint
                {
                    Month = new DateTime(2025, 9, 1),
                    TemperatureAnomaly = 1.44,
                    AtmosphericCO2 = 424.82,
                    SeaIceExtent = 4.68
                },
                new ClimateDataPoint
                {
                    Month = new DateTime(2025, 10, 1),
                    TemperatureAnomaly = 1.48,
                    AtmosphericCO2 = 425.46,
                    SeaIceExtent = 6.08
                },
                new ClimateDataPoint
                {
                    Month = new DateTime(2025, 11, 1),
                    TemperatureAnomaly = 1.53,
                    AtmosphericCO2 = 426.98,
                    SeaIceExtent = 9.04
                },
                new ClimateDataPoint
                {
                    Month = new DateTime(2025, 12, 1),
                    TemperatureAnomaly = 1.55,
                    AtmosphericCO2 = 428.12,
                    SeaIceExtent = 11.83
                }
            };
        }
    }

    public class ClimateDataPoint
    {
        public DateTime Month { get; set; }

        public double TemperatureAnomaly { get; set; }

        public double AtmosphericCO2 { get; set; }

        public double SeaIceExtent { get; set; }
    }
}