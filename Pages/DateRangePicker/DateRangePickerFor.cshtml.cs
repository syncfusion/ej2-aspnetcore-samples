#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.DateRangePicker
{
    public class DateRangePickerForModel : PageModel
    {
        [BindProperty]
        public DateRange DateRangeValue { get; set; }
        public DateTime[] DateValues = new DateTime[] { new DateTime(2020, 03, 03), new DateTime(2021, 09, 03) };
        public void OnGet()
        {
            DateRangeValue = new DateRange
            {
                value = DateValues
            };
        }

        public void OnPost()
        {
            if (DateRangeValue.value.Length == 0)
            {
                ModelState.AddModelError("DateRangeValue.value", "Please enter the value");
            }
            // if (DateRangeValue.value.Count().ToString() == "0")
            // {
            //     ModelState.AddModelError("DateRangeValue.value", "Please enter the value");
            // }
        }
    }

    public class DateRange
    {
        public DateTime[] value { get; set; }
    }
}
