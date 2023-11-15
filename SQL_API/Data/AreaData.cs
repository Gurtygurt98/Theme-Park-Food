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
        private readonly ISQLDataAccess _db;

        public AreaData(ISQLDataAccess db)
        {
            _db = db;
        }
        public Task<List<AreaModel>> GetAreaData()
        {
            string sql = $@"SELECT  *
                        FROM Area";
            return _db.LoadData<AreaModel>(sql, new { });
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
        public Task<List<String>> GetAllAreas(string ParkName)
        {
            string sql = $@"select DISTINCT Area.AreaName From Area Where ParkName = @ParkName";
            return _db.LoadData<String>(sql, new { ParkName });
        }
    }
}
