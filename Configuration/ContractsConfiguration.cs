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
            builder.HasData
            (
                new ContractsEntities
                {
                    Id = 1,
                    SigningDate = new DateTime(2001, 11, 02),
                    ExpirationDate = new DateTime(2001, 12, 11),
                    ClientId = 1,
                    LawyerId = 1
                }
            );
        }
    }
}