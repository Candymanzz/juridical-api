using juridical_api.DTO;
using juridical_api.Models.Entities;

namespace juridical_api.Profile
{
    public class TasksProfile : AutoMapper.Profile
    {
        public TasksProfile() 
        {
            CreateMap<TasksEntities, TasksDto>();
        }
    }
}
