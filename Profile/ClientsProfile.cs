using juridical_api.DTO;
using juridical_api.Models.Entities;
using juridical_api.Contracts;
using juridical_api.Db;
using Microsoft.EntityFrameworkCore;
using AutoMapper;


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
