using SQL_API.Models;

namespace SQL_API.Data
{
    public interface IFoodData
    {
        Task insertPrintJob(FoodModel FoodItem);
    }
}