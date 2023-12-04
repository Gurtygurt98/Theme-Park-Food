/*
    Project Developed by : Austin Phillips
    Page was Implemented using Dapper ORM 
    Page Description: This page provides a set of functions to perform database operations on the area table 

*/
using SQL_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_API.Data
{
    public class AreaData : IAreaData
    {
        // Recieves interface to SQLDataAccess class to secure the connection string 
        private readonly ISQLDataAccess _db;

        public AreaData(ISQLDataAccess db)
        {
            _db = db;
        }
        // Gets all allergy data from the area table 
        public Task<List<AreaModel>> GetAreaData()
        {
            string sql = $@"SELECT  *
                        FROM Area";
            return _db.LoadData<AreaModel>(sql, new { });
        }
        // Inserts a AreaModel into the area database
        public Task insertArea(AreaModel AreaItem)
        {
            string sql = @"INSERT INTO Area (AreaName, ParkName)" +
                " VALUES (@AreaName, @ParkName);";
            return _db.SaveData(sql, AreaItem);
        }
        // Removes a AreaModel from the Area Table, ID is used for the delete 
        public Task DeleteArea(AreaModel AreaItem)
        {
            string sql = "DELETE FROM Area WHERE ID = @ID;";
            return _db.SaveData(sql, AreaItem);
        }
        // Update a area entry in the area table 

        public Task UpdateArea(AreaModel AreaItem)
        {
            string sql = @"UPDATE Area SET AreaName = @AreaName, ParkName = @ParkName  WHERE ID = @ID;";
            return _db.SaveData(sql, AreaItem);
        }
        // Get a distinct list of all the area in the area table 
        public Task<List<String>> GetAllAreas(string ParkName)
        {
            string sql = $@"select DISTINCT Area.AreaName From Area Where ParkName = @ParkName";
            return _db.LoadData<String>(sql, new { ParkName });
        }
    }
}
