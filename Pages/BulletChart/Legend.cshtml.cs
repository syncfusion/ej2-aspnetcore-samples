using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.BulletChart
{
    public class LegendModel : PageModel
    {
        public List<LegendData> BulletData1 { get; set; }
        public void OnGet()
        {
            BulletData1 = new List<LegendData>
            {
                new LegendData { Value = 25, Target = new double[]{ 20, 26, 28 } }
            };
        }
        
    }
    public class LegendData
    {
        public double Value;
        public double[] Target;
    }
}
