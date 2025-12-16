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
using System.Threading.Tasks;

namespace EJ2CoreSampleBrowser.Models
{
    public class Vegetables
    {
        public string Vegetable { get; set; }
        public string Category { get; set; }
        public string Id { get; set; }
        public List<Vegetables> VegetablesList()
        {
            List<Vegetables> veg = new List<Vegetables>();
        veg.Add(new Vegetables { Vegetable = "Cabbage", Category= "Leafy and Salad", Id= "item1" });
        veg.Add(new Vegetables { Vegetable = "Chickpea", Category= "Beans", Id= "item2" });
        veg.Add(new Vegetables { Vegetable = "Garlic", Category= "Bulb and Stem", Id= "item3" });
        veg.Add(new Vegetables { Vegetable = "Green bean", Category= "Beans", Id= "item4" });
        veg.Add(new Vegetables { Vegetable = "Horse gram", Category= "Beans", Id= "item5" });
        veg.Add(new Vegetables { Vegetable = "Nopal", Category= "Bulb and Stem", Id= "item6" });
        veg.Add(new Vegetables { Vegetable = "Onion", Category= "Bulb and Stem", Id= "item7" });
        veg.Add(new Vegetables { Vegetable = "Pumpkins", Category= "Leafy and Salad", Id= "item8" });
        veg.Add(new Vegetables { Vegetable = "Spinach", Category= "Leafy and Salad", Id= "item9" });
        veg.Add(new Vegetables { Vegetable = "Wheat grass", Category= "Leafy and Salad", Id= "item10" });
            veg.Add(new Vegetables { Vegetable = "Yarrow", Category = "Leafy and Salad", Id = "item11" });
         return veg;
        }
    }
}
