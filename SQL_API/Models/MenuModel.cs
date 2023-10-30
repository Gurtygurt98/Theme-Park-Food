namespace SQL_API.Models
{
    public class MenuModel
    {
        public string ParkName { get; set; }
        public string ParkDescription { get; set; }
        public string AreaName { get; set; }
        public string LocationName { get; set; }
        public string FoodName { get; set; }
        public decimal Price { get; set; }
        public string FoodDescription { get; set; }
        public string Allergy { get; set; }
        public string Tags { get; set; }

        public MenuModel(string parkName, string parkDescription, string areaName,
            string locationName, string foodName, decimal price, string foodDescription,
            string allergies, string tags)
        {
            ParkName = parkName;
            ParkDescription = parkDescription;
            AreaName = areaName;
            LocationName = locationName;
            FoodName = foodName;
            Price = price;
            FoodDescription = foodDescription;
            Allergy = allergies;
            Tags = tags;
        }
        public MenuModel() { }
    }
}
