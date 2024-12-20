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
        public DbSet<ClientsEntities> Clients { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}