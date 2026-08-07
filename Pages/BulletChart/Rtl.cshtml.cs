using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.BulletChart
{
    public class RtlModel : PageModel
    {
        public List<RtlData> BulletData1 { get; set; }
        public void OnGet()
        {
            BulletData1 = new List<RtlData>
            {
                new RtlData { Value = 270, Target = 250}
            };
        }
        
    }
    public class RtlData
    {
        public double Value;
        public double Target;
    }
}
