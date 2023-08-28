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
        public Task insertFestivalJob(FestivalModel FoodItem)
        {
            string sql = @"INSERT INTO Festival (TYPE, PRINTED, BASEID,INPUT_ARGS,CREATE_DATE,CREATOR)" +
                " VALUES (@Name , @Start , @End , @Location , @Description);";
            return _db.SaveData(sql, FoodItem);
        }
    }
}
