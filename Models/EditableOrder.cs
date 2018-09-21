namespace MVCSampleBrowser.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class EditableOrder
    {
        [Range(0, int.MaxValue, ErrorMessage = "OrderID must be greater than 0.")]
        public int OrderID
        {
            get;
            set;
        }

        [StringLength(5, ErrorMessage = "CustomerID must be 5 characters.")]
        public string CustomerID
        {
            get;
            set;
        }

        [Range(1, 9, ErrorMessage = "EmployeeID must be between 0 and 9.")]
        public int EmployeeID
        {
            get;
            set;
        }

        [RegularExpression(@"^(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d$", ErrorMessage = "Date is required")]
        public DateTime? OrderDate
        {
            get;
            set;
        }

      
        public string ShipName
        {
            get;
            set;
        }

        [StringLength(15, ErrorMessage = "ShipCity must be 15 characters.")]
        public string ShipCity
        {
            get;
            set;
        }

        public string ShipAddress
        {
            get;
            set;
        }

        public string ShipRegion
        {
            get;
            set;
        }

        public string ShipPostalCode
        {
            get;
            set;
        }

        [StringLength(15, ErrorMessage = "ShipName must be 15 characters.")]
        public string ShipCountry
        {
            get;
            set;
        }

        [Range(1.00, 1000.00, ErrorMessage = "Freight must be between 1.00 & 1000")]
        public decimal? Freight
        {
            get;
            set;
        }

        public bool Verified
        {
            get;
            set;
        }
        public EditableEmployee Employee
		{ 
			get;
			set; 
		}
}
}