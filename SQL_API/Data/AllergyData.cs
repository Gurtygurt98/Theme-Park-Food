/*
    Project Developed by : Austin Phillips
    Page was Implemented using Dapper ORM 
    Page Description: This page provides a set of functions to perform database operations on the allergy table 

*/
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
        // Recieves interface to SQLDataAccess class to secure the connection string 
        private readonly ISQLDataAccess _db;

        public AllergyData(ISQLDataAccess db)
        {
            _db = db;
        }
        // Gets all allergy data from the allergy table 
        public Task<List<AllergyModel>> GetAllergyData()
        {
            string sql = $@"SELECT  *
                        FROM Allergy";
            return _db.LoadData<AllergyModel>(sql, new { });
        }
        // Inserts a AllergyModel into the allergy database
        public Task insertAllergy(AllergyModel allergyItem)
        {
            string sql = @"INSERT INTO Allergy (AllergyName, FoodName)" +
                " VALUES (@AllergyName, @FoodName);";
            return _db.SaveData(sql, allergyItem);
        }
        // Removes a AllergyModel from the Allergy Table, ID is used for the delete 
        public Task DeleteAllergy(AllergyModel allergyItem)
        {
            string sql = "DELETE FROM Allergy WHERE ID = @ID;";
            return _db.SaveData(sql, allergyItem);
        }
        // Update a allergy entry in the allergy table 
        public Task UpdateAllergy(AllergyModel allergyItem)
        {
            string sql = @"UPDATE Area SET AllergyName = @AllergyName, FoodName = @FoodName  WHERE ID = @ID;";
            return _db.SaveData(sql, allergyItem);
        }
        // Get a distinct list of all the allergies in the allergy table 
        public Task<List<String>> GetAllergies()
        {
            string sql = @"select DISTINCT Allergy.AllergyName From Allergy";
            return _db.LoadData<String>(sql, new { });
        }
    }
}
