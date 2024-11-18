#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.MultiSelect;

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