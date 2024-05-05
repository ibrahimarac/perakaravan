using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Perakaravan.Data.Context;
using Perakaravan.Domain.Common;
using Perakaravan.Domain.Repositories;
using Perakaravan.InfraPack.Domain;
using Perakaravan.InfraPack.Extensions;

namespace Perakaravan.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PeraContext _context;
        private bool _disposed = false;

        private readonly LoggedUser _loggedUser;
        private readonly ILoginUserRepository loginUserRepository;
        private readonly ISliderRepository sliderRepository;
        private readonly ISiteStaticRepository siteStaticRepository;

        public UnitOfWork(PeraContext context, LoggedUser loggedUser)
        {
            _context = context;
            _loggedUser = loggedUser;

            loginUserRepository = loginUserRepository ?? new LoginUserRepository(_context);
            sliderRepository = sliderRepository ?? new SliderRepository(_context);   
            siteStaticRepository = siteStaticRepository ?? new SiteStaticRepository(_context);
        }


        public ILoginUserRepository LoginUserRepository => loginUserRepository;
        public ISliderRepository SliderRepository => sliderRepository;
        public ISiteStaticRepository SiteStaticRepository => siteStaticRepository;


        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }


        public async Task<bool> CommitAsync()
        {
            foreach (var entry in _context.ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Added && entry.Entity is Entity addedEntity)
                {
                    addedEntity.CreatedTime = DateTime.UtcNow.ToTurkeyLocalTime();
                    addedEntity.UpdatedUser = _loggedUser.Username ?? "admin";
                }
                else if (entry.State == EntityState.Deleted && entry.Entity is Entity deletedEntity)
                {
                    entry.State = EntityState.Modified;
                    deletedEntity.UpdatedUser = _loggedUser.Username ?? "admin";
                    deletedEntity.UpdatedTime = DateTime.UtcNow.ToTurkeyLocalTime();
                    deletedEntity.IsDeleted = true;
                }
                else if (entry.State == EntityState.Modified && entry.Entity is Entity modifiedEntity)
                {
                    modifiedEntity.UpdatedUser = _loggedUser.Username ?? "admin";
                    modifiedEntity.UpdatedTime = DateTime.UtcNow.ToTurkeyLocalTime();
                }
            }
            return await _context.SaveChangesAsync() > 0;
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                // free managed resources (.net objeleri)
                _context.Dispose();
            }
            // free unmanaged resource. (Başka dillerde yazılıp C# içerisinde kullanılan com veya dll kütüphaneleri) 
            _disposed = true;
        }
    }
}
