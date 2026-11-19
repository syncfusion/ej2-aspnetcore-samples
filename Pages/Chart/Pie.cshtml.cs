using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Chart
{
    public class PieModel : PageModel
    {
        public List<PieChartData> ChartPoints { get; set; }
        public void OnGet()
        {
            ChartPoints = new List<PieChartData>
            {
                new PieChartData { Browser= "Coal", Users= 34.4, DataLabelMappingName= "Coal: 34.4%" },
                new PieChartData { Browser= "Natural Gas", Users= 22.1, DataLabelMappingName= "Natural Gas: 22.1%" },
                new PieChartData { Browser= "Hydro", Users= 14.4, DataLabelMappingName= "Hydro: 14.4%" },
                new PieChartData { Browser= "Nuclear", Users= 9.0, DataLabelMappingName= "Nuclear: 9.0%" },
                new PieChartData { Browser= "Wind", Users= 8.1, DataLabelMappingName= "Wind: 8.1%" },
                new PieChartData { Browser= "Others", Users= 12.0, DataLabelMappingName= "Others: 12.0%" }
            };
        }
    }
    public class PieChartData
    {
        public string Browser;
        public double Users;
        public string DataLabelMappingName;
    }
    
}