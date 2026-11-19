using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.TreeView
{
    public class VirtualizationModel : PageModel
    {
        public List<object> TreeData = new List<object>();

        public void OnGet()
        {
            int totalNodes = 8000;
            int employeesPerDept = 20;

            string[] departments =
            {
                "Engineering",
                "Sales",
                "Human Resources",
                "Finance",
                "Marketing",
                "Customer Support",
                "Operations",
                "Legal",
                "Research",
                "IT Infrastructure"
            };

            string[] employeeRoles =
            {
                "Manager",
                "Senior Engineer",
                "Software Engineer",
                "Business Analyst",
                "QA Engineer",
                "Consultant",
                "Specialist",
                "Coordinator",
                "Executive",
                "Associate"
            };

            int index = 0;
            int id = 1;
            int deptIndex = 0;

            while (index < totalNodes)
            {
                int deptId = id++;
                string deptName = departments[deptIndex % departments.Length];

                TreeData.Add(new
                {
                    id = deptId,
                    pid = (int?)null,
                    name = deptName,
                    hasChild = false,
                    isChecked = true,
                    isExpanded = false
                });

                index++;
                int childCount = 0;

                for (int i = 0; i < employeesPerDept && index < totalNodes; i++)
                {
                    string role = employeeRoles[i % employeeRoles.Length];

                    TreeData.Add(new
                    {
                        id = id++,
                        pid = deptId,
                        name = role + " - Employee " + (i + 1),
                        isChecked = true,
                        isExpanded = false
                    });

                    index++;
                    childCount++;
                }

                if (childCount > 0)
                {
                    var parentNode = TreeData[TreeData.Count - childCount - 1];

                    TreeData[TreeData.Count - childCount - 1] = new
                    {
                        id = deptId,
                        pid = (int?)null,
                        name = deptName,
                        hasChild = true,
                        isChecked = true,
                        isExpanded = false
                    };
                }

                deptIndex++;
            }
        }
    }
}