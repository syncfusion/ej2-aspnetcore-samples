using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.AutoComplete;

public class AutoCompleteValue
{
    public string val { get; set; }
    public string[] data { get; set; }
}
public class AutoCompleteFor : PageModel
{
    [BindProperty]
    public AutoCompleteValue model { get; set; }

    public string[] datasource = new string[] { "American Football", "Badminton", "Basketball", "Cricket", "Football", "Golf", "Hockey", "Rugby", "Snooker", "Tennis" };
    public void OnGet()
    {
        model = new AutoCompleteValue
        {
            data = datasource
        };
    }

    public void OnPost()
    {
        if (model.val == null)
        {
            ModelState.AddModelError("model.val", "Please enter a value");
        }

        model.data = datasource;
        model.val = model.val;
    }
}