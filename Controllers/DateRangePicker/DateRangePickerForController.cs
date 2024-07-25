#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EJ2CoreSampleBrowser.Controllers
{
    public class DateRange
    {
        [Required(ErrorMessage = "Please enter the value")]
        public DateTime[] value { get; set; }

    }
    public partial class DateRangePickerController : Controller
    {
        DateRange DateRangeValue = new DateRange();
        public IActionResult DateRangePickerFor()
        {   
            DateRangeValue.value = new DateTime[] { new DateTime(2020, 03, 03), new DateTime(2021, 09, 03) };
            return View(DateRangeValue);
        }
        [HttpPost]
        public IActionResult DateRangePickerFor(DateRange model)
        {
            //posted value is obtained from the model
            DateRangeValue.value = model.value;
            return View(DateRangeValue);
        }
    }

}