#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using EJ2CoreSampleBrowser.Pages;

namespace EJ2CoreSampleBrowser.Models
{
    public class EmployeeShiftManagementData
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int DesignationId { get; set; }
        public int EmployeeId { get; set; }
        public string Subject { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Description { get; set; }
        public bool IsReadonly { get; set; }
    }
    public class EmployeeImage
    {
        public string Name { get; set; }
        public string Image { get; set; }
    }
    public class RoleData
    {
        public string Role { get; set; }
        public int Id { get; set; }
    }

    public class DesignationData
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int GroupId { get; set; }
    }
    public class StaffMember
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Role { get; set; }
    }
    public class EmployeeNames
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Shift
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public static class EmployeeShiftDataSource
    {
        public static List<EmployeeShiftManagementData> GetShiftData()
        {
            List<EmployeeShiftManagementData> employeeData = new List<EmployeeShiftManagementData>();
            employeeData.Add(new EmployeeShiftManagementData { Id = 1, RoleId = 1, DesignationId = 1, EmployeeId = 1, Subject = "John", StartTime = "2025-03-02T01:30:00.000Z", EndTime = "2025-03-02T09:30:00.000Z", Description = "Available (Morning Shift)", IsReadonly = true });
            employeeData.Add(new EmployeeShiftManagementData { Id = 2, RoleId = 1, DesignationId = 1, EmployeeId = 2, Subject = "Nashil", StartTime = "2025-03-02T09:30:00.000Z", EndTime = "2025-03-02T17:30:00.000Z", Description = "Available (Evening Shift)", IsReadonly = true });
            employeeData.Add(new EmployeeShiftManagementData { Id = 3, RoleId = 1, DesignationId = 1, EmployeeId = 1, Subject = "John", StartTime = "2025-03-03T01:30:00.000Z", EndTime = "2025-03-03T09:30:00.000Z", Description = "Available (Morning Shift)", IsReadonly = true });
            employeeData.Add(new EmployeeShiftManagementData { Id = 4, RoleId = 1, DesignationId = 1, EmployeeId = 2, Subject = "Nashil", StartTime = "2025-03-03T09:30:00.000Z", EndTime = "2025-03-03T17:30:00.000Z", Description = "Available (Evening Shift)", IsReadonly = true });
            employeeData.Add(new EmployeeShiftManagementData { Id = 5, RoleId = 1, DesignationId = 1, EmployeeId = 1, Subject = "John", StartTime = "2025-03-04T01:30:00.000Z", EndTime = "2025-03-04T09:30:00.000Z", Description = "Available (Morning Shift)", IsReadonly = true });
            employeeData.Add(new EmployeeShiftManagementData { Id = 6, RoleId = 1, DesignationId = 1, EmployeeId = 2, Subject = "Nashil", StartTime = "2025-03-04T09:30:00.000Z", EndTime = "2025-03-04T17:30:00.000Z", Description = "Available (Evening Shift)", IsReadonly = true });
            employeeData.Add(new EmployeeShiftManagementData { Id = 7, RoleId = 1, DesignationId = 1, EmployeeId = 1, Subject = "John", StartTime = "2025-03-05T01:30:00.000Z", EndTime = "2025-03-05T09:30:00.000Z", Description = "Available (Morning Shift)" });
            employeeData.Add(new EmployeeShiftManagementData { Id = 8, RoleId = 1, DesignationId = 1, EmployeeId = 2, Subject = "Nashil", StartTime = "2025-03-05T09:30:00.000Z", EndTime = "2025-03-05T17:30:00.000Z", Description = "Available (Evening Shift)" });
            employeeData.Add(new EmployeeShiftManagementData { Id = 9, RoleId = 1, DesignationId = 1, EmployeeId = 1, Subject = "John", StartTime = "2025-03-06T01:30:00.000Z", EndTime = "2025-03-06T09:30:00.000Z", Description = "Available (Morning Shift - Swap-Request)" });
            employeeData.Add(new EmployeeShiftManagementData { Id = 10, RoleId = 1, DesignationId = 1, EmployeeId = 2, Subject = "Nashil", StartTime = "2025-03-06T09:30:00.000Z", EndTime = "2025-03-06T17:30:00.000Z", Description = "Available (Evening Shift)" });
            employeeData.Add(new EmployeeShiftManagementData { Id = 11, RoleId = 1, DesignationId = 1, EmployeeId = 1, Subject = "John", StartTime = "2025-03-07T01:30:00.000Z", EndTime = "2025-03-07T09:30:00.000Z", Description = "Available (Morning Shift)" });
            employeeData.Add(new EmployeeShiftManagementData { Id = 12, RoleId = 1, DesignationId = 1, EmployeeId = 2, Subject = "Nashil", StartTime = "2025-03-07T09:30:00.000Z", EndTime = "2025-03-07T17:30:00.000Z", Description = "Available (Evening Shift - Swap-Request)" });
            employeeData.Add(new EmployeeShiftManagementData { Id = 13, RoleId = 1, DesignationId = 1, EmployeeId = 1, Subject = "John", StartTime = "2025-03-08T01:30:00.000Z", EndTime = "2025-03-08T09:30:00.000Z", Description = "Available (Morning Shift)" });
            employeeData.Add(new EmployeeShiftManagementData { Id = 14, RoleId = 1, DesignationId = 1, EmployeeId = 2, Subject = "Nashil", StartTime = "2025-03-08T09:30:00.000Z", EndTime = "2025-03-08T17:30:00.000Z", Description = "Available (Evening Shift)" });
            employeeData.Add(new EmployeeShiftManagementData { Id = 15, RoleId = 1, DesignationId = 2, EmployeeId = 3, Subject = "Jennifer", StartTime = "2025-03-02T01:30:00.000Z", EndTime = "2025-03-02T09:30:00.000Z", Description = "Available (Morning Shift)", IsReadonly = true });
            employeeData.Add(new EmployeeShiftManagementData { Id = 16, RoleId = 1, DesignationId = 2, EmployeeId = 4, Subject = "William", StartTime = "2025-03-02T09:30:00.000Z", EndTime = "2025-03-02T17:30:00.000Z", Description = "Available (Evening Shift)", IsReadonly = true });
            employeeData.Add(new EmployeeShiftManagementData { Id = 17, RoleId = 1, DesignationId = 2, EmployeeId = 3, Subject = "Jennifer", StartTime = "2025-03-03T01:30:00.000Z", EndTime = "2025-03-03T09:30:00.000Z", Description = "Available (Morning Shift)", IsReadonly = true });
            employeeData.Add(new EmployeeShiftManagementData { Id = 18, RoleId = 1, DesignationId = 2, EmployeeId = 4, Subject = "William", StartTime = "2025-03-03T09:30:00.000Z", EndTime = "2025-03-03T17:30:00.000Z", Description = "Available (Evening Shift)", IsReadonly = true });
            employeeData.Add(new EmployeeShiftManagementData { Id = 19, RoleId = 1, DesignationId = 2, EmployeeId = 3, Subject = "Jennifer", StartTime = "2025-03-04T01:30:00.000Z", EndTime = "2025-03-04T09:30:00.000Z", Description = "Available (Morning Shift)", IsReadonly = true });
            employeeData.Add(new EmployeeShiftManagementData { Id = 20, RoleId = 1, DesignationId = 2, EmployeeId = 4, Subject = "William", StartTime = "2025-03-04T09:30:00.000Z", EndTime = "2025-03-04T17:30:00.000Z", Description = "Available (Evening Shift)", IsReadonly = true });
            employeeData.Add(new EmployeeShiftManagementData { Id = 21, RoleId = 1, DesignationId = 2, EmployeeId = 3, Subject = "Jennifer", StartTime = "2025-03-05T01:30:00.000Z", EndTime = "2025-03-05T09:30:00.000Z", Description = "Available (Morning Shift - Swap-Request)" });
            employeeData.Add(new EmployeeShiftManagementData { Id = 22, RoleId = 1, DesignationId = 2, EmployeeId = 4, Subject = "William", StartTime = "2025-03-05T09:30:00.000Z", EndTime = "2025-03-05T17:30:00.000Z", Description = "Available (Evening Shift - Swap-Request)" });
            employeeData.Add(new EmployeeShiftManagementData { Id = 23, RoleId = 1, DesignationId = 2, EmployeeId = 3, Subject = "Jennifer", StartTime = "2025-03-06T01:30:00.000Z", EndTime = "2025-03-06T09:30:00.000Z", Description = "Available (Morning Shift)" });
            employeeData.Add(new EmployeeShiftManagementData { Id = 24, RoleId = 1, DesignationId = 2, EmployeeId = 4, Subject = "William", StartTime = "2025-03-06T09:30:00.000Z", EndTime = "2025-03-06T17:30:00.000Z", Description = "Available (Evening Shift)" });
            employeeData.Add(new EmployeeShiftManagementData { Id = 25, RoleId = 1, DesignationId = 2, EmployeeId = 3, Subject = "Jennifer", StartTime = "2025-03-07T01:30:00.000Z", EndTime = "2025-03-07T09:30:00.000Z", Description = "Available (Morning Shift)" });
            employeeData.Add(new EmployeeShiftManagementData { Id = 26, RoleId = 1, DesignationId = 2, EmployeeId = 4, Subject = "William", StartTime = "2025-03-07T09:30:00.000Z", EndTime = "2025-03-07T17:30:00.000Z", Description = "Available (Evening Shift - Swap-Request)" });
            employeeData.Add(new EmployeeShiftManagementData { Id = 27, RoleId = 1, DesignationId = 2, EmployeeId = 3, Subject = "Jennifer", StartTime = "2025-03-08T01:30:00.000Z", EndTime = "2025-03-08T09:30:00.000Z", Description = "Available (Morning Shift - Swap-Request)" });
            employeeData.Add(new EmployeeShiftManagementData { Id = 28, RoleId = 1, DesignationId = 2, EmployeeId = 4, Subject = "William", StartTime = "2025-03-08T09:30:00.000Z", EndTime = "2025-03-08T17:30:00.000Z", Description = "Available (Evening Shift)" });
            employeeData.Add(new EmployeeShiftManagementData { Id = 29, RoleId = 1, DesignationId = 3, EmployeeId = 5, Subject = "David", StartTime = "2025-03-02T01:30:00.000Z", EndTime = "2025-03-02T09:30:00.000Z", Description = "Available (Morning Shift)", IsReadonly = true });
            employeeData.Add(new EmployeeShiftManagementData { Id = 30, RoleId = 1, DesignationId = 3, EmployeeId = 6, Subject = "Michael", StartTime = "2025-03-02T09:30:00.000Z", EndTime = "2025-03-02T17:30:00.000Z", Description = "Available (Evening Shift)", IsReadonly = true });
            employeeData.Add(new EmployeeShiftManagementData { Id = 31, RoleId = 1, DesignationId = 3, EmployeeId = 5, Subject = "David", StartTime = "2025-03-03T01:30:00.000Z", EndTime = "2025-03-03T09:30:00.000Z", Description = "Available (Morning Shift)", IsReadonly = true });
            employeeData.Add(new EmployeeShiftManagementData { Id = 32, RoleId = 1, DesignationId = 3, EmployeeId = 6, Subject = "Michael", StartTime = "2025-03-03T09:30:00.000Z", EndTime = "2025-03-03T17:30:00.000Z", Description = "Available (Evening Shift)", IsReadonly = true });
            employeeData.Add(new EmployeeShiftManagementData { Id = 33, RoleId = 1, DesignationId = 3, EmployeeId = 5, Subject = "David", StartTime = "2025-03-04T01:30:00.000Z", EndTime = "2025-03-04T09:30:00.000Z", Description = "Available (Morning Shift)", IsReadonly = true });
            employeeData.Add(new EmployeeShiftManagementData { Id = 34, RoleId = 1, DesignationId = 3, EmployeeId = 6, Subject = "Michael", StartTime = "2025-03-04T09:30:00.000Z", EndTime = "2025-03-04T17:30:00.000Z", Description = "Available (Evening Shift)", IsReadonly = true });
            employeeData.Add(new EmployeeShiftManagementData { Id = 35, RoleId = 1, DesignationId = 3, EmployeeId = 5, Subject = "David", StartTime = "2025-03-05T01:30:00.000Z", EndTime = "2025-03-05T09:30:00.000Z", Description = "Leave (Morning Shift)" });
            employeeData.Add(new EmployeeShiftManagementData { Id = 36, RoleId = 1, DesignationId = 3, EmployeeId = 6, Subject = "Michael", StartTime = "2025-03-05T09:30:00.000Z", EndTime = "2025-03-05T17:30:00.000Z", Description = "Available (Evening Shift)" });
            employeeData.Add(new EmployeeShiftManagementData { Id = 37, RoleId = 1, DesignationId = 3, EmployeeId = 5, Subject = "David", StartTime = "2025-03-06T01:30:00.000Z", EndTime = "2025-03-06T09:30:00.000Z", Description = "Available (Morning Shift)" });
            employeeData.Add(new EmployeeShiftManagementData { Id = 38, RoleId = 1, DesignationId = 3, EmployeeId = 6, Subject = "Michael", StartTime = "2025-03-06T09:30:00.000Z", EndTime = "2025-03-06T17:30:00.000Z", Description = "Available (Evening Shift - Swap-Request)" });
            employeeData.Add(new EmployeeShiftManagementData { Id = 39, RoleId = 1, DesignationId = 3, EmployeeId = 5, Subject = "David", StartTime = "2025-03-07T01:30:00.000Z", EndTime = "2025-03-07T09:30:00.000Z", Description = "Available (Morning Shift)" });
            employeeData.Add(new EmployeeShiftManagementData { Id = 40, RoleId = 1, DesignationId = 3, EmployeeId = 6, Subject = "Michael", StartTime = "2025-03-07T09:30:00.000Z", EndTime = "2025-03-07T17:30:00.000Z", Description = "Available (Evening Shift)" });
            employeeData.Add(new EmployeeShiftManagementData { Id = 41, RoleId = 1, DesignationId = 3, EmployeeId = 5, Subject = "David", StartTime = "2025-03-08T01:30:00.000Z", EndTime = "2025-03-08T09:30:00.000Z", Description = "Available (Morning Shift - Swap-Request)" });
            employeeData.Add(new EmployeeShiftManagementData { Id = 42, RoleId = 1, DesignationId = 3, EmployeeId = 6, Subject = "Michael", StartTime = "2025-03-08T09:30:00.000Z", EndTime = "2025-03-08T17:30:00.000Z", Description = "Available (Evening Shift)" });
            employeeData.Add(new EmployeeShiftManagementData { Id = 43, RoleId = 1, DesignationId = 4, EmployeeId = 7, Subject = "Thomas", StartTime = "2025-03-02T01:30:00.000Z", EndTime = "2025-03-02T09:30:00.000Z", Description = "Available (Morning Shift)", IsReadonly = true });
            employeeData.Add(new EmployeeShiftManagementData { Id = 44, RoleId = 1, DesignationId = 4, EmployeeId = 8, Subject = "Daniel", StartTime = "2025-03-02T09:30:00.000Z", EndTime = "2025-03-02T17:30:00.000Z", Description = "Available (Evening Shift)", IsReadonly = true });
            employeeData.Add(new EmployeeShiftManagementData { Id = 45, RoleId = 1, DesignationId = 4, EmployeeId = 7, Subject = "Thomas", StartTime = "2025-03-03T01:30:00.000Z", EndTime = "2025-03-03T09:30:00.000Z", Description = "Available (Morning Shift)", IsReadonly = true });
            employeeData.Add(new EmployeeShiftManagementData { Id = 46, RoleId = 1, DesignationId = 4, EmployeeId = 8, Subject = "Daniel", StartTime = "2025-03-03T09:30:00.000Z", EndTime = "2025-03-03T17:30:00.000Z", Description = "Available (Evening Shift)", IsReadonly = true });
            employeeData.Add(new EmployeeShiftManagementData { Id = 47, RoleId = 1, DesignationId = 4, EmployeeId = 7, Subject = "Thomas", StartTime = "2025-03-04T01:30:00.000Z", EndTime = "2025-03-04T09:30:00.000Z", Description = "Available (Morning Shift)", IsReadonly = true });
            employeeData.Add(new EmployeeShiftManagementData { Id = 48, RoleId = 1, DesignationId = 4, EmployeeId = 8, Subject = "Daniel", StartTime = "2025-03-04T09:30:00.000Z", EndTime = "2025-03-04T17:30:00.000Z", Description = "Available (Evening Shift)", IsReadonly = true });
            employeeData.Add(new EmployeeShiftManagementData { Id = 49, RoleId = 1, DesignationId = 4, EmployeeId = 7, Subject = "Thomas", StartTime = "2025-03-05T01:30:00.000Z", EndTime = "2025-03-05T09:30:00.000Z", Description = "Available (Morning Shift)" });
            employeeData.Add(new EmployeeShiftManagementData { Id = 50, RoleId = 1, DesignationId = 4, EmployeeId = 8, Subject = "Daniel", StartTime = "2025-03-05T09:30:00.000Z", EndTime = "2025-03-05T17:30:00.000Z", Description = "Available (Evening Shift)" });
            employeeData.Add(new EmployeeShiftManagementData { Id = 51, RoleId = 1, DesignationId = 4, EmployeeId = 7, Subject = "Thomas", StartTime = "2025-03-06T01:30:00.000Z", EndTime = "2025-03-06T09:30:00.000Z", Description = "Available (Morning Shift)" });
            employeeData.Add(new EmployeeShiftManagementData { Id = 52, RoleId = 1, DesignationId = 4, EmployeeId = 8, Subject = "Daniel", StartTime = "2025-03-06T09:30:00.000Z", EndTime = "2025-03-06T17:30:00.000Z", Description = "Leave (Evening Shift)" });
            employeeData.Add(new EmployeeShiftManagementData { Id = 53, RoleId = 1, DesignationId = 4, EmployeeId = 7, Subject = "Thomas", StartTime = "2025-03-07T01:30:00.000Z", EndTime = "2025-03-07T09:30:00.000Z", Description = "Available (Morning Shift - Swap-Request)" });
            employeeData.Add(new EmployeeShiftManagementData { Id = 54, RoleId = 1, DesignationId = 4, EmployeeId = 8, Subject = "Daniel", StartTime = "2025-03-07T09:30:00.000Z", EndTime = "2025-03-07T17:30:00.000Z", Description = "Available (Evening Shift - Swap-Request)" });
            employeeData.Add(new EmployeeShiftManagementData { Id = 55, RoleId = 1, DesignationId = 4, EmployeeId = 7, Subject = "Thomas", StartTime = "2025-03-08T01:30:00.000Z", EndTime = "2025-03-08T09:30:00.000Z", Description = "Available (Morning Shift)" });
            employeeData.Add(new EmployeeShiftManagementData { Id = 56, RoleId = 1, DesignationId = 4, EmployeeId = 8, Subject = "Daniel", StartTime = "2025-03-08T09:30:00.000Z", EndTime = "2025-03-08T17:30:00.000Z", Description = "Available (Evening Shift)" });
            employeeData.Add(new EmployeeShiftManagementData { Id = 57, RoleId = 2, DesignationId = 5, EmployeeId = 9, Subject = "Emma", StartTime = "2025-03-02T01:30:00.000Z", EndTime = "2025-03-02T09:30:00.000Z", Description = "Available (Morning Shift)", IsReadonly = true });
            employeeData.Add(new EmployeeShiftManagementData { Id = 58, RoleId = 2, DesignationId = 5, EmployeeId = 10, Subject = "Lily", StartTime = "2025-03-02T09:30:00.000Z", EndTime = "2025-03-02T17:30:00.000Z", Description = "Available (Evening Shift)", IsReadonly = true });
            employeeData.Add(new EmployeeShiftManagementData { Id = 59, RoleId = 2, DesignationId = 5, EmployeeId = 9, Subject = "Emma", StartTime = "2025-03-03T01:30:00.000Z", EndTime = "2025-03-03T09:30:00.000Z", Description = "Available (Morning Shift)", IsReadonly = true });
            employeeData.Add(new EmployeeShiftManagementData { Id = 60, RoleId = 2, DesignationId = 5, EmployeeId = 10, Subject = "Lily", StartTime = "2025-03-03T09:30:00.000Z", EndTime = "2025-03-03T17:30:00.000Z", Description = "Available (Evening Shift)", IsReadonly = true });
            employeeData.Add(new EmployeeShiftManagementData { Id = 61, RoleId = 2, DesignationId = 5, EmployeeId = 9, Subject = "Emma", StartTime = "2025-03-04T01:30:00.000Z", EndTime = "2025-03-04T09:30:00.000Z", Description = "Available (Morning Shift)", IsReadonly = true });
            employeeData.Add(new EmployeeShiftManagementData { Id = 62, RoleId = 2, DesignationId = 5, EmployeeId = 10, Subject = "Lily", StartTime = "2025-03-04T09:30:00.000Z", EndTime = "2025-03-04T17:30:00.000Z", Description = "Available (Evening Shift)", IsReadonly = true });
            employeeData.Add(new EmployeeShiftManagementData { Id = 63, RoleId = 2, DesignationId = 5, EmployeeId = 9, Subject = "Emma", StartTime = "2025-03-05T01:30:00.000Z", EndTime = "2025-03-05T09:30:00.000Z", Description = "Available (Morning Shift)" });
            employeeData.Add(new EmployeeShiftManagementData { Id = 64, RoleId = 2, DesignationId = 5, EmployeeId = 10, Subject = "Lily", StartTime = "2025-03-05T09:30:00.000Z", EndTime = "2025-03-05T17:30:00.000Z", Description = "Available (Evening Shift)" });
            employeeData.Add(new EmployeeShiftManagementData { Id = 65, RoleId = 2, DesignationId = 5, EmployeeId = 9, Subject = "Emma", StartTime = "2025-03-06T01:30:00.000Z", EndTime = "2025-03-06T09:30:00.000Z", Description = "Available (Morning Shift - Swap-Request)" });
            employeeData.Add(new EmployeeShiftManagementData { Id = 66, RoleId = 2, DesignationId = 5, EmployeeId = 10, Subject = "Lily", StartTime = "2025-03-06T09:30:00.000Z", EndTime = "2025-03-06T17:30:00.000Z", Description = "Available (Evening Shift)" });
            employeeData.Add(new EmployeeShiftManagementData { Id = 67, RoleId = 2, DesignationId = 5, EmployeeId = 9, Subject = "Emma", StartTime = "2025-03-07T01:30:00.000Z", EndTime = "2025-03-07T09:30:00.000Z", Description = "Available (Morning Shift)" });
            employeeData.Add(new EmployeeShiftManagementData { Id = 68, RoleId = 2, DesignationId = 5, EmployeeId = 10, Subject = "Lily", StartTime = "2025-03-07T09:30:00.000Z", EndTime = "2025-03-07T17:30:00.000Z", Description = "Available (Evening Shift - Swap-Request)" });
            employeeData.Add(new EmployeeShiftManagementData { Id = 69, RoleId = 2, DesignationId = 5, EmployeeId = 9, Subject = "Emma", StartTime = "2025-03-08T01:30:00.000Z", EndTime = "2025-03-08T09:30:00.000Z", Description = "Leave (Morning Shift)" });
            employeeData.Add(new EmployeeShiftManagementData { Id = 70, RoleId = 2, DesignationId = 5, EmployeeId = 10, Subject = "Lily", StartTime = "2025-03-08T09:30:00.000Z", EndTime = "2025-03-08T17:30:00.000Z", Description = "Available (Evening Shift)" });
            employeeData.Add(new EmployeeShiftManagementData { Id = 71, RoleId = 2, DesignationId = 6, EmployeeId = 11, Subject = "Ava", StartTime = "2025-03-02T01:30:00.000Z", EndTime = "2025-03-02T09:30:00.000Z", Description = "Available (Morning Shift)", IsReadonly = true });
            employeeData.Add(new EmployeeShiftManagementData { Id = 72, RoleId = 2, DesignationId = 6, EmployeeId = 12, Subject = "Grace", StartTime = "2025-03-02T09:30:00.000Z", EndTime = "2025-03-02T17:30:00.000Z", Description = "Available (Evening Shift)", IsReadonly = true });
            employeeData.Add(new EmployeeShiftManagementData { Id = 73, RoleId = 2, DesignationId = 6, EmployeeId = 11, Subject = "Ava", StartTime = "2025-03-03T01:30:00.000Z", EndTime = "2025-03-03T09:30:00.000Z", Description = "Available (Morning Shift)", IsReadonly = true });
            employeeData.Add(new EmployeeShiftManagementData { Id = 74, RoleId = 2, DesignationId = 6, EmployeeId = 12, Subject = "Grace", StartTime = "2025-03-03T09:30:00.000Z", EndTime = "2025-03-03T17:30:00.000Z", Description = "Available (Evening Shift)", IsReadonly = true });
            employeeData.Add(new EmployeeShiftManagementData { Id = 75, RoleId = 2, DesignationId = 6, EmployeeId = 11, Subject = "Ava", StartTime = "2025-03-04T01:30:00.000Z", EndTime = "2025-03-04T09:30:00.000Z", Description = "Available (Morning Shift)", IsReadonly = true });
            employeeData.Add(new EmployeeShiftManagementData { Id = 76, RoleId = 2, DesignationId = 6, EmployeeId = 12, Subject = "Grace", StartTime = "2025-03-04T09:30:00.000Z", EndTime = "2025-03-04T17:30:00.000Z", Description = "Available (Evening Shift)", IsReadonly = true });
            employeeData.Add(new EmployeeShiftManagementData { Id = 77, RoleId = 2, DesignationId = 6, EmployeeId = 11, Subject = "Ava", StartTime = "2025-03-05T01:30:00.000Z", EndTime = "2025-03-05T09:30:00.000Z", Description = "Available (Morning Shift)" });
            employeeData.Add(new EmployeeShiftManagementData { Id = 78, RoleId = 2, DesignationId = 6, EmployeeId = 12, Subject = "Grace", StartTime = "2025-03-05T09:30:00.000Z", EndTime = "2025-03-05T17:30:00.000Z", Description = "Available (Evening Shift)" });
            employeeData.Add(new EmployeeShiftManagementData { Id = 79, RoleId = 2, DesignationId = 6, EmployeeId = 11, Subject = "Ava", StartTime = "2025-03-06T01:30:00.000Z", EndTime = "2025-03-06T09:30:00.000Z", Description = "Available (Morning Shift)" });
            employeeData.Add(new EmployeeShiftManagementData { Id = 80, RoleId = 2, DesignationId = 6, EmployeeId = 12, Subject = "Grace", StartTime = "2025-03-06T09:30:00.000Z", EndTime = "2025-03-06T17:30:00.000Z", Description = "Available (Evening Shift)" });
            employeeData.Add(new EmployeeShiftManagementData { Id = 81, RoleId = 2, DesignationId = 6, EmployeeId = 11, Subject = "Ava", StartTime = "2025-03-07T01:30:00.000Z", EndTime = "2025-03-07T09:30:00.000Z", Description = "Available (Morning Shift)" });
            employeeData.Add(new EmployeeShiftManagementData { Id = 82, RoleId = 2, DesignationId = 6, EmployeeId = 12, Subject = "Grace", StartTime = "2025-03-07T09:30:00.000Z", EndTime = "2025-03-07T17:30:00.000Z", Description = "Available (Evening Shift)" });
            employeeData.Add(new EmployeeShiftManagementData { Id = 83, RoleId = 2, DesignationId = 6, EmployeeId = 11, Subject = "Ava", StartTime = "2025-03-08T01:30:00.000Z", EndTime = "2025-03-08T09:30:00.000Z", Description = "Available (Morning Shift)" });
            employeeData.Add(new EmployeeShiftManagementData { Id = 84, RoleId = 2, DesignationId = 6, EmployeeId = 12, Subject = "Grace", StartTime = "2025-03-08T09:30:00.000Z", EndTime = "2025-03-08T17:30:00.000Z", Description = "Available (Evening Shift)" });
            employeeData.Add(new EmployeeShiftManagementData { Id = 85, RoleId = 3, DesignationId = 7, EmployeeId = 13, Subject = "James", StartTime = "2025-03-02T01:30:00.000Z", EndTime = "2025-03-02T09:30:00.000Z", Description = "Available (Morning Shift)", IsReadonly = true });
            employeeData.Add(new EmployeeShiftManagementData { Id = 86, RoleId = 3, DesignationId = 7, EmployeeId = 14, Subject = "Benjamin", StartTime = "2025-03-02T09:30:00.000Z", EndTime = "2025-03-02T17:30:00.000Z", Description = "Available (Evening Shift)", IsReadonly = true });
            employeeData.Add(new EmployeeShiftManagementData { Id = 87, RoleId = 3, DesignationId = 7, EmployeeId = 13, Subject = "James", StartTime = "2025-03-03T01:30:00.000Z", EndTime = "2025-03-03T09:30:00.000Z", Description = "Available (Morning Shift)", IsReadonly = true });
            employeeData.Add(new EmployeeShiftManagementData { Id = 88, RoleId = 3, DesignationId = 7, EmployeeId = 14, Subject = "Benjamin", StartTime = "2025-03-03T09:30:00.000Z", EndTime = "2025-03-03T17:30:00.000Z", Description = "Available (Evening Shift)", IsReadonly = true });
            employeeData.Add(new EmployeeShiftManagementData { Id = 89, RoleId = 3, DesignationId = 7, EmployeeId = 13, Subject = "James", StartTime = "2025-03-04T01:30:00.000Z", EndTime = "2025-03-04T09:30:00.000Z", Description = "Available (Morning Shift)", IsReadonly = true });
            employeeData.Add(new EmployeeShiftManagementData { Id = 90, RoleId = 3, DesignationId = 7, EmployeeId = 14, Subject = "Benjamin", StartTime = "2025-03-04T09:30:00.000Z", EndTime = "2025-03-04T17:30:00.000Z", Description = "Available (Evening Shift)", IsReadonly = true });
            employeeData.Add(new EmployeeShiftManagementData { Id = 91, RoleId = 3, DesignationId = 7, EmployeeId = 13, Subject = "James", StartTime = "2025-03-05T01:30:00.000Z", EndTime = "2025-03-05T09:30:00.000Z", Description = "Available (Morning Shift)" });
            employeeData.Add(new EmployeeShiftManagementData { Id = 92, RoleId = 3, DesignationId = 7, EmployeeId = 14, Subject = "Benjamin", StartTime = "2025-03-05T09:30:00.000Z", EndTime = "2025-03-05T17:30:00.000Z", Description = "Available (Evening Shift)" });
            employeeData.Add(new EmployeeShiftManagementData { Id = 93, RoleId = 3, DesignationId = 7, EmployeeId = 13, Subject = "James", StartTime = "2025-03-06T01:30:00.000Z", EndTime = "2025-03-06T09:30:00.000Z", Description = "Available (Morning Shift)" });
            employeeData.Add(new EmployeeShiftManagementData { Id = 94, RoleId = 3, DesignationId = 7, EmployeeId = 14, Subject = "Benjamin", StartTime = "2025-03-06T09:30:00.000Z", EndTime = "2025-03-06T17:30:00.000Z", Description = "Available (Evening Shift)" });
            employeeData.Add(new EmployeeShiftManagementData { Id = 95, RoleId = 3, DesignationId = 7, EmployeeId = 13, Subject = "James", StartTime = "2025-03-07T01:30:00.000Z", EndTime = "2025-03-07T09:30:00.000Z", Description = "Available (Morning Shift)" });
            employeeData.Add(new EmployeeShiftManagementData { Id = 96, RoleId = 3, DesignationId = 7, EmployeeId = 14, Subject = "Benjamin", StartTime = "2025-03-07T09:30:00.000Z", EndTime = "2025-03-07T17:30:00.000Z", Description = "Leave (Evening Shift)" });
            employeeData.Add(new EmployeeShiftManagementData { Id = 97, RoleId = 3, DesignationId = 7, EmployeeId = 13, Subject = "James", StartTime = "2025-03-08T01:30:00.000Z", EndTime = "2025-03-08T09:30:00.000Z", Description = "Available (Morning Shift)" });
            employeeData.Add(new EmployeeShiftManagementData { Id = 98, RoleId = 3, DesignationId = 7, EmployeeId = 14, Subject = "Benjamin", StartTime = "2025-03-08T09:30:00.000Z", EndTime = "2025-03-08T17:30:00.000Z", Description = "Available (Evening Shift)" });
            employeeData.Add(new EmployeeShiftManagementData { Id = 99, RoleId = 3, DesignationId = 8, EmployeeId = 15, Subject = "Olivia", StartTime = "2025-03-02T01:30:00.000Z", EndTime = "2025-03-02T09:30:00.000Z", Description = "Available (Morning Shift)", IsReadonly = true });
            employeeData.Add(new EmployeeShiftManagementData { Id = 100, RoleId = 3, DesignationId = 8, EmployeeId = 16, Subject = "Chloe", StartTime = "2025-03-02T09:30:00.000Z", EndTime = "2025-03-02T17:30:00.000Z", Description = "Available (Evening Shift)", IsReadonly = true });
            employeeData.Add(new EmployeeShiftManagementData { Id = 101, RoleId = 3, DesignationId = 8, EmployeeId = 15, Subject = "Olivia", StartTime = "2025-03-03T01:30:00.000Z", EndTime = "2025-03-03T09:30:00.000Z", Description = "Available (Morning Shift)", IsReadonly = true });
            employeeData.Add(new EmployeeShiftManagementData { Id = 102, RoleId = 3, DesignationId = 8, EmployeeId = 16, Subject = "Chloe", StartTime = "2025-03-03T09:30:00.000Z", EndTime = "2025-03-03T17:30:00.000Z", Description = "Available (Evening Shift)", IsReadonly = true });
            employeeData.Add(new EmployeeShiftManagementData { Id = 103, RoleId = 3, DesignationId = 8, EmployeeId = 15, Subject = "Olivia", StartTime = "2025-03-04T01:30:00.000Z", EndTime = "2025-03-04T09:30:00.000Z", Description = "Available (Morning Shift)", IsReadonly = true });
            employeeData.Add(new EmployeeShiftManagementData { Id = 104, RoleId = 3, DesignationId = 8, EmployeeId = 16, Subject = "Chloe", StartTime = "2025-03-04T09:30:00.000Z", EndTime = "2025-03-04T17:30:00.000Z", Description = "Available (Evening Shift)", IsReadonly = true });
            employeeData.Add(new EmployeeShiftManagementData { Id = 105, RoleId = 3, DesignationId = 8, EmployeeId = 15, Subject = "Olivia", StartTime = "2025-03-05T01:30:00.000Z", EndTime = "2025-03-05T09:30:00.000Z", Description = "Available (Morning Shift)" });
            employeeData.Add(new EmployeeShiftManagementData { Id = 106, RoleId = 3, DesignationId = 8, EmployeeId = 16, Subject = "Chloe", StartTime = "2025-03-05T09:30:00.000Z", EndTime = "2025-03-05T17:30:00.000Z", Description = "Available (Evening Shift)" });
            employeeData.Add(new EmployeeShiftManagementData { Id = 107, RoleId = 3, DesignationId = 8, EmployeeId = 15, Subject = "Olivia", StartTime = "2025-03-06T01:30:00.000Z", EndTime = "2025-03-06T09:30:00.000Z", Description = "Available (Morning Shift)" });
            employeeData.Add(new EmployeeShiftManagementData { Id = 108, RoleId = 3, DesignationId = 8, EmployeeId = 16, Subject = "Chloe", StartTime = "2025-03-06T09:30:00.000Z", EndTime = "2025-03-06T17:30:00.000Z", Description = "Available (Evening Shift)" });
            employeeData.Add(new EmployeeShiftManagementData { Id = 109, RoleId = 3, DesignationId = 8, EmployeeId = 15, Subject = "Olivia", StartTime = "2025-03-07T01:30:00.000Z", EndTime = "2025-03-07T09:30:00.000Z", Description = "Available (Morning Shift)" });
            employeeData.Add(new EmployeeShiftManagementData { Id = 110, RoleId = 3, DesignationId = 8, EmployeeId = 16, Subject = "Chloe", StartTime = "2025-03-07T09:30:00.000Z", EndTime = "2025-03-07T17:30:00.000Z", Description = "Available (Evening Shift - Swap-Request)" });
            employeeData.Add(new EmployeeShiftManagementData { Id = 111, RoleId = 3, DesignationId = 8, EmployeeId = 15, Subject = "Olivia", StartTime = "2025-03-08T01:30:00.000Z", EndTime = "2025-03-08T09:30:00.000Z", Description = "Available (Morning Shift - Swap-Request)" });
            employeeData.Add(new EmployeeShiftManagementData { Id = 112, RoleId = 3, DesignationId = 8, EmployeeId = 16, Subject = "Chloe", StartTime = "2025-03-08T09:30:00.000Z", EndTime = "2025-03-08T17:30:00.000Z", Description = "Available (Evening Shift)" });

            return employeeData;
        }

        public static List<RoleData> GetRoles()
        {
            return new List<RoleData>
            {
                new RoleData { Role = "Doctors", Id = 1 },
                new RoleData { Role = "Nurses", Id = 2 },
                new RoleData { Role = "Support Staffs", Id = 3 }
            };
        }

        public static List<DesignationData> GetDesignations()
        {
            return new List<DesignationData>
            {
                new DesignationData { Name = "Attending Physician", Id = 1, GroupId = 1 },
                new DesignationData { Name = "Hospitalist", Id = 2, GroupId = 1 },
                new DesignationData { Name = "General Pediatrician", Id = 3, GroupId = 1 },
                new DesignationData { Name = "Resident Doctor", Id = 4, GroupId = 1 },
                new DesignationData { Name = "Senior Nurse", Id = 5, GroupId = 2 },
                new DesignationData { Name = "Nurse Practitioner", Id = 6, GroupId = 2 },
                new DesignationData { Name = "Medical Assistant", Id = 7, GroupId = 3 },
                new DesignationData { Name = "Receptionist", Id = 8, GroupId = 3 }
            };
        }

        public static List<EmployeeImage> GetEmployeeImages()
        {
            return new List<EmployeeImage>
            {
                new EmployeeImage { Name = "John", Image = "../css/schedule/images/EmployeeShiftImage/robert.png" },
                new EmployeeImage { Name = "Nashil", Image = "../css/schedule/images/EmployeeShiftImage/nancy.png" },
                new EmployeeImage { Name = "Jennifer", Image = "../css/schedule/images/EmployeeShiftImage/jennifer.png" },
                new EmployeeImage { Name = "William", Image = "../css/schedule/images/EmployeeShiftImage/william.png" },
                new EmployeeImage { Name = "David", Image = "../css/schedule/images/EmployeeShiftImage/david.png" },
                new EmployeeImage { Name = "Michael", Image = "../css/schedule/images/EmployeeShiftImage/michael.png" },
                new EmployeeImage { Name = "Thomas", Image = "../css/schedule/images/EmployeeShiftImage/thomas.png" },
                new EmployeeImage { Name = "Daniel", Image = "../css/schedule/images/EmployeeShiftImage/robson.png" },
                new EmployeeImage { Name = "Mark", Image = "../css/schedule/images/EmployeeShiftImage/will-smith.png" },
                new EmployeeImage { Name = "Brian", Image = "../css/schedule/images/EmployeeShiftImage/brian@3x.png" },
                new EmployeeImage { Name = "Kevin", Image = "../css/schedule/images/EmployeeShiftImage/alice.png" },
                new EmployeeImage { Name = "Salman", Image = "../css/schedule/images/EmployeeShiftImage/salman@3x.png" },
                new EmployeeImage { Name = "Emma", Image = "../css/schedule/images/EmployeeShiftImage/emma.png" },
                new EmployeeImage { Name = "Lily", Image = "../css/schedule/images/EmployeeShiftImage/lily.png" },
                new EmployeeImage { Name = "Ava", Image = "../css/schedule/images/EmployeeShiftImage/ava.png" },
                new EmployeeImage { Name = "Grace", Image = "../css/schedule/images/EmployeeShiftImage/grace.png" },
                new EmployeeImage { Name = "Olivia", Image = "../css/schedule/images/EmployeeShiftImage/margaret.png" },
                new EmployeeImage { Name = "Zoe", Image = "../css/schedule/images/EmployeeShiftImage/laura.png" },
                new EmployeeImage { Name = "James", Image = "../css/schedule/images/EmployeeShiftImage/james.png" },
                new EmployeeImage { Name = "Benjamin", Image = "../css/schedule/images/EmployeeShiftImage/benjamin.png" },
                new EmployeeImage { Name = "Olivia", Image = "../css/schedule/images/EmployeeShiftImage/olivia.png" }, // Note: Duplicate name, adjust if needed
                new EmployeeImage { Name = "Chloe", Image = "../css/schedule/images/EmployeeShiftImage/chloe.png" },
                new EmployeeImage { Name = "Ricky", Image = "../css/schedule/images/EmployeeShiftImage/ricky.png" },
                new EmployeeImage { Name = "Jake", Image = "../css/schedule/images/EmployeeShiftImage/jake@3x.png" },
            };
        }
        public static List<StaffMember> GetDoctors()
        {
            return new List<StaffMember>
            {
                new StaffMember { Id = 1, Name = "Mark",   Description = "Attending Physician",   Role = "Doctors" },
                new StaffMember { Id = 2, Name = "Brian",  Description = "Hospitalist",           Role = "Doctors" },
                new StaffMember { Id = 3, Name = "Kevin",  Description = "General Pediatrician",  Role = "Doctors" },
                new StaffMember { Id = 4, Name = "Salman", Description = "Resident Doctor",       Role = "Doctors" }
            };
        }

        public static List<StaffMember> GetNurses()
        {
            return new List<StaffMember>
            {
                new StaffMember { Id = 5, Name = "Olivia", Description = "Senior Nurse",        Role = "Nurses" },
                new StaffMember { Id = 6, Name = "Zoe",    Description = "Nurse Practitioner", Role = "Nurses" }
            };
        }

        public static List<StaffMember> GetStaffs()
        {
            return new List<StaffMember>
            {
                new StaffMember { Id = 7, Name = "Ricky", Description = "Medical Assistant",  Role = "Support Staffs" },
                new StaffMember { Id = 8, Name = "Jake",  Description = "Receptionist",       Role = "Support Staffs" }
            };
        }

        public static Dictionary<string, string> GetImageMap()
        {
            return new Dictionary<string, string>
            {
                ["mark"] = "../css/schedule/images/EmployeeShiftImage/will-smith.png",
                ["brian"] = "../css/schedule/images/EmployeeShiftImage/brian@3x.png",
                ["kevin"] = "../css/schedule/images/EmployeeShiftImage/alice.png",
                ["salman"] = "../css/schedule/images/EmployeeShiftImage/salman@3x.png",
                ["olivia"] = "../css/schedule/images/EmployeeShiftImage/margaret.png",
                ["zoe"] = "../css/schedule/images/EmployeeShiftImage/laura.png",
                ["ricky"] = "../css/schedule/images/EmployeeShiftImage/ricky.png",
                ["jake"] = "../css/schedule/images/EmployeeShiftImage/jake@3x.png"
            };
        }
    }
}
