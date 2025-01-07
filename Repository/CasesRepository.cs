using juridical_api.Db;
using juridical_api.Models.Entities;
using Microsoft.EntityFrameworkCore;
using juridical_api.Contracts;
using juridical_api.DTO;
using AutoMapper;

namespace juridical_api.Repository
{
    public class CasesRepository : SaveChangesDb, IRepository<CasesEntities, CasesDto>, IDisposable
    {
        private readonly AppDbContext appDbContext;
        private bool disposed = false;
        private readonly IMapper mapper;

        public CasesRepository(AppDbContext appDbContext, IMapper mapper)
        {
            this.appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public void Create(CasesEntities item)
        {
            appDbContext.Cases.Add(item);
            appDbContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var case_ = appDbContext.Cases.Find(id);
            if (case_ != null)
            {
                appDbContext.Cases.Remove(case_);
                appDbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException($"ID: {id} not faund.");
            }
        }

        public CasesDto? Get(Guid id)
        {
            return mapper.ProjectTo<CasesDto>(appDbContext.Set<CasesEntities>().AsNoTracking().Where(cs => cs.Id == id)).FirstOrDefault();
        }

        public List<CasesDto> GetAll()
        {
            return mapper.ProjectTo<CasesDto>(appDbContext.Set<CasesEntities>().AsNoTracking()).ToList();
        }

        public void Update(Guid id, CasesEntities item)
        {
            var case_ = appDbContext.Cases.Find(id);
            if (case_ != null)
            {
                case_.CaseName = item.CaseName;
                case_.Description = item.Description;
                case_.OpeningDate = item.OpeningDate;
                case_.ClientId = item.ClientId;
                case_.LawyerId = item.LawyerId;
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
