using Core.Contracts;
using Core.Contracts.AtmCrs;
using Core.DTOs;
using Core.Entities;
using Core.Helper;

namespace Core.UseCases
{
    public class AtmCrsService : IAtmCrsService
    {
        private readonly IUnitOfWork _uow;
        public AtmCrsService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task AddAsync(AtmCrs atmCrs)
        {
            await _uow.AtmCrsRepository.AddAsync(atmCrs);
            await _uow.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _uow.AtmCrsRepository.DeleteAsync(id);
            await _uow.CommitAsync();
        }

        public async Task<IEnumerable<AtmCrs>> GetAllAsync()
        {
            var data = await _uow.AtmCrsRepository.GetAllAsync(null, x => x.OrderByDescending(x => x.Id));
            return data;
           
        }

        public async Task<PaginatedList<AtmCrs>> GetAllPaginated()
        {
            var data = await _uow.AtmCrsRepository.GetAllPaginated();
            return data;

        }

        public async Task<AtmCrs> GetByIdAsync(int id)
        {
            var data = await _uow.AtmCrsRepository.GetByIdAsync(id);
            return data;
        }

        public async Task Update(AtmCrs atmCrs)
        {
            _uow.AtmCrsRepository.Update(atmCrs);
            await _uow.CommitAsync();
        }
    }
}