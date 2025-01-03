using juridical_api.Contracts;
using juridical_api.Db;
using juridical_api.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace juridical_api.Repository
{
    public class LawyersRepository : SaveChangesDb, IRepository<LawyersEntities>, IDisposable
    {
        private readonly AppDbContext appDbContext;
        private bool disposed = false;

        public LawyersRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
        }

        public async Task Create(LawyersEntities item)
        {
            await appDbContext.Lawyers.AddAsync(item);
            await Save(appDbContext);
        }

        public async Task Delete(Guid id)
        {
            await appDbContext.Lawyers.Where(cl => cl.Id == id).ExecuteDeleteAsync();
            await Save(appDbContext);
        }

        public async Task<LawyersEntities?> Get(Guid id)
        {
            return await appDbContext.Lawyers.AsNoTracking().FirstOrDefaultAsync(cl => cl.Id == id);
        }

        public async Task<List<LawyersEntities>> GetAll()
        {
            return await appDbContext.Lawyers.AsNoTracking().ToListAsync();
        }

        public async Task Update(Guid id, LawyersEntities item)
        {
            var existingClient = await appDbContext.Lawyers.FirstOrDefaultAsync(cl => cl.Id == id);

            if (existingClient != null)
            {
                appDbContext.Entry(existingClient).CurrentValues.SetValues(item);
                await Save(appDbContext);
            }
            else
            {
                throw new KeyNotFoundException("Lawyer not found.");
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

        ~LawyersRepository()
        {
            Dispose(false);
        }

        public bool StatusDispose()
        {
            return disposed;
        }
    }
}
