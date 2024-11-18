#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Diagram;

public class RadialTreeModel : PageModel
{
    public List<RadialTreeDetails> Nodes { get; set; }
    public void OnGet()
    {
        Nodes = RadialTreeDetails.GetAllRecords();
    }
}
 public class RadialTreeDetails
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string ReportingPerson { get; set; }

        public RadialTreeDetails(string id, string name, string designation, string reportingPerson)
        {
            this.Id = id;
            this.Name = name;
            this.Designation = designation;
            this.ReportingPerson = reportingPerson;
        }

        public static List<RadialTreeDetails> GetAllRecords()
        {
            List<RadialTreeDetails> radialTreeDetails = new List<RadialTreeDetails>();
            radialTreeDetails.Add(new RadialTreeDetails("parent", "Maria Anders", "Managing Director", ""));
            radialTreeDetails.Add(new RadialTreeDetails("1", "Ana Trujillo", "Project Manager", "parent"));
            radialTreeDetails.Add(new RadialTreeDetails("2", "Lino Rodri", "Project Manager", "parent"));
            radialTreeDetails.Add(new RadialTreeDetails("3", "Philip Cramer", "Project Manager", "parent"));
            radialTreeDetails.Add(new RadialTreeDetails("4", "Pedro Afonso", "Project Manager", "parent"));
            radialTreeDetails.Add(new RadialTreeDetails("5", "Anto Moreno", "Project Lead", "1"));
            radialTreeDetails.Add(new RadialTreeDetails("6", "Elizabeth Roel", "Project Lead", "1"));
            radialTreeDetails.Add(new RadialTreeDetails("7", "Aria Cruz", "Project Lead", "1"));
            radialTreeDetails.Add(new RadialTreeDetails("8", "Eduardo Roel", "Project Lead", "1"));
            radialTreeDetails.Add(new RadialTreeDetails("9", "Howard Snyd", "Project Lead", "2"));
            radialTreeDetails.Add(new RadialTreeDetails("10", "Daniel Tonini", "Project Lead", "2"));
            radialTreeDetails.Add(new RadialTreeDetails("11", "Nardo Batista", "Project Lead", "89"));
            radialTreeDetails.Add(new RadialTreeDetails("12", "Michael Holz", "Project Lead", "89"));
            radialTreeDetails.Add(new RadialTreeDetails("13", "Kloss Perrier", "Project Lead", "90"));
            radialTreeDetails.Add(new RadialTreeDetails("14", "Liz Nixon", "Project Lead", "3"));
            radialTreeDetails.Add(new RadialTreeDetails("15", "Paul Henriot", "Project Lead", "3"));
            radialTreeDetails.Add(new RadialTreeDetails("16", "Paula Parente", "Project Lead", "90"));
            radialTreeDetails.Add(new RadialTreeDetails("17", "Matti Kenna", "Project Lead", "4"));
            radialTreeDetails.Add(new RadialTreeDetails("18", "Laura Callahan", "Project Lead", "4"));
            radialTreeDetails.Add(new RadialTreeDetails("19", "Simon Roel", "#Project Lead", "4"));

            radialTreeDetails.Add(new RadialTreeDetails("20", "Thomas Hardy", "Senior S/w Engg", "12"));
            radialTreeDetails.Add(new RadialTreeDetails("21", "Martín Kloss", "Senior S/w Engg", "5"));
            radialTreeDetails.Add(new RadialTreeDetails("23", "Diego Roel", "Senior S/w Engg", "7"));
            radialTreeDetails.Add(new RadialTreeDetails("24", "José Pedro", "Senior S/w Engg", "8"));
            radialTreeDetails.Add(new RadialTreeDetails("25", "Manu Pereira", "Senior S/w Engg", "8"));
            radialTreeDetails.Add(new RadialTreeDetails("26", "Annette Roel", "Senior S/w Engg", "25"));
            radialTreeDetails.Add(new RadialTreeDetails("27", "Catherine Kaff", "Senior S/w Engg", "8"));
            radialTreeDetails.Add(new RadialTreeDetails("28", "Lúcia Carvalho", "Senior S/w Engg", "12"));
            radialTreeDetails.Add(new RadialTreeDetails("29", "Alej Camino", "Senior S/w Engg", "13"));
            radialTreeDetails.Add(new RadialTreeDetails("30", "Liu Wong", "Senior S/w Engg", "14"));
            radialTreeDetails.Add(new RadialTreeDetails("31", "Karin Josephs", "Senior S/w Engg", "14"));
            radialTreeDetails.Add(new RadialTreeDetails("33", "Pirkko King", "Senior S/w Engg", "17"));
            radialTreeDetails.Add(new RadialTreeDetails("34", "Karl Jablonski", "Senior S/w Engg", "18"));
            radialTreeDetails.Add(new RadialTreeDetails("35", "Zbyszek Yang", "Senior S/w Engg", "19"));
            radialTreeDetails.Add(new RadialTreeDetails("36", "Nancy", "Senior S/w Engg", "5"));
            radialTreeDetails.Add(new RadialTreeDetails("37", "Anne", "Senior S/w Engg", "6"));

            radialTreeDetails.Add(new RadialTreeDetails("38", "Isabel Castro", "Senior S/w Engg", "7"));
            radialTreeDetails.Add(new RadialTreeDetails("39", "Nardo Batista", "Senior S/w Engg", "9"));
            radialTreeDetails.Add(new RadialTreeDetails("40", "Rene Phillips", "Senior S/w Engg", "16"));
            radialTreeDetails.Add(new RadialTreeDetails("41", "Rita Pfalzheim", "Senior S/w Engg", "9"));
            radialTreeDetails.Add(new RadialTreeDetails("42", "Janete Limeira", "Senior S/w Engg", "11"));

            radialTreeDetails.Add(new RadialTreeDetails("43", "Christina kaff", "S/w Engg", "20"));
            radialTreeDetails.Add(new RadialTreeDetails("44", "Peter Franken", "S/w Engg", "21"));
            radialTreeDetails.Add(new RadialTreeDetails("45", "Carlos Schmitt", "S/w Engg", "23"));
            radialTreeDetails.Add(new RadialTreeDetails("46", "Yoshi Wilson", "S/w Engg", "23"));
            radialTreeDetails.Add(new RadialTreeDetails("47", "Jean Fresnière", "S/w Engg", "24"));
            radialTreeDetails.Add(new RadialTreeDetails("48", "Simon Roel", "S/w Engg", "25"));
            radialTreeDetails.Add(new RadialTreeDetails("52", "Palle Ibsen", "S/w Engg", "29"));
            radialTreeDetails.Add(new RadialTreeDetails("53", "Lúcia Carvalho", "S/w Engg", "30"));


            radialTreeDetails.Add(new RadialTreeDetails("54", "Hanna Moos", "Project Trainee", "30"));
            radialTreeDetails.Add(new RadialTreeDetails("55", "Peter Citeaux", "Project Trainee", "33"));
            radialTreeDetails.Add(new RadialTreeDetails("56", "Elizabeth Mary", "Project Trainee", "33"));
            radialTreeDetails.Add(new RadialTreeDetails("57", "Victoria Ash", "Project Trainee", "34"));
            radialTreeDetails.Add(new RadialTreeDetails("58", "Janine Labrune", "Project Trainee", "35"));
            radialTreeDetails.Add(new RadialTreeDetails("60", "Carine Schmitt", "Project Trainee", "11"));
            radialTreeDetails.Add(new RadialTreeDetails("61", "Paolo Accorti", "Project Trainee", "38"));
            radialTreeDetails.Add(new RadialTreeDetails("62", "André Fonseca", "Project Trainee", "41"));
            radialTreeDetails.Add(new RadialTreeDetails("63", "Mario Pontes", "Project Trainee", "6"));
            radialTreeDetails.Add(new RadialTreeDetails("64", "John Steel", "Project Trainee", "7"));
            radialTreeDetails.Add(new RadialTreeDetails("65", "Renate Jose", "Project Trainee", "42"));
            radialTreeDetails.Add(new RadialTreeDetails("66", "Jaime Yorres", "Project Trainee", "20"));
            radialTreeDetails.Add(new RadialTreeDetails("67", "Alex Feuer", "Project Trainee", "21"));
            radialTreeDetails.Add(new RadialTreeDetails("70", "Helen Marie", "Project Trainee", "24"));
            radialTreeDetails.Add(new RadialTreeDetails("73", "Sergio roel", "Project Trainee", "37"));
            radialTreeDetails.Add(new RadialTreeDetails("75", "Janete Limeira", "Project Trainee", "29"));
            radialTreeDetails.Add(new RadialTreeDetails("76", "Jonas Bergsen", "Project Trainee", "18"));
            radialTreeDetails.Add(new RadialTreeDetails("77", "Miguel Angel", "Project Trainee", "18"));
            radialTreeDetails.Add(new RadialTreeDetails("80", "Helvetis Nagy", "Project Trainee", "34"));
            radialTreeDetails.Add(new RadialTreeDetails("81", "Rita Müller", "Project Trainee", "35"));
            radialTreeDetails.Add(new RadialTreeDetails("82", "Georg Pipps", "Project Trainee", "36"));
            radialTreeDetails.Add(new RadialTreeDetails("83", "Horst Kloss", "Project Trainee", "37"));
            radialTreeDetails.Add(new RadialTreeDetails("84", "Paula Wilson", "Project Trainee", "38"));
            radialTreeDetails.Add(new RadialTreeDetails("85", "Jose Michael", "Project Trainee", "37"));
            radialTreeDetails.Add(new RadialTreeDetails("86", "Mauri Moroni", "Project Trainee", "40"));
            radialTreeDetails.Add(new RadialTreeDetails("87", "Michael Holz", "Project Trainee", "41"));
            radialTreeDetails.Add(new RadialTreeDetails("88", "Alej Camino", "Project Trainee", "42"));

            radialTreeDetails.Add(new RadialTreeDetails("89", "Jytte Petersen", "Project Manager", "parent"));
            radialTreeDetails.Add(new RadialTreeDetails("90", "Mary Saveley", "Project Manager", "parent"));
            radialTreeDetails.Add(new RadialTreeDetails("91", "Robert King", "Project Manager", "parent"));

            radialTreeDetails.Add(new RadialTreeDetails("95", "Roland Mendel", "CSR", "19"));
            radialTreeDetails.Add(new RadialTreeDetails("98", "Helen Bennett", "SR", "42"));
            radialTreeDetails.Add(new RadialTreeDetails("99", "Carlos Nagy", "SR", "42"));
            radialTreeDetails.Add(new RadialTreeDetails("100", "Felipe Kloss", "SR", "77"));




            return radialTreeDetails;
        }
    }