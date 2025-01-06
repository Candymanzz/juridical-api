using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using juridical_api.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace juridical_api.Configuration
{
    public class ClientsConfiguration : IEntityTypeConfiguration<ClientsEntities>
    { 
        public void Configure(EntityTypeBuilder<ClientsEntities> builder)
        {
            builder.HasKey(cl => cl.Id);

            builder.HasOne(cl => cl.Review).
                WithOne(r => r.Client).
                HasForeignKey<ReviewsEntities>(r => r.ClientId);
            builder.HasOne(cl => cl.Payment).
                WithOne(p => p.Client).
                HasForeignKey<PaymentsEntities>(p => p.ClientId);
            builder.HasOne(cl => cl.Case).
                WithOne(cs => cs.Client).
                HasForeignKey<CasesEntities>(cs => cs.ClientId);
            builder.HasOne(cl => cl.Contract).
                WithOne(cn => cn.Client).
                HasForeignKey<ContractsEntities>(cn => cn.ClientId);

            builder.HasData
            (
                new ClientsEntities
                {
                    Id = new Guid("8B9658B8-49C1-423A-A807-71D1706710E1"),
                    FirstName = "Slava",
                    LastName = "Spanish",
                    Email = "Dadaya@gmail.com",
                    Phone = "+3226232109",
                    Address = "Nemecia, Frankich 22 / 1",
                },
                new ClientsEntities
                {
                    Id = new Guid("8B9238B8-49C1-423A-A807-71D170671123"),
                    FirstName = "Slava",
                    LastName = "Spanish",
                    Email = "Dadaya@gmail.com",
                    Phone = "+3226232109",
                    Address = "Nemecia, Frankich 22 / 1",
                }
            );
        }
    }
}