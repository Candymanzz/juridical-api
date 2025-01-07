using juridical_api.Db;
using juridical_api.Models.Entities;
using Microsoft.EntityFrameworkCore;
using juridical_api.Contracts;
using juridical_api.DTO;
using AutoMapper;

namespace juridical_api.Repository
{
    public class PaymentsRepository : IRepository<PaymentsEntities, PaymentsDto>, IDisposable
    {
        private readonly AppDbContext appDbContext;
        private bool disposed = false;
        private readonly IMapper mapper;

        public PaymentsRepository(AppDbContext appDbContext, IMapper mapper)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
        }

        public void Create(PaymentsEntities item)
        {
            appDbContext.Payments.Add(item);
            appDbContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var payment = appDbContext.Payments.Find(id);
            if (payment != null)
            {
                appDbContext.Payments.Remove(payment);
                appDbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException($"ID: {id} not faund.");
            }
        }

        public PaymentsDto? Get(Guid id)
        {
            return mapper.ProjectTo<PaymentsDto>(appDbContext.Set<PaymentsEntities>().AsNoTracking().Where(cl => cl.Id == id)).FirstOrDefault();
        }

        public List<PaymentsDto> GetAll()
        {
            return mapper.ProjectTo<PaymentsDto>(appDbContext.Set<PaymentsEntities>().AsNoTracking()).ToList();
        }

        public void Update(Guid id, PaymentsEntities item)
        {
            var payment = appDbContext.Payments.Find(id);
            if (payment != null)
            {
                payment.PaymentDate = item.PaymentDate;
                payment.Amount = item.Amount;
                payment.Amount = item.Amount;
                payment.PaymentMethod = item.PaymentMethod;
                payment.ClientId = item.ClientId;
                payment.CaseId = item.CaseId;
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

        ~PaymentsRepository()
        {
            Dispose(false);
        }

        public bool StatusDispose()
        {
            return disposed;
        }
    }
}
