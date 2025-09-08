#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Popups;
using EJ2CoreSampleBrowser.Models;
using Syncfusion.EJ2.Navigations;
using System.ComponentModel.DataAnnotations;

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class PdfViewerController : Controller
    {
        // GET: DefaultFunctionalities
        public IActionResult DocumentList()
        {
            return View();
        }
    }
    public class UserModels
    {
        [Required(ErrorMessage = "UserName is Required.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Date of Birth is Required")]
        public DateTime? DOB { get; set; }

        [Required(ErrorMessage = "Addresss is Required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "City is Required")]
        public string City { get; set; }

        [Required(ErrorMessage = "State is Required")]
        public string State { get; set; }
    }
}