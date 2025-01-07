using juridical_api.Db;
using juridical_api.Models.Entities;
using Microsoft.EntityFrameworkCore;
using juridical_api.Contracts;
using juridical_api.DTO;
using AutoMapper;

namespace juridical_api.Repository
{
    public class CourtHearingsRepository : SaveChangesDb, IRepository<CourtHearingsEntities, CourtHearingsDto>, IDisposable
    {
        private readonly AppDbContext appDbContext;
        private bool disposed = false;
        private readonly IMapper mapper;

        public CourtHearingsRepository(AppDbContext appDbContext, IMapper mapper)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(appDbContext));
            this.appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
        }

        public void Create(CourtHearingsEntities item)
        {
            appDbContext.CourtHearings.Add(item);
            appDbContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var courtHearing = appDbContext.CourtHearings.Find(id);
            if (courtHearing != null)
            {
                appDbContext.CourtHearings.Remove(courtHearing);
                appDbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException($"ID: {id} not faund.");
            }
        }

        public CourtHearingsDto? Get(Guid id)
        {
            return mapper.ProjectTo<CourtHearingsDto>(appDbContext.Set<CourtHearingsEntities>().AsNoTracking().Where(cl => cl.Id == id)).FirstOrDefault();
        }

        public List<CourtHearingsDto> GetAll()
        {
            return mapper.ProjectTo<CourtHearingsDto>(appDbContext.Set<CourtHearingsEntities>().AsNoTracking()).ToList();
        }

        public void Update(Guid id, CourtHearingsEntities item)
        {
            var courtHearing = appDbContext.CourtHearings.Find(id);
            if (courtHearing != null)
            {
                courtHearing.HearingDate = item.HearingDate;
                courtHearing.Place = item.Place;
                courtHearing.CaseId = item.CaseId;
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
