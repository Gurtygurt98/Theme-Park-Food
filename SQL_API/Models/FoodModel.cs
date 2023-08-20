using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_API.Models
{
    public class FoodModel
    {
        string Name { get; set; }
        public int IDFood { get; set; }
        string Description { get; set; }
        public FestivalModels Festival { get; set; }
        public decimal Price { get; set; }
        public List<TagModel> Tags { get; set; }
        public string CuisineType { get; set; }

        public FoodModel() { }
       
    }
}