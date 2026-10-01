using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Schedule;

public class HideWeekend : PageModel
{
    public List<GetData> workDays = new List<GetData>();
    public void OnGet()
    {
        workDays.Add(new GetData { Name = "Sunday", Code = "0" });
        workDays.Add(new GetData { Name = "Monday", Code = "1" });
        workDays.Add(new GetData { Name = "Tuesday", Code = "2" });
        workDays.Add(new GetData { Name = "Wednesday", Code = "3" });
        workDays.Add(new GetData { Name = "Thursday", Code = "4" });
        workDays.Add(new GetData { Name = "Friday", Code = "5" });
        workDays.Add(new GetData { Name = "Saturday", Code = "6" });
    }
}
public class GetData
{
    public string Name { get; set; }
    public string Code { get; set; }
}