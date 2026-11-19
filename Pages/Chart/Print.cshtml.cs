using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Chart
{
    public class PrintModel : PageModel
    {
        public List<PrintChartData> ChartPoints { get; set; }
        public void OnGet()
        {
            ChartPoints = new List<PrintChartData>
            {
                new PrintChartData { Manager = "John",  SalesInfo = 10, DataLabelMappingName = "$10k" },
                new PrintChartData { Manager = "Jake",  SalesInfo = 12, DataLabelMappingName = "$12k" },
                new PrintChartData { Manager = "Peter", SalesInfo = 18, DataLabelMappingName = "$18k" },
                new PrintChartData { Manager = "James", SalesInfo = 11, DataLabelMappingName = "$11k" },
                new PrintChartData { Manager = "Mary",  SalesInfo = 9.7, DataLabelMappingName = "$9.7k"  }
            };
        }
    }
    public class PrintChartData
    {
        public string Manager;
        public double SalesInfo;
        public string DataLabelMappingName;
    }
}