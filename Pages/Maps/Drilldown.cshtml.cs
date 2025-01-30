#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
namespace EJ2CoreSampleBrowser.Pages.Maps;

public class Drilldown : PageModel
{
    public object GetWorldMap()
    {
        string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/WorldMap.json");
        return JsonConvert.DeserializeObject(allText);
    }
    public object GetDefaultData()
    {
        string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/defaultdata.js");
        return JsonConvert.DeserializeObject(allText);
    }
    public object GetAsia()
    {
        string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/asia.json");
        return JsonConvert.DeserializeObject(allText);
    }
    public object GetNorthAmerica()
    {
        string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/northamerica.json");
        return JsonConvert.DeserializeObject(allText);
    }
    public object GetSouthAmerica()
    {
        string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/southamerica.json");
        return JsonConvert.DeserializeObject(allText);
    }
    public object GetOceania()
    {
        string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/oceania.json");
        return JsonConvert.DeserializeObject(allText);
    }
    public object GetEurope()
    {
        string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/europe.json");
        return JsonConvert.DeserializeObject(allText);
    }
    public object GetAfrica()
    {
        string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/africa.js");
        return JsonConvert.DeserializeObject(allText);
    }
    public void OnGet()
    {
        
    }
}