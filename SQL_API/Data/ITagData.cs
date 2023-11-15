using SQL_API.Models;

namespace SQL_API.Data
{
    public interface ITagData
    {
        Task DeleteTag(TagModel tagItem);
        Task<List<TagModel>> GetTagData();
        Task<List<string>> GetTags();
        Task insertTagJob(TagModel tagItem);
        Task UpdateTag(TagModel tagItem);
    }
}