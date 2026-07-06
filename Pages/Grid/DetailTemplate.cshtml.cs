using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;

namespace EJ2CoreSampleBrowser.Pages.Grid;

public class DetailTemplateModel : PageModel
{
    public List<EmployeeDetails> DataSource { get; set; }
    public List<TaskDetail> TaskData { get; set; }

    public void OnGet()
    {
        DataSource = EmployeeDetails.GetAllRecords();
        TaskData = TaskDetail.GetAllRecords();

    }
}