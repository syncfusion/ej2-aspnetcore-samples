using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.HeatMapChart;

public class Default : PageModel
{
    public int[,] GetDataSource()
    {
        int[,] data = new int[12, 6];
        for (int x = 0; x < 12; x++)
        {
            for (int y = 0; y < 6; y++)
            {
                Random random = new Random();
                data[x, y] = random.Next(0, 100);
            }
        }
        return data;
    }
    public void OnGet()
    {
        
    }
}