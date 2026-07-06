using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.EJ2.QueryBuilder;

namespace EJ2CoreSampleBrowser.Pages.QueryBuilder;

public class HeaderTemplateModel : PageModel
{
    public QueryBuilderRule rule { get; set; }
    public List<Object> Conditions = new List<object>();
    public void OnGet()
    {
        rule = new QueryBuilderRule()
        {
            Condition = "and",
            Rules = new List<QueryBuilderRule>()
            {
                new QueryBuilderRule { Label="First Name", Field="FirstName", Type="string", Operator="equal", Value="Nancy"  },
                new QueryBuilderRule { Label="Country", Field="Country", Type="string", Operator="equal", Value = "USA" }
            }
                
        };

        Conditions.Add(
            new { text = "AND", value = "and" });
        Conditions.Add(
            new {text = "OR", value="or"});


    }
}