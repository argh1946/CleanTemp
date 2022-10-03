using Core.Contracts.AtmCrs;
using System;
using System.Threading.Tasks;

namespace Core.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        Task CommitAsync();
        IAtmCrsRepository AtmCrsRepository { get; }
        
    }
}
