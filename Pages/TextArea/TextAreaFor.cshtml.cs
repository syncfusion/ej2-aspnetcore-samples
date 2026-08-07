using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.TextArea;

public class TextAreaFor : PageModel
{
    [BindProperty]
    public TextAreaValue Textareas { get; set; }

    public string comment = "";
    public void OnGet()
    {
        Textareas = new TextAreaValue
        {
            comments = comment
        };
    }
    public void OnPost()
    {
        if (Textareas.comments == null)
        {
            ModelState.AddModelError("Textareas.comments", "Value is required");
        }
    }
}
public class TextAreaValue
{
    public string comments { get; set; }
}