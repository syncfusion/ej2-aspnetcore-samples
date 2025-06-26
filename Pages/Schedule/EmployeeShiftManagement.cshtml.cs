#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;
using Syncfusion.EJ2.Navigations;

namespace EJ2CoreSampleBrowser.Pages
{
    public class EmployeeShiftManagement : PageModel
    {
        public List<EmployeeShiftManagementData> EmployeeShiftData { get; set; }
        public List<RoleData> EmployeeRoles { get; set; }
        public List<DesignationData> Designations { get; set; }
        public List<EmployeeImage> EmployeeImages { get; set; }
        public string[] GroupResources { get; set; } = new[] { "Roles", "Designations" };

        //treeview
        public List<StaffMember> Doctors { get; set; }
        public List<StaffMember> Nurses { get; set; }
        public List<StaffMember> Staffs { get; set; }
        public List<StaffMember> AllStaffs { get; set; }

        //TreeView field settings
        public TreeViewFieldsSettings AllStaffsFields { get; set; }
        public TreeViewFieldsSettings DoctorsFields { get; set; }
        public TreeViewFieldsSettings NursesFields { get; set; }
        public TreeViewFieldsSettings StaffsFields { get; set; }

        public Dictionary<string, string> ImageMap { get; set; }

        //Initial ChipList selection (0 = "All")
        public int[] SelectedChips { get; set; }

        public List<EmployeeNames> EmployeeNamesList { get; set; }
        public List<Shift> ShiftList { get; set; }

        public void OnGet()
        {
            EmployeeShiftData = EmployeeShiftDataSource.GetShiftData();
            EmployeeRoles = EmployeeShiftDataSource.GetRoles();
            Designations = EmployeeShiftDataSource.GetDesignations();
            EmployeeImages = EmployeeShiftDataSource.GetEmployeeImages();
            Doctors = EmployeeShiftDataSource.GetDoctors();
            Nurses = EmployeeShiftDataSource.GetNurses();
            Staffs = EmployeeShiftDataSource.GetStaffs();
            AllStaffs = Doctors.Concat(Nurses).Concat(Staffs).ToList();
            //Initial selected chip = "All"
            SelectedChips = new[] { 0 };
            ImageMap = EmployeeShiftDataSource.GetImageMap();

            // Configure TreeView fields
            AllStaffsFields = new TreeViewFieldsSettings
            {
                DataSource = AllStaffs,
                Id = "Id",
                Text = "Name"
            };
            DoctorsFields = new TreeViewFieldsSettings
            {
                DataSource = Doctors,
                Id = "Id",
                Text = "Name"
            };
            NursesFields = new TreeViewFieldsSettings
            {
                DataSource = Nurses,
                Id = "Id",
                Text = "Name"
            };
            StaffsFields = new TreeViewFieldsSettings
            {
                DataSource = Staffs,
                Id = "Id",
                Text = "Name"
            };
        }
    }
}
