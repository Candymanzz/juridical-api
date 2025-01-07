using juridical_api.Contracts;
using juridical_api.Db;
using juridical_api.Models.Entities;
using Microsoft.EntityFrameworkCore;
using juridical_api.DTO;
using AutoMapper;

namespace juridical_api.Repository
{
    public class ClientsRepository : IRepository<ClientsEntities, ClientsDto>, IDisposable 
    {
        private readonly AppDbContext appDbContext;
        private bool disposed = false;
        private readonly IMapper mapper;

        public ClientsRepository(AppDbContext appDbContext, IMapper mapper)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
        }

        public void Create(ClientsEntities item)
        {
            appDbContext.Clients.Add(item);
            appDbContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var client = appDbContext.Clients.Find(id);
            if (client != null)
            {
                appDbContext.Clients.Remove(client);
                appDbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException($"ID: {id} not faund.");
            }
        }

        public ClientsDto? Get(Guid id)
        {
            return mapper.ProjectTo<ClientsDto>(appDbContext.Set<ClientsEntities>().AsNoTracking().Where(cl => cl.Id == id)).FirstOrDefault();
        }

        public List<ClientsDto> GetAll()
        {
            return mapper.ProjectTo<ClientsDto>(appDbContext.Set<ClientsEntities>().AsNoTracking()).ToList();
        }

        public void Update(Guid id, ClientsEntities item)
        {
            var client = appDbContext.Clients.Find(id);
            if (client != null)
            {
                client.FirstName = item.FirstName;
                client.LastName = item.LastName;
                client.Email = item.Email;
                client.Phone = item.Phone;
                client.Address = item.Address;
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
