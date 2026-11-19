using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;

namespace EJ2CoreSampleBrowser.Pages.TextArea;

public class FloatingLabelModel : PageModel
{
    public List<floatLabelValues> data { get; set; }
    public void OnGet()
    {
        data = new floatLabelValues().TextAreaModel();
    }
}