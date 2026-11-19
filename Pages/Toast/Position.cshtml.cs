using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Toast;

public class Position : PageModel
{
    public List<Positions> position = new List<Positions>();
    public void OnGet()
    {
        position.Add(new Positions { Value = "Top Left" });
        position.Add(new Positions { Value = "Top Right" });
        position.Add(new Positions { Value = "Top Center" });
        position.Add(new Positions { Value = "Top Full Width" });
        position.Add(new Positions { Value = "Bottom Left" });
        position.Add(new Positions { Value = "Bottom Right" });
        position.Add(new Positions { Value = "Bottom Center" });
        position.Add(new Positions { Value = "Bottom Full Width" });
    }
}

public class Positions
{
    public string Value { get; set; }
}