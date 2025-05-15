#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.MultiSelect;

public class GroupingWithCheckBox : PageModel
{
    public List<Vegetable> Veg = new List<Vegetable>();
    public void OnGet()
    {
        Veg.Add(new Vegetable { Vegetables = "Cabbage", Category= "Leafy and Salad", Id= "item1" });
        Veg.Add(new Vegetable { Vegetables = "Chickpea", Category= "Beans", Id= "item2" });
        Veg.Add(new Vegetable { Vegetables = "Garlic", Category= "Bulb and Stem", Id= "item3" });
        Veg.Add(new Vegetable { Vegetables = "Green bean", Category= "Beans", Id= "item4" });
        Veg.Add(new Vegetable { Vegetables = "Horse gram", Category= "Beans", Id= "item5" });
        Veg.Add(new Vegetable { Vegetables = "Nopal", Category= "Bulb and Stem", Id= "item6" });
        Veg.Add(new Vegetable { Vegetables = "Onion", Category= "Bulb and Stem", Id= "item7" });
        Veg.Add(new Vegetable { Vegetables = "Pumpkins", Category= "Leafy and Salad", Id= "item8" });
        Veg.Add(new Vegetable { Vegetables = "Spinach", Category= "Leafy and Salad", Id= "item9" });
        Veg.Add(new Vegetable { Vegetables = "Wheat grass", Category= "Leafy and Salad", Id= "item10" });
        Veg.Add(new Vegetable { Vegetables = "Yarrow", Category = "Leafy and Salad", Id = "item11" });
    }
}

public class Vegetable
{
    public string Vegetables { get; set; }
    public string Category { get; set; }
    public string Id { get; set; }
}