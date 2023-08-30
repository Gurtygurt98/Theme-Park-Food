namespace SQL_API.Data
{
    public interface ISQLDataAccess
    {
        string ConnectionString { get; }

        Task<List<T>> LoadData<T>(string sql, object queryParameters = null);
        Task SaveData<T>(string sql, T parameters);
    }
}