using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using SQL_API.Models;

namespace SQL_API.Data
{
    public class FestivalData : IFestivalData
    {
        private readonly ISQLDataAccess _db;

        public FestivalData(ISQLDataAccess db)
        {
            _db = db;
        }
        public Task insertFestivalJob(FestivalModel festivalItem)
        {
            string sql = @"INSERT INTO Festival (Name, StartDate, EndDate,Location,Description)" +
                " VALUES (@Name , @Start , @End , @Location , @Description);";
            return _db.SaveData(sql, festivalItem);
        }
    }
}
