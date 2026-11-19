using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.TimePicker
{
    public class TimePickerForModel : PageModel
    {
        [BindProperty]
        public TimeValue valueObject { get; set; }

        public DateTime TimeValues = new DateTime(2018, 03, 03, 10, 30, 30);
        public void OnGet()
        {
            valueObject = new TimeValue
            {
                value = TimeValues
            };
        }
        public void OnPost()
        {
            if (valueObject.value==null)
            {
                ModelState.AddModelError("valueObject.value", "Please enter the value");
            }
        }
    }
    public class TimeValue
    {
        public DateTime? value { get; set; }
    }
}
