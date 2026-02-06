#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
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
