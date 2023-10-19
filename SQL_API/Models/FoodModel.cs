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
        public string FoodName { get; set; } = "";
        public string Description { get; set; } 
        public string LocationName { get; set; }
        public decimal Price { get; set; }
        public string Cuisine { get; set; }
        public string ImageUrl { get; set; }
        public string FoodType { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public FoodModel() { }
        public FoodModel(string foodName, string description, string location,decimal Price, string Cuisine,
            string foodType , string ImageUrl, string start, string end)
        {
            this.FoodName = foodName;
            this.Description = description;
            this.LocationName = location;
            this.Price = Price;
            this.Cuisine = Cuisine;
            this.ImageUrl = ImageUrl;
            this.FoodType = foodType;
            this.StartDate = start;
            this.EndDate = end;
        }
        public FoodModel(int id,string foodName, string description, string location, decimal Price, string Cuisine,
    string foodType, string ImageUrl, string start, string end)
        {
            this.ID = id; 
            this.FoodName = foodName;
            this.Description = description;
            this.LocationName = location;
            this.Price = Price;
            this.Cuisine = Cuisine;
            this.ImageUrl = ImageUrl;
            this.FoodType = foodType;
            this.StartDate = start;
            this.EndDate = end;
        }
        // Equals method comparing only FoodName
        public override bool Equals(object obj)
        {
            if (obj is FoodModel other)
            {
                return string.Equals(FoodName, other.FoodName, StringComparison.OrdinalIgnoreCase);
            }
            return false;
        }

        // GetHashCode method using FoodName's hash code
        public override int GetHashCode()
        {
            return StringComparer.OrdinalIgnoreCase.GetHashCode(FoodName);
        }

        // ToString method displaying FoodName
        public override string ToString()
        {
            return FoodName;
        }
    }
}