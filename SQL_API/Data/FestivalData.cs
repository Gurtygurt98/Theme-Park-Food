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
        public Task<List<FestivalModel>> GetFestivalData()
        {
            string sql = $@"SELECT  *
                        FROM Festival";
            return _db.LoadData<FestivalModel>(sql, new { });
        }
        public Task insertFestival(FestivalModel festivalItem)
        {
            string sql = @"INSERT INTO Festival (FestivalName, StartDate, EndDate, ParkName, Description)" +
                " VALUES (@FestivalName , @StartDate , @EndDate , @ParkName , @Description);";
            return _db.SaveData(sql, festivalItem);
        }
        public Task DeleteFestival(FestivalModel festivalItem)
        {
            string sql = "DELETE FROM Festival WHERE ID = @ID;";
            return _db.SaveData(sql, festivalItem);
        }
        public Task UpdateFestival(FestivalModel festivalItem)
        {
            string sql = @"UPDATE FESTIVAL  SET FestivalName = @FestivalName, StartDate = @StartDate, EndDate = @EndDate, ParkName = @ParkName, Description = @Description    WHERE ID = @ID;";
            return _db.SaveData(sql, festivalItem);
        }
    }
}
