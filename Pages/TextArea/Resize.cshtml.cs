using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;

namespace EJ2CoreSampleBrowser.Pages.TextArea;

public class ResizeModel : PageModel
{
    public List<resizeValues> data { get; set; }
    public void OnGet()
    {
        data = new resizeValues().TextAreaModel();
    }
}