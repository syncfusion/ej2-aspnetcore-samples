using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Pages.Button;

public class SwitchFor : PageModel
{
    [BindProperty]
    public SwitchModel model { get; set; }
    public void OnGet()
    {
        model = new SwitchModel
        {
            check = true
        };
    }
    public void OnPost()
    {
        if (model.check != true)
        {
            ModelState.AddModelError("model.check", "You need to agree to receive newsletter");
        }
    }
}
public class SwitchModel
{
    public bool check { get; set; }
}