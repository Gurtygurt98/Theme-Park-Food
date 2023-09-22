using SQL_API.Models;

namespace SQL_API.Data
{
    public interface IFestivalData
    {
        Task DeleteFestival(FestivalModel festivalItem);
        Task<List<FestivalModel>> GetFestivalData();
        Task insertFestival(FestivalModel festivalItem);
        Task UpdateFestival(FestivalModel festivalItem);
    }
}