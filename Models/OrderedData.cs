using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EJ2CoreSampleBrowser.Models
{
    public class OrderedData
    {
        public OrderedData() { }

        public OrderedData(
            int OrderID,
            string CustomerName,
            int EmployeeID,
            double Freight,
            bool Verified,
            DateTime OrderDate,
            string ShipCity,
            string ShipName,
            string ShipCountry,
            DateTime ShippedDate,
            string ShipAddress)
        {
            this.OrderID = OrderID;
            this.CustomerName = CustomerName;
            this.EmployeeID = EmployeeID;
            this.Freight = Freight;
            this.Verified = Verified;
            this.OrderDate = OrderDate;
            this.ShipCity = ShipCity;
            this.ShipName = ShipName;
            this.ShipCountry = ShipCountry;
            this.ShippedDate = ShippedDate;
            this.ShipAddress = ShipAddress;
        }

        public static List<OrderedData> GetAllRecords()
        {
            return new List<OrderedData>
            {
                new OrderedData(1001,"John Miller",1,45.50,true,new DateTime(2025,1,15),"City","John Miller","USA",new DateTime(2025,1,20),"Address"),
                new OrderedData(1002,"Sarah Johnson",2,62.75,true,new DateTime(2025,2,3),"City","Sarah Johnson","Canada",new DateTime(2025,2,8),"Address"),
                new OrderedData(1003,"Michael Davis",3,38.25,true,new DateTime(2025,2,18),"City","Michael Davis","UK",new DateTime(2025,2,23),"Address"),
                new OrderedData(1004,"Emily Brown",4,55.00,true,new DateTime(2025,3,5),"City","Emily Brown","Germany",new DateTime(2025,3,10),"Address"),
                new OrderedData(1005,"James Wilson",5,41.30,true,new DateTime(2025,3,22),"City","James Wilson","France",new DateTime(2025,3,28),"Address"),
                new OrderedData(1006,"Lisa Anderson",6,73.90,true,new DateTime(2025,4,10),"City","Lisa Anderson","Australia",new DateTime(2025,4,16),"Address"),
                new OrderedData(1007,"David Martinez",7,52.15,true,new DateTime(2025,4,25),"City","David Martinez","Spain",new DateTime(2025,5,2),"Address"),
                new OrderedData(1008,"Jennifer Garcia",8,39.60,true,new DateTime(2025,5,8),"City","Jennifer Garcia","Italy",new DateTime(2025,5,14),"Address"),
                new OrderedData(1009,"Robert Taylor",9,68.40,true,new DateTime(2025,5,20),"City","Robert Taylor","Japan",new DateTime(2025,5,27),"Address"),
                new OrderedData(1010,"Amanda White",10,44.85,true,new DateTime(2025,6,3),"City","Amanda White","Mexico",new DateTime(2025,6,9),"Address"),
                new OrderedData(1011,"Christopher Harris",11,57.20,true,new DateTime(2025,6,18),"City","Christopher Harris","Brazil",new DateTime(2025,6,25),"Address"),
                new OrderedData(1012,"Rachel Martin",12,48.70,true,new DateTime(2025,7,1),"City","Rachel Martin","India",new DateTime(2025,7,8),"Address"),
                new OrderedData(1013,"Daniel Thompson",13,61.45,true,new DateTime(2025,7,15),"City","Daniel Thompson","China",new DateTime(2025,7,22),"Address"),
                new OrderedData(1014,"Jessica Lee",14,35.80,true,new DateTime(2025,8,2),"City","Jessica Lee","Singapore",new DateTime(2025,8,8),"Address"),
                new OrderedData(1015,"Matthew Clark",15,66.30,true,new DateTime(2025,8,17),"City","Matthew Clark","Netherlands",new DateTime(2025,8,24),"Address"),
                new OrderedData(1016,"Ashley Rodriguez",16,43.50,true,new DateTime(2025,9,3),"City","Ashley Rodriguez","Belgium",new DateTime(2025,9,10),"Address"),
                new OrderedData(1017,"Kevin Lewis",17,59.15,true,new DateTime(2025,9,19),"City","Kevin Lewis","Sweden",new DateTime(2025,9,26),"Address"),
                new OrderedData(1018,"Nicole Walker",18,47.65,true,new DateTime(2025,10,4),"City","Nicole Walker","Norway",new DateTime(2025,10,11),"Address"),
                new OrderedData(1019,"Brandon Hall",19,70.25,true,new DateTime(2025,10,20),"City","Brandon Hall","South Korea",new DateTime(2025,10,28),"Address"),
                new OrderedData(1020,"Stephanie Allen",20,51.90,true,new DateTime(2025,11,2),"City","Stephanie Allen","Thailand",new DateTime(2025,11,9),"Address"),
                new OrderedData(1021,"Ryan Young",21,42.35,true,new DateTime(2025,11,18),"City","Ryan Young","Malaysia",new DateTime(2025,11,25),"Address"),
                new OrderedData(1022,"Victoria King",22,64.80,true,new DateTime(2025,12,1),"City","Victoria King","Philippines",new DateTime(2025,12,8),"Address"),
                new OrderedData(1023,"Joshua Wright",23,37.45,true,new DateTime(2026,1,5),"City","Joshua Wright","Vietnam",new DateTime(2026,1,12),"Address"),
                new OrderedData(1024,"Megan Scott",24,69.50,true,new DateTime(2026,1,20),"City","Megan Scott","Indonesia",new DateTime(2026,1,27),"Address"),
                new OrderedData(1025,"Tyler Green",25,46.25,true,new DateTime(2026,2,8),"City","Tyler Green","Pakistan",new DateTime(2026,2,15),"Address"),
                new OrderedData(1026,"Olivia Adams",26,58.70,true,new DateTime(2026,2,22),"City","Olivia Adams","Egypt",new DateTime(2026,3,1),"Address"),
                new OrderedData(1027,"Jacob Nelson",27,40.15,true,new DateTime(2026,3,10),"City","Jacob Nelson","South Africa",new DateTime(2026,3,17),"Address"),
                new OrderedData(1028,"Sophia Baker",28,72.60,true,new DateTime(2026,3,25),"City","Sophia Baker","Nigeria",new DateTime(2026,4,2),"Address"),
                new OrderedData(1029,"Mason Carter",29,49.35,true,new DateTime(2026,4,12),"City","Mason Carter","Kenya",new DateTime(2026,4,19),"Address"),
                new OrderedData(1030,"Isabella Mitchell",30,63.45,true,new DateTime(2026,4,28),"City","Isabella Mitchell","UAE",new DateTime(2026,5,5),"Address")
            };
        }

        public int? OrderID { get; set; }
        public string CustomerName { get; set; }
        public int? EmployeeID { get; set; }
        public double? Freight { get; set; }
        public string ShipCity { get; set; }
        public bool Verified { get; set; }
        public DateTime OrderDate { get; set; }
        public string ShipName { get; set; }
        public string ShipCountry { get; set; }
        public DateTime ShippedDate { get; set; }
        public string ShipAddress { get; set; }
    }
}