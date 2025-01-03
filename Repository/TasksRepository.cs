using juridical_api.Db;
using juridical_api.Models.Entities;
using Microsoft.EntityFrameworkCore;
using juridical_api.Contracts;

namespace juridical_api.Repository
{
    public class TasksRepository : SaveChangesDb, IRepository<TasksEntities>, IDisposable
    {
        private readonly AppDbContext appDbContext;
        private bool disposed = false;

        public TasksRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
        }

        public async Task Create(TasksEntities item)
        {
            await appDbContext.Tasks.AddAsync(item);
            await Save(appDbContext);
        }

        public async Task Delete(Guid id)
        {
            await appDbContext.Tasks.Where(cl => cl.Id == id).ExecuteDeleteAsync();
            await Save(appDbContext);
        }

        public async Task<TasksEntities?> Get(Guid id)
        {
            return await appDbContext.Tasks.AsNoTracking().FirstOrDefaultAsync(cl => cl.Id == id);
        }

        public async Task<List<TasksEntities>> GetAll()
        {
            return await appDbContext.Tasks.AsNoTracking().ToListAsync();
        }

        public async Task Update(Guid id, TasksEntities item)
        {
            var existingClient = await appDbContext.Tasks.FirstOrDefaultAsync(cl => cl.Id == id);

            if (existingClient != null)
            {
                appDbContext.Entry(existingClient).CurrentValues.SetValues(item);
                await Save(appDbContext);
            }
            else
            {
                throw new KeyNotFoundException("Task not found.");
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
