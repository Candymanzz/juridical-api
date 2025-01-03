using juridical_api.Contracts;
using juridical_api.Db;
using juridical_api.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace juridical_api.Repository
{
    public class ContractsRepository : SaveChangesDb, IRepository<ContractsEntities>, IDisposable
    {
        private readonly AppDbContext appDbContext;
        private bool disposed = false;

        public ContractsRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
        }

        public async Task Create(ContractsEntities item)
        {
            await appDbContext.Contracts.AddAsync(item);
            await Save(appDbContext);
        }

        public async Task Delete(Guid id)
        {
            await appDbContext.Contracts.Where(cl => cl.Id == id).ExecuteDeleteAsync();
            await Save(appDbContext);
        }

        public async Task<ContractsEntities?> Get(Guid id)
        {
            return await appDbContext.Contracts.AsNoTracking().FirstOrDefaultAsync(cl => cl.Id == id);
        }

        public async Task<List<ContractsEntities>> GetAll()
        {
            return await appDbContext.Contracts.AsNoTracking().ToListAsync();
        }

        public async Task Update(Guid id, ContractsEntities item)
        {
            var existingClient = await appDbContext.Contracts.FirstOrDefaultAsync(cl => cl.Id == id);

            if (existingClient != null)
            {
                appDbContext.Entry(existingClient).CurrentValues.SetValues(item);
                await Save(appDbContext);
            }
            else
            {
                throw new KeyNotFoundException("Contract not found.");
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

        ~ContractsRepository()
        {
            Dispose(false);
        }

        public bool StatusDispose()
        {
            return disposed;
        }
    }
}
