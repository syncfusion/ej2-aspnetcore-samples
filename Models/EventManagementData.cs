#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace EJ2CoreSampleBrowser.Models
{
    public class Speaker
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Note { get; set; }
    }
    public class EventManagementData
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Subject { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int RoomId { get; set; }
        public int Capacity { get; set; }
        public List<Speaker> Speakers { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
        public string EventType { get; set; }
        public string TargetAudience { get; set; }
        public string EventLevel { get; set; }
        public List<string> EventTags { get; set; }
    }
    public class RoomData
    {
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public string RoomColor { get; set; }
        public int RoomCapacity { get; set; }
    }
    public class Room
    {
        public int RoomId { get; set; }
        public string RoomName { get; set; }
    }

    public class DropDownItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public static class EventManagementDataSource
    {
        public static List<EventManagementData> GetEventData()
        {
            return new List<EventManagementData>
            {
                new EventManagementData {
                    Id = 1,
                    Title = "AI for Business Automation",
                    Subject = "The Impact of AI on Business Efficiency",
                    StartTime = "2025-02-24T03:30:00Z",
                    EndTime = "2025-02-24T04:30:00Z",
                    RoomId = 1,
                    Capacity = 80,
                    Speakers = new List<Speaker> {
                        new Speaker {
                            Name = "Liam Johnson",
                            Title = "AI Specialist",
                            Note = "Exploring how AI is transforming business processes and increasing efficiency."
                        }
                    },
                    Description = "Overview of AI and how it’s transforming business operations, enhancing productivity, and driving innovation.",
                    Duration = "1 hour",
                    EventType = "Technical Session",
                    TargetAudience = "Developers, Engineers, Business Analysts",
                    EventLevel = "Intermediate",
                    EventTags = new List<string> { "Artificial Intelligence", "Business Automation", "Machine Learning" }
                },
                new EventManagementData {
                    Id = 2,
                    Title = "AI for Business Automation",
                    Subject = "Short Break for Relaxation",
                    StartTime = "2025-02-24T04:30:00Z",
                    EndTime = "2025-02-24T05:00:00Z",
                    RoomId = 1,
                    Capacity = 80,
                    Speakers = new List<Speaker>(),
                    Description = "Take a short break to refresh and network with fellow attendees.",
                    Duration = "30 minutes",
                    EventType = "Break",
                    TargetAudience = "All attendees",
                    EventLevel = "All levels",
                    EventTags = new List<string> { "Networking", "Relaxation" }
                },
                new EventManagementData {
                    Id= 3,
                    Title= "AI for Business Automation",
                    Subject= "AI-Driven Business Intelligence: Improving Decision-Making",
                    StartTime= "2025-02-24T05:00:00.000Z",
                    EndTime= "2025-02-24T05:50:00.000Z",
                    RoomId= 1,
                    Capacity= 80,
                    Speakers=new List<Speaker> {
                        new Speaker{
                            Name= "Liam Johnson",
                            Title= "AI Specialist",
                            Note= "How AI and machine learning enhance business intelligence tools for smarter decision-making."
                        }
                    },
                    Description= "How AI and machine learning enhance business intelligence tools to make better, more data-driven decisions.",
                    Duration= "30 minutes",
                    EventType= "Technical Session",
                    TargetAudience= "Developers, Engineers, Business Analysts",
                    EventLevel= "Intermediate",
                    EventTags= ["Artificial Intelligence", "Business Intelligence", "Machine Learning"]
                },
                new EventManagementData {
                    Id= 4,
                    Title= "AI for Business Automation",
                    Subject= "Implementing AI-Powered Automation in Business",
                    StartTime= "2025-02-24T06:00:00.000Z",
                    EndTime= "2025-02-24T06:30:00.000Z",
                    RoomId= 1,
                    Capacity= 80,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Liam Johnson",
                            Title= "AI Specialist",
                            Note= "A deep dive into real-world applications of AI-powered automation in various industries."
                        }
                    },
                    Description= "Exploring real-world applications of AI-powered automation in various sectors, including customer service, logistics, and marketing.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Developers, Engineers, Business Analysts",
                    EventLevel= "Intermediate",
                    EventTags= ["Artificial Intelligence", "Automation", "Machine Learning"]
                },
                new EventManagementData {
                    Id= 5,
                    Title= "AI for Business Automation",
                    Subject= "Networking and Lunch",
                    StartTime= "2025-02-24T06:30:00.000Z",
                    EndTime= "2025-02-24T07:30:00.000Z",
                    RoomId= 1,
                    Capacity= 80,
                    Speakers= new List<Speaker>(),
                    Description= "Enjoy lunch and connect with peers during the break.",
                    Duration= "1 hour",
                    EventType= "Break",
                    TargetAudience= "All attendees",
                    EventLevel= "All levels",
                    EventTags= ["Networking", "Lunch"]
                },
                new EventManagementData {
                    Id= 6,
                    Title= "AI for Business Automation",
                    Subject= "AI for Customer Engagement and Personalization",
                    StartTime= "2025-02-24T07:30:00.000Z",
                    EndTime= "2025-02-24T09:30:00.000Z",
                    RoomId= 1,
                    Capacity= 80,
                    Speakers= new List<Speaker> {
                         new Speaker{
                            Name= "Liam Johnson",
                            Title= "AI Specialist",
                            Note= "Using AI to create personalized customer experiences through targeted recommendations and services."
                        },
                         new Speaker{
                            Name= "Sophia Collins",
                            Title= "Customer Experience Strategist",
                            Note= "Specializing in integrating AI for enhancing customer engagement and building personalized journeys."
                        }
                    },
                    Description= "Discussing the application of AI in creating personalized customer experiences, such as product recommendations and tailored content.",
                    Duration= "2 hours",
                    EventType= "Technical Session",
                    TargetAudience= "Developers, Engineers, Business Analysts",
                    EventLevel= "Intermediate",
                    EventTags= ["Artificial Intelligence", "Customer Engagement", "Personalization"]
                },
                new EventManagementData {
                    Id= 7,
                    Title= "AI for Business Automation",
                    Subject= "Coffee Break and Networking",
                    StartTime= "2025-02-24T09:30:00.000Z",
                    EndTime= "2025-02-24T10:00:00.000Z",
                    RoomId= 1,
                    Capacity= 80,
                    Speakers= new List<Speaker>(),
                    Description= "Enjoy a coffee break and network with your peers.",
                    Duration= "30 minutes",
                    EventType= "Break",
                    TargetAudience= "All participants",
                    EventLevel= "All levels",
                    EventTags= ["Networking", "Coffee Break"]
                },
                new EventManagementData {
                    Id= 8,
                    Title= "AI for Business Automation",
                    Subject= "Implementing AI-Powered Automation in Business",
                    StartTime= "2025-02-24T10:00:00.000Z",
                    EndTime= "2025-02-24T11:00:00.000Z",
                    RoomId= 1,
                    Capacity= 80,
                    Speakers= new List<Speaker> {
                         new Speaker{
                            Name= "Liam Johnson",
                            Title= "AI Specialist",
                            Note= "A deep dive into real-world applications of AI-powered automation in various industries."
                        }
                    },
                    Description= "Exploring real-world applications of AI-powered automation in various sectors, including customer service, logistics, and marketing.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Developers, Engineers, Business Analysts",
                    EventLevel= "Intermediate",
                    EventTags= ["Artificial Intelligence", "Automation", "Machine Learning"]
                },
                new EventManagementData {
                    Id= 9,
                    Title= "AI for Business Automation",
                    Subject= "Panel Discussion: The Future of AI in Business Automation",
                    StartTime= "2025-02-24T11:30:00.000Z",
                    EndTime= "2025-02-24T12:30:00.000Z",
                    RoomId= 1,
                    Capacity= 80,
                    Speakers=new List<Speaker> {
                         new Speaker{
                            Name= "Liam Johnson",
                            Title= "AI Specialist",
                            Note= "Industry experts discuss the next big steps for AI technologies in business automation and upcoming trends."
                        },
                         new Speaker{
                            Name= "Sophia Collins",
                            Title= "Machine Learning Expert",
                            Note= "Insights into the future impact of AI on industries such as retail, healthcare, and logistics."
                        }
                    },
                    Description= "Panel discussion featuring industry experts who share their insights into the future of AI in business automation.",
                    Duration= "1 hour",
                    EventType= "Panel Discussion",
                    TargetAudience= "Developers, Engineers, Business Analysts, Managers",
                    EventLevel= "Advanced",
                    EventTags= ["Artificial Intelligence", "Business Automation", "Future Trends"]
                },
                new EventManagementData {
                    Id= 10,
                    Title= "Database Systems and Data Management",
                    Subject= "Introduction to Relational Databases",
                    StartTime= "2025-02-24T03:45:00.000Z",
                    EndTime= "2025-02-24T05:00:00.000Z",
                    RoomId= 2,
                    Capacity= 150,
                    Speakers= new List<Speaker> {
                         new Speaker{
                            Name= "James White",
                            Title= "Database Expert",
                            Note= "Understanding the foundations of relational databases and their role in business."
                        }
                    },
                    Description= "This session will introduce the fundamentals of relational databases and how they’re applied in modern enterprises.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Developers, Database Administrators, Data Analysts",
                    EventLevel= "Beginner",
                    EventTags= ["Database Management", "SQL", "Data Modeling"]
                },
                new EventManagementData {
                    Id= 11,
                    Title= "Database Systems and Data Management",
                    Subject= "Optimizing SQL Queries for Performance",
                    StartTime= "2025-02-24T05:30:00.000Z",
                    EndTime= "2025-02-24T06:00:00.000Z",
                    RoomId= 2,
                    Capacity= 150,
                    Speakers= new List<Speaker> {
                         new Speaker{
                            Name= "James White",
                            Title= "Database Expert",
                            Note= "Techniques and strategies for improving the performance of SQL queries in large databases."
                        }
                    },
                    Description= "In this session, we will dive into SQL query optimization strategies to enhance database performance.",
                    Duration= "30 minutes",
                    EventType= "Technical Session",
                    TargetAudience= "Database Administrators, Developers, Data Engineers",
                    EventLevel= "Intermediate",
                    EventTags= ["SQL Optimization", "Performance Tuning", "Database Administration"]
                },
                new EventManagementData {
                    Id= 12,
                    Title= "Database Systems and Data Management",
                    Subject= "Database Security Best Practices",
                    StartTime= "2025-02-24T06:00:00.000Z",
                    EndTime= "2025-02-24T07:00:00.000Z",
                    RoomId= 2,
                    Capacity= 150,
                    Speakers= new List<Speaker> {
                         new Speaker{
                            Name= "Sophia Green",
                            Title= "Security Analyst",
                            Note= "Exploring best practices for securing databases and ensuring the protection of sensitive data."
                        }
                    },
                    Description= "Learn the best practices for securing databases, including encryption, access control, and backup strategies.",
                    Duration= "1 hour 30 minutes",
                    EventType= "Technical Session",
                    TargetAudience= "Security Engineers, Database Administrators, IT Professionals",
                    EventLevel= "Intermediate",
                    EventTags= ["Database Security", "Encryption", "Data Protection"]
                },
                new EventManagementData {
                    Id= 13,
                    Title= "Database Systems and Data Management",
                    Subject= "Advanced Database Architectures",
                    StartTime= "2025-02-24T08:00:00.000Z",
                    EndTime= "2025-02-24T09:00:00.000Z",
                    RoomId= 2,
                    Capacity= 150,
                    Speakers= new List<Speaker> {
                         new Speaker{
                            Name= "James White",
                            Title= "Database Expert",
                            Note= "Exploring next-generation database architectures, including NoSQL and distributed databases."
                        }
                    },
                    Description= "A deep dive into the most advanced database architectures and how they are being applied in the modern world.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Database Architects, Developers, Engineers",
                    EventLevel= "Advanced",
                    EventTags= ["NoSQL", "Distributed Databases", "Database Design"]
                },
                new EventManagementData {
                    Id= 14,
                    Title= "Database Systems and Data Management",
                    Subject= "Database Troubleshooting and Performance Monitoring",
                    StartTime= "2025-02-24T09:00:00.000Z",
                    EndTime= "2025-02-24T09:30:00.000Z",
                    RoomId= 2,
                    Capacity= 150,
                    Speakers= new List<Speaker> {
                         new Speaker{
                            Name= "Sophia Green",
                            Title= "Database Administrator",
                            Note= "Techniques and tools for troubleshooting database performance issues in a live environment."
                        }
                    },
                    Description= "Learn to troubleshoot and monitor databases effectively, ensuring seamless database performance.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Database Administrators, System Engineers, IT Support",
                    EventLevel= "Advanced",
                    EventTags= ["Database Performance", "Troubleshooting", "Monitoring"]
                },
                new EventManagementData {
                    Id= 15,
                    Subject= "Break",
                    StartTime= "2025-02-24T09:30:00.000Z",
                    EndTime= "2025-02-24T10:00:00.000Z",
                    RoomId= 2,
                    Capacity= 150,
                    Speakers= new List<Speaker>(),
                    Description= "Short break to relax and network.",
                    Duration= "30 minutes",
                    EventType= "Break",
                    TargetAudience= "All Participants",
                    EventLevel= "All Levels",
                    EventTags= ["Networking", "Relax"]
                },
                new EventManagementData {
                    Id= 16,
                    Title= "Database Systems and Data Management",
                    Subject= "Panel Discussion: The Future of Databases",
                    StartTime= "2025-02-24T10:00:00.000Z",
                    EndTime= "2025-02-24T12:00:00.000Z",
                    RoomId= 2,
                    Capacity= 150,
                    Speakers= new List<Speaker> {
                         new Speaker{
                            Name= "James White",
                            Title= "Database Expert",
                            Note= "A panel discussion featuring experts in database technology and their visions of the future of databases."
                        },
                         new Speaker{
                            Name= "Sophia Green",
                            Title= "Security Analyst",
                            Note= "Security concerns and the next wave of database technology."
                        }
                    },
                    Description= "Panel discussion exploring emerging trends, new database technologies, and the future of data management.",
                    Duration= "1 hour",
                    EventType= "Panel Discussion",
                    TargetAudience= "Developers, Data Scientists, Database Administrators",
                    EventLevel= "Advanced",
                    EventTags= ["Future of Databases", "Emerging Trends", "Panel Discussion"]
                },
                new EventManagementData {
                    Id= 17,
                    Title= "Networking Strategies for Tech Professionals",
                    Subject= "Building a Professional Network in Tech",
                    StartTime= "2025-02-24T03:30:00.000Z",
                    EndTime= "2025-02-24T05:00:00.000Z",
                    RoomId= 3,
                    Capacity= 300,
                    Speakers= new List<Speaker> {
                         new Speaker{
                            Name= "Ella Roberts",
                            Title= "Tech Networking Specialist",
                            Note= "Strategies for building meaningful professional relationships within the technology industry."
                        }
                    },
                    Description= "This session covers effective strategies for building a professional network in the tech industry.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Tech Professionals, Entrepreneurs, Developers",
                    EventLevel= "Beginner",
                    EventTags= ["Networking", "Career Development", "Professional Growth"]
                },
                new EventManagementData {
                    Id= 18,
                    Title= "Networking Strategies for Tech Professionals",
                    Subject= "Leveraging LinkedIn for Professional Networking",
                    StartTime= "2025-02-24T05:30:00.000Z",
                    EndTime= "2025-02-24T06:45:00.000Z",
                    RoomId= 3,
                    Capacity= 300,
                    Speakers= new List<Speaker> {
                         new Speaker{
                            Name= "Ella Roberts",
                            Title= "Tech Networking Specialist",
                            Note= "Learn how to use LinkedIn to connect with professionals and enhance career opportunities."
                        }
                    },
                    Description= "A session focused on utilizing LinkedIn to build a strong professional network and increase career opportunities.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Developers, Entrepreneurs, Job Seekers",
                    EventLevel= "Beginner",
                    EventTags= ["Networking", "LinkedIn", "Career Growth"]
                },
                new EventManagementData {
                    Id= 19,
                    Title= "Networking Strategies for Tech Professionals",
                    Subject= "Networking at Conferences and Meetups",
                    StartTime= "2025-02-24T07:00:00.000Z",
                    EndTime= "2025-02-24T08:30:00.000Z",
                    RoomId= 3,
                    Capacity= 300,
                    Speakers= new List<Speaker> {
                         new Speaker{
                            Name= "Ella Roberts",
                            Title= "Tech Networking Specialist",
                            Note= "Practical advice on making meaningful connections at conferences and tech meetups."
                        }
                    },
                    Description= "Tech professionals will learn how to make lasting connections while attending conferences and meetups.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Developers, Entrepreneurs, Tech Enthusiasts",
                    EventLevel= "Intermediate",
                    EventTags= ["Networking", "Conferences", "Tech Meetups"]
                },
                new EventManagementData {
                    Id= 20,
                    Title= "Networking Strategies for Tech Professionals",
                    Subject= "Building an Online Presence for Career Growth",
                    StartTime= "2025-02-24T09:30:00.000Z",
                    EndTime= "2025-02-24T11:30:00.000Z",
                    RoomId= 3,
                    Capacity= 300,
                    Speakers= new List<Speaker> {
                         new Speaker{
                            Name= "Ella Roberts",
                            Title= "Tech Networking Specialist",
                            Note= "Learn how to build and leverage an online presence to boost your career in the tech industry."
                        }
                    },
                    Description= "Building an online presence is key to career growth in tech. This session will teach participants how to do it effectively.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Developers, Entrepreneurs, Job Seekers",
                    EventLevel= "Intermediate",
                    EventTags= ["Networking", "Online Presence", "Career Growth"]
                },
                new EventManagementData {
                    Id= 21,
                    Title= "Cloud Computing and Architecture",
                    Subject= "Introduction to Cloud Computing",
                    StartTime= "2025-02-24T03:30:00.000Z",
                    EndTime= "2025-02-24T04:30:00.000Z",
                    RoomId= 4,
                    Capacity= 320,
                    Speakers= new List<Speaker> {
                         new Speaker{
                            Name= "David Miller",
                            Title= "Cloud Architect",
                            Note= "Exploring the fundamentals of cloud computing and its impact on business and technology."
                        }
                    },
                    Description= "This session provides an introduction to cloud computing, its advantages, and the different cloud service models.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Developers, Engineers, IT Architects",
                    EventLevel= "Beginner",
                    EventTags= ["Cloud Computing", "Cloud Services", "Infrastructure as a Service"]
                },
                new EventManagementData {
                    Id= 22,
                    Title= "Cloud Computing and Architecture",
                    Subject= "Choosing the Right Cloud Provider for Your Business",
                    StartTime= "2025-02-24T05:00:00.000Z",
                    EndTime= "2025-02-24T05:30:00.000Z",
                    RoomId= 4,
                    Capacity= 320,
                    Speakers= new List<Speaker> {
                         new Speaker{
                            Name= "David Miller",
                            Title= "Cloud Architect",
                            Note= "Guidelines for selecting the right cloud provider based on business needs and scalability."
                        }
                    },
                    Description= "This session will help you evaluate cloud providers and choose the best option for your organization.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "IT Decision Makers, Developers, Engineers",
                    EventLevel= "Intermediate",
                    EventTags= ["Cloud Providers", "Cloud Architecture", "Scalability"]
                },
                new EventManagementData {
                    Id= 23,
                    Title= "Cloud Computing and Architecture",
                    Subject= "Building Scalable Cloud Architectures",
                    StartTime= "2025-02-24T05:30:00.000Z",
                    EndTime= "2025-02-24T06:30:00.000Z",
                    RoomId= 4,
                    Capacity= 320,
                    Speakers= new List<Speaker> {
                         new Speaker{
                            Name= "Emily Walker",
                            Title= "Cloud Solutions Architect",
                            Note= "Learn how to design and deploy scalable cloud infrastructures for modern applications."
                        }
                    },
                    Description= "In this session, you will learn best practices for building scalable and resilient cloud architectures.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Cloud Architects, Developers, IT Engineers",
                    EventLevel= "Intermediate",
                    EventTags= ["Cloud Architecture", "Scalability", "Cloud Solutions"]
                },
                new EventManagementData {
                    Id= 24,
                    Title= "Cloud Computing and Architecture",
                    Subject= "Lunch Break",
                    StartTime= "2025-02-24T06:30:00.000Z",
                    EndTime= "2025-02-24T07:30:00.000Z",
                    RoomId= 4,
                    Capacity= 320,
                    Speakers= new List<Speaker>(),
                    Description= "Lunch Break for attendees to relax and network.",
                    Duration= "1 hour",
                    EventType= "Break",
                    TargetAudience= "All attendees",
                    EventLevel= "All levels",
                    EventTags= ["Networking", "Break"]
                },
                new EventManagementData {
                    Id= 25,
                    Title= "Cloud Computing and Architecture",
                    Subject= "Cloud Security Best Practices",
                    StartTime= "2025-02-24T07:30:00.000Z",
                    EndTime= "2025-02-24T08:30:00.000Z",
                    RoomId= 4,
                    Capacity= 320,
                    Speakers= new List<Speaker> {
                         new Speaker{
                            Name= "Michael Davis",
                            Title= "Cloud Security Specialist",
                            Note= "Learn the best security practices for ensuring the safety of your data in the cloud."
                        }
                    },
                    Description= "This session covers cloud security strategies, focusing on protecting your data and maintaining compliance.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Security Engineers, IT Professionals, Developers",
                    EventLevel= "Advanced",
                    EventTags= ["Cloud Security", "Data Protection", "Compliance"]
                },
                new EventManagementData {
                    Id= 26,
                    Title= "Cloud Computing and Architecture",
                    Subject= "Containerization and Cloud-Native Applications",
                    StartTime= "2025-02-24T09:00:00.000Z",
                    EndTime= "2025-02-24T10:00:00.000Z",
                    RoomId= 4,
                    Capacity= 320,
                    Speakers= new List<Speaker> {
                         new Speaker{
                            Name= "Sarah Lee",
                            Title= "Cloud-Native Expert",
                            Note= "Exploring how containerization technologies like Docker and Kubernetes are transforming cloud-native applications."
                        }
                    },
                    Description= "This session will dive into the world of containerization and its application in cloud-native environments.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "DevOps Engineers, Cloud Architects, Developers",
                    EventLevel= "Intermediate",
                    EventTags= ["Containers", "Cloud-Native", "Kubernetes"]
                },
                new EventManagementData {
                    Id= 27,
                    Title= "Cloud Computing and Architecture",
                    Subject= "Panel Discussion: The Future of Cloud Computing",
                    StartTime= "2025-02-24T11:00:00.000Z",
                    EndTime= "2025-02-24T12:30:00.000Z",
                    RoomId= 4,
                    Capacity= 320,
                    Speakers= new List<Speaker> {
                         new Speaker{
                            Name= "David Miller",
                            Title= "Cloud Architect",
                            Note= "Industry leaders discuss the future of cloud computing, new trends, and emerging technologies."
                        },
                         new Speaker{
                            Name= "Emily Walker",
                            Title= "Cloud Solutions Architect",
                            Note= "Insights into the evolving role of cloud computing in the modern tech landscape."
                        }
                    },
                    Description= "A panel of cloud computing experts will discuss the future of cloud architecture, emerging trends, and upcoming challenges.",
                    Duration= "1 hour",
                    EventType= "Panel Discussion",
                    TargetAudience= "Cloud Architects, Developers, IT Managers",
                    EventLevel= "Advanced",
                    EventTags= ["Cloud Computing", "Future Trends", "Emerging Technologies"]
                },
                new EventManagementData {
                    Id= 28,
                    Title= "DevOps and Continuous Integration",
                    Subject= "Introduction to DevOps Practices",
                    StartTime= "2025-02-25T04:00:00.000Z",
                    EndTime= "2025-02-25T05:15:00.000Z",
                    RoomId= 1,
                    Capacity= 100,
                    Speakers= new List<Speaker> {
                         new Speaker{
                            Name= "John Carter",
                            Title= "DevOps Engineer",
                            Note= "Understanding the key principles of DevOps and how it helps streamline software development processes."
                        }
                    },
                    Description= "This session introduces the core principles of DevOps, including continuous integration and continuous delivery.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Developers, DevOps Engineers, IT Professionals",
                    EventLevel= "Beginner",
                    EventTags= ["DevOps", "Continuous Integration", "Agile Development"]
                },
                new EventManagementData {
                    Id= 29,
                    Title= "DevOps and Continuous Integration",
                    Subject= "Automating CI/CD Pipelines with Jenkins",
                    StartTime= "2025-02-25T05:45:00.000Z",
                    EndTime= "2025-02-25T07:00:00.000Z",
                    RoomId= 1,
                    Capacity= 100,
                    Speakers= new List<Speaker> {
                         new Speaker{
                            Name= "John Carter",
                            Title= "DevOps Engineer",
                            Note= "Learn how to set up automated CI/CD pipelines using Jenkins for streamlined software deployment."
                        }
                    },
                    Description= "In this session, we’ll walk through the process of setting up and automating CI/CD pipelines using Jenkins.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Developers, DevOps Engineers, IT Managers",
                    EventLevel= "Intermediate",
                    EventTags= ["CI/CD", "Jenkins", "Automation"]
                },
                new EventManagementData {
                    Id= 30,
                    Title= "DevOps and Continuous Integration",
                    Subject= "Scaling DevOps in Large Organizations",
                    StartTime= "2025-02-25T08:30:00.000Z",
                    EndTime= "2025-02-25T10:30:00.000Z",
                    RoomId= 1,
                    Capacity= 100,
                    Speakers= new List<Speaker> {
                         new Speaker{
                            Name= "Emily Carter",
                            Title= "Senior DevOps Engineer",
                            Note= "Explore strategies for scaling DevOps practices across larger teams and enterprises."
                        }
                    },
                    Description= "This session will cover strategies to scale DevOps practices in large organizations, ensuring smoother workflows and faster deployment.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Enterprise DevOps Engineers, IT Managers, Senior Developers",
                    EventLevel= "Advanced",
                    EventTags= ["Scaling DevOps", "Enterprise Solutions", "Agile Development"]
                },
                new EventManagementData {
                    Id= 31,
                    Title= "DevOps and Continuous Integration",
                    Subject= "Advanced Continuous Integration Practices",
                    StartTime= "2025-02-25T11:00:00.000Z",
                    EndTime= "2025-02-25T12:00:00.000Z",
                    RoomId= 1,
                    Capacity= 100,
                    Speakers= new List<Speaker> {
                         new Speaker{
                            Name= "John Carter",
                            Title= "DevOps Engineer",
                            Note= "Advanced techniques in automating CI/CD processes, including blue/green deployments."
                        }
                    },
                    Description= "This session will focus on advanced CI/CD automation strategies, including advanced Jenkins features, blue/green deployment strategies, and more.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "DevOps Engineers, Senior Developers, IT Managers",
                    EventLevel= "Advanced",
                    EventTags= ["CI/CD", "Jenkins", "Advanced Automation"]
                },
                new EventManagementData {
                    Id= 32,
                    Title= "Cybersecurity in Modern IT Infrastructure",
                    Subject= "Introduction to Cybersecurity",
                    StartTime= "2025-02-25T03:30:00.000Z",
                    EndTime= "2025-02-25T04:30:00.000Z",
                    RoomId= 2,
                    Capacity= 120,
                    Speakers= new List<Speaker> {
                         new Speaker{
                            Name= "Ethan Walker",
                            Title= "Cybersecurity Specialist",
                            Note= "Overview of cybersecurity concepts and its significance in modern IT infrastructure."
                        }
                    },
                    Description= "Introduction to cybersecurity threats and their impact on modern IT infrastructure.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Security Engineers, IT Professionals, Developers",
                    EventLevel= "Beginner",
                    EventTags= ["Cybersecurity", "IT Infrastructure", "Security"]
                },
                new EventManagementData {
                    Id= 33,
                    Title= "Cybersecurity in Modern IT Infrastructure",
                    Subject= "Network Security and Threats",
                    StartTime= "2025-02-25T04:30:00.000Z",
                    EndTime= "2025-02-25T05:00:00.000Z",
                    RoomId= 2,
                    Capacity= 120,
                    Speakers= new List<Speaker> {
                         new Speaker{
                            Name= "Ethan Walker",
                            Title= "Cybersecurity Specialist",
                            Note= "Exploring the most common network security threats and how to protect your infrastructure."
                        }
                    },
                    Description= "An in-depth session on network security, common threats, and methods for protecting your infrastructure.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Network Engineers, Security Specialists, IT Professionals",
                    EventLevel= "Intermediate",
                    EventTags= ["Network Security", "Threats", "Infrastructure"]
                },
                new EventManagementData {
                    Id= 34,
                    Title= "Cybersecurity in Modern IT Infrastructure",
                    Subject= "Short Break for Relaxation",
                    StartTime= "2025-02-25T04:30:00.000Z",
                    EndTime= "2025-02-25T05:00:00.000Z",
                    RoomId= 2,
                    Capacity= 120,
                    Speakers= new List<Speaker>(),
                    Description= "Take a short break to refresh and network with fellow attendees.",
                    Duration= "30 minutes",
                    EventType= "Break",
                    TargetAudience= "All attendees",
                    EventLevel= "All levels",
                    EventTags= ["Networking", "Relaxation"]
                },
                new EventManagementData {
                    Id= 35,
                    Title= "Cybersecurity in Modern IT Infrastructure",
                    Subject= "Firewalls and Intrusion Detection Systems",
                    StartTime= "2025-02-25T05:00:00.000Z",
                    EndTime= "2025-02-25T06:30:00.000Z",
                    RoomId= 2,
                    Capacity= 120,
                    Speakers= new List<Speaker> {
                         new Speaker{
                            Name= "Olivia Scott",
                            Title= "Network Security Expert",
                            Note= "How to configure and manage firewalls and intrusion detection systems to safeguard your network."
                        }
                    },
                    Description= "Techniques for configuring firewalls and intrusion detection systems (IDS) to prevent network attacks.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Network Administrators, Security Engineers, System Admins",
                    EventLevel= "Intermediate",
                    EventTags= ["Firewall", "IDS", "Network Security"]
                },
                new EventManagementData {
                    Id= 36,
                    Title= "Cybersecurity in Modern IT Infrastructure",
                    Subject= "Encryption and Data Protection",
                    StartTime= "2025-02-25T07:30:00.000Z",
                    EndTime= "2025-02-25T08:30:00.000Z",
                    RoomId= 2,
                    Capacity= 120,
                    Speakers= new List<Speaker> {
                         new Speaker{
                            Name= "Olivia Scott",
                            Title= "Network Security Expert",
                            Note= "Exploring encryption techniques and how they are used to protect sensitive data."
                        }
                    },
                    Description= "An overview of encryption protocols and strategies to protect sensitive information across networks.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Security Engineers, IT Professionals, Developers",
                    EventLevel= "Intermediate",
                    EventTags= ["Encryption", "Data Protection", "Security"]
                },
                new EventManagementData {
                    Id= 37,
                    Title= "Cybersecurity in Modern IT Infrastructure",
                    Subject= "Cloud Security Practices",
                    StartTime= "2025-02-25T08:30:00.000Z",
                    EndTime= "2025-02-25T09:30:00.000Z",
                    RoomId= 2,
                    Capacity= 120,
                    Speakers= new List<Speaker> {
                         new Speaker{
                            Name= "Ethan Walker",
                            Title= "Cybersecurity Specialist",
                            Note= "Best practices for securing cloud environments against cyber threats."
                        }
                    },
                    Description= "Learn cloud security best practices and how to ensure the security of your data and applications in the cloud.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Cloud Engineers, Security Specialists, IT Managers",
                    EventLevel= "Advanced",
                    EventTags= ["Cloud Security", "Cybersecurity", "Cloud Infrastructure"]
                },
                new EventManagementData {
                    Id= 38,
                    Title= "Cybersecurity in Modern IT Infrastructure",
                    Subject= "Break",
                    StartTime= "2025-02-25T09:30:00.000Z",
                    EndTime= "2025-02-25T10:00:00.000Z",
                    RoomId= 2,
                    Capacity= 120,
                    Speakers= new List<Speaker>(),
                    Description= "Short break to relax and network.",
                    Duration= "30 minutes",
                    EventType= "Break",
                    TargetAudience= "All Participants",
                    EventLevel= "All Levels",
                    EventTags= ["Networking", "Relax"]
                },
                new EventManagementData {
                    Id= 39,
                    Title= "Cybersecurity in Modern IT Infrastructure",
                    Subject= "Incident Response and Recovery",
                    StartTime= "2025-02-25T10:00:00.000Z",
                    EndTime= "2025-02-25T10:30:00.000Z",
                    RoomId= 2,
                    Capacity= 120,
                    Speakers= new List<Speaker> {
                         new Speaker{
                            Name= "Olivia Scott",
                            Title= "Network Security Expert",
                            Note= "Discussing incident response strategies and recovery techniques in the event of a cyberattack."
                        }
                    },
                    Description= "Techniques and strategies for responding to cybersecurity incidents and recovering from data breaches and attacks.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Security Engineers, Incident Response Teams, IT Managers",
                    EventLevel= "Advanced",
                    EventTags= ["Incident Response", "Cybersecurity", "Recovery"]
                },
                new EventManagementData {
                    Id= 40,
                    Title= "Cybersecurity in Modern IT Infrastructure",
                    Subject= "Panel Discussion: The Future of Cybersecurity",
                    StartTime= "2025-02-25T10:45:00.000Z",
                    EndTime= "2025-02-25T12:30:00.000Z",
                    RoomId= 2,
                    Capacity= 120,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Ethan Walker",
                            Title= "Cybersecurity Specialist",
                            Note= "Experts discuss the evolving landscape of cybersecurity and the technologies shaping the future."
                        },
                        new Speaker{
                            Name= "Olivia Scott",
                            Title= "Network Security Expert",
                            Note= "Insights into the future of cybersecurity with new technologies and upcoming challenges."
                        }
                    },
                    Description= "Industry experts discuss the next steps for cybersecurity as it continues to evolve in the face of new threats and technologies.",
                    Duration= "1 hour",
                    EventType= "Panel Discussion",
                    TargetAudience= "Security Engineers, IT Professionals, Managers",
                    EventLevel= "Advanced",
                    EventTags= ["Cybersecurity", "Future Trends", "Panel Discussion"]
                },
                new EventManagementData {
                    Id= 41,
                    Title= "Data Science and Machine Learning Fundamentals",
                    Subject= "Introduction to Data Science",
                    StartTime= "2025-02-25T03:30:00.000Z",
                    EndTime= "2025-02-25T04:30:00.000Z",
                    RoomId= 3,
                    Capacity= 280,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Ava Parker",
                            Title= "Data Scientist",
                            Note= "Learn the fundamentals of data science and its role in modern industries."
                        }
                    },
                    Description= "Introduction to the principles of data science, including data collection, cleaning, and basic analysis techniques.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Data Scientists, Analysts, IT Professionals",
                    EventLevel= "Beginner",
                    EventTags= ["Data Science", "Big Data", "Machine Learning"]
                },
                new EventManagementData {
                    Id= 42,
                    Title= "Data Science and Machine Learning Fundamentals",
                    Subject= "Exploring Machine Learning Algorithms",
                    StartTime= "2025-02-25T05:00:00.000Z",
                    EndTime= "2025-02-25T06:30:00.000Z",
                    RoomId= 3,
                    Capacity= 280,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Ava Parker",
                            Title= "Data Scientist",
                            Note= "A closer look at common machine learning algorithms such as linear regression, classification, and clustering."
                        }
                    },
                    Description= "A session focused on understanding machine learning algorithms, including their applications and use cases.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Data Scientists, Developers, AI Researchers",
                    EventLevel= "Intermediate",
                    EventTags= ["Machine Learning", "Algorithms", "Data Science"]
                },
                new EventManagementData {
                    Id= 43,
                    Title= "Data Science and Machine Learning Fundamentals",
                    Subject= "Supervised vs Unsupervised Learning",
                    StartTime= "2025-02-25T07:30:00.000Z",
                    EndTime= "2025-02-25T08:30:00.000Z",
                    RoomId= 3,
                    Capacity= 280,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Liam Brown",
                            Title= "AI Engineer",
                            Note= "Deep dive into the differences and applications of supervised and unsupervised machine learning models."
                        }
                    },
                    Description= "Understanding the fundamental differences between supervised and unsupervised learning and when to use each.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "AI Engineers, Data Scientists, Machine Learning Practitioners",
                    EventLevel= "Intermediate",
                    EventTags= ["Supervised Learning", "Unsupervised Learning", "Machine Learning"]
                },
                new EventManagementData {
                    Id= 44,
                    Title= "Data Science and Machine Learning Fundamentals",
                    Subject= "Deep Learning Introduction",
                    StartTime= "2025-02-25T08:30:00.000Z",
                    EndTime= "2025-02-25T09:30:00.000Z",
                    RoomId= 3,
                    Capacity= 280,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Liam Brown",
                            Title= "AI Engineer",
                            Note= "Introduction to deep learning, neural networks, and their applications."
                        }
                    },
                    Description= "A primer on deep learning techniques, including an overview of neural networks, CNNs, and RNNs.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "AI Engineers, Machine Learning Researchers, Developers",
                    EventLevel= "Advanced",
                    EventTags= ["Deep Learning", "Neural Networks", "AI"]
                },
                new EventManagementData {
                    Id= 45,
                    Title= "Data Science and Machine Learning Fundamentals",
                    Subject= "Break",
                    StartTime= "2025-02-25T09:30:00.000Z",
                    EndTime= "2025-02-25T10:00:00.000Z",
                    RoomId= 3,
                    Capacity= 280,
                    Speakers= new List<Speaker>(),
                    Description= "Beak for relaxation and networking.",
                    Duration= "1 hour",
                    EventType= "Break",
                    TargetAudience= "All Attendees",
                    EventLevel= "All levels",
                    EventTags= ["Break", "Networking"]
                },
                new EventManagementData {
                    Id= 46,
                    Title= "Data Science and Machine Learning Fundamentals",
                    Subject= "Evaluating Model Performance",
                    StartTime= "2025-02-25T10:00:00.000Z",
                    EndTime= "2025-02-25T11:30:00.000Z",
                    RoomId= 3,
                    Capacity= 280,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Ava Parker",
                            Title= "Data Scientist",
                            Note= "How to evaluate machine learning models and improve performance."
                        }
                    },
                    Description= "Exploring techniques for evaluating and tuning machine learning models to improve their accuracy.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Data Scientists, Machine Learning Engineers",
                    EventLevel= "Intermediate",
                    EventTags= ["Model Evaluation", "Performance", "Machine Learning"]
                },
                new EventManagementData {
                    Id= 47,
                    Title= "Data Science and Machine Learning Fundamentals",
                    Subject= "Ethical Considerations in Data Science",
                    StartTime= "2025-02-25T11:50:00.000Z",
                    EndTime= "2025-02-25T12:30:00.000Z",
                    RoomId= 3,
                    Capacity= 280,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Ava Parker",
                            Title= "Data Scientist",
                            Note= "Discussing the ethical challenges and responsibilities when working with data."
                        }
                    },
                    Description= "A session dedicated to exploring the ethical implications of data science and machine learning applications.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Data Scientists, AI Practitioners, Ethics Professionals",
                    EventLevel= "Advanced",
                    EventTags= ["Ethics", "Data Science", "Machine Learning"]
                },
                new EventManagementData {
                    Id= 48,
                    Title= "Blockchain and Cryptocurrency Fundamentals",
                    Subject= "Introduction to Blockchain Technology",
                    StartTime= "2025-02-25T03:45:00.000Z",
                    EndTime= "2025-02-25T04:15:00.000Z",
                    RoomId= 4,
                    Capacity= 390,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Henry Clarke",
                            Title= "Blockchain Expert",
                            Note= "An introduction to the basics of blockchain technology and how it revolutionizes industries."
                        }
                    },
                    Description= "Understanding blockchain fundamentals, its architecture, and how it underpins cryptocurrency systems.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Developers, Business Professionals, IT Specialists",
                    EventLevel= "Beginner",
                    EventTags= ["Blockchain", "Cryptocurrency", "Technology"]
                },
                new EventManagementData {
                    Id= 49,
                    Title= "Blockchain and Cryptocurrency Fundamentals",
                    Subject= "Cryptocurrency Basics and Bitcoin Overview",
                    StartTime= "2025-02-25T04:30:00.000Z",
                    EndTime= "2025-02-25T05:00:00.000Z",
                    RoomId= 4,
                    Capacity= 390,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Sophia Mitchell",
                            Title= "Cryptocurrency Expert",
                            Note= "A deep dive into Bitcoin and its place in the cryptocurrency ecosystem."
                        }
                    },
                    Description= "Exploring the fundamentals of cryptocurrencies, with a special focus on Bitcoin, and how it’s used in digital transactions.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Blockchain Enthusiasts, Financial Technologists, Developers",
                    EventLevel= "Intermediate",
                    EventTags= ["Bitcoin", "Cryptocurrency", "Blockchain"]
                },
                new EventManagementData {
                    Id= 50,
                    Title= "Blockchain and Cryptocurrency Fundamentals",
                    Subject= "Break",
                    StartTime= "2025-02-25T05:00:00.000Z",
                    EndTime= "2025-02-25T05:30:00.000Z",
                    RoomId= 4,
                    Capacity= 390,
                    Speakers= new List<Speaker>(),
                    Description= "A short break for attendees to relax and network.",
                    Duration= "30 minutes",
                    EventType= "Break",
                    TargetAudience= "All Participants",
                    EventLevel= "All Levels",
                    EventTags= ["Networking", "Relax"]
                },
                new EventManagementData {
                    Id= 51,
                    Title= "Blockchain and Cryptocurrency Fundamentals",
                    Subject= "Decentralization and Consensus Algorithms",
                    StartTime= "2025-02-25T05:30:00.000Z",
                    EndTime= "2025-02-25T06:30:00.000Z",
                    RoomId= 4,
                    Capacity= 390,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Henry Clarke",
                            Title= "Blockchain Expert",
                            Note= "Exploring decentralization and various consensus algorithms like PoW, PoS, and more."
                        }
                    },
                    Description= "Understanding the importance of decentralization and learning about consensus algorithms used in blockchain networks.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Blockchain Developers, IT Engineers, Researchers",
                    EventLevel= "Intermediate",
                    EventTags= ["Blockchain", "Consensus Algorithms", "Decentralization"]
                },
                new EventManagementData {
                    Id= 52,
                    Title= "Blockchain and Cryptocurrency Fundamentals",
                    Subject= "Lunch Break",
                    StartTime= "2025-02-25T06:30:00.000Z",
                    EndTime= "2025-02-25T07:30:00.000Z",
                    RoomId= 4,
                    Capacity= 390,
                    Speakers= new List<Speaker>(),
                    Description= "Lunch break for relaxation and networking.",
                    Duration= "1 hour",
                    EventType= "Break",
                    TargetAudience= "All Attendees",
                    EventLevel= "All levels",
                    EventTags= ["Break", "Networking"]
                },
                new EventManagementData {
                    Id= 53,
                    Title= "Blockchain and Cryptocurrency Fundamentals",
                    Subject= "Smart Contracts and DApps",
                    StartTime= "2025-02-25T07:30:00.000Z",
                    EndTime= "2025-02-25T08:45:00.000Z",
                    RoomId= 4,
                    Capacity= 390,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Sophia Mitchell",
                            Title= "Cryptocurrency Expert",
                            Note= "Exploring smart contracts, decentralized applications (DApps), and how they operate on blockchain platforms."
                        }
                    },
                    Description= "A session dedicated to smart contracts and decentralized applications (DApps), which are built on blockchain platforms like Ethereum.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Blockchain Developers, Ethereum Developers, Smart Contract Enthusiasts",
                    EventLevel= "Intermediate",
                    EventTags= ["Smart Contracts", "DApps", "Ethereum"]
                },
                new EventManagementData {
                    Id= 54,
                    Title= "Blockchain and Cryptocurrency Fundamentals",
                    Subject= "Blockchain for Enterprise Applications",
                    StartTime= "2025-02-25T08:45:00.000Z",
                    EndTime= "2025-02-25T09:45:00.000Z",
                    RoomId= 4,
                    Capacity= 390,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Henry Clarke",
                            Title= "Blockchain Expert",
                            Note= "How blockchain can be used for enterprise applications, improving transparency and security in business processes."
                        }
                    },
                    Description= "A look into enterprise-level blockchain implementations and how companies are using this technology for improved efficiency and security.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Business Analysts, Blockchain Developers, IT Managers",
                    EventLevel= "Advanced",
                    EventTags= ["Enterprise Blockchain", "Business Applications", "Security"]
                },
                new EventManagementData {
                    Id= 55,
                    Title= "Blockchain and Cryptocurrency Fundamentals",
                    Subject= "Future of Blockchain and Cryptocurrency",
                    StartTime= "2025-02-25T10:00:00.000Z",
                    EndTime= "2025-02-25T11:00:00.000Z",
                    RoomId= 4,
                    Capacity= 390,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Sophia Mitchell",
                            Title= "Cryptocurrency Expert",
                            Note= "Discussing the future trends and innovations in blockchain and cryptocurrency technologies."
                        }
                    },
                    Description= "A forward-looking discussion on the potential future of blockchain and cryptocurrency technologies, their societal impacts, and upcoming trends.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                            TargetAudience= "Crypto Enthusiasts, Blockchain Innovators, IT Professionals",
                    EventLevel= "Advanced",
                    EventTags= ["Blockchain Future", "Cryptocurrency Trends", "Innovation"]
                },
                new EventManagementData {
                    Id= 56,
                    Title= "Blockchain and Cryptocurrency Fundamentals",
                    Subject= "Panel Discussion: The Regulatory Landscape of Cryptocurrencies",
                    StartTime= "2025-02-25T11:30:00.000Z",
                    EndTime= "2025-02-25T12:30:00.000Z",
                    RoomId= 4,
                    Capacity= 390,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Henry Clarke",
                            Title= "Blockchain Expert",
                            Note= "An expert panel discusses the regulatory challenges and frameworks for cryptocurrencies and blockchain technologies."
                        },
                        new Speaker{
                            Name= "Sophia Mitchell",
                            Title= "Cryptocurrency Expert",
                            Note= "Insights on how governments and financial institutions are handling the regulation of digital currencies."
                        }
                    },
                    Description= "Industry leaders discuss the evolving regulatory landscape for cryptocurrencies and blockchain-based technologies.",
                    Duration= "1 hour",
                    EventType= "Panel Discussion",
                    TargetAudience= "Regulatory Experts, Developers, Financial Professionals",
                    EventLevel= "Advanced",
                    EventTags= ["Cryptocurrency Regulation", "Blockchain", "Panel Discussion"]
                },
                new EventManagementData {
                    Id= 57,
                    Title= "Internet of Things (IoT) for Smart Solutions",
                    Subject= "Introduction to IoT and Its Applications",
                    StartTime= "2025-02-26T03:30:00.000Z",
                    EndTime= "2025-02-26T04:00:00.000Z",
                    RoomId= 1,
                    Capacity= 50,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "James Porter",
                            Title= "IoT Specialist",
                            Note= "An introduction to the Internet of Things (IoT) and its real-world applications in smart cities, homes, and industries."
                        }
                    },
                    Description= "Exploring the concept of IoT, its key technologies, and how it’s being used to develop smart solutions in various industries.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "IoT Engineers, Developers, IT Professionals",
                    EventLevel= "Beginner",
                    EventTags= ["IoT", "Smart Solutions", "Technology"]
                },
                new EventManagementData {
                    Id= 58,
                    Title= "Internet of Things (IoT) for Smart Solutions",
                    Subject= "IoT Architecture and Devices",
                    StartTime= "2025-02-26T04:30:00.000Z",
                    EndTime= "2025-02-26T06:00:00.000Z",
                    RoomId= 1,
                    Capacity= 50,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Emily Rose",
                            Title= "IoT Engineer",
                            Note= "Understanding IoT architecture and how IoT devices communicate in a connected environment."
                        }
                    },
                    Description= "An in-depth look at IoT architecture, communication protocols, and devices that power the Internet of Things.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "IoT Developers, Network Engineers, Solution Architects",
                    EventLevel= "Intermediate",
                    EventTags= ["IoT Devices", "Architecture", "Networking"]
                },
                new EventManagementData {
                    Id= 59,
                    Title= "Internet of Things (IoT) for Smart Solutions",
                    Subject= "Security Challenges in IoT",
                    StartTime= "2025-02-26T06:00:00.000Z",
                    EndTime= "2025-02-26T06:30:00.000Z",
                    RoomId= 1,
                    Capacity= 50,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "James Porter",
                            Title= "IoT Security Expert",
                            Note= "Exploring the security challenges in IoT systems and strategies to secure connected devices."
                        }
                    },
                    Description= "Addressing the unique security challenges posed by IoT systems and exploring solutions to protect connected devices and networks.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Security Engineers, IoT Developers, Network Specialists",
                    EventLevel= "Advanced",
                    EventTags= ["IoT Security", "Data Protection", "Internet of Things"]
                },
                new EventManagementData {
                    Id= 60,
                    Title= "Internet of Things (IoT) for Smart Solutions",
                    Subject= "Lunch Break",
                    StartTime= "2025-02-26T06:30:00.000Z",
                    EndTime= "2025-02-26T07:30:00.000Z",
                    RoomId= 1,
                    Capacity= 50,
                    Speakers= new List<Speaker>(),
                    Description= "Lunch break for relaxation and networking.",
                    Duration= "1 hour",
                    EventType= "Break",
                    TargetAudience= "All Attendees",
                    EventLevel= "All levels",
                    EventTags= ["Break", "Networking"]
                },
                new EventManagementData {
                    Id= 61,
                    Title= "Internet of Things (IoT) for Smart Solutions",
                    Subject= "IoT Data Management and Analytics",
                    StartTime= "2025-02-26T07:30:00.000Z",
                    EndTime= "2025-02-26T08:30:00.000Z",
                    RoomId= 1,
                    Capacity= 50,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Emily Rose",
                            Title= "IoT Engineer",
                            Note= "Discussing how IoT systems collect, manage, and analyze data for smart decision-making."
                        }
                    },
                    Description= "Exploring the ways IoT systems generate massive data and how it’s analyzed for smart solutions and business intelligence.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Data Scientists, IoT Developers, Analytics Professionals",
                    EventLevel= "Intermediate",
                    EventTags= ["IoT Data", "Analytics", "Big Data"]
                },
                new EventManagementData {
                    Id= 62,
                    Title= "Internet of Things (IoT) for Smart Solutions",
                    Subject= "IoT for Smart Cities and Homes",
                    StartTime= "2025-02-26T08:30:00.000Z",
                    EndTime= "2025-02-26T09:30:00.000Z",
                    RoomId= 1,
                    Capacity= 50,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "James Porter",
                            Title= "IoT Specialist",
                            Note= "Exploring how IoT is transforming cities and homes with smart technologies that improve living standards."
                        }
                    },
                    Description= "A session focused on how IoT technologies are shaping the development of smart cities and homes, improving efficiency and quality of life.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Smart City Planners, IoT Engineers, Urban Developers",
                    EventLevel= "Intermediate",
                    EventTags= ["Smart Cities", "IoT", "Urban Planning"]
                },
                new EventManagementData {
                    Id= 63,
                    Title= "Internet of Things (IoT) for Smart Solutions",
                    Subject= "The Future of IoT",
                    StartTime= "2025-02-26T10:30:00.000Z",
                    EndTime= "2025-02-26T12:30:00.000Z",
                    RoomId= 1,
                    Capacity= 50,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Emily Rose",
                            Title= "IoT Engineer",
                            Note= "Looking ahead to the next frontier of IoT innovation and the transformative potential of connected devices."
                        }
                    },
                    Description= "A discussion on the future of IoT, emerging trends, and how the Internet of Things will continue to shape industries and everyday life.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "IoT Innovators, Tech Enthusiasts, Developers",
                    EventLevel= "Advanced",
                    EventTags= ["Future IoT", "Technology Trends", "Innovation"]
                },
                new EventManagementData {
                    Id= 64,
                    Title= "Data Science and Machine Learning",
                    Subject= "Introduction to Data Science",
                    StartTime= "2025-02-26T03:30:00.000Z",
                    EndTime= "2025-02-26T04:10:00.000Z",
                    RoomId= 2,
                    Capacity= 180,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Alice Johnson",
                            Title= "Data Scientist",
                            Note= "Introducing the core concepts and tools of data science, including data wrangling, visualization, and analysis."
                        }
                    },
                    Description= "An introductory session to the world of data science, covering fundamental concepts and tools used in the field.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Data Enthusiasts, Developers, Business Analysts",
                    EventLevel= "Beginner",
                    EventTags= ["Data Science", "Data Analysis", "Machine Learning"]
                },
                new EventManagementData {
                    Id= 65,
                    Title= "Data Science and Machine Learning",
                    Subject= "Supervised Learning Algorithms",
                    StartTime= "2025-02-26T04:30:00.000Z",
                    EndTime= "2025-02-26T05:30:00.000Z",
                    RoomId= 2,
                    Capacity= 180,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Alice Johnson",
                            Title= "Data Scientist",
                            Note= "A detailed exploration of supervised learning algorithms, including linear regression and decision trees."
                        }
                    },
                    Description= "An in-depth session on supervised learning algorithms and their applications in machine learning and data analysis.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Data Scientists, ML Enthusiasts, Developers",
                    EventLevel= "Intermediate",
                    EventTags= ["Supervised Learning", "Algorithms", "Machine Learning"]
                },
                new EventManagementData {
                    Id= 66,
                    Title= "Data Science and Machine Learning",
                    Subject= "Unsupervised Learning and Clustering Techniques",
                    StartTime= "2025-02-26T05:30:00.000Z",
                    EndTime= "2025-02-26T06:30:00.000Z",
                    RoomId= 2,
                    Capacity= 180,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Alice Johnson",
                            Title= "Data Scientist",
                            Note= "Exploring unsupervised learning techniques like clustering and dimensionality reduction."
                        }
                    },
                    Description= "A session covering unsupervised learning techniques, including K-means clustering and PCA, used to analyze unlabeled data.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Machine Learning Enthusiasts, Data Scientists, Analysts",
                    EventLevel= "Intermediate",
                    EventTags= ["Unsupervised Learning", "Clustering", "Machine Learning"]
                },
                new EventManagementData {
                    Id= 67,
                    Title= "Data Science and Machine Learning",
                    Subject= "Lunch Break",
                    StartTime= "2025-02-26T06:30:00.000Z",
                    EndTime= "2025-02-26T07:30:00.000Z",
                    RoomId= 2,
                    Capacity= 180,
                    Speakers= new List<Speaker>(),
                    Description= "Lunch break for relaxation and networking.",
                    Duration= "1 hour",
                    EventType= "Break",
                    TargetAudience= "All Attendees",
                    EventLevel= "All levels",
                    EventTags= ["Break", "Networking"]
                },
                new EventManagementData {
                    Id= 68,
                    Title= "Data Science and Machine Learning",
                    Subject= "Deep Learning and Neural Networks",
                    StartTime= "2025-02-26T07:30:00.000Z",
                    EndTime= "2025-02-26T09:00:00.000Z",
                    RoomId= 2,
                    Capacity= 180,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Alice Johnson",
                            Title= "Deep Learning Expert",
                            Note= "Introduction to deep learning techniques and how neural networks are transforming data science."
                        }
                    },
                    Description= "An introductory session on deep learning, explaining neural networks, CNNs, and their use in various applications.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Deep Learning Enthusiasts, Data Scientists, AI Developers",
                    EventLevel= "Intermediate",
                    EventTags= ["Deep Learning", "Neural Networks", "Machine Learning"]
                },
                new EventManagementData {
                    Id= 69,
                    Title= "Data Science and Machine Learning",
                    Subject= "Model Evaluation and Performance Metrics",
                    StartTime= "2025-02-26T09:30:00.000Z",
                    EndTime= "2025-02-26T10:45:00.000Z",
                    RoomId= 2,
                    Capacity= 180,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Alice Johnson",
                            Title= "Data Scientist",
                            Note= "Understanding the different model evaluation metrics like accuracy, precision, recall, and F1-score."
                        }
                    },
                    Description= "A session on the importance of evaluating machine learning models using various performance metrics.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Data Scientists, Machine Learning Engineers",
                    EventLevel= "Advanced",
                    EventTags= ["Model Evaluation", "Performance Metrics", "Machine Learning"]
                },
                new EventManagementData {
                    Id= 70,
                    Title= "Data Science and Machine Learning",
                    Subject= "Deploying Machine Learning Models in Production",
                    StartTime= "2025-02-26T11:30:00.000Z",
                    EndTime= "2025-02-26T12:30:00.000Z",
                    RoomId= 2,
                    Capacity= 180,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Alice Johnson",
                            Title= "Machine Learning Engineer",
                            Note= "Discussing best practices and tools for deploying machine learning models to production environments."
                        }
                    },
                    Description= "A session focused on the strategies, tools, and challenges of deploying machine learning models into production environments.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "DevOps Engineers, ML Engineers, Data Scientists",
                    EventLevel= "Advanced",
                    EventTags= ["Deployment", "Machine Learning", "Production"]
                },
                new EventManagementData {
                    Id= 71,
                    Title= "Cloud Computing for Scalability",
                    Subject= "Introduction to Cloud Computing",
                    StartTime= "2025-02-26T04:00:00.000Z",
                    EndTime= "2025-02-26T05:00:00.000Z",
                    RoomId= 3,
                    Capacity= 230,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Daniel Smith",
                            Title= "Cloud Architect",
                            Note= "An introduction to cloud computing and its core concepts including IaaS, PaaS, and SaaS."
                        }
                    },
                    Description= "A session that introduces cloud computing, its different models, and its benefits for businesses and individuals.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Cloud Enthusiasts, IT Professionals, Developers",
                    EventLevel= "Beginner",
                    EventTags= ["Cloud Computing", "IaaS", "PaaS", "SaaS"]
                },
                new EventManagementData {
                    Id= 72,
                    Title= "Cloud Computing for Scalability",
                    Subject= "Break",
                    StartTime= "2025-02-26T05:00:00.000Z",
                    EndTime= "2025-02-26T05:30:00.000Z",
                    RoomId= 3,
                    Capacity= 230,
                    Speakers= new List<Speaker>(),
                    Description= "A short break for attendees to relax and network.",
                    Duration= "30 minutes",
                    EventType= "Break",
                    TargetAudience= "All Participants",
                    EventLevel= "All Levels",
                    EventTags= ["Networking", "Relax"]
                },
                new EventManagementData {
                    Id= 73,
                    Title= "Cloud Computing for Scalability",
                    Subject= "Scaling Applications in the Cloud",
                    StartTime= "2025-02-26T05:30:00.000Z",
                    EndTime= "2025-02-26T06:30:00.000Z",
                    RoomId= 3,
                    Capacity= 230,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Daniel Smith",
                            Title= "Cloud Architect",
                            Note= "How to scale cloud-based applications and utilize cloud features to handle increasing traffic and demand."
                        }
                    },
                    Description= "This session covers techniques for scaling applications in the cloud using services like auto-scaling and load balancing.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Cloud Engineers, Developers, IT Professionals",
                    EventLevel= "Intermediate",
                    EventTags= ["Cloud Scalability", "Load Balancing", "Auto-Scaling"]
                },
                new EventManagementData {
                    Id= 74,
                    Title= "Cloud Computing for Scalability",
                    Subject= "Lunch Break",
                    StartTime= "2025-02-26T06:30:00.000Z",
                    EndTime= "2025-02-26T07:30:00.000Z",
                    RoomId= 3,
                    Capacity= 230,
                    Speakers= new List<Speaker>(),
                    Description= "Lunch break for relaxation and networking.",
                    Duration= "1 hour",
                    EventType= "Break",
                    TargetAudience= "All Attendees",
                    EventLevel= "All levels",
                    EventTags= ["Break", "Networking"]
                },
                new EventManagementData {
                    Id= 75,
                    Title= "Cloud Computing for Scalability",
                    Subject= "Cloud Security Best Practices",
                    StartTime= "2025-02-26T07:30:00.000Z",
                    EndTime= "2025-02-26T09:00:00.000Z",
                    RoomId= 3,
                    Capacity= 230,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Emily Davis",
                            Title= "Cloud Security Expert",
                            Note= "Discussing security best practices and tools for ensuring data protection in the cloud."
                        }
                    },
                    Description= "This session focuses on security best practices, tools, and techniques for safeguarding data and applications in the cloud.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Security Engineers, Cloud Engineers, IT Managers",
                    EventLevel= "Advanced",
                    EventTags= ["Cloud Security", "Data Protection", "Encryption"]
                },
                new EventManagementData {
                    Id= 76,
                    Title= "Cloud Computing for Scalability",
                    Subject= "Cloud Databases and Storage",
                    StartTime= "2025-02-26T09:00:00.000Z",
                    EndTime= "2025-02-26T10:00:00.000Z",
                    RoomId= 3,
                    Capacity= 230,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Daniel Smith",
                            Title= "Cloud Architect",
                            Note= "Overview of cloud databases and storage services like AWS RDS, Google Cloud SQL, and Azure Blob Storage."
                        }
                    },
                    Description= "A session focusing on cloud databases and storage solutions that scale according to your data needs and application demands.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Cloud Engineers, Database Administrators, Developers",
                    EventLevel= "Intermediate",
                    EventTags= ["Cloud Databases", "Storage Solutions", "AWS", "Google Cloud"]
                },
                new EventManagementData {
                    Id= 77,
                    Title= "Cloud Computing for Scalability",
                    Subject= "Multi-cloud and Hybrid Cloud Architectures",
                    StartTime= "2025-02-26T10:30:00.000Z",
                    EndTime= "2025-02-26T11:30:00.000Z",
                    RoomId= 3,
                    Capacity= 230,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Emily Davis",
                            Title= "Cloud Security Expert",
                            Note= "Understanding multi-cloud and hybrid cloud strategies to optimize performance, flexibility, and costs."
                        }
                    },
                    Description= "Learn about multi-cloud and hybrid cloud architectures and their benefits in achieving operational flexibility and reliability.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Cloud Engineers, System Architects, IT Managers",
                    EventLevel= "Advanced",
                    EventTags= ["Multi-cloud", "Hybrid Cloud", "Cloud Architecture"]
                },
                new EventManagementData {
                    Id= 78,
                    Title= "Cloud Computing for Scalability",
                    Subject= "Serverless Architectures and Functions",
                    StartTime= "2025-02-26T11:30:00.000Z",
                    EndTime= "2025-02-26T12:30:00.000Z",
                    RoomId= 3,
                    Capacity= 230,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Daniel Smith",
                            Title= "Cloud Architect",
                            Note= "Exploring serverless computing, serverless functions, and how it can simplify scaling applications."
                        }
                    },
                    Description= "An in-depth look at serverless architectures, including AWS Lambda and Google Cloud Functions, and their scalability benefits.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Cloud Developers, DevOps Engineers, IT Architects",
                    EventLevel= "Advanced",
                    EventTags= ["Serverless", "Cloud Functions", "Scalability"]
                },
                new EventManagementData {
                    Id= 79,
                    Title= "Network Automation and Orchestration",
                    Subject= "Introduction to Network Automation",
                    StartTime= "2025-02-26T04:00:00.000Z",
                    EndTime= "2025-02-26T05:00:00.000Z",
                    RoomId= 4,
                    Capacity= 400,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Robert Lee",
                            Title= "Network Engineer",
                            Note= "Introducing the fundamentals of network automation and how it optimizes network management."
                        }
                    },
                    Description= "An introductory session to network automation tools and techniques to automate manual processes and increase efficiency.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Network Engineers, IT Administrators, DevOps Professionals",
                    EventLevel= "Beginner",
                    EventTags= ["Network Automation", "IT Management", "Orchestration"]
                },
                new EventManagementData {
                    Id= 80,
                    Title= "Network Automation and Orchestration",
                    Subject= "Automation Tools: Ansible, Puppet, and Chef",
                    StartTime= "2025-02-26T05:30:00.000Z",
                    EndTime= "2025-02-26T07:00:00.000Z",
                    RoomId= 4,
                    Capacity= 400,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Robert Lee",
                            Title= "Network Automation Specialist",
                            Note= "Exploring popular automation tools like Ansible, Puppet, and Chef for network orchestration."
                        }
                    },
                    Description= "A technical session exploring the use of automation tools like Ansible, Puppet, and Chef for configuring and managing network devices.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Network Engineers, DevOps Engineers, Systems Administrators",
                    EventLevel= "Intermediate",
                    EventTags= ["Ansible", "Puppet", "Chef", "Network Automation"]
                },
                new EventManagementData {
                    Id= 81,
                    Title= "Network Automation and Orchestration",
                    Subject= "SDN (Software-Defined Networking) Concepts",
                    StartTime= "2025-02-26T08:00:00.000Z",
                    EndTime= "2025-02-26T09:00:00.000Z",
                    RoomId= 4,
                    Capacity= 400,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Robert Lee",
                            Title= "Network Engineer",
                            Note= "An introduction to SDN, its architecture, and how it changes the way networks are managed and configured."
                        }
                    },
                    Description= "This session covers Software-Defined Networking (SDN), a new approach to managing network infrastructure through centralized control.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Network Engineers, IT Managers, SDN Enthusiasts",
                    EventLevel= "Intermediate",
                    EventTags= ["SDN", "Network Automation", "Software-Defined"]
                },
                new EventManagementData {
                    Id= 82,
                    Title= "Network Automation and Orchestration",
                    Subject= "Network Orchestration Using Kubernetes",
                    StartTime= "2025-02-26T09:30:00.000Z",
                    EndTime= "2025-02-26T11:00:00.000Z",
                    RoomId= 4,
                    Capacity= 400,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "David Robinson",
                            Title= "Kubernetes Expert",
                            Note= "Explaining how Kubernetes can be used for network orchestration in modern network infrastructures."
                        }
                    },
                    Description= "A session dedicated to using Kubernetes for network orchestration, simplifying network management and increasing scalability.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Network Engineers, Kubernetes Enthusiasts, IT Administrators",
                    EventLevel= "Intermediate",
                    EventTags= ["Kubernetes", "Network Orchestration", "Automation"]
                },
                new EventManagementData {
                    Id= 83,
                    Title= "Network Automation and Orchestration",
                    Subject= "Automation in Network Security",
                    StartTime= "2025-02-26T11:15:00.000Z",
                    EndTime= "2025-02-26T12:15:00.000Z",
                    RoomId= 4,
                    Capacity= 400,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "David Robinson",
                            Title= "Network Security Expert",
                            Note= "Focusing on how automation can be used to enhance network security and detect vulnerabilities."
                        }
                    },
                    Description= "An in-depth look at how network automation can play a significant role in securing networks and improving threat detection.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Network Security Engineers, IT Managers, Security Enthusiasts",
                    EventLevel= "Advanced",
                    EventTags= ["Network Security", "Automation", "Threat Detection"]
                },
                new EventManagementData {
                    Id= 84,
                    Title= "Advanced Cybersecurity Threats and Mitigations",
                    Subject= "Introduction to Advanced Cybersecurity Threats",
                    StartTime= "2025-02-27T03:45:00.000Z",
                    EndTime= "2025-02-27T04:45:00.000Z",
                    RoomId= 1,
                    Capacity= 90,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Samuel Harris",
                            Title= "Cybersecurity Expert",
                            Note= "Exploring the advanced threats facing modern businesses and organizations in the digital age."
                        }
                    },
                    Description= "A session that introduces common and emerging cybersecurity threats, including advanced persistent threats (APTs) and ransomware.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Cybersecurity Professionals, IT Managers, Security Analysts",
                    EventLevel= "Advanced",
                    EventTags= ["Cybersecurity", "Ransomware", "Threats"]
                },
                new EventManagementData {
                    Id= 85,
                    Title= "Advanced Cybersecurity Threats and Mitigations",
                    Subject= "Phishing Attacks and Social Engineering",
                    StartTime= "2025-02-27T05:00:00.000Z",
                    EndTime= "2025-02-27T05:30:00.000Z",
                    RoomId= 1,
                    Capacity= 90,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Samuel Harris",
                            Title= "Cybersecurity Expert",
                            Note= "Understanding phishing attacks, social engineering tactics, and how to mitigate them."
                        }
                    },
                    Description= "A session focused on phishing, social engineering, and the techniques attackers use to trick employees into revealing sensitive information.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Security Professionals, Employees, IT Managers",
                    EventLevel= "Intermediate",
                    EventTags= ["Phishing", "Social Engineering", "Cybersecurity"]
                },
                new EventManagementData {
                    Id= 86,
                    Title= "Advanced Cybersecurity Threats and Mitigations",
                    Subject= "Malware and Ransomware Attacks",
                    StartTime= "2025-02-27T05:30:00.000Z",
                    EndTime= "2025-02-27T06:30:00.000Z",
                    RoomId= 1,
                    Capacity= 90,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Samuel Harris",
                            Title= "Cybersecurity Expert",
                            Note= "An analysis of various types of malware, ransomware, and how to protect systems from these threats."
                        }
                    },
                    Description= "This session will explore common types of malware and ransomware, their delivery mechanisms, and best practices for defense.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Cybersecurity Professionals, IT Support Staff, Business Leaders",
                    EventLevel= "Advanced",
                    EventTags= ["Malware", "Ransomware", "Cybersecurity"]
                },
                new EventManagementData {
                    Id= 87,
                    Title= "Advanced Cybersecurity Threats and Mitigations",
                    Subject= "Lunch Break",
                    StartTime= "2025-02-27T06:30:00.000Z",
                    EndTime= "2025-02-27T07:30:00.000Z",
                    RoomId= 1,
                    Capacity= 90,
                    Speakers= new List<Speaker>(),
                    Description= "Lunch break for relaxation and networking.",
                    Duration= "1 hour",
                    EventType= "Break",
                    TargetAudience= "All Attendees",
                    EventLevel= "All levels",
                    EventTags= ["Break", "Networking"]
                },
                new EventManagementData {
                    Id= 88,
                    Title= "Advanced Cybersecurity Threats and Mitigations",
                    Subject= "Network Security and Intrusion Detection",
                    StartTime= "2025-02-27T07:30:00.000Z",
                    EndTime= "2025-02-27T09:00:00.000Z",
                    RoomId= 1,
                    Capacity= 90,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Sarah Williams",
                            Title= "Network Security Expert",
                            Note= "Discussing the importance of intrusion detection systems (IDS) and other network defense mechanisms."
                        }
                    },
                    Description= "In this session, we’ll examine intrusion detection systems, firewalls, and other tools to detect and prevent unauthorized access.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Network Administrators, Security Engineers, IT Managers",
                    EventLevel= "Advanced",
                    EventTags= ["Network Security", "Intrusion Detection", "Firewalls"]
                },
                new EventManagementData {
                    Id= 89,
                    Title= "Advanced Cybersecurity Threats and Mitigations",
                    Subject= "Advanced Persistent Threats (APTs)",
                    StartTime= "2025-02-27T09:30:00.000Z",
                    EndTime= "2025-02-27T11:00:00.000Z",
                    RoomId= 1,
                    Capacity= 90,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Samuel Harris",
                            Title= "Cybersecurity Expert",
                            Note= "An advanced session on APTs, focusing on their persistence, methods of attack, and how to combat them."
                        }
                    },
                    Description= "This session will dive into APTs, how they are carried out by advanced hackers, and strategies for defending against them.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Cybersecurity Experts, IT Managers, Network Administrators",
                    EventLevel= "Advanced",
                    EventTags= ["APT", "Cybersecurity", "Advanced Threats"]
                },
                new EventManagementData {
                    Id= 90,
                    Title= "Advanced Cybersecurity Threats and Mitigations",
                    Subject= "Incident Response and Forensics",
                    StartTime= "2025-02-27T11:30:00.000Z",
                    EndTime= "2025-02-27T12:30:00.000Z",
                    RoomId= 1,
                    Capacity= 90,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Sarah Williams",
                            Title= "Cybersecurity Forensics Expert",
                            Note= "Understanding the importance of incident response and how to conduct proper forensics after a cyberattack."
                        }
                    },
                    Description= "A session on handling security incidents effectively, from detection to response and the forensic analysis needed afterward.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Incident Response Teams, Forensics Experts, Cybersecurity Professionals",
                    EventLevel= "Advanced",
                    EventTags= ["Incident Response", "Forensics", "Cybersecurity"]
                },
                new EventManagementData {
                    Id= 91,
                    Title= "Blockchain and Cryptocurrency Technologies",
                    Subject= "Introduction to Blockchain Technology",
                    StartTime= "2025-02-27T04:00:00.000Z",
                    EndTime= "2025-02-27T05:15:00.000Z",
                    RoomId= 2,
                    Capacity= 200,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "John Cooper",
                            Title= "Blockchain Expert",
                            Note= "An overview of blockchain technology and its potential to transform various industries."
                        }
                    },
                    Description= "This session introduces the basics of blockchain technology, its components, and its applications in various sectors.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Developers, Business Leaders, Crypto Enthusiasts",
                    EventLevel= "Beginner",
                    EventTags= ["Blockchain", "Cryptocurrency", "Tech Innovations"]
                },
                new EventManagementData {
                    Id= 92,
                    Title= "Blockchain and Cryptocurrency Technologies",
                    Subject= "Smart Contracts and DApps",
                    StartTime= "2025-02-27T05:30:00.000Z",
                    EndTime= "2025-02-27T06:50:00.000Z",
                    RoomId= 2,
                    Capacity= 200,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "John Cooper",
                            Title= "Blockchain Developer",
                            Note= "Exploring how smart contracts and decentralized applications (DApps) function on blockchain networks."
                        }
                    },
                    Description= "An in-depth session on the role of smart contracts and decentralized apps (DApps) in blockchain ecosystems.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Developers, Blockchain Enthusiasts, Entrepreneurs",
                    EventLevel= "Intermediate",
                    EventTags= ["Smart Contracts", "DApps", "Blockchain"]
                },
                new EventManagementData {
                    Id= 93,
                    Title= "Blockchain and Cryptocurrency Technologies",
                    Subject= "Cryptocurrency Mining and Consensus Algorithms",
                    StartTime= "2025-02-27T07:50:00.000Z",
                    EndTime= "2025-02-27T09:00:00.000Z",
                    RoomId= 2,
                    Capacity= 200,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "John Cooper",
                            Title= "Blockchain Developer",
                            Note= "Understanding how cryptocurrency mining works, and an introduction to consensus algorithms like Proof of Work (PoW) and Proof of Stake (PoS)."
                        }
                    },
                    Description= "A technical session on how mining works in the world of cryptocurrency and how consensus algorithms play a crucial role.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Crypto Enthusiasts, Developers, Miners",
                    EventLevel= "Intermediate",
                    EventTags= ["Cryptocurrency Mining", "PoW", "PoS"]
                },
                new EventManagementData {
                    Id= 94,
                    Title= "Blockchain and Cryptocurrency Technologies",
                    Subject= "Blockchain Use Cases Beyond Cryptocurrency",
                    StartTime= "2025-02-27T09:00:00.000Z",
                    EndTime= "2025-02-27T09:30:00.000Z",
                    RoomId= 2,
                    Capacity= 200,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Sophia Lee",
                            Title= "Blockchain Researcher",
                            Note= "Exploring how blockchain is applied in supply chains, healthcare, voting systems, and more."
                        }
                    },
                    Description= "This session explores real-world use cases of blockchain beyond cryptocurrency, such as logistics, health tech, and digital identity.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Blockchain Enthusiasts, Developers, Entrepreneurs",
                    EventLevel= "Intermediate",
                    EventTags= ["Blockchain Use Cases", "Tech Innovations", "Industry Applications"]
                },
                new EventManagementData {
                    Id= 95,
                    Title= "Blockchain and Cryptocurrency Technologies",
                    Subject= "Blockchain Security and Privacy Concerns",
                    StartTime= "2025-02-27T10:00:00.000Z",
                    EndTime= "2025-02-27T11:00:00.000Z",
                    RoomId= 2,
                    Capacity= 200,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Sophia Lee",
                            Title= "Blockchain Security Expert",
                            Note= "Understanding security challenges in blockchain and strategies for mitigating privacy and security risks."
                        }
                    },
                    Description= "A session on security risks in blockchain, with a focus on potential vulnerabilities in blockchain applications and privacy concerns.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Security Engineers, Developers, Blockchain Enthusiasts",
                    EventLevel= "Advanced",
                    EventTags= ["Blockchain Security", "Privacy", "Vulnerabilities"]
                },
                new EventManagementData {
                    Id= 96,
                    Title= "Blockchain and Cryptocurrency Technologies",
                    Subject= "Future Trends in Blockchain and Cryptocurrency",
                    StartTime= "2025-02-27T11:00:00.000Z",
                    EndTime= "2025-02-27T12:00:00.000Z",
                    RoomId= 2,
                    Capacity= 200,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "John Cooper",
                            Title= "Blockchain Visionary",
                            Note= "Discussing the future trends in blockchain technology, from scalability improvements to decentralized finance (DeFi)."
                        }
                    },
                    Description= "A discussion on the future direction of blockchain technology, focusing on scalability, DeFi, and innovations to come.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Blockchain Enthusiasts, Developers, Entrepreneurs",
                    EventLevel= "Advanced",
                    EventTags= ["Blockchain Future", "DeFi", "Tech Innovations"]
                },
                new EventManagementData {
                    Id= 97,
                    Title= "Modern Web Development and Frameworks",
                    Subject= "Introduction to Web Development with React",
                    StartTime= "2025-02-27T03:50:00.000Z",
                    EndTime= "2025-02-27T04:30:00.000Z",
                    RoomId= 3,
                    Capacity= 250,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Alex Johnson",
                            Title= "Web Developer",
                            Note= "An introduction to modern web development using the React framework and its components."
                        }
                    },
                    Description= "This session will cover the basics of building modern web applications with React, from setting up a project to rendering components.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Web Developers, Frontend Engineers, React Enthusiasts",
                    EventLevel= "Beginner",
                    EventTags= ["React", "Web Development", "Frontend"]
                },
                new EventManagementData {
                    Id= 98,
                    Title= "Modern Web Development and Frameworks",
                    Subject= "Advanced React Techniques",
                    StartTime= "2025-02-27T04:30:00.000Z",
                    EndTime= "2025-02-27T05:30:00.000Z",
                    RoomId= 3,
                    Capacity= 250,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Alex Johnson",
                            Title= "Web Developer",
                            Note= "A deep dive into advanced React features like hooks, context, and state management."
                        }
                    },
                    Description= "An in-depth session on advanced React concepts such as hooks, context API, Redux for state management, and performance optimizations.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "React Developers, Frontend Engineers",
                    EventLevel= "Intermediate",
                    EventTags= ["React", "State Management", "JavaScript"]
                },
                new EventManagementData {
                    Id= 99,
                    Title= "Modern Web Development and Frameworks",
                    Subject= "Building Responsive UIs with CSS Grid and Flexbox",
                    StartTime= "2025-02-27T06:00:00.000Z",
                    EndTime= "2025-02-27T07:00:00.000Z",
                    RoomId= 3,
                    Capacity= 250,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Sarah Mitchell",
                            Title= "UI/UX Designer",
                            Note= "Mastering modern CSS layout techniques, including Grid and Flexbox for building flexible and responsive web designs."
                        }
                    },
                    Description= "This session focuses on building modern, responsive user interfaces using CSS Grid and Flexbox to create flexible layouts.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "UI/UX Designers, Frontend Developers",
                    EventLevel= "Intermediate",
                    EventTags= ["CSS", "Grid", "Flexbox"]
                },
                new EventManagementData {
                    Id= 100,
                    Title= "Modern Web Development and Frameworks",
                    Subject= "Server-Side Rendering with Next.js",
                    StartTime= "2025-02-27T08:00:00.000Z",
                    EndTime= "2025-02-27T09:30:00.000Z",
                    RoomId= 3,
                    Capacity= 250,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "David Lee",
                            Title= "Full Stack Developer",
                            Note= "Exploring server-side rendering with Next.js and how it improves performance and SEO for React apps."
                        }
                    },
                    Description= "Learn about the advantages of server-side rendering with Next.js, and how it can enhance the performance and SEO of React applications.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Full Stack Developers, React Developers, SEO Specialists",
                    EventLevel= "Intermediate",
                    EventTags= ["Next.js", "Server-Side Rendering", "React"]
                },
                new EventManagementData {
                    Id= 101,
                    Title= "Modern Web Development and Frameworks",
                    Subject= "State Management with Redux",
                    StartTime= "2025-02-27T10:00:00.000Z",
                    EndTime= "2025-02-27T11:00:00.000Z",
                    RoomId= 3,
                    Capacity= 250,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "David Lee",
                            Title= "Full Stack Developer",
                            Note= "Understanding how to use Redux for global state management in React applications."
                        }
                    },
                    Description= "This session dives deep into state management with Redux, helping you build more maintainable React applications.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "React Developers, Full Stack Developers",
                    EventLevel= "Intermediate",
                    EventTags= ["Redux", "React", "State Management"]
                },
                new EventManagementData {
                    Id= 102,
                    Title= "Modern Web Development and Frameworks",
                    Subject= "JavaScript Performance Optimization Techniques",
                    StartTime= "2025-02-27T11:30:00.000Z",
                    EndTime= "2025-02-27T12:30:00.000Z",
                    RoomId= 3,
                    Capacity= 250,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Alex Johnson",
                            Title= "Web Developer",
                            Note= "Best practices for optimizing JavaScript performance in large-scale web applications."
                        }
                    },
                    Description= "This session focuses on performance optimization strategies for JavaScript, including lazy loading, memoization, and efficient rendering techniques.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Frontend Developers, Web Performance Engineers",
                    EventLevel= "Advanced",
                    EventTags= ["JavaScript", "Performance Optimization", "Web Development"]
                },
                new EventManagementData {
                    Id= 103,
                    Title= "Cloud Infrastructure and Kubernetes",
                    Subject= "Introduction to Cloud Computing and Services",
                    StartTime= "2025-02-27T03:30:00.000Z",
                    EndTime= "2025-02-27T04:30:00.000Z",
                    RoomId= 4,
                    Capacity= 350,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Mark Thompson",
                            Title= "Cloud Architect",
                            Note= "Exploring the fundamentals of cloud computing, including IaaS, PaaS, and SaaS models."
                        }
                    },
                    Description= "This session introduces cloud computing services, their architecture, and how businesses can leverage them to scale their operations.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Cloud Engineers, IT Professionals, Business Leaders",
                    EventLevel= "Beginner",
                    EventTags= ["Cloud Computing", "IaaS", "PaaS"]
                },
                new EventManagementData {
                    Id= 104,
                    Title= "Cloud Infrastructure and Kubernetes",
                    Subject= "Introduction to Kubernetes and Containerization",
                    StartTime= "2025-02-27T04:45:00.000Z",
                    EndTime= "2025-02-27T05:15:00.000Z",
                    RoomId= 4,
                    Capacity= 350,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Mark Thompson",
                            Title= "Cloud Architect",
                            Note= "Understanding Kubernetes, container orchestration, and how it simplifies cloud infrastructure management."
                        }
                    },
                    Description= "Learn about Kubernetes, containerization, and the role they play in modern cloud infrastructure and application deployment.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "DevOps Engineers, Cloud Architects, Developers",
                    EventLevel= "Intermediate",
                    EventTags= ["Kubernetes", "Containerization", "DevOps"]
                },
                new EventManagementData {
                    Id= 105,
                    Title= "Cloud Infrastructure and Kubernetes",
                    Subject= "Automating Deployments with Kubernetes",
                    StartTime= "2025-02-27T05:30:00.000Z",
                    EndTime= "2025-02-27T06:30:00.000Z",
                    RoomId= 4,
                    Capacity= 350,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Sarah Nelson",
                            Title= "DevOps Engineer",
                            Note= "Exploring how Kubernetes can be used to automate deployment pipelines and scale applications effectively."
                        }
                    },
                    Description= "This session focuses on using Kubernetes for automating continuous integration and deployment (CI/CD) pipelines.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "DevOps Engineers, Cloud Architects",
                    EventLevel= "Intermediate",
                    EventTags= ["CI/CD", "Kubernetes", "Automation"]
                },
                new EventManagementData {
                    Id= 106,
                    Title= "Cloud Infrastructure and Kubernetes",
                    Subject= "Scaling Applications in Kubernetes",
                    StartTime= "2025-02-27T07:30:00.000Z",
                    EndTime= "2025-02-27T08:30:00.000Z",
                    RoomId= 4,
                    Capacity= 350,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Sarah Nelson",
                            Title= "DevOps Engineer",
                            Note= "Understanding how Kubernetes helps scale containerized applications efficiently across multiple nodes."
                        }
                    },
                    Description= "In this session, we will cover scaling techniques in Kubernetes and how to maintain high availability for cloud-native applications.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Cloud Engineers, DevOps Engineers",
                    EventLevel= "Intermediate",
                    EventTags= ["Scaling", "Kubernetes", "Cloud Infrastructure"]
                },
                new EventManagementData {
                    Id= 107,
                    Title= "Cloud Infrastructure and Kubernetes",
                    Subject= "Monitoring and Troubleshooting Kubernetes Applications",
                    StartTime= "2025-02-27T09:00:00.000Z",
                    EndTime= "2025-02-27T10:00:00.000Z",
                    RoomId= 4,
                    Capacity= 350,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Mark Thompson",
                            Title= "Cloud Architect",
                            Note= "Learn about the tools and strategies for monitoring and troubleshooting Kubernetes-based applications."
                        }
                    },
                    Description= "This session dives deep into monitoring and troubleshooting Kubernetes applications using tools like Prometheus and Grafana.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "DevOps Engineers, Cloud Engineers",
                    EventLevel= "Advanced",
                    EventTags= ["Monitoring", "Kubernetes", "Troubleshooting"]
                },
                new EventManagementData {
                    Id= 108,
                    Title= "Cloud Infrastructure and Kubernetes",
                    Subject= "Kubernetes Security Best Practices",
                    StartTime= "2025-02-27T10:30:00.000Z",
                    EndTime= "2025-02-27T11:45:00.000Z",
                    RoomId= 4,
                    Capacity= 350,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Sarah Nelson",
                            Title= "DevOps Engineer",
                            Note= "Best practices for securing your Kubernetes clusters and managing security risks."
                        }
                    },
                    Description= "A session on Kubernetes security practices, from securing clusters to managing network policies and container vulnerabilities.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Security Engineers, DevOps Engineers",
                    EventLevel= "Advanced",
                    EventTags= ["Kubernetes", "Security", "Best Practices"]
                },
                new EventManagementData {
                    Id= 109,
                    Title= "Artificial Intelligence and Data Science",
                    Subject= "Introduction to Machine Learning Algorithms",
                    StartTime= "2025-02-28T03:30:00.000Z",
                    EndTime= "2025-02-28T04:30:00.000Z",
                    RoomId= 1,
                    Capacity= 100,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Ethan Williams",
                            Title= "Data Scientist",
                            Note= "An overview of essential machine learning algorithms such as linear regression, decision trees, and k-nearest neighbors."
                        }
                    },
                    Description= "This session introduces core machine learning algorithms, their uses, and how they are applied in real-world problems.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Data Scientists, Machine Learning Enthusiasts",
                    EventLevel= "Beginner",
                    EventTags= ["Machine Learning", "Algorithms", "Data Science"]
                },
                new EventManagementData {
                    Id= 110,
                    Title= "Artificial Intelligence and Data Science",
                    Subject= "Break",
                    StartTime= "2025-02-28T04:30:00.000Z",
                    EndTime= "2025-02-28T05:00:00.000Z",
                    RoomId= 1,
                    Capacity= 100,
                    Speakers= new List<Speaker>(),
                    Description= "A short break for attendees to relax and network.",
                    Duration= "30 minutes",
                    EventType= "Break",
                    TargetAudience= "All Participants",
                    EventLevel= "All Levels",
                    EventTags= []
                },
                new EventManagementData {
                    Id= 111,
                    Title= "Artificial Intelligence and Data Science",
                    Subject= "Deep Learning: Fundamentals and Applications",
                    StartTime= "2025-02-28T05:00:00.000Z",
                    EndTime= "2025-02-28T06:15:00.000Z",
                    RoomId= 1,
                    Capacity= 100,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Ethan Williams",
                            Title= "Data Scientist",
                            Note= "A look at deep learning, neural networks, and their applications in image recognition and natural language processing."
                        }
                    },
                    Description= "An introduction to deep learning, its architectures like CNN and RNN, and how they’re transforming industries.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "AI Engineers, Data Scientists",
                    EventLevel= "Intermediate",
                    EventTags= ["Deep Learning", "Neural Networks", "Artificial Intelligence"]
                },
                new EventManagementData {
                    Id= 112,
                    Title= "Artificial Intelligence and Data Science",
                    Subject= "Natural Language Processing and Text Analytics",
                    StartTime= "2025-02-28T07:30:00.000Z",
                    EndTime= "2025-02-28T08:30:00.000Z",
                    RoomId= 1,
                    Capacity= 100,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Sophia Clark",
                            Title= "AI Researcher",
                            Note= "Exploring how NLP is used to analyze and understand human language, including sentiment analysis and chatbots."
                        }
                    },
                    Description= "This session covers the basics of NLP, its applications in real-world systems, and how to use NLP for text analytics.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "AI Engineers, Data Scientists",
                    EventLevel= "Intermediate",
                    EventTags= ["Natural Language Processing", "AI", "Text Analytics"]
                },
                new EventManagementData {
                    Id= 113,
                    Title= "Artificial Intelligence and Data Science",
                    Subject= "Computer Vision and Image Processing",
                    StartTime= "2025-02-28T09:00:00.000Z",
                    EndTime= "2025-02-28T10:30:00.000Z",
                    RoomId= 1,
                    Capacity= 100,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Sophia Clark",
                            Title= "AI Researcher",
                            Note= "A session on image classification, object detection, and advanced techniques in computer vision."
                        }
                    },
                    Description= "In this session, we’ll dive into computer vision and the methods used to extract useful information from images.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Computer Vision Engineers, AI Enthusiasts",
                    EventLevel= "Intermediate",
                    EventTags= ["Computer Vision", "AI", "Image Processing"]
                },
                new EventManagementData {
                    Id= 114,
                    Title= "Artificial Intelligence and Data Science",
                    Subject= "AI in Healthcare: Opportunities and Challenges",
                    StartTime= "2025-02-28T10:45:00.000Z",
                    EndTime= "2025-02-28T11:15:00.000Z",
                    RoomId= 1,
                    Capacity= 100,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Liam Johnson",
                            Title= "AI Specialist",
                            Note= "Exploring how AI technologies are transforming healthcare, from diagnostic tools to personalized treatments."
                        }
                    },
                    Description= "AI is making a big impact in healthcare, improving diagnosis, treatment, and patient outcomes. This session explores these applications.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "AI Enthusiasts, Healthcare Professionals",
                    EventLevel= "Intermediate",
                    EventTags= ["AI", "Healthcare", "Medical Tech"]
                },
                new EventManagementData {
                    Id= 115,
                    Title= "Artificial Intelligence and Data Science",
                    Subject= "AI in Autonomous Vehicles",
                    StartTime= "2025-02-28T11:15:00.000Z",
                    EndTime= "2025-02-28T12:15:00.000Z",
                    RoomId= 1,
                    Capacity= 100,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Ethan Williams",
                            Title= "Data Scientist",
                            Note= "Exploring the role of AI in autonomous driving, from computer vision to decision-making algorithms."
                        }
                    },
                    Description= "This session dives into the technologies that power autonomous vehicles, such as computer vision, machine learning, and sensor integration.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "AI Engineers, Automotive Engineers",
                    EventLevel= "Advanced",
                    EventTags= ["AI", "Autonomous Vehicles", "Machine Learning"]
                },
                new EventManagementData {
                    Id= 116,
                    Title= "Cloud Computing and DevOps",
                    Subject= "Introduction to Cloud Computing and Services",
                    StartTime= "2025-02-28T03:30:00.000Z",
                    EndTime= "2025-02-28T04:30:00.000Z",
                    RoomId= 2,
                    Capacity= 150,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Mark Thompson",
                            Title= "Cloud Architect",
                            Note= "Exploring the fundamentals of cloud computing, including IaaS, PaaS, and SaaS models."
                        }
                    },
                    Description= "This session introduces cloud computing services, their architecture, and how businesses can leverage them to scale their operations.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Cloud Engineers, IT Professionals, Business Leaders",
                    EventLevel= "Beginner",
                    EventTags= ["Cloud Computing", "IaaS", "PaaS"]
                },
                new EventManagementData {
                    Id= 117,
                    Title= "Cloud Computing and DevOps",
                    Subject= "Introduction to Kubernetes and Containerization",
                    StartTime= "2025-02-28T04:30:00.000Z",
                    EndTime= "2025-02-28T05:00:00.000Z",
                    RoomId= 2,
                    Capacity= 150,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "David Lee",
                            Title= "DevOps Engineer",
                            Note= "Understanding Kubernetes, container orchestration, and how it simplifies cloud infrastructure management."
                        }
                    },
                    Description= "This session introduces Kubernetes and how containerization helps improve scalability and deployment in cloud environments.",
                    Duration= "30 minutes",
                    EventType= "Technical Session",
                    TargetAudience= "DevOps Engineers, Cloud Architects, Developers",
                    EventLevel= "Intermediate",
                    EventTags= ["Kubernetes", "Containerization", "DevOps"]
                },
                new EventManagementData {
                    Id= 118,
                    Title= "Cloud Computing and DevOps",
                    Subject= "Break",
                    StartTime= "2025-02-28T05:00:00.000Z",
                    EndTime= "2025-02-28T05:30:00.000Z",
                    RoomId= 2,
                    Capacity= 150,
                    Speakers= new List<Speaker>(),
                    Description= "A short break for attendees to relax and network.",
                    Duration= "30 minutes",
                    EventType= "Break",
                    TargetAudience= "All Participants",
                    EventLevel= "All Levels",
                    EventTags= ["Networking", "Relax"]
                },
                new EventManagementData {
                    Id= 119,
                    Title= "Cloud Computing and DevOps",
                    Subject= "CI/CD Pipelines with Jenkins and Kubernetes",
                    StartTime= "2025-02-28T05:30:00.000Z",
                    EndTime= "2025-02-28T07:00:00.000Z",
                    RoomId= 2,
                    Capacity= 150,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "David Lee",
                            Title= "DevOps Engineer",
                            Note= "Leveraging Jenkins to automate CI/CD pipelines in Kubernetes environments."
                        }
                    },
                    Description= "In this session, you’ll learn how Jenkins is used in combination with Kubernetes to automate the CI/CD process.",
                    Duration= "1 hour 30 minutes",
                    EventType= "Technical Session",
                    TargetAudience= "DevOps Engineers, Cloud Engineers",
                    EventLevel= "Intermediate",
                    EventTags= ["CI/CD", "Jenkins", "Kubernetes"]
                },
                new EventManagementData {
                    Id= 120,
                    Title= "Cloud Computing and DevOps",
                    Subject= "Lunch Break",
                    StartTime= "2025-02-28T07:00:00.000Z",
                    EndTime= "2025-02-28T08:00:00.000Z",
                    RoomId= 2,
                    Capacity= 150,
                    Speakers= new List<Speaker>(),
                    Description= "Lunch break for networking and relaxation.",
                    Duration= "1 hour",
                    EventType= "Break",
                    TargetAudience= "All Attendees",
                    EventLevel= "All Levels",
                    EventTags= ["Break", "Networking"]
                },
                new EventManagementData {
                    Id= 121,
                    Title= "Cloud Computing and DevOps",
                    Subject= "Cloud Infrastructure Automation with Terraform",
                    StartTime= "2025-02-28T08:00:00.000Z",
                    EndTime= "2025-02-28T09:00:00.000Z",
                    RoomId= 2,
                    Capacity= 150,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Mark Thompson",
                            Title= "Cloud Architect",
                            Note= "Using Terraform to automate cloud infrastructure deployment and management."
                        }
                    },
                    Description= "Terraform is a powerful tool for cloud automation. This session covers its features, benefits, and best practices.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Cloud Engineers, DevOps Engineers",
                    EventLevel= "Intermediate",
                    EventTags= ["Terraform", "Cloud Automation", "Infrastructure as Code"]
                },
                new EventManagementData {
                    Id= 122,
                    Title= "Cloud Computing and DevOps",
                    Subject= "Serverless Architectures and Their Benefits",
                    StartTime= "2025-02-28T09:30:00.000Z",
                    EndTime= "2025-02-28T11:00:00.000Z",
                    RoomId= 2,
                    Capacity= 150,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Sarah Nelson",
                            Title= "Cloud Specialist",
                            Note= "Exploring serverless computing and how it simplifies cloud architectures while reducing costs."
                        }
                    },
                    Description= "In this session, we explore the benefits of serverless architectures in cloud computing and when to use them.",
                    Duration= "1 hour 30 minutes",
                    EventType= "Technical Session",
                    TargetAudience= "Cloud Engineers, Architects",
                    EventLevel= "Intermediate",
                    EventTags= ["Serverless", "Cloud Computing", "DevOps"]
                },
                new EventManagementData {
                    Id= 123,
                    Title= "Cloud Computing and DevOps",
                    Subject= "Automating Infrastructure with Ansible",
                    StartTime= "2025-02-28T11:15:00.000Z",
                    EndTime= "2025-02-28T12:15:00.000Z",
                    RoomId= 2,
                    Capacity= 150,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Sarah Nelson",
                            Title= "Cloud Specialist",
                            Note= "Ansible for automating cloud infrastructure deployment and configuration management."
                        }
                    },
                    Description= "This session focuses on how to use Ansible for automating infrastructure tasks and configuration management in the cloud.",
                    Duration= "45 minutes",
                    EventType= "Technical Session",
                    TargetAudience= "Cloud Engineers, DevOps Engineers",
                    EventLevel= "Intermediate",
                    EventTags= ["Ansible", "Cloud Automation", "Infrastructure Management"]
                },
                new EventManagementData {
                    Id= 124,
                    Title= "Cloud Infrastructure and Security",
                    Subject= "Cloud Security Best Practices",
                    StartTime= "2025-02-28T03:30:00.000Z",
                    EndTime= "2025-02-28T04:30:00.000Z",
                    RoomId= 3,
                    Capacity= 280,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Oliver Smith",
                            Title= "Cloud Security Engineer",
                            Note= "Security best practices for cloud environments to ensure data protection and compliance."
                        }
                    },
                    Description= "This session will cover best practices for securing cloud environments, including encryption, access control, and vulnerability management.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Security Engineers, Cloud Engineers",
                    EventLevel= "Intermediate",
                    EventTags= ["Cloud Security", "Encryption", "Compliance"]
                },
                new EventManagementData {
                    Id= 125,
                    Title= "Cloud Infrastructure and Security",
                    Subject= "Identity and Access Management in the Cloud",
                    StartTime= "2025-02-28T04:45:00.000Z",
                    EndTime= "2025-02-28T05:45:00.000Z",
                    RoomId= 3,
                    Capacity= 280,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Oliver Smith",
                            Title= "Cloud Security Engineer",
                            Note= "Understanding IAM services in cloud platforms and how to implement them for secure access management."
                        }
                    },
                    Description= "In this session, we will explore Identity and Access Management services (IAM) in the cloud and how to implement best practices for access control.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Security Engineers, IT Professionals",
                    EventLevel= "Intermediate",
                    EventTags= ["IAM", "Cloud Security", "Access Control"]
                },
                new EventManagementData {
                    Id= 126,
                    Title= "Cloud Infrastructure and Security",
                    Subject= "Cloud Vulnerability Scanning and Remediation",
                    StartTime= "2025-02-28T05:45:00.000Z",
                    EndTime= "2025-02-28T06:45:00.000Z",
                    RoomId= 3,
                    Capacity= 280,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Mia Roberts",
                            Title= "Security Specialist",
                            Note= "Scanning cloud environments for vulnerabilities and effective remediation strategies to minimize risks."
                        }
                    },
                    Description= "This session covers tools and techniques for scanning cloud infrastructure for security vulnerabilities and how to remediate them.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Security Engineers, DevOps Engineers",
                    EventLevel= "Advanced",
                    EventTags= ["Cloud Security", "Vulnerability Management", "Risk Remediation"]
                },
                new EventManagementData {
                    Id= 127,
                    Title= "Cloud Infrastructure and Security",
                    Subject= "Disaster Recovery and Business Continuity in Cloud",
                    StartTime= "2025-02-28T07:30:00.000Z",
                    EndTime= "2025-02-28T08:30:00.000Z",
                    RoomId= 3,
                    Capacity= 280,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Mia Roberts",
                            Title= "Security Specialist",
                            Note= "Designing disaster recovery and business continuity plans to ensure availability of cloud-based services."
                        }
                    },
                    Description= "This session discusses designing disaster recovery strategies and business continuity plans for cloud environments.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Cloud Engineers, Business Continuity Professionals",
                    EventLevel= "Advanced",
                    EventTags= ["Disaster Recovery", "Business Continuity", "Cloud Security"]
                },
                new EventManagementData {
                    Id= 128,
                    Title= "Cloud Infrastructure and Security",
                    Subject= "Cloud Network Security",
                    StartTime= "2025-02-28T09:00:00.000Z",
                    EndTime= "2025-02-28T10:30:00.000Z",
                    RoomId= 3,
                    Capacity= 280,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Michael Brown",
                            Title= "Network Security Expert",
                            Note= "Securing cloud networks with firewalls, load balancers, and virtual private networks (VPNs)."
                        }
                    },
                    Description= "This session covers the importance of securing cloud networks using various techniques such as VPNs, firewalls, and encryption.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Network Engineers, Security Experts",
                    EventLevel= "Intermediate",
                    EventTags= ["Cloud Network Security", "Encryption", "Firewall"]
                },
                new EventManagementData {
                    Id= 129,
                    Title= "Cloud Infrastructure and Security",
                    Subject= "Zero Trust Security Model in Cloud Environments",
                    StartTime= "2025-02-28T11:00:00.000Z",
                    EndTime= "2025-02-28T12:00:00.000Z",
                    RoomId= 3,
                    Capacity= 280,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Michael Brown",
                            Title= "Network Security Expert",
                            Note= "Understanding the Zero Trust model and how it helps secure cloud environments against modern threats."
                        }
                    },
                    Description= "In this session, we will discuss the Zero Trust security model and its importance in securing cloud-based systems.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Security Engineers, Cloud Engineers",
                    EventLevel= "Advanced",
                    EventTags= ["Zero Trust", "Cloud Security", "Network Security"]
                },
                new EventManagementData {
                    Id= 130,
                    Title= "Networking and Cloud Infrastructure",
                    Subject= "Networking Fundamentals for Cloud Environments",
                    StartTime= "2025-02-28T04:00:00.000Z",
                    EndTime= "2025-02-28T04:30:00.000Z",
                    RoomId= 4,
                    Capacity= 400,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "James Wilson",
                            Title= "Network Engineer",
                            Note= "Networking concepts and protocols critical to deploying cloud infrastructure."
                        }
                    },
                    Description= "This session covers the basic networking concepts and protocols used when designing and deploying cloud environments.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Network Engineers, Cloud Architects",
                    EventLevel= "Beginner",
                    EventTags= ["Networking", "Cloud", "Infrastructure"]
                },
                new EventManagementData {
                    Id= 131,
                    Title= "Networking and Cloud Infrastructure",
                    Subject= "SDN (Software Defined Networking) and Cloud",
                    StartTime= "2025-02-28T04:30:00.000Z",
                    EndTime= "2025-02-28T05:30:00.000Z",
                    RoomId= 4,
                    Capacity= 400,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "James Wilson",
                            Title= "Network Engineer",
                            Note= "Exploring how SDN is revolutionizing network management and the deployment of cloud services."
                        }
                    },
                    Description= "SDN allows more flexibility and control over cloud networks. This session covers its role and impact in cloud computing environments.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Network Engineers, Cloud Engineers",
                    EventLevel= "Intermediate",
                    EventTags= ["SDN", "Cloud", "Networking"]
                },
                new EventManagementData {
                    Id= 132,
                    Title= "Networking and Cloud Infrastructure",
                    Subject= "Virtualization and Network Function Virtualization (NFV)",
                    StartTime= "2025-02-28T06:00:00.000Z",
                    EndTime= "2025-02-28T07:00:00.000Z",
                    RoomId= 4,
                    Capacity= 400,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Sophia Green",
                            Title= "Cloud Engineer",
                            Note= "Understanding how virtualization and NFV are used to deploy scalable, flexible, and cost-efficient cloud services."
                        }
                    },
                    Description= "In this session, we will explore how network function virtualization (NFV) and network virtualization can optimize cloud infrastructure.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Cloud Engineers, Network Engineers",
                    EventLevel= "Intermediate",
                    EventTags= ["Virtualization", "NFV", "Cloud Infrastructure"]
                },
                new EventManagementData {
                    Id= 133,
                    Title= "Networking and Cloud Infrastructure",
                    Subject= "Cloud Networking Services: AWS, GCP, Azure",
                    StartTime= "2025-02-28T08:00:00.000Z",
                    EndTime= "2025-02-28T09:00:00.000Z",
                    RoomId= 4,
                    Capacity= 400,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Sophia Green",
                            Title= "Cloud Engineer",
                            Note= "Exploring networking services provided by AWS, GCP, and Azure and their applications in cloud networking."
                        }
                    },
                    Description= "This session will compare the networking services provided by major cloud platforms like AWS, Google Cloud, and Azure.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Cloud Engineers, Network Architects",
                    EventLevel= "Intermediate",
                    EventTags= ["Cloud Networking", "AWS", "Azure", "GCP"]
                },
                new EventManagementData {
                    Id= 134,
                    Title= "Networking and Cloud Infrastructure",
                    Subject= "5G Networks and Cloud Integration",
                    StartTime= "2025-02-28T09:30:00.000Z",
                    EndTime= "2025-02-28T10:30:00.000Z",
                    RoomId= 4,
                    Capacity= 400,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Noah Taylor",
                            Title= "Network Architect",
                            Note= "Exploring the integration of 5G networks with cloud infrastructures for ultra-fast and reliable connectivity."
                        }
                    },
                    Description= "This session explores how 5G networks can be integrated with cloud infrastructures to enable faster and more reliable communication.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Network Engineers, Cloud Architects",
                    EventLevel= "Advanced",
                    EventTags= ["5G", "Cloud Integration", "Networking"]
                },
                new EventManagementData {
                    Id= 135,
                    Title= "Networking and Cloud Infrastructure",
                    Subject= "Cloud Load Balancing and Scaling Networks",
                    StartTime= "2025-02-28T11:00:00.000Z",
                    EndTime= "2025-02-28T12:15:00.000Z",
                    RoomId= 4,
                    Capacity= 400,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Noah Taylor",
                            Title= "Network Architect",
                            Note= "Exploring techniques for load balancing and scaling networks to ensure high availability in the cloud."
                        }
                    },
                    Description= "This session will teach you how to design and implement cloud load balancing and network scaling strategies.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Network Engineers, Cloud Engineers",
                    EventLevel= "Advanced",
                    EventTags= ["Cloud Networking", "Load Balancing", "Network Scaling"]
                },
                new EventManagementData {
                    Id= 136,
                    Title= "Advanced Networking Techniques",
                    Subject= "BGP (Border Gateway Protocol) Fundamentals",
                    StartTime= "2025-03-01T03:30:00.000Z",
                    EndTime= "2025-03-01T05:00:00.000Z",
                    RoomId= 1,
                    Capacity= 70,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "John Carter",
                            Title= "Network Engineer",
                            Note= "Understanding the fundamentals and practical applications of BGP in large-scale networks."
                        }
                    },
                    Description= "This session introduces the basics of Border Gateway Protocol (BGP) and its usage in inter-domain routing.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Network Engineers",
                    EventLevel= "Intermediate",
                    EventTags= ["BGP", "Networking", "Routing"]
                },
                new EventManagementData {
                    Id= 137,
                    Title= "Advanced Networking Techniques",
                    Subject= "IPv6 Networking in the Cloud Era",
                    StartTime= "2025-03-01T05:30:00.000Z",
                    EndTime= "2025-03-01T06:30:00.000Z",
                    RoomId= 1,
                    Capacity= 70,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "John Carter",
                            Title= "Network Engineer",
                            Note= "Exploring the implementation and challenges of IPv6 addressing in cloud environments."
                        }
                    },
                    Description= "This session explores IPv6 networking fundamentals, benefits, and its role in modern cloud infrastructures.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Network Engineers, Cloud Engineers",
                    EventLevel= "Intermediate",
                    EventTags= ["IPv6", "Cloud Networking", "Networking"]
                },
                new EventManagementData {
                    Id= 138,
                    Title= "Advanced Networking Techniques",
                    Subject= "Software-Defined Networking (SDN) Architecture",
                    StartTime= "2025-03-01T06:30:00.000Z",
                    EndTime= "2025-03-01T07:00:00.000Z",
                    RoomId= 1,
                    Capacity= 70,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Sophia Green",
                            Title= "Cloud Engineer",
                            Note= "In-depth look into SDN architecture and its advantages in cloud networking."
                        }
                    },
                    Description= "This session covers SDN architecture and how it enhances flexibility and management of cloud-based networks.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Network Engineers, Cloud Architects",
                    EventLevel= "Advanced",
                    EventTags= ["SDN", "Networking", "Cloud Architecture"]
                },
                new EventManagementData {
                    Id= 139,
                    Title= "Advanced Networking Techniques",
                    Subject= "VLANs and Network Segmentation for Cloud Security",
                    StartTime= "2025-03-01T08:00:00.000Z",
                    EndTime= "2025-03-01T09:30:00.000Z",
                    RoomId= 1,
                    Capacity= 70,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Michael Brown",
                            Title= "Network Architect",
                            Note= "Utilizing VLANs and network segmentation to improve cloud security and performance."
                        }
                    },
                    Description= "Learn how VLANs can be used to segment networks and enhance security in cloud environments.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Network Engineers, Cloud Security Professionals",
                    EventLevel= "Intermediate",
                    EventTags= ["VLAN", "Network Security", "Cloud"]
                },

                new EventManagementData {
                    Id= 140,
                    Title= "Advanced Networking Techniques",
                    Subject= "Network Automation with Ansible and Python",
                    StartTime= "2025-03-01T10:15:00.000Z",
                    EndTime= "2025-03-01T11:15:00.000Z",
                    RoomId= 1,
                    Capacity= 70,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "James Wilson",
                            Title= "Cloud Network Specialist",
                            Note= "Automating network configurations and operations using Ansible and Python."
                        }
                    },
                    Description= "This session discusses how to automate network configuration, monitoring, and management using Ansible and Python.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Network Engineers, Automation Engineers",
                    EventLevel= "Advanced",
                    EventTags= ["Network Automation", "Ansible", "Python"]
                },
                new EventManagementData {
                    Id= 141,
                    Title= "Advanced Networking Techniques",
                    Subject= "Network Performance Monitoring in Cloud Environments",
                    StartTime= "2025-03-01T11:30:00.000Z",
                    EndTime= "2025-03-01T12:30:00.000Z",
                    RoomId= 1,
                    Capacity= 70,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Sophia Green",
                            Title= "Cloud Engineer",
                            Note= "Understanding how to monitor and optimize network performance in cloud-based infrastructures."
                        }
                    },
                    Description= "This session focuses on the best practices and tools for monitoring network performance in the cloud.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Network Engineers, Cloud Engineers",
                    EventLevel= "Intermediate",
                    EventTags= ["Network Monitoring", "Cloud Networking", "Optimization"]
                },
                new EventManagementData {
                    Id= 142,
                    Title= "Cloud Infrastructure Optimization",
                    Subject= "Optimizing Cloud Storage Solutions",
                    StartTime= "2025-03-01T04:00:00.000Z",
                    EndTime= "2025-03-01T05:00:00.000Z",
                    RoomId= 2,
                    Capacity= 180,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Emily Davis",
                            Title= "Cloud Architect",
                            Note= "Optimizing cloud storage solutions for performance, security, and cost-effectiveness."
                        }
                    },
                    Description= "This session covers best practices for optimizing cloud storage, ensuring efficiency and cost control.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Cloud Engineers, IT Professionals",
                    EventLevel= "Intermediate",
                    EventTags= ["Cloud Storage", "Optimization", "Cost Management"]
                },
                new EventManagementData {
                    Id= 143,
                    Title= "Cloud Infrastructure Optimization",
                    Subject= "Scaling Cloud Infrastructure with Auto-scaling Groups",
                    StartTime= "2025-03-01T05:10:00.000Z",
                    EndTime= "2025-03-01T06:00:00.000Z",
                    RoomId= 2,
                    Capacity= 180,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Emily Davis",
                            Title= "Cloud Architect",
                            Note= "Leveraging auto-scaling to dynamically scale cloud infrastructure based on demand."
                        }
                    },
                    Description= "Learn how auto-scaling works in cloud platforms to handle fluctuating demand and optimize resources.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Cloud Engineers, Architects",
                    EventLevel= "Intermediate",
                    EventTags= ["Auto-scaling", "Cloud Infrastructure", "Cloud Optimization"]
                },
                new EventManagementData {
                    Id= 144,
                    Title= "Cloud Infrastructure Optimization",
                    Subject= "Cost Optimization in Cloud with Reserved Instances",
                    StartTime= "2025-03-01T06:00:00.000Z",
                    EndTime= "2025-03-01T07:00:00.000Z",
                    RoomId= 2,
                    Capacity= 180,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Michael Green",
                            Title= "Cloud Specialist",
                            Note= "How to reduce costs by using reserved instances and other cost-saving strategies in the cloud."
                        }
                    },
                    Description= "This session explores how to optimize costs in the cloud by using reserved instances and other cloud cost-saving mechanisms.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Cloud Engineers, Finance Professionals",
                    EventLevel= "Intermediate",
                    EventTags= ["Cost Optimization", "Cloud Economics", "Cloud Management"]
                },
                new EventManagementData {
                    Id= 145,
                    Title= "Cloud Infrastructure Optimization",
                    Subject= "Managing Multi-Cloud Environments",
                    StartTime= "2025-03-01T08:00:00.000Z",
                    EndTime= "2025-03-01T08:30:00.000Z",
                    RoomId= 2,
                    Capacity= 180,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Sarah Brown",
                            Title= "Cloud Engineer",
                            Note= "Best practices for managing resources and services in a multi-cloud environment."
                        }
                    },
                    Description= "This session will discuss best practices for handling multi-cloud environments and ensuring smooth operations.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Cloud Engineers, Multi-Cloud Architects",
                    EventLevel= "Advanced",
                    EventTags= ["Multi-cloud", "Cloud Management", "Cloud Optimization"]
                },
                new EventManagementData {
                    Id= 146,
                    Title= "Cloud Infrastructure Optimization",
                    Subject= "Optimizing Cloud Database Performance",
                    StartTime= "2025-03-01T09:00:00.000Z",
                    EndTime= "2025-03-01T11:00:00.000Z",
                    RoomId= 2,
                    Capacity= 180,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Sarah Brown",
                            Title= "Cloud Database Expert",
                            Note= "Tips and tools for optimizing the performance of cloud-hosted databases."
                        }
                    },
                    Description= "This session will focus on strategies for improving cloud database performance and ensuring fast, efficient data retrieval.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Cloud Database Administrators, Engineers",
                    EventLevel= "Intermediate",
                    EventTags= ["Cloud Databases", "Optimization", "Performance"]
                },
                new EventManagementData {
                    Id= 147,
                    Title= "Cloud Security and Privacy",
                    Subject= "Cloud Security Essentials: Protecting Your Data in the Cloud",
                    StartTime= "2025-03-01T03:30:00.000Z",
                    EndTime= "2025-03-01T04:45:00.000Z",
                    RoomId= 3,
                    Capacity= 300,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Jack Turner",
                            Title= "Cloud Security Specialist",
                            Note= "Understanding the key principles of cloud security and data protection best practices."
                        }
                    },
                    Description= "Learn the fundamentals of cloud security, covering encryption, data protection, and risk mitigation strategies.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Security Engineers, Cloud Architects",
                    EventLevel= "Intermediate",
                    EventTags= ["Cloud Security", "Data Protection", "Encryption"]
                },
                new EventManagementData {
                    Id= 148,
                    Title= "Cloud Security and Privacy",
                    Subject= "Implementing Identity and Access Management in Cloud",
                    StartTime= "2025-03-01T05:00:00.000Z",
                    EndTime= "2025-03-01T05:30:00.000Z",
                    RoomId= 3,
                    Capacity= 300,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Jack Turner",
                            Title= "Cloud Security Specialist",
                            Note= "Best practices for implementing IAM in cloud-based systems to ensure secure access."
                        }
                    },
                    Description= "In this session, we discuss how to implement robust Identity and Access Management (IAM) strategies for secure cloud environments.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Security Engineers, Cloud Developers",
                    EventLevel= "Intermediate",
                    EventTags= ["IAM", "Cloud Security", "Access Management"]
                },
                new EventManagementData {
                    Id= 149,
                    Title= "Cloud Security and Privacy",
                    Subject= "Securing Cloud-Based APIs and Microservices",
                    StartTime= "2025-03-01T05:30:00.000Z",
                    EndTime= "2025-03-01T06:30:00.000Z",
                    RoomId= 3,
                    Capacity= 300,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Sarah Collins",
                            Title= "Cloud Engineer",
                            Note= "Focusing on securing APIs and microservices in a cloud-based environment using the latest tools."
                        }
                    },
                    Description= "Learn how to secure APIs and microservices, including OAuth, encryption, and token management for cloud applications.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Cloud Engineers, API Developers",
                    EventLevel= "Intermediate",
                    EventTags= ["API Security", "Microservices", "Cloud Security"]
                },
                new EventManagementData {
                    Id= 150,
                    Title= "Cloud Security and Privacy",
                    Subject= "Lunch Break",
                    StartTime= "2025-03-01T06:30:00.000Z",
                    EndTime= "2025-03-01T07:30:00.000Z",
                    RoomId= 3,
                    Capacity= 300,
                    Speakers= new List<Speaker>(),
                    Description= "Lunch break for networking and relaxation.",
                    Duration= "1 hour",
                    EventType= "Break",
                    TargetAudience= "All Attendees",
                    EventLevel= "All Levels",
                    EventTags= ["Break", "Networking"]
                },
                new EventManagementData {
                    Id= 151,
                    Title= "Cloud Security and Privacy",
                    Subject= "Understanding Cloud Compliance and Regulatory Requirements",
                    StartTime= "2025-03-01T07:30:00.000Z",
                    EndTime= "2025-03-01T09:00:00.000Z",
                    RoomId= 3,
                    Capacity= 300,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Michael Davis",
                            Title= "Cloud Compliance Expert",
                            Note= "A guide to navigating the regulatory requirements that affect cloud deployments and services."
                        }
                    },
                    Description= "This session will help you understand various compliance frameworks and their implementation in the cloud environment.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Cloud Architects, Compliance Officers",
                    EventLevel= "Advanced",
                    EventTags= ["Compliance", "Cloud Security", "Regulatory Requirements"]
                },
                new EventManagementData {
                    Id= 152,
                    Title= "Cloud Security and Privacy",
                    Subject= "Incident Response in Cloud Environments",
                    StartTime= "2025-03-01T10:00:00.000Z",
                    EndTime= "2025-03-01T11:15:00.000Z",
                    RoomId= 3,
                    Capacity= 300,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "David Wright",
                            Title= "Incident Response Specialist",
                            Note= "Learn how to effectively respond to and manage security incidents in a cloud environment."
                        }
                    },
                    Description= "In this session, we’ll cover the incident response process in cloud environments, including tools and strategies for mitigation.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Security Professionals, Incident Response Teams",
                    EventLevel= "Advanced",
                    EventTags= ["Incident Response", "Cloud Security", "Security Mitigation"]
                },
                new EventManagementData {
                    Id= 153,
                    Title= "Cloud Security and Privacy",
                    Subject= "Advanced Cloud Encryption Techniques",
                    StartTime= "2025-03-01T11:15:00.000Z",
                    EndTime= "2025-03-01T12:30:00.000Z",
                    RoomId= 3,
                    Capacity= 300,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "David Wright",
                            Title= "Encryption Specialist",
                            Note= "A deep dive into advanced encryption methods used to protect data in cloud environments."
                        }
                    },
                    Description= "This session will discuss advanced encryption techniques, key management, and how to protect sensitive data in cloud environments.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Security Engineers, Cloud Architects",
                    EventLevel= "Advanced",
                    EventTags= ["Encryption", "Cloud Security", "Data Protection"]
                },
                new EventManagementData {
                    Id= 154,
                    Title= "Cloud DevOps and Automation",
                    Subject= "Introduction to DevOps in Cloud Environments",
                    StartTime= "2025-03-01T03:45:00.000Z",
                    EndTime= "2025-03-01T04:45:00.000Z",
                    RoomId= 4,
                    Capacity= 370,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Olivia Martinez",
                            Title= "DevOps Engineer",
                            Note= "An introduction to the key principles and practices of DevOps in cloud-based systems."
                        }
                    },
                    Description= "This session covers the basics of DevOps principles, including continuous integration and continuous delivery in the cloud.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "DevOps Engineers, Cloud Engineers",
                    EventLevel= "Intermediate",
                    EventTags= ["DevOps", "Cloud Automation", "CI/CD"]
                },
                new EventManagementData {
                    Id= 155,
                    Title= "Cloud DevOps and Automation",
                    Subject= "Automating Cloud Deployments with Infrastructure as Code (IaC)",
                    StartTime= "2025-03-01T04:45:00.000Z",
                    EndTime= "2025-03-01T05:15:00.000Z",
                    RoomId= 4,
                    Capacity= 370,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Olivia Martinez",
                            Title= "DevOps Engineer",
                            Note= "Using IaC tools like Terraform and CloudFormation to automate infrastructure deployment in the cloud."
                        }
                    },
                    Description= "This session will demonstrate how to use Infrastructure as Code (IaC) tools to automate and manage cloud infrastructure.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "DevOps Engineers, Cloud Architects",
                    EventLevel= "Intermediate",
                    EventTags= ["IaC", "Cloud Automation", "Terraform"]
                },
                new EventManagementData {
                    Id= 156,
                    Title= "Cloud DevOps and Automation",
                    Subject= "Break",
                    StartTime= "2025-03-01T05:15:00.000Z",
                    EndTime= "2025-03-01T05:45:00.000Z",
                    RoomId= 4,
                    Capacity= 370,
                    Speakers= new List<Speaker>(),
                    Description= "A short break for attendees to relax and network.",
                    Duration= "30 minutes",
                    EventType= "Break",
                    TargetAudience= "All Participants",
                    EventLevel= "All Levels",
                    EventTags= ["Networking", "Relax"]
                },
                new EventManagementData {
                    Id= 157,
                    Title= "Cloud DevOps and Automation",
                    Subject= "Continuous Integration and Delivery (CI/CD) for Cloud Applications",
                    StartTime= "2025-03-01T05:45:00.000Z",
                    EndTime= "2025-03-01T07:00:00.000Z",
                    RoomId= 4,
                    Capacity= 370,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Ethan Parker",
                            Title= "Cloud DevOps Engineer",
                            Note= "In-depth exploration of CI/CD pipelines in cloud environments using Jenkins, CircleCI, and AWS CodePipeline."
                        }
                    },
                    Description= "This session focuses on setting up and managing CI/CD pipelines for cloud-based applications to achieve faster development cycles.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "DevOps Engineers, Cloud Developers",
                    EventLevel= "Advanced",
                    EventTags= ["CI/CD", "Cloud Applications", "DevOps"]
                },
                new EventManagementData {
                    Id= 158,
                    Title= "Cloud DevOps and Automation",
                    Subject= "Lunch Break",
                    StartTime= "2025-03-01T07:00:00.000Z",
                    EndTime= "2025-03-01T08:00:00.000Z",
                    RoomId= 4,
                    Capacity= 370,
                    Speakers= new List<Speaker>(),
                    Description= "Lunch break for networking and relaxation.",
                    Duration= "1 hour",
                    EventType= "Break",
                    TargetAudience= "All Attendees",
                    EventLevel= "All Levels",
                    EventTags= ["Break", "Networking"]
                },
                new EventManagementData {
                    Id= 159,
                    Title= "Cloud DevOps and Automation",
                    Subject= "Serverless Architectures and Automation in the Cloud",
                    StartTime= "2025-03-01T08:00:00.000Z",
                    EndTime= "2025-03-01T09:30:00.000Z",
                    RoomId= 4,
                    Capacity= 370,
                    Speakers= new List<Speaker> {
                        new Speaker{
                            Name= "Ethan Parker",
                            Title= "Cloud DevOps Engineer",
                            Note= "Exploring serverless architecture and how to automate deployments with cloud-native tools."
                        }
                    },
                    Description= "This session will cover the benefits of serverless architecture and how to automate deployments using cloud-native services.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "DevOps Engineers, Cloud Architects",
                    EventLevel= "Advanced",
                    EventTags= ["Serverless", "Cloud Automation", "DevOps"]
                },
                new EventManagementData {
                    Id= 160,
                    Title= "Cloud DevOps and Automation",
                    Subject= "Monitoring and Logging for Cloud Infrastructure",
                    StartTime= "2025-03-01T10:00:00.000Z",
                    EndTime= "2025-03-01T11:00:00.000Z",
                    RoomId= 4,
                    Capacity= 370,
                    Speakers= new List<Speaker> {
                         new Speaker{
                            Name= "Hannah Lee",
                            Title= "DevOps Specialist",
                            Note= "Best practices for monitoring and logging cloud infrastructure, using tools like CloudWatch and ELK Stack."
                          }
                    },
                    Description= "In this session, we’ll discuss how to monitor and log cloud infrastructure effectively to ensure operational efficiency.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "DevOps Engineers, Cloud Administrators",
                    EventLevel= "Intermediate",
                    EventTags= ["Monitoring", "Cloud Logging", "DevOps"]
                }
            };
        }

        public static List<RoomData> GetRooms()
        {
            return new List<RoomData>
            {
                new RoomData { RoomId = 1, RoomName = "Room A", RoomCapacity = 100, RoomColor = "#0F6CBD" },
                new RoomData { RoomId = 2, RoomName = "Room B", RoomCapacity = 200, RoomColor = "#B71C1C" },
                new RoomData { RoomId = 3, RoomName = "Room C", RoomCapacity = 300, RoomColor = "#E65100" },
                new RoomData { RoomId = 4, RoomName = "Room D", RoomCapacity = 400, RoomColor = "#558B2F" }
            };
        }

        public static List<EventManagementData> GetCloudSecurityEventData()
        {
            return new List<EventManagementData>
            {
                 new EventManagementData {
                    Id=1,
                    Title= "Cloud Security Essentials",
                    Subject= "Securing Cloud Networks and Data",
                    Capacity= 100,
                    Speakers= new List<Speaker> {
                        new Speaker{
                        Name= "Aidan Cole",
                        Title= "Cloud Security Expert",
                        Note= "Best practices for securing cloud networks and protecting sensitive data in the cloud."
                        },
                        new Speaker{
                        Name= "Riley Smith",
                        Title= "Security Engineer",
                        Note= "Hands-on strategies for implementing robust cloud security measures."
                        }
                    },
                    Description= "Learn key strategies and tools for securing cloud networks and managing cloud data securely.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Cloud Engineers, Security Experts",
                    EventLevel= "Intermediate",
                    EventTags= ["Cloud Security", "Data Protection", "Network Security"]
                 },
                 new EventManagementData {
                     Id=2,
                    Title= "Cloud Security Essentials",
                    Subject= "Identity and Access Management in Cloud",
                    Capacity= 100,
                    Speakers= new List<Speaker> {
                      new Speaker{
                        Name= "Emily Parker",
                        Title= "IAM Specialist",
                        Note= "Implementing identity and access management in cloud environments to enhance security."
                      },
                      new Speaker{
                        Name= "Mason Reed",
                        Title= "Cloud Engineer",
                        Note= "Configuring IAM solutions like AWS IAM, Azure Active Directory for optimal security."
                      }
                    },
                    Description= "Discover how to implement Identity and Access Management (IAM) solutions to secure cloud-based resources.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Cloud Administrators, Security Engineers",
                    EventLevel= "Intermediate",
                    EventTags= ["IAM", "Cloud Security", "Access Control"]
                 },
                 new EventManagementData {
                     Id=3,
                    Title= "Cloud Security Essentials",
                    Subject= "Cloud Data Encryption and Privacy",
                    Capacity= 100,
                    Speakers= new List<Speaker> {
                        new Speaker{
                        Name= "Jordan Lee",
                        Title= "Security Consultant",
                        Note= "Data encryption techniques for securing sensitive data in the cloud environment."
                        },
                        new Speaker{
                        Name= "Sarah Khan",
                        Title= "Cloud Architect",
                        Note= "Architecting systems that comply with data privacy regulations and ensure data integrity."
                        }
                    },
                    Description= "Implement data encryption techniques and privacy measures to safeguard cloud-based data.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Cloud Architects, Data Protection Officers",
                    EventLevel= "Intermediate",
                    EventTags= ["Encryption", "Cloud Privacy", "Data Protection"]
                 },
                 new EventManagementData {
                     Id=4,
                    Title= "Cloud Security Essentials",
                    Subject= "Threat Detection in Cloud Environments",
                    Capacity= 100,
                    Speakers= new List<Speaker> {
                      new Speaker{
                        Name= "Olivia Brooks",
                        Title= "Security Analyst",
                        Note= "Exploring tools and methodologies for detecting security threats in cloud platforms."
                      },
                      new Speaker{
                        Name= "David Shaw",
                        Title= "Security Engineer",
                        Note= "Using cloud-native threat detection systems like AWS GuardDuty, Azure Security Center."
                      }
                    },
                    Description= "Learn how to detect threats using advanced security tools and AI-powered threat intelligence in cloud environments.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Cloud Security Engineers, IT Professionals",
                    EventLevel= "Advanced",
                    EventTags= ["Cloud Threats", "Cloud Security", "Threat Detection"]
                 },
                 new EventManagementData {
                     Id=5,
                    Title= "Cloud Security Essentials",
                    Subject= "Disaster Recovery and Backup in Cloud",
                    Capacity= 100,
                    Speakers= new List<Speaker> {
                      new Speaker{
                        Name= "Maxwell Davis",
                        Title= "Cloud Recovery Specialist",
                        Note= "Implementing robust disaster recovery and backup strategies in cloud infrastructure."
                      },
                      new Speaker{
                        Name= "Grace Evans",
                        Title= "Cloud Engineer",
                        Note= "Best practices for backup and disaster recovery to ensure business continuity in the cloud."
                      }
                    },
                    Description= "Strategies for implementing disaster recovery and backup solutions in the cloud for maximum data protection.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Cloud Engineers, Disaster Recovery Experts",
                    EventLevel= "Intermediate",
                    EventTags= ["Backup", "Disaster Recovery", "Cloud Security"]
                 }
            };
        }

        public static List<EventManagementData> GetAIAutomationEventData()
        {
            return new List<EventManagementData>
            {
                new EventManagementData {
                    Id=6,
                    Title= "AI for Automation",
                    Subject= "Automating Tasks with AI and Machine Learning",
                    Capacity= 200,
                    Speakers= new List<Speaker> {
                      new Speaker{
                        Name= "Olivia Grant",
                        Title= "AI Researcher",
                        Note= "Exploring the use of AI to automate repetitive tasks and optimize workflows."
                      },
                      new Speaker{
                        Name= "Liam Young",
                        Title= "AI Engineer",
                        Note= "Hands-on implementation of machine learning models for automation."
                      }
                    },
                    Description= "Learn how AI and machine learning can automate processes, enhancing productivity and efficiency.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "AI Engineers, Automation Specialists",
                    EventLevel= "Intermediate",
                    EventTags= ["AI", "Automation", "Machine Learning"]
                 },
                 new EventManagementData {
                     Id=7,
                    Title= "AI for Automation",
                    Subject= "AI for Process Optimization",
                    Capacity= 200,
                    Speakers= new List<Speaker> {
                      new Speaker{
                        Name= "Nina Brooks",
                        Title= "Machine Learning Expert",
                        Note= "Optimizing processes and workflows using AI algorithms for better outcomes."
                      },
                      new Speaker{
                        Name= "Daniel Foster",
                        Title= "Data Scientist",
                        Note= "Practical applications of AI in process optimization across industries."
                      }
                    },
                    Description= "Explore how AI can optimize business processes to reduce costs and improve performance.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Data Scientists, Business Analysts",
                    EventLevel= "Intermediate",
                    EventTags= ["AI", "Process Optimization", "Automation"]
                 },
                 new EventManagementData {
                    Id=8,
                    Title= "AI for Automation",
                    Subject= "Implementing AI-Powered Automation Solutions",
                    Capacity= 200,
                    Speakers= new List<Speaker> {
                      new Speaker{
                        Name= "George Walsh",
                        Title= "AI Solutions Architect",
                        Note= "Designing end-to-end AI-powered automation systems for various business needs."
                      },
                      new Speaker{
                        Name= "Isabella Johnson",
                        Title= "Machine Learning Developer",
                        Note= "Integrating AI models into business applications for real-world automation."
                      }
                    },
                    Description= "Learn how to implement AI-powered automation solutions to streamline processes in business.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Solutions Architects, AI Engineers",
                    EventLevel= "Advanced",
                    EventTags= ["AI Automation", "Business Solutions", "Machine Learning"]
                 },
                 new EventManagementData {
                     Id=9,
                    Title= "AI for Automation",
                    Subject= "AI for Predictive Maintenance",
                    Capacity= 200,
                    Speakers= new List<Speaker> {
                      new Speaker{
                        Name= "Lena Parker",
                        Title= "AI Expert",
                        Note= "Using AI for predictive maintenance in industries like manufacturing and healthcare."
                      },
                      new Speaker{
                        Name= "Oscar Lee",
                        Title= "Maintenance Engineer",
                        Note= "Leveraging AI-driven insights to predict equipment failure before it occurs."
                      }
                    },
                    Description= "Discover how AI-driven predictive maintenance can enhance operational efficiency and reduce costs.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Manufacturing Engineers, Data Scientists",
                    EventLevel= "Advanced",
                    EventTags= ["AI", "Predictive Maintenance", "Industrial Automation"]
                 },
                 new EventManagementData {
                     Id=10,
                    Title= "AI for Automation",
                    Subject= "AI-Powered Chatbots for Business",
                    Capacity= 200,
                    Speakers= new List<Speaker> {
                      new Speaker{
                        Name= "David Morris",
                        Title= "AI Specialist",
                        Note= "Building intelligent AI-powered chatbots to automate customer support and services."
                      },
                      new Speaker{
                        Name= "Sophie Turner",
                        Title= "Chatbot Developer",
                        Note= "Creating and integrating AI-powered chatbots into customer service workflows."
                      }
                    },
                    Description= "Learn how to design and deploy AI chatbots to automate customer interactions and improve service delivery.",
                    Duration= "1 hour",
                    EventType= "Technical Session",
                    TargetAudience= "Developers, Customer Service Managers",
                    EventLevel= "Intermediate",
                    EventTags= ["AI", "Chatbots", "Automation"]
                 }
            };
        }
    }
}
