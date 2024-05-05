using Perakaravan.Data.Context;
using Perakaravan.Domain.Entities;
using Perakaravan.Domain.Repositories;

namespace Perakaravan.Data.Repositories
{
    public class SiteStaticRepository : Repository<SiteStatic>, ISiteStaticRepository
    {

        public SiteStaticRepository(PeraContext context) : base(context) { }


    }
}
