using juridical_api.DTO;
using juridical_api.Models.Entities;

namespace juridical_api.Profile
{
    public class CourtHearingsProfile : AutoMapper.Profile
    {
        CourtHearingsProfile()
        {
            CreateMap<CourtHearingsEntities, CourtHearingsDto>();
        }
    }
}
