using juridical_api.Contracts;
using juridical_api.Db;
using juridical_api.Models.Entities;
using Microsoft.EntityFrameworkCore;
using juridical_api.DTO;
using AutoMapper;

namespace juridical_api.Repository
{
    public class ContractsRepository : SaveChangesDb, IRepository<ContractsEntities, ContractsDto>, IDisposable
    {
        private readonly AppDbContext appDbContext;
        private bool disposed = false;
        private readonly IMapper mapper;

        public ContractsRepository(AppDbContext appDbContext, IMapper mapper)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
        }

        public void Create(ContractsEntities item)
        {
            appDbContext.Contracts.Add(item);
            appDbContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var contract = appDbContext.Contracts.Find(id);
            if (contract != null)
            {
                appDbContext.Contracts.Remove(contract);
                appDbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException($"ID: {id} not faund.");
            }
        }

        public ContractsDto? Get(Guid id)
        {
            return mapper.ProjectTo<ContractsDto>(appDbContext.Set<ContractsEntities>().AsNoTracking().Where(cn => cn.Id == id)).FirstOrDefault();
        }

        public List<ContractsDto> GetAll()
        {
            return mapper.ProjectTo<ContractsDto>(appDbContext.Set<ContractsEntities>().AsNoTracking()).ToList();
        }

        public void Update(Guid id, ContractsEntities item)
        {
            var contract = appDbContext.Contracts.Find(id);
            if (contract != null)
            {
                contract.SigningDate = item.SigningDate;
                contract.ExpirationDate = item.ExpirationDate;
                contract.ClientId = item.ClientId;
                contract.LawyerId = item.LawyerId;
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
