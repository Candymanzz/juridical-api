using juridical_api.Db;
using juridical_api.Models.Entities;
using Microsoft.EntityFrameworkCore;
using juridical_api.Contracts;

namespace juridical_api.Repository
{
    public class CasesRepository : SaveChangesDb, IRepository<CasesEntities>, IDisposable
    {
        private readonly AppDbContext appDbContext;
        private bool disposed = false;

        public CasesRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
        }

        public async Task Create(CasesEntities item)
        {
            await appDbContext.Cases.AddAsync(item);
            await Save(appDbContext);
        }

        public async Task Delete(Guid id)
        {
            await appDbContext.Cases.Where(cl => cl.Id == id).ExecuteDeleteAsync();
            await Save(appDbContext);
        }

        public async Task<CasesEntities?> Get(Guid id)
        {
            return await appDbContext.Cases.AsNoTracking().FirstOrDefaultAsync(cl => cl.Id == id);
        }

        public async Task<List<CasesEntities>> GetAll()
        {
            return await appDbContext.Cases.AsNoTracking().ToListAsync();
        }

        public async Task Update(Guid id, CasesEntities item)
        {
            var existingClient = await appDbContext.Cases.FirstOrDefaultAsync(cl => cl.Id == id);

            if (existingClient != null)
            {
                appDbContext.Entry(existingClient).CurrentValues.SetValues(item);
                await Save(appDbContext);
            }
            else
            {
                throw new KeyNotFoundException("Case not found.");
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

        ~CasesRepository()
        {
            Dispose(false);
        }

        public bool StatusDispose()
        {
            return disposed;
        }
    }
}
