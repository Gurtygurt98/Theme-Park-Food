using SQL_API.Models;

namespace SQL_API.Data
{
    public interface IFestivalData
    {
        Task<List<FestivalModel>> GetFestivalData();
        Task insertFestivalJob(FestivalModel festivalItem);
    }
}