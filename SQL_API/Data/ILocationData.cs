using SQL_API.Models;

namespace SQL_API.Data
{
    public interface ILocationData
    {
        Task DeleteLocation(LocationModel locationItem);
        Task<List<LocationModel>> GetLocationData();
        Task insertLocation(LocationModel locationItem);
        Task UpdateLocation(LocationModel locationItem);
    }
}