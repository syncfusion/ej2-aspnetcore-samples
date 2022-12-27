#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
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

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class SpreadsheetController : Controller
    {
        public IActionResult NumberFormatting()
        {
            List<object> numberFormatData = new List<object>()
            {
                new { ItemCode= "I231", ItemName= "Chinese Combo Noodle", Quantity= 2, Rate= 125, Amount= "=PRODUCT(C4,D4)" },
                new { ItemCode= "I245", ItemName= "Chinese Combo Rice", Quantity= 3, Rate= 125, Amount= "=PRODUCT(C5,D5)" },
                new { ItemCode= "I237", ItemName= "Amritsari Chola", Quantity= 2, Rate= 225, Amount= "=PRODUCT(C6,D6)" },
                new { ItemCode= "I291", ItemName= "Asian Mixed Entree Platt", Quantity= 3, Rate= 165, Amount= "=PRODUCT(C7,D7)" },
                new { ItemCode= "I268", ItemName= "Chinese Combo Chicken", Quantity= 3, Rate= 125, Amount= "=PRODUCT(C8,D8)" },
                new { ItemCode= "I251", ItemName= "Chivas Regal", Quantity= 1, Rate= 325, Amount= "=PRODUCT(C9,D9)" },
                new { ItemCode= "I256", ItemName= "Chicken Drumsticks", Quantity= 2, Rate= 180, Amount= "=PRODUCT(C10,D10)" },
                new { ItemCode= "I232", ItemName= "Manchow Soup", Quantity= 2, Rate= 160, Amount= "=PRODUCT(C11,D11)" },
                new { ItemCode= "I290", ItemName= "Schezuan Chicken", Quantity= 3, Rate= 180, Amount= "=PRODUCT(C12,D12)" },
                new { ItemCode= "I229", ItemName= "Manchow Soup", Quantity= 2, Rate= 125, Amount= "=PRODUCT(C13,D13)" },
                new { ItemCode= "I239", ItemName= "Jw Black Lable", Quantity= 2, Rate= 175, Amount= "=PRODUCT(C14,D14)" }
            };
            ViewBag.numberFormatData = numberFormatData;
            return View();
        }
    }
}