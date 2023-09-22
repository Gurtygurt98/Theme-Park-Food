using SQL_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_API.Data
{
    public class TagData : ITagData
    {
        private readonly ISQLDataAccess _db;

        public TagData(ISQLDataAccess db)
        {
            _db = db;
        }
        public Task<List<TagModel>> GetAllergyData()
        {
            string sql = $@"SELECT  *
                        FROM Tag";
            return _db.LoadData<TagModel>(sql, new { });
        }
        public Task insertTagJob(TagModel tagItem)
        {
            string sql = @"INSERT INTO Tag (TagName, FoodName)" +
                " VALUES (@TagName, @FoodName);";
            return _db.SaveData(sql, tagItem);
        }
        public Task DeleteTag(TagModel tagItem)
        {
            string sql = "DELETE FROM Tag WHERE ID = @ID;";
            return _db.SaveData(sql, tagItem);
        }
        public Task UpdateTag(TagModel tagItem)
        {
            string sql = @"UPDATE Tag SET TagName = @TagName, FoodName = @FoodName   WHERE ID = @ID;";
            return _db.SaveData(sql, tagItem);
        }
    }
}
