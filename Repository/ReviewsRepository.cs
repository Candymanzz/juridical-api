using AutoMapper;
using juridical_api.Contracts;
using juridical_api.Db;
using juridical_api.DTO;
using juridical_api.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace juridical_api.Repository
{
    public class ReviewsRepository : IRepository<ReviewsEntities, ReviewsDto>, IDisposable
    {
        private readonly AppDbContext appDbContext;
        private bool disposed = false;
        private readonly IMapper mapper;

        public ReviewsRepository(AppDbContext appDbContext, IMapper mapper)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
        }

        public void Create(ReviewsEntities item)
        {
            appDbContext.Reviews.Add(item);
            appDbContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var review = appDbContext.Reviews.Find(id);
            if (review != null)
            {
                appDbContext.Reviews.Remove(review);
                appDbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException($"ID: {id} not faund.");
            }
        }

        public ReviewsDto? Get(Guid id)
        {
            return mapper.ProjectTo<ReviewsDto>(appDbContext.Set<ReviewsEntities>().AsNoTracking().Where(cl => cl.Id == id)).FirstOrDefault();
        }

        public List<ReviewsDto> GetAll()
        {
            return mapper.ProjectTo<ReviewsDto>(appDbContext.Set<ReviewsEntities>().AsNoTracking()).ToList();
        }

        public void Update(Guid id, ReviewsEntities item)
        {
            var review = appDbContext.Reviews.Find(id);
            if (review != null)
            {
                review.Rating = item.Rating;
                review.Comment = item.Comment;
                review.Date = item.Date;
                review.ClientId = item.ClientId;
                review.LawyerId = item.LawyerId;
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

        ~ReviewsRepository()
        {
            Dispose(false);
        }

        public bool StatusDispose()
        {
            return disposed;
        }
    }
}
