using SQL_API.Models;

namespace SQL_API.Data
{
    public interface ITagData
    {
        Task DeleteTag(TagModel tagItem);
        Task<List<TagModel>> GetAllergyData();
        Task insertTagJob(TagModel tagItem);
        Task UpdateTag(TagModel tagItem);
    }
}