/*
    Project Developed by : Austin Phillips
    Page was Implemented using Dapper ORM 
    Page Description: This page provides a set of functions to perform database operations on the tag table 

*/
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
        // Recieves interface to SQLDataAccess class to secure the connection string 
        private readonly ISQLDataAccess _db;

        public TagData(ISQLDataAccess db)
        {
            _db = db;
        }
        // Gets all allergy data from the Tag table 
        public Task<List<TagModel>> GetTagData()
        {
            string sql = $@"SELECT  *
                        FROM Tag";
            return _db.LoadData<TagModel>(sql, new { });
        }
        // Inserts a TagModel into the tag database
        public Task insertTagJob(TagModel tagItem)
        {
            string sql = @"INSERT INTO Tag (TagName, FoodName)" +
                " VALUES (@TagName, @FoodName);";
            return _db.SaveData(sql, tagItem);
        }
        // Removes a TagModel from the tag Table, ID is used for the delete 
        public Task DeleteTag(TagModel tagItem)
        {
            string sql = "DELETE FROM Tag WHERE ID = @ID;";
            return _db.SaveData(sql, tagItem);
        }
        // Update a tag entry in the tag table 
        public Task UpdateTag(TagModel tagItem)
        {
            string sql = @"UPDATE Tag SET TagName = @TagName, FoodName = @FoodName   WHERE ID = @ID;";
            return _db.SaveData(sql, tagItem);
        }
        // Get a distinct list of all the tags in the tag table 
        public Task<List<String>> GetTags()
        {
            string sql = @"select DISTINCT Tag.TagName From Tag";
            return _db.LoadData<String>(sql, new { });
        }
    }
}
