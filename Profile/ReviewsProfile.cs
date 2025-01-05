using juridical_api.DTO;
using juridical_api.Models.Entities;

namespace juridical_api.Profile
{
    public class ReviewsProfile : AutoMapper.Profile
    {
        ReviewsProfile()
        {
            CreateMap<ReviewsEntities, ReviewsDto>();
        }
    }
}
