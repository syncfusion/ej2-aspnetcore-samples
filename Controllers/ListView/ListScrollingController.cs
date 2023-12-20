#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
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
using Syncfusion.EJ2.Navigations;

namespace EJ2CoreSampleBrowser.Controllers.ListView
{
    public partial class ListViewController : Controller
    {

        public IActionResult ListScrolling()
        {
            List<object> foodData = new List<object>();
            foodData.Add(new { text = "Hamburger", id = "list-01", price = "$10", src = Url.Content("~/css/listview/images/hamburger.jpg"), type = "non-veg", description = "A patty of ground beef grilled and placed between two halves of a bun with slices of lettuce and mayonnaise", rating = 3 });
            foodData.Add(new { text = "Cheeseburger", id = "list-02", price = "$12", src = Url.Content("~/css/listview/images/cheeseburger.jpg"), type = "veg", description = "A hamburger with a slice of melted cheese on top of the meat patty, added near the end of the cooking time", rating = 4 });
            foodData.Add(new { text = "Sandwich", id = "list-03", price = "$8", src = Url.Content("~/css/listview/images/sandwich.jpg"), type = "veg", description = "A combination of vegetables, sliced cheese or meat, placed on or between slices of bread with a layer of ingredients", rating = 5 });
            foodData.Add(new { text = "Milkshake", id = "list-04", price = "$6", src = Url.Content("~/css/listview/images/milkshake.jpg"), type = "veg", description = "A sweet beverage made by blending milk, ice cream, and flavorings or fruit syrup into a thick, sweet, cold mixture", rating = 3 });
            foodData.Add(new { text = "Muffin", id = "list-05", price = "$11", src = Url.Content("~/css/listview/images/muffin.jpg"), type = "veg", description = "Muffins are single-serving quick breads, which rise with the help of baking soda or baking powder and eggs instead of yeast", rating = 4 });
            foodData.Add(new { text = "Pizza", id = "list-06", price = "$22", src = Url.Content("~/css/listview/images/pizza.jpg"), type = "veg", description = "A combination of a flattened disk of bread dough with olive oil, oregano, tomato, mozzarella cheese", rating = 3 });
            foodData.Add(new { text = "Onion ring", id = "list-07", price = "$10", src = Url.Content("~/css/listview/images/onionrings.jpg"), type = "veg", description = "Consists of a cross-sectional 'ring' of onion dipped in bread crumbs and then deep-fried; variant is made with onion paste.", rating = 4 });
            foodData.Add(new { text = "Sausage", id = "list-08", price = "$15", src = Url.Content("~/css/listview/images/sausage.jpg"), type = "veg", description = "Sausage is a combination of minced/ground meat, a binder, water and seasonings, mild but strongly spiced", rating = 5 });
            foodData.Add(new { text = "Pretzel", id = "list-09", price = "$25", src = Url.Content("~/css/listview/images/pretzel.jpg"), type = "veg", description = "Made from a rope of dough, the pretzel is briefly boiled and then glazed with egg, salted, and baked", rating = 3 });
            foodData.Add(new { text = "Pancake", id = "list-10", price = "$23", src = Url.Content("~/css/listview/images/pancake.jpg"), type = "veg", description = "A combination of eggs, milk on a hot surface such as a griddle or frying pan, often frying with oil or butter", rating = 4 });
            ViewBag.foodData = foodData;
            return View();
        }
    }
}