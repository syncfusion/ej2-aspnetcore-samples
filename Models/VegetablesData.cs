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
    public class VegetablesData
    {
        public string Vegetable { get; set; }
        public string Category { get; set; }
        public string ID { get; set; }
        public bool Status { get; set; }
        public List<VegetablesData> VegetablesDataList()
        {
            List<VegetablesData> veg = new List<VegetablesData>();
            veg.Add(new VegetablesData { Vegetable = "Cabbage", Category = "Leafy and Salad", ID = "item1", Status = true });
            veg.Add(new VegetablesData { Vegetable = "Pumpkins", Category = "Leafy and Salad", ID = "item2", Status = false });
            veg.Add(new VegetablesData { Vegetable = "Spinach", Category = "Leafy and Salad", ID = "item3", Status = true });
            veg.Add(new VegetablesData { Vegetable = "Wheat grass", Category = "Leafy and Salad", ID = "item4", Status = false });
            veg.Add(new VegetablesData { Vegetable = "Yarrow", Category = "Leafy and Salad", ID = "item5", Status = false });
            veg.Add(new VegetablesData { Vegetable = "Chickpea", Category = "Beans", ID = "item6", Status = true });
            veg.Add(new VegetablesData { Vegetable = "Green bean", Category = "Beans", ID = "item7", Status = false });
            veg.Add(new VegetablesData { Vegetable = "Horse gram", Category = "Beans", ID = "item8", Status = true });
            veg.Add(new VegetablesData { Vegetable = "Garlic", Category = "Bulb and Stem", ID = "item9", Status = false });
            veg.Add(new VegetablesData { Vegetable = "Nopal", Category = "Bulb and Stem", ID = "item10", Status = true });
            veg.Add(new VegetablesData { Vegetable = "Onion", Category = "Bulb and Stem", ID = "item11", Status = false });

            return veg;
        }
    }
}
