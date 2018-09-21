using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EJ2CoreSampleBrowser.Models
{
    public class InlineEmployees
    {
        public string Name { get; set; }
        public string Eimg { get; set; }
        public List<InlineEmployees> EmployeesList()
        {
            List<InlineEmployees> emp = new List<InlineEmployees>();
            emp.Add(new InlineEmployees { Name = "Andrew", Eimg = "7" });
            emp.Add(new InlineEmployees { Name = "Anne", Eimg = "1" });
            emp.Add(new InlineEmployees { Name = "Janet", Eimg = "3" });
            emp.Add(new InlineEmployees { Name = "Laura", Eimg = "2" });
            emp.Add(new InlineEmployees { Name = "Michael", Eimg = "9" });
            emp.Add(new InlineEmployees { Name = "Nancy", Eimg = "4" });
            emp.Add(new InlineEmployees { Name = "Robert", Eimg = "8" });
            emp.Add(new InlineEmployees { Name = "Steven", Eimg = "10" });
            return emp;
        }
    }
}
