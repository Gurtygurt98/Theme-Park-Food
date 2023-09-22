using SQL_API.Models;

namespace SQL_API.Data
{
    public interface IAreaData
    {
        Task DeleteArea(AreaModel AreaItem);
        Task<List<AreaModel>> GetAreaData();
        Task insertArea(AreaModel AreaItem);
        Task UpdateArea(AreaModel AreaItem);
    }
}