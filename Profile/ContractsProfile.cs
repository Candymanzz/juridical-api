using juridical_api.DTO;
using juridical_api.Models.Entities;
using AutoMapper;

namespace juridical_api.Profile
{
    public class ContractsProfile : AutoMapper.Profile
    {
        ContractsProfile() 
        {
            CreateMap<ContractsEntities, ContractsDto>();
        }
    }
}
