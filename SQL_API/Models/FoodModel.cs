using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_API.Models
{
    public class FoodModel
    {
        public string FoodName { get; set; }
        public string Description { get; set; }
        public int FestivalID { get; set; }
        public string Location { get; set; }
        public decimal Price { get; set; }
        public List<TagModel> Tags { get; set; }
        public string CuisineType { get; set; }

        public FoodModel() { }
        public FoodModel(string foodName, string description, int festivalID, string location,decimal Price, string Cuisine, string foodType , decimal populatrityRating, string ImageUrl,List<TagModel> tags)
        {
            this.FoodName = foodName;
            this.Description = description;
            this.FestivalID = festivalID;
            this.Location = location;
            this.Price = Price;
            this.Cuisine = Cuisine;
            this.PopularityRating = populatrityRating;
            this.ImageUrl = ImageUrl;
            this.Tags = tags;
            this.FoodType = foodType;
       
    }
}
}