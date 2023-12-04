/*
    Project Developed by : Austin Phillips
    Page was Implemented using Dapper ORM 
    Page Description: This page provides a set of functions to perform database operations on the location table 
*/
using SQL_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_API.Data
{
    public class LocationData : ILocationData
    {
        // Recieves interface to SQLDataAccess class to secure the connection string 
        private readonly ISQLDataAccess _db;

        public LocationData(ISQLDataAccess db)
        {
            _db = db;
        }
        // Gets all location data from the location table 
        public Task<List<LocationModel>> GetLocationData()
        {
            string sql = $@"SELECT  *
                        FROM Location";
            return _db.LoadData<LocationModel>(sql, new { });
        }
        // Inserts a LocationModel into the location database
        public Task insertLocation(LocationModel locationItem)
        {
            string sql = @"INSERT INTO Location (LocationName, FestivalName,AreaName)" +
                " VALUES (@LocationName,@FestivalName, @AreaName);";
            return _db.SaveData(sql, locationItem);
        }
        // Removes a LocationModel from the Location Table, ID is used for the delete 
        public Task DeleteLocation(LocationModel locationItem)
        {
            string sql = "DELETE FROM Location WHERE ID = @ID;";
            return _db.SaveData(sql, locationItem);
        }
        // Update a location entry in the location table 
        public Task UpdateLocation(LocationModel locationItem)
        {
            string sql = @"UPDATE Location SET LocationName = @LocationName, FestivalName = @FestivalName, AreaName = @AreaName   WHERE ID = @ID;";
            return _db.SaveData(sql, locationItem);
        }
        // Get a  list of all the locations in the location table where the park name for that location is equal to the specified park name 
        public Task<List<String>> GetLocations(string ParkName)
        {
            string sql = @"SELECT Location.LocationName 
                FROM Area 
                JOIN Location ON Area.AreaName = Location.AreaName 
                WHERE Area.ParkName = @ParkName;";
            return _db.LoadData<String>(sql, new { ParkName });
        }
        // Get a list of all the locations in the location table where the park name for that location is equal to the specified festival name 
        public Task<List<String>> GetLocationsFestivals(string FestivalName)
        {
            string sql = @"SELECT Location.LocationName 
                FROM Location 
                WHERE Location.FestivalName = @FestivalName;";
            return _db.LoadData<String>(sql, new { FestivalName });
        }
    }
}
