using Perakaravan.Application.Repositories;
using Perakaravan.Data.Context;
using Perakaravan.Domain.Entities;

namespace Perakaravan.Data.Repositories
{
    public class LoginUserRepository : Repository<LoginUser>, ILoginUserRepository
    {

        public LoginUserRepository(PeraContext context) : base(context) { }


    }
}
