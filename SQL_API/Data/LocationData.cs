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
        private readonly ISQLDataAccess _db;

        public LocationData(ISQLDataAccess db)
        {
            _db = db;
        }
        public Task<List<LocationModel>> GetLocationData()
        {
            string sql = $@"SELECT  *
                        FROM Location";
            return _db.LoadData<LocationModel>(sql, new { });
        }
        public Task insertLocation(LocationModel locationItem)
        {
            string sql = @"INSERT INTO Location (LocationName, FestivalName,AreaName)" +
                " VALUES (@LocationName,@FestivalName, @AreaName);";
            return _db.SaveData(sql, locationItem);
        }
        public Task DeleteLocation(LocationModel locationItem)
        {
            string sql = "DELETE FROM Location WHERE ID = @ID;";
            return _db.SaveData(sql, locationItem);
        }
        public Task UpdateLocation(LocationModel locationItem)
        {
            string sql = @"UPDATE Location SET LocationName = @LocationName, FestivalName = @FestivalName, AreaName = @AreaName   WHERE ID = @ID;";
            return _db.SaveData(sql, locationItem);
        }
    }
}
