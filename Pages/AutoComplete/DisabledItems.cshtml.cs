using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.AutoComplete;

public class DisabledItems : PageModel
{
    public List<StatusData> status = new List<StatusData>();
    public void OnGet()
    {
        status.Add(new StatusData() { Status = "Open", State= false });
        status.Add(new StatusData() { Status = "Waiting for Customer", State= false });
        status.Add(new StatusData() { Status = "On Hold", State= true });
        status.Add(new StatusData() { Status = "Follow-up", State= false });
        status.Add(new StatusData() { Status = "Closed", State= true });
        status.Add(new StatusData() { Status = "Solved", State= false });
        status.Add(new StatusData() { Status = "Fetaure Request", State= false });
    }
}
public class StatusData
{
    public string Status { get; set; }
    public bool State { get; set; }
}