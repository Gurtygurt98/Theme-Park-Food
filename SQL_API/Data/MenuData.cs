using SQL_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_API.Data
{
    public class MenuData
    {
        private readonly ISQLDataAccess _db;

        public MenuData(ISQLDataAccess db)
        {
            _db = db;
        }
        public Task<List<ParkModel>> GetParkMenuData(string ParkName)
        {
            string sql = $@"SELECT
                                Park.ParkName,
                                Park.Description,
                                Area.AreaName,
                                Location.LocationName,
                                Food.FoodName,
                                Food.Price,
                                Food.Description,
                                GROUP_CONCAT(DISTINCT Allergy.AllergyName) AS Allergy,
                                GROUP_CONCAT(DISTINCT Tag.TagName) AS Tag
                            FROM Park
                            JOIN Area ON Park.ParkName = Area.ParkName
                            JOIN Location ON Area.AreaName = Location.AreaName
                            JOIN Food ON Location.LocationName = Food.LocationName
                            LEFT JOIN Allergy ON Food.FoodName = Allergy.FoodName
                            LEFT JOIN Tag ON Food.FoodName = Tag.FoodName
                            WHERE Park.ParkName = @ParkName
                            GROUP BY Food.FoodName
                            ORDER BY Area.AreaName, Location.LocationName";
            return _db.LoadData<ParkModel>(sql, new { });
        }
        public Task insertArea(AreaModel AreaItem)
        {
            string sql = @"INSERT INTO Area (AreaName, ParkName)" +
                " VALUES (@AreaName, @ParkName);";
            return _db.SaveData(sql, AreaItem);
        }
        public Task DeleteArea(AreaModel AreaItem)
        {
            string sql = "DELETE FROM Area WHERE ID = @ID;";
            return _db.SaveData(sql, AreaItem);
        }
        public Task UpdateArea(AreaModel AreaItem)
        {
            string sql = @"UPDATE Area SET AreaName = @AreaName, ParkName = @ParkName  WHERE ID = @ID;";
            return _db.SaveData(sql, AreaItem);
        }
    }
}
