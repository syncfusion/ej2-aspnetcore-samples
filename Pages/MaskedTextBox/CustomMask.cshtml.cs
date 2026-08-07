using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.MaskedTextBox;

public class CustomMask : PageModel
{
    public CustomCharacters customObj = new CustomCharacters();
    public void OnGet()
    {
        customObj.P = "P,A,a,p";
        customObj.M = "M,m";
    }
}
public class CustomCharacters
{
    public string P { get; set; }
    public string M { get; set; }
}