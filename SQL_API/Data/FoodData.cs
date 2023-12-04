/*
    Project Developed by : Austin Phillips
    Page was Implemented using Dapper ORM 
    Page Description: This page provides a set of functions to perform database operations on the Food table 

*/
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
        // Recieves interface to SQLDataAccess class to secure the connection string 
        private readonly ISQLDataAccess _db;

        public FoodData(ISQLDataAccess db)
        {
            _db = db;
        }
        // Gets all food data from the food table 
        public Task<List<FoodModel>> GetFoodData()
        {
            string sql = $@"SELECT  *
                        FROM Food";
            return _db.LoadData<FoodModel>(sql, new { });
        }
        // Inserts a FoodModel into the food database

        public Task insertFood(FoodModel foodItem)
        {
            string sql = @"INSERT INTO Food (FoodName, Description, LocationName, Price, Cuisine, FoodType, ImageUrl, StartDate, EndDate) " +
                         "VALUES (@FoodName, @Description, @LocationName, @Price, @Cuisine, @FoodType, @ImageUrl, @StartDate, @EndDate);";
            return _db.SaveData(sql, foodItem);
        }
        // Removes a FoodModel from the Food Table, ID is used for the delete 
        public Task DeleteFood(FoodModel foodItem)
        {
            string sql = "DELETE FROM Food WHERE ID = @ID;";
            return _db.SaveData(sql, foodItem);
        }
        // Update a food entry in the food table 
        public Task UpdateFood(FoodModel foodItem)
        {
            string sql = @"UPDATE Food SET FoodName = @FoodName, StartDate = @StartDate, EndDate = @EndDate, LocationName = @LocationName, Description = @Description  WHERE ID = @ID;";
            return _db.SaveData(sql, foodItem);
        }
    }
}
