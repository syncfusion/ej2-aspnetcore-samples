using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.RichTextEditor;

public class Types : PageModel
{
    public List<Data> datasource = new List<Data>();
    public void OnGet()
    {
        datasource.Add(new Data() { text = "Expand", value = 1 });
        datasource.Add(new Data() { text = "MultiRow", value = 2 });
        datasource.Add(new Data() { text = "Scrollable", value = 3 });
        datasource.Add(new Data() { text = "Popup", value = 4 });
    }
}

public class Data
{
    public string text { get; set; }
    public int value { get; set; }
}