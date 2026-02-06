#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.EJ2.Diagrams;

namespace EJ2CoreSampleBrowser.Pages.Diagram;

public class VirtualizationModel : PageModel
{
    public List<VirtualizationDetails> Data { get; set; }
    public DiagramMargin marginValue { get; set; }
    public void OnGet()
    {
        Data = VirtualizationDetails.GetAllRecords();
        marginValue = new DiagramMargin() { Left = 10, Top = 50 };
    }
}
public class VirtualizationDetails
    {
        public string Id { get; set; }
        public string ParentId { get; set; }


        public VirtualizationDetails(string Id, string ParentId)
        {
            this.Id = Id;
            this.ParentId = ParentId;
        }
        public static List<VirtualizationDetails> GetAllRecords()
        {
            List<VirtualizationDetails> data = new List<VirtualizationDetails>();

            int i = 0;
            string name;
            string parentName;
            string[] virtualData = VirtualizationData.GetNames();
            data.Add(new VirtualizationDetails (virtualData[0], "" ));
            i++;
            parentName = virtualData[0];
            for (var j = 1; j < 100; j++)
            {
                name = virtualData[i];
                data.Add(new VirtualizationDetails(name, parentName));
                i++;
                for (var k = 0; k < 2; k++)
                {
                    data.Add(new VirtualizationDetails(virtualData[i], name));
                    i++;
                }
            }
            return data;
        }
    }
    // custom code start
    public class VirtualizationData
    {
        public static string[] GetNames()
        {
            string[] strArray = { "Isiahi Witcomb","Viola Yorkston","Revkah Ebbett","Jakob Pywell","Hank Fice","Tally Bloxsum","Yardley Beasley","Helaina Ludovico","Leroi Tinn","Flory Cordaroy","Vanya Shorland","Micheal Ronnay","Donetta Doore","Alphard Casazza","Chucho Odcroft","Meridith Kalf","Elizabeth Birrane","Cathrin Gerardet","Mimi Molyneaux","Diego Eborn","Shea Mynett","Pincus Glanfield","Kurtis Crawley","Hermina Giovannacci","Alberta Olpin","Derron Wolpert","Zorine Coatts","Gilli McCanny","Keely Braunds","Sula Hartfleet","Sam Bolderoe","Celle Blei","Bertine Bridgwater",
"Garfield Hickford","Dom Halle","Fidole Willetts","Izaak Densell","Angelica Ricciardello","Bax Roskam","Gilbertine Peddowe","Dagny Chaundy","Donelle Huxton","Edithe Statefield","Harlene Gravener","Davidde Acton","Jakob Pearsey","Gratia Badham","Bili Puffett","Amelita Chastand","Miner Melding","Tades Stagg","Niels Devas","Cairistiona Mulcock","Kayle Withey","Ashil Caldero","Leesa Okill","Lorant Avrahamof","Staci MacKessock","Darline Goodoune","Theadora Gaitley","Pepe Redhole","Katya Jenckes","Toby Whapham","Cherin Tilly","Merrel Attlee","Hallsy Skalls","Felecia Blythe","Maxy Mirfield",
"Zebedee Atrill","Mead Monkleigh","Tracy McAuslene","Emyle Olenikov","Sharlene Dell Casa","Jens Rathke","Oliy Riddlesden","Taddeusz Palethorpe","Kermit Emblow","Tammara Naptin","Neall Borghese","Dar Topley","Alex Doodson","Lilith Nowakowska","Dean Adao","Sigfrid O'Corr","Kerry Dinneen","Micky Dane","Christie Kelso","Ceil Tomik","Urbanus Froude","Blaire Adshede","Bobbye Forri","Kory Seedull","Esdras Sarsons","Garret Wozencraft","Lorita Tomasi","Hobey Duckerin","Rolph Chalcot","Emera Phythien","Madeline Reisen","Harald Waterhowse","Kirbee Piwall","Tish Roston","Trenna Spofforth","Basia Crispe",
"Brandie Thurlbourne","Antoine Chang","Orson Stannus","Benson Perrelle","Nannette Ebbetts","Loreen Petley","Sianna McPharlain","Kaylil Gossan","Kendra Godthaab","Keeley Weerdenburg","Gearard Boulsher","Johnna McDonagh","Dolorita Tugwell","Billy Semmence","Joyann Swatton","Zacharie Mesnard","Terri-jo Cranny","Alaine Lewington","Loralyn Dick","Morton Penella","Yurik Friel","Claudian Rentalll","Maribel Hubery","Enrika Connolly","Marina Garmons","Ariel Ege","Denni Georghiou","Humphrey Grinham","Stanley Kolodziej","Malva Aylett","Mair Wolfinger","Tim Kelberer","Fayette Brocket","Neill Cottrill",
"Louella Tordoff","Sib Winnister","Patrick Megarry","Shelley Rangle","Andonis Napier","Georgia Tatum","Arlena Lebourn","Gannon Pickworth","Kayle Usherwood","Alaine Lenoir","Bambi Tresler","Austina Braddick","Hester Torrent","Dedie Hobson","Linn Caulier","Dulci Enrico","Jeni Rogge","Hyacinthie Caplis","Marielle Limbourne","Kaia Gamil","Lindon Ganforth","Cyndia Possek","Melisande Maxweell","Cornela Dacks","Chick Heale","Worden Vick","Craggy Nower","Minni Gammel","Hanni Danneil","Agathe Earengey","Roddie Samper","Geneva Parratt","Tandie Weatherup","Emmi Reany","Allissa Kleinplac","Kelsey Vaggs",
"Chad Knobell","Sibelle Wooller","Chic Sirrell","Griswold Kayes","Shirlee Stackbridge","Ashley Ugo","Henriette Lampens","Zaneta Roussell","Celestia Newvell","Morgana Jervoise","Rhodie Pylkynyton","Fonzie Swiers","Bethanne Sainz","Althea Divill","Lucie Syalvester","Gigi Ciani","Joellen Falconbridge","Hollis Vassall","Lindon Glassborow","Lynde Vivers","Gar Scrigmour","Fredek Sporton","Ardath Schottli","Sol Dwane","Gardner Lownsbrough","Lynna Gorstidge","Antonina Berston","Binny Kingsnode","Janeta Noar","Adorne Emett","Jephthah Montfort","Francisco Patillo","Elle Heyball","Gypsy Picott","Karissa Lownie",
"Nonie Conry","Aurlie Cordrey","Pru Di Maria","Carling Houldin","Leland Hickin","Ediva Wingfield","Stefano Westcot","Marie-jeanne Davidsson","Liv Davydzenko","Bartlett Hartzenberg","Ashia Diplock","Merilee Clapham","Dugald Baszkiewicz","Xerxes Cutford","Marshall Braunton","Sheilah Vannikov","Grazia Tuiller","Tadeo Stonehewer","Tori Hurdman","Susann Schutte","Brendis Aitken","Malvin Stockford","Callie Poulter","Percival Cornillot","Lezlie Rowley","Lilli Rouchy","Rinaldo Goodredge","Pat Gillio","Raynell Rouge","Adelheid Heatley","Kirstin Ayshford","Lotta Gosland","Hope Watchorn","Lissa Corr","Yehudit Grzelewski",
"Consalve Goburn","Rolland Brewett","Marcelia Musselwhite","Jaquenetta Gillian","Millie Torri","Collie Whetland","Neil Toppin","Brier McKimmey","Rogers Rannigan","Krista Coldrick","Kathe Turnpenny","Shayne Mapstone","Candida Janicki","Patty Klausen","Tuck Brantzen","Kiah Ilieve","Ronni Gibke","Brok Mansford","Kinny Crasford","Adora Martijn","Tamiko Pavier","Billi Mahon","Arlen Smythe","Arvin Lorkins","Fanechka Ruston","Thelma Halms","Bjorn Koopman","Luella Kleiner","Ester Vedishchev","Daveta Chasney","Elsworth Hobell","Brice Moxsom","Jeannie Danelutti","Akim Kohneke","Sanson Cirlos","Court Egger","Evvy Goodfield",
"Abey Lamport","Melina Lardeur","Flynn Marchant","Karola Vedenyapin","Demetre Masic","Liane Collimore","Vanda Navarre","Alys Ollivier","Dannye Kilday","Bettine Handforth","Shell Lesurf","Raquela Pargetter","Angeline Childers","Allyn Powell","Caz Hyslop","Jesselyn Andriveaux","Ruggiero Isley","Faustine Trillow","Cecil Dudney","Consolata Taggart"};

            return strArray;
        }
    }
    // custom code end