using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Pages.Button;

public class CheckBoxFor : PageModel
{
    [BindProperty]
    public CheckboxModel model { get; set; }
    public void OnGet()
    {
        model = new CheckboxModel
        {
            check = true
        };
    }

    public void OnPost()
    {
        if (model.check != true)
        {
            ModelState.AddModelError("model.check", "You need to agree to the Terms and Conditions");
        }
    }
}
public class CheckboxModel
{
    public bool check { get; set; }
}