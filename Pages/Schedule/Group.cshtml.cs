using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Schedule;

public class Group : PageModel
{
    public List<AirlineRes> airlines = new List<AirlineRes>();
    public void OnGet()
    {
        airlines.Add(new AirlineRes { AirlineName = "Airways 1", AirlineId = 1, AirlineColor = "#EA7A57" });
        airlines.Add(new AirlineRes { AirlineName = "Airways 2", AirlineId = 2, AirlineColor = "#357cd2" });
        airlines.Add(new AirlineRes { AirlineName = "Airways 3", AirlineId = 3, AirlineColor = "#7fa900" });
    }
}
public class AirlineRes
{
    public string AirlineName { set; get; }
    public int AirlineId { set; get; }
    public string AirlineColor { set; get; }
}