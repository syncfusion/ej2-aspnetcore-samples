using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.DateTimePicker
{
    public class DateTimePickerForModel : PageModel
    {
        [BindProperty]
        public DateTimeValue valueObject { get; set; }

        public DateTime Datevalues = new DateTime(2018, 03, 03);
        public void OnGet()
        {
            valueObject = new DateTimeValue
            {
                value = Datevalues
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
    public class DateTimeValue
    {
        public DateTime? value { get; set; }
    }
}
