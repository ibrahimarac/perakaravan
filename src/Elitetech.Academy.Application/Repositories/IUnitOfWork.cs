using Microsoft.EntityFrameworkCore.Storage;

namespace Perakaravan.Application.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        public ILoginUserRepository LoginUserRepository { get; }


        IDbContextTransaction BeginTransaction();
        Task<bool> CommitAsync();
    }
}
