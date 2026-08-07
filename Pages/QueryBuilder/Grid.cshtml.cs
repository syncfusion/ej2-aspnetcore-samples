using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.EJ2.QueryBuilder;
using EJ2CoreSampleBrowser.Models;
namespace EJ2CoreSampleBrowser.Pages.QueryBuilder;

public class GridModel : PageModel
{
    public QueryBuilderRule rule { get; set; }
    public List<object> dataSource { get; set; }
    public void OnGet()
    {
        rule = new QueryBuilderRule()
        {
            Condition = "or",
            Rules = new List<QueryBuilderRule>()
            {
                new QueryBuilderRule { Label="Category", Field="Category", Type="string", Operator="equal", Value = "Laptop" }
            }
        };

        dataSource = QueryBuilderData.hardwareData;
    }
}