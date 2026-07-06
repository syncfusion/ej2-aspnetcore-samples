using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.ComboBox;

public class DiacriticsFiltering : PageModel
{
    public string[] Data = new string[]{
        "Águilas",
        "Ajedrez",
        "Ala Delta",
        "Álbumes de Música",
        "Alusivos",
        "Análisis de Escritura a Mano",
        "Dyarbakır",
        "Derepazarı ",
        "Gülümsemek ",
        "Teşekkürler", 
        "Güle güle.",
        "Gülhatmi",
        "Gülünç"
    };
    public void OnGet()
    {
        
    }
}