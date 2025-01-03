using juridical_api.Db;
using juridical_api.Models.Entities;
using Microsoft.EntityFrameworkCore;
using juridical_api.Contracts;

namespace juridical_api.Repository
{
    public class CourtHearingsRepository : SaveChangesDb, IRepository<CourtHearingsEntities>, IDisposable
    {
        private readonly AppDbContext appDbContext;
        private bool disposed = false;

        public CourtHearingsRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
        }

        public async Task Create(CourtHearingsEntities item)
        {
            await appDbContext.CourtHearings.AddAsync(item);
            await Save(appDbContext);
        }

        public async Task Delete(Guid id)
        {
            await appDbContext.CourtHearings.Where(cl => cl.Id == id).ExecuteDeleteAsync();
            await Save(appDbContext);
        }

        public async Task<CourtHearingsEntities?> Get(Guid id)
        {
            return await appDbContext.CourtHearings.AsNoTracking().FirstOrDefaultAsync(cl => cl.Id == id);
        }

        public async Task<List<CourtHearingsEntities>> GetAll()
        {
            return await appDbContext.CourtHearings.AsNoTracking().ToListAsync();
        }

        public async Task Update(Guid id, CourtHearingsEntities item)
        {
            var existingClient = await appDbContext.CourtHearings.FirstOrDefaultAsync(cl => cl.Id == id);

            if (existingClient != null)
            {
                appDbContext.Entry(existingClient).CurrentValues.SetValues(item);
                await Save(appDbContext);
            }
            else
            {
                throw new KeyNotFoundException("Court hearings not found.");
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

        ~CourtHearingsRepository()
        {
            Dispose(false);
        }

        public bool StatusDispose()
        {
            return disposed;
        }
    }
}
