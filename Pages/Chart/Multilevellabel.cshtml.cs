using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Chart
{
    public class MultilevellabelModel : PageModel
    {
        public List<MultiLevelLabelsData> ChartPoints { get; set; }
        public void OnGet()
        {
            ChartPoints = new List<MultiLevelLabelsData>
            {
                new MultiLevelLabelsData { Fruits = "Grapes",  Sales = 28 },
                new MultiLevelLabelsData { Fruits = "Apples",  Sales = 87 },
                new MultiLevelLabelsData { Fruits = "Pears",   Sales = 42 },
                new MultiLevelLabelsData { Fruits = "Grapes",  Sales = 13 },
                new MultiLevelLabelsData { Fruits = "Apples",  Sales = 13 },
                new MultiLevelLabelsData { Fruits = "Pears",   Sales = 10 },
                new MultiLevelLabelsData { Fruits = "Tomato",  Sales = 31 },
                new MultiLevelLabelsData { Fruits = "Potato",  Sales = 96 },
                new MultiLevelLabelsData { Fruits = "Cucumber",Sales = 41 },
                new MultiLevelLabelsData { Fruits = "Onion",   Sales = 59 }
            };
        }
    }
    public class MultiLevelLabelsData
    {
        public string Fruits;
        public double Sales;
    }
}
