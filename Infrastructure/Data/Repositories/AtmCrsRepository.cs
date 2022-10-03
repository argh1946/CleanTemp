using Core.Entities;
using Microsoft.Extensions.Configuration;
using Core.Entities;
using Core.Contracts.AtmCrs;

namespace Infrastructure.Data
{
    public class AtmCrsRepository : RepositoryBase<AtmCrs>, IAtmCrsRepository
    {
        public AtmCrsRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}