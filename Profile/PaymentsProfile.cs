using juridical_api.DTO;
using juridical_api.Models.Entities;

namespace juridical_api.Profile
{
    public class PaymentsProfile : AutoMapper.Profile
    {
        PaymentsProfile()
        {
            CreateMap<PaymentsEntities, PaymentsDto>();
        }
    }
}