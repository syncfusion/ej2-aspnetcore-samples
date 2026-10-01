using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages
{
    public class IndexModel : PageModel
    {
        public RedirectToPageResult OnGet()
        {
            return new RedirectToPageResult("/grid/gridoverview");
        }
    }
}
