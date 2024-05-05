using Microsoft.EntityFrameworkCore.Storage;

namespace Perakaravan.Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        public ILoginUserRepository LoginUserRepository { get; }
        public ISliderRepository SliderRepository { get; }
        public ISiteStaticRepository SiteStaticRepository { get; }

        IDbContextTransaction BeginTransaction();
        Task<bool> CommitAsync();
    }
}
