using Microsoft.EntityFrameworkCore;
using juridical_api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace juridical_api.Db
{
    public class AppDbContext : DbContext
    {
        public DbSet<CasesEntities> Cases { get; set; }
        public DbSet<ClientsEntities> Clients { get; set; }
        public DbSet<ContractsEntities> Contracts { get; set; }
        public DbSet<CourtHearingsEntities> CourtHearings { get; set; }
        public DbSet<DocumentsEntities> Documents { get; set; }
        public DbSet<LawyersEntities> Lawyers { get; set; }
        public DbSet<PaymentsEntities> Payments { get; set; }
        public DbSet<ReviewsEntities> Reviews { get; set; }
        public DbSet<TasksEntities> Tasks { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}