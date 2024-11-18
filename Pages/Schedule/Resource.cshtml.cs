#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Schedule;

public class Resource : PageModel
{
    public List<OwnerRes> ownerCollections = new List<OwnerRes>();
    public void OnGet()
    {
        ownerCollections.Add(new OwnerRes { OwnerText= "Margaret", OwnerId= 1, Color= "#ea7a57" });
        ownerCollections.Add(new OwnerRes { OwnerText= "Robert", OwnerId= 2, Color= "#df5286" });
        ownerCollections.Add(new OwnerRes { OwnerText= "Laura", OwnerId= 3, Color= "#865fcf" });
    }
}
public class OwnerRes
{
    public string OwnerText { set; get; }
    public int OwnerId { set; get; }
    public string Color { set; get; }
}