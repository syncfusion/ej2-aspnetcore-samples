using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.TextBoxes;

public class TextboxFor : PageModel
{
    [BindProperty]
    public TextBoxValue Textbox { get; set; }

    public string ValueText = "John";
    public void OnGet()
    {
        Textbox = new TextBoxValue
        {
            firstname = ValueText
        };
    }
    public void OnPost()
    {
        if (Textbox.firstname == null)
        {
            ModelState.AddModelError("Textbox.firstname", "Value is required");
        }
    }
}
public class TextBoxValue
{
    public string firstname { get; set; }
}