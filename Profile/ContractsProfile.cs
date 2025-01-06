using juridical_api.DTO;
using juridical_api.Models.Entities;

namespace juridical_api.Profile
{
    public class ContractsProfile : AutoMapper.Profile
    {
        public ContractsProfile() 
        {
            CreateMap<ContractsEntities, ContractsDto>();
        }
    }
}
