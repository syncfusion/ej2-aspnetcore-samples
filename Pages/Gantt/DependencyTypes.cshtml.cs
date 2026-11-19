using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace EJ2CoreSampleBrowser.Pages.Gantt
{
    public class DependencyTypesModel : PageModel
    {
        public List<object> DependencyTypes { get; set; }

        public string[] DefaultValues { get; set; }

        public void OnGet()
        {
            DependencyTypes = new List<object>()
            {
                new
                {
                    Text = "Finish to Start (FS)",
                    Value = "FS"
                },
                new
                {
                    Text = "Start to Start (SS)",
                    Value = "SS"
                },
                new
                {
                    Text = "Finish to Finish (FF)",
                    Value = "FF"
                },
                new
                {
                    Text = "Start to Finish (SF)",
                    Value = "SF"
                }
            };

            DefaultValues = new string[]
            {
                "FS",
                "SS",
                "FF",
                "SF"
            };
        }
    }
}