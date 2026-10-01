using EJ2CoreSampleBrowser.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Grid
{
    public class ProductCatalogModel : PageModel
    {
        public List<ProductDetail> Products { get; set; }

        public void OnGet()
        {
            Products = ProductDetailsData.GetProducts();
        }
    }
}
