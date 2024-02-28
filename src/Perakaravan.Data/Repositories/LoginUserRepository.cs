using Perakaravan.Data.Context;
using Perakaravan.Domain.Entities;
using Perakaravan.Domain.Repositories;

namespace Perakaravan.Data.Repositories
{
    public class LoginUserRepository : Repository<LoginUser>, ILoginUserRepository
    {

        public LoginUserRepository(PeraContext context) : base(context) { }


    }
}
