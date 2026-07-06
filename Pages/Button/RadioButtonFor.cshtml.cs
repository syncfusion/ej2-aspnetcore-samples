using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Pages.Button;

public class RadioButtonFor : PageModel
{
    [BindProperty]
    public RadioButtonModel model { get; set; }
    public void OnGet()
    {
        model = new RadioButtonModel
        {
            gender = "female"
        };
    }
    public void OnPost()
    {
        if (model.gender != "male")
        {
            ModelState.AddModelError("model.gender", "Male gender is required.");
        }
    }
}
public class RadioButtonModel
{
    public string gender { get; set; }
}