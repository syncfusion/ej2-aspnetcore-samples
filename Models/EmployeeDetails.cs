#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EJ2CoreSampleBrowser.Models
{
    public class EmployeeDetails
    {
        public EmployeeDetails()
        {

        }
        public EmployeeDetails(string EmployeeID, string Name, string MailID, string PhoneNumber, string Designation, string ReportTo, string Location, string AssetKit , DateTime AssetKitDistribution, string EmployeeAvailability, string Team, DateTime DateOfJoining, string YearOfExperience, string SoftwareTeam)
        {
            this.EmployeeID = EmployeeID;
            this.Name = Name;
            this.MailID = MailID;
            this.PhoneNumber = PhoneNumber;
            this.Designation = Designation;
            this.ReportTo = ReportTo;
            this.Location = Location;
            this.AssetKit = AssetKit;
            this.AssetKitDistribution = AssetKitDistribution;
            this.EmployeeAvailability = EmployeeAvailability;
            this.Team = Team;
            this.DateOfJoining = DateOfJoining;
            this.YearOfExperience = YearOfExperience;
            this.SoftwareTeam = SoftwareTeam;

        }
        public string EmployeeID { get; set; }
        public string Name { get; set; }
        public string MailID { get; set; }
        public string PhoneNumber { get; set; }
        public string Designation { get; set; }
        public string ReportTo { get; set; }

        public string Location { get; set; }

        public string AssetKit { get; set; }
        public DateTime AssetKitDistribution { get; set; }
        public string EmployeeAvailability { get; set; }
        public string Team { get; set; }
        public DateTime DateOfJoining { get; set; }
        public string YearOfExperience { get; set; }
        public string SoftwareTeam { get; set; }
        public static List<EmployeeDetails> GetAllRecords()
        {
            List<EmployeeDetails> Emp = new List<Models.EmployeeDetails>();
            Emp.Add(new EmployeeDetails("Emp1001", "John", "john@abc.com", "(711) 555-4444", "Sales Representative", "Vinet", "Reims", "Headset, Laptop, Phone", new DateTime(1948, 12, 08), "Available", "Sales", new DateTime(1948, 12, 08), "3 Years", "Web-General"));
            Emp.Add(new EmployeeDetails("Emp1002", "Suyama", "suyama@abc.com", "(206) 555-1189", "Marketing Manager", "Suprd", "Albuquerque", "Laptop, Projector, Tablet", new DateTime(1952, 02, 19), "Available", "Marketing", new DateTime(1952, 02, 19), "1 Year 10 Months", "Web-Server"));
            Emp.Add(new EmployeeDetails("Emp1003", "Janet", "janet@abc.com", "(710) 555-5598", "HR Specialist", "Hanar", "Barquisimeto", "Headset, Laptop, Printer", new DateTime(1963, 08, 30), "Not Available", "Human Resources", new DateTime(1963, 08, 30), "1 Year", "Web-General"));
            Emp.Add(new EmployeeDetails("Emp1004", "Peacock", "peacock@abc.com", "(811) 555-7773", "Sales Representative", "Vinet", "Albuquerque", "Headset, Laptop, Phone", new DateTime(1937, 09, 19), "Available", "Sales", new DateTime(1937, 09, 19), "2 Years", "Window"));
            Emp.Add(new EmployeeDetails("Emp1005", "Leverling", "leverling@abc.com", "(712) 555-4848", "IT Support", "Tomsp", "Reims", "Keyboard, Laptop, Mouse", new DateTime(1955, 03, 04), "Not Available", "IT Department", new DateTime(1955, 03, 04), "5 Years 3 Months", "Web-Server"));
            Emp.Add(new EmployeeDetails("Emp1006", "Fuller", "fuller@abc.com", "(206) 555-8122", "HR Specialist", "Victe", "Barquisimeto", "Headset, Laptop, Printer", new DateTime(1963, 07, 02), "Available", "Human Resources", new DateTime(1963, 07, 02), "3 Years 1 Month", "Designer"));
            Emp.Add(new EmployeeDetails("Emp1007", "Buchanan", "buchanan@abc.com", "(206) 555-3412", "Marketing Manager", "Hanar", "Reims", "Laptop, Projector, Tablet", new DateTime(1960, 05, 29), "Not Available", "Marketing", new DateTime(1960, 05, 29), "4 Years", "Support"));
            Emp.Add(new EmployeeDetails("Emp1008", "Davolio", "davolio@abc.com", "(206) 555-9482", "Customer Service", "Vinet", "Albuquerque", "Headset, Laptop, Phone", new DateTime(1958, 01, 09), "Not Available", "Customer Support", new DateTime(1958, 01, 09), "11 Months", "Web-Server"));
            Emp.Add(new EmployeeDetails("Emp1009", "Robert", "robert@abc.com", "(206) 555-9857", "Finance Analyst", "Suprd", "Reims", "Calculator, Headset, Laptop", new DateTime(1966, 01, 27), "Available", "Finance", new DateTime(1966, 01, 27), "3 Years 5 Months", "Testing"));
            return Emp;
        }
    }
}
