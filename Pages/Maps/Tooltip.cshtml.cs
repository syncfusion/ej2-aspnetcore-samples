#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
namespace EJ2CoreSampleBrowser_NET8.Pages.Maps;

public class Tooltip : PageModel
{
    public object GetWorldMap()
    {
        string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/WorldMap.json");
        return JsonConvert.DeserializeObject(allText);
    }
    public object GetWorldcup()
    {
        string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/worldcup.js");
        return JsonConvert.DeserializeObject(allText);
    }

    public void OnGet()
    {
        
    }
}