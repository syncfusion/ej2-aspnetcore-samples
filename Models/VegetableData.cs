using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EJ2CoreSampleBrowser.Models
{
    public class VegetableData
    {
        public string Vegetable { get; set; }
        public string Category { get; set; }
        public bool Status { get; set; }
        public List<VegetableData> VegetableDataList()
        {
            List<VegetableData> veg = new List<VegetableData>();
            veg.Add(new VegetableData { Vegetable = "Cabbage", Category = "Leafy and Salad", Status = true });
            veg.Add(new VegetableData { Vegetable = "Pumpkins", Category = "Leafy and Salad", Status = false });
            veg.Add(new VegetableData { Vegetable = "Spinach", Category = "Leafy and Salad", Status = true });
            veg.Add(new VegetableData { Vegetable = "Wheat grass", Category = "Leafy and Salad", Status = false });
            veg.Add(new VegetableData { Vegetable = "Yarrow", Category = "Leafy and Salad", Status = false });
            veg.Add(new VegetableData { Vegetable = "Chickpea", Category = "Beans", Status = true });
            veg.Add(new VegetableData { Vegetable = "Green bean", Category = "Beans", Status = false });
            veg.Add(new VegetableData { Vegetable = "Horse gram", Category = "Beans", Status = true });
            veg.Add(new VegetableData { Vegetable = "Garlic", Category = "Bulb and Stem", Status = false });
            veg.Add(new VegetableData { Vegetable = "Nopal", Category = "Bulb and Stem", Status = true });
            veg.Add(new VegetableData { Vegetable = "Onion", Category = "Bulb and Stem", Status = false });

            return veg;
        }
    }
}
