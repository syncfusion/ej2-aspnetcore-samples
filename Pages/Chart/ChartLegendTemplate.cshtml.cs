using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.EJ2.Charts;
using System.Collections.Generic;

namespace EJ2CoreSampleBrowser.Pages.Chart
{
    public class ChartLegendTemplateModel : PageModel
    {
        public string Title { get; set; } = "All-Time Summer Olympic Medal Count by Country";
        public string SubTitle { get; set; } = "Source: Wikipedia.org";
        public List<MedalData> MedalData { get; set; }

        public void OnGet()
        {
            MedalData = new List<MedalData>
            {
                new MedalData { Country = "Argentina", Gold = 22, Silver = 27, Bronze = 31 },
                new MedalData { Country = "Austria",   Gold = 22, Silver = 35, Bronze = 44 },
                new MedalData { Country = "Ethiopia",  Gold = 24, Silver = 16, Bronze = 22 },
                new MedalData { Country = "Iran",      Gold = 27, Silver = 29, Bronze = 32 },
                new MedalData { Country = "India",     Gold = 10, Silver = 10, Bronze = 21 }
            };
        }
    }

    public class MedalData
    {
        public string Country { get; set; }
        public int Gold { get; set; }
        public int Silver { get; set; }
        public int Bronze { get; set; }
    }
}