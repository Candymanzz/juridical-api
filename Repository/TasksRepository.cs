using juridical_api.Db;
using juridical_api.Models.Entities;
using Microsoft.EntityFrameworkCore;
using juridical_api.Contracts;
using juridical_api.DTO;
using AutoMapper;

namespace juridical_api.Repository
{
    public class TasksRepository : IRepository<TasksEntities, TasksDto>, IDisposable
    {
        private readonly AppDbContext appDbContext;
        private bool disposed = false;
        private readonly IMapper mapper;

        public TasksRepository(AppDbContext appDbContext, IMapper mapper)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
        }

        public void Create(TasksEntities item)
        {
            appDbContext.Tasks.Add(item);
            appDbContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var task = appDbContext.Tasks.Find(id);
            if (task != null)
            {
                appDbContext.Tasks.Remove(task);
                appDbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException($"ID: {id} not faund.");
            }
        }

        public TasksDto? Get(Guid id)
        {
            return mapper.ProjectTo<TasksDto>(appDbContext.Set<TasksEntities>().AsNoTracking().Where(cl => cl.Id == id)).FirstOrDefault();
        }

        public List<TasksDto> GetAll()
        {
            return mapper.ProjectTo<TasksDto>(appDbContext.Set<TasksEntities>().AsNoTracking()).ToList();
        }

        public void Update(Guid id, TasksEntities item)
        {
            var task = appDbContext.Tasks.Find(id);
            if (task != null)
            {
                task.TaskDescription = item.TaskDescription;
                task.DateOfCompletion = item.DateOfCompletion;
                task.Status = item.Status;
                task.CaseId = item.CaseId;
                task.LawyerId = item.LawyerId;
                appDbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException($"ID: {id} not faund.");
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    appDbContext?.Dispose();
                }

                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~TasksRepository()
        {
            Dispose(false);
        }

        public bool StatusDispose()
        {
            return disposed;
        }
    }
}
