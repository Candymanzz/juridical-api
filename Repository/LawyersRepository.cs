using AutoMapper;
using juridical_api.Contracts;
using juridical_api.Db;
using juridical_api.DTO;
using juridical_api.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace juridical_api.Repository
{
    public class LawyersRepository : IRepository<LawyersEntities, LawyersDto>, IDisposable
    {
        private readonly AppDbContext appDbContext;
        private bool disposed = false;
        private readonly IMapper mapper;

        public LawyersRepository(AppDbContext appDbContext, IMapper mapper)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(appDbContext));
            this.appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
        }

        public void Create(LawyersEntities item)
        {
            appDbContext.Lawyers.Add(item);
            appDbContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var lawyers = appDbContext.Lawyers.Find(id);
            if (lawyers != null)
            {
                appDbContext.Lawyers.Remove(lawyers);
                appDbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException($"ID: {id} not faund.");
            }
        }

        public LawyersDto? Get(Guid id)
        {
            return mapper.ProjectTo<LawyersDto>(appDbContext.Set<LawyersEntities>().AsNoTracking().Where(l => l.Id == id)).FirstOrDefault();
        }

        public List<LawyersDto> GetAll()
        {
            return mapper.ProjectTo<LawyersDto>(appDbContext.Set<LawyersEntities>().AsNoTracking()).ToList();
        }

        public void Update(Guid id, LawyersEntities item)
        {
            var lawyers = appDbContext.Lawyers.Find(id);
            if (lawyers != null)
            {
                lawyers.FirstName = item.FirstName;
                lawyers.LastName = item.LastName;
                lawyers.Specialization = item.Specialization;
                lawyers.Phone = item.Phone;
                lawyers.Email = item.Email;
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
