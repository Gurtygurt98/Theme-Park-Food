using System.Data;
using Dapper;
using System.Data.SQLite;
using Microsoft.Extensions.Configuration;

namespace SQL_API.Data
{
    public class SQLDataAccess : ISQLDataAccess
    {
        private readonly IConfiguration _config;

        public SQLDataAccess(IConfiguration config)
        {
            _config = config;
        }

        public string ConnectionString => _config.GetConnectionString("Default");

        public async Task<List<T>> LoadData<T>(string sql, object queryParameters = null)
        {
            using (IDbConnection connection = new SQLiteConnection(ConnectionString))
            {
                var data = await connection.QueryAsync<T>(sql, queryParameters);
                return data.ToList();
            }
        }

        public async Task SaveData<T>(string sql, T parameters)
        {
            using (IDbConnection connection = new SQLiteConnection(ConnectionString))
            {
                await connection.ExecuteAsync(sql, parameters);
            }
        }
    }
}
