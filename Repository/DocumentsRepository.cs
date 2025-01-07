using juridical_api.Db;
using juridical_api.Models.Entities;
using Microsoft.EntityFrameworkCore;
using juridical_api.Contracts;
using juridical_api.DTO;
using AutoMapper;

namespace juridical_api.Repository
{
    public class DocumentsRepository : IRepository<DocumentsEntities, DocumentsDto>, IDisposable
    {
        private readonly AppDbContext appDbContext;
        private bool disposed = false;
        private readonly IMapper mapper;

        public DocumentsRepository(AppDbContext appDbContext, IMapper mapper)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
        }

        public void Create(DocumentsEntities item)
        {
            appDbContext.Documents.Add(item);
            appDbContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var document = appDbContext.Documents.Find(id);
            if (document != null)
            {
                appDbContext.Documents.Remove(document);
                appDbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException($"ID: {id} not faund.");
            }
        }

        public DocumentsDto? Get(Guid id)
        {
            return mapper.ProjectTo<DocumentsDto>(appDbContext.Set<DocumentsEntities>().AsNoTracking().Where(d => d.Id == id)).FirstOrDefault();
        }

        public List<DocumentsDto> GetAll()
        {
            return mapper.ProjectTo<DocumentsDto>(appDbContext.Set<DocumentsEntities>().AsNoTracking()).ToList();
        }

        public void Update(Guid id, DocumentsEntities item)
        {
            var document = appDbContext.Documents.Find(id);
            if (document != null)
            {
                document.DocumentName = item.DocumentName;
                document.CreationDate = item.CreationDate;
                document.DocumentType = item.DocumentType;
                document.DocumentText = item.DocumentText;
                document.CaseId = item.CaseId;
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
