using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EJ2CoreSampleBrowser.Models
{
    public class Merge
    {
        public static List<Merge> GetInversedData()
        {
            
                List<Merge> obj = new List<Merge>();

            obj.Add(new Merge("Testing", "Testing", "Testing", "Testing", "Development", "Conference", "Team Meeting", "Team Meeting", "Analysis Tasks", "Lunch Break", "Analysis Tasks", "Team Meeting", "Testing", "Development", "Development", "Development", "Support", 10001, "Davolio"));
            obj.Add(new Merge("Development", "Development", "Development", "Development", "Check Mail", "Check Mail", "Team Meeting", "Team Meeting", "Task Assign", "Lunch Break", "Support", "Support", "Support", "Testing", "Testing", "Testing", "Testing", 10002, "Buchanan"));
            obj.Add(new Merge("Development", "Development", "Development", "Development", "Team Meeting", "Team Meeting", "Development", "Development", "Check Mail", "Lunch Break", "Check Mail", "Check Mail", "Analysis Tasks", "Analysis Tasks", "Support", "Support", "Support", 10003, "Fuller"));
            obj.Add(new Merge("Development", "Development", "Development", "Development", "Check Mail", "Conference", "Conference", "Team Meeting", "Testing", "Lunch Break", "Check Mail", "Check Mail", "Support", "Testing", "Testing", "Testing", "Testing", 10004, "Leverling"));
            obj.Add(new Merge("Development", "Development", "Development", "Development", "Team Meeting", "Team Meeting", "Testing", "Testing", "Task Assign", "Lunch Break", "Task Assign", "Task Assign", "Task Assign", "Check Mail", "Support", "Support", "Support", 10005, "Peacock"));
            obj.Add(new Merge("Development", "Development", "Development", "Development", "Team Meeting", "Team Meeting", "Development", "Development", "Testing", "Lunch Break", "Testing", "Support", "Support", "Support", "Team Meeting", "Team Meeting", "Team Meeting", 10006, "Janet"));
            obj.Add(new Merge("Support", "Support", "Support", "Build", "Build", "Check Mail", "Check Mail", "Check Mail", "Analysis Tasks", "Lunch Break", "Analysis Tasks", "Testing", "Development", "Development", "Testing", "Testing", "Testing", 10007, "Suyama"));
            obj.Add(new Merge("Check Mail", "Check Mail", "Check Mail", "Check Mail", "Check Mail", "Team Meeting", "Team Meeting", "Build", "Task Assign", "Lunch Break", "Task Assign", "Task Assign", "Development", "Development", "Development", "Testing", "Support", 10008, "Robert"));
            obj.Add(new Merge("Check Mail", "Check Mail", "Check Mail", "Check Mail", "Check Mail", "Team Meeting", "Development", "Development", "Check Mail", "Lunch Break", "Team Meeting", "Team Meeting", "Support", "Testing", "Development", "Development", "Development", 10009, "Andrew"));
            obj.Add(new Merge("Testing", "Testing", "Testing", "Testing", "Testing", "Build", "Build", "Build", "Task Assign", "Lunch Break", "Task Assign", "Task Assign", "Analysis Tasks", "Analysis Tasks", "Development", "Development", "Development", 10010, "Michael"));



            return obj;

        }

        public static List<Merge> GetRowSpanData()
        {

            List<Merge> obj = new List<Merge>();
            obj.Add(new Merge("Analysis Tasks", "Analysis Tasks", "Team Meeting", "Testing", "Development", "Development", "Development", "Support", "Lunch Break", "Lunch Break", "Lunch Break", "Testing", "Testing", "Development", "Conference", "Team Meeting", "Team Meeting", 10001, "Davolio"));
            obj.Add(new Merge("Task Assign", "Support", "Support", "Support", "Testing", "Testing", "Testing", "Testing", "Lunch Break", "Lunch Break", "Lunch Break", "Development", "Development", "Check Mail", "Check Mail", "Team Meeting", "Team Meeting", 10002, "Buchanan"));
            obj.Add(new Merge("Check Mail", "Check Mail", "Check Mail", "Analysis Tasks", "Analysis Tasks", "Support", "Support", "Support", "Lunch Break", "Lunch Break", "Lunch Break", "Development", "Development", "Team Meeting", "Team Meeting", "Development", "Development", 10003, "Fuller"));
            obj.Add(new Merge("Testing", "Check Mail", "Check Mail", "Support", "Testing", "Testing", "Testing", "Testing", "Lunch Break", "Lunch Break", "Lunch Break", "Development", "Development", "Check Mail", "Conference", "Conference", "Team Meeting", 10004, "Leverling"));
            obj.Add(new Merge("Task Assign", "Task Assign", "Task Assign", "Task Assign", "Check Mail", "Support", "Support", "Support", "Lunch Break", "Lunch Break", "Lunch Break", "Development", "Development", "Team Meeting", "Team Meeting", "Testing", "Testing", 10005, "Peacock"));
            obj.Add(new Merge("Testing", "Testing", "Support", "Support", "Support", "Team Meeting", "Team Meeting", "Team Meeting", "Lunch Break", "Lunch Break", "Lunch Break", "Development", "Development", "Team Meeting", "Team Meeting", "Development", "Development", 10006, "Janet"));
            obj.Add(new Merge("Analysis Tasks", "Analysis Tasks", "Testing", "Development", "Development", "Testing", "Testing", "Testing", "Lunch Break", "Lunch Break", "Lunch Break", "Support", "Build", "Build", "Check Mail", "Check Mail", "Check Mail", 10007, "Suyama"));
            obj.Add(new Merge("Task Assign", "Task Assign", "Task Assign", "Development", "Development", "Development", "Testing", "Support", "Lunch Break", "Lunch Break", "Lunch Break", "Check Mail", "Check Mail", "Check Mail", "Team Meeting", "Team Meeting", "Build", 10008, "Robert"));
            obj.Add(new Merge("Check Mail", "Team Meeting", "Team Meeting", "Support", "Testing", "Development", "Development", "Development", "Lunch Break", "Lunch Break", "Lunch Break", "Check Mail", "Check Mail", "Check Mail", "Team Meeting", "Development", "Development", 10009, "Andrew"));
            obj.Add(new Merge("Task Assign", "Task Assign", "Task Assign", "Analysis Tasks", "Analysis Tasks", "Development", "Development", "Development", "Lunch Break", "Lunch Break", "Lunch Break", "Testing", "Testing", "Testing", "Build", "Build", "Build", 10010, "Michael"));
            return obj;
        }



        public Merge(string Time900, string Time930, string Time1000, string Time1030, string Time1100, string Time1130, string Time1200, string Time1230, string Time100, string Time130, string Time200, string Time230, string Time300, string Time330, string Time400, string Time430, string Time500, int EmployeeID, string EmployeeName)
        {
            this.Time100 = Time100;
            this.Time1000 = Time1000;
            this.Time1030 = Time1030;
            this.Time1100 = Time1100;
            this.Time1130 = Time1130;
            this.Time1200 = Time1200;
            this.Time1230 = Time1230;
            this.Time100 = Time100;
            this.Time130 = Time130;
            this.Time200 = Time200;
            this.Time230 = Time230;
            this.Time300 = Time300;
            this.Time330 = Time330;
            this.Time400 = Time400;
            this.Time430 = Time430;
            this.Time500 = Time500;
            this.Time900 = Time900;
            this.Time930 = Time930;
            this.EmployeeID = EmployeeID;
            this.EmployeeName = EmployeeName;

        }
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Time900 { get; set; }
        public string Time930 { get; set; }
        public string Time1000 { get; set; }
        public string Time1030 { get; set; }
        public string Time1100 { get; set; }
        public string Time1130 { get; set; }
        public string Time1200 { get; set; }
        public string Time1230 { get; set; }
        public string Time100 { get; set; }
        public string Time130 { get; set; }
        public string Time200 { get; set; }
        public string Time230 { get; set; }
        public string Time300 { get; set; }
        public string Time330 { get; set; }
        public string Time400 { get; set; }
        public string Time430 { get; set; }
        public string Time500 { get; set; }
    }
}
