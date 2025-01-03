using juridical_api.Contracts;
using juridical_api.Db;
using juridical_api.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace juridical_api.Repository
{
    public class ReviewsRepository : SaveChangesDb, IRepository<ReviewsEntities>, IDisposable
    {
        private readonly AppDbContext appDbContext;
        private bool disposed = false;

        public ReviewsRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
        }

        public async Task Create(ReviewsEntities item)
        {
            await appDbContext.Reviews.AddAsync(item);
            await Save(appDbContext);
        }

        public async Task Delete(Guid id)
        {
            await appDbContext.Reviews.Where(cl => cl.Id == id).ExecuteDeleteAsync();
            await Save(appDbContext);
        }

        public async Task<ReviewsEntities?> Get(Guid id)
        {
            return await appDbContext.Reviews.AsNoTracking().FirstOrDefaultAsync(cl => cl.Id == id);
        }

        public async Task<List<ReviewsEntities>> GetAll()
        {
            return await appDbContext.Reviews.AsNoTracking().ToListAsync();
        }

        public async Task Update(Guid id, ReviewsEntities item)
        {
            var existingClient = await appDbContext.Reviews.FirstOrDefaultAsync(cl => cl.Id == id);

            if (existingClient != null)
            {
                appDbContext.Entry(existingClient).CurrentValues.SetValues(item);
                await Save(appDbContext);
            }
            else
            {
                throw new KeyNotFoundException("Review not found.");
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

        ~ReviewsRepository()
        {
            Dispose(false);
        }

        public bool StatusDispose()
        {
            return disposed;
        }
    }
}
