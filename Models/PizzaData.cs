#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EJ2CoreSampleBrowser.Models
{
    public class PizzaData
    {
        public PizzaData() { }

        public PizzaData(int Id, string Title, string Type, string Size, string Description, List<string> Tags, string ImageURL, string Price, string OriginalPrice = null)
        {
            this.Id = Id;
            this.Title = Title;
            this.Type = Type;
            this.Size = Size;
            this.Description = Description;
            this.Tags = Tags;
            this.ImageURL = ImageURL;
            this.Price = Price;
            this.OriginalPrice = OriginalPrice;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Size { get; set; }
        public string Description { get; set; }
        public List<string> Tags { get; set; }
        public string ImageURL { get; set; }
        public string Price { get; set; }
        public string OriginalPrice { get; set; }

        public static List<PizzaData> GetAllRecords()
        {
            List<PizzaData> pizzaList = new List<PizzaData>
            {
                new PizzaData(1, "Mexican Green Wave", "Vegetarian", "Small", "Stromboli sandwich with chili sauce.", new List<string> { "Onions", "Pepper", "Cheese" }, "Mexican_Green_Wave.jpg", "$4.79", "$6.58"),
                new PizzaData(2, "Fresh Veggie", "Vegetarian", "Medium", "Veggie with Onions and Capsicum.", new List<string> { "Onions", "Capsicum" }, "Fresh_Veggie.jpg", "$11.99"),
                new PizzaData(3, "Peppy Paneer", "Vegetarian", "Large", "It's made using toppings of tomato, mozzarella cheese and fresh basil.", new List<string> { "Onions", "Pepper", "Cheese" }, "Peppy_Paneer.jpg", "$14.99", "$16.08"),
                new PizzaData(4, "Margherita", "Vegetarian", "Small", "Lebanese Pizza topped with tomato sauce.", new List<string> { "Onions", "Pepper", "Cheese" }, "Margherit.jpg", "$4.79", "$7.56"),
                new PizzaData(5, "Indian Tandoori Paneer", "Vegetarian", "Medium", "Tandoori Paneer with capsicum, red paprika and mint.", new List<string> { "Paneer", "Capsicum" }, "IndianTandooriPaneer.jpg", "$11.99"),
                new PizzaData(6, "Pepper Barbecue Chicken", "Non-Vegetarian", "Medium", "Pepper Barbecue Chicken with cheese.", new List<string> { "Pepper", "Chicken", "Cheese" }, "Pepper_Barbeque.jpg", "$11.99"),
                new PizzaData(7, "Chicken Sausage", "Non-Vegetarian", "Large", "Chicken Sausage with cheese.", new List<string> { "Cheese", "Chicken" }, "Chicken_Sausage.jpg", "$14.99"),
                new PizzaData(8, "Chicken Golden Delight", "Non-Vegetarian", "Large", "Barbeque chicken with a topping of golden corn loaded with extra cheese.", new List<string> { "Onions", "BBQ", "Prawn" }, "Chicken_Golden_Delight.jpg", "$14.99", "$17.99"),
                new PizzaData(9, "Pepper Barbecue and Onion", "Non-Vegetarian", "Medium", "Pepper Barbecue chicken with Onion.", new List<string> { "Pepper", "Chicken" }, "Pepper_Barbeque_Onion.jpg", "$11.99"),
                new PizzaData(10, "Chicken Fiesta", "Non-Vegetarian", "Small", "Grilled Chicken Rashers with Peri-Peri chicken, Onion and Capsicum.", new List<string> { "Chicken", "Capsicum" }, "chunky-chicken.png", "$4.79", "$9.58"),
                new PizzaData(11, "Double Cheese Margherita", "Vegetarian", "Medium", "Margherita with chili sauce and double Cheese.", new List<string> { "Onions", "Pepper" }, "Double_Cheese_Margherita.jpg", "$11.99"),
                new PizzaData(12, "Veggie Paradise", "Vegetarian", "Large", "Veggie Delight with Golden Corn, Black Olives, Capsicum, and red Paprika.", new List<string> { "Corn", "Capsicum" }, "Veggie_Paradise.jpg", "$14.99", "$15.62"),
                new PizzaData(13, "Cheese and Corn", "Vegetarian", "Large", "Cheese with golden corn.", new List<string> { "Cheese", "Corn" }, "Corn_Cheese.jpg", "$14.99"),
                new PizzaData(14, "Chicken Tikka", "Non-Vegetarian", "Medium", "Tandoori masala with Chicken Tikka, Onion, red paprika and mint.", new List<string> { "Chicken", "Tikka", "Paprika" }, "IndianChickenTikka.jpg", "$11.99", "$12.02"),
                new PizzaData(15, "Chicken Dominator", "Non-Vegetarian", "Small", "Double Pepper Barbecue Chicken with Peri-Peri Chicken, Chicken Tikka, Grilled and Rashers.", new List<string> { "Pepper", "Chicken" }, "Dominator.jpg", "$4.79", "$6.30"),
                new PizzaData(16, "Deluxe Veggie", "Vegetarian", "Medium", "Onions and Capsicum those delectable mushrooms with paneer and golden corn to top it all.", new List<string> { "Mushrooms", "Corn" }, "Deluxe_Veggie.jpg", "$11.99"),
                new PizzaData(17, "Farm House", "Vegetarian", "Large", "Crunchy, crisp capsicum, succulent mushrooms and fresh tomatoes.", new List<string> { "Capsicum", "Mushrooms" }, "Farmhouse.jpg", "$14.99"),
                new PizzaData(18, "Veg Extravanganza", "Vegetarian", "Large", "Pizza with corn, olives, onions, capsicum, tomatoes and jalapeno with cheese to go all around.", new List<string> { "Corn", "Mushrooms" }, "Veg_Extravaganz.jpg", "$14.99", "$19.58"),
                new PizzaData(19, "Margherita", "Vegetarian", "Small", "Lebanese Pizza topped with tomato sauce.", new List<string> { "Onions", "Pepper", "Cheese" }, "Margherit.jpg", "$4.79", "$7.77"),
                new PizzaData(20, "Pepper Barbecue and Onion", "Non-Vegetarian", "Medium", "Pepper Barbecue chicken with Onion.", new List<string> { "Onions", "Pepper", "Chicken" }, "Pepper_Barbeque_Onion.jpg", "$11.99"),
                new PizzaData(21, "Veggie Paradise", "Vegetarian", "Large", "Veggie Delight with Golden Corn, Black Olives, Capsicum, and red Paprika.", new List<string> { "Corn", "Capsicum", "Pepper" }, "Veggie_Paradise.jpg", "$14.99", "$15.34"),
                new PizzaData(22, "Chicken Dominator", "Non-Vegetarian", "Small", "Double Pepper Barbecue Chicken with Peri-Peri Chicken, Chicken Tikka, Grilled and Rashers.", new List<string> { "Pepper", "Chicken" }, "Dominator.jpg", "$4.79")
            };

            return pizzaList;
        }
    }
}