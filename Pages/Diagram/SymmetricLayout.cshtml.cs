#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Diagram;

public class SymmetricLayoutModel : PageModel
{
    public List<SymmetricalDetails> Nodes { get; set; }
    public void OnGet()
    {
        Nodes = SymmetricalDetails.GetAllRecords();

    }
}
public class SymmetricalDetails
    {
        public string Id { get; set; }
        public string Source { get; set; }
        public string Type { get; set; }
        public string ReportingPerson { get; set; }

        public SymmetricalDetails(string id, string source, string type)
        {
            this.Id = id;
            this.Source = source;
            this.Type = type;
        }

        public static List<SymmetricalDetails> GetAllRecords()
        {
            List<SymmetricalDetails> symmetricalDetails = new List<SymmetricalDetails>();

            symmetricalDetails.Add(new SymmetricalDetails("parent", "", "Server"));
            symmetricalDetails.Add(new SymmetricalDetails("1", "parent", "Server"));
            symmetricalDetails.Add(new SymmetricalDetails("2", "parent", "Server"));
            symmetricalDetails.Add(new SymmetricalDetails("3", "parent", "Server"));
            symmetricalDetails.Add(new SymmetricalDetails("4", "parent", "Server"));

            symmetricalDetails.Add(new SymmetricalDetails("5", "1", "Hub"));
            symmetricalDetails.Add(new SymmetricalDetails("6", "1", "Hub"));
            symmetricalDetails.Add(new SymmetricalDetails("7", "1", "Hub"));
            symmetricalDetails.Add(new SymmetricalDetails("8", "1", "Hub"));
            symmetricalDetails.Add(new SymmetricalDetails("9", "1", "Hub"));
            symmetricalDetails.Add(new SymmetricalDetails("10", "1", "Hub"));
            symmetricalDetails.Add(new SymmetricalDetails("11", "1", "Hub"));
            symmetricalDetails.Add(new SymmetricalDetails("12", "1", "Hub"));
            symmetricalDetails.Add(new SymmetricalDetails("13", "1", "Hub"));

            symmetricalDetails.Add(new SymmetricalDetails("14", "2", "Hub"));
            symmetricalDetails.Add(new SymmetricalDetails("15", "2", "Hub"));
            symmetricalDetails.Add(new SymmetricalDetails("16", "2", "Hub"));
            symmetricalDetails.Add(new SymmetricalDetails("18", "2", "Hub"));
            symmetricalDetails.Add(new SymmetricalDetails("19", "2", "Hub"));
            symmetricalDetails.Add(new SymmetricalDetails("20", "2", "Hub"));
            symmetricalDetails.Add(new SymmetricalDetails("21", "2", "Hub"));
            symmetricalDetails.Add(new SymmetricalDetails("22", "2", "Hub"));
            symmetricalDetails.Add(new SymmetricalDetails("23", "2", "Hub"));

            symmetricalDetails.Add(new SymmetricalDetails("24", "3", "Hub"));
            symmetricalDetails.Add(new SymmetricalDetails("25", "3", "Hub"));
            symmetricalDetails.Add(new SymmetricalDetails("26", "3", "Hub"));
            symmetricalDetails.Add(new SymmetricalDetails("27", "3", "Hub"));
            symmetricalDetails.Add(new SymmetricalDetails("28", "3", "Hub"));
            symmetricalDetails.Add(new SymmetricalDetails("29", "3", "Hub"));
            symmetricalDetails.Add(new SymmetricalDetails("30", "3", "Hub"));
            symmetricalDetails.Add(new SymmetricalDetails("31", "3", "Hub"));

            symmetricalDetails.Add(new SymmetricalDetails("32", "4", "Hub"));
            symmetricalDetails.Add(new SymmetricalDetails("33", "4", "Hub"));
            symmetricalDetails.Add(new SymmetricalDetails("34", "4", "Hub"));
            symmetricalDetails.Add(new SymmetricalDetails("35", "4", "Hub"));
            symmetricalDetails.Add(new SymmetricalDetails("36", "4", "Hub"));
            symmetricalDetails.Add(new SymmetricalDetails("37", "4", "Hub"));
            symmetricalDetails.Add(new SymmetricalDetails("38", "4", "Hub"));
            symmetricalDetails.Add(new SymmetricalDetails("39", "4", "Hub"));

            return symmetricalDetails;
        }
    }