using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.BulletChart
{
    public class DotModel : PageModel
    {
        public List<DotBulletData> BulletData1 { get; set; }
        public string[] Data { get; set; }
        public void OnGet()
        {
            BulletData1 = new List<DotBulletData>
            {
                new DotBulletData { Value = 270, Target = 250}
            };
            Data = new string[] { "Rect", "Dot" };
        }
        
    }
    public class DotBulletData
    {
        public double Value;
        public double Target;
    }
}
