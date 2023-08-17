using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SQL_API
{
    public class FoodData : IFoodData
    {
        private readonly ISQLDataAccess _db;

        public FoodData(ISQLDataAccess db)
        {
            this._db = db;
        }
        public Task insertPrintJob(FoodModel FoodItem)
        {
            string sql = @"INSERT INTO dbo.Label_Print (TYPE, PRINTED, BASEID,INPUT_ARGS,CREATE_DATE,CREATOR)" +
                " VALUES (@TYPE, @PRINTED, @BASEID, @INPUT_ARGS, CURRENT_TIMESTAMP,@CREATOR);";
            return _db.SaveData(sql, FoodItem);
        }
    }
}
