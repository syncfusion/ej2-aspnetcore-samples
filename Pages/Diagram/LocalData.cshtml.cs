#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Diagram;

public class LocalDataModel : PageModel
{
    public List<LocalDataDetails> localData { get; set; }
    public void OnGet()
    {
        localData = new List<LocalDataDetails>();
        localData.Add(new LocalDataDetails("Species", ""));
        localData.Add(new LocalDataDetails("Plants", "Species"));
        localData.Add(new LocalDataDetails("Fungi", "Species"));
        localData.Add(new LocalDataDetails("Lichens", "Species"));
        localData.Add(new LocalDataDetails("Animals", "Species"));
        localData.Add(new LocalDataDetails("Mosses", "Plants"));
        localData.Add(new LocalDataDetails("Ferns", "Plants"));
        localData.Add(new LocalDataDetails("Gymnosperms", "Plants"));
        localData.Add(new LocalDataDetails("Dicotyledens", "Plants"));
        localData.Add(new LocalDataDetails("Monocotyledens", "Plants"));
        localData.Add(new LocalDataDetails("Invertebrates", "Animals"));
        localData.Add(new LocalDataDetails("Vertebrates", "Animals"));
        localData.Add(new LocalDataDetails("Insects", "Invertebrates"));
        localData.Add(new LocalDataDetails("Molluscs", "Invertebrates"));
        localData.Add(new LocalDataDetails("Crustaceans", "Invertebrates"));
        localData.Add(new LocalDataDetails("Others", "Invertebrates"));
        localData.Add(new LocalDataDetails("Fish", "Vertebrates"));
        localData.Add(new LocalDataDetails("Amphibians", "Vertebrates"));
        localData.Add(new LocalDataDetails("Reptiles", "Vertebrates"));
        localData.Add(new LocalDataDetails("Birds", "Vertebrates"));
        localData.Add(new LocalDataDetails("Mammals", "Vertebrates"));
    }
}
public class LocalDataDetails
{
    public string Name { get; set; }
    public string Category { get; set; }
        

    public LocalDataDetails(string id, string category)
    {
        this.Name = id;
        this.Category = category;            
    }
}