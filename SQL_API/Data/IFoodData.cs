using SQL_API.Models;

namespace SQL_API.Data
{
    public interface IFoodData
    {
        Task DeleteFood(FoodModel foodItem);
        Task<List<FoodModel>> GetFoodData();
        Task insertFood(FoodModel foodItem);
        Task UpdateFood(FoodModel foodItem);
    }
}