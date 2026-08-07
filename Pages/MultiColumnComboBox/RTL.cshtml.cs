using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;

namespace EJ2CoreSampleBrowser.Pages.MultiColumnComboBox;

public class RTLModel : PageModel
{
public List<BookDetails> book { get; set; }
    public void OnGet()
    {
        book = new BookDetails().GetAllRecords();
    }
}