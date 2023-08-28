using SQL_API.Models;

namespace SQL_API.Data
{
    public interface IFestivalData
    {
        Task insertFestivalJob(FestivalModel FoodItem);
    }
}