
namespace Core.Contracts.AtmCrs
{
    public interface IAtmCrsService
    {
        Task<IEnumerable<Entities.AtmCrs>> GetAllAsync();
        Task<Entities.AtmCrs> GetByIdAsync(int id);
        Task AddAsync(Entities.AtmCrs atmCrs);
        Task Update(Entities.AtmCrs atmCrs);
        Task DeleteAsync(int id);
    }
}
