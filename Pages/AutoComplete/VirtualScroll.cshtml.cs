#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.AutoComplete;

public class VirtualScroll : PageModel
{
    public void OnGet()
    {
        
    }
}
public class AutoCompleteRecords
{
    public string ID { get; set; }
    public string Text { get; set; }
    public string Group { get; set; }
    public List<AutoCompleteRecords> RecordList { set; get; }
    public List<AutoCompleteRecords> RecordModelList()
    {
        Random random = new Random();
        return Enumerable.Range(1, 150).Select(i => new AutoCompleteRecords()
        {
            ID = i.ToString(),
            Text = "Item " + i,
            Group = GetRandomGroup(random),
        }).ToList();
    }
    public string GetRandomGroup(Random random)
    {
        // Generate a random number between 1 and 4 to determine the group
        int randomGroup = random.Next(1, 5);
        switch (randomGroup)
        {
            case 1:
                return "Group A";
            case 2:
                return "Group B";
            case 3:
                return "Group C";
            case 4:
                return "Group D";
            default:
                return string.Empty;
        }
    }
}