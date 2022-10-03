using Core.Contracts;
using Core.Contracts.AtmCrs;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        protected ApplicationDbContext _db { get; private set; }
        private IServiceProvider _serviceProvider;
        private bool _disposed;

        public UnitOfWork(ApplicationDbContext db, IServiceProvider serviceProvider)
        {
            _db = db;
            _serviceProvider = serviceProvider;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_db != null)
                    {
                        _db.Dispose();
                        _db = null;
                    }
                }
                _disposed = true;
            }
        }

        public async Task CommitAsync()
        {
            await _db.SaveChangesAsync();
        }

        public IAtmCrsRepository AtmCrsRepository => _serviceProvider.GetRequiredService<IAtmCrsRepository>();       
           
    }
}