using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;

namespace EJ2CoreSampleBrowser.Pages.Grid;

public class ShowHideColumnModel : PageModel
{
    public List<Category> DataSource { get; set; }
    public List<object> columns { get; set; }
    public void OnGet()
    {
        DataSource = Category.GetAllRecords().ToList();
        List<object> dd = new List<object>();
        dd.Add(new { text = "Category Name", value = "CategoryName" });
        dd.Add(new { text = "Product Name", value = "ProductName" });
        dd.Add(new { text = "Units In Stock", value = "UnitsInStock" });
        dd.Add(new { text = "Discontinued", value = "Discontinued" });
        columns = dd;
    }
}