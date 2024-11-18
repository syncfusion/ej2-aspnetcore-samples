#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Diagram;

public class ZoomingAndPanningModel : PageModel
{
    public List<ZoomingAndPanning> data { get; set; }
    public void OnGet()
        {
            data = new List<ZoomingAndPanning>();
            data.Add(new ZoomingAndPanning("parent", "Maria Anders", "Managing Director", "", "../images/Diagram/employees/image30.png"));
            data.Add(new ZoomingAndPanning("1", "Ana Trujillo", "Project Manager", "parent", "../images/Diagram/employees/image2.png"));
            data.Add(new ZoomingAndPanning("2", "Anto Moreno", "Project Lead", "1", "../images/Diagram/employees/image1.png"));
            data.Add(new ZoomingAndPanning("3", "Thomas Hardy", "Senior S/w Engg", "2", "../images/Diagram/employees/image3.png"));
            data.Add(new ZoomingAndPanning("4", "Christina kaff", "S/w Engg", "3", "../images/Diagram/employees/image4.png"));
            data.Add(new ZoomingAndPanning("5", "Hanna Moos", "Project Trainee", "4", "../images/Diagram/employees/image6.png"));
            data.Add(new ZoomingAndPanning("6", "Peter Citeaux", "S/w Engg", "5", "../images/Diagram/employees/image5.png"));
            data.Add(new ZoomingAndPanning("7", "Martín Kloss", "Project Trainee", "6", "../images/Diagram/employees/image18.png"));
            data.Add(new ZoomingAndPanning("8", "Elizabeth Mary", "Project Trainee", "6", "../images/Diagram/employees/image7.png"));
            data.Add(new ZoomingAndPanning("9", "Victoria Ash", "Senior S/w Engg", "5", "../images/Diagram/employees/image8.png"));
            data.Add(new ZoomingAndPanning("10", "Francisco Yang", "Senior S/w Engg", "3", "../images/Diagram/employees/image19.png"));
            data.Add(new ZoomingAndPanning("11", "Yang Wang", "Project Manager", "parent", "../images/Diagram/employees/image21.png"));
            data.Add(new ZoomingAndPanning("12", "Lino Rodri", "Project Manager", "11", "../images/Diagram/employees/image9.png"));
            data.Add(new ZoomingAndPanning("13", "Philip Cramer", "Senior S/w Engg", "24", "../images/Diagram/employees/image23.png"));
            data.Add(new ZoomingAndPanning("14", "Pedro Afonso", "Project Trainee", "15", "../images/Diagram/employees/image10.png"));
            data.Add(new ZoomingAndPanning("15", "Elizabeth Roel", "S/w Engg", "13", "../images/Diagram/employees/image11.png"));
            data.Add(new ZoomingAndPanning("16", "Janine Labrune", "Project Lead", "12", "../images/Diagram/employees/image12.png"));
            data.Add(new ZoomingAndPanning("17", "Ann Devon", "Project Manager", "25", "../images/Diagram/employees/image13.png"));
            data.Add(new ZoomingAndPanning("18", "Roland Mendel", "Project Lead", "17", "../images/Diagram/employees/image24.png"));
            data.Add(new ZoomingAndPanning("19", "Aria Cruz", "Senior S/w Engg", "18", "../images/Diagram/employees/image14.png"));
            data.Add(new ZoomingAndPanning("20", "Martine Rancé", "S/w Engg", "18", "../images/Diagram/employees/image26.png"));
            data.Add(new ZoomingAndPanning("21", "Maria Larsson", "Project Trainee", "19", "../images/Diagram/employees/image15.png"));
            data.Add(new ZoomingAndPanning("22", "Diego Roel", "Project Trainee", "21", "../images/Diagram/employees/image17.png"));
            data.Add(new ZoomingAndPanning("23", "Peter Franken", "Project Trainee", "21", "../images/Diagram/employees/image27.png"));
            data.Add(new ZoomingAndPanning("24", "Howard Snyder", "Project Lead", "16", "../images/Diagram/employees/image20.png"));
            data.Add(new ZoomingAndPanning("25", "Carine Schmitt", "Project Manager", "parent", "../images/Diagram/employees/image22.png"));
            data.Add(new ZoomingAndPanning("26", "Paolo Accorti", "Project Lead", "36", "../images/Diagram/employees/image28.png"));
            data.Add(new ZoomingAndPanning("27", "Eduardo Roel", "Senior S/w Engg", "26", "../images/Diagram/employees/image31.png"));
            data.Add(new ZoomingAndPanning("28", "José Pedro", "Senior S/w Engg", "27", "../images/Diagram/employees/image25.png"));
            data.Add(new ZoomingAndPanning("29", "André Fonseca", "Senior S/w Engg", "28", "../images/Diagram/employees/image32.png"));
            data.Add(new ZoomingAndPanning("30", "Howard Snyd", "S/w Engg", "29", "../images/Diagram/employees/image33.png"));
            data.Add(new ZoomingAndPanning("31", "Manu Pereira", "Project Trainee", "29", "../images/Diagram/employees/image34.png"));
            data.Add(new ZoomingAndPanning("32", "Mario Pontes", "S/w Engg", "29", "../images/Diagram/employees/image29.png"));
            data.Add(new ZoomingAndPanning("33", "Carlos Schmitt", "Project Trainee", "29", "../images/Diagram/employees/image30.png"));
            data.Add(new ZoomingAndPanning("34", "Yoshi Latimer", "Project Trainee", "29", "../images/Diagram/employees/image4.png"));
            data.Add(new ZoomingAndPanning("35", "Patricia Kenna", "Project Trainee", "29", "../images/Diagram/employees/image6.png"));
            data.Add(new ZoomingAndPanning("36", "Helen Bennett", "Project Lead", "25", "../images/Diagram/employees/image7.png"));
            data.Add(new ZoomingAndPanning("37", "Daniel Tonini", "Project Manager", "parent", "../images/Diagram/employees/image1.png"));
            data.Add(new ZoomingAndPanning("38", "Annette Roel", "Project Lead", "37", "../images/Diagram/employees/image2.png"));
            data.Add(new ZoomingAndPanning("39", "Yoshi Wilson", "Senior S/w Engg", "38", "../images/Diagram/employees/image8.png"));
            data.Add(new ZoomingAndPanning("40", "John Steel", "Project Lead", "38", "../images/Diagram/employees/image3.png"));
            data.Add(new ZoomingAndPanning("41", "Renate Jose", "Senior S/w Engg", "40", "../images/Diagram/employees/image9.png"));
            data.Add(new ZoomingAndPanning("42", "Jaime Yorres", "SR", "41", "../images/Diagram/employees/image10.png"));
            data.Add(new ZoomingAndPanning("43", "Carlos Nagy", "SR", "42", "../images/Diagram/employees/image5.png"));
            data.Add(new ZoomingAndPanning("44", "Felipe Kloss", "S/w Engg", "43", "../images/Diagram/employees/image16.png"));
            data.Add(new ZoomingAndPanning("45", "Fran Wilson", "SR", "43", "../images/Diagram/employees/image18.png"));
            data.Add(new ZoomingAndPanning("46", "John Rovelli", "S/w Engg", "43", "../images/Diagram/employees/image19.png"));
            data.Add(new ZoomingAndPanning("47", "Catherine Kaff", "SR", "43", "../images/Diagram/employees/image11.png"));
            data.Add(new ZoomingAndPanning("48", "Jean Fresnière", "Project Trainee", "43", "../images/Diagram/employees/image21.png"));
            data.Add(new ZoomingAndPanning("49", "Alex Feuer", "Project Trainee", "43", "../images/Diagram/employees/image23.png"));
            data.Add(new ZoomingAndPanning("50", "Simon Roel", "Project Trainee", "41", "../images/Diagram/employees/image24.png"));
            data.Add(new ZoomingAndPanning("51", "Yvonne Wong", "Project Trainee", "52", "../images/Diagram/employees/image12.png"));
            data.Add(new ZoomingAndPanning("52", "Rene Phillips", "S/w Engg", "39", "../images/Diagram/employees/image25.png"));
            data.Add(new ZoomingAndPanning("53", "Yoshi Kenna", "Project Trainee", "52", "../images/Diagram/employees/image14.png"));
            data.Add(new ZoomingAndPanning("54", "Helen Marie", "Project Trainee", "52", "../images/Diagram/employees/image15.png"));
            data.Add(new ZoomingAndPanning("55", "Joseph Kaff", "Project Trainee", "52", "../images/Diagram/employees/image26.png"));
            data.Add(new ZoomingAndPanning("56", "Georg Pipps", "Senior S/w Engg", "57", "../images/Diagram/employees/image27.png"));
            data.Add(new ZoomingAndPanning("57", "Nardo Batista", "Project Lead", "12", "../images/Diagram/employees/image17.png"));
            data.Add(new ZoomingAndPanning("58", "Lúcia Carvalho", "Senior S/w Engg", "57", "../images/Diagram/employees/image20.png"));
            data.Add(new ZoomingAndPanning("59", "Horst Kloss", "Project Trainee", "57", "../images/Diagram/employees/image28.png"));
            data.Add(new ZoomingAndPanning("60", "Sergio roel", "CSR", "57", "../images/Diagram/employees/image22.png"));
            data.Add(new ZoomingAndPanning("61", "Paula Wilson", "CSR", "57", "../images/Diagram/employees/image31.png"));
            data.Add(new ZoomingAndPanning("62", "Mauri Moroni", "Senior S/w Engg", "57", "../images/Diagram/employees/image25.png"));
            data.Add(new ZoomingAndPanning("63", "Janete Limeira", "Project Trainee", "57", "../images/Diagram/employees/image29.png"));
            data.Add(new ZoomingAndPanning("64", "Michael Holz", "S/w Engg", "57", "../images/Diagram/employees/image32.png"));
            data.Add(new ZoomingAndPanning("65", "Alej Camino", "Project Manager", "parent", "../images/Diagram/employees/image33.png"));
            data.Add(new ZoomingAndPanning("66", "Jonas Bergsen", "Project Lead", "65", "../images/Diagram/employees/image34.png"));
            data.Add(new ZoomingAndPanning("67", "Jose Pavarotti", "Project Trainee", "68", "../images/Diagram/employees/image30.png"));
            data.Add(new ZoomingAndPanning("68", "Miguel Angel", "Senior S/w Engg", "66", "../images/Diagram/employees/image4.png"));
            data.Add(new ZoomingAndPanning("69", "Jytte Petersen", "Senior S/w Engg", "68", "../images/Diagram/employees/image1.png"));
            data.Add(new ZoomingAndPanning("70", "Kloss Perrier", "Project Lead", "72", "../images/Diagram/employees/image2.png"));
            data.Add(new ZoomingAndPanning("71", "Art Nancy", "Senior S/w Engg", "27", "../images/Diagram/employees/image6.png"));
            data.Add(new ZoomingAndPanning("72", "Pascal Cartrain", "Project Lead", "65", "../images/Diagram/employees/image3.png"));
            data.Add(new ZoomingAndPanning("73", "Liz Nixon", "Senior S/w Engg", "68", "../images/Diagram/employees/image7.png"));
            data.Add(new ZoomingAndPanning("74", "Liu Wong", "Project Manager", "parent", "../images/Diagram/employees/image8.png"));
            data.Add(new ZoomingAndPanning("75", "Karin Josephs", "Project Lead", "74", "../images/Diagram/employees/image9.png"));
            data.Add(new ZoomingAndPanning("76", "Ruby Anabela", "Senior S/w Engg", "75", "../images/Diagram/employees/image10.png"));
            data.Add(new ZoomingAndPanning("77", "Helvetis Nagy", "Project Trainee", "82", "../images/Diagram/employees/image11.png"));
            data.Add(new ZoomingAndPanning("78", "Palle Ibsen", "Senior S/w Engg", "76", "../images/Diagram/employees/image5.png"));
            data.Add(new ZoomingAndPanning("79", "Mary Saveley", "SR", "82", "../images/Diagram/employees/image12.png"));
            data.Add(new ZoomingAndPanning("80", "Paul Henriot", "SR", "79", "../images/Diagram/employees/image16.png"));
            data.Add(new ZoomingAndPanning("81", "Rita Müller", "SR", "79", "../images/Diagram/employees/image13.png"));
            data.Add(new ZoomingAndPanning("82", "Pirkko King", "Senior S/w Engg", "78", "../images/Diagram/employees/image18.png"));
            data.Add(new ZoomingAndPanning("83", "Paula Parente", "Senior S/w Engg", "75", "../images/Diagram/employees/image19.png"));
            data.Add(new ZoomingAndPanning("84", "Karl Jablonski", "S/w Engg", "83", "../images/Diagram/employees/image14.png"));
            data.Add(new ZoomingAndPanning("34", "Matti Kenna", "Project Trainee", "84", "../images/Diagram/employees/image15.png"));
            data.Add(new ZoomingAndPanning("35", "Zbyszek Yang", "Project Trainee", "84", "../images/Diagram/employees/image21.png"));
            data.Add(new ZoomingAndPanning("85", "Nancy", "Project Lead", "74", "../images/Diagram/employees/image17.png"));
            data.Add(new ZoomingAndPanning("86", "Robert King", "Senior S/w Engg", "85", "../images/Diagram/employees/image23.png"));
            data.Add(new ZoomingAndPanning("87", "Laura Callahan", "CSR", "88", "../images/Diagram/employees/image20.png"));
            data.Add(new ZoomingAndPanning("88", "Anne", "CSR", "86", "../images/Diagram/employees/image24.png"));
            data.Add(new ZoomingAndPanning("89", "Georg Pipps", "Senior S/w Engg", "parent", "../images/Diagram/employees/image26.png"));
            data.Add(new ZoomingAndPanning("90", "Rene Phillips", "Project Trainee", "89", "../images/Diagram/employees/image22.png"));
            data.Add(new ZoomingAndPanning("91", "Lúcia Carvalho", "Project Trainee", "89", "../images/Diagram/employees/image25.png"));
            data.Add(new ZoomingAndPanning("92", "Horst Kloss", "Project Trainee", "89", "../images/Diagram/employees/image29.png"));
            data.Add(new ZoomingAndPanning("93", "Simon Roel", "Project Lead", "98", "../images/Diagram/employees/image28.png"));
            
        }
}
public class ZoomingAndPanning
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Designation { get; set; }
    public string ReportingPerson { get; set; }
    public string Image { get; set; }

    public ZoomingAndPanning(string id, string name, string designation, string reportingperson, string image)
    {
        this.Id = id;
        this.Name = name;
        this.Designation = designation;
        this.ReportingPerson = reportingperson;
        this.Image = image;
    }
}