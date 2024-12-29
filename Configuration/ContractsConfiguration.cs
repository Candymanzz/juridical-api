using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using juridical_api.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace juridical_api.Configuration
{
    public class ContractsConfiguration : IEntityTypeConfiguration<ContractsEntities>
    {
        public void Configure(EntityTypeBuilder<ContractsEntities> builder)
        {
            builder.HasKey(cn => cn.Id);

            builder.HasOne(cn => cn.Client).WithOne(cl => cl.Contract);
            builder.HasOne(cn => cn.Lawyer).WithOne(l => l.Contract);

            builder.HasData
            (
                new ContractsEntities
                {
                    Id = new Guid("8B9658B8-49C1-423A-A807-71D1706710E3"),
                    SigningDate = new DateTime(2001, 11, 02),
                    ExpirationDate = new DateTime(2001, 12, 11),
                    ClientId = new Guid("8B9658B8-49C1-423A-A807-71D1706710E1"),
                    LawyerId = new Guid("8B9658B8-49C1-423A-A807-71D1706710E2")
                }
            );
        }
    }
}