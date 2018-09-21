using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EJ2CoreSampleBrowser.Controllers
{
    public class DateValue
    {
        [Required(ErrorMessage = "Please enter the value")]
        public DateTime? value { get; set; }

    }
    public partial class DatePickerController : Controller
    {
        DateValue valueObject = new DateValue();
        public IActionResult DatePickerFor()
        {
            valueObject.value = new DateTime(2018, 03, 03);
            return View(valueObject);
        }
        [HttpPost]
        public IActionResult DatePickerFor(DateValue model)
        {
            //posted value is obtained from the model
            valueObject.value = model.value;
            return View(valueObject);
        }
    }

}