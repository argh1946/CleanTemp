
using Core.Helper;

namespace Core.Contracts.AtmCrs
{
    public interface IAtmCrsRepository : IAsyncGenericRepository<Entities.AtmCrs>
    {
        Task<PaginatedList<Entities.AtmCrs>> GetAllPaginated();
    }
}
