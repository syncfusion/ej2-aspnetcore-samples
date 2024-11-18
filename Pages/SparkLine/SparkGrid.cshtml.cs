#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace EJ2CoreSampleBrowser.Pages.SparkLine;

public class SparkGridModel : PageModel
{
    public object DataSource { get; set; }
    
    public void OnGet()
    {
        DataSource = this.getDataSource("OrderData");
    }
    public object getDataSource(string filename)
    {
        string allText = System.IO.File.ReadAllText("./wwwroot/scripts/SparkLine/" + filename + ".js");
        return JsonConvert.DeserializeObject(allText);
    }
}
