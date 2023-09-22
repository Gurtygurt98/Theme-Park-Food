using SQL_API.Models;

namespace SQL_API.Data
{
    public interface IAllergyData
    {
        Task DeleteAllergy(AllergyModel allergyItem);
        Task<List<AllergyModel>> GetAllergyData();
        Task insertAllergy(AllergyModel allergyItem);
        Task UpdateAllergy(AllergyModel allergyItem);
    }
}