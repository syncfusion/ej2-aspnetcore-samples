using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Controllers.Chips
{
    public partial class ChipsController : Controller
    {

        public IActionResult Api()
        {
            List<object> ddlData = new List<object>();
            ddlData.Add(new { text = "Default", id = "1" });
            ddlData.Add(new { text = "Primary", id = "2" });
            ddlData.Add(new { text = "Success", id = "3" });
            ddlData.Add(new { text = "Danger", id = "4" });
            ddlData.Add(new { text = "Warning", id = "5" });
            ddlData.Add(new { text = "Info", id = "6" });

            ViewBag.ddlData = ddlData;

            List<object> avatarData = new List<object>();
            avatarData.Add(new { text = "None", id = "1" });
            avatarData.Add(new { text = "Icon", id = "2" });
            avatarData.Add(new { text = "Image", id = "3" });
            avatarData.Add(new { text = "Letter", id = "4" });

            ViewBag.avatarData = avatarData;

            return View();
        }
    }
}