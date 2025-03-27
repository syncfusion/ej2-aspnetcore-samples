#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.DatePicker
{
    public class DatePickerForModel : PageModel
    {
        [BindProperty]
        public DateValue valueObject { get; set; }

        public DateTime DateValues = new DateTime(2018, 03, 03);
        public void OnGet()
        {
            valueObject = new DateValue
            {
                value = DateValues
            };
        }

        public void OnPost()
        {
            if (valueObject.value == null)
            {
                ModelState.AddModelError("valueObject.value", "Please enter a value");
            }
        }
    }
    public class DateValue
    {
        public DateTime? value { get; set; }

    }
}
