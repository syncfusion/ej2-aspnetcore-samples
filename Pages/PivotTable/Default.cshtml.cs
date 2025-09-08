#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.PivotTable
{
    public class DefaultModel : PageModel
    {
        public class DefaultData
        {
            public int Sold { get; set; }
            public double Amount { get; set; }
            public string Country { get; set; }
            public string Products { get; set; }
            public string Year { get; set; }
            public string Quarter { get; set; }
        }
        public List<DefaultData> GetDefaultData()
        {
            List<DefaultData> defaultData = new List<DefaultData>();
            defaultData.Add(new DefaultData { Sold = 31, Amount = 52824, Country = "France", Products = "Mountain Bikes", Year = "FY 2022", Quarter = "Q1" });
            defaultData.Add(new DefaultData { Sold = 51, Amount = 86904, Country = "France", Products = "Mountain Bikes", Year = "FY 2022", Quarter = "Q2" });
            defaultData.Add(new DefaultData { Sold = 90, Amount = 153360, Country = "France", Products = "Mountain Bikes", Year = "FY 2022", Quarter = "Q3" });
            defaultData.Add(new DefaultData { Sold = 25, Amount = 42600, Country = "France", Products = "Mountain Bikes", Year = "FY 2022", Quarter = "Q4" });
            defaultData.Add(new DefaultData { Sold = 27, Amount = 46008, Country = "France", Products = "Mountain Bikes", Year = "FY 2023", Quarter = "Q1" });
            defaultData.Add(new DefaultData { Sold = 49, Amount = 83496, Country = "France", Products = "Mountain Bikes", Year = "FY 2023", Quarter = "Q2" });
            defaultData.Add(new DefaultData { Sold = 95, Amount = 161880, Country = "France", Products = "Mountain Bikes", Year = "FY 2023", Quarter = "Q3" });
            defaultData.Add(new DefaultData { Sold = 67, Amount = 114168, Country = "France", Products = "Mountain Bikes", Year = "FY 2023", Quarter = "Q4" });
            defaultData.Add(new DefaultData { Sold = 75, Amount = 127800, Country = "France", Products = "Mountain Bikes", Year = "FY 2024", Quarter = "Q1" });
            defaultData.Add(new DefaultData { Sold = 67, Amount = 114168, Country = "France", Products = "Mountain Bikes", Year = "FY 2024", Quarter = "Q2" });
            defaultData.Add(new DefaultData { Sold = 69, Amount = 117576, Country = "France", Products = "Mountain Bikes", Year = "FY 2024", Quarter = "Q3" });
            defaultData.Add(new DefaultData { Sold = 90, Amount = 153360, Country = "France", Products = "Mountain Bikes", Year = "FY 2024", Quarter = "Q4" });
            defaultData.Add(new DefaultData { Sold = 16, Amount = 27264, Country = "France", Products = "Mountain Bikes", Year = "FY 2025", Quarter = "Q1" });
            defaultData.Add(new DefaultData { Sold = 83, Amount = 124422, Country = "France", Products = "Road Bikes", Year = "FY 2022", Quarter = "Q1" });
            defaultData.Add(new DefaultData { Sold = 57, Amount = 85448, Country = "France", Products = "Road Bikes", Year = "FY 2022", Quarter = "Q2" });
            defaultData.Add(new DefaultData { Sold = 20, Amount = 29985, Country = "France", Products = "Road Bikes", Year = "FY 2022", Quarter = "Q3" });
            defaultData.Add(new DefaultData { Sold = 93, Amount = 139412, Country = "France", Products = "Road Bikes", Year = "FY 2022", Quarter = "Q4" });
            defaultData.Add(new DefaultData { Sold = 35, Amount = 52470, Country = "France", Products = "Road Bikes", Year = "FY 2023", Quarter = "Q1" });
            defaultData.Add(new DefaultData { Sold = 28, Amount = 41977, Country = "France", Products = "Road Bikes", Year = "FY 2023", Quarter = "Q2" });
            defaultData.Add(new DefaultData { Sold = 48, Amount = 71957, Country = "France", Products = "Road Bikes", Year = "FY 2023", Quarter = "Q3" });
            defaultData.Add(new DefaultData { Sold = 36, Amount = 53969, Country = "France", Products = "Road Bikes", Year = "FY 2023", Quarter = "Q4" });
            defaultData.Add(new DefaultData { Sold = 25, Amount = 37480, Country = "France", Products = "Road Bikes", Year = "FY 2024", Quarter = "Q1" });
            defaultData.Add(new DefaultData { Sold = 69, Amount = 103436, Country = "France", Products = "Road Bikes", Year = "FY 2024", Quarter = "Q2" });
            defaultData.Add(new DefaultData { Sold = 16, Amount = 23989, Country = "France", Products = "Road Bikes", Year = "FY 2024", Quarter = "Q3" });
            defaultData.Add(new DefaultData { Sold = 28, Amount = 41977, Country = "France", Products = "Road Bikes", Year = "FY 2024", Quarter = "Q4" });
            defaultData.Add(new DefaultData { Sold = 19, Amount = 28486, Country = "France", Products = "Road Bikes", Year = "FY 2025", Quarter = "Q1" });
            defaultData.Add(new DefaultData { Sold = 89, Amount = 141999.5, Country = "France", Products = "Touring Bikes", Year = "FY 2022", Quarter = "Q1" });
            defaultData.Add(new DefaultData { Sold = 91, Amount = 145190.5, Country = "France", Products = "Touring Bikes", Year = "FY 2022", Quarter = "Q2" });
            defaultData.Add(new DefaultData { Sold = 24, Amount = 38292, Country = "France", Products = "Touring Bikes", Year = "FY 2022", Quarter = "Q3" });
            defaultData.Add(new DefaultData { Sold = 75, Amount = 119662.5, Country = "France", Products = "Touring Bikes", Year = "FY 2022", Quarter = "Q4" });
            defaultData.Add(new DefaultData { Sold = 100, Amount = 159550, Country = "France", Products = "Touring Bikes", Year = "FY 2023", Quarter = "Q1" });
            defaultData.Add(new DefaultData { Sold = 30, Amount = 47865, Country = "France", Products = "Touring Bikes", Year = "FY 2023", Quarter = "Q2" });
            defaultData.Add(new DefaultData { Sold = 69, Amount = 110089.5, Country = "France", Products = "Touring Bikes", Year = "FY 2023", Quarter = "Q3" });
            defaultData.Add(new DefaultData { Sold = 25, Amount = 39887.5, Country = "France", Products = "Touring Bikes", Year = "FY 2023", Quarter = "Q4" });
            defaultData.Add(new DefaultData { Sold = 42, Amount = 67011, Country = "France", Products = "Touring Bikes", Year = "FY 2024", Quarter = "Q1" });
            defaultData.Add(new DefaultData { Sold = 94, Amount = 149977, Country = "France", Products = "Touring Bikes", Year = "FY 2024", Quarter = "Q2" });
            defaultData.Add(new DefaultData { Sold = 76, Amount = 121258, Country = "France", Products = "Touring Bikes", Year = "FY 2024", Quarter = "Q3" });
            defaultData.Add(new DefaultData { Sold = 52, Amount = 82966, Country = "France", Products = "Touring Bikes", Year = "FY 2024", Quarter = "Q4" });
            defaultData.Add(new DefaultData { Sold = 33, Amount = 52651.5, Country = "France", Products = "Touring Bikes", Year = "FY 2025", Quarter = "Q1" });
            defaultData.Add(new DefaultData { Sold = 16, Amount = 23989, Country = "Germany", Products = "Road Bikes", Year = "FY 2022", Quarter = "Q1" });
            defaultData.Add(new DefaultData { Sold = 21, Amount = 33505.5, Country = "Germany", Products = "Touring Bikes", Year = "FY 2022", Quarter = "Q1" });
            defaultData.Add(new DefaultData { Sold = 74, Amount = 126096, Country = "Germany", Products = "Mountain Bikes", Year = "FY 2022", Quarter = "Q1" });
            defaultData.Add(new DefaultData { Sold = 99, Amount = 148406, Country = "Germany", Products = "Road Bikes", Year = "FY 2023", Quarter = "Q1" });
            defaultData.Add(new DefaultData { Sold = 31, Amount = 49460.5, Country = "Germany", Products = "Touring Bikes", Year = "FY 2023", Quarter = "Q1" });
            defaultData.Add(new DefaultData { Sold = 57, Amount = 97128, Country = "Germany", Products = "Mountain Bikes", Year = "FY 2023", Quarter = "Q1" });
            defaultData.Add(new DefaultData { Sold = 41, Amount = 61464, Country = "Germany", Products = "Road Bikes", Year = "FY 2024", Quarter = "Q1" });
            defaultData.Add(new DefaultData { Sold = 64, Amount = 102112, Country = "Germany", Products = "Touring Bikes", Year = "FY 2024", Quarter = "Q1" });
            defaultData.Add(new DefaultData { Sold = 85, Amount = 144840, Country = "Germany", Products = "Mountain Bikes", Year = "FY 2024", Quarter = "Q1" });
            defaultData.Add(new DefaultData { Sold = 76, Amount = 129504, Country = "Germany", Products = "Mountain Bikes", Year = "FY 2025", Quarter = "Q1" });
            defaultData.Add(new DefaultData { Sold = 33, Amount = 56232, Country = "Germany", Products = "Mountain Bikes", Year = "FY 2022", Quarter = "Q2" });
            defaultData.Add(new DefaultData { Sold = 71, Amount = 120984, Country = "Germany", Products = "Mountain Bikes", Year = "FY 2023", Quarter = "Q2" });
            defaultData.Add(new DefaultData { Sold = 81, Amount = 138024, Country = "Germany", Products = "Mountain Bikes", Year = "FY 2024", Quarter = "Q2" });
            defaultData.Add(new DefaultData { Sold = 65, Amount = 110760, Country = "Germany", Products = "Mountain Bikes", Year = "FY 2022", Quarter = "Q3" });
            defaultData.Add(new DefaultData { Sold = 39, Amount = 66456, Country = "Germany", Products = "Mountain Bikes", Year = "FY 2023", Quarter = "Q3" });
            defaultData.Add(new DefaultData { Sold = 91, Amount = 155064, Country = "Germany", Products = "Mountain Bikes", Year = "FY 2024", Quarter = "Q3" });
            defaultData.Add(new DefaultData { Sold = 16, Amount = 27264, Country = "Germany", Products = "Mountain Bikes", Year = "FY 2022", Quarter = "Q4" });
            defaultData.Add(new DefaultData { Sold = 59, Amount = 100536, Country = "Germany", Products = "Mountain Bikes", Year = "FY 2023", Quarter = "Q4" });
            defaultData.Add(new DefaultData { Sold = 36, Amount = 61344, Country = "Germany", Products = "Mountain Bikes", Year = "FY 2024", Quarter = "Q4" });
            defaultData.Add(new DefaultData { Sold = 39, Amount = 58466, Country = "Germany", Products = "Road Bikes", Year = "FY 2025", Quarter = "Q1" });
            defaultData.Add(new DefaultData { Sold = 47, Amount = 70458, Country = "Germany", Products = "Road Bikes", Year = "FY 2022", Quarter = "Q2" });
            defaultData.Add(new DefaultData { Sold = 19, Amount = 28486, Country = "Germany", Products = "Road Bikes", Year = "FY 2023", Quarter = "Q2" });
            defaultData.Add(new DefaultData { Sold = 34, Amount = 50971, Country = "Germany", Products = "Road Bikes", Year = "FY 2024", Quarter = "Q2" });
            defaultData.Add(new DefaultData { Sold = 34, Amount = 50971, Country = "Germany", Products = "Road Bikes", Year = "FY 2022", Quarter = "Q3" });
            defaultData.Add(new DefaultData { Sold = 26, Amount = 38979, Country = "Germany", Products = "Road Bikes", Year = "FY 2023", Quarter = "Q3" });
            defaultData.Add(new DefaultData { Sold = 15, Amount = 22490, Country = "Germany", Products = "Road Bikes", Year = "FY 2024", Quarter = "Q3" });
            defaultData.Add(new DefaultData { Sold = 83, Amount = 124422, Country = "Germany", Products = "Road Bikes", Year = "FY 2022", Quarter = "Q4" });
            defaultData.Add(new DefaultData { Sold = 79, Amount = 118426, Country = "Germany", Products = "Road Bikes", Year = "FY 2023", Quarter = "Q4" });
            defaultData.Add(new DefaultData { Sold = 14, Amount = 20991, Country = "Germany", Products = "Road Bikes", Year = "FY 2024", Quarter = "Q4" });
            defaultData.Add(new DefaultData { Sold = 15, Amount = 23932.5, Country = "Germany", Products = "Touring Bikes", Year = "FY 2025", Quarter = "Q1" });
            defaultData.Add(new DefaultData { Sold = 47, Amount = 74988.5, Country = "Germany", Products = "Touring Bikes", Year = "FY 2022", Quarter = "Q2" });
            defaultData.Add(new DefaultData { Sold = 93, Amount = 148381.5, Country = "Germany", Products = "Touring Bikes", Year = "FY 2023", Quarter = "Q2" });
            defaultData.Add(new DefaultData { Sold = 13, Amount = 20741.5, Country = "Germany", Products = "Touring Bikes", Year = "FY 2024", Quarter = "Q2" });
            defaultData.Add(new DefaultData { Sold = 44, Amount = 70202, Country = "Germany", Products = "Touring Bikes", Year = "FY 2022", Quarter = "Q3" });
            defaultData.Add(new DefaultData { Sold = 59, Amount = 94134.5, Country = "Germany", Products = "Touring Bikes", Year = "FY 2023", Quarter = "Q3" });
            defaultData.Add(new DefaultData { Sold = 34, Amount = 54247, Country = "Germany", Products = "Touring Bikes", Year = "FY 2024", Quarter = "Q3" });
            defaultData.Add(new DefaultData { Sold = 48, Amount = 76584, Country = "Germany", Products = "Touring Bikes", Year = "FY 2022", Quarter = "Q4" });
            defaultData.Add(new DefaultData { Sold = 35, Amount = 55842.5, Country = "Germany", Products = "Touring Bikes", Year = "FY 2023", Quarter = "Q4" });
            defaultData.Add(new DefaultData { Sold = 71, Amount = 113280.5, Country = "Germany", Products = "Touring Bikes", Year = "FY 2024", Quarter = "Q4" });
            defaultData.Add(new DefaultData { Sold = 77, Amount = 131208, Country = "United Kingdom", Products = "Mountain Bikes", Year = "FY 2022", Quarter = "Q1" });
            defaultData.Add(new DefaultData { Sold = 92, Amount = 156768, Country = "United Kingdom", Products = "Mountain Bikes", Year = "FY 2022", Quarter = "Q2" });
            defaultData.Add(new DefaultData { Sold = 51, Amount = 86904, Country = "United Kingdom", Products = "Mountain Bikes", Year = "FY 2022", Quarter = "Q3" });
            defaultData.Add(new DefaultData { Sold = 91, Amount = 155064, Country = "United Kingdom", Products = "Mountain Bikes", Year = "FY 2022", Quarter = "Q4" });
            defaultData.Add(new DefaultData { Sold = 90, Amount = 153360, Country = "United Kingdom", Products = "Mountain Bikes", Year = "FY 2023", Quarter = "Q1" });
            defaultData.Add(new DefaultData { Sold = 56, Amount = 95424, Country = "United Kingdom", Products = "Mountain Bikes", Year = "FY 2023", Quarter = "Q2" });
            defaultData.Add(new DefaultData { Sold = 14, Amount = 23856, Country = "United Kingdom", Products = "Mountain Bikes", Year = "FY 2023", Quarter = "Q3" });
            defaultData.Add(new DefaultData { Sold = 95, Amount = 161880, Country = "United Kingdom", Products = "Mountain Bikes", Year = "FY 2023", Quarter = "Q4" });
            defaultData.Add(new DefaultData { Sold = 24, Amount = 40896, Country = "United Kingdom", Products = "Mountain Bikes", Year = "FY 2024", Quarter = "Q1" });
            defaultData.Add(new DefaultData { Sold = 39, Amount = 66456, Country = "United Kingdom", Products = "Mountain Bikes", Year = "FY 2024", Quarter = "Q2" });
            defaultData.Add(new DefaultData { Sold = 84, Amount = 143136, Country = "United Kingdom", Products = "Mountain Bikes", Year = "FY 2024", Quarter = "Q3" });
            defaultData.Add(new DefaultData { Sold = 40, Amount = 68160, Country = "United Kingdom", Products = "Mountain Bikes", Year = "FY 2024", Quarter = "Q4" });
            defaultData.Add(new DefaultData { Sold = 96, Amount = 163584, Country = "United Kingdom", Products = "Mountain Bikes", Year = "FY 2025", Quarter = "Q1" });
            defaultData.Add(new DefaultData { Sold = 24, Amount = 35981, Country = "United Kingdom", Products = "Road Bikes", Year = "FY 2022", Quarter = "Q1" });
            defaultData.Add(new DefaultData { Sold = 86, Amount = 128919, Country = "United States", Products = "Road Bikes", Year = "FY 2022", Quarter = "Q1" });
            defaultData.Add(new DefaultData { Sold = 31, Amount = 46474, Country = "United Kingdom", Products = "Road Bikes", Year = "FY 2022", Quarter = "Q2" });
            defaultData.Add(new DefaultData { Sold = 36, Amount = 53969, Country = "United States", Products = "Road Bikes", Year = "FY 2022", Quarter = "Q2" });
            defaultData.Add(new DefaultData { Sold = 40, Amount = 59965, Country = "United Kingdom", Products = "Road Bikes", Year = "FY 2022", Quarter = "Q3" });
            defaultData.Add(new DefaultData { Sold = 69, Amount = 103436, Country = "United States", Products = "Road Bikes", Year = "FY 2022", Quarter = "Q3" });
            defaultData.Add(new DefaultData { Sold = 95, Amount = 142410, Country = "United Kingdom", Products = "Road Bikes", Year = "FY 2022", Quarter = "Q4" });
            defaultData.Add(new DefaultData { Sold = 95, Amount = 142410, Country = "United States", Products = "Road Bikes", Year = "FY 2022", Quarter = "Q4" });
            defaultData.Add(new DefaultData { Sold = 30, Amount = 44975, Country = "United Kingdom", Products = "Road Bikes", Year = "FY 2023", Quarter = "Q1" });
            defaultData.Add(new DefaultData { Sold = 11, Amount = 16494, Country = "United States", Products = "Road Bikes", Year = "FY 2023", Quarter = "Q1" });
            defaultData.Add(new DefaultData { Sold = 97, Amount = 145408, Country = "United Kingdom", Products = "Road Bikes", Year = "FY 2023", Quarter = "Q2" });
            defaultData.Add(new DefaultData { Sold = 16, Amount = 23989, Country = "United States", Products = "Road Bikes", Year = "FY 2023", Quarter = "Q2" });
            defaultData.Add(new DefaultData { Sold = 40, Amount = 59965, Country = "United Kingdom", Products = "Road Bikes", Year = "FY 2023", Quarter = "Q3" });
            defaultData.Add(new DefaultData { Sold = 68, Amount = 101937, Country = "United States", Products = "Road Bikes", Year = "FY 2023", Quarter = "Q3" });
            defaultData.Add(new DefaultData { Sold = 11, Amount = 16494, Country = "United Kingdom", Products = "Road Bikes", Year = "FY 2023", Quarter = "Q4" });
            defaultData.Add(new DefaultData { Sold = 27, Amount = 40478, Country = "United States", Products = "Road Bikes", Year = "FY 2023", Quarter = "Q4" });
            defaultData.Add(new DefaultData { Sold = 45, Amount = 67460, Country = "United Kingdom", Products = "Road Bikes", Year = "FY 2024", Quarter = "Q1" });
            defaultData.Add(new DefaultData { Sold = 100, Amount = 149905, Country = "United States", Products = "Road Bikes", Year = "FY 2024", Quarter = "Q1" });
            defaultData.Add(new DefaultData { Sold = 70, Amount = 104935, Country = "United Kingdom", Products = "Road Bikes", Year = "FY 2024", Quarter = "Q2" });
            defaultData.Add(new DefaultData { Sold = 83, Amount = 124422, Country = "United States", Products = "Road Bikes", Year = "FY 2024", Quarter = "Q2" });
            defaultData.Add(new DefaultData { Sold = 100, Amount = 149905, Country = "United Kingdom", Products = "Road Bikes", Year = "FY 2024", Quarter = "Q3" });
            defaultData.Add(new DefaultData { Sold = 18, Amount = 26987, Country = "United States", Products = "Road Bikes", Year = "FY 2024", Quarter = "Q3" });
            defaultData.Add(new DefaultData { Sold = 70, Amount = 104935, Country = "United Kingdom", Products = "Road Bikes", Year = "FY 2024", Quarter = "Q4" });
            defaultData.Add(new DefaultData { Sold = 81, Amount = 121424, Country = "United States", Products = "Road Bikes", Year = "FY 2024", Quarter = "Q4" });
            defaultData.Add(new DefaultData { Sold = 20, Amount = 29985, Country = "United Kingdom", Products = "Road Bikes", Year = "FY 2025", Quarter = "Q1" });
            defaultData.Add(new DefaultData { Sold = 99, Amount = 148406, Country = "United States", Products = "Road Bikes", Year = "FY 2025", Quarter = "Q1" });
            defaultData.Add(new DefaultData { Sold = 43, Amount = 73272, Country = "United States", Products = "Mountain Bikes", Year = "FY 2022", Quarter = "Q1" });
            defaultData.Add(new DefaultData { Sold = 43, Amount = 73272, Country = "United States", Products = "Mountain Bikes", Year = "FY 2022", Quarter = "Q2" });
            defaultData.Add(new DefaultData { Sold = 52, Amount = 88608, Country = "United States", Products = "Mountain Bikes", Year = "FY 2022", Quarter = "Q3" });
            defaultData.Add(new DefaultData { Sold = 91, Amount = 155064, Country = "United States", Products = "Mountain Bikes", Year = "FY 2022", Quarter = "Q4" });
            defaultData.Add(new DefaultData { Sold = 37, Amount = 63048, Country = "United States", Products = "Mountain Bikes", Year = "FY 2023", Quarter = "Q1" });
            defaultData.Add(new DefaultData { Sold = 41, Amount = 69864, Country = "United States", Products = "Mountain Bikes", Year = "FY 2023", Quarter = "Q2" });
            defaultData.Add(new DefaultData { Sold = 49, Amount = 83496, Country = "United States", Products = "Mountain Bikes", Year = "FY 2023", Quarter = "Q3" });
            defaultData.Add(new DefaultData { Sold = 23, Amount = 39192, Country = "United States", Products = "Mountain Bikes", Year = "FY 2023", Quarter = "Q4" });
            defaultData.Add(new DefaultData { Sold = 67, Amount = 114168, Country = "United States", Products = "Mountain Bikes", Year = "FY 2024", Quarter = "Q1" });
            defaultData.Add(new DefaultData { Sold = 85, Amount = 144840, Country = "United States", Products = "Mountain Bikes", Year = "FY 2024", Quarter = "Q2" });
            defaultData.Add(new DefaultData { Sold = 25, Amount = 42600, Country = "United States", Products = "Mountain Bikes", Year = "FY 2024", Quarter = "Q3" });
            defaultData.Add(new DefaultData { Sold = 28, Amount = 47712, Country = "United States", Products = "Mountain Bikes", Year = "FY 2024", Quarter = "Q4" });
            defaultData.Add(new DefaultData { Sold = 53, Amount = 90312, Country = "United States", Products = "Mountain Bikes", Year = "FY 2025", Quarter = "Q1" });
            defaultData.Add(new DefaultData { Sold = 82, Amount = 130831, Country = "United Kingdom", Products = "Touring Bikes", Year = "FY 2022", Quarter = "Q1" });
            defaultData.Add(new DefaultData { Sold = 41, Amount = 65415.5, Country = "United States", Products = "Touring Bikes", Year = "FY 2022", Quarter = "Q1" });
            defaultData.Add(new DefaultData { Sold = 60, Amount = 95730, Country = "United Kingdom", Products = "Touring Bikes", Year = "FY 2022", Quarter = "Q2" });
            defaultData.Add(new DefaultData { Sold = 71, Amount = 113280.5, Country = "United States", Products = "Touring Bikes", Year = "FY 2022", Quarter = "Q2" });
            defaultData.Add(new DefaultData { Sold = 45, Amount = 71797.5, Country = "United Kingdom", Products = "Touring Bikes", Year = "FY 2022", Quarter = "Q3" });
            defaultData.Add(new DefaultData { Sold = 21, Amount = 33505.5, Country = "United States", Products = "Touring Bikes", Year = "FY 2022", Quarter = "Q3" });
            defaultData.Add(new DefaultData { Sold = 94, Amount = 149977, Country = "United Kingdom", Products = "Touring Bikes", Year = "FY 2022", Quarter = "Q4" });
            defaultData.Add(new DefaultData { Sold = 34, Amount = 54247, Country = "United States", Products = "Touring Bikes", Year = "FY 2022", Quarter = "Q4" });
            defaultData.Add(new DefaultData { Sold = 14, Amount = 22337, Country = "United Kingdom", Products = "Touring Bikes", Year = "FY 2023", Quarter = "Q1" });
            defaultData.Add(new DefaultData { Sold = 76, Amount = 121258, Country = "United States", Products = "Touring Bikes", Year = "FY 2023", Quarter = "Q1" });
            defaultData.Add(new DefaultData { Sold = 50, Amount = 79775, Country = "United Kingdom", Products = "Touring Bikes", Year = "FY 2023", Quarter = "Q2" });
            defaultData.Add(new DefaultData { Sold = 75, Amount = 119662.5, Country = "United States", Products = "Touring Bikes", Year = "FY 2023", Quarter = "Q2" });
            defaultData.Add(new DefaultData { Sold = 49, Amount = 78179.5, Country = "United Kingdom", Products = "Touring Bikes", Year = "FY 2023", Quarter = "Q3" });
            defaultData.Add(new DefaultData { Sold = 40, Amount = 63820, Country = "United States", Products = "Touring Bikes", Year = "FY 2023", Quarter = "Q3" });
            defaultData.Add(new DefaultData { Sold = 94, Amount = 149977, Country = "United Kingdom", Products = "Touring Bikes", Year = "FY 2023", Quarter = "Q4" });
            defaultData.Add(new DefaultData { Sold = 17, Amount = 27123.5, Country = "United States", Products = "Touring Bikes", Year = "FY 2023", Quarter = "Q4" });
            defaultData.Add(new DefaultData { Sold = 45, Amount = 71797.5, Country = "United Kingdom", Products = "Touring Bikes", Year = "FY 2024", Quarter = "Q1" });
            defaultData.Add(new DefaultData { Sold = 56, Amount = 89348, Country = "United States", Products = "Touring Bikes", Year = "FY 2024", Quarter = "Q1" });
            defaultData.Add(new DefaultData { Sold = 75, Amount = 119662.5, Country = "United Kingdom", Products = "Touring Bikes", Year = "FY 2024", Quarter = "Q2" });
            defaultData.Add(new DefaultData { Sold = 11, Amount = 17550.5, Country = "United States", Products = "Touring Bikes", Year = "FY 2024", Quarter = "Q2" });
            defaultData.Add(new DefaultData { Sold = 54, Amount = 86157, Country = "United Kingdom", Products = "Touring Bikes", Year = "FY 2024", Quarter = "Q3" });
            defaultData.Add(new DefaultData { Sold = 14, Amount = 22337, Country = "United States", Products = "Touring Bikes", Year = "FY 2024", Quarter = "Q3" });
            defaultData.Add(new DefaultData { Sold = 11, Amount = 17550.5, Country = "United Kingdom", Products = "Touring Bikes", Year = "FY 2024", Quarter = "Q4" });
            defaultData.Add(new DefaultData { Sold = 76, Amount = 121258, Country = "United States", Products = "Touring Bikes", Year = "FY 2024", Quarter = "Q4" });
            defaultData.Add(new DefaultData { Sold = 45, Amount = 71797.5, Country = "United Kingdom", Products = "Touring Bikes", Year = "FY 2025", Quarter = "Q1" });
            defaultData.Add(new DefaultData { Sold = 80, Amount = 127640, Country = "United States", Products = "Touring Bikes", Year = "FY 2025", Quarter = "Q1" });
            return defaultData;
        }
    }
}
