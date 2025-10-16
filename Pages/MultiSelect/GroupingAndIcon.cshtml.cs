#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.MultiSelect;

public class GroupingAndIcon : PageModel
{
    public List<Vegetables> Veg = new List<Vegetables>();
    public void OnGet()
    {
        Veg.Add(new Vegetables { Vegetable = "Cabbage", Category= "Leafy and Salad", Id= "item1" });
        Veg.Add(new Vegetables { Vegetable = "Chickpea", Category= "Beans", Id= "item2" });
        Veg.Add(new Vegetables { Vegetable = "Garlic", Category= "Bulb and Stem", Id= "item3" });
        Veg.Add(new Vegetables { Vegetable = "Green bean", Category= "Beans", Id= "item4" });
        Veg.Add(new Vegetables { Vegetable = "Horse gram", Category= "Beans", Id= "item5" });
        Veg.Add(new Vegetables { Vegetable = "Nopal", Category= "Bulb and Stem", Id= "item6" });
        Veg.Add(new Vegetables { Vegetable = "Onion", Category= "Bulb and Stem", Id= "item7" });
        Veg.Add(new Vegetables { Vegetable = "Pumpkins", Category= "Leafy and Salad", Id= "item8" });
        Veg.Add(new Vegetables { Vegetable = "Spinach", Category= "Leafy and Salad", Id= "item9" });
        Veg.Add(new Vegetables { Vegetable = "Wheat grass", Category= "Leafy and Salad", Id= "item10" });
        Veg.Add(new Vegetables { Vegetable = "Yarrow", Category = "Leafy and Salad", Id = "item11" });
    }
}
public class Vegetables
{
    public string Vegetable { get; set; }
    public string Category { get; set; }
    public string Id { get; set; }
}