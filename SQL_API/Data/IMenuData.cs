using SQL_API.Models;

namespace SQL_API.Data
{
    public interface IMenuData
    {
        Task<List<MenuModel>> GetParkMenuData(string ParkName);
    }
}