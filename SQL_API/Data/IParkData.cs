using SQL_API.Models;

namespace SQL_API.Data
{
    public interface IParkData
    {
        Task DeletePark(ParkModel parkItem);
        Task<List<ParkModel>> GetParkData();
        Task insertPark(ParkModel parkItem);
        Task UpdatePark(ParkModel parkItem);
        Task<List<ParkModel>> GetParkSingle(string ParkName);
    }
}