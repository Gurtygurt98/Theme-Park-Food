using System.Data;
using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;

namespace SQL_API.Data
{
    public class SQLDataAccess : ISQLDataAccess
    {
        // IConfiguration comes in from the front end through injection, placd in appsettings 
        private readonly IConfiguration _config;
        public string ConnectionStringName { get; set; } = Environment.CurrentDirectory + "\\DisneyFoodApp.db"; 
        public SQLDataAccess(IConfiguration config)
        {
            _config = config;
        }
        public async Task<List<T>> LoadData<T, U>(string sql, U parameters)
        {
            string connectionString = _config.GetConnectionString(ConnectionStringName);
            using (IDbConnection connection = new SqliteConnection(connectionString))
            {
                // Queries the database given a sql query as string sql and 
                // Query Async returns a Iennumurable 
                var data = await connection.QueryAsync<T>(sql, parameters);
                return data.ToList();
            }
        }
        public async Task SaveData<T>(string sql, T parameters)
        {
            string connectionString = _config.GetConnectionString(ConnectionStringName);
            Console.WriteLine(connectionString + " Run");
            using (IDbConnection connection = new SqliteConnection(connectionString))
            {
                await connection.ExecuteAsync(sql, parameters);
            }

        }
    }
}
