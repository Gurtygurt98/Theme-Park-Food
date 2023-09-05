using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_API.Models
{
    public class FoodModel
    {
        public int ID { get; set; }
        public string FoodName { get; set; } = "Apple Turnip Pie";
        public string Description { get; set; } = "Disgusting Food";
        public int FestivalID { get; set; } = 999;
        public string Location { get; set; } = "Greenland Booth";
        public decimal Price { get; set; } = 6.99M;
        public double PopularityRating { get; set; } = 5;
        public string Cuisine { get; set; } = "Greenland";
        public string ImageUrl { get; set; } = "/images/Epcot.jpg";
        public string FoodType { get; set; } = "Dessert";
        public DateOnly StartDate { get; set; } = new DateOnly(1995, 1, 1);
        public DateOnly EndDate { get; set; } = new DateOnly(1995, 12, 31);

        public FoodModel() { }
        public FoodModel(string foodName, string description, int festivalID, string location,decimal Price, string Cuisine,
            string foodType , double populatrityRating, string ImageUrl, DateOnly start, DateOnly end)
        {
            this.FoodName = foodName;
            this.Description = description;
            this.FestivalID = festivalID;
            this.Location = location;
            this.Price = Price;
            this.Cuisine = Cuisine;
            this.PopularityRating = populatrityRating;
            this.ImageUrl = ImageUrl;
            this.FoodType = foodType;
            this.StartDate = start;
            this.EndDate = end;
        }
    }
}