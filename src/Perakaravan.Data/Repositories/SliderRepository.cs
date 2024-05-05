using Perakaravan.Data.Context;
using Perakaravan.Domain.Entities;
using Perakaravan.Domain.Repositories;

namespace Perakaravan.Data.Repositories
{
    public class SliderRepository : Repository<Slider>, ISliderRepository
    {

        public SliderRepository(PeraContext context) : base(context) { }


    }
}
