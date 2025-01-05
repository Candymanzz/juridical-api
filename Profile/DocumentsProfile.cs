using juridical_api.DTO;
using juridical_api.Models.Entities;

namespace juridical_api.Profile
{
    public class DocumentsProfile : AutoMapper.Profile
    {
        DocumentsProfile()
        {
            CreateMap<DocumentsEntities, DocumentsDto>();
        }
    }
}
