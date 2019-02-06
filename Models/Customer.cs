using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EJ2CoreSampleBrowser.Models
{
    public class Customer
    {
        public  Customer(){}
        public Customer(string CustomerID, string ContactName, string CompanyName, string Adrress, string Country) {
            this.CustomerID = CustomerID;
            this.CompanyName = CompanyName;
            this.ContactName = ContactName;
            this.Address = Address;
            this.Country = Country;

        }
        public static List<Customer> GetAllRecords()
        {
            List<Customer> cust = new List<Customer>();           
            cust.Add(new Customer("ALFKI", "Maria ", "Alfreds Futterkiste", "Obere Str. 57", "Germany"));
            cust.Add(new Customer("ANATR", "Ana Trujillo", "Ana Trujillo Emparedados y helados", "Avda. de la Constitución 2222", "Mexico"));           
            cust.Add(new Customer("BLONP", "Frédérique Citeaux", "Blondesddsl père et fils", "24, place Kléber", "France"));
            cust.Add(new Customer("BOLID", "Martín Sommer", "Bólido Comidas preparadas", "C/ Araquil, 67", "Spain"));
            cust.Add(new Customer("ANTON", "Elizabeth Lincoln", "Bottom-Dollar Markets", "23 Tsawassen Blvd.", "Canada"));
            // cust.Add(new Customer("BONAP", "Laurence Lebihan", "Bon app", "12, rue des Bouchers", "France"));           
            // cust.Add(new Customer("BSBEV", "Victoria Ashworth", "B's Beverages", "Fauntleroy Circus", "UK"));
            // cust.Add(new Customer("CACTU", "Patricio Simpson", "Cactus Comidas para llevar", "Cerrito 333", "Argentina"));
            // cust.Add(new Customer("CENTC", "Francisco Chang", "Centro comercial Moctezuma", "Sierras de Granada 9993", "Mexico"));
            // cust.Add(new Customer("CHOPS", "Yang Wang", "Chop-suey Chinese", "Hauptstr. 29", "Switzerland"));
            // cust.Add(new Customer("COMMI", "Pedro Afonso", "Comércio Mineiro", "Av. dos Lusíadas, 23", "Brazil"));
            // cust.Add(new Customer("CONSH", "Elizabeth Brown", "Consolidated Holdings", "Berkeley Gardens 12  Brewery", "UK"));
            // cust.Add(new Customer("DRACD", "Sven Ottlieb", "Drachenblut Delikatessen", "Walserweg 21", "Germany"));
            // cust.Add(new Customer("DUMON", "Janine Labrune", "Du monde entier", "67, rue des Cinquante Otages", "France"));
            // cust.Add(new Customer("EASTC", "Ann Devon", "Eastern Connection", "35 King George", "UK"));
            // cust.Add(new Customer("ERNSH", "Roland Mendel", "Ernst Handel", "Kirchgasse 6", "Austria"));
            // cust.Add(new Customer("FAMIA", "Aria Cruz", "Familia Arquibaldo", "Rua Orós, 92", "Brazil"));
            // cust.Add(new Customer("FISSA", "Diego Roel", "FISSA Fabrica Inter. Salchichas S.A.", "C/ Moralzarzal, 86", "Spain"));
            // cust.Add(new Customer("FOLIG", "Martine Rancé", "Folies gourmandes", "184, chaussée de Tournai", "France"));
            // cust.Add(new Customer("FOLKO", "Maria Larsson", "Folk och fä HB", "Åkergatan 24", "Sweden"));
            // cust.Add(new Customer("FRANK", "Peter Franken", "Frankenversand", "Berliner Platz 43", "Germany"));
            // cust.Add(new Customer("FRANR", "Carine Schmitt", "France restauration", "54, rue Royale", "France"));
            // cust.Add(new Customer("FRANS", "Paolo Accorti", "Franchi S.p.A.", "Via Monte Bianco 34", "Italy"));
            // cust.Add(new Customer("FURIB", "Lino Rodriguez", "Furia Bacalhau e Frutos do Mar", "Jardim das rosas n. 32", "Portugal"));
            // cust.Add(new Customer("GALED", "Eduardo Saavedra", "Galería del gastrónomo", "Rambla de Cataluña, 23", "Spain"));
            // cust.Add(new Customer("GODOS", "José Pedro Freyre", "Godos Cocina Típica", "C/ Romero, 33", "Spain"));
            // cust.Add(new Customer("GOURL", "André Fonseca", "Gourmet Lanchonetes", "Av. Brasil, 442", "Brazil"));
            // cust.Add(new Customer("GREAL", "Howard Snyder", "Great Lakes Food Market", "2732 Baker Blvd.", "USA"));
            // cust.Add(new Customer("GROSR", "Manuel Pereira", "GROSELLA-Restaurante", "5ª Ave. Los Palos Grandes", "Venezuela"));
            // cust.Add(new Customer("HANAR", "Mario Pontes", "Hanari Carnes", "Rua do Paço, 67", "Brazil"));
            // cust.Add(new Customer("HILAA", "Carlos Hernández", "HILARION-Abastos", "Carrera 22 con Ave. Carlos Soublette #8-35", "Venezuela"));
            // cust.Add(new Customer("HUNGC", "Yoshi Latimer", "Hungry Coyote Import Store", "City Center Plaza 516 Main St.", "USA"));
            // cust.Add(new Customer("HUNGO", "Patricia McKenna", "Hungry Owl All-Night Grocers", "8 Johnstown Road", "Ireland"));
            // cust.Add(new Customer("ISLAT", "Helen Bennett", "Island Trading", "Garden House Crowther Way", "UK"));
            // cust.Add(new Customer("KOENE", "Philip Cramer", "Königlich Essen", "Maubelstr. 90", "Germany"));
            // cust.Add(new Customer("LACOR", "Daniel Tonini", "La corne d'abondance", "67, avenue de l'Europe", "France"));
            // cust.Add(new Customer("LAMAI", "Annette Roulet", "La maison d'Asie", "1 rue Alsace-Lorraine", "France"));
            // cust.Add(new Customer("LAUGB", "Yoshi Tannamuri", "Laughing Bacchus Wine Cellars", "1900 Oak St.", "Canada"));
            // cust.Add(new Customer("LAZYK", "John Steel", "Lazy K Kountry Store", "12 Orchestra Terrace", "USA"));
            // cust.Add(new Customer("LEHMS", "Renate Messner", "Lehmanns Marktstand", "Magazinweg 7", "Germany"));
            // cust.Add(new Customer("LETSS", "Jaime Yorres", "Let's Stop N Shop", "87 Polk St. Suite 5", "USA"));
            // cust.Add(new Customer("LILAS", "Carlos González", "LILA-Supermercado", "Carrera 52 con Ave. Bolívar #65-98 Llano Largo", "Venezuela"));
            // cust.Add(new Customer("LINOD", "Felipe Izquierdo", "LINO-Delicateses", "Ave. 5 de Mayo Porlamar", "Venezuela"));
            // cust.Add(new Customer("LONEP", "Fran Wilson", "Lonesome Pine Restaurant", "89 Chiaroscuro Rd.", "USA"));
            // cust.Add(new Customer("MAGAA", "Giovanni Rovelli", "Magazzini Alimentari Riuniti", "Via Ludovico il Moro 22", "Italy"));
            // cust.Add(new Customer("MAISD", "Catherine Dewey", "Maison Dewey", "Rue Joseph-Bens 532", "Belgium"));
            // cust.Add(new Customer("MEREP", "Jean Fresnière", "Mère Paillarde", "43 rue St. Laurent", "Canada"));
            // cust.Add(new Customer("MORGK", "Alexander Feuer", "Morgenstern Gesundkost", "Heerstr. 22", "Germany"));
            // cust.Add(new Customer("NORTS", "Simon Crowther", "North/South", "South House 300 Queensbridge", "UK"));
            // cust.Add(new Customer("OCEAN", "Yvonne Moncada", "Océano Atlántico Ltda.", "Ing. Gustavo Moncada 8585 Piso 20-A", "Argentina"));
            // cust.Add(new Customer("OLDWO", "Rene Phillips", "Old World Delicatessen", "2743 Bering St.", "USA"));
            // cust.Add(new Customer("OTTIK", "Henriette Pfalzheim", "Ottilies Käseladen", "Mehrheimerstr. 369", "Germany"));
            // cust.Add(new Customer("PARIS", "Marie Bertrand", "Paris spécialités", "265, boulevard Charonne", "France"));
            // cust.Add(new Customer("PERIC", "Guillermo Fernández", "Pericles Comidas clásicas", "Calle Dr. Jorge Cash 321", "Mexico"));
            // cust.Add(new Customer("PICCO", "Georg Pipps", "Piccolo und mehr", "Geislweg 14", "Austria"));
            // cust.Add(new Customer("PRINI", "Isabel de Castro", "Princesa Isabel Vinhos", "Estrada da saúde n. 58", "Portugal"));
            // cust.Add(new Customer("QUEDE", "Bernardo Batista", "Que Delícia", "Rua da Panificadora, 12", "Brazil"));
            // cust.Add(new Customer("QUEEN", "Lúcia Carvalho", "Queen Cozinha", "Alameda dos Canàrios, 891", "Brazil"));
            // cust.Add(new Customer("QUICK", "Horst Kloss", "QUICK-Stop", "Taucherstraße 10", "Germany"));
            // cust.Add(new Customer("RANCH", "Sergio Gutiérrez", "Rancho grande", "Av. del Libertador 900", "Argentina"));
            // cust.Add(new Customer("RATTC", "Paula Wilson", "Rattlesnake Canyon Grocery", "2817 Milton Dr.", "USA"));
            // cust.Add(new Customer("REGGC", "Maurizio Moroni", "Reggiani Caseifici", "Strada Provinciale 124", "Italy"));
            // cust.Add(new Customer("RICAR", "Janete Limeira", "Ricardo Adocicados", "Av. Copacabana, 267", "Brazil"));
            // cust.Add(new Customer("RICSU", "Michael Holz", "Richter Supermarkt", "Grenzacherweg 237", "Switzerland"));
            // cust.Add(new Customer("ROMEY", "Alejandra Camino", "Romero y tomillo", "Gran Vía, 1", "Spain"));
            // cust.Add(new Customer("SANTG", "Jonas Bergulfsen", "Santé Gourmet", "Erling Skakkes gate 78", "Norway"));
            // cust.Add(new Customer("SAVEA", "Jose Pavarotti", "Save-a-lot Markets", "187 Suffolk Ln.", "USA"));
            // cust.Add(new Customer("SEVES", "Hari Kumar", "Seven Seas Imports", "90 Wadhurst Rd.", "UK"));
            // cust.Add(new Customer("SIMOB", "Jytte Petersen", "Simons bistro", "Vinbæltet 34", "Denmark"));
            // cust.Add(new Customer("SPECD", "Dominique Perrier", "Spécialités du monde", "25, rue Lauriston", "France"));
            // cust.Add(new Customer("SPLIR", "Art Braunschweiger", "Split Rail Beer & Ale", "P.O. Box 555", "USA"));
            // cust.Add(new Customer("SUPRD", "Pascale Cartrain", "Suprêmes délices", "Boulevard Tirou, 255", "Belgium"));
            // cust.Add(new Customer("THEBI", "Liz Nixon", "The Big Cheese", "89 Jefferson Way Suite 2", "USA"));
            // cust.Add(new Customer("THECR", "Liu Wong", "The Cracker Box", "55 Grizzly Peak Rd.", "USA"));
            // cust.Add(new Customer("TOMSP", "Karin Josephs", "Toms Spezialitäten", "Luisenstr. 48", "Germany"));
            // cust.Add(new Customer("TORTU", "Miguel Angel Paolino", "Tortuga Restaurante", "Avda. Azteca 123", "Mexico"));
            // cust.Add(new Customer("TRADH", "Anabela Domingues", "Tradição Hipermercados", "Av. Inês de Castro, 414", "Brazil"));
            // cust.Add(new Customer("TRAIH", "Helvetius Nagy", "Trail's Head Gourmet Provisioners", "722 DaVinci Blvd.", "USA"));
            // cust.Add(new Customer("VAFFE", "Palle Ibsen", "Vaffeljernet", "Smagsloget 45", "Denmark"));
            // cust.Add(new Customer("VICTE", "Mary Saveley", "Victuailles en stock", "2, rue du Commerce", "France"));
            // cust.Add(new Customer("VINET", "Paul Henriot", "Vins et alcools Chevalier", "59 rue de l'Abbaye", "France"));
            // cust.Add(new Customer("WANDK", "Rita Müller", "Die Wandernde Kuh", "Adenauerallee 900", "Germany"));
            // cust.Add(new Customer("WARTH", "Pirkko Koskitalo", "Wartian Herkku", "Torikatu 38", "Finland"));
            // cust.Add(new Customer("WELLI", "Paula Parente", "Wellington Importadora", "Rua do Mercado, 12", "Brazil"));
            // cust.Add(new Customer("WHITC", "Karl Jablonski", "White Clover Markets", "305 - 14th Ave. S. Suite 3B", "USA"));
            // cust.Add(new Customer("WILMK", "Matti Karttunen", "Wilman Kala", "Keskuskatu 45", "Finland"));
            // cust.Add(new Customer("WOLZA", "Zbyszek Piestrzeniewicz", "Wolski  Zajazd", "ul. Filtrowa 68", "Poland"));
            return cust;
        }
        public string CustomerID { get; set; }
        public string ContactName { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }


    }
}