using juridical_api.DTO;
using juridical_api.Models.Entities;

namespace juridical_api.Profile
{
    public class ClientsProfile : AutoMapper.Profile
    {
        public ClientsProfile()
        {
            CreateMap<ClientsEntities, ClientsDto>();
        }
    }
}
