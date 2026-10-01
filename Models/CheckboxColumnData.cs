using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EJ2CoreSampleBrowser.Models
{
    public class CheckboxColumnData
    {
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public string Assignee { get; set; }
        public string Designation { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public double Progress { get; set; }
        public bool Expanded { get; set; }
        public List<CheckboxColumnData> SubTasks { get; set; }

        public static List<CheckboxColumnData> GetCheckboxColumnData()
        {
            List<CheckboxColumnData> data = new List<CheckboxColumnData>();

            data.Add(new CheckboxColumnData()
            {
                TaskID = 1,
                TaskName = "Project Planning",
                Assignee = "Emma Wilson",
                Designation = "Project Manager",
                Priority = "High",
                Status = "In Progress",
                Progress = 0.85,
                Expanded = true,
                SubTasks = new List<CheckboxColumnData>()
                {
                    new CheckboxColumnData()
                    {
                        TaskID = 2,
                        TaskName = "Requirements Discovery",
                        Assignee = "David Brown",
                        Designation = "Team Lead",
                        Priority = "High",
                        Status = "In Progress",
                        Progress = 0.90,
                        Expanded = true,
                        SubTasks = new List<CheckboxColumnData>()
                        {
                            new CheckboxColumnData() { TaskID = 3, TaskName = "Information Gathering", Assignee = "Ethan Walker", Designation = "Senior Business Analyst", Priority = "High", Status = "Completed", Progress = 1.0 },
                            new CheckboxColumnData() { TaskID = 4, TaskName = "Stakeholder Workshops", Assignee = "Olivia Taylor", Designation = "Business Analyst", Priority = "Medium", Status = "Completed", Progress = 1.0 },
                            new CheckboxColumnData() { TaskID = 5, TaskName = "Scope Definition", Assignee = "James Scott", Designation = "Junior Business Analyst", Priority = "Low", Status = "In Progress", Progress = 0.75 }
                        }
                    },
                    new CheckboxColumnData()
                    {
                        TaskID = 6,
                        TaskName = "Budget and Resources",
                        Assignee = "Michael Lee",
                        Designation = "Resource Planning Lead",
                        Priority = "Medium",
                        Status = "In Progress",
                        Progress = 0.80,
                        Expanded = true,
                        SubTasks = new List<CheckboxColumnData>()
                        {
                            new CheckboxColumnData() { TaskID = 7, TaskName = "Budget Approval", Assignee = "Charlotte Davis", Designation = "Senior Finance Analyst", Priority = "Medium", Status = "Completed", Progress = 1.0 },
                            new CheckboxColumnData() { TaskID = 8, TaskName = "Team Allocation", Assignee = "Benjamin Clark", Designation = "Resource Coordinator", Priority = "Low", Status = "In Progress", Progress = 0.75 },
                            new CheckboxColumnData() { TaskID = 9, TaskName = "Resource Planning", Assignee = "Ava Harris", Designation = "Junior Resource Analyst", Priority = "Low", Status = "In Progress", Progress = 0.60 }
                        }
                    },
                    new CheckboxColumnData() { TaskID = 10, TaskName = "Planning Sign-off", Assignee = "Emma Wilson", Designation = "Project Manager", Priority = "Low", Status = "Not Started", Progress = 0.0 }
                }
            });

            data.Add(new CheckboxColumnData()
            {
                TaskID = 11,
                TaskName = "Design and Review",
                Assignee = "Sophia Clark",
                Designation = "Design Manager",
                Priority = "High",
                Status = "In Progress",
                Progress = 0.78,
                Expanded = true,
                SubTasks = new List<CheckboxColumnData>()
                {
                    new CheckboxColumnData()
                    {
                        TaskID = 12,
                        TaskName = "Solution Design",
                        Assignee = "Liam Moore",
                        Designation = "Solution Design Lead",
                        Priority = "High",
                        Status = "In Progress",
                        Progress = 0.80,
                        Expanded = true,
                        SubTasks = new List<CheckboxColumnData>()
                        {
                            new CheckboxColumnData() { TaskID = 13, TaskName = "Architecture Design", Assignee = "Noah Hall", Designation = "Senior Solutions Architect", Priority = "High", Status = "Completed", Progress = 1.0 },
                            new CheckboxColumnData() { TaskID = 14, TaskName = "Process Mapping", Assignee = "Mia Young", Designation = "Business Process Analyst", Priority = "Medium", Status = "In Progress", Progress = 0.70 },
                            new CheckboxColumnData() { TaskID = 15, TaskName = "Design Review", Assignee = "Liam Moore", Designation = "Solution Design Lead", Priority = "Low", Status = "Under Review", Progress = 0.75 }
                        }
                    },
                    new CheckboxColumnData()
                    {
                        TaskID = 16,
                        TaskName = "Experience Design",
                        Assignee = "Ava Harris",
                        Designation = "UX Lead",
                        Priority = "Medium",
                        Status = "In Progress",
                        Progress = 0.75,
                        Expanded = true,
                        SubTasks = new List<CheckboxColumnData>()
                        {
                            new CheckboxColumnData() { TaskID = 17, TaskName = "Wireframe Design", Assignee = "Lucas King", Designation = "Senior UX Designer", Priority = "Medium", Status = "Completed", Progress = 1.0 },
                            new CheckboxColumnData() { TaskID = 18, TaskName = "User Interface Design", Assignee = "Grace Allen", Designation = "UX Designer", Priority = "Low", Status = "In Progress", Progress = 0.75 },
                            new CheckboxColumnData() { TaskID = 19, TaskName = "Design Approval", Assignee = "Henry Adams", Designation = "Junior UX Designer", Priority = "Low", Status = "Not Started", Progress = 0.0 }
                        }
                    },
                    new CheckboxColumnData() { TaskID = 20, TaskName = "Design Sign-off", Assignee = "Sophia Clark", Designation = "Design Manager", Priority = "Low", Status = "Not Started", Progress = 0.0 }
                }
            });

            data.Add(new CheckboxColumnData()
            {
                TaskID = 21,
                TaskName = "Execution",
                Assignee = "Emma Wilson",
                Designation = "Program Manager",
                Priority = "Critical",
                Status = "In Progress",
                Progress = 0.60,
                Expanded = true,
                SubTasks = new List<CheckboxColumnData>()
                {
                    new CheckboxColumnData()
                    {
                        TaskID = 22,
                        TaskName = "Workstream A",
                        Assignee = "Michael Lee",
                        Designation = "Delivery Manager",
                        Priority = "High",
                        Status = "In Progress",
                        Progress = 0.65,
                        Expanded = true,
                        SubTasks = new List<CheckboxColumnData>()
                        {
                            new CheckboxColumnData()
                            {
                                TaskID = 23,
                                TaskName = "Delivery Package A",
                                Assignee = "Benjamin Clark",
                                Designation = "Technical Lead",
                                Priority = "High",
                                Status = "In Progress",
                                Progress = 0.70,
                                Expanded = true,
                                SubTasks = new List<CheckboxColumnData>()
                                {
                                    new CheckboxColumnData() { TaskID = 24, TaskName = "Core Implementation", Assignee = "Ethan Walker", Designation = "Senior Software Engineer", Priority = "High", Status = "In Progress", Progress = 0.65 },
                                    new CheckboxColumnData() { TaskID = 25, TaskName = "Data Configuration", Assignee = "Sophia Clark", Designation = "Software Engineer", Priority = "High", Status = "In Progress", Progress = 0.50 },
                                    new CheckboxColumnData() { TaskID = 26, TaskName = "Validation Review", Assignee = "Olivia Taylor", Designation = "Senior QA Engineer", Priority = "Medium", Status = "Under Review", Progress = 0.75 },
                                    new CheckboxColumnData() { TaskID = 27, TaskName = "Issue Resolution", Assignee = "James Scott", Designation = "Junior Software Engineer", Priority = "Medium", Status = "In Progress", Progress = 0.40 },
                                    new CheckboxColumnData() { TaskID = 28, TaskName = "Package Completion", Assignee = "David Parker", Designation = "Software Engineering Intern", Priority = "Low", Status = "Not Started", Progress = 0.0 }
                                }
                            }
                        }
                    },
                    new CheckboxColumnData()
                    {
                        TaskID = 29,
                        TaskName = "Workstream B",
                        Assignee = "Charlotte Davis",
                        Designation = "Delivery Manager",
                        Priority = "High",
                        Status = "In Progress",
                        Progress = 0.55,
                        Expanded = true,
                        SubTasks = new List<CheckboxColumnData>()
                        {
                            new CheckboxColumnData()
                            {
                                TaskID = 30,
                                TaskName = "Delivery Package B",
                                Assignee = "Noah Hall",
                                Designation = "Technical Lead",
                                Priority = "High",
                                Status = "In Progress",
                                Progress = 0.60,
                                Expanded = true,
                                SubTasks = new List<CheckboxColumnData>()
                                {
                                    new CheckboxColumnData() { TaskID = 31, TaskName = "Core Implementation", Assignee = "Daniel Hill", Designation = "Senior Software Engineer", Priority = "High", Status = "In Progress", Progress = 0.60 },
                                    new CheckboxColumnData() { TaskID = 32, TaskName = "Data Configuration", Assignee = "Mia Young", Designation = "Software Engineer", Priority = "Medium", Status = "In Progress", Progress = 0.45 },
                                    new CheckboxColumnData() { TaskID = 33, TaskName = "Validation Review", Assignee = "Amelia Green", Designation = "QA Engineer", Priority = "Medium", Status = "Under Review", Progress = 0.50 },
                                    new CheckboxColumnData() { TaskID = 34, TaskName = "Issue Resolution", Assignee = "Lucas King", Designation = "Junior Software Engineer", Priority = "Low", Status = "Blocked", Progress = 0.20 },
                                    new CheckboxColumnData() { TaskID = 35, TaskName = "Package Completion", Assignee = "Harper Baker", Designation = "Software Engineering Intern", Priority = "Low", Status = "Not Started", Progress = 0.0 }
                                }
                            }
                        }
                    },
                    new CheckboxColumnData() { TaskID = 36, TaskName = "Status Reporting", Assignee = "Emma Wilson", Designation = "Program Manager", Priority = "Medium", Status = "In Progress", Progress = 0.50 }
                }
            });

            data.Add(new CheckboxColumnData()
            {
                TaskID = 37,
                TaskName = "Validation",
                Assignee = "Olivia Taylor",
                Designation = "Quality Manager",
                Priority = "High",
                Status = "In Progress",
                Progress = 0.52,
                Expanded = true,
                SubTasks = new List<CheckboxColumnData>()
                {
                    new CheckboxColumnData()
                    {
                        TaskID = 38,
                        TaskName = "Verification",
                        Assignee = "Amelia Green",
                        Designation = "Quality Lead",
                        Priority = "Medium",
                        Status = "In Progress",
                        Progress = 0.55,
                        Expanded = true,
                        SubTasks = new List<CheckboxColumnData>()
                        {
                            new CheckboxColumnData() { TaskID = 39, TaskName = "Quality Review", Assignee = "Ethan Walker", Designation = "Senior QA Engineer", Priority = "Medium", Status = "In Progress", Progress = 0.50 },
                            new CheckboxColumnData() { TaskID = 40, TaskName = "Compliance Check", Assignee = "Benjamin Clark", Designation = "Compliance Analyst", Priority = "Medium", Status = "Under Review", Progress = 0.50 },
                            new CheckboxColumnData() { TaskID = 41, TaskName = "Issue Resolution", Assignee = "Noah Hall", Designation = "Junior QA Engineer", Priority = "Low", Status = "In Progress", Progress = 0.50 }
                        }
                    },
                    new CheckboxColumnData() { TaskID = 42, TaskName = "Acceptance Review", Assignee = "Emma Wilson", Designation = "Program Manager", Priority = "Low", Status = "Not Started", Progress = 0.0 }
                }
            });

            data.Add(new CheckboxColumnData()
            {
                TaskID = 43,
                TaskName = "Closure",
                Assignee = "Emma Wilson",
                Designation = "Program Manager",
                Priority = "Medium",
                Status = "Not Started",
                Progress = 0.10,
                Expanded = true,
                SubTasks = new List<CheckboxColumnData>()
                {
                    new CheckboxColumnData() { TaskID = 44, TaskName = "Knowledge Transfer", Assignee = "Michael Lee", Designation = "Operations Lead", Priority = "Medium", Status = "Not Started", Progress = 0.0 },
                    new CheckboxColumnData() { TaskID = 45, TaskName = "Operational Handover", Assignee = "Charlotte Davis", Designation = "Senior Operations Analyst", Priority = "Medium", Status = "Not Started", Progress = 0.0 },
                    new CheckboxColumnData() { TaskID = 46, TaskName = "Final Documentation", Assignee = "James Scott", Designation = "Documentation Specialist", Priority = "Low", Status = "Completed", Progress = 1.0 }
                }
            });

            return data;
        }
    }
}