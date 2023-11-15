using SQL_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_API.Data
{
    public class AllergyData : IAllergyData
    {
        private readonly ISQLDataAccess _db;

        public AllergyData(ISQLDataAccess db)
        {
            _db = db;
        }
        public Task<List<AllergyModel>> GetAllergyData()
        {
            string sql = $@"SELECT  *
                        FROM Allergy";
            return _db.LoadData<AllergyModel>(sql, new { });
        }
        public Task insertAllergy(AllergyModel allergyItem)
        {
            string sql = @"INSERT INTO Allergy (AllergyName, FoodName)" +
                " VALUES (@AllergyName, @FoodName);";
            return _db.SaveData(sql, allergyItem);
        }
        public Task DeleteAllergy(AllergyModel allergyItem)
        {
            string sql = "DELETE FROM Allergy WHERE ID = @ID;";
            return _db.SaveData(sql, allergyItem);
        }
        public Task UpdateAllergy(AllergyModel allergyItem)
        {
            string sql = @"UPDATE Area SET AllergyName = @AllergyName, FoodName = @FoodName  WHERE ID = @ID;";
            return _db.SaveData(sql, allergyItem);
        }
        public Task<List<String>> GetAllergies()
        {
            string sql = @"select DISTINCT Allergy.AllergyName From Allergy";
            return _db.LoadData<String>(sql, new { });
        }
    }
}
