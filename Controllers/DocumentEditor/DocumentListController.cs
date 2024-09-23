using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Controllers {
    public partial class DocumentEditorController : Controller
    {
        public ActionResult DocumentList()
        {
            List < object > exportItems = new List<object>();
            exportItems.Add(new { text = "Syncfusion Document Text (*.sfdt)", id = "sfdt" });
            exportItems.Add(new { text = "Word Document (*.docx)", id = "word" });
            exportItems.Add(new { text = "Word Template (*.dotx)", id = "dotx" });
            exportItems.Add(new { text = "Plain Text (*.txt)", id = "txt" });
            ViewBag.ExportItems = exportItems;
            return View();
        }        
    }
    public class UserModel
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
