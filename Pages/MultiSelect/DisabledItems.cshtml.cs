#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.MultiSelect;

public class DisabledItems : PageModel
{
    public List<VegetablesData> veg = new List<VegetablesData>();
    public List<Tag> tag = new List<Tag>();
    public void OnGet()
    {
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
        
        tag.Add(new Tag() { ID = "Item1", Text = "Add to KB", State= false });
        tag.Add(new Tag() { ID = "Item2", Text = "Crisis", State= false });
        tag.Add(new Tag() { ID = "Item3", Text = "Enhancement", State= true });
        tag.Add(new Tag() { ID = "Item4", Text = "Pre-Sale", State= false });
        tag.Add(new Tag() { ID = "Item5", Text = "Needs Approval", State= false });
        tag.Add(new Tag() { ID = "Item6", Text = "Approved", State= true });
        tag.Add(new Tag() { ID = "Item7", Text = "Internal Issue", State= true });
        tag.Add(new Tag() { ID = "Item8", Text = "Breaking Issue", State= false });
        tag.Add(new Tag() { ID = "Item9", Text = "New Feature", State= true });
        tag.Add(new Tag() { ID = "Item10", Text = "New Component", State= false });
        tag.Add(new Tag() { ID = "Item11", Text = "Mobile Issue", State= false });
    }
}
public class VegetablesData
{
    public string Vegetable { get; set; }
    public string Category { get; set; }
    public string ID { get; set; }
    public bool Status { get; set; }
}

public class Tag
{
    public string ID { get; set; }
    public string Text { get; set; }
    public bool State { get; set; }
}