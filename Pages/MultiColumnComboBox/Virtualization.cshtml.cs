#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.MultiColumnComboBox;

public class VirtualizationModel : PageModel
{
    public List<MultiColumnComboBoxRecord> Records { get; set; }
    public void OnGet()
    {
        MultiColumnComboBoxRecord model = new MultiColumnComboBoxRecord();
        Records = new MultiColumnComboBoxRecord().GenerateTasks(150);
    }
}
public class MultiColumnComboBoxRecord
{
    public string Name { get; set; }
    public string Departments { get; set; }
    public string Role { get; set; }
    public string Location { get; set; }


    public List<MultiColumnComboBoxRecord> GenerateTasks(int count)
    {
        var names = new List<string> { "John Doe", "Jane Smith", "Alice Johnson", "Bob Brown", "Emily Davis" };
        var departments = new List<string> { "HR", "IT", "Finance", "Marketing", "Sales" };
        var roles = new List<string> { "Manager", "Developer", "Analyst", "Consultant", "Executive" };
        var locations = new List<string> { "New York", "San Francisco", "London", "Berlin", "Tokyo" };
        var result = new List<MultiColumnComboBoxRecord>();
        for (var i = 0; i < count; i++)
        {
            result.Add(new MultiColumnComboBoxRecord
            {
                Name = names[new Random().Next(names.Count)],
                Departments = departments[new Random().Next(departments.Count)],
                Role = roles[new Random().Next(roles.Count)],
                Location = locations[new Random().Next(locations.Count)]
            });
        }
        return result;
    }
}