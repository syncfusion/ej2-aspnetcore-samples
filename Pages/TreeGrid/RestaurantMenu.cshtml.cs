#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EJ2CoreSampleBrowser.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.TreeGrid
{
    public class FoodItem : PageModel
    {
        public string FoodCategory { get; set; }
        public string FoodName { get; set; }
        public string FoodType { get; set; }
        public double newPrice { get; set; }
        public double originalPrice { get; set; }
        public string Image { get; set; }
        public int FoodId { get; set; }
        public int? CategoryId { get; set; }
        public double Rating { get; set; }
        public int TotalReviews { get; set; }
        public string FoodDescription { get; set; }
        public bool IsBestseller { get; set; }
        public int vegCount { get; set; }
        public int nonvegCount { get; set; }
        public List<string> ingredients { get; set; }
        public FoodItem() { }
        public static List<FoodItem> GetData()
        {
            List<FoodItem> FoodMenuCollection = new List<FoodItem>();

            FoodMenuCollection.Add(new FoodItem()
            {
                FoodId = 1,
                CategoryId = null,
                FoodName = "Salads",
                FoodCategory = "Salads",
                FoodType = "Veg",
                newPrice = 0,
                originalPrice = 0,
                Image = "",
                Rating = 0,
                TotalReviews = 0,
                FoodDescription = "",
                IsBestseller = false,
                vegCount = 2,
                nonvegCount = 4,
                ingredients = new List<string>()
            });
            FoodMenuCollection.Add(new FoodItem()
            {
                FoodId = 2,
                CategoryId = 1,
                FoodName = "House Salad",
                FoodCategory = "Salads",
                FoodType = "Veg",
                newPrice = 7.99,
                originalPrice = 9.99,
                Image = "../images/treegrid/house-salad.png",
                Rating = 4.5,
                TotalReviews = 120,
                FoodDescription = "A refreshing blend of crisp lettuce, cherry tomatoes, cucumbers, and carrots.",
                IsBestseller = true,
                vegCount = 0,
                nonvegCount = 0,
                ingredients = new List<string> { "Lettuce", "Tomatoes", "Cucumbers", "Carrots" }
            });
            FoodMenuCollection.Add(new FoodItem()
            {
                FoodId = 3,
                CategoryId = 1,
                FoodName = "Cranberry Chicken Salad",
                FoodCategory = "Salads",
                FoodType = "Non-veg",
                newPrice = 13.99,
                originalPrice = 0,
                Image = "../images/treegrid/cranberry-chicken-salad.png",
                Rating = 4.6,
                TotalReviews = 110,
                FoodDescription = "Grilled chicken breast with mixed greens and dried cranberries.",
                IsBestseller = true,
                vegCount = 0,
                nonvegCount = 0,
                ingredients = new List<string> { "Chicken breast", "Mixed greens", "Cranberries" }
            });
            FoodMenuCollection.Add(new FoodItem()
            {
                FoodId = 4,
                CategoryId = 1,
                FoodName = "Chili Chicken Steamed",
                FoodCategory = "Salads",
                FoodType = "Non-veg",
                newPrice = 12.49,
                originalPrice = 14.49,
                Image = "../images/treegrid/chili-chicken-steamed.png",
                Rating = 4.4,
                TotalReviews = 90,
                FoodDescription = "Steamed chicken tossed with green chilies and garlic.",
                IsBestseller = false,
                vegCount = 0,
                nonvegCount = 0,
                ingredients = new List<string> { "Chicken", "Green chilies", "Garlic" }
            });
            FoodMenuCollection.Add(new FoodItem()
            {
                FoodId = 5,
                CategoryId = 1,
                FoodName = "Spinach Salad",
                FoodCategory = "Salads",
                FoodType = "Veg",
                newPrice = 8.99,
                originalPrice = 0,
                Image = "../images/treegrid/spinach-salad.png",
                Rating = 4.3,
                TotalReviews = 80,
                FoodDescription = "Fresh baby spinach, cherry tomatoes, and walnuts.",
                IsBestseller = false,
                vegCount = 0,
                nonvegCount = 0,
                ingredients = new List<string> { "Spinach", "Tomatoes", "Walnuts" }
            });
            FoodMenuCollection.Add(new FoodItem()
            {
                FoodId = 6,
                CategoryId = 1,
                FoodName = "Caesar Salad",
                FoodCategory = "Salads",
                FoodType = "Non-veg",
                newPrice = 10.99,
                originalPrice = 12.99,
                Image = "../images/treegrid/caesar-salad.png",
                Rating = 4.7,
                TotalReviews = 140,
                FoodDescription = "Romaine lettuce with Parmesan and croutons.",
                IsBestseller = true,
                vegCount = 0,
                nonvegCount = 0,
                ingredients = new List<string> { "Romaine lettuce", "Parmesan", "Croutons" }
            });
            FoodMenuCollection.Add(new FoodItem()
            {
                FoodId = 7,
                CategoryId = 1,
                FoodName = "Blue Chicken Salad",
                FoodCategory = "Salads",
                FoodType = "Non-veg",
                newPrice = 12.99,
                originalPrice = 14.99,
                Image = "../images/treegrid/blue-chicken-salad.png",
                Rating = 4.2,
                TotalReviews = 60,
                FoodDescription = "Grilled chicken, blue cheese, and mixed greens.",
                IsBestseller = false,
                vegCount = 0,
                nonvegCount = 0,
                ingredients = new List<string> { "Chicken", "Blue cheese", "Mixed greens" }
            });

            // Pizza Category
            FoodMenuCollection.Add(new FoodItem()
            {
                FoodId = 8,
                CategoryId = null,
                FoodName = "Pizza",
                FoodCategory = "Pizza",
                FoodType = "Veg",
                newPrice = 0,
                originalPrice = 0,
                Image = "",
                Rating = 0,
                TotalReviews = 0,
                FoodDescription = "",
                IsBestseller = false,
                vegCount = 3,
                nonvegCount = 3,
                ingredients = new List<string>()
            });
            FoodMenuCollection.Add(new FoodItem()
            {
                FoodId = 9,
                CategoryId = 8,
                FoodName = "Veggie Pizza",
                FoodCategory = "Pizza",
                FoodType = "Veg",
                newPrice = 14.99,
                originalPrice = 0,
                Image = "../images/treegrid/veggie-pizza.png",
                Rating = 4.6,
                TotalReviews = 100,
                FoodDescription = "Bell peppers, onions, olives, and mozzarella cheese.",
                IsBestseller = true,
                vegCount = 0,
                nonvegCount = 0,
                ingredients = new List<string> { "Bell peppers", "Onions", "Olives", "Mozzarella" }
            });
            FoodMenuCollection.Add(new FoodItem()
            {
                FoodId = 10,
                CategoryId = 8,
                FoodName = "Margherita Pizza",
                FoodCategory = "Pizza",
                FoodType = "Veg",
                newPrice = 13.99,
                originalPrice = 0,
                Image = "../images/treegrid/margherita-pizza.png",
                Rating = 4.7,
                TotalReviews = 120,
                FoodDescription = "Fresh mozzarella, tomato sauce, and basil.",
                IsBestseller = true,
                vegCount = 0,
                nonvegCount = 0,
                ingredients = new List<string> { "Mozzarella", "Tomato sauce", "Basil" }
            });
            FoodMenuCollection.Add(new FoodItem()
            {
                FoodId = 11,
                CategoryId = 8,
                FoodName = "Quattro Formaggi Pizza",
                FoodCategory = "Pizza",
                FoodType = "Veg",
                newPrice = 15.99,
                originalPrice = 18.99,
                Image = "../images/treegrid/quattro-formaggi.png",
                Rating = 4.8,
                TotalReviews = 80,
                FoodDescription = "Mozzarella, cheddar, parmesan, and blue cheese.",
                IsBestseller = false,
                vegCount = 0,
                nonvegCount = 0,
                ingredients = new List<string> { "Mozzarella", "Cheddar", "Parmesan", "Blue cheese" }
            });
            FoodMenuCollection.Add(new FoodItem()
            {
                FoodId = 12,
                CategoryId = 8,
                FoodName = "Capricciosa Pizza",
                FoodCategory = "Pizza",
                FoodType = "Non-veg",
                newPrice = 16.99,
                originalPrice = 0,
                Image = "../images/treegrid/capricciosa-pizza.png",
                Rating = 4.5,
                TotalReviews = 60,
                FoodDescription = "Ham, mushrooms, artichokes, and olives.",
                IsBestseller = false,
                vegCount = 0,
                nonvegCount = 0,
                ingredients = new List<string> { "Ham", "Mushrooms", "Artichokes", "Olives" }
            });
            FoodMenuCollection.Add(new FoodItem()
            {
                FoodId = 13,
                CategoryId = 8,
                FoodName = "Pepperoni Pizza",
                FoodCategory = "Pizza",
                FoodType = "Non-veg",
                newPrice = 15.99,
                originalPrice = 0,
                Image = "../images/treegrid/pepperoni-pizza.png",
                Rating = 4.9,
                TotalReviews = 140,
                FoodDescription = "Pepperoni and mozzarella cheese.",
                IsBestseller = true,
                vegCount = 0,
                nonvegCount = 0,
                ingredients = new List<string> { "Pepperoni", "Mozzarella" }
            });
            FoodMenuCollection.Add(new FoodItem()
            {
                FoodId = 14,
                CategoryId = 8,
                FoodName = "BBQ Chicken Pizza",
                FoodCategory = "Pizza",
                FoodType = "Non-veg",
                newPrice = 16.49,
                originalPrice = 19.49,
                Image = "../images/treegrid/BBQ-chicken-pizza.png",
                Rating = 4.8,
                TotalReviews = 110,
                FoodDescription = "BBQ chicken, onions, and mozzarella.",
                IsBestseller = false,
                vegCount = 0,
                nonvegCount = 0,
                ingredients = new List<string> { "Chicken", "Onions", "Mozzarella" }
            });

            // Burger Category
            FoodMenuCollection.Add(new FoodItem()
            {
                FoodId = 15,
                CategoryId = null,
                FoodName = "Burger",
                FoodCategory = "Burger",
                FoodType = "Veg",
                newPrice = 0,
                originalPrice = 0,
                Image = "",
                Rating = 0,
                TotalReviews = 0,
                FoodDescription = "",
                IsBestseller = false,
                vegCount = 2,
                nonvegCount = 7,
                ingredients = new List<string>()
            });
            FoodMenuCollection.Add(new FoodItem()
            {
                FoodId = 16,
                CategoryId = 15,
                FoodName = "Cheeseburger",
                FoodCategory = "Burger",
                FoodType = "Non-veg",
                newPrice = 8.99,
                originalPrice = 10.99,
                Image = "../images/treegrid/cheeseburger.png",
                Rating = 4.5,
                TotalReviews = 90,
                FoodDescription = "Beef patty with cheese, lettuce, and tomato.",
                IsBestseller = true,
                vegCount = 0,
                nonvegCount = 0,
                ingredients = new List<string> { "Beef patty", "Cheese", "Lettuce", "Tomato" }
            });
            FoodMenuCollection.Add(new FoodItem()
            {
                FoodId = 17,
                CategoryId = 15,
                FoodName = "Smash Burger",
                FoodCategory = "Burger",
                FoodType = "Non-veg",
                newPrice = 9.99,
                originalPrice = 0,
                Image = "../images/treegrid/smash-burger.png",
                Rating = 4.6,
                TotalReviews = 80,
                FoodDescription = "Double beef patties with cheese and pickles.",
                IsBestseller = false,
                vegCount = 0,
                nonvegCount = 0,
                ingredients = new List<string> { "Beef patties", "Cheese", "Pickles" }
            });
            FoodMenuCollection.Add(new FoodItem()
            {
                FoodId = 18,
                CategoryId = 15,
                FoodName = "Butter Burger",
                FoodCategory = "Burger",
                FoodType = "Non-veg",
                newPrice = 8.99,
                originalPrice = 10.99,
                Image = "../images/treegrid/butter-burger.png",
                Rating = 4.4,
                TotalReviews = 70,
                FoodDescription = "Beef patty with buttery glaze and lettuce.",
                IsBestseller = false,
                vegCount = 0,
                nonvegCount = 0,
                ingredients = new List<string> { "Beef patty", "Butter", "Lettuce" }
            });
            FoodMenuCollection.Add(new FoodItem()
            {
                FoodId = 19,
                CategoryId = 15,
                FoodName = "Chili Burger",
                FoodCategory = "Burger",
                FoodType = "Non-veg",
                newPrice = 9.49,
                originalPrice = 11.49,
                Image = "../images/treegrid/chili-burger.png",
                Rating = 4.3,
                TotalReviews = 60,
                FoodDescription = "Chili beef patty with jalape�os and cheese.",
                IsBestseller = false,
                vegCount = 0,
                nonvegCount = 0,
                ingredients = new List<string> { "Beef patty", "Jalape�os", "Cheese" }
            });
            FoodMenuCollection.Add(new FoodItem()
            {
                FoodId = 20,
                CategoryId = 15,
                FoodName = "Veggie Burger",
                FoodCategory = "Burger",
                FoodType = "Veg",
                newPrice = 7.99,
                originalPrice = 0,
                Image = "../images/treegrid/veggie-burger.png",
                Rating = 4.2,
                TotalReviews = 50,
                FoodDescription = "Vegetable patty with lettuce and tomato.",
                IsBestseller = false,
                vegCount = 0,
                nonvegCount = 0,
                ingredients = new List<string> { "Vegetable patty", "Lettuce", "Tomato" }
            });
            FoodMenuCollection.Add(new FoodItem()
            {
                FoodId = 21,
                CategoryId = 15,
                FoodName = "Black Bean Burger",
                FoodCategory = "Burger",
                FoodType = "Veg",
                newPrice = 8.49,
                originalPrice = 0,
                Image = "../images/treegrid/black-bean-burger.png",
                Rating = 4.1,
                TotalReviews = 40,
                FoodDescription = "Black bean patty with greens and tomato.",
                IsBestseller = false,
                vegCount = 0,
                nonvegCount = 0,
                ingredients = new List<string> { "Black bean patty", "Greens", "Tomato" }
            });
            FoodMenuCollection.Add(new FoodItem()
            {
                FoodId = 22,
                CategoryId = 15,
                FoodName = "Mushroom Burger",
                FoodCategory = "Burger",
                FoodType = "Veg",
                newPrice = 8.99,
                originalPrice = 10.99,
                Image = "../images/treegrid/mushroom-burger.png",
                Rating = 4.3,
                TotalReviews = 30,
                FoodDescription = "Mushroom patty with Swiss cheese and lettuce.",
                IsBestseller = false,
                vegCount = 0,
                nonvegCount = 0,
                ingredients = new List<string> { "Mushroom patty", "Swiss cheese", "Lettuce" }
            });
            FoodMenuCollection.Add(new FoodItem()
            {
                FoodId = 23,
                CategoryId = 15,
                FoodName = "Salmon Burger",
                FoodCategory = "Burger",
                FoodType = "Non-veg",
                newPrice = 11.99,
                originalPrice = 0,
                Image = "../images/treegrid/salmon-burger.png",
                Rating = 4.5,
                TotalReviews = 20,
                FoodDescription = "Salmon patty with lettuce and tomato.",
                IsBestseller = false,
                vegCount = 0,
                nonvegCount = 0,
                ingredients = new List<string> { "Salmon patty", "Lettuce", "Tomato" }
            });
            FoodMenuCollection.Add(new FoodItem()
            {
                FoodId = 24,
                CategoryId = 15,
                FoodName = "Chicken Burger",
                FoodCategory = "Burger",
                FoodType = "Non-veg",
                newPrice = 9.99,
                originalPrice = 11.99,
                Image = "../images/treegrid/chicken-burger.png",
                Rating = 4.6,
                TotalReviews = 60,
                FoodDescription = "Chicken fillet with lettuce.",
                IsBestseller = true,
                vegCount = 0,
                nonvegCount = 0,
                ingredients = new List<string> { "Chicken fillet", "Lettuce" }
            });

            // Hot Dogs Category
            FoodMenuCollection.Add(new FoodItem()
            {
                FoodId = 25,
                CategoryId = null,
                FoodName = "Hot Dogs",
                FoodCategory = "Hot Dogs",
                FoodType = "Veg",
                newPrice = 0,
                originalPrice = 0,
                Image = "",
                Rating = 0,
                TotalReviews = 0,
                FoodDescription = "",
                IsBestseller = false,
                vegCount = 1,
                nonvegCount = 5,
                ingredients = new List<string>()
            });
            FoodMenuCollection.Add(new FoodItem()
            {
                FoodId = 26,
                CategoryId = 25,
                FoodName = "Classic Hot Dog",
                FoodCategory = "Hot Dogs",
                FoodType = "Non-veg",
                newPrice = 5.99,
                originalPrice = 7.99,
                Image = "../images/treegrid/classic-hotdog.png",
                Rating = 4.6,
                TotalReviews = 60,
                FoodDescription = "Hot dog sausage in a bun.",
                IsBestseller = true,
                vegCount = 0,
                nonvegCount = 0,
                ingredients = new List<string> { "Hot dog sausage", "Bun" }
            });
            FoodMenuCollection.Add(new FoodItem()
            {
                FoodId = 27,
                CategoryId = 25,
                FoodName = "Onion Dog",
                FoodCategory = "Hot Dogs",
                FoodType = "Non-veg",
                newPrice = 6.49,
                originalPrice = 0,
                Image = "../images/treegrid/onion-dog.png",
                Rating = 4.6,
                TotalReviews = 60,
                FoodDescription = "Hot dog with caramelized onions.",
                IsBestseller = true,
                vegCount = 0,
                nonvegCount = 0,
                ingredients = new List<string> { "Hot dog sausage", "Bun", "Onions" }
            });
            FoodMenuCollection.Add(new FoodItem()
            {
                FoodId = 28,
                CategoryId = 25,
                FoodName = "Bacon Dog",
                FoodCategory = "Hot Dogs",
                FoodType = "Non-veg",
                newPrice = 7.49,
                originalPrice = 9.49,
                Image = "../images/treegrid/bacon_dog.png",
                Rating = 4.6,
                TotalReviews = 60,
                FoodDescription = "Hot dog wrapped in bacon.",
                IsBestseller = true,
                vegCount = 0,
                nonvegCount = 0,
                ingredients = new List<string> { "Hot dog sausage", "Bacon", "Bun" }
            });
            FoodMenuCollection.Add(new FoodItem()
            {
                FoodId = 29,
                CategoryId = 25,
                FoodName = "BBQ Veggie Dog",
                FoodCategory = "Hot Dogs",
                FoodType = "Veg",
                newPrice = 6.99,
                originalPrice = 0,
                Image = "../images/treegrid/bbq_veggie_dog.png",
                Rating = 4.6,
                TotalReviews = 60,
                FoodDescription = "Veggie sausage with BBQ sauce.",
                IsBestseller = true,
                vegCount = 0,
                nonvegCount = 0,
                ingredients = new List<string> { "Veggie sausage", "Bun" }
            });
            FoodMenuCollection.Add(new FoodItem()
            {
                FoodId = 30,
                CategoryId = 25,
                FoodName = "Cheese Hot Dog",
                FoodCategory = "Hot Dogs",
                FoodType = "Non-veg",
                newPrice = 6.99,
                originalPrice = 8.99,
                Image = "../images/treegrid/cheese-hotdog.png",
                Rating = 4.6,
                TotalReviews = 60,
                FoodDescription = "Hot dog with melted cheese.",
                IsBestseller = true,
                vegCount = 0,
                nonvegCount = 0,
                ingredients = new List<string> { "Hot dog sausage", "Cheese", "Bun" }
            });
            FoodMenuCollection.Add(new FoodItem()
            {
                FoodId = 31,
                CategoryId = 25,
                FoodName = "Chili Dog",
                FoodCategory = "Hot Dogs",
                FoodType = "Non-veg",
                newPrice = 7.49,
                originalPrice = 9.49,
                Image = "../images/treegrid/chili-dog.png",
                Rating = 4.6,
                TotalReviews = 60,
                FoodDescription = "Hot dog topped with chili.",
                IsBestseller = true,
                vegCount = 0,
                nonvegCount = 0,
                ingredients = new List<string> { "Hot dog sausage", "Chili", "Bun" }
            });

            // Chowmein Category
            FoodMenuCollection.Add(new FoodItem()
            {
                FoodId = 32,
                CategoryId = null,
                FoodName = "Chowmein",
                FoodCategory = "Chowmein",
                FoodType = "Veg",
                newPrice = 0,
                originalPrice = 0,
                Image = "",
                Rating = 0,
                TotalReviews = 0,
                FoodDescription = "",
                IsBestseller = false,
                vegCount = 0,
                nonvegCount = 11,
                ingredients = new List<string>()
            });
            FoodMenuCollection.Add(new FoodItem()
            {
                FoodId = 33,
                CategoryId = 32,
                FoodName = "Manchurian Chicken Chowmein",
                FoodCategory = "Chowmein",
                FoodType = "Non-veg",
                newPrice = 12.99,
                originalPrice = 0,
                Image = "../images/treegrid/manchurian-chicken-chowmein.png",
                Rating = 4.4,
                TotalReviews = 60,
                FoodDescription = "Noodles with chicken and vegetables.",
                IsBestseller = false,
                vegCount = 0,
                nonvegCount = 0,
                ingredients = new List<string> { "Noodles", "Chicken", "Vegetables" }
            });
            FoodMenuCollection.Add(new FoodItem()
            {
                FoodId = 34,
                CategoryId = 32,
                FoodName = "Fish Chowmein",
                FoodCategory = "Chowmein",
                FoodType = "Non-veg",
                newPrice = 13.49,
                originalPrice = 0,
                Image = "../images/treegrid/fish-chowmein.png",
                Rating = 4.3,
                TotalReviews = 55,
                FoodDescription = "Noodles with fish and vegetables.",
                IsBestseller = false,
                vegCount = 0,
                nonvegCount = 0,
                ingredients = new List<string> { "Noodles", "Fish", "Vegetables" }
            });
            FoodMenuCollection.Add(new FoodItem()
            {
                FoodId = 35,
                CategoryId = 32,
                FoodName = "Paneer and Chicken Chowmein",
                FoodCategory = "Chowmein",
                FoodType = "Non-veg",
                newPrice = 13.99,
                originalPrice = 0,
                Image = "../images/treegrid/paneer-chowmein.png",
                Rating = 4.2,
                TotalReviews = 40,
                FoodDescription = "Noodles with paneer, chicken, and vegetables.",
                IsBestseller = false,
                vegCount = 0,
                nonvegCount = 0,
                ingredients = new List<string> { "Noodles", "Paneer", "Chicken" }
            });
            FoodMenuCollection.Add(new FoodItem()
            {
                FoodId = 36,
                CategoryId = 32,
                FoodName = "Egg Chowmein",
                FoodCategory = "Chowmein",
                FoodType = "Non-veg",
                newPrice = 11.99,
                originalPrice = 0,
                Image = "../images/treegrid/egg-chowmein.png",
                Rating = 4.5,
                TotalReviews = 50,
                FoodDescription = "Noodles with scrambled eggs and vegetables.",
                IsBestseller = false,
                vegCount = 0,
                nonvegCount = 0,
                ingredients = new List<string> { "Noodles", "Eggs", "Vegetables" }
            });
            FoodMenuCollection.Add(new FoodItem()
            {
                FoodId = 37,
                CategoryId = 32,
                FoodName = "Chicken Chowmein",
                FoodCategory = "Chowmein",
                FoodType = "Non-veg",
                newPrice = 12.99,
                originalPrice = 14.99,
                Image = "../images/treegrid/chicken-chowmein.png",
                Rating = 4.6,
                TotalReviews = 70,
                FoodDescription = "Noodles with chicken and vegetables.",
                IsBestseller = false,
                vegCount = 0,
                nonvegCount = 0,
                ingredients = new List<string> { "Noodles", "Chicken", "Vegetables" }
            });
            FoodMenuCollection.Add(new FoodItem()
            {
                FoodId = 38,
                CategoryId = 32,
                FoodName = "Chilli Garlic Chicken Chowmein",
                FoodCategory = "Chowmein",
                FoodType = "Non-veg",
                newPrice = 13.49,
                originalPrice = 15.49,
                Image = "../images/treegrid/chilli-garlic-chowmein.png",
                Rating = 4.3,
                TotalReviews = 45,
                FoodDescription = "Spicy noodles with chicken and garlic.",
                IsBestseller = false,
                vegCount = 0,
                nonvegCount = 0,
                ingredients = new List<string> { "Noodles", "Chicken", "Garlic" }
            });
            FoodMenuCollection.Add(new FoodItem()
            {
                FoodId = 39,
                CategoryId = 32,
                FoodName = "Tandoori Chicken Chowmein",
                FoodCategory = "Chowmein",
                FoodType = "Non-veg",
                newPrice = 13.99,
                originalPrice = 0,
                Image = "../images/treegrid/tandoori-chicken-chowmein.png",
                Rating = 4.2,
                TotalReviews = 35,
                FoodDescription = "Noodles with tandoori chicken.",
                IsBestseller = false,
                vegCount = 0,
                nonvegCount = 0,
                ingredients = new List<string> { "Noodles", "Tandoori chicken" }
            });
            FoodMenuCollection.Add(new FoodItem()
            {
                FoodId = 40,
                CategoryId = 32,
                FoodName = "Sichuan Chicken Chowmein",
                FoodCategory = "Chowmein",
                FoodType = "Non-veg",
                newPrice = 13.49,
                originalPrice = 15.49,
                Image = "../images/treegrid/sichuan-chicken-chowmein.png",
                Rating = 4.1,
                TotalReviews = 30,
                FoodDescription = "Spicy Sichuan noodles with chicken.",
                IsBestseller = false,
                vegCount = 0,
                nonvegCount = 0,
                ingredients = new List<string> { "Noodles", "Chicken" }
            });
            FoodMenuCollection.Add(new FoodItem()
            {
                FoodId = 41,
                CategoryId = 32,
                FoodName = "Shrimp Chowmein",
                FoodCategory = "Chowmein",
                FoodType = "Non-veg",
                newPrice = 14.99,
                originalPrice = 16.99,
                Image = "../images/treegrid/shrimp-chowmein.png",
                Rating = 4.5,
                TotalReviews = 25,
                FoodDescription = "Noodles with shrimp and vegetables.",
                IsBestseller = false,
                vegCount = 0,
                nonvegCount = 0,
                ingredients = new List<string> { "Noodles", "Shrimp", "Vegetables" }
            });
            FoodMenuCollection.Add(new FoodItem()
            {
                FoodId = 42,
                CategoryId = 32,
                FoodName = "Hakka Mutton Chowmein",
                FoodCategory = "Chowmein",
                FoodType = "Non-veg",
                newPrice = 13.99,
                originalPrice = 15.99,
                Image = "../images/treegrid/hakka-chowmein.png",
                Rating = 4.3,
                TotalReviews = 40,
                FoodDescription = "Hakka noodles with mutton.",
                IsBestseller = false,
                vegCount = 0,
                nonvegCount = 0,
                ingredients = new List<string> { "Noodles", "Mutton" }
            });
            FoodMenuCollection.Add(new FoodItem()
            {
                FoodId = 43,
                CategoryId = 32,
                FoodName = "Tandoori Prawn Chowmein",
                FoodCategory = "Chowmein",
                FoodType = "Non-veg",
                newPrice = 14.99,
                originalPrice = 16.99,
                Image = "../images/treegrid/tandoori-prawn-chowmein.png",
                Rating = 4.2,
                TotalReviews = 35,
                FoodDescription = "Noodles with tandoori prawn.",
                IsBestseller = false,
                vegCount = 0,
                nonvegCount = 0,
                ingredients = new List<string> { "Noodles", "Prawn" }
            });

            // Sides Category
            FoodMenuCollection.Add(new FoodItem()
            {
                FoodId = 44,
                CategoryId = null,
                FoodName = "Sides",
                FoodCategory = "Sides",
                FoodType = "Veg",
                newPrice = 0,
                originalPrice = 0,
                Image = "",
                Rating = 0,
                TotalReviews = 0,
                FoodDescription = "",
                IsBestseller = false,
                vegCount = 6,
                nonvegCount = 0,
                ingredients = new List<string>()
            });
            FoodMenuCollection.Add(new FoodItem()
            {
                FoodId = 45,
                CategoryId = 44,
                FoodName = "French Fries",
                FoodCategory = "Sides",
                FoodType = "Veg",
                newPrice = 3.99,
                originalPrice = 4.99,
                Image = "../images/treegrid/french-fries.png",
                Rating = 4.5,
                TotalReviews = 40,
                FoodDescription = "Classic crispy French fries.",
                IsBestseller = true,
                vegCount = 0,
                nonvegCount = 0,
                ingredients = new List<string> { "Potatoes", "Salt", "Oil" }
            });
            FoodMenuCollection.Add(new FoodItem()
            {
                FoodId = 46,
                CategoryId = 44,
                FoodName = "Grilled Asparagus",
                FoodCategory = "Sides",
                FoodType = "Veg",
                newPrice = 5.49,
                originalPrice = 6.49,
                Image = "../images/treegrid/grilled-asparagus.png",
                Rating = 4.7,
                TotalReviews = 25,
                FoodDescription = "Fresh asparagus grilled to perfection.",
                IsBestseller = false,
                vegCount = 0,
                nonvegCount = 0,
                ingredients = new List<string> { "Asparagus", "Olive oil", "Salt" }
            });
            FoodMenuCollection.Add(new FoodItem()
            {
                FoodId = 47,
                CategoryId = 44,
                FoodName = "Sweet Potato Fries",
                FoodCategory = "Sides",
                FoodType = "Veg",
                newPrice = 4.99,
                originalPrice = 5.99,
                Image = "../images/treegrid/sweet-potato-fries.png",
                Rating = 4.6,
                TotalReviews = 35,
                FoodDescription = "Sweet and crispy sweet potato fries.",
                IsBestseller = true,
                vegCount = 0,
                nonvegCount = 0,
                ingredients = new List<string> { "Sweet potatoes", "Salt", "Oil" }
            });
            FoodMenuCollection.Add(new FoodItem()
            {
                FoodId = 48,
                CategoryId = 44,
                FoodName = "Twice Baked Beans",
                FoodCategory = "Sides",
                FoodType = "Veg",
                newPrice = 6.49,
                originalPrice = 7.49,
                Image = "../images/treegrid/twice-baked-beans.png",
                Rating = 4.4,
                TotalReviews = 30,
                FoodDescription = "Beans baked twice with spices and herbs.",
                IsBestseller = false,
                vegCount = 0,
                nonvegCount = 0,
                ingredients = new List<string> { "Beans", "Spices", "Herbs" }
            });
            FoodMenuCollection.Add(new FoodItem()
            {
                FoodId = 49,
                CategoryId = 44,
                FoodName = "Chipotle Mashed Potatoes",
                FoodCategory = "Sides",
                FoodType = "Veg",
                newPrice = 5.99,
                originalPrice = 0,
                Image = "../images/treegrid/chipotle-mashed-potatoes.png",
                Rating = 4.8,
                TotalReviews = 50,
                FoodDescription = "Creamy mashed potatoes with chipotle flavor.",
                IsBestseller = false,
                vegCount = 0,
                nonvegCount = 0,
                ingredients = new List<string> { "Potatoes", "Chipotle", "Cream" }
            });
            FoodMenuCollection.Add(new FoodItem()
            {
                FoodId = 50,
                CategoryId = 44,
                FoodName = "Collard Greens",
                FoodCategory = "Sides",
                FoodType = "Veg",
                newPrice = 5.49,
                originalPrice = 0,
                Image = "../images/treegrid/collard-greens.png",
                Rating = 4.5,
                TotalReviews = 25,
                FoodDescription = "Slow-cooked collard greens.",
                IsBestseller = false,
                vegCount = 0,
                nonvegCount = 0,
                ingredients = new List<string> { "Collard greens", "Onions", "Garlic" }
            });

            // Desserts Category
            FoodMenuCollection.Add(new FoodItem()
            {
                FoodId = 51,
                CategoryId = null,
                FoodName = "Desserts",
                FoodCategory = "Desserts",
                FoodType = "Veg",
                newPrice = 0,
                originalPrice = 0,
                Image = "",
                Rating = 0,
                TotalReviews = 0,
                FoodDescription = "",
                IsBestseller = false,
                vegCount = 6,
                nonvegCount = 0,
                ingredients = new List<string>()
            });
            // FoodMenuCollection.Add(new FoodItem()
            // {
            //     FoodId = 52,
            //     CategoryId = 51,
            //     FoodName = "Kulfi",
            //     FoodCategory = "Desserts",
            //     FoodType = "Veg",
            //     newPrice = 4.99,
            //     originalPrice = 5.99,
            //     Image = "../images/treegrid/kulfi.png",
            //     Rating = 4.7,
            //     TotalReviews = 70,
            //     FoodDescription = "Traditional Indian frozen dessert with milk and pistachios.",
            //     IsBestseller = true,
            //     vegCount = 0,
            //     nonvegCount = 0,
            //     ingredients = new List<string> { "Milk", "Pistachios" }
            // });
            FoodMenuCollection.Add(new FoodItem()
            {
                FoodId = 53,
                CategoryId = 51,
                FoodName = "Chocolate Truffles",
                FoodCategory = "Desserts",
                FoodType = "Veg",
                newPrice = 5.99,
                originalPrice = 0,
                Image = "../images/treegrid/chocolate-truffles.png",
                Rating = 4.8,
                TotalReviews = 60,
                FoodDescription = "Chocolate ganache rolled in cocoa.",
                IsBestseller = false,
                vegCount = 0,
                nonvegCount = 0,
                ingredients = new List<string> { "Chocolate", "Cream" }
            });
            FoodMenuCollection.Add(new FoodItem()
            {
                FoodId = 54,
                CategoryId = 51,
                FoodName = "Brownies",
                FoodCategory = "Desserts",
                FoodType = "Veg",
                newPrice = 4.99,
                originalPrice = 5.99,
                Image = "../images/treegrid/brownies.png",
                Rating = 4.6,
                TotalReviews = 50,
                FoodDescription = "Fudgy chocolate brownies.",
                IsBestseller = false,
                vegCount = 0,
                nonvegCount = 0,
                ingredients = new List<string> { "Chocolate", "Flour" }
            });
            FoodMenuCollection.Add(new FoodItem()
            {
                FoodId = 55,
                CategoryId = 51,
                FoodName = "Gelato",
                FoodCategory = "Desserts",
                FoodType = "Veg",
                newPrice = 5.49,
                originalPrice = 6.49,
                Image = "../images/treegrid/gelato.png",
                Rating = 4.7,
                TotalReviews = 40,
                FoodDescription = "Italian-style ice cream.",
                IsBestseller = false,
                vegCount = 0,
                nonvegCount = 0,
                ingredients = new List<string> { "Milk", "Sugar" }
            });
            FoodMenuCollection.Add(new FoodItem()
            {
                FoodId = 56,
                CategoryId = 51,
                FoodName = "Sorbet",
                FoodCategory = "Desserts",
                FoodType = "Veg",
                newPrice = 4.99,
                originalPrice = 0,
                Image = "../images/treegrid/sorbet.png",
                Rating = 4.5,
                TotalReviews = 30,
                FoodDescription = "Refreshing fruit sorbet.",
                IsBestseller = false,
                vegCount = 0,
                nonvegCount = 0,
                ingredients = new List<string> { "Fruit", "Sugar" }
            });
            FoodMenuCollection.Add(new FoodItem()
            {
                FoodId = 57,
                CategoryId = 51,
                FoodName = "Fruit Tart",
                FoodCategory = "Desserts",
                FoodType = "Veg",
                newPrice = 5.99,
                originalPrice = 7.99,
                Image = "../images/treegrid/fruit-tart.png",
                Rating = 4.6,
                TotalReviews = 20,
                FoodDescription = "Tart shell with custard and fresh fruits.",
                IsBestseller = false,
                vegCount = 0,
                nonvegCount = 0,
                ingredients = new List<string> { "Tart shell", "Custard", "Fruits" }
            });

            return FoodMenuCollection;

        }
    }
}