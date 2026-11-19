using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;

namespace EJ2CoreSampleBrowser.Pages.MultiColumnComboBox;

public class FilteringModel : PageModel
{
    public List<Employee> employee { get; set; }
    public void OnGet()
    {
        employee = new Employee().GetAllRecords();
    }
}