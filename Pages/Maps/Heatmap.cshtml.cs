#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
namespace EJ2CoreSampleBrowser.Pages.Maps;

public class Heatmap : PageModel
{
    public object GetIndiaData()
    {
        string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/india.json");
        return JsonConvert.DeserializeObject(allText);
    }
    public object GetIndianPopulation()
    {
        string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/indianpopulation.js");
        return JsonConvert.DeserializeObject(allText);
    }
    public void OnGet()
    {
        
    }
}