/*
    Project Developed by : Austin Phillips
    Page was Implemented using Dapper ORM 
    Page Description: This page provides a set of functions to perform database operations on the Festival table 

*/
using SQL_API.Models;


namespace SQL_API.Data
{
    public class FestivalData : IFestivalData
    {
        // Recieves interface to SQLDataAccess class to secure the connection string 
        private readonly ISQLDataAccess _db;

        public FestivalData(ISQLDataAccess db)
        {
            _db = db;
        }
        // Gets all festival data from the festival table 
        public Task<List<FestivalModel>> GetFestivalData()
        {
            string sql = $@"SELECT  *
                        FROM Festival";
            return _db.LoadData<FestivalModel>(sql, new { });
        }
        // Inserts a FestivalModel into the festival database
        public Task insertFestival(FestivalModel festivalItem)
        {
            string sql = @"INSERT INTO Festival (FestivalName, StartDate, EndDate, ParkName, Description)" +
                " VALUES (@FestivalName , @StartDate , @EndDate , @ParkName , @Description);";
            return _db.SaveData(sql, festivalItem);
        }
        // Removes a FestivalModel from the Festival Table, ID is used for the delete 
        public Task DeleteFestival(FestivalModel festivalItem)
        {
            string sql = "DELETE FROM Festival WHERE ID = @ID;";
            return _db.SaveData(sql, festivalItem);
        }
        // Update a festival entry in the festival table 

        public Task UpdateFestival(FestivalModel festivalItem)
        {
            string sql = @"UPDATE FESTIVAL  SET FestivalName = @FestivalName, StartDate = @StartDate, EndDate = @EndDate, ParkName = @ParkName, Description = @Description    WHERE ID = @ID;";
            return _db.SaveData(sql, festivalItem);
        }
        // Gets a single festivalModel from a parameter of the festival name 
        public Task<List<FestivalModel>> GetFestivalSingle(string FestivalName)
        {
            string sql = $@"SELECT  *
                        FROM Festival WHERE FestivalName = @FestivalName";
            var parameters = new { FestivalName };
            return _db.LoadData<FestivalModel>(sql, parameters);
        }
        // Main method to build a festival menu 
        public async Task<FestivalModel> GetFestivalMenuAsync(string FestivalName)
        {
            // A single festival model repersents the entire festival menu 
            FestivalModel FestivalMenu = new FestivalModel();
            string sql = $@"SELECT Festival.FestivalName,  Festival.Description
                        FROM Festival WHERE FestivalName = @FestivalName";
            var parameters = new { FestivalName };
            // Get the Park Description 
            List<FestivalModel> festivalModels = new List<FestivalModel>();
            festivalModels = (await GetFestivalSingle(FestivalName));
            if (festivalModels.Any())
            {
                FestivalMenu = festivalModels.First();
            } else
            {
                Console.WriteLine(FestivalName);
                Console.WriteLine(parameters);
                return null;
            }
            // Get the Locations's for the park given in the function 

            sql = $@"SELECT Location.LocationName
                            FROM Location
                            WHERE Location.FestivalName = @FestivalName";

            FestivalMenu.Locations = await _db.LoadData<LocationModel>(sql, parameters);
            // For each location the food is added 
            foreach (LocationModel location in FestivalMenu.Locations)
            {
                // SQL query to get Food items along with their Allergies and Tags for a specific location
                sql = $@"SELECT Food.ID, Food.FoodName, Food.Description, Food.LocationName, Food.Price, 
                Food.Cuisine, Food.FoodType, Food.ImageUrl, Food.StartDate, Food.EndDate,
                GROUP_CONCAT(DISTINCT Allergy.AllergyName) AS Allergies, 
                GROUP_CONCAT(DISTINCT Tag.TagName) AS Tags
                    FROM Food
                    LEFT JOIN Allergy ON Food.FoodName = Allergy.FoodName
                    LEFT JOIN Tag ON Food.FoodName = Tag.FoodName
                    WHERE Food.LocationName = @LocationName
                    GROUP BY Food.ID";
                var par3 = new { LocationName = location.LocationName };

                // Execute the query and map the results to FoodModel, including Allergies and Tags

                location.Foods = await _db.LoadData<FoodModel>(sql, par3);
            }
            return FestivalMenu;
        }
    }
}
