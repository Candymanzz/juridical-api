using juridical_api.Contracts;
using juridical_api.Db;
using juridical_api.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace juridical_api.Repository
{
    public class ClientsRepository : SaveChangesDb, IRepository<ClientsEntities>, IDisposable 
    {
        private readonly AppDbContext appDbContext;
        private bool disposed = false;

        public ClientsRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
        }

        public async Task Create(ClientsEntities item)
        {
            await appDbContext.Clients.AddAsync(item);
            await Save(appDbContext);
        }

        public async Task Delete(Guid id)
        {
            await appDbContext.Clients.Where(cl => cl.Id == id).ExecuteDeleteAsync();

            await Save(appDbContext);
        }

        public async Task<ClientsEntities?> Get(Guid id)
        {
            return await appDbContext.Clients.AsNoTracking().FirstOrDefaultAsync(cl => cl.Id == id);
        }

        public async Task<List<ClientsEntities>> GetAll()
        {
            return await appDbContext.Clients.AsNoTracking().ToListAsync();
        }

        public async Task Update(Guid id, ClientsEntities item)
        {
            var existingClient = await appDbContext.Clients.FirstOrDefaultAsync(cl => cl.Id == id);

            if (existingClient != null)
            {
                appDbContext.Entry(existingClient).CurrentValues.SetValues(item);
                await Save(appDbContext);
            }
            else
            {
                throw new KeyNotFoundException("Client not found.");
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
        
        ~ClientsRepository()
        {
            Dispose(false);
        }

        public bool StatusDispose()
        {
            return disposed;
        }
    }
}
