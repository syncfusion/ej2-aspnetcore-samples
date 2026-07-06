using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.ComboBox;

public class Template : PageModel
{
    public List<Employees> Emp = new List<Employees>();
    public void OnGet()
    {
        Emp.Add(new Employees { Name= "Andrew Fuller", Eimg= "7", Designation = "Team Lead", Country= "England"});
        Emp.Add(new Employees { Name= "Anne Dodsworth", Eimg= "1", Designation = "Developer", Country= "USA"});
        Emp.Add(new Employees { Name= "Janet Leverling", Eimg= "3", Designation = "HR", Country= "USA"});
        Emp.Add(new Employees { Name= "Laura Callahan", Eimg= "2", Designation = "Product Manager", Country= "USA"});
        Emp.Add(new Employees { Name= "Margaret Peacock", Eimg= "6", Designation = "Developer", Country= "USA"});
        Emp.Add(new Employees { Name= "Michael Suyama", Eimg= "9", Designation = "Team Lead", Country= "USA"});
        Emp.Add(new Employees { Name= "Nancy Davolio", Eimg= "4", Designation = "Product Manager", Country= "USA"});
        Emp.Add(new Employees { Name= "Robert King", Eimg= "8", Designation = "Developer ", Country= "England"});
        Emp.Add(new Employees { Name= "Steven Buchanan", Eimg= "10", Designation = "CEO", Country= "England" });
    }
}
public class Employees
{
    public string Name { get; set; }
    public string Eimg { get; set; }
    public string Designation { get; set; }
    public string Country { get; set; }
}