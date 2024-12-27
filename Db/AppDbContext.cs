using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using juridical_api.Configuration;
using juridical_api.Models.Entities;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CasesConfiguration());
            modelBuilder.ApplyConfiguration(new ClientsConfiguration());
            modelBuilder.ApplyConfiguration(new ContractsConfiguration());
            modelBuilder.ApplyConfiguration(new CourtHearingsConfiguration());
            modelBuilder.ApplyConfiguration(new DocumentsConfiguration());
            modelBuilder.ApplyConfiguration(new LawyersConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentsConfiguration());
            modelBuilder.ApplyConfiguration(new ReviewsConfiguration());
            modelBuilder.ApplyConfiguration(new TasksConfiguration());
        }
    }
}