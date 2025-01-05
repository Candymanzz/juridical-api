using juridical_api.DTO;
using juridical_api.Models.Entities;

namespace juridical_api.Profile
{
    public class CasesProfile : AutoMapper.Profile
    {
        public CasesProfile()
        {
            CreateMap<CasesEntities, CasesDto>();
        }
    }
}
