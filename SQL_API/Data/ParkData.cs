using SQL_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_API.Data
{
    public class ParkData : IParkData
    {
        private readonly ISQLDataAccess _db;

        public ParkData(ISQLDataAccess db)
        {
            _db = db;
        }
        public Task<List<ParkModel>> GetParkData()
        {
            string sql = $@"SELECT  *
                        FROM Park";
            return _db.LoadData<ParkModel>(sql, new { });
        }
        public Task insertPark(ParkModel parkItem)
        {
            string sql = @"INSERT INTO Park (ParkName, Description)" +
                " VALUES (@ParkName, @Description);";
            return _db.SaveData(sql, parkItem);
        }
        public Task DeletePark(ParkModel parkItem)
        {
            string sql = "DELETE FROM Park WHERE ParkName = @ParkName;";
            return _db.SaveData(sql, parkItem);
        }
        public Task UpdatePark(ParkModel parkItem)
        {
            string sql = @"UPDATE Park SET ParkName = @ParkName, Description = @Description  WHERE ID = @ID;";
            return _db.SaveData(sql, parkItem);
        }
        public Task<List<ParkModel>> GetParkSingle(string ParkName)
        {
            string sql = $@"SELECT  *
                        FROM Park WHERE ParkName = @ParkName";
            var parameters = new { ParkName };
            return _db.LoadData<ParkModel>(sql, parameters);
        }

        public async Task<ParkModel> GetParkMenuAsync(string ParkName)
        {
            ParkModel ParkMenu = new ParkModel();
            ParkMenu.ParkName = ParkName;
            string sql = $@"SELECT Park.ParkName,  Park.Description
                        FROM Park WHERE ParkName = @ParkName";
            var parameters = new { ParkName };
            // Get the Park Description 
            ParkMenu = (await GetParkSingle(ParkName)).First();
            // Get the Area's for the park given in the function 
            sql = $@"select Area.AreaName 
                            from Park 
                            JOIN Area on Park.ParkName = Area.ParkName 
                            where Park.ParkName = @ParkName";
            parameters = new { ParkName };
            ParkMenu.Areas = await _db.LoadData<AreaModel>(sql, parameters);
            // For each area the locations are added 
            foreach (AreaModel area in ParkMenu.Areas)
            {
                sql = $@"SELECT Location.LocationName
                 FROM Area
                 JOIN Location ON Area.AreaName = Location.AreaName
                 WHERE Area.AreaName = @AreaName";
                var par2 = new { AreaName = area.AreaName };

                area.Locations = await _db.LoadData<LocationModel>(sql, par2);
                // For each location the food is added 
                foreach (LocationModel location in area.Locations)
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
            }
            return ParkMenu;
        }
    }
}
