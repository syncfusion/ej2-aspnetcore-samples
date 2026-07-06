using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.BulletChart
{
    public class TooltipModel : PageModel
    {
        public List<TooltipData> BulletData1 { get; set; }
        public void OnGet()
        {
            BulletData1 = new List<TooltipData>
            {
                new TooltipData { Value = 70, Target = 50}
            };
        }
        
    }
    public class TooltipData
    {
        public double Value;
        public double Target;
    }
}