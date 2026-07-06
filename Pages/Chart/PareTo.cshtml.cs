using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Chart
{
    public class PareToModel : PageModel
    {
        public List<PareToData> ChartPoints { get; set; }
        public void OnGet()
        {
            ChartPoints = new List<PareToData>
            {
                new PareToData { DefectCategory = "Button Defect", Y = 23 },
                new PareToData { DefectCategory = "Pocket Defect", Y = 16 },
                new PareToData { DefectCategory = "Collar Defect", Y = 10 },
                new PareToData { DefectCategory = "Cuff Defect", Y = 7 },
                new PareToData { DefectCategory = "Sleeve Defect", Y = 6 },
                new PareToData { DefectCategory = "Other Defect", Y = 2 }
            };
        }
    }
    public class PareToData
    {
        public string DefectCategory;
        public double Y;
    }
}