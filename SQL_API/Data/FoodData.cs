using SQL_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_API.Data
{
    public class FoodData : IFoodData
    {
        private readonly ISQLDataAccess _db;

        public FoodData(ISQLDataAccess db)
        {
            _db = db;
        }
        public Task<List<FoodModel>> GetFoodData()
        {
            string sql = $@"SELECT  *
                        FROM Food";
            return _db.LoadData<FoodModel>(sql, new { });
        }
        public Task insertFood(FoodModel foodItem)
        {
            string sql = @"INSERT INTO Food (FoodName, Description, LocationName, Price, Cuisine, FoodType, PopularityRating, ImageUrl, StartDate, EndDate) " +
                         "VALUES (@FoodName, @Description, @LocationName, @Price, @Cuisine, @FoodType, @PopularityRating, @ImageUrl, @StartDate, @EndDate);";
            return _db.SaveData(sql, foodItem);
        }
        public Task DeleteFood(FoodModel foodItem)
        {
            string sql = "DELETE FROM Food WHERE ID = @ID;";
            return _db.SaveData(sql, foodItem);
        }
        public Task UpdateFood(FoodModel foodItem)
        {
            string sql = @"UPDATE Food SET FoodName = @FoodName, StartDate = @StartDate, EndDate = @EndDate, LocationName = @LocationName, Description = @Description,  WHERE ID = @ID;";
            return _db.SaveData(sql, foodItem);
        }
    }
}
