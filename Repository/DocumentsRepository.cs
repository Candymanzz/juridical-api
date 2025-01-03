using juridical_api.Db;
using juridical_api.Models.Entities;
using Microsoft.EntityFrameworkCore;
using juridical_api.Contracts;

namespace juridical_api.Repository
{
    public class DocumentsRepository : SaveChangesDb, IRepository<DocumentsEntities>, IDisposable
    {
        private readonly AppDbContext appDbContext;
        private bool disposed = false;

        public DocumentsRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
        }

        public async Task Create(DocumentsEntities item)
        {
            await appDbContext.Documents.AddAsync(item);
            await Save(appDbContext);
        }

        public async Task Delete(Guid id)
        {
            await appDbContext.Documents.Where(cl => cl.Id == id).ExecuteDeleteAsync();
            await Save(appDbContext);
        }

        public async Task<DocumentsEntities?> Get(Guid id)
        {
            return await appDbContext.Documents.AsNoTracking().FirstOrDefaultAsync(cl => cl.Id == id);
        }

        public async Task<List<DocumentsEntities>> GetAll()
        {
            return await appDbContext.Documents.AsNoTracking().ToListAsync();
        }

        public async Task Update(Guid id, DocumentsEntities item)
        {
            var existingClient = await appDbContext.Documents.FirstOrDefaultAsync(cl => cl.Id == id);

            if (existingClient != null)
            {
                appDbContext.Entry(existingClient).CurrentValues.SetValues(item);
                await Save(appDbContext);
            }
            else
            {
                throw new KeyNotFoundException("Document not found.");
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

        ~DocumentsRepository()
        {
            Dispose(false);
        }

        public bool StatusDispose()
        {
            return disposed;
        }
    }
}
