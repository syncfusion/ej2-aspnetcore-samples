using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.BulletChart
{
    public class CustomModel : PageModel
    {
        public List<CustomBulletData> BulletData1 { get; set; }
        public void OnGet()
        {
            BulletData1 = new List<CustomBulletData>
            {
                new CustomBulletData { Value = 1.7, Target = 2.5}
            };
        }
        
    }
    public class CustomBulletData
    {
        public double Value;
        public double Target;
    }
}
