using SQL_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_API.Data
{
    public class MenuData : IMenuData
    {
        private readonly ISQLDataAccess _db;

        public MenuData(ISQLDataAccess db)
        {
            _db = db;
        }
        public Task<List<MenuModel>> GetParkMenuData(string ParkName)
        {
            string sql = $@"SELECT
                                Park.ParkName,
                                Park.Description ParkDescription,
                                Area.AreaName,
                                Location.LocationName,
                                Food.FoodName,
                                Food.Price,
                                Food.Cuisine,
                                Food.Description AS FoodDescription ,
                                GROUP_CONCAT(DISTINCT Allergy.AllergyName) AS Allergy,
                                GROUP_CONCAT(DISTINCT Tag.TagName) AS Tags
                            FROM Park
                            JOIN Area ON Park.ParkName = Area.ParkName
                            JOIN Location ON Area.AreaName = Location.AreaName
                            JOIN Food ON Location.LocationName = Food.LocationName
                            LEFT JOIN Allergy ON Food.FoodName = Allergy.FoodName
                            LEFT JOIN Tag ON Food.FoodName = Tag.FoodName
                            WHERE Park.ParkName = @ParkName
                            GROUP BY Food.FoodName
                            ORDER BY Area.AreaName, Location.LocationName";
            return _db.LoadData<MenuModel>(sql, new ParkModel(ParkName));
        }
    }
}
