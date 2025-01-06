using juridical_api.DTO;
using juridical_api.Models.Entities;

namespace juridical_api.Profile
{
    public class LawyersProfile : AutoMapper.Profile
    {
        public LawyersProfile()
        {
            CreateMap<LawyersEntities, LawyersDto>();
        }
    }
}
