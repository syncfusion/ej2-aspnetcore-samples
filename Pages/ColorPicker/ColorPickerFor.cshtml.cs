using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.ColorPicker;

public class ColorPickerFor : PageModel
{
    [BindProperty]
    public ColorPickerModel model { get; set; }

    public string ColorText = "#000080";
    public void OnGet()
    {
        model = new ColorPickerModel
        {
            colorValue = ColorText
        };
    }

    public void OnPost()
    {
        if (model.colorValue == ColorText)
        {
            ModelState.AddModelError("model.colorValue", "Please select color with value other than #000080.");
        }
    }
}
public class ColorPickerModel
{
    public string colorValue { get; set; }
}