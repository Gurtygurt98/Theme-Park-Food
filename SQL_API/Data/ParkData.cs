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
    }
}
