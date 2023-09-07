﻿using SQL_API.Models;


namespace SQL_API.Data
{
    public class FestivalData : IFestivalData
    {
        private readonly ISQLDataAccess _db;

        public FestivalData(ISQLDataAccess db)
        {
            _db = db;
        }
        public Task<List<FestivalModel>> GetFestivalData()
        {
            string sql = $@"SELECT  *
                        FROM Festival";
            return _db.LoadData<FestivalModel>(sql, new { });
        }
        public Task insertFestivalJob(FestivalModel festivalItem)
        {
            string sql = @"INSERT INTO Festival (Name, StartDate, EndDate,Location,Description)" +
                " VALUES (@Name , @StartDate , @EndDate , @Location , @Description);";
            return _db.SaveData(sql, festivalItem);
        }
        public Task DeleteFestival(FestivalModel festivalItem)
        {
            string sql = "DELETE FROM Festival WHERE ID = @ID;";
            return _db.SaveData(sql, festivalItem);
        }
        public Task UpdateFestival(FestivalModel festivalItem)
        {
            Console.WriteLine(festivalItem.ToString());
            string sql = @"UPDATE FESTIVAL  SET NAME = @Name, StartDate = @StartDate, EndDate = @EndDate, Location = @Location, Description = @Description    WHERE ID = @ID;";
            return _db.SaveData(sql, festivalItem);
        }
    }
}
