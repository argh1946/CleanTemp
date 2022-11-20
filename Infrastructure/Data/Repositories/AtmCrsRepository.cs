using Core.Entities;
using Core.Contracts.AtmCrs;
using Core.Helper;

namespace Infrastructure.Data.Repositories
{
    public class AtmCrsRepository : RepositoryBase<AtmCrs>, IAtmCrsRepository
    {
        public AtmCrsRepository(ApplicationDbContext db) : base(db)
        {
        }

        public async Task<PaginatedList<AtmCrs>> GetAllPaginated()
        {
            var r = await _db.Set<AtmCrs>().AsQueryable().PaginatedListAsync();
            return r;
        }
    }
}