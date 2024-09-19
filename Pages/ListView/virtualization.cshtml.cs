#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser_NET8.Pages.ListView;

public class virtualization : PageModel
{
    public List<object> ddlData = new List<object>();
    
    public List<object> generateData(int no, IUrlHelper url)
    {
        List<object> commonData = new List<object>();
        commonData.Add(new { name = "Nancy", imgUrl = "", icon = "N", id = "0" });
        commonData.Add(new { name = "Andrew", imgUrl = "", icon = "A", id = "1" });
        commonData.Add(new { name = "Janet", imgUrl = "", icon = "J", id = "2" });
        commonData.Add(new { name = "Margaret", icon = "", imgUrl = url.Content("~/css/listview/images/margaret.png"), id = "3" });
        commonData.Add(new { name = "Steven", imgUrl = "", icon = "S", id = "4" });
        commonData.Add(new { name = "Laura", icon = "", imgUrl = url.Content("~/css/listview/images/laura.png"), id = "5" });
        commonData.Add(new { name = "Robert", imgUrl = "", icon = "R", id = "6" });
        commonData.Add(new { name = "Michael", imgUrl = "", icon = "M", id = "7" });
        commonData.Add(new { name = "Albert", icon = "", imgUrl = url.Content("~/css/listview/images/albert.png"), id = "8" });
        commonData.Add(new { name = "Nolan", imgUrl = "", icon = "N", id = "9" });
        
        int index = 0;
        int spyIndex = 0;
        List<object> data = new List<object>();
        for (int i = 0; i < no; i++)
        {
            while (index == spyIndex)
            {
                index = new Random().Next(0, 10);
            }
            data.Add(new
            {
                name = commonData[index].GetType().GetProperty("name").GetValue(commonData[index], null).ToString(),
                icon = commonData[index].GetType().GetProperty("icon").GetValue(commonData[index], null).ToString(),
                imgUrl = commonData[index].GetType().GetProperty("imgUrl").GetValue(commonData[index], null).ToString(),
                id = i.ToString()
            });
            spyIndex = index;
        }

        return data;
    }
    public void OnGet()
    {
        ddlData.Add(new { value = "1", text = "1k" });
        ddlData.Add(new { value = "5", text = "5k" });
        ddlData.Add(new { value = "10", text = "10k" });
        ddlData.Add(new { value = "25", text = "25k" });
    }
}